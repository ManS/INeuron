using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NeuralNetworks.Utilities
{
    public class TestData
    {
        public List<List<float>> InputSignals { get; set; }
        public List<List<float>> NormalizedSignals { get; set; }
        public int NumOfSignals { get; set; }
        public int SizeOfData { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestData"/> class.
        /// </summary>
        /// <param name="p_filepath">The p_filepath.</param>
        public TestData(string p_filepath)
        {
            this.InputSignals = new List<List<float>>();
            this.NormalizedSignals = new List<List<float>>();

            this.ReadData(p_filepath);
        }

        /// <summary>
        /// Reads the data.
        /// </summary>
        /// <param name="p_filepath">The p_filepath.</param>
        private void ReadData(string p_filepath)
        {
            FileStream fs = new FileStream(p_filepath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string rstring = sr.ReadLine();
            this.NumOfSignals = 4;
            for (int i = 0; i < this.NumOfSignals; i++)
            {
                this.InputSignals.Add(new List<float>());
            }
            int k = 0;
            while (sr.Peek()!=-1)
            {
                rstring = sr.ReadLine();
                char[] parm = {' ','\t'};
                string[] tempArr = rstring.Split(parm);
                for (int i = 0; i < this.NumOfSignals; i++)
                {
                    this.InputSignals[i].Add(float.Parse(tempArr[i]));
                }
                k++;
            }
            
            this.SizeOfData = k;
            fs.Close();
            sr.Close();
            this.NormalizeSignals();
        }

        /// <summary>
        /// Normalizes the signals.
        /// </summary>
        private void NormalizeSignals()
        {
            List<float> mean0 = new List<float>();
            List<float> max0 = new List<float>();
            for (int i = 0; i < this.NumOfSignals; i++)
            {
                float tempmean = this.InputSignals[i].Sum();
                mean0.Add(tempmean / (float)this.InputSignals[i].Count);
            }
            //calculate max0
            for (int i = 0; i < this.NumOfSignals; i++)
            {
                List<float> absList = new List<float>();
                this.NormalizedSignals.Add(new List<float>());
                for (int j = 0; j < this.SizeOfData; j++)
                {
                    this.NormalizedSignals[i].Add(this.InputSignals[i][j] - mean0[i]);
                    absList.Add(Math.Abs(this.NormalizedSignals[i][j]));
                }
                max0.Add(absList.Max());
            }

            //calculate normalized data.
            for (int i = 0; i < this.NumOfSignals; i++)
            {
                for (int j = 0; j < this.SizeOfData; j++)
                {
                    this.NormalizedSignals[i][j] = (NormalizedSignals[i][j] / max0[i]);
                }
            }
        }
    }
}
