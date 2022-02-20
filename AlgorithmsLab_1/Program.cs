using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsLab_1
{
    class Program
    {
        static void Task2()
        {
            var input = GetInput();
            if(input.HasValue)
                Console.WriteLine($"Answer: {Lagrange.InterpolatePiece2(input.Value.Item1.Keys.ToArray(), input.Value.Item1.Values.ToArray(), input.Value.Item2, 3)}");
        }
        // TODO: 2(B)
        static void Print(double[] x1, double[] y1, double[] y2)
        {
            Console.WriteLine("|-------|-------|-------|-------|");
            Console.WriteLine("|   i   |   x   |  y_f  |  y_i  |");
            Console.WriteLine("|-------|-------|-------|-------|");
            for (long i = 0; i < x1.LongLength; i++)
            {
                Console.Write("|");
                Console.Write("{0,-7:F2}|", i);
                Console.Write(x1[i] < 0 ? "{0,-7:F2}|" : " {0,-6:F2}|", x1[i]);
                Console.Write(y1[i] < 0 ? "{0,-7:F2}|" : " {0,-6:F2}|", y1[i]);
                Console.Write(y2[i] < 0 ? "{0,-7:F2}|" : " {0,-6:F2}|", y2[i]);
                Console.WriteLine();
            }
            Console.WriteLine("|-------|-------|-------|-------|");
        }
        static void Initialize(int count, out double[] x1, out double[] y1)
        {
            x1 = new double[count];
            y1 = new double[count];
            using (StreamReader sr = new StreamReader(@"./input.txt", System.Text.Encoding.Default))
            {
                x1 = sr.ReadLine().Split(' ').Select(x => double.Parse(x)).ToArray();
                y1 = sr.ReadLine().Split(' ').Select(x => double.Parse(x)).ToArray();
            }
        }
        static void GetXData(out double[] x2)
        {
            List<double> container = new List<double>();
            for (double i = 1; i < 8.9; i = i + 0.1)
            {
                container.Add(i);
            }
            x2 = container.ToArray();
        }
        static (Dictionary<double, double>, double)? GetInput()
        {
            Dictionary<double, double> keyValuePairs = new Dictionary<double, double>();
            while (true)
            {
                Console.WriteLine("Enter pair x,y (q to end): ");
                string value = Console.ReadLine();
                if (value == string.Empty || value == " " || value == "\n")
                    return null;
                if (value == "q")
                {
                    Console.WriteLine("Enter X*: ");
                    return (keyValuePairs, double.Parse(Console.ReadLine()));
                }
                else
                {
                    keyValuePairs.Add(double.Parse(value.Split(' ')[0]), double.Parse(value.Split(' ')[1]));
                }
            }
        }
        static void Main(string[] args)
        {
            int count = 9; // количество входящих пар OX/OY
            Initialize(count, out double[] x1, out double[] y1);
            GetXData(out double[] x2);
            GetFormula(x2, out double[] y2);
            double[] y_i = Lagrange.InterpolateGlobal(x1, y1, x2);
            Console.WriteLine("Global Lagrange interpolation\n");
            Print(x2, y2, y_i); // Task 2 A
            // ------------------------------------/--------------------------
            // --------------------------------------------------------------
            //var input = GetInput();
            Task2(); // Task 2 B
            Console.WriteLine($"Check: {Lagrange.InterpolatePiece2(x1, y1, 3.5, 3)}");
            Console.WriteLine($"Check: {Lagrange.InterpolatePiece2(x1, y1, 3.51, 3)}");
            Console.WriteLine($"Check: {Lagrange.InterpolatePiece2(x1, y1, 3.49, 3)}");


            GetFormulaDiffFirst(x2, out y2); // Task 3
            Differential.GetOutPutDiff(x1, y1, 4.3);

            y_i = Differential.GetFirstDiff(x1,y1, x2);
            Console.WriteLine("Diff 1-st grade\n");
            Print(x2, y2, y_i);
            // --------------------------------------------------------------
            GetFormulaDiffSecond(x2, out y2);
            y_i = Differential.GetSecondDiff(x1, y1, x2);
            Console.WriteLine("Diff 2-nd grade\n");
            Print(x2, y2, y_i);

            Console.ReadLine();
        }

        private static void GetFormulaDiffFirst(double[] x2, out double[] y2)
        {
            y2 = new double[x2.Length];
            List<double> list = new List<double>();
            for (int i = 0; i < x2.Length; i++)
            {
                list.Add(Math.Exp(Math.Sin(x2[i])) * Math.Cos(x2[i])); // e^sin(x) * cos(x)
            }
            y2 = list.ToArray();
        }
        private static void GetFormulaDiffSecond(double[] x2, out double[] y2)
        {
            y2 = new double[x2.Length];
            List<double> list = new List<double>();
            for (int i = 0; i < x2.Length; i++)
            {
                list.Add((-Math.Sin(x2[i]) + Math.Pow(Math.Cos(x2[i]), 2)) * Math.Exp(Math.Sin(x2[i]))); // -e^sin(x) * sin(x) + e^sin(x)*cos(x)^2
            }
            y2 = list.ToArray();
        }

        private static void GetFormula(double[] x2, out double[] y2)
        {
            List<double> list = new List<double>();
            for (int i = 0; i < x2.Length; i++)
            {
                list.Add(Math.Exp(Math.Sin(x2[i])));
            }
            y2 = list.ToArray();
        }
    }
}
