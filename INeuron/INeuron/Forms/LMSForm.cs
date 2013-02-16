using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NeuralNetworks.LearningAlgorithms;
using NeuralNetworks.Utilities;

namespace INeuron.Forms
{
    public partial class LMSForm : Form
    {
        public LMSForm()
        {
            InitializeComponent();
        }
       
        private LMS myPerceptron = null;
        private TrainingData td = null;
        private TestData teD = null;
        
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                 td = new TrainingData(fd.FileName);
                 myPerceptron = new LMS(float.Parse(eta_textbox.Text), float.Parse(w_thre_textbox.Text), float.Parse(mse_thre_textbox.Text), td.NumOfInputSignals);
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (myPerceptron != null)
            {
                myPerceptron.StartLMS(td,int.Parse(epoch_textbox.Text), int.Parse(num_trin_textbox.Text));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (myPerceptron != null && td!=null)
            {
                List<int> output = new List<int>();
                output = myPerceptron.TestClassifierUsingLMS(td.InputSignals, td.NormalizedInputSignals, td.NumOfInputSignals);

              int correct = 0;

              for (int i = 0; i < td.DesiredOutput.Count; i ++ )
              {
                  if (output[i]==td.DesiredOutput[i])
                  {
                      correct++;
                  }
              }

              MessageBox.Show(correct.ToString()+" features classified correctly");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                teD = new TestData(fd.FileName);
            }
        }
    }
}
