using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NeuralNetworks.Perceptrons;
using NeuralNetworks.Utilities;

namespace NeuralNetworks.Perceptrons
{
    public class RosenblattsPerceptron : INeuralNetwork
    {
        #region Properties
        Perceptron P;
        List<Data>  TrainingData;
        int numberOfInputs;
        #endregion

        #region Constructor
         /// <summary>
        /// Initializes a new instance of the <see cref="RosenblattsPerceptron"/> class.
        /// </summary>
        /// <param name="trainingData">The training data.</param>
        /// <param name="NumberOfInputs">The number of inputs.</param>
         public  RosenblattsPerceptron(List<Data> trainingData,int NumberOfInputs)
        {
            TrainingData = trainingData;
            numberOfInputs = NumberOfInputs;
            PreparePerceptron();
        }
         #endregion
       
        #region Methods
        /// <summary>
        /// Prepares the perceptron.
        /// </summary>
        void PreparePerceptron()
        {
            Random randomGenerator = new Random();
            List<double> WeightVector= new List<double>();
                for (int j = 0; j < numberOfInputs; j++)
                {
                    WeightVector.Add(randomGenerator.NextDouble());
                }
                P = new Perceptron(numberOfInputs, new ThresholdFunction(), WeightVector);
            
        }

        /// <summary>
        /// Starts the training.
        /// </summary>
        /// <param name="eta">The eta.</param>
        public void StartTraining( double eta)
        {
            for (int i = 0; i < TrainingData.Count; i++)
            {
                List<double> inputs = new List<double>();
                for (int j = 0; j < numberOfInputs; j++)
                    inputs.Add(TrainingData[i].Features[j]);
                P.Inputs = inputs;
                
                double output = P.GenerateOutput();
                double desiredOutput;
                if (i<(TrainingData.Count()/2))
                    desiredOutput = 1;
                else
                    desiredOutput = 0;

                if (output != desiredOutput)
                {
                    for (int j = 0; j < P.Inputs.Count; j++)
                        P.Weights[j] += (eta * (desiredOutput - output) * P.Inputs[j]);
                }
            }

        }
        
        /// <summary>
        /// Tests the specified p_test data.
        /// </summary>
        /// <param name="p_testData">The p_test data.</param>
        /// <returns></returns>
        public int Test(List<Data> p_testData)
        {
            int errors = 0;
            FileStream fs = new FileStream("Perceptron Output.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < p_testData.Count; i++)
            {
                List<double> inputs = new List<double>();
                for (int j = 0; j < numberOfInputs; j++)
                    inputs.Add(p_testData[i].Features[j]);
                P.Inputs = inputs;
                double output = P.GenerateOutput();

                if ((i < (p_testData.Count() / 2) && output != 1) || (i > (p_testData.Count() / 2) && output != 0))
                    errors++;
                sw.WriteLine(i + "\t" + output);
            }
            return errors;
        }
        #endregion
    }
}
