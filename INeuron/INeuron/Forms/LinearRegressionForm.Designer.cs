namespace INeuron.Forms
{
    partial class LinearRegressionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LinearRegressionForm));
            this.training_gb = new System.Windows.Forms.GroupBox();
            this.browse_btn = new System.Windows.Forms.Button();
            this.start_btn = new System.Windows.Forms.Button();
            this.weights_lbl = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.testing_gb = new System.Windows.Forms.GroupBox();
            this.browse2_btn = new System.Windows.Forms.Button();
            this.errors_lbl = new System.Windows.Forms.Label();
            this.test_btn = new System.Windows.Forms.Button();
            this.training_gb.SuspendLayout();
            this.testing_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // training_gb
            // 
            this.training_gb.Controls.Add(this.browse_btn);
            this.training_gb.Controls.Add(this.start_btn);
            this.training_gb.Controls.Add(this.weights_lbl);
            this.training_gb.Controls.Add(this.textBox1);
            this.training_gb.Location = new System.Drawing.Point(3, 3);
            this.training_gb.Name = "training_gb";
            this.training_gb.Size = new System.Drawing.Size(260, 127);
            this.training_gb.TabIndex = 0;
            this.training_gb.TabStop = false;
            this.training_gb.Text = "Training";
            // 
            // browse_btn
            // 
            this.browse_btn.Location = new System.Drawing.Point(6, 19);
            this.browse_btn.Name = "browse_btn";
            this.browse_btn.Size = new System.Drawing.Size(75, 23);
            this.browse_btn.TabIndex = 5;
            this.browse_btn.Text = "Browse..";
            this.browse_btn.UseVisualStyleBackColor = true;
            this.browse_btn.Click += new System.EventHandler(this.browse_btn_Click);
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(6, 98);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(75, 23);
            this.start_btn.TabIndex = 4;
            this.start_btn.Text = "start training";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // weights_lbl
            // 
            this.weights_lbl.AutoSize = true;
            this.weights_lbl.Location = new System.Drawing.Point(78, 60);
            this.weights_lbl.Name = "weights_lbl";
            this.weights_lbl.Size = new System.Drawing.Size(50, 13);
            this.weights_lbl.TabIndex = 3;
            this.weights_lbl.Text = "Weights:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(130, 10);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox1.Size = new System.Drawing.Size(124, 112);
            this.textBox1.TabIndex = 2;
            // 
            // testing_gb
            // 
            this.testing_gb.Controls.Add(this.browse2_btn);
            this.testing_gb.Controls.Add(this.errors_lbl);
            this.testing_gb.Controls.Add(this.test_btn);
            this.testing_gb.Location = new System.Drawing.Point(3, 142);
            this.testing_gb.Name = "testing_gb";
            this.testing_gb.Size = new System.Drawing.Size(260, 74);
            this.testing_gb.TabIndex = 1;
            this.testing_gb.TabStop = false;
            this.testing_gb.Text = "Testing";
            // 
            // browse2_btn
            // 
            this.browse2_btn.Location = new System.Drawing.Point(6, 15);
            this.browse2_btn.Name = "browse2_btn";
            this.browse2_btn.Size = new System.Drawing.Size(75, 23);
            this.browse2_btn.TabIndex = 11;
            this.browse2_btn.Text = "Browse..";
            this.browse2_btn.UseVisualStyleBackColor = true;
            this.browse2_btn.Click += new System.EventHandler(this.browse2_btn_Click);
            // 
            // errors_lbl
            // 
            this.errors_lbl.AutoSize = true;
            this.errors_lbl.Location = new System.Drawing.Point(127, 24);
            this.errors_lbl.Name = "errors_lbl";
            this.errors_lbl.Size = new System.Drawing.Size(36, 13);
            this.errors_lbl.TabIndex = 10;
            this.errors_lbl.Text = "Errors";
            // 
            // test_btn
            // 
            this.test_btn.Location = new System.Drawing.Point(6, 44);
            this.test_btn.Name = "test_btn";
            this.test_btn.Size = new System.Drawing.Size(75, 23);
            this.test_btn.TabIndex = 9;
            this.test_btn.Text = "Test!";
            this.test_btn.UseVisualStyleBackColor = true;
            this.test_btn.Click += new System.EventHandler(this.test_btn_Click);
            // 
            // LinearRegressionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 221);
            this.Controls.Add(this.testing_gb);
            this.Controls.Add(this.training_gb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LinearRegressionForm";
            this.Text = "LinearRegressionForm";
            this.training_gb.ResumeLayout(false);
            this.training_gb.PerformLayout();
            this.testing_gb.ResumeLayout(false);
            this.testing_gb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox training_gb;
        private System.Windows.Forms.GroupBox testing_gb;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label weights_lbl;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Button browse_btn;
        private System.Windows.Forms.Button test_btn;
        private System.Windows.Forms.Label errors_lbl;
        private System.Windows.Forms.Button browse2_btn;
    }
}