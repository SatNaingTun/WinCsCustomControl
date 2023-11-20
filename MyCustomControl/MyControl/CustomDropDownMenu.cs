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
  public  class CustomDropDownMenu:ContextMenuStrip
    {
        private bool isMainMenu;

        [Browsable(false)]
        public bool IsMainMenu
        {
            get { return isMainMenu; }
            set { isMainMenu = value; }
        }
        private int menuItemHeight = 25;

        [Browsable(false)]
        public int MenuItemHeight
        {
            get { return menuItemHeight; }
            set { menuItemHeight = value; }
        }
        private Color menuItemTextColor = Color.DimGray;

        //[Browsable(false)]
           [Category("Appearance")]
        public Color MenuItemTextColor
        {
            get { return menuItemTextColor; }
            set { menuItemTextColor = value; }
        }
        private Color primaryColor = Color.MediumSlateBlue;

       // [Browsable(false)]
        [Category("Appearance")]
        public Color PrimaryColor
        {
            get { return primaryColor; }
            set { primaryColor = value; }
        }

        private Bitmap menuItemHeaderSize;

        public CustomDropDownMenu(IContainer container):base(container)
        {

        }

        private void LoadMenuItemAppearance()
        {
            if (isMainMenu)
            {
                menuItemHeaderSize = new Bitmap(25, 45);
               // MenuItemTextColor = Color.Gainsboro;

            }
            else
            {
                menuItemHeaderSize = new Bitmap(15, menuItemHeight);
            }

            SetItemProperties(this.Items);

           /*
            foreach (ToolStripMenuItem item1 in this.Items)
            {
                item1.ForeColor = menuItemTextColor;
                item1.ImageScaling = ToolStripItemImageScaling.None;
                if (item1.Image == null) item1.Image = menuItemHeaderSize;

                foreach (ToolStripMenuItem item2 in this.Items)
                {
                    item2.ForeColor = menuItemTextColor;
                    item2.ImageScaling = ToolStripItemImageScaling.None;
                    if (item2.Image == null) item1.Image = menuItemHeaderSize;
                }
            }
            */ 
        }

        private void SetItemProperties(ToolStripItemCollection Items)
        {
            if (Items.Count > 0)
            {
                foreach (ToolStripMenuItem item in Items)
                {
                    item.BackColor = primaryColor;
                    item.ForeColor = menuItemTextColor;
                  
                    item.ImageScaling = ToolStripItemImageScaling.None;
                    if (item.Image == null) item.Image = menuItemHeaderSize;

                    SetItemProperties(item.DropDownItems);
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (this.DesignMode == false)
            {
                LoadMenuItemAppearance();
                this.Renderer = new MenuRenderer(IsMainMenu,primaryColor,menuItemTextColor);
            }
        }

    }
}
