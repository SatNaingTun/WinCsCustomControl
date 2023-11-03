using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MyCustomControl.MyControl
{
    [ToolboxBitmap(typeof(CustomDatePicker), "Properties.Resources.calendar_icon")]
   public class CustomDatePicker:DateTimePicker
    {
        private Color skinColor = Color.MediumSlateBlue;

        public Color SkinColor
        {
            get { return skinColor; }
            set { skinColor = value;
            this.Invalidate();
            }
        }
        private Color textColor = Color.White;

        public Color TextColor
        {
            get { return textColor; }
            set { 
                textColor = value;
                this.Invalidate();
            
            }
        }
        private Color borderColor = Color.PaleVioletRed;

        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value;
            this.Invalidate();
            }
        }
        private int borderSize = 0;

        public int BorderSize
        {
            get { return borderSize; }
            set { borderSize = value;
            this.Invalidate();
            }
        }

        private bool droppedDown = false;
        private Image calendarIcon = Properties.Resources.calendar_icon;
        private RectangleF iconButonArea;
        private const int calendarIconWidth = 34;
        private const int arrowIconWidth = 17;



        public CustomDatePicker()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.MinimumSize = new Size(0, 35);
            this.Font = new Font(this.Font.Name, 9.5F);
           
        }

        protected override void OnDropDown(EventArgs eventargs)
        {
            base.OnDropDown(eventargs);
            droppedDown = true;
        }
        protected override void OnCloseUp(EventArgs eventargs)
        {
            base.OnCloseUp(eventargs);
            droppedDown = false;
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            e.Handled = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Graphics graphics = this.CreateGraphics()) 
            using (Pen penBorder = new Pen(borderColor, borderSize))
            using (SolidBrush skinBrush=new SolidBrush(skinColor))
            using (SolidBrush openIconBrush=new SolidBrush(Color.FromArgb(50,64,64,64)))
            using (SolidBrush textBrush=new SolidBrush(textColor))
            using (StringFormat textFormat=new StringFormat())
            {
                RectangleF clientArea = new RectangleF(0, 0, this.Width - 0.5F, this.Height - .5F);
                RectangleF  iconArea=new RectangleF(clientArea.Width-calendarIconWidth,0,calendarIconWidth,clientArea.Height);
                penBorder.Alignment = PenAlignment.Inset;
                textFormat.LineAlignment = StringAlignment.Center;
                graphics.FillRectangle(skinBrush,clientArea);
                graphics.DrawString(this.Text, this.Font, textBrush, clientArea, textFormat);
                //Draw open calendar icon highlight
                if (droppedDown == true) graphics.FillRectangle(openIconBrush, iconArea);
                //Draw border
                if (borderSize >= 1) graphics.DrawRectangle(penBorder,clientArea.X, clientArea.Y, clientArea.Width, clientArea.Height);
                //Draw icon

                graphics.DrawImage(calendarIcon, this.Width - calendarIcon.Width - 9, (this.Height - calendarIcon.Height) / 2);
            }
           
        }
        private int GetIconButtonWidth()
        {
            int textWidth = TextRenderer.MeasureText(this.Text, this.Font).Width;
            if (textWidth <= this.Width - (calendarIconWidth + 20))
                return calendarIconWidth;
            else return arrowIconWidth;
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            int iconWidth = GetIconButtonWidth();
            iconButonArea = new RectangleF(this.Width-iconWidth,0,iconWidth,this.Height);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (iconButonArea.Contains(e.Location))
                this.Cursor = Cursors.Hand;
            else this.Cursor = Cursors.Default;
        }

    }
}
