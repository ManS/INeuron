using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using NeuralNetworks.Utilities;
namespace NeuralNetworks.LearningAlgorithms
{
    public class GHA
    {
        int blockWidth, blockHeight, numberOfPrincipleComponents, numberOfEpochs,numberOfInputPatterns;
        double learningRate;


        public GHA(Point p, int numberOfPrincipleComponents, double learningRate, int numberOfEpochs)
        {
            blockWidth = p.X;
            blockHeight = p.Y;
            
            this.numberOfPrincipleComponents = numberOfPrincipleComponents;
            this.learningRate = learningRate;
            this.numberOfEpochs = 10;
        }
        private void writeDoubleArray(double[,]arr,string name)
        {
            StreamWriter sw=new StreamWriter(name);
            int rows=arr.GetLength(0);
            int columns=arr.GetLength(1);
            for(int i=0;i<rows;i++)
            {
                for(int j=0;j<columns;j++)
                {
                    sw.Write(arr[i,j].ToString()+"      ");
                }
                sw.WriteLine();
            }
            sw.Close();
        }
        public Bitmap DoGeneralHebbianAlgorithm(string imagePath)
        {
            Bitmap image = new Bitmap(imagePath);
            numberOfInputPatterns=(image.Height/blockHeight )*(image.Width/blockWidth);
            UnsafeBitmap unSafeImage = new UnsafeBitmap(image);
            unSafeImage.LockBitmap();
            double[,] AA = BreakImageIntoPatterns(unSafeImage);//tested:)

           
            int maxValue = GetMaxValueInImage(unSafeImage);
            double[,] DD = NormalizeTheImage(AA, maxValue);
            double[,]newarr=CreateArrayWithValue(8,64,0.5);
      

    double [,] initialWeightsTransposed=       TestingGHAMainRoutine(DD, 8, 500);      

 double[,]coeffs=   GetCoefficientsSubRoutineForOneInputPattern(DD, initialWeightsTransposed);

Bitmap newImage= GHARecompose(coeffs, initialWeightsTransposed, 1, image.Height / blockHeight, image.Width / blockWidth, blockHeight, blockWidth, maxValue);
newImage.Save("kokoko.bmp");
            unSafeImage.UnlockBitmap();
            return newImage;
        }
        private int GetMaxValueInImage(UnsafeBitmap unsafeImage)
        {
            int maxValue = -1;
            for (int i = 0; i < unsafeImage.Bitmap.Height; i++)
            {
                for (int j = 0; j < unsafeImage.Bitmap.Width; j++)
                {
                    PixelData pixelColor = unsafeImage.GetPixel(j, i);
                    if (pixelColor.Blue > maxValue)
                        maxValue = pixelColor.Blue;

                }

            }
            return maxValue;
        }
        private double[,] BreakImageIntoPatterns(UnsafeBitmap unsafeImage)
        {
            int numberOfRows = unsafeImage.Bitmap.Height / blockHeight;
            int numberOfColumns = unsafeImage.Bitmap.Width / blockWidth;
            int numberOfInputPatterns = numberOfRows * numberOfColumns;
            double[,] inputPatterns = new double[numberOfInputPatterns, blockWidth * blockHeight]; //1024 Rows and 64 Colums
            int indexOfCurrentInputPattern = 0;

            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    int index = 0;
                    for (int K = i*blockHeight; K < (i + 1) * blockHeight; K++)
                    {
                        for (int h = j*blockWidth; h < (j + 1) * blockWidth; h++)
                        {
                            inputPatterns[indexOfCurrentInputPattern, index] = unsafeImage.GetPixel(h, K).Blue;
                            index++;
                        }

                    }
                    indexOfCurrentInputPattern++;

                }
            }

            return inputPatterns;
        }
        private double[,] CreateArrayWithValue(int rows, int columns, double value)
        {
            double[,] newArray = new double[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    newArray[i, j] = value;
                }
            }
            return newArray;
        }
        private double[] CreateArrayWithValue1D(int rows, double value)
        {
            double[] newArray = new double[rows];
            for (int i = 0; i < rows; i++)
            {
               
                    newArray[i] = value;
                
            }
            return newArray;
        }
        private double[,] NormalizeTheImage(double[,] inputPatterns, int maxValue)
        {
            int rows = inputPatterns.GetLength(0);
            int columns = inputPatterns.GetLength(1);
            double[,] normalizedpatterns = new double[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    normalizedpatterns[i, j] = inputPatterns[i, j] / maxValue;
                }
            }
            return normalizedpatterns;
        }
        private UnsafeBitmap NormalizeTheImage(UnsafeBitmap unsafeImage, int maxValue)
        {
            for (int i = 0; i < unsafeImage.Bitmap.Height; i++)
            {
                for (int j = 0; j < unsafeImage.Bitmap.Width; j++)
                {
                    PixelData pixelData = unsafeImage.GetPixel(j, i);
                    PixelData newPixelData = new PixelData((byte)(pixelData.Blue / maxValue), (byte)(pixelData.Red / maxValue), (byte)(pixelData.Green / maxValue));
                    unsafeImage.SetPixel(j, i, newPixelData);

                }
            }
            return unsafeImage;
        }
        private double GetY(double []weights,double []x)
        {
            int rows1 = weights.GetLength(0);
            int rows2 = x.GetLength(0);
            if (rows1 != rows2)
                throw new Exception("the two matrices haven't equal number of rows");
            double sum = 0;
            for (int i = 0; i < rows1; i++)
            {
                sum += weights[i] * x[i];
                if (sum==double.NaN)
                    throw new Exception("GetY");
            }
            return sum;
        }
        private double[,] Multiply2d(double[,] first, double[,] second)
        {
        
            int rows1 = first.GetLength(0);
            int rows2 = second.GetLength(0);
            int cols1 = first.GetLength(1);
            int cols2 = second.GetLength(1);
            if (rows1 != rows2 || cols1 != cols2)
                throw new Exception("unequal dimensions");
            double[,] res = new double[rows1, cols1];
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    res[i, j] = first[i, j] * second[i, j];

                }
            }
            return res;
        }
        public double[,] TestingGHAMainRoutine( double[,] D, int numberOfPrincipleComponents, int numberOfEpochs)// initial weights =8*64 // D=1024*64
        {

            int numberOfPixelsInOnePattern =D.GetLength(1);
            double[,] bigNewWeights = new double[numberOfPrincipleComponents, numberOfPixelsInOnePattern];
          
            double[,] initialWeights = CreateArrayWithValue(numberOfPrincipleComponents, numberOfPixelsInOnePattern, 0.5);
            int numberOfInputPatterns = D.GetLength(0);
            
            double[] y = new double[numberOfPrincipleComponents];


            for (int i = 0; i < numberOfEpochs; i++)
            {
                for (int j = 0; j < numberOfInputPatterns; j++)
                {
                    int h = 0;
                    double[] newWeights = new double[initialWeights.GetLength(1)];
                    double[] x = new double[numberOfPixelsInOnePattern];
                    double[] currentW = new double[numberOfPixelsInOnePattern];

                  for (int k = 0; k < numberOfPixelsInOnePattern; k++)
                    {

                        x[k] = D[j, k];
                        currentW[k] = initialWeights[0, k];

                    }

                    y[0] = GetY(currentW, x);
                    double[] WY = ScalarMultiply(currentW, y[0]);
                    double[] XSubWY = Subtract(x, WY);
                    newWeights = ScalarMultiply(XSubWY, learningRate * y[0]);


                    for (int v = 0; v < numberOfPixelsInOnePattern; v++)
                    {
                        bigNewWeights[h, v] = newWeights[v];
                    }



                    for (h = 1; h < numberOfPrincipleComponents; h++)
                    {

                        for (int k = 0; k < numberOfPixelsInOnePattern; k++)
                        {

                            currentW[k] = initialWeights[h, k];

                        }



                        y[h] = GetY(currentW, x);


                        double[] temp = CreateArrayWithValue1D(numberOfPixelsInOnePattern, 0);
                        //noo
                        for (int g = 0; g <= h; g++)
                        {
                            for (int k = 0; k < numberOfPixelsInOnePattern; k++)
                            {

                                currentW[k] = initialWeights[g, k];

                            }
                            temp = Add(temp, ScalarMultiply(currentW, y[g]));
                        }


                        newWeights = ScalarMultiply(Subtract(x, temp), learningRate * y[h]);

                        for (int v = 0; v < numberOfPixelsInOnePattern; v++)
                        {
                            bigNewWeights[h, v] = newWeights[v];
                        }



                    }




                    initialWeights = Add2d(initialWeights, bigNewWeights);


                }

            
            }

            return Matrix.Transpose(initialWeights);
        }
        private double[,] GHAMainRoutine(double[,] initialWeights, double[,] D)// initial weights =8*64 // D=1024*64
        {
            double[,] bigNewWeights = new double[initialWeights.GetLength(0), initialWeights.GetLength(1)];
            int numberOfPixelsInOnePattern = blockHeight * blockWidth;
          
    
            double[] y = new double[numberOfPrincipleComponents];


            for (int i = 0; i < numberOfEpochs; i++)
            {
                for (int j = 0; j < numberOfInputPatterns; j++)
                {
                    int h = 0;
                    double[] newWeights = new double[ initialWeights.GetLength(1)];
                    double[] x = new double[ numberOfPixelsInOnePattern];
                    double[] currentW = new double[ numberOfPixelsInOnePattern];

                   for (int k = 0; k < numberOfPixelsInOnePattern; k++)
                    {

                        x[ k] = D[j, k];
                        currentW[ k] = initialWeights[0, k];

                    }

                     y[0] = GetY(currentW, x);
                     double[] WY = ScalarMultiply(currentW, y[0]);
                    double []XSubWY=Subtract( x,WY);
                     newWeights = ScalarMultiply( XSubWY , learningRate * y[0]);


                    for (int v = 0; v < numberOfPixelsInOnePattern; v++)
                    {
                        bigNewWeights[h, v] = newWeights[ v];
                    }
                    


                    for (h = 1; h < numberOfPrincipleComponents; h++)
                    {

                        for (int k = 0; k < numberOfPixelsInOnePattern; k++)
                        {

                            currentW[k] = initialWeights[h, k];

                        }



                        y[h] = GetY(currentW, x);
                       
                    
                     double[] temp =  CreateArrayWithValue1D(numberOfPixelsInOnePattern, 0);
                        //noo
                        for (int g = 1; g < h; g++)
                        {
                            for (int k = 0; k < numberOfPixelsInOnePattern; k++)
                            {

                                currentW[k] = initialWeights[g, k];

                            }
                            temp = Add(temp, ScalarMultiply( currentW,y[g]));
                        }


                        newWeights = ScalarMultiply(Subtract(x, temp),learningRate * y[h]);

                        for (int v = 0; v < numberOfPixelsInOnePattern; v++)
                        {
                            bigNewWeights[h, v] = newWeights[ v];
                        }



                    }




                    initialWeights = Add2d(initialWeights, bigNewWeights);


                }
            }

            return Matrix.Transpose(initialWeights);
        }
        private double[,] Add2d(double[,] arr1, double[,] arr2)
        {
            int rows1 = arr1.GetLength(0);
            int rows2 = arr2.GetLength(0);
            if (rows1 != rows2)
                throw new Exception("number of rows aren't equal");
            int cols1 = arr1.GetLength(1);
            int cols2 = arr2.GetLength(1);
            if (rows1 != rows2)
                throw new Exception("number of rows aren't equal");
            double[,] result = new double[rows1, cols1];
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    result[i,j]=arr1[i,j]+arr2[i,j];

                    if (double.IsNaN(result[i, j]) || double.IsPositiveInfinity(result[i,j]) || double.IsNegativeInfinity(result[i,j]))
                        throw new Exception("Add2D");
                }
            }
            return result;
        }
        private double[] Subtract(double[] arr1, double[] arr2)
        {
            int rows1 = arr1.GetLength(0);
            int rows2 = arr2.GetLength(0);
            if (rows1 != rows2)
                throw new Exception("number of rows aren't equal");
            double[] result = new double[rows1];
            for (int i = 0; i < rows1; i++)
            {
                result[i] = arr1[i] - arr2[i];
                if (double.IsNaN(result[i]) || double.IsPositiveInfinity(result[i]) || double.IsNegativeInfinity(result[i]))
                    throw new Exception("Subtract");
            }
            return result;
        }
        private double[] Add(double[] arr1, double[] arr2)
        {

            int rows1 = arr1.GetLength(0);
            int rows2 = arr2.GetLength(0);
            if (rows1 != rows2)
                throw new Exception("number of rows aren't equal");
            double[] result = new double[rows1];
            for (int i = 0; i < rows1; i++)
            {
                result[i] = arr1[1] +arr2[i];
                if (double.IsNaN(result[i]) ||double.IsPositiveInfinity(result[i])||double.IsNegativeInfinity(result[i]))
                    throw new Exception("Add");
            }
            return result;
        }
        private double[] ScalarMultiply(double[] arr, double val)
        {    int rows = arr.GetLength(0);
        
            double[] newArr = new double[rows];
            for (int i = 0; i < rows; i++)
            {
                newArr[i] = arr[i] * val;
                if (double.IsNaN(newArr[i]) || double.IsPositiveInfinity(newArr[i]) || double.IsNegativeInfinity(newArr[i]))
                    throw new Exception("Scalar Multiply");
            }
            return newArr;
        }
        private double[,] GetCoefficientsSubRoutineForOneInputPattern(double[,] NormalizedInputPatterns, double[,] Transposedweights)
        {
            int rows = Transposedweights.GetLength(0);
            int cols = Transposedweights.GetLength(1); int numberOfPatterns = NormalizedInputPatterns.GetLength(0);
            double[,] sum = new double[numberOfPatterns, numberOfPrincipleComponents];
            for (int patternNumber = 0; patternNumber < numberOfPatterns; patternNumber++)
            {
                for (int j = 0; j < cols; j++)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        sum[patternNumber, j] += NormalizedInputPatterns[patternNumber, i] * Transposedweights[i, j];
                    }
                }
            }
            return sum;

        }
        private double[,] BuildRepeated64Mul8Matrix(double[] g)
        {
            int rows = g.GetLength(0);
            double[,] newMat = new double[64, rows];
            for (int i = 0; i < 64; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    newMat[i, j] = g[j];
                }

            }
            return newMat;

        }
        private double[] GetColumsSumOfMatrix(double[,] Mat)
        {
            int rows = Mat.GetLength(0);
            int columns = Mat.GetLength(1);
            double[] sum = new double[columns];
            for (int j = 0; j < columns; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    sum[j] += Mat[i, j];
                }
            }
            return sum;
        }
        private Bitmap GHARecompose(double[,] coeffs, double[,] transposedWeights, int num_layer, int r, int c, int rm, int cm,int mvalue)
        {
            int row = 0;
            int rW = transposedWeights.GetLength(0);
            int cW = transposedWeights.GetLength(1);
            double[] g = new double[numberOfPrincipleComponents];
            double[,] imdata = new double[r * c, 64];

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    for (int k = 0; k < numberOfPrincipleComponents; k++)
                    {
                        g[k] = coeffs[row, k];
                    }

                    double[,] CA = BuildRepeated64Mul8Matrix(g);

                    double[,] val = Matrix.Transpose(Multiply2d(CA, transposedWeights));

                    double[] val2 = GetColumsSumOfMatrix(val);
                    for (int f = 0; f < 64; f++)
                    {
                        imdata[row, f] = val2[f];
                    }
                    row++;



                }




            }

      double[,]X=      Matrix.ScalarMultiply(mvalue, imdata);
      row = 1;

      int indexOfCurrentInputPattern = 0;
      UnsafeBitmap unsafeImage = new UnsafeBitmap(r * rm, c * cm);
      unsafeImage.LockBitmap();
      for (int i = 0; i < r; i++)
      {
          for (int j = 0; j < c; j++)
          {
              int index = 0;
              for (int K = i*rm; K < (i + 1) * rm; K++)
              {
                  for (int h = j*cm; h < (j + 1) * cm; h++)
                  {
                      byte color=(byte)X[indexOfCurrentInputPattern, index];
                      unsafeImage.SetPixel(h,K,new PixelData(color,color,color));
               
                      index++;
                  }

              }
              indexOfCurrentInputPattern++;

          }
      }
            unsafeImage.SetPixel(0,0,new PixelData(0,255,0));
      unsafeImage.UnlockBitmap();
      return unsafeImage.Bitmap;

        }
    }
}
