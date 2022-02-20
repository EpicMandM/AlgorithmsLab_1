using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsLab_1
{
    class Differential
    {
        internal static double f(double[] x1, double[] y1, double x)
        {
            return Lagrange.InterpolatePiece2(x1, y1, x, 3);
        }
        public static double GetFirstDiff(double[] x1, double[] y1, double x)
        {
            double h = 0.0001;
            return (f(x1,y1,x + h) - f(x1,y1,x - h)) / (2 * h);
        }
        public static void GetOutPutDiff(double[] x1, double[] y1, double x)
        {
            Console.WriteLine($"X:{x}; DF2: {GetSecondDiff(x1, y1, x)}, D2: {-Math.Exp(Math.Sin(x)) * Math.Sin(x) + Math.Exp(Math.Sin(x) * Math.Pow(Math.Cos(x), 2))}");
        }
        public static double[] GetFirstDiff(double[] x1, double[] y1, double[] x2)
        {
            List<double> list = new List<double>();
            for (int i = 0; i < x2.Length; i++)
            {
                list.Add(GetFirstDiff(x1, y1, x2[i]));
            }
            return list.ToArray();

        }
        //TODO: Доделать GetSecondDiff(оба)
        public static double GetSecondDiff(double[] x1, double[] y1, double x)
        {
            double h = 0.0001;
            return (f(x1,y1,x + h) - 2 * f(x1, y1, x) + f(x1,y1,x - h)) / Math.Pow(h,2);
        }
        public static double[] GetSecondDiff(double[] x1, double[] y1, double[] x2)
        {
            List<double> list = new List<double>();
            for (int i = 0; i < x2.Length; i++)
            {
                list.Add(GetSecondDiff(x1, y1, x2[i]));
            }
            return list.ToArray();

        }
    }
}
