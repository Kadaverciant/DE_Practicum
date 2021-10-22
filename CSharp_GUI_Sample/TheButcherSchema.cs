using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_GUI_Sample
{
    public static class TheButcherSchema
    {
        private static double derivative_function(double x, double y)
        {
            return (y * y - y) / x;
        }
        public static double K1EM(double x, double y, double h)
        {
            return h*derivative_function(x,y);
        }
        public static double K2EM(double x, double y, double h)
        {
            return h * derivative_function(x+h, y+K1EM(x,y,h));
        }
        public static double K1RKM(double x, double y, double h)
        {
            return K1EM(x,y,h);
        }
        public static double K2RKM(double x, double y, double h)
        {
            return h * derivative_function(x + h/2, y + K1RKM(x, y, h)/2);
        }
        public static double K3RKM(double x, double y, double h)
        {
            return h * derivative_function(x + h/2, y + K2RKM(x, y, h)/2);
        }
        public static double K4RKM(double x, double y, double h)
        {
            return h * derivative_function(x + h, y + K3RKM(x, y, h));
        }
    }
    
}
