using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_GUI_Sample
{
    class Improved_Euler_Method_Max_Error : Grid
    {
        public Improved_Euler_Method_Max_Error(double x0, double x1, double y0, int n, int n_max) : base(n, n_max, n_max - n)
        {
            for (int k = 0; k <= n_max - n; k++)
            {
                y[k] = 0;

                double[] pointsOfDiscontinuty = new double[2];
                double pointOfDiscontinuty = CalculationsForExact.Get_Point_Of_Discontinuty(x0, y0);
                double esConst = CalculationsForExact.Get_Constant(x0, y0);
                if (0 < pointOfDiscontinuty)
                {
                    pointsOfDiscontinuty[0] = 0;
                    pointsOfDiscontinuty[1] = pointOfDiscontinuty;
                }
                else
                {
                    pointsOfDiscontinuty[0] = pointOfDiscontinuty;
                    pointsOfDiscontinuty[1] = 0;
                }

                Grid totalGrid = new Grid(x0, x1, n + k);
                int counter1 = 0;
                int counter2 = 0;
                int counter3 = 0;
                int i = 0;
                int size = totalGrid.x.Length;
                while (i < totalGrid.x.Length && totalGrid.x[i] <= pointsOfDiscontinuty[0] && totalGrid.x[i] <= totalGrid.x[size - 1])
                {
                    counter1++;
                    i++;
                }

                while (i < totalGrid.x.Length && totalGrid.x[i] <= pointsOfDiscontinuty[1] && totalGrid.x[i] <= totalGrid.x[size - 1])
                {
                    counter2++;
                    i++;
                }

                while (i < totalGrid.x.Length && totalGrid.x[i] <= totalGrid.x[size - 1])
                {
                    counter3++;
                    i++;
                }

                if (counter1 > 1)
                {
                    int range = counter1 - 1;
                    //int range = n;
                    Exact_Solution exact1 = new Exact_Solution(x0, totalGrid.x[counter1 - 1], y0, range, esConst);
                    Improved_Euler_Method iem1 = new Improved_Euler_Method(x0, totalGrid.x[counter1 - 1], y0, range);

                    Numerical_Method_Error ieme1 = new Numerical_Method_Error(x0, totalGrid.x[counter1 - 1], range, exact1, iem1);
                    y[k] = (new[] { ieme1.maxError, y[k] }).Max();
                }
                if (counter2 > 1)
                {
                    int beginIndex;
                    int endIndex;
                    int range;
                    if (counter1 > 0)
                    {
                        beginIndex = counter1 + 1;
                        endIndex = counter1 + counter2 - 1;
                        range = counter2 - 2;
                    }
                    else
                    {
                        beginIndex = counter1;
                        endIndex = counter1 + counter2 - 1;
                        range = counter2 - 1;
                    }
                    //range = n;

                    double y1 = CalculationsForExact.Get_Value_At_Point(x0, y0, totalGrid.x[beginIndex]);
                    Exact_Solution exact2 = new Exact_Solution(totalGrid.x[beginIndex], totalGrid.x[endIndex], y1, range, esConst);
                    Improved_Euler_Method iem2 = new Improved_Euler_Method(totalGrid.x[beginIndex], totalGrid.x[endIndex], y1, range);

                    Numerical_Method_Error ieme2 = new Numerical_Method_Error(totalGrid.x[beginIndex], totalGrid.x[endIndex], range, exact2, iem2);
                    y[k] = (new[] { ieme2.maxError, y[k] }).Max();
                }
                if (counter3 > 1)
                {
                    int beginIndex;
                    int endIndex;
                    int range;
                    if (counter2 > 0)
                    {
                        beginIndex = counter1 + counter2 + 1;
                        endIndex = counter1 + counter2 + counter3 - 1;
                        range = counter3 - 2;
                    }
                    else
                    {
                        beginIndex = counter1 + counter2;
                        endIndex = counter1 + counter2 + counter3 - 1;
                        range = counter3 - 1;
                    }
                    //range = n;

                    double y1 = CalculationsForExact.Get_Value_At_Point(x0, y0, totalGrid.x[beginIndex]);
                    Exact_Solution exact3 = new Exact_Solution(totalGrid.x[beginIndex], totalGrid.x[endIndex], y1, range, esConst);
                    Improved_Euler_Method iem3 = new Improved_Euler_Method(totalGrid.x[beginIndex], totalGrid.x[endIndex], y1, range);

                    Numerical_Method_Error ieme3 = new Numerical_Method_Error(totalGrid.x[beginIndex], totalGrid.x[endIndex], range, exact3, iem3);
                    y[k] = (new[] { ieme3.maxError, y[k] }).Max();
                }
                if (y[k] > 100)
                {
                    y[k] = 500;
                }
            }

        }
    }
}
