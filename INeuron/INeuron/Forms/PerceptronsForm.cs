using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NeuralNetworks.Perceptrons;
using NeuralNetworks.Utilities;

namespace INeuron.Forms
{
    
    public partial class PerceptronsForm : Form
    {
        
        List<Data> TrainingData ;
        List<double> meanvector = new List<double>();
        List<double> maxvector = new List<double>();
        string TrainingDataFileName = "";
        string TestingDataFileName = "";
        MultiLayerPerceptron MultiLayerNetwork;
        RosenblattsPerceptron RPerceptron;

        public PerceptronsForm()
        {
            InitializeComponent();
        }

        void ReadTrainingData(string Path, int numberOfClasses)
        {
            TrainingData = new List<Data>();
            FileStream FS = new FileStream(Path, FileMode.Open, FileAccess.Read);
            StreamReader SR = new StreamReader(FS);
            SR.ReadLine();
            for (int i = 0; i < numberOfClasses; i++)
            {
                for (int j = 0; j < 35; j++)
                {
                    string inputLine = SR.ReadLine();
                    Data InputData = new Data();
                    InputData.Features = new List<double>();
                    string[] Data = inputLine.Split(' ');
                   InputData.Features.Add (double.Parse(Data[0]));
                    InputData.Features.Add(double.Parse(Data[1]));
                    InputData.Features.Add(double.Parse(Data[2]));
                   InputData.Features.Add(double.Parse(Data[3]));
                    InputData.Class = i+1;
                    TrainingData.Add(InputData);
                }
            }
        }
        void Normalize(int numberOfFeatures, ref List<double> MeanVector, ref List<double> MaxVector)
        {
            MeanVector = new List<double>();
            for (int i = 0; i < numberOfFeatures; i++)
            {
                MeanVector.Add(0);
                for (int j = 0; j < TrainingData.Count; j++)
                {
                    MeanVector[i] += TrainingData[j].Features[i];
                }
                MeanVector[i] /= TrainingData.Count;
            }

            for (int i = 0; i < numberOfFeatures; i++)
            {

                for (int j = 0; j < TrainingData.Count; j++)
                {
                    TrainingData[j].Features[i] -= MeanVector[i];
                }

            }

            MaxVector = new List<double>();
            for (int i = 0; i < numberOfFeatures; i++)
            {
                MaxVector.Add(0);
                for (int j = 0; j < TrainingData.Count; j++)
                {
                    if (TrainingData[j].Features[i] > MaxVector[i])
                        MaxVector[i] = TrainingData[j].Features[i];
                }

            }

            for (int i = 0; i < numberOfFeatures; i++)
            {

                for (int j = 0; j < TrainingData.Count; j++)
                {
                    TrainingData[j].Features[i] /= MaxVector[i];
                }

            }
        }  

        private void button1_Click_1(object sender, EventArgs e)
        {
            //errors_lbl.Visible = true;
            
            button3.Visible = true;
            button4.Visible = true;
            if (comboBox1.SelectedIndex == 1)
            {
                ReadTrainingData(TrainingDataFileName, 3);
                Normalize(4, ref meanvector, ref maxvector);
                MultiLayerNetwork = new MultiLayerPerceptron(TrainingData, 4, 20, 3);
                for (int i = 0; i < 500; i++)
                    MultiLayerNetwork.StartTraining(0.4);
            }

            else
            {
                ReadTrainingData(TrainingDataFileName, 2);
                
                RPerceptron = new RosenblattsPerceptron(TrainingData, 4);
                  for (int j = 0;j < 5000; j++)
                   RPerceptron.StartTraining(0.4);
                
            }
            training_lbl.Show();
            testing_gb.Show();
            training_gb.Enabled = false;
            testing_gb.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                TrainingDataFileName = openFile.FileName;
                testing_gb.Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            training_lbl.Visible = false;

            testing_gb.Hide();

            comboBox1.SelectedIndex = 0;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
                TestingDataFileName = openFile.FileName;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (TestingDataFileName == "")
            {
                TestingDataFileName = TrainingDataFileName;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                ReadTrainingData(TestingDataFileName, 3);
                Normalize(4, ref meanvector, ref maxvector);
                errors_lbl.Text = "Errors = " + MultiLayerNetwork.Test(TrainingData).ToString();
            }
            else
            {
                ReadTrainingData(TestingDataFileName, 2);
                
                 errors_lbl.Text = "Errors = " + RPerceptron.Test(TrainingData).ToString();
            }
            training_gb.Enabled = true;
            testing_gb.Enabled = false;
            training_lbl.Hide();
        }
    }
}
