using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NeuralNetworks.Utilities
{
    public struct Data
    {
        public List<double> Features;
        public int Class;
    }
    public class TrainingData
    {
        public int NumOfClasses { get; set; }
        public int NumOfInputSignals { get; set; }
        public List<int> DesiredOutput { get; set; }
        public int SizeOfData { get; set; }
        public List<List<float>> InputSignals { get; set; }
        public List<List<float>> NormalizedInputSignals  {get; set; }
        public List<float> mean0 { get; set; }
        public List<float> max0 { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="TrainingData"/> class.
        /// </summary>
        /// <param name="p_dataPath">The p_data path.</param>
        public TrainingData(string p_dataPath)
        {
            this.InputSignals = new List<List<float>>();
            this.NormalizedInputSignals = new List<List<float>>();
            this.max0 = new List<float>();
            this.mean0 = new List<float>();
            this.DesiredOutput = new List<int>();
            
            this.ReadData(p_dataPath);
        }


        /// <summary>
        /// Reads the data.
        /// </summary>
        /// <param name="p_dataPath">The p_data path.</param>
        private void ReadData(string p_dataPath)
        {
            FileStream fs = new FileStream(p_dataPath,FileMode.Open,FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string rstring = sr.ReadLine();
            this.NumOfClasses = 3;
            this.NumOfInputSignals = 4;
            for (int w = 0; w < this.NumOfInputSignals; w++)
            {
                this.InputSignals.Add(new List<float>());
            }

            int k = 0;
            while (sr.Peek()!=-1)
            {
                rstring = sr.ReadLine();
                char[] parm = { ' ', '\t'};
                string[] tempArr = rstring.Split(parm);
                int i = 0;

                for (; i < this.NumOfInputSignals; i++)
                {
                    this.InputSignals[i].Add(float.Parse(tempArr[i]));
                }
                bool checkdesired = false;
                for (i = 0; i < this.NumOfClasses;i++ )
                {
                    if (int.Parse(tempArr[i+this.NumOfInputSignals])==1)
                    {
                        if (i > 1)
                        {
                            checkdesired = true;
                            break;
                        }
                        if(i==1)
                        this.DesiredOutput.Add(1);
                        else
                        this.DesiredOutput.Add(-1);

                        break;
                    }
                }
                k++;
                if (checkdesired)
                {
                    break;
                }

            }
            this.SizeOfData = k;
            this.CalculateNormalizedData();
            sr.Close();
            fs.Close();
        }

        /// <summary>
        /// Calculates the normalized data.
        /// </summary>
        private void CalculateNormalizedData()
        {
            for (int i = 0; i < this.NumOfInputSignals; i++ )
            {
                float tempmean = this.InputSignals[i].Sum();
                mean0.Add(tempmean/(float)this.InputSignals[i].Count);
            }
            //calculate max0
            for (int i = 0; i < this.NumOfInputSignals; i++)
            {
                List<float> absList = new List<float>();
                this.NormalizedInputSignals.Add(new List<float>());
                for (int j = 0; j < this.SizeOfData; j++)
                {
                    this.NormalizedInputSignals[i].Add(this.InputSignals[i][j]- mean0[i]);
                    absList.Add(Math.Abs(this.NormalizedInputSignals[i][j]));
                }
                max0.Add(absList.Max());
            }

            //calculate normalized data.
            for (int i = 0; i < this.NumOfInputSignals; i++)
            {
                for (int j = 0; j < this.SizeOfData; j++)
                {
                    this.NormalizedInputSignals[i][j] = (NormalizedInputSignals[i][j] / max0[i]);
                }
            }
        }
    }
}
