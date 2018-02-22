using MetroFramework.Forms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GoogleGeolocation
{
    public partial class MainForm : MetroForm
    {
        #region Windows Presentation - Snapping and Grips and anti-flicker

        protected override void WndProc(ref Message message)
        {
            try
            {
                if (message.Msg == WM_SYSCOMMAND && (message.WParam.ToInt32() & 0xfff0) == SC_SIZE)
                {
                    int isDragFullWindow;
                    GetSystemParametersInfo(SPI_GETDRAGFULLWINDOWS, 0, out isDragFullWindow, 0);

                    if (isDragFullWindow != 0)
                        SetSystemParametersInfo(SPI_SETDRAGFULLWINDOWS, 0, 0, 0);

                    base.WndProc(ref message);

                    if (isDragFullWindow != 0)
                        SetSystemParametersInfo(SPI_SETDRAGFULLWINDOWS, 1, 0, 0);
                }
                else
                {
                    base.WndProc(ref message);

                    if (message.Msg == 0x84) // WM_NCHITTEST
                    {
                        var cursor = PointToClient(Cursor.Position);

                        if (TopLeft.Contains(cursor)) message.Result = (IntPtr)HTTOPLEFT;
                        else if (TopRight.Contains(cursor)) message.Result = (IntPtr)HTTOPRIGHT;
                        else if (BottomLeft.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
                        else if (BottomRight.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;

                        else if (Top.Contains(cursor)) message.Result = (IntPtr)HTTOP;
                        else if (Left.Contains(cursor)) message.Result = (IntPtr)HTLEFT;
                        else if (Right.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
                        else if (Bottom.Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    "Google Geolocation encountered a fatal error and must be restarted. Please contact support with this message: " +
                    e.Message, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Variables for borderless form resize

        private const int SnapDist = 100;

        private const int
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17;

        private const int m_height = 10;

        private new Rectangle Top => new Rectangle(0, 0, ClientSize.Width, m_height);

        private new Rectangle Left => new Rectangle(0, 0, m_height, ClientSize.Height);

        private new Rectangle Bottom => new Rectangle(0, ClientSize.Height - m_height, ClientSize.Width, m_height);

        private new Rectangle Right => new Rectangle(ClientSize.Width - m_height, 0, m_height, ClientSize.Height);

        private Rectangle TopLeft => new Rectangle(0, 0, m_height, m_height);
        private Rectangle TopRight => new Rectangle(ClientSize.Width - m_height, 0, m_height, m_height);
        private Rectangle BottomLeft => new Rectangle(0, ClientSize.Height - m_height, m_height, m_height);

        private Rectangle BottomRight => new Rectangle(ClientSize.Width - m_height, ClientSize.Height - m_height,
            m_height, m_height);

        #endregion

        #region Variables for no content while resizing

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo", CharSet = CharSet.Auto)]
        public static extern int GetSystemParametersInfo(int uAction, int uParam, out int lpvParam, int fuWinIni);

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo", CharSet = CharSet.Auto)]
        public static extern int SetSystemParametersInfo(int uAction, int uParam, int lpvParam, int fuWinIni);

        private const int SPI_GETDRAGFULLWINDOWS = 38;
        private const int SPI_SETDRAGFULLWINDOWS = 37;

        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_SIZE = 0xF000;

        #endregion

        #region Double Buffering and Shadow

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;

                //  cp.ClassStyle |= 0x20000;  // Drop shadow on form
                //  cp.Style |= 0x20000 | 0x80000 | 0x40000; //WS_MINIMIZEBOX | WS_SYSMENU | WS_SIZEBOX;
                //  cp.Style &= ~0x02000000; // Turn off WS_CLIPCHILDREN

                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED     
                cp.Style |= 0x40000; // WS_SIZEBOX;

                return cp;
            }
        }

        public void SetAllControlsDoubleBuffered(Control parentControl)
        {
            var controls = GetAllControls(parentControl);

            foreach (var control in controls)
                typeof(Control).InvokeMember("DoubleBuffered",
                    BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, control, new object[] { true });
        }

        private List<Control> GetAllControls(Control container, List<Control> list)
        {
            foreach (Control c in container.Controls)
            {
                if (c is DataGridView)
                    list.Add(c);

                if (c.Controls.Count > 0)
                    list = GetAllControls(c, list);
            }

            return list;
        }

        private List<Control> GetAllControls(Control container)
        {
            return GetAllControls(container, new List<Control>());
        }

        #endregion

        private Thread processThread;

        public static void EnsureBrowserEmulationEnabled(string exename = "MarkdownMonster.exe", bool uninstall = false)
        {

            try
            {
                using (
                    var rk = Registry.CurrentUser.OpenSubKey(
                            @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true)
                )
                {
                    if (!uninstall)
                    {
                        dynamic value = rk.GetValue(exename);
                        if (value == null)
                            rk.SetValue(exename, (uint)11001, RegistryValueKind.DWord);
                    }
                    else
                        rk.DeleteValue(exename);
                }
            }
            catch
            {
                // do nothing
            }
        }

        public MainForm()
        {
            InitializeComponent();
            EnsureBrowserEmulationEnabled();

            lblLatLong.Text = "Latitude / Longitude:";
            lblLatLong.ReadOnly = true;
            lblLatLong.BorderStyle = 0;
            lblLatLong.BackColor = this.BackColor;
            lblLatLong.TabStop = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetGoButtonGreen();

            AttemptToLoadApiKey();

            tbAddressField.Focus();
            tbAddressField.Select();

            LoadMapHTML("Centenary Court, Croft St, Burnley BB11 2ED", true);
        }

        private void ProcessAddresses()
        {
            processThread = new Thread(ThreadWorker);
            processThread.Start();
        }

        private void ThreadWorker()
        {
            Thread.CurrentThread.IsBackground = true;

            string api = tbAPIKey.Text;

            string[] addresses = Regex.Split(tbAddresses.Text, "\n");

            int counter = 1;
            int noIDCount = 1;

            SetPreloaderVisible(true);

            foreach (string address in addresses)
            {
                if (counter % 49 == 0)
                {
                    Thread.Sleep(2000); // 2 seconds
                }

                try
                {
                    string formattedAddrress = address.Replace("\r", "");

                    string[] parts = Regex.Split(formattedAddrress, "\\[");

                    // No id given
                    if (parts.Length == 1)
                    {
                        parts = new string[] { parts[0], "No ID " + noIDCount + "]" };
                        noIDCount++;
                    }

                    string formattedAddress = AddressStringHelper.GetFormattedAddress(parts[0]);

                    List<string> latLong = GetLatLong(formattedAddress, api);

                    if (latLong[0] == "Over Limit")
                    {
                        AppendResults("[" + parts[1] + "\t" + "Limited Reached" + "\t");
                    }
                    else if (latLong[0].Contains("The remote server returned an error") || latLong[0].Contains("instance of an object"))
                    {
                        AppendResults("[" + parts[1] + "\t" + "Server / API Key Error" + "\t");
                    }
                    else if (latLong[0] == "Fail")
                    {
                        // just use the post code if we can't locate the exact address:

                        latLong = GetLatLong(AddressStringHelper.GetPostCodeFromAddress(formattedAddress), api);

                        // still a fail
                        if (latLong[0] == "Fail")
                        {
                            AppendResults("[" + parts[1] + "\t" + "Fail" + "\t");
                        }
                        else
                        {
                            AppendResults("[" + parts[1] + "\t" + latLong[0] + "\t" + latLong[1] + "\t" + "- Post Code Only");
                        }
                    }
                    else
                        AppendResults("[" + parts[1] + "\t" + latLong[0] + "\t" + latLong[1]);

                    SetProcessInfo(counter, addresses.Length);

                    if (latLong[0] == "Over Limit" || latLong[0].Contains("The remote server returned an error") || latLong[0].Contains("instance of an object"))
                    {
                        SetEnd();
                        processThread.Abort();
                    }
                }
                catch
                {
                    // ignore errorrs
                }

                counter++;
            }

            SetEnd();
        }

        private void AttemptToLoadApiKey()
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("GoogleAPIKeyt.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    String line = sr.ReadToEnd();

                    tbAPIKey.Text = line.Replace(" ", "").Replace("\r", "").Replace("\n", "");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        private void LoadMapHTML(string address, bool initialLoad = false)
        {
            if (string.IsNullOrEmpty(tbAPIKey.Text))
            {
                if (!initialLoad)
                {
                    tbAPIKey.BackColor = ColourHelper.HexStringToColor("f98a85");
                    MessageBox.Show("Google API field cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    wbMap.Navigate("about:blank");
                    try
                    {
                        if (wbMap.Document != null)
                        {
                            wbMap.Document.Write(string.Empty);
                        }
                    }
                    catch
                    { } // do nothing with this
                    wbMap.DocumentText = HtmlHelper.GenerateMapHtml("", tbAPIKey.Text);
                }
            }
            else
            {
                tbAPIKey.BackColor = Color.White;

                List<string> latLong = GetLatLong(address, tbAPIKey.Text);

                bool postCodeOnly = false;

                if (latLong[0] == "Fail")
                {
                    // just use the post code if we can't locate the exact address:

                    address = AddressStringHelper.GetPostCodeFromAddress(address);
                    latLong = GetLatLong(address, tbAPIKey.Text);

                    postCodeOnly = true;
                }
                if (latLong[0].Contains("Over Limit"))
                    lblLatLong.Text = "Latitude / Longitude:   " + "Query limit reached";
                else if (latLong[0].Contains("The remote server returned an error") || latLong[0].Contains("instance of an object"))
                    lblLatLong.Text = "Latitude / Longitude:   " + "Server / API key error";
                else
                {
                    if (latLong[0].Contains("Fail"))
                        lblLatLong.Text = "Latitude / Longitude:   " + "Failed to find coordinates";
                    else
                    {
                        if (postCodeOnly)
                        {
                            lblLatLong.Text = "Latitude / Longitude:   " + latLong[0] + "\t" + latLong[1] + "\t" + "*PC";
                        }
                        else
                        {
                            lblLatLong.Text = "Latitude / Longitude:   " + latLong[0] + "\t" + latLong[1];
                        }
                    }
                }

                lblLatLong.Visible = true;

                wbMap.Navigate("about:blank");
                try
                {
                    if (wbMap.Document != null)
                    {
                        wbMap.Document.Write(string.Empty);
                    }
                }
                catch
                { } // do nothing with this
                wbMap.DocumentText = HtmlHelper.GenerateMapHtml(address, tbAPIKey.Text);
            }
        }

        private List<string> GetLatLong(string address, string apiKey)
        {
            string lng = string.Empty;
            string lat = string.Empty;

            try
            {
                string requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?address={0}&key={1}", Uri.EscapeDataString(address), apiKey);

                WebRequest request = WebRequest.Create(requestUri);
                WebResponse response = request.GetResponse();
                XDocument xdoc = XDocument.Load(response.GetResponseStream());

                if (xdoc.Element("GeocodeResponse").Element("status").Value.Contains("OVER_QUERY_LIMIT"))
                {
                    lat = "Over Limit";
                    lng = "Over Limit";
                }
                else if (xdoc.Element("GeocodeResponse").Element("status").Value.Contains("ZERO_RESULTS"))
                {
                    lat = "Fail";
                    lng = "Fail";
                }
                else
                {
                    XElement result = xdoc.Element("GeocodeResponse").Element("result");
                    XElement locationElement = result.Element("geometry").Element("location");

                    lat = ((XElement)locationElement.Element("lat")).Value;
                    lng = ((XElement)locationElement.Element("lng")).Value;
                }
            }
            catch (Exception e)
            {
                lat = "Fail: " + e.Message;
                lng = "Fail: " + e.Message;
            }

            List<string> returnList = new List<string>();

            returnList.Add(lat);
            returnList.Add(lng);

            return returnList;
        }

        private void SetGoButtonRed()
        {
            btnGoButton.Text = "Stop";

            btnGoButton.ButtonElement.ButtonFillElement.BackColor = ColourHelper.HexStringToColor("ff675f");
            btnGoButton.ButtonElement.ButtonFillElement.BackColor2 = ColourHelper.HexStringToColor("f7918c");
            btnGoButton.ButtonElement.ButtonFillElement.BackColor3 = ColourHelper.HexStringToColor("fbb9b6");
            btnGoButton.ButtonElement.ButtonFillElement.BackColor4 = ColourHelper.HexStringToColor("f9ccca");
        }

        private void SetGoButtonGreen()
        {
            btnGoButton.Text = "Go";

            btnGoButton.ButtonElement.ButtonFillElement.BackColor = ColourHelper.HexStringToColor("68ff6c");
            btnGoButton.ButtonElement.ButtonFillElement.BackColor2 = ColourHelper.HexStringToColor("84fc87");
            btnGoButton.ButtonElement.ButtonFillElement.BackColor3 = ColourHelper.HexStringToColor("b0feb2");
            btnGoButton.ButtonElement.ButtonFillElement.BackColor4 = ColourHelper.HexStringToColor("d3fed4");
        }


        #region Delegates

        private delegate void SetEnd_Callback();

        private void SetEnd()
        {
            if (tbResults.InvokeRequired)
            {
                SetEnd_Callback d = SetEnd;
                Invoke(d);
            }
            else
            {
                SetGoButtonGreen();
                btnGoButton.Text = "Go";
                btnClearButton.Enabled = true;

                SetPreloaderVisible(false);
            }
        }

        private delegate void SetPreloaderVisible_Callback(bool visible);

        private void SetPreloaderVisible(bool visible)
        {
            if (tbResults.InvokeRequired)
            {
                SetPreloaderVisible_Callback d = SetPreloaderVisible;
                Invoke(d, visible);
            }
            else
            {
                pbSpinner.Visible = visible;
            }
        }

        private delegate void AppendResuls_Callback(string appendText);

        private void AppendResults(string appendText)
        {
            if (tbResults.InvokeRequired)
            {
                AppendResuls_Callback d = AppendResults;
                Invoke(d, appendText);
            }
            else
            {
                tbResults.Text = tbResults.Text + appendText + "\r\n";

                tbResults.SelectionStart = tbResults.Text.Length;
                tbResults.ScrollToCaret();
            }
        }

        private delegate void SetProcessInfo_Callback(int count, int total);

        private void SetProcessInfo(int count, int total)
        {
            if (lblProcessInfo.InvokeRequired)
            {
                SetProcessInfo_Callback d = SetProcessInfo;
                Invoke(d, count, total);
            }
            else
            {
                lblProcessInfo.Visible = true;
                lblProcessInfo.Text = "Processed " + count + " of " + total;
            }
        }

        #endregion

        #region events

        private void btnSearchAddress_Click(object sender, EventArgs e)
        {
            LoadMapHTML(tbAddressField.Text);
        }

        private void btnClearButton_Click(object sender, EventArgs e)
        {
            tbAddresses.Clear();
            tbResults.Clear();
            lblProcessInfo.Visible = false;
        }

        private void btnGoButton_Click(object sender, EventArgs e)
        {
            if (btnGoButton.Text == "Go")
            {
                if (string.IsNullOrEmpty(tbAPIKey.Text))
                {
                    MessageBox.Show("Google API field cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    btnGoButton.Text = "Stop";
                    btnClearButton.Enabled = false;
                    SetGoButtonRed();
                    tbResults.Clear();

                    ProcessAddresses();
                }
            }
            else
            {
                SetPreloaderVisible(false);

                btnGoButton.Text = "Go";
                btnClearButton.Enabled = true;
                SetGoButtonGreen();

                processThread.Abort();
            }
        }

        private void tbResults_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                if (sender != null)
                    ((TextBox)sender).SelectAll();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        #endregion 
    }
}
