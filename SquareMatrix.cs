using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics.LinearAlgebra.Double;

namespace NewtonMD
{
    public class SquareMatrix
    {
        private double[,] data = new double[3, 3];

        public int NumCols
        { get { return data.GetLength(1); } }

        public int NumRows
        { get { return data.GetLength(0); } }

        public SquareMatrix()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    this[i, j] = 0;
        }

        public double this[int row, int col]
        {
            get { return data[row, col]; }
            set {data[row, col] = value; }
        }

        public static SquareMatrix operator+(SquareMatrix left, SquareMatrix right)
        {
            SquareMatrix tmp = new SquareMatrix();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    tmp[i, j] = left[i,j] + right[i,j];
            return tmp;
        }
        public static Vector operator*(SquareMatrix left, Vector right)
        {
            Vector tmp = new Vector();
            double sum = 0;
            for (int i = 0; i < 3; i++)
            {
                sum = 0;
                for (int j = 0; j < 3; j++)
                    sum += right[j] * left[i, j];
                tmp[i] = sum;
            }
            return tmp;
        }
        //conversion operator
        public static implicit operator DenseMatrix(SquareMatrix m)
        {
            DenseMatrix tmp = new DenseMatrix(3, 3);
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    tmp[i, j] = m[i, j];
            return tmp;
        }
        public SquareMatrix GetInvD()
        {
            SquareMatrix tmp = new SquareMatrix();
            for (int i = 0; i < 3; i++)
                tmp[i, i] = 1 / this[i, i];
            return tmp;
        }
        public SquareMatrix GetLpU()
        {
            SquareMatrix tmp = new SquareMatrix();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if(i != j)
                        tmp[i, j] = -this[i, j];
            return tmp;
        }
    }
}
