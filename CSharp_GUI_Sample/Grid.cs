using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_GUI_Sample
{
    public class Grid
    {
        public double[] x;
        public double[] y;
        public int N;
        public double h;
        public Vector<double> tryX;
        public Grid(double x0, double x1, int n)
        {
            N = n;
            h = (x1 - x0) / n;

            x = new double[N + 1];
            y = new double[N + 1];
            for (int i = 0; i < N + 1; i++)
            {
                if (i == 0)
                    x[i] = x0;
                else
                    x[i] = x[i - 1] + h;
            }
            
        }
    }
}
