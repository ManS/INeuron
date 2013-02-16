using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using INeuron.Forms;

namespace INeuron
{
    public partial class INeuron : Form
    {
        public INeuron()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LinearRegressionForm x = new LinearRegressionForm();
            x.ShowDialog();
        }

        private void iPerceptronToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PerceptronsForm Form = new PerceptronsForm();
            Form.ShowDialog();
        }

        private void lMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LMSForm Form = new LMSForm();
            Form.ShowDialog();
        }

        private void gHAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GHAForm Form = new GHAForm();
            Form.ShowDialog();
        }

        private void linearRegressionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LinearRegressionForm Form = new LinearRegressionForm();
            Form.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Team Members:\n1- Yassmin Taha Mostafa\n2- Rehab Mohammed Reda\n3- Kariem Mohammed Ali\n4- Ahmad Mansour");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
