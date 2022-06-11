using System;
using System.Collections.Generic;
using System.Text;

namespace NewtonMD
{
    class NewtonsMethod
    {
        public static Vector FindRoot(FunctionVector F, FunctionMatrix J, Vector init)
        {
            Vector xn = init;
            Vector xnp1 = new Vector();
            Vector vn = new Vector();
            SquareMatrix Jd;
            Vector b;
            int numiters = 0;
            while(true)
            {
                Jd = J.Evaluate(xn);
                b = -F.Evaluate(xn);
                vn = LinearSolve.LinSolve(Jd, b);
                xnp1 = xn + vn;
                //check end condition
                if(((xnp1-xn).Norm())/xn.Norm() < 0.000001)
                {
                    break;
                }
                if(numiters > 10000)
                {
                    Console.WriteLine("Failed to converge");
                    break;
                }
                xn = xnp1;
                numiters++;
            }
            return xnp1;
        }
    }
}
