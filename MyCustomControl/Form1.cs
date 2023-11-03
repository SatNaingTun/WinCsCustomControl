using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyCustomControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            customDropDownMenu1.Show(customButton1, customButton1.Left, customButton1.Height);
            
        }

       
    }
}
