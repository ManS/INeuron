namespace INeuron.Forms
{
    partial class PerceptronsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PerceptronsForm));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.errors_lbl = new System.Windows.Forms.Label();
            this.training_gb = new System.Windows.Forms.GroupBox();
            this.training_lbl = new System.Windows.Forms.Label();
            this.testing_gb = new System.Windows.Forms.GroupBox();
            this.training_gb.SuspendLayout();
            this.testing_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(151, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start Training";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose Training Data:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Single Layer",
            "Multi Layer "});
            this.comboBox1.Location = new System.Drawing.Point(151, 40);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(75, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select Network";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(151, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Browse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Choose Testing Data:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(151, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Browse";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(151, 46);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Test";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // errors_lbl
            // 
            this.errors_lbl.AutoSize = true;
            this.errors_lbl.Location = new System.Drawing.Point(6, 71);
            this.errors_lbl.Name = "errors_lbl";
            this.errors_lbl.Size = new System.Drawing.Size(36, 13);
            this.errors_lbl.TabIndex = 10;
            this.errors_lbl.Text = "Errors";
            // 
            // training_gb
            // 
            this.training_gb.Controls.Add(this.training_lbl);
            this.training_gb.Controls.Add(this.button1);
            this.training_gb.Controls.Add(this.button2);
            this.training_gb.Controls.Add(this.label1);
            this.training_gb.Controls.Add(this.comboBox1);
            this.training_gb.Controls.Add(this.label2);
            this.training_gb.Location = new System.Drawing.Point(6, 1);
            this.training_gb.Name = "training_gb";
            this.training_gb.Size = new System.Drawing.Size(231, 122);
            this.training_gb.TabIndex = 13;
            this.training_gb.TabStop = false;
            this.training_gb.Text = "Phase1: Training";
            // 
            // training_lbl
            // 
            this.training_lbl.AutoSize = true;
            this.training_lbl.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.training_lbl.ForeColor = System.Drawing.Color.Red;
            this.training_lbl.Location = new System.Drawing.Point(6, 75);
            this.training_lbl.Name = "training_lbl";
            this.training_lbl.Size = new System.Drawing.Size(102, 13);
            this.training_lbl.TabIndex = 13;
            this.training_lbl.Text = "Training Finished";
            // 
            // testing_gb
            // 
            this.testing_gb.Controls.Add(this.button4);
            this.testing_gb.Controls.Add(this.button3);
            this.testing_gb.Controls.Add(this.label3);
            this.testing_gb.Controls.Add(this.errors_lbl);
            this.testing_gb.Location = new System.Drawing.Point(6, 129);
            this.testing_gb.Name = "testing_gb";
            this.testing_gb.Size = new System.Drawing.Size(231, 120);
            this.testing_gb.TabIndex = 14;
            this.testing_gb.TabStop = false;
            this.testing_gb.Text = "Phase2: Testing";
            // 
            // PerceptronsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 254);
            this.Controls.Add(this.testing_gb);
            this.Controls.Add(this.training_gb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PerceptronsForm";
            this.Text = "IPerceptron";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.training_gb.ResumeLayout(false);
            this.training_gb.PerformLayout();
            this.testing_gb.ResumeLayout(false);
            this.testing_gb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label errors_lbl;
        private System.Windows.Forms.GroupBox training_gb;
        private System.Windows.Forms.GroupBox testing_gb;
        private System.Windows.Forms.Label training_lbl;

    }
}

