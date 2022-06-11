using System;
using MathNet.Numerics.LinearAlgebra.Double;

namespace NewtonMD
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //nonlinear functions
            FunctionVector F = new FunctionVector();
            F[0] = x => x[0] * x[0] * x[0] - 2 * x[1] - 2;
            F[1] = x => x[0] * x[0] * x[0] - 5 * x[2] * x[2] + 7;
            F[2] = x => x[1] * x[2] * x[2] - 1;
            //jacobian
            FunctionMatrix J = new FunctionMatrix();
            J[0, 0] = x => 3 * x[0] *x[0];
            J[0, 1] = x => -2;
            J[0, 2] = x => 0;
            J[1, 0] = x => 3 * x[0] * x[0];
            J[1, 1] = x => 0;
            J[1, 2] = x => -10 * x[2];
            J[2, 0] = x=> 0;
            J[2, 1] = x => x[2] * x[2];
            J[2,2] = x=> 2 *x[1] * x[2];
            //intial guess
            Vector v = new Vector(new double [] { 1.4, -1, 1.4 });
            //call the solver
            Vector res = NewtonsMethod.FindRoot(F, J, v);
            Console.WriteLine("Result is ({0}, {1}, {2})", res[0], res[1], res[2]);
            Console.ReadKey();
        }
    }
}
