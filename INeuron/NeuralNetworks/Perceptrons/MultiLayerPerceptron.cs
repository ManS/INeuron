using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NeuralNetworks.Utilities;

namespace NeuralNetworks.Perceptrons
{
    public class MultiLayerPerceptron : INeuralNetwork
    {
        #region Properties
        List<Data> TrainingData;
        List<Perceptron> HiddenLayers;
        List<Perceptron> Outputs;
        int numberOfInputs;
        int numberOfHiddenLayers;
        int numberOfClasses;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiLayerPerceptron"/> class.
        /// </summary>
        /// <param name="TD">The TD.</param>
        /// <param name="NOI">The NOI.</param>
        /// <param name="NOHL">The NOHL.</param>
        /// <param name="NOC">The NOC.</param>
        public MultiLayerPerceptron(List<Data> TD,int NOI,int NOHL,int NOC)
        {
            TrainingData = TD;
            numberOfInputs = NOI;
            numberOfHiddenLayers = NOHL;
            numberOfClasses = NOC;
            PrepareMultiLayerNetwork();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Prepares the multi layer network.
        /// </summary>
        void PrepareMultiLayerNetwork()
        {
            HiddenLayers = new List<Perceptron>();
            Random randomGenerator = new Random();
            for (int i = 0; i < numberOfHiddenLayers; i++)
            {
                List<double> weights = new List<double>();
                for (int j = 0; j < numberOfInputs; j++)
                    weights.Add(randomGenerator.NextDouble());
                HiddenLayers.Add(new Perceptron(numberOfInputs, new SigmoidFunction(), weights));
            }

            Outputs = new List<Perceptron>();
            for (int i = 0; i < numberOfClasses; i++)
            {
                List<double> weights = new List<double>();
                for (int j = 0; j < numberOfHiddenLayers; j++)
                    weights.Add(randomGenerator.NextDouble());
                Outputs.Add(new Perceptron(numberOfHiddenLayers, new SigmoidFunction(), weights));
            }
        }
      
        /// <summary>
        /// Starts the training.
        /// </summary>
        /// <param name="LearningRate">The learning rate.</param>
        public void StartTraining(double LearningRate)
       {
            for (int i = 0; i < TrainingData.Count; i++)
            {
                double[] disiredOutput = new double[3];
                for (int j = 0; j < Outputs.Count; j++)
                {
                    if (TrainingData[i].Class == 1)
                        disiredOutput[0] = 1;

                    if (TrainingData[i].Class == 2)
                        disiredOutput[1] = 1;

                    if (TrainingData[i].Class == 3)
                        disiredOutput[2] = 1;
                }

                // Forward Step
                List<double> inputs = new List<double>();
                for (int j = 0; j < numberOfInputs; j++)
                    inputs.Add(TrainingData[i].Features[j]);
                List<double> HiddenLayersOutput = new List<double>();
                for (int j = 0; j < HiddenLayers.Count; j++)
                {
                    HiddenLayers[j].Inputs = inputs;
                    HiddenLayersOutput.Add(HiddenLayers[j].GenerateOutput());
                }
                List<double> FinalOutputs = new List<double>();
                for (int j = 0; j < Outputs.Count; j++)
                {
                    Outputs[j].Inputs = HiddenLayersOutput;
                    FinalOutputs.Add(Outputs[j].GenerateOutput());
                    Outputs[j].Sigma = FinalOutputs[j] * (1 - FinalOutputs[j]) * (disiredOutput[j] - FinalOutputs[j]);  // calculating error prop. starting from output layer
                }

                //calculating error signal propagation
                for (int j = 0; j < HiddenLayers.Count; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < Outputs.Count; k++)
                    {
                        sum += Outputs[k].Sigma * Outputs[k].Weights[j];
                    }
                    HiddenLayers[j].Sigma = sum * (HiddenLayersOutput[j] * (1 - HiddenLayersOutput[j]));
                }

                // updating weights

                for (int j = 0; j < HiddenLayers.Count; j++)
                {
                    for (int k = 0; k < HiddenLayers[j].Weights.Count; k++)
                        HiddenLayers[j].Weights[k] += (LearningRate * HiddenLayers[j].Sigma * HiddenLayers[j].Inputs[k]);
                }

                for (int j = 0; j < Outputs.Count; j++)
                {
                    for (int k = 0; k < Outputs[j].Weights.Count; k++)
                        Outputs[j].Weights[k] += (LearningRate * Outputs[j].Sigma * Outputs[j].Inputs[k]);
                }

            }
        }
        
        /// <summary>
        /// Tests the specified test data.
        /// </summary>
        /// <param name="TestData">The test data.</param>
        /// <returns></returns>
        public int Test(List<Data> TestData)
        {
          int errors = 0;
          FileStream fs = new FileStream("MultiLayer Output.txt", FileMode.Create, FileAccess.Write);
          StreamWriter sw = new StreamWriter(fs);
         
          List<double>[] PerceptronOutput = new List<double>[3];
          List<double>[] FinalOutputs = new List<double>[3];
          for (int i = 0; i < 3; i++)
              PerceptronOutput[i] = new List<double>();

          for (int i = 0; i < TestData.Count; i++)
          {
              List<double> inputs = new List<double>();
              for (int j = 0; j < numberOfInputs; j++)
                  inputs.Add(TestData[i].Features[j]);
              List<double> HiddenLayersOutput = new List<double>();
              for (int j = 0; j < HiddenLayers.Count; j++)
              {
                  HiddenLayers[j].Inputs = inputs;
                  HiddenLayersOutput.Add(HiddenLayers[j].GenerateOutput());
              }
              for (int j = 0; j < Outputs.Count; j++)
              {
                  Outputs[j].Inputs = HiddenLayersOutput;
                  PerceptronOutput[j].Add(Outputs[j].GenerateOutput());

              }
              if (PerceptronOutput[0][PerceptronOutput[0].Count - 1] > PerceptronOutput[1][PerceptronOutput[1].Count - 1] && PerceptronOutput[0][PerceptronOutput[0].Count - 1] > PerceptronOutput[2][PerceptronOutput[2].Count - 1])
              {
                  PerceptronOutput[0][PerceptronOutput[0].Count - 1] = 1;
                  PerceptronOutput[1][PerceptronOutput[1].Count - 1] = 0;
                  PerceptronOutput[2][PerceptronOutput[2].Count - 1] = 0;
                  if (TestData[i].Class != 1)
                      errors++;
              }
              else
              {
                  if (PerceptronOutput[1][PerceptronOutput[1].Count - 1] > PerceptronOutput[0][PerceptronOutput[0].Count - 1] && PerceptronOutput[1][PerceptronOutput[1].Count - 1] > PerceptronOutput[2][PerceptronOutput[2].Count - 1])
                  {
                      PerceptronOutput[0][PerceptronOutput[0].Count - 1] = 0;
                      PerceptronOutput[1][PerceptronOutput[1].Count - 1] = 1;
                      PerceptronOutput[2][PerceptronOutput[2].Count - 1] = 0;
                      if (TestData[i].Class != 2)
                          errors++;
                  }
                  else
                  {
                      PerceptronOutput[0][PerceptronOutput[0].Count - 1] = 0;
                      PerceptronOutput[1][PerceptronOutput[1].Count - 1] = 0;
                      PerceptronOutput[2][PerceptronOutput[2].Count - 1] = 1;
                      if (TestData[i].Class != 3)
                          errors++;
                  }
              }
              sw.WriteLine(i + " " + PerceptronOutput[0][PerceptronOutput[0].Count - 1] + " " + PerceptronOutput[1][PerceptronOutput[1].Count - 1] + " " + PerceptronOutput[2][PerceptronOutput[2].Count - 1]);
          }
          sw.Close();
          return errors;
      }
        #endregion
     }
}
