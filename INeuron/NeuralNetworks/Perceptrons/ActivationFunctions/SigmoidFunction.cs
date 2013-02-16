using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuralNetworks.Perceptrons
{
    public class SigmoidFunction : IActivationFunction
    {
        /// <summary>
        /// Gets my sign.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public double GetMySign(double value)
        {
            return (1) / (1 + Math.Exp(-value));
        }
    }
}
