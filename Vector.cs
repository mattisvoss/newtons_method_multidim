using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics.LinearAlgebra.Double;

namespace NewtonMD
{
    public class Vector
    {
        private double[] data = new double[3];
        public int Size { get { return data.Length; } }

        public Vector()
        {
            for (int i = 0; i < 3; i++)
                data[i] = 0;
        }

        public Vector(double[] vals)
        {
            for (int i = 0; i < 3; i++)
                data[i] = vals[i];
        }

        public Vector(Vector vals)
        {
            for (int i = 0; i < 3; i++)
                data[i] = vals[i];
        }

        public double this[int index]
        {
            get{
                return data[index];
            }
            set{
                data[index] = value;
            }
        }

        public static Vector operator+(Vector left, Vector right)
        {
            Vector tmp = new Vector();
            for (int i = 0; i < 3; i++)
                tmp[i] = left[i] + right[i];
            return tmp;
        }

        public static Vector operator -(Vector left, Vector right)
        {
            Vector tmp = new Vector();
            for (int i = 0; i < 3; i++)
                tmp[i] = left[i] - right[i];
            return tmp;
        }

        public static Vector operator -(Vector val)
        {
            Vector tmp = new Vector();
            for (int i = 0; i < 3; i++)
                tmp[i] = - val[i];
            return tmp;
        }
        //conversion operators
        public static implicit operator DenseVector(Vector v)
        {
            DenseVector tmp = new DenseVector(3);
            for (int i = 0; i < 3; i++)
                tmp[i] = v[i];
            return tmp;
        }

        public static implicit operator Vector(DenseVector v)
        {
            Vector tmp = new Vector();
            for (int i = 0; i < 3; i++)
                tmp[i] = v[i];
            return tmp;
        }
        public double Norm()
        {
            double tmp = 0;
            for (int i = 0; i < 3; i++)
                tmp += data[i] * data[i];
            return Math.Sqrt(tmp);
        }
    }
}
