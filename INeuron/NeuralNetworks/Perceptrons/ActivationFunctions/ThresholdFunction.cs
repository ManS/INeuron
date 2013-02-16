using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuralNetworks.Perceptrons
{
    public class ThresholdFunction : IActivationFunction
    {
        /// <summary>
        /// Gets my sign.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public double GetMySign(double value)
        {
            if (value > 0)
                return 1;
            else
                return 0;
        }
    }
}
