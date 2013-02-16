using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NeuralNetworks.LearningAlgorithms;

namespace INeuron.Forms
{
    public partial class LinearRegressionForm : Form
    {
        LinearRegression LR;

        bool initialized1 = false;
        bool initialized2 = false;

        string testing = "";
        string training = "";

        public LinearRegressionForm()
        {
            InitializeComponent();
            LR = new LinearRegression();
            testing_gb.Hide();
        }

        private void browse_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            if (FD.ShowDialog() == DialogResult.OK)
            {
                textBox1.Clear();
                training = FD.FileName;
                LR.ReadTrainingData(FD.FileName, 2);
                LR.Normalize(4);
                initialized1 = true;
            }
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            if (initialized1)
            {
                LR.LinearReg(0.1);
                for (int i = 0; i < 4; i++)
                {
                    textBox1.Text += LR.W[i, 0] + "\n";
                }
                training_gb.Enabled = false;
                testing_gb.Show();
                testing_gb.Enabled = true;
            }
        }

        private void test_btn_Click(object sender, EventArgs e)
        {
            if (initialized2)
            {
                errors_lbl.Text ="Errors = "+ LR.Test(testing).ToString();
                testing_gb.Enabled = false;
                training_gb.Enabled = true;
                textBox1.Clear();
            }
            else
                MessageBox.Show("Select Test File..");
        }

        private void browse2_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            if (FD.ShowDialog() == DialogResult.OK)
            {
                testing = FD.FileName;
                initialized2 = true;
            }
        }
    }
}
