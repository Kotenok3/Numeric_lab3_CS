using System;
using System.Windows;


namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiMinFun.GradientDescent(Fun.A,-0.1, -2.8,1e-6);
            MultiMinFun.GradientFraction(Fun.A,-0.3, -2.8,1e-6);
            MultiMinFun.ConjugateGradient(Fun.A,-0.3, -2.8,1e-6);
            MultiMinFun.GradientDescent(Fun.B, -0.3, -2.8);
            Console.ReadKey();
        }
    }
}