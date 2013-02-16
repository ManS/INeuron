using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetworks.Utilities;
using System.IO;

namespace NeuralNetworks.LearningAlgorithms
{
    public class LinearRegression
    {
        #region Properties
        public List<Data> TrainingData = new List<Data>();
        public List<double> MeanVector;
        public List<double> MaxVector;
        public double[,] W;
        #endregion

        public LinearRegression()
        {

        }

        /// <summary>
        /// Reads the training data.
        /// </summary>
        /// <param name="Path">The path.</param>
        /// <param name="numberOfClasses">The number of classes.</param>
        public void ReadTrainingData(string Path, int numberOfClasses)
        {
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
                    InputData.Features.Add(double.Parse(Data[0]));
                    InputData.Features.Add(double.Parse(Data[1]));
                    InputData.Features.Add(double.Parse(Data[2]));
                    InputData.Features.Add(double.Parse(Data[3]));
                    InputData.Class = i + 1;
                    TrainingData.Add(InputData);
                }
            }
        }
        /// <summary>
        /// Normalizes the specified number of features.
        /// </summary>
        /// <param name="numberOfFeatures">The number of features.</param>
        public void Normalize(int numberOfFeatures)
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
        /// <summary>
        /// Linears the reg.
        /// </summary>
        /// <param name="mu">The mu.</param>
        public void LinearReg(double mu)
        {
            double[,] x = new double[TrainingData.Count, 4];
            double[,] Desired = new double[TrainingData.Count, 1];
            for (int i = 0; i < TrainingData.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                    x[i, j] = TrainingData[i].Features[j];
                Desired[i, 0] = TrainingData[i].Class;
            }

            double[,] I = new double[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == j)
                        I[i, j] = 1;
                    else
                        I[i, j] = 0;
                }
            }

            double[,] temp = Matrix.ScalarMultiply(mu, I);
            double[,] xTranspose = Matrix.Transpose(x);
            double[,] temp1 = Matrix.Inverse(Matrix.Multiply(xTranspose, x));
            double[,] temp2 = Matrix.Add(temp1, temp);
            double[,] temp3 = Matrix.Multiply(temp2, xTranspose);
            W = Matrix.Multiply(temp3, Desired);
        }
        /// <summary>
        /// Tests the specified p_path.
        /// </summary>
        /// <param name="p_path">The p_path.</param>
        /// <returns></returns>
        public int Test(string p_path)
        {
            TrainingData.Clear();
            ReadTrainingData(p_path, 2);

            Normalize(4);
            int errors = 0;
            FileStream fs = new FileStream("linearReg Output.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < TrainingData.Count; i++)
            {
                double output = 0;
                List<double> features = TrainingData[i].Features;
                for (int j = 0; j < 4; j++)
                {
                    output += (features[j] * W[j, 0]);
                }

                if (output < 0)
                    output = 1;
                else
                    output = 2;

                if ((i < (TrainingData.Count() / 2) && output != 1) || (i > (TrainingData.Count() / 2) && output != 2))
                    errors++;
                sw.WriteLine(i + "\t" + output);
            }

            return errors;
        }
    }
}
