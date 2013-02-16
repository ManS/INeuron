using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuralNetworks.Perceptrons
{
    public interface IActivationFunction
    {
        double GetMySign(double value);
    }
}
