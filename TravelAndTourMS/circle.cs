using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAndTourMS
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    namespace MyWindowsFormsApp
    {
        public class RoundedTextBox : TextBox
        {
            //Fields
            private int borderRadius = 20;

            //Properties
            [Category("RJ Code Advance")]
            public int BorderRadius
            {
                get { return borderRadius; }
                set
                {
                    borderRadius = value;
                    this.Invalidate();
                }
            }

            //Constructor
            public RoundedTextBox()
            {
                this.Resize += new EventHandler(TextBox_Resize);
            }

            private void TextBox_Resize(object sender, EventArgs e)
            {
                if (borderRadius > this.Height)
                    borderRadius = this.Height;
            }

            //Methods
            private GraphicsPath GetFigurePath(Rectangle rect, float radius)
            {
                GraphicsPath path = new GraphicsPath();
                float curveSize = radius * 2F;

                path.StartFigure();
                path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
                path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
                path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
                path.CloseFigure();
                return path;
            }


            protected override void OnPaint(PaintEventArgs pevent)
            {
                base.OnPaint(pevent);
                Rectangle rect = this.ClientRectangle;
                int smoothSize = 2;

                if (borderRadius > 2) //Rounded textbox
                {
                    using (GraphicsPath path = GetFigurePath(rect, borderRadius))
                    {
                        pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        this.Region = new Region(path);
                    }
                }
            }
        }
    }
}




