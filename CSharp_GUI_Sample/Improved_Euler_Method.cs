using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_GUI_Sample
{
    public class Improved_Euler_Method : Numerical_Method
    { 
        public Improved_Euler_Method(double x0, double x1, double y0, int n) : base(x0, x1, y0, n)
        {
        }

        protected override double computingFunction(int i, double h)
        {
            return (TheButcherSchema.K1EM(x[i - 1], y[i - 1], h) + TheButcherSchema.K2EM(x[i - 1], y[i - 1], h)) / 2;
        }
    }
}
