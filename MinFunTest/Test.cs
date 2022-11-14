using System;
using lab3;
using NUnit.Framework;

namespace MinFunTest
{
    [TestFixture]
    public class MultiMinFunDescentTest
    {
        public void functionA()
        {
            
        }
        
        
        public void Simple(Func<double[], double> fun, double x, double y, double x0, double y0, double param)
        {
            var p = MultiMinFun.GradientDescent(fun,x0, y0,0.0001,param,true);
            Assert.AreEqual(p[0], x, 1e-3);
            Assert.AreEqual(p[1], y, 1e-3);
        }

        [Test]
        public void AllValue()
        {
            for (double x0 = -0.8; x0 < 0; x0 += 0.01)
            {
                for (double y0 = -3.5; y0 < -1.5; y0 += 0.01)
                {
                    var p = MultiMinFun.GradientDescent(x0, y0,0.0001,true);
                    Assert.AreEqual(p[0], MultiMinFun.X, 1e-3);
                    Assert.AreEqual(p[1], MultiMinFun.Y, 1e-3);
                }
            }
        }
    }
    
    [TestFixture]
    public class MultiMinFunFractionTest
    {
        [Test]
        public void Simple()
        {
            var p = MultiMinFun.GradientFraction(-0.3, -2.8,0.0001,true);
            Assert.AreEqual(p[0], MultiMinFun.X, 1e-3);
            Assert.AreEqual(p[1], MultiMinFun.Y, 1e-3);
        }

        [Test]
        public void Midle()
        {
            var p = MultiMinFun.GradientFraction(-0.5, -1.8,0.0001,true);
            Assert.AreEqual(p[0], MultiMinFun.X, 1e-3);
            Assert.AreEqual(p[1], MultiMinFun.Y, 1e-3);
        }

        [Test]
        public void AllValue()
        {
            for (double x0 = -0.5; x0 < -0.1; x0 += 0.01)
            {
                for (double y0 = -2.9; y0 < -2; y0 += 0.01)
                {
                    var p = MultiMinFun.GradientFraction(x0, y0,0.0001,true);
                    Assert.AreEqual(p[0], MultiMinFun.X, 1e-4);
                    Assert.AreEqual(p[1], MultiMinFun.Y, 1e-4);
                }
            }
        }
    }

    [TestFixture]
    public class MultiMinFunConjugateTest
    {
        [Test]
        public void Simple()
        {
            var p = MultiMinFun.ConjugateGradient(-0.3, -2.8, 0.0001, true);
            Assert.AreEqual(p[0], MultiMinFun.X, 1e-3);
            Assert.AreEqual(p[1], MultiMinFun.Y, 1e-3);
        }

        [Test]
        public void Midle()
        {
            var p = MultiMinFun.ConjugateGradient(-0.3, -2.8, 0.0001, true);
            Assert.AreEqual(p[0], MultiMinFun.X, 1e-3);
            Assert.AreEqual(p[1], MultiMinFun.Y, 1e-3);
        }

        [Test]
        public void AllValue()
        {
            for (double x0 = -0.8; x0 < 0; x0 += 0.01)
            {
                for (double y0 = -3.5; y0 < -1.5; y0 += 0.01)
                {
                    var p = MultiMinFun.ConjugateGradient(x0, y0, 0.0001, true);
                    Assert.AreEqual(p[0], MultiMinFun.X, 1e-3);
                    Assert.AreEqual(p[1], MultiMinFun.Y, 1e-3);
                }
            }
        }
    }
}
