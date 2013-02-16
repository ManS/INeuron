using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetworks.Utilities;

namespace NeuralNetworks.Perceptrons
{
    interface INeuralNetwork
    {
        void StartTraining(double LearningRate);
        int Test(List<Data> p_testData);
    }
}
