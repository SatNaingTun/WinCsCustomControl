namespace MyCustomControl
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.customButton1 = new MyCustomControl.MyControl.CustomButton();
            this.customDropDownMenu1 = new MyCustomControl.MyControl.CustomDropDownMenu(this.components);
            this.a1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.a2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.a3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customDropDownMenu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customButton1
            // 
            this.customButton1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.customButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.customButton1.BorderRadius = 40;
            this.customButton1.BorderSize = 0;
            this.customButton1.FlatAppearance.BorderSize = 0;
            this.customButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customButton1.ForeColor = System.Drawing.Color.White;
            this.customButton1.Location = new System.Drawing.Point(63, 57);
            this.customButton1.Name = "customButton1";
            this.customButton1.Size = new System.Drawing.Size(150, 40);
            this.customButton1.TabIndex = 1;
            this.customButton1.Text = "customButton1";
            this.customButton1.UseVisualStyleBackColor = false;
            this.customButton1.Click += new System.EventHandler(this.customButton1_Click);
            // 
            // customDropDownMenu1
            // 
            this.customDropDownMenu1.IsMainMenu = false;
            this.customDropDownMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.a1ToolStripMenuItem,
            this.a2ToolStripMenuItem,
            this.a3ToolStripMenuItem});
            this.customDropDownMenu1.MenuItemHeight = 25;
            this.customDropDownMenu1.MenuItemTextColor = System.Drawing.Color.WhiteSmoke;
            this.customDropDownMenu1.Name = "customDropDownMenu1";
            this.customDropDownMenu1.PrimaryColor = System.Drawing.Color.MediumSlateBlue;
            this.customDropDownMenu1.Size = new System.Drawing.Size(153, 92);
            // 
            // a1ToolStripMenuItem
            // 
            this.a1ToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.a1ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.a1ToolStripMenuItem.Name = "a1ToolStripMenuItem";
            this.a1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.a1ToolStripMenuItem.Text = "A1";
            this.a1ToolStripMenuItem.Click += new System.EventHandler(this.a1ToolStripMenuItem_Click);
            // 
            // a2ToolStripMenuItem
            // 
            this.a2ToolStripMenuItem.Name = "a2ToolStripMenuItem";
            this.a2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.a2ToolStripMenuItem.Text = "A2";
            // 
            // a3ToolStripMenuItem
            // 
            this.a3ToolStripMenuItem.Name = "a3ToolStripMenuItem";
            this.a3ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.a3ToolStripMenuItem.Text = "A3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.customButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.customDropDownMenu1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MyControl.CustomDropDownMenu customDropDownMenu1;
        private MyControl.CustomButton customButton1;
        private System.Windows.Forms.ToolStripMenuItem a1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem a2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem a3ToolStripMenuItem;















    }
}

