using System;
using System.Windows;


namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiMinFun.MinFunGradientDescent(-0.1, -2.8);
            MultiMinFun.MinFunGradientFraction(-0.3, -2.8);
            Console.ReadKey();
        }
    }
}