using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PM.DSS.App.Web.Services
{
    public class ArrayExtension
    {
        public double[] MatrixProduct(double[][] matrixA,double[] vectorB)
        {
            int aRows = matrixA.Length; int aCols = matrixA[0].Length;
            int bRows = vectorB.Length;
            if (aCols != bRows)
                throw new Exception("Non-conformable matrices in MatrixProduct");
            double[] result = new double[aRows];
            for (int i = 0; i < aRows; ++i) // each row of A
                for (int k = 0; k < aCols; ++k)
                    result[i] += matrixA[i][k] * vectorB[k];
            return result;
        }
        public double[][] MatrixProduct(double[][] matrixA, double[][] matrixB)
        {
            int aRows = matrixA.Length; int aCols = matrixA[0].Length;
            int bRows = matrixB.Length; int bCols = matrixB[0].Length;
            if (aCols != bRows)
                throw new Exception("Non-conformable matrices in MatrixProduct");
            double[][] result = MatrixCreate(aRows, bCols);
            for (int i = 0; i < aRows; ++i) // each row of A
                for (int j = 0; j < bCols; ++j) // each col of B
                    for (int k = 0; k < aCols; ++k)
                        result[i][j] += matrixA[i][k] * matrixB[k][j];
            return result;
        }
        public double[][] MatrixCreate(int rows, int cols)
        {
            // creates a matrix initialized to all 0.0s  
            // do error checking here?  
            double[][] result = new double[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new double[cols];
            // auto init to 0.0  
            return result;
        }
    }
}