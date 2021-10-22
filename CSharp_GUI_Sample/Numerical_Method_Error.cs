using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_GUI_Sample
{
    class Numerical_Method_Error : Grid
    {
        public double maxError;

        public Numerical_Method_Error(double x0, double x1, int n, Exact_Solution es, Numerical_Method method) : base(x0, x1, n)
        {
            maxError = 0;
            for (int i = 0; i <= y.Length-1; i++)
            {
                y[i] = Math.Abs(es.y[i] - method.y[i]);
                if (y[i] > maxError)
                    maxError = y[i];
            }
        }
    }
}

