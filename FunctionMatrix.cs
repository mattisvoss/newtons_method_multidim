using System;
using System.Collections.Generic;
using System.Text;

namespace NewtonMD
{
    public delegate double func(Vector v);
    class FunctionMatrix
    {
        private func [,] functions = null;
        public FunctionMatrix()
        {
            functions = new func[3, 3];
        }
        public func this[int row, int col]
        {
            get {return functions[row, col]; }
            set {functions[row,col] = value; }
        }
        public SquareMatrix Evaluate(Vector v)
        {
            SquareMatrix tmp = new SquareMatrix();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    tmp[i, j] = functions[i, j](v);
            return tmp;
        }
    }

    class FunctionVector
    {
        private func[] functions = null;
        public FunctionVector()
        {
            functions = new func[3];
        }
        public func this[int index]
        {
            get { return functions[index]; }
            set { functions[index] = value; }
        }
        public Vector Evaluate(Vector v)
        {
            Vector tmp = new Vector();
            for (int i = 0; i < 3; i++)               
                    tmp[i] = functions[i](v);
            return tmp;
        }
    }
}
