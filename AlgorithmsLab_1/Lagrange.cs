using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsLab_1
{
    class Lagrange
    {
        public static double InterpolateGlobal (double[] x, double[] y, double xval)
        {
            double yval = 0.0;
            double products = y[0];
            for (int i = 0; i < x.Length; i++)
            {
                products = y[i];
                for (int j = 0; j < x.Length; j++)
                {
                    if (i != j)
                    {
                        products *= (xval - x[j]) / (x[i] - x[j]);
                    }
                }
                yval += products;               
            }
            return yval;
        }
        public static double[] InterpolateGlobal(double[] x, double[] y, double[] xvals)
        {
            double[] yvals = new double[xvals.Length];
            for (int i = 0; i < xvals.Length; i++)
                yvals[i] = InterpolateGlobal(x, y, xvals[i]);
            return yvals;
        }
        //public static double InterpolatePiece(double[] x, double[] y, double xval, int degree)
        //{
        //    if(x.Length % (degree + 1) == 0)
        //    {
        //        for (int i = 0; i < x.Length / (degree + 1); i++)
        //        {
        //            var arrayx = new double[degree + 1];
        //            var arrayy = new double[degree + 1];
        //            Array.Copy(x, i*degree, arrayx, 0, degree + 1);
        //            Array.Copy(y, i*degree, arrayy, 0, degree + 1);
        //            if (arrayx.Min() <= xval && xval <= arrayx.Max())
        //            {
        //                return InterpolateGlobal(arrayx, arrayy, xval);
        //            }
        //            else
        //            {
        //                continue;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < x.Length / (degree + 1); i++)
        //        {
        //            var arrayx = new double[degree + 1];
        //            var arrayy = new double[degree + 1];
        //            Array.Copy(x, i * degree, arrayx, 0, degree + 1);
        //            Array.Copy(y, i * degree, arrayy, 0, degree + 1);
        //            if (arrayx.Min() <= xval && xval <= arrayx.Max())
        //            {
        //                return InterpolateGlobal(arrayx, arrayy, xval);
        //            }
        //            else
        //            {
        //                continue;
        //            }
        //        }
        //        double[] arrayx2 = new double[x.Length % (degree + 1)] ;
        //        double[] arrayy2 = new double[x.Length % (degree + 1)];
        //        Array.Copy(x, x.Length - x.Length % (degree + 1), arrayx2, 0, x.Length % (degree + 1));
        //        Array.Copy(y, y.Length - x.Length % (degree + 1), arrayy2, 0, x.Length % (degree + 1));
        //        if (arrayx2.Min() <= xval && xval <= arrayx2.Max())
        //        {
        //            return InterpolateGlobal(arrayx2, arrayy2, xval);
        //        }
        //        else
        //        {
        //            new Exception("Critical ERROR!");
        //            return 0;
        //        }
        //    }
        //    new Exception("Critical EROOR");
        //    return 0;
        //}
        public static double InterpolatePiece2(double[] x, double[] y, double xval, int degree)
        {
            double[] arrayx = new double[degree + 1];
            double[] arrayy = new double[degree + 1];
            int flag = 0;
            for (int i = 0; i < (x.Length - 1) / degree; i++)
            {
                Array.Copy(x, i * degree, arrayx, 0, degree + 1);
                Array.Copy(y, i * degree, arrayy, 0, degree + 1);
                flag = i;
                if (arrayx.Min() <= xval && xval <= arrayx.Max())
                {
                    return InterpolateGlobal(arrayx, arrayy, xval);
                }
            }
            if ((x.Length - 1)/degree != 0)
            {
                Array.Copy(x, flag * degree + degree, arrayx, 0, x.Length - (flag * degree + degree + 1));
                Array.Copy(y, flag * degree + degree, arrayy, 0, x.Length - (flag * degree + degree + 1));
                if (arrayx.Min() <= xval && xval <= arrayx.Max())
                {
                    return InterpolateGlobal(arrayx, arrayy, xval);
                }
                else
                {
                    throw new Exception("****CRITICAL ERROR****");
                }
            }
            throw new Exception("****CRITICAL ERROR****");
        }
    }

}
