using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_GUI_Sample
{
    class Rung_Kutta_Method : Numerical_Method
    {
        public Rung_Kutta_Method(double x0, double x1, double y0, int n) : base(x0, x1, y0, n)
        {
        }

        protected override double computingFunction(int i, double h)
        {
            return (TheButcherSchema.K1RKM(x[i - 1], y[i - 1], h) + 2 * TheButcherSchema.K2RKM(x[i - 1], y[i - 1], h) +
                    2 * TheButcherSchema.K3RKM(x[i - 1], y[i - 1], h) + TheButcherSchema.K4RKM(x[i - 1], y[i - 1], h)) / 6;
        }
    }
}
