using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NeuralNetworks.Perceptrons
{
    public class Perceptron
    {
        #region Properties
        List<double> inputs;
        public List<double> Inputs
        {
            get { return inputs; }
            set { inputs = value; }
        }
        List<double> weights;
        public List<double> Weights
        {
            get { return weights; }
            set { weights = value; }
        }
       
        double output;
        int numberOfInputs;
        public IActivationFunction ActivationFunction { get; set; }
        public double Sigma { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Perceptron"/> class.
        /// </summary>
        /// <param name="NOI">The NOI.</param>
        /// <param name="p_activationFunction">The p_activation function.</param>
        /// <param name="p_weights">The p_weights.</param>
        public Perceptron(int NOI, IActivationFunction  p_activationFunction,List<double> p_weights)
        {
            this.ActivationFunction = p_activationFunction;
            this.Weights = p_weights;
            numberOfInputs = NOI;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Generates the output.
        /// </summary>
        /// <returns></returns>
        public double GenerateOutput()
        {
            for (int i = 0; i < this.inputs.Count; i++)
                output += (this.Weights[i] * this.inputs[i]);
            return this.GetMySign(output);
        }

        /// <summary>
        /// Gets my sign.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public double GetMySign(double value)
        {
            output = this.ActivationFunction.GetMySign(value);
            return output;
        }
        #endregion
    }
}
