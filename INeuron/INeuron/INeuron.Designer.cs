namespace INeuron
{
    partial class INeuron
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INeuron));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algorithmsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iPerceptronToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gHAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linearRegressionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(328, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.algorithmsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // algorithmsToolStripMenuItem
            // 
            this.algorithmsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iPerceptronToolStripMenuItem,
            this.lMSToolStripMenuItem,
            this.gHAToolStripMenuItem,
            this.linearRegressionToolStripMenuItem});
            this.algorithmsToolStripMenuItem.Name = "algorithmsToolStripMenuItem";
            this.algorithmsToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.algorithmsToolStripMenuItem.Text = "Algorithms";
            // 
            // iPerceptronToolStripMenuItem
            // 
            this.iPerceptronToolStripMenuItem.Name = "iPerceptronToolStripMenuItem";
            this.iPerceptronToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.iPerceptronToolStripMenuItem.Text = "IPerceptron";
            this.iPerceptronToolStripMenuItem.Click += new System.EventHandler(this.iPerceptronToolStripMenuItem_Click);
            // 
            // lMSToolStripMenuItem
            // 
            this.lMSToolStripMenuItem.Name = "lMSToolStripMenuItem";
            this.lMSToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.lMSToolStripMenuItem.Text = "LMS";
            this.lMSToolStripMenuItem.Click += new System.EventHandler(this.lMSToolStripMenuItem_Click);
            // 
            // gHAToolStripMenuItem
            // 
            this.gHAToolStripMenuItem.Name = "gHAToolStripMenuItem";
            this.gHAToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.gHAToolStripMenuItem.Text = "GHA";
            this.gHAToolStripMenuItem.Click += new System.EventHandler(this.gHAToolStripMenuItem_Click);
            // 
            // linearRegressionToolStripMenuItem
            // 
            this.linearRegressionToolStripMenuItem.Name = "linearRegressionToolStripMenuItem";
            this.linearRegressionToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.linearRegressionToolStripMenuItem.Text = "Linear Regression";
            this.linearRegressionToolStripMenuItem.Click += new System.EventHandler(this.linearRegressionToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // INeuron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(328, 307);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "INeuron";
            this.Opacity = 0.95D;
            this.Text = "INeuron";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algorithmsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iPerceptronToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lMSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gHAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linearRegressionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;

    }
}

