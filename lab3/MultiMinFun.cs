using System;
using Accord.Math.Differentiation;

namespace lab3
{
    static public class MultiMinFun
    {
        static double[] GradP(double[] p, double[] p1, double b)
        {
            var result = new double[p.Length];

            for (int i = 0; i < p.Length; i++)
                result[i] = p[i] - p1[i] * b;

            return result;
        }
        
        static double  Dichotomy(Func<double, double> fun, double a, double b,double esp = 0.001, double delta = 0.001) {
            double x1, x2;

            while ((b - a) > 2 * esp) {
                x1 = (a + b - delta) / 2;
                x2 = (a + b + delta) / 2;

                if (fun(x1) <= fun(x2))
                    b = x2;
                else
                    a = x1;
            }

            return (a + b) / 2;
        }
        
        static double Norm(double[] G)
        {
            double sum = 0;
            foreach (var g in G)
            {
                sum += g*g;
            }

            return Math.Sqrt(sum);
        }

        public static double[] GradientFraction(Func<double[], double> fun,double x0, double y0, double esp = 0.0001,double param = 10, bool test = false)
        {
            double x = x0, y = y0, alfa = 0.25, xk = x0, yk = y0;
            int counter = 0;
            Func<double[], double[]> grad = FiniteDifferences.Gradient(fun, 2);
            var gr = grad(new []{x,y});
            while (Norm(gr) > esp)
            {
                y = yk - alfa * gr[1];
                x = xk - alfa * gr[0];

                if (fun(new []{x, y}) >= fun(new [] { xk, yk }))
                {
                    alfa /= 2;
                }
                else
                {
                    xk = x;
                    yk = y;
                }
                
                gr = grad(new []{x,y});
                counter++;
            }

            if (!test)
            {
                Console.WriteLine($"x={x},y={y} value Fun {fun(new []{x, y})}. counter = {counter}");
                return new[] { x0, y0, counter };
            }
            else
            {
                Console.WriteLine(
                    $"(x0,y0)=({x0:F6},{y0:F6})  x={x:F6},y={y:F6}  counter = {counter} g={(500 - counter) / 498.0 * 255}");
                return new[] { x, y, counter };
            }

        }

        public static double[] ConjugateGradient(Func<double[], double> fun, double x0, double y0, double esp = 0.0001, double parametr = 10, bool test = false)
        {
            double x = x0, y = y0, alfa = 0.25, xk = x0, yk = y0;
            int counter = 0;
            Func<double[], double[]> grad = FiniteDifferences.Gradient(fun, 2);
            var p = grad(new[] { x, y });
            double[] p1;
            while (true)
            {

                Func<double, double> g = a => fun(new [] { x - a * p[0], y - a * p[1] });
                alfa = Dichotomy(g, 0, parametr);

                x = x - alfa * p[0];
                y = y - alfa * p[1];

                if (Norm(p) < esp) break;

                p1 = p;
                p = grad(new[] { x, y });

                if (counter % 2 == 1)
                {
                    p = GradP(p, p1, (-Norm(p) / Norm(p1)));
                }

                counter++;
            }

            if (!test)
            {
                Console.WriteLine($"x={x},y={y} value Fun {fun(new []{x, y})}. counter = {counter}");
                return new[] { x0, y0, counter };
            }
            else
            {
                Console.WriteLine(
                    $"(x0,y0)=({x0:F6},{y0:F6})  x={x:F6},y={y:F6}  counter = {counter} g={(500 - counter) / 498.0 * 255}");
                return new[] { x, y, counter };
            }

        }

        public static double[] GradientDescent(Func<double[], double> fun, double x0, double y0, double esp = 0.0001,double parametr = 10, bool test = false)
        {
            double x = x0, y = y0, alfa;
            int counter = 0;
            Func<double[], double[]> grad = FiniteDifferences.Gradient(fun, 2);
            var gr = grad(new []{x,y});
            while (Norm(gr) > esp)
            {
                Func<double, double> g = a => fun(new[] { x - a * gr[0], y - a * gr[1] });
                alfa = Dichotomy(g, 0, parametr);
                
                x = x - alfa * gr[0];
                y = y - alfa * gr[1];

                gr = grad(new []{x,y});
                counter++;
            }

            if (!test)
            {
                Console.WriteLine($"x={x},y={y} value Fun {fun(new []{x, y})} norm {Norm(gr)}. counter = {counter}");
                return new[] { x0, y0, counter };
            }
            else
            {
                Console.WriteLine(
                    $"(x0,y0)=({x0:F6},{y0:F6})  x={x:F6},y={y:F6}  counter = {counter} g={(500 - counter) / 498.0 * 255}");
                return new[] { x, y, counter };
            }

        }
    }
}