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
    class CustomToggle:CheckBox
    {
        private Color onBackColor = Color.LightSteelBlue;
        private Color onToggleColor = Color.LawnGreen;
        private Color offBackColor = Color.Gray;
        private Color offToggleColor = Color.OrangeRed;
        private bool solidStyle = true;

        [DefaultValue(true)]
        [Category("Custom Color")]
        public bool SolidStyle
        {
            get { return solidStyle; }
            set { solidStyle = value;
            this.Invalidate();
            }
        }
        [Category("Custom Color")]
        public Color OnBackColor
        {
            get { return onBackColor; }
            set { 
                onBackColor = value;
                this.Invalidate();
            }
        }

        [Category("Custom Color")]
        public Color OnToggleColor
        {
            get { return onToggleColor; }
            set { 
                onToggleColor = value;
                this.Invalidate();
            }
        }

        [Category("Custom Color")]
        public Color OffBackColor
        {
            get { return offBackColor; }
            set { 
                offBackColor = value;
                this.Invalidate();
            }
        }

        [Category("Custom Color")]
        public Color OffToggleColor
        {
            get { return offToggleColor; }
            set { 
                offToggleColor = value;
                this.Invalidate();
            }
        }

        public CustomToggle()
        {
           // this.Size = new Size(45, 22);
            this.MinimumSize = new Size(45, 22);
        }

        private GraphicsPath GetFigurePath()
        {
            int arcSize = this.Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(this.Width-arcSize-2,0,arcSize,arcSize);

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc,90,180);
            path.AddArc(rightArc,270, 180);
            path.CloseFigure();

            return path;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            int toggleSize = this.Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);

            if (this.Checked)
            {
                //Draw the control surface
                if(solidStyle)
                pevent.Graphics.FillPath(new SolidBrush(OnBackColor), GetFigurePath());
                else
                    pevent.Graphics.DrawPath(new Pen(OnBackColor,2), GetFigurePath());
                //Draw the toggle
                pevent.Graphics.FillEllipse(new SolidBrush(OnToggleColor), new Rectangle(this.Width-this.Height+1,2,toggleSize,toggleSize));
            }
            else
            {
                if (solidStyle)
                pevent.Graphics.FillPath(new SolidBrush(OffBackColor), GetFigurePath());
                else
                    pevent.Graphics.DrawPath(new Pen(OffBackColor,2), GetFigurePath()); 
                //Draw the toggle
                pevent.Graphics.FillEllipse(new SolidBrush(OffToggleColor), new Rectangle(2, 2, toggleSize, toggleSize));
            }

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CustomToggleButton
            // 
            this.Size = new System.Drawing.Size(45, 22);
            this.ResumeLayout(false);

        }
    }
}
