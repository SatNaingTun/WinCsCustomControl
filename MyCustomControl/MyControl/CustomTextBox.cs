using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace MyCustomControl.MyControl
{
    class CustomTextBox:TextBox
    {
        private string placeHolder;
        private const int EM_SETCUEBANNER = 0x1501;

        private Color placeHolderColor = Color.Gray;

          [Category("Appearance")]
        public Color PlaceHolderColor
        {
            get { return placeHolderColor; }
            set { placeHolderColor = value;
            this.Invalidate();
            
            }
        }

          [Category("Appearance")]
        public string PlaceHolder
        {
            get { return placeHolder; }
            set {
                    placeHolder = value;
                    SendMessage(Handle,
                               EM_SETCUEBANNER,
                               0,
                               placeHolder);
                    this.Invalidate();
            }
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(
            IntPtr hWnd,
            int msg,
            int wParam,
            [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        
       


    }
}
