using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics.LinearAlgebra.Double;

namespace NewtonMD
{
    class LinearSolve
    {
        public static Vector LinSolve(SquareMatrix A, Vector b)
        {
            DenseMatrix ad = A;
            DenseVector bd = b;            
            DenseVector resultX = (DenseVector)ad.LU().Solve(bd);
            return resultX;
        }
    }
}
