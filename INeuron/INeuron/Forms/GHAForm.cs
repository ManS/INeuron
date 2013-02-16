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
    public partial class GHAForm : Form
    {
        GHA mygha;
        bool initialized = false;
        string path = "";
        public GHAForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            if (FD.ShowDialog() == DialogResult.OK)
            {
                path = FD.FileName;
                Bitmap image = new Bitmap(FD.FileName);
                pictureBox1.Image = image;
                mygha = new GHA(new Point(8, 8), 8, 0.001, 500);
                initialized = true;

            }
           
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (initialized)
                pictureBox2.Image = mygha.DoGeneralHebbianAlgorithm(path);
            else
                MessageBox.Show("Choose an Image!");
        }
    }
}