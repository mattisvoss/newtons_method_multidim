using System;
using System.Collections.Generic;
using System.Text;

namespace NewtonMD
{
    class GaussJacobi
    {
        public Vector Solve(SquareMatrix A, Vector b)
        {
            Vector solnp1 = new Vector();
            Vector soln = new Vector();
            SquareMatrix Dinv = A.GetInvD();
            SquareMatrix LpU = A.GetLpU();
            do
            {
                solnp1 = Dinv * (LpU * soln) + Dinv * b;
                if (((solnp1 - soln).Norm()) / (soln.Norm()) < 0.00001)
                    break;
                soln = solnp1;
            } while (true);
            return solnp1;
        }
    }
}
