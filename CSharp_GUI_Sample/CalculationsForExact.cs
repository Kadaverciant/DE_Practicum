using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_GUI_Sample
{
    public static class CalculationsForExact
    {
        public static double Get_Point_Of_Discontinuty(double x0, double y0)
        {
            double c = (1 - y0) / (x0 * y0);
            return -1 / c;
        }
        public static double Get_Constant(double x0, double y0)
        {
            double c = (1 - y0) / (x0 * y0);
            return c;
        }
        public static double Get_Value_At_Point(double x0, double y0, double x)
        {
            double c = Get_Constant(x0, y0);
            return 1 / (x * c + 1);
        }
    }
}
