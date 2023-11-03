using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace MyCustomControl.MyControl
{
  public  class CircularPictureBox:PictureBox
    {
        private int borderSize = 2;

        public int BorderSize
        {
            get { return borderSize; }
            set { borderSize = value;
            this.Invalidate();
            }
        }
        private Color borderColor = Color.RoyalBlue;

        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value;
            this.Invalidate();
            }
        }
        private Color borderColor2 = Color.HotPink;

        public Color BorderColor2
        {
            get { return borderColor2; }
            set { borderColor2 = value;
            this.Invalidate();
            }
        }
        private DashStyle borderLineStyle = DashStyle.Solid;

        public DashStyle BorderLineStyle
        {
            get { return borderLineStyle; }
            set { borderLineStyle = value;
            this.Invalidate();
            }
        }
        private DashCap borderCapStyle = DashCap.Flat;

        public DashCap BorderCapStyle
        {
            get { return borderCapStyle; }
            set { borderCapStyle = value;
            this.Invalidate();
            }
        }
        private float gradientAngle = 50F;

        public float GradientAngle
        {
            get { return gradientAngle; }
            set { gradientAngle = value;
            this.Invalidate();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Size = new Size(this.Width, this.Width);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            var graphic = pe.Graphics;
            var rectContourSmooth = Rectangle.Inflate(this.ClientRectangle, -1, -1);
            var rectBorder = Rectangle.Inflate(rectContourSmooth, -borderSize, -borderSize);
            var smoothSize = borderSize > 0 ? borderSize * 3 : 1;
            using (var borderGColr = new LinearGradientBrush(rectBorder, borderColor, borderColor2, gradientAngle))
            using (var pathRegion=new GraphicsPath())
            using (var penSmooth=new Pen(this.Parent.BackColor,smoothSize))
            using (var penBorder=new Pen(borderGColr,borderSize))
            {
                penBorder.DashStyle = borderLineStyle;
                penBorder.DashCap = borderCapStyle;
                pathRegion.AddEllipse(rectContourSmooth);
                this.Region = new Region(pathRegion);
                graphic.SmoothingMode = SmoothingMode.AntiAlias;
                graphic.DrawEllipse(penSmooth, rectContourSmooth);
                if (borderSize > 0)
                    graphic.DrawEllipse(penBorder, rectBorder);
            }

        }

        public CircularPictureBox()
        {
            this.Size = new Size(100, 100);
            this.SizeMode = PictureBoxSizeMode.StretchImage;

        }
    }
}
