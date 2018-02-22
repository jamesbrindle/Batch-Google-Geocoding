namespace GoogleGeolocation
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnGoButton = new Telerik.WinControls.UI.RadButton();
            this.btnClearButton = new Telerik.WinControls.UI.RadButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblProcessInfo = new Telerik.WinControls.UI.RadLabel();
            this.pbSpinner = new System.Windows.Forms.PictureBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLatLong = new System.Windows.Forms.TextBox();
            this.btnSearchAddress = new Telerik.WinControls.UI.RadButton();
            this.tbAddressField = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbAPIKey = new GoogleGeolocation.BorderedTextBox();
            this.tbResults = new GoogleGeolocation.BorderedTextBox();
            this.tbAddresses = new GoogleGeolocation.BorderedTextBox();
            this.pnlBrowserContainer = new GoogleGeolocation.BorderedPanel();
            this.wbMap = new System.Windows.Forms.WebBrowser();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGoButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClearButton)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblProcessInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAddressField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlBrowserContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 458);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Batch Processing";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tbResults, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tbAddresses, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(466, 437);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radLabel5);
            this.panel2.Controls.Add(this.radLabel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(460, 44);
            this.panel2.TabIndex = 8;
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.Location = new System.Drawing.Point(3, 22);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(271, 18);
            this.radLabel5.TabIndex = 5;
            this.radLabel5.Text = "E.g: Centenary Court, Croft St, Burnley BB11 2ED [234]";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(3, 3);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(361, 18);
            this.radLabel4.TabIndex = 4;
            this.radLabel4.Text = "Enter Addresses (1 line / address, with appended ID in square brackets)";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.btnGoButton, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnClearButton, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.panel4, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.pbSpinner, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 228);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(466, 30);
            this.tableLayoutPanel4.TabIndex = 9;
            // 
            // btnGoButton
            // 
            this.btnGoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGoButton.Location = new System.Drawing.Point(71, 3);
            this.btnGoButton.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
            this.btnGoButton.MaximumSize = new System.Drawing.Size(58, 24);
            this.btnGoButton.MinimumSize = new System.Drawing.Size(58, 24);
            this.btnGoButton.Name = "btnGoButton";
            this.btnGoButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.btnGoButton.RootElement.MaxSize = new System.Drawing.Size(58, 24);
            this.btnGoButton.RootElement.MinSize = new System.Drawing.Size(58, 24);
            this.btnGoButton.Size = new System.Drawing.Size(58, 24);
            this.btnGoButton.TabIndex = 0;
            this.btnGoButton.Text = "Go";
            this.btnGoButton.Click += new System.EventHandler(this.btnGoButton_Click);
            // 
            // btnClearButton
            // 
            this.btnClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearButton.Location = new System.Drawing.Point(141, 3);
            this.btnClearButton.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.btnClearButton.MaximumSize = new System.Drawing.Size(58, 24);
            this.btnClearButton.MinimumSize = new System.Drawing.Size(58, 24);
            this.btnClearButton.Name = "btnClearButton";
            // 
            // 
            // 
            this.btnClearButton.RootElement.MaxSize = new System.Drawing.Size(58, 24);
            this.btnClearButton.RootElement.MinSize = new System.Drawing.Size(58, 24);
            this.btnClearButton.Size = new System.Drawing.Size(58, 24);
            this.btnClearButton.TabIndex = 1;
            this.btnClearButton.Text = "Clear";
            this.btnClearButton.Click += new System.EventHandler(this.btnClearButton_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblProcessInfo);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(253, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(213, 30);
            this.panel4.TabIndex = 2;
            // 
            // lblProcessInfo
            // 
            this.lblProcessInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblProcessInfo.Location = new System.Drawing.Point(18, 6);
            this.lblProcessInfo.Name = "lblProcessInfo";
            this.lblProcessInfo.Size = new System.Drawing.Size(100, 18);
            this.lblProcessInfo.TabIndex = 6;
            this.lblProcessInfo.Text = "Processed 0 of 290";
            this.lblProcessInfo.Visible = false;
            // 
            // pbSpinner
            // 
            this.pbSpinner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSpinner.Image = global::GoogleGeolocation.Properties.Resources.spinner;
            this.pbSpinner.Location = new System.Drawing.Point(222, 0);
            this.pbSpinner.Margin = new System.Windows.Forms.Padding(0);
            this.pbSpinner.Name = "pbSpinner";
            this.pbSpinner.Size = new System.Drawing.Size(31, 30);
            this.pbSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSpinner.TabIndex = 3;
            this.pbSpinner.TabStop = false;
            this.pbSpinner.Visible = false;
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel1.Location = new System.Drawing.Point(439, 49);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(83, 18);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.Text = "Google API Key";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(481, 3);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(475, 458);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Location Check";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.pnlBrowserContainer, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(469, 437);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblLatLong);
            this.panel1.Controls.Add(this.btnSearchAddress);
            this.panel1.Controls.Add(this.tbAddressField);
            this.panel1.Controls.Add(this.radLabel3);
            this.panel1.Controls.Add(this.radLabel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(463, 109);
            this.panel1.TabIndex = 0;
            // 
            // lblLatLong
            // 
            this.lblLatLong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLatLong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblLatLong.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatLong.Location = new System.Drawing.Point(130, 83);
            this.lblLatLong.Name = "lblLatLong";
            this.lblLatLong.Size = new System.Drawing.Size(330, 15);
            this.lblLatLong.TabIndex = 10;
            this.lblLatLong.Text = "Latitude:   Longitude:";
            // 
            // btnSearchAddress
            // 
            this.btnSearchAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearchAddress.Location = new System.Drawing.Point(35, 78);
            this.btnSearchAddress.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
            this.btnSearchAddress.MaximumSize = new System.Drawing.Size(58, 24);
            this.btnSearchAddress.MinimumSize = new System.Drawing.Size(58, 24);
            this.btnSearchAddress.Name = "btnSearchAddress";
            this.btnSearchAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.btnSearchAddress.RootElement.MaxSize = new System.Drawing.Size(58, 24);
            this.btnSearchAddress.RootElement.MinSize = new System.Drawing.Size(58, 24);
            this.btnSearchAddress.Size = new System.Drawing.Size(58, 24);
            this.btnSearchAddress.TabIndex = 8;
            this.btnSearchAddress.Text = "Go";
            this.btnSearchAddress.Click += new System.EventHandler(this.btnSearchAddress_Click);
            // 
            // tbAddressField
            // 
            this.tbAddressField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAddressField.Location = new System.Drawing.Point(0, 46);
            this.tbAddressField.Name = "tbAddressField";
            this.tbAddressField.Size = new System.Drawing.Size(463, 20);
            this.tbAddressField.TabIndex = 7;
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(3, 22);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(387, 18);
            this.radLabel3.TabIndex = 6;
            this.radLabel3.Text = "For Coordinates, in the format [Latitude],[Longitude] e.g: 53.788971,-2.239350";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(3, 3);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(146, 18);
            this.radLabel2.TabIndex = 5;
            this.radLabel2.Text = "Enter Address / Coordinates";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 85);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(956, 464);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::GoogleGeolocation.Properties.Resources.Google_Maps;
            this.pictureBox1.Location = new System.Drawing.Point(931, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // tbAPIKey
            // 
            this.tbAPIKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAPIKey.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            this.tbAPIKey.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAPIKey.Location = new System.Drawing.Point(528, 47);
            this.tbAPIKey.MaxLength = 999999999;
            this.tbAPIKey.Name = "tbAPIKey";
            this.tbAPIKey.Size = new System.Drawing.Size(281, 22);
            this.tbAPIKey.TabIndex = 11;
            // 
            // tbResults
            // 
            this.tbResults.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            this.tbResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbResults.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbResults.Location = new System.Drawing.Point(3, 261);
            this.tbResults.MaxLength = 999999999;
            this.tbResults.Multiline = true;
            this.tbResults.Name = "tbResults";
            this.tbResults.ReadOnly = true;
            this.tbResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbResults.Size = new System.Drawing.Size(460, 173);
            this.tbResults.TabIndex = 11;
            this.tbResults.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbResults_KeyDown);
            // 
            // tbAddresses
            // 
            this.tbAddresses.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            this.tbAddresses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAddresses.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAddresses.Location = new System.Drawing.Point(3, 53);
            this.tbAddresses.MaxLength = 999999999;
            this.tbAddresses.Multiline = true;
            this.tbAddresses.Name = "tbAddresses";
            this.tbAddresses.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbAddresses.Size = new System.Drawing.Size(460, 172);
            this.tbAddresses.TabIndex = 10;
            // 
            // pnlBrowserContainer
            // 
            this.pnlBrowserContainer.Controls.Add(this.wbMap);
            this.pnlBrowserContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBrowserContainer.Location = new System.Drawing.Point(3, 118);
            this.pnlBrowserContainer.Name = "pnlBrowserContainer";
            this.pnlBrowserContainer.Size = new System.Drawing.Size(463, 316);
            this.pnlBrowserContainer.TabIndex = 1;
            // 
            // wbMap
            // 
            this.wbMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbMap.Location = new System.Drawing.Point(1, 1);
            this.wbMap.Margin = new System.Windows.Forms.Padding(0);
            this.wbMap.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbMap.Name = "wbMap";
            this.wbMap.Size = new System.Drawing.Size(461, 314);
            this.wbMap.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 572);
            this.Controls.Add(this.tbAPIKey);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.radLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1005, 572);
            this.Name = "MainForm";
            this.Text = "Google Geolocation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnGoButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClearButton)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblProcessInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAddressField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlBrowserContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private Telerik.WinControls.UI.RadButton btnGoButton;
        private Telerik.WinControls.UI.RadButton btnClearButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadButton btnSearchAddress;
        private Telerik.WinControls.UI.RadTextBox tbAddressField;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private BorderedPanel pnlBrowserContainer;
        private System.Windows.Forms.Panel panel4;
        private Telerik.WinControls.UI.RadLabel lblProcessInfo;
        private BorderedTextBox tbResults;
        private BorderedTextBox tbAddresses;
        private System.Windows.Forms.WebBrowser wbMap;
        private BorderedTextBox tbAPIKey;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbSpinner;
        private System.Windows.Forms.TextBox lblLatLong;
    }
}

