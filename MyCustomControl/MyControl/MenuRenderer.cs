using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

    

namespace MyCustomControl.MyControl
{
    class MenuRenderer:ToolStripProfessionalRenderer
    {
        private Color primaryColor;
        private Color textColor=Color.Black;
        private int arrowThickness;

        public MenuRenderer(bool isMainMenu,Color primaryColor)
        {
            this.primaryColor = primaryColor;
            if (isMainMenu) arrowThickness = 3;
            else arrowThickness = 2;
        }
        public MenuRenderer(bool isMainMenu, Color primaryColor,Color textColor)
        {
            this.primaryColor = primaryColor;
            this.textColor = textColor;
            if (isMainMenu) arrowThickness = 3;
            else arrowThickness = 2;
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            base.OnRenderItemText(e);
            e.Item.ForeColor = e.Item.Selected ? Color.White : textColor;
        }
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            base.OnRenderArrow(e);
            var graphic = e.Graphics;
            var arrowSize = new Size(5,12);
            var arrowColor = e.Item.Selected ? Color.White : primaryColor;
            var rect = new Rectangle(e.ArrowRectangle.Location.X,(e.ArrowRectangle.Height-arrowSize.Height)/2,arrowSize.Width,arrowSize.Height);
            using (GraphicsPath path=new GraphicsPath())
            using (Pen pen=new Pen(arrowColor,arrowThickness))
            {
                graphic.SmoothingMode = SmoothingMode.AntiAlias;
                path.AddLine(rect.Left, rect.Top,rect.Right, rect.Top + rect.Height/2);
                path.AddLine( rect.Right, rect.Top + rect.Height / 2,rect.Left, rect.Top);
                graphic.DrawPath(pen, path);
            }
        }
    }
}
