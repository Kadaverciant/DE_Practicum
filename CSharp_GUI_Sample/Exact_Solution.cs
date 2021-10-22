using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_GUI_Sample
{
    class Exact_Solution : Grid
    {
        public Exact_Solution(double x0, double x1, double y0, int n, double c) : base(x0, x1, n )
        {
            for (int i = 0; i <= y.Length-1; i++)
            {
                y[i] = 1 / (x[i] * c + 1);
            }
        }
    }
}
