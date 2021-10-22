using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_GUI_Sample
{
     public abstract class Numerical_Method : Grid
     {
        protected abstract double computingFunction(int i, double h);
        protected Numerical_Method(double x0, double x1, double y0, int n) : base(x0, x1, n)
        {
            y[0] = y0;
            for (int i = 1; i <= y.Length-1; i++)
            {
                y[i] = y[i - 1] + computingFunction(i,h);
            }
        }
     }
}
