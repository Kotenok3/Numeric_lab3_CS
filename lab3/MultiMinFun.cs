﻿using System;
using Accord.Math.Differentiation;

namespace lab3
{
    static public class MultiMinFun
    {
        public static double X
        {
            get => -0.42100280;
        }
        
        public static double Y
        {
            get => -2.55847255;
        }
        
        
        static double Fun(params double [] p)  => 3 * p[0] + 2.2 * p[1] + Math.Exp(1.16 * p[0] * p[0] + 0.14 * p[1] * p[1]);
        
        static double Gfun(double a,double b) =>Fun(a, b);
        static double SetA(double a) => a/5;
        static double SetA(Func<double, double> g) => Dichotomy(g, 0, 10);
        
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
        
        public static (double x, double y) MinFunGradientFraction(double x0, double y0, double esp = 0.0001, bool test = false)
        {
            double x = x0, y = y0, alfa = 0.25, xk = x0, yk = y0;
            int counter = 0;
            var grad = FiniteDifferences.Gradient(Fun, 2);
            var gr = grad(new []{x,y});
            while (Norm(gr) > esp)
            {
                x = xk - alfa * gr[0];
                y = yk - alfa * gr[1];

                if (Fun(x, y) > Fun(xk, yk))
                    alfa = SetA(alfa);
                gr = grad(new []{x,y});
                xk = x;
                yk = y;
                counter++;
            }

            if (!test)
                Console.WriteLine($"x={x},y={y} value Fun {Fun(x, y)} norm {Norm(gr)}. counter = {counter}");
            else
                Console.WriteLine($"(x0,y0)=({x0:F6},{y0:F6})  x={x:F6},y={y:F6}  counter = {counter}");
            return (x, y);

        }
        
        
        public static (double x, double y) MinFunGradientDescent(double x0, double y0, double esp = 0.0001, bool test = false)
        {
            double x = x0, y = y0, alfa;
            int counter = 0;
            var grad = FiniteDifferences.Gradient(Fun, 2);
            var gr = grad(new []{x,y});
            while (Norm(gr) > esp)
            {
                Func<double, double> g = a => Fun(x - a * gr[0], y - a * gr[1]);
                alfa = SetA(g);
                
                x = x - alfa * gr[0];
                y = y - alfa * gr[1];

                gr = grad(new []{x,y});
                counter++;
            }

            if (!test)
                Console.WriteLine($"x={x},y={y} value Fun {Fun(x, y)} norm {Norm(gr)}. counter = {counter}");
            else
                Console.WriteLine($"(x0,y0)=({x0:F6},{y0:F6})  x={x:F6},y={y:F6}  counter = {counter}");
            return (x, y);

        }
    }
}