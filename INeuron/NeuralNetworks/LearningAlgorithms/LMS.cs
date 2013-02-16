using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetworks.Utilities;
using System.IO;

namespace NeuralNetworks.LearningAlgorithms
{
    public class LMS
    {
        #region Properties
        public float eta { get; set; }
        public float WeightChangeThre { get; set; }
        public float MSEThreshold { get; set; }
        public List<double> Weights { get; set; }
        public List<double> MSE { get; set; }
        private List<float> mean0 { get; set; }
        private List<float> max0 { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="LMS"/> class.
        /// </summary>
        /// <param name="p_eta">The p_eta.</param>
        /// <param name="p_weightThre">The p_weight thre.</param>
        /// <param name="p_mseThre">The p_mse thre.</param>
        /// <param name="p_inputSize">Size of the p_input.</param>
        public LMS(float p_eta, float p_weightThre, float p_mseThre, int p_inputSize)
        {
            this.Weights = new List<double>();
            this.mean0 = new List<float>();
            this.max0 = new List<float>();
            this.MSE = new List<double>();

            this.eta = p_eta;
            this.MSEThreshold = p_mseThre;
            this.WeightChangeThre = p_weightThre;
            this.InitializeWeights(p_inputSize);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes the weights.
        /// </summary>
        /// <param name="size">The size.</param>
        private void InitializeWeights(int size)
        {
            Random rand = new Random(0);
            for (int i = 0; i < size; i++)
            {
                Weights.Add(rand.NextDouble());
            }
        }

        /// <summary>
        /// Starts the LMS.
        /// </summary>
        /// <param name="p_trainingData">The p_training data.</param>
        /// <param name="epoach">The epoach.</param>
        /// <param name="p_minTrainingNum">The p_min training num.</param>
        public void StartLMS(TrainingData p_trainingData, int epoach, int p_minTrainingNum)
        {
            mean0 = p_trainingData.mean0;
            max0 = p_trainingData.max0;

            for (int i = 0; i < epoach; i++)
            {
                List<double> ee = new List<double>();
                for (int k = 0; k < p_trainingData.SizeOfData; k++)
                {
                    //List<float> inputSignal = new List<float>();
                    List<double> weightsXsignal = new List<double>();
                    double e;
                    List<double> w_delta = new List<double>();
                    for (int j = 0; j < p_trainingData.NumOfInputSignals; j++)
                    {
                        weightsXsignal.Add(p_trainingData.NormalizedInputSignals[j][k] * this.Weights[j]);//w'*x
                    }

                    e = p_trainingData.DesiredOutput[k] - weightsXsignal.Sum();

                    for (int j = 0; j < p_trainingData.NumOfInputSignals; j++)
                    {
                        w_delta.Add(this.eta * p_trainingData.NormalizedInputSignals[j][k] * e);
                    }
                    ee.Add(e);

                    if (w_delta.Max() < this.WeightChangeThre && k >= p_minTrainingNum)
                    {
                        break;//weights will not be updated anymore.
                    }
                    for (int j = 0; j < this.Weights.Count; j++)
                    {
                        this.Weights[j] += w_delta[j];
                    }
                }
                for (int j = 0; j < ee.Count; j++)
                {
                    ee[j] *= ee[j];
                }
                double mean = ee.Sum() / (double)ee.Count;
                this.MSE.Add(mean); //add mse 
                if (this.MSE[i] < this.MSEThreshold)
                {
                    break;//
                }
            }

            this.WriteErrors();
        }
   
        /// <summary>
        /// Writes the errors.
        /// </summary>
        private void WriteErrors()
        {
            FileStream fs = new FileStream("Weights&Errors.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Weights:");
            for (int i = 0; i < this.Weights.Count; i++)
            {
                sw.Write(this.Weights[i].ToString() + "\t");
            }
            sw.WriteLine("");
            sw.WriteLine("Errors:");
            for (int i = 0; i < this.MSE.Count; i++)
            {
                sw.WriteLine(this.MSE[i].ToString());
            }
            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// Tests the classifier using LMS.
        /// </summary>
        /// <param name="p_inputSignals">The p_input signals.</param>
        /// <param name="p_InputNormalizedSignals">The p_ input normalized signals.</param>
        /// <param name="numOfSignals">The num of signals.</param>
        /// <returns></returns>
        public List<int> TestClassifierUsingLMS(List<List<float>> p_inputSignals, List<List<float>> p_InputNormalizedSignals, int numOfSignals)
        {
            List<int> output = new List<int>();
            for (int i = 0; i < p_InputNormalizedSignals[0].Count; i++)
            {
                List<double> result = new List<double>();
                for (int j = 0; j < numOfSignals; j++)
                {
                    result.Add(p_InputNormalizedSignals[j][i] * this.Weights[j]);
                }
                output.Add(MySign(result.Sum()));
            }
            this.WriteClassificationResult(output, p_inputSignals);

            return output;
        }

        /// <summary>
        /// Writes the classification result.
        /// </summary>
        /// <param name="output">The output.</param>
        /// <param name="p_Input">The p_ input.</param>
        private void WriteClassificationResult(List<int> output, List<List<float>> p_Input)
        {
            FileStream fs = new FileStream("Classifier.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < output.Count; i++)
            {
                for (int k = 0; k < p_Input.Count; k++)
                {
                    sw.Write(p_Input[k][i].ToString() + "\t");
                }
                sw.WriteLine(output[i].ToString());
            }
            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// Mies the sign.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <returns></returns>
        private int MySign(double d)
        {
            return d >= 0 ? 1 : -1;
        }
        #endregion



    }
}
