using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MyCustomControl.MyControl
{
   public class CustomRadio:RadioButton
    {
        private Color checkedColor = Color.MediumSlateBlue;

        public Color CheckedColor
        {
            get { return checkedColor; }
            set { checkedColor = value;
            this.Invalidate();
            }
        }
        private Color unChekedColor = Color.Gray;

        public Color UnChekedColor
        {
            get { return unChekedColor; }
            set { unChekedColor = value;
            this.Invalidate();
            }


        }

        public CustomRadio()
        {
            this.MinimumSize = new Size(0, 21);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            //base.OnPaint(pevent);
            Graphics graphics = pevent.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            float rbBorderSize = 18F;
            float rbCheckSize = 12F;
            RectangleF rectRbBorder = new RectangleF()
            {
                X=0.5F,Y=(this.Height-rbBorderSize)/2,
                Width=rbBorderSize,
                Height=rbBorderSize
            };
            RectangleF rectRbCheck = new RectangleF()
            {
                X = rectRbBorder.X + ((rectRbBorder.Width - rbCheckSize) / 2),
                //Y = (this.Height - rbBorderSize) / 2,
                Y = (this.Height - rbBorderSize)+1,
                
                Width = rbCheckSize,
                Height = rbCheckSize
            };
            using (Pen penBorder = new Pen(checkedColor, 1.6F))
            using (SolidBrush brushRbCheck = new SolidBrush(checkedColor))
            using (SolidBrush brushText = new SolidBrush(this.ForeColor)) 
            {
                graphics.Clear(this.BackColor);
                if (Checked)
                {
                    graphics.DrawEllipse(penBorder, rectRbBorder);
                    graphics.FillEllipse(brushRbCheck, rectRbCheck);
                }
                else
                {
                    penBorder.Color = unChekedColor;
                    graphics.DrawEllipse(penBorder,rectRbBorder);
                }
                graphics.DrawString(this.Text, this.Font, brushText, rbBorderSize + 8, (this.Height - TextRenderer.MeasureText(this.Text, this.Font).Height) / 2);
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Width = TextRenderer.MeasureText(this.Text, this.Font).Width + 30;
        }

    }
}
