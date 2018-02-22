using System.Drawing;
using System.Windows.Forms;

namespace GoogleGeolocation
{
    public class BorderedPanel : Panel
    {
        public BorderedPanel()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(BackColor))
                e.Graphics.FillRectangle(brush, ClientRectangle);
            e.Graphics.DrawRectangle(new Pen(ColourHelper.HexStringToColor("9cbde8"), 1.0f), 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
        }

    }
}
