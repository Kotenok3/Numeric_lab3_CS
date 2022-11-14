using static System.Math;

namespace lab3
{
    public static class Fun
    {
        public static double A(double [] p)  => 3 * p[0] + 2.2 * p[1] + Exp(1.16 * p[0] * p[0] + 0.14 * p[1] * p[1]);   
        
        public static double Ax
        {
            get => -0.42100280;
        }
        
        public static double Ay
        {
            get => -2.55847255;
        }

        public static double B(double[] p) => 25 * Sin(0.4 * p[0] + 1.6 * p[1]) * Cos(0.7 * p[0] + 1.2 * p[1]);   
        
        public static double Bx
        {
            get => -0.42100280;
        }
        
        public static double By
        {
            get => -2.55847255;
        }

    }
}