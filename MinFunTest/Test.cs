using lab3;
using NUnit.Framework;

namespace MinFunTest
{
    [TestFixture]
    public class MultiMinFunDescentTest
    {
        [Test]
        public void Simple()
        {
            var (x, y) = MultiMinFun.MinFunGradientDescent(-0.3, -2.8,0.0001,true);
            Assert.AreEqual(x, MultiMinFun.X, 1e-3);
            Assert.AreEqual(y, MultiMinFun.Y, 1e-3);
        }

        [Test]
        public void Midle()
        {
            var (x, y) = MultiMinFun.MinFunGradientDescent(-0.5, -1.8,0.0001,true);
            Assert.AreEqual(x, MultiMinFun.X, 1e-3);
            Assert.AreEqual(y, MultiMinFun.Y, 1e-3);
        }

        [Test]
        public void AllValue()
        {
            for (double x0 = -0.8; x0 < 0; x0 += 0.01)
            {
                for (double y0 = -3.5; y0 < -1.5; y0 += 0.01)
                {
                    var (x, y) = MultiMinFun.MinFunGradientDescent(x0, y0,0.0001,true);
                    Assert.AreEqual(x, MultiMinFun.X, 1e-4);
                    Assert.AreEqual(y, MultiMinFun.Y, 1e-4);
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
            var (x, y) = MultiMinFun.MinFunGradientFraction(-0.3, -2.8,0.0001,true);
            Assert.AreEqual(x, MultiMinFun.X, 1e-3);
            Assert.AreEqual(y, MultiMinFun.Y, 1e-3);
        }

        [Test]
        public void Midle()
        {
            var (x, y) = MultiMinFun.MinFunGradientFraction(-0.5, -1.8,0.0001,true);
            Assert.AreEqual(x, MultiMinFun.X, 1e-3);
            Assert.AreEqual(y, MultiMinFun.Y, 1e-3);
        }

        [Test]
        public void AllValue()
        {
            for (double x0 = -0.5; x0 < -0.1; x0 += 0.01)
            {
                for (double y0 = -2.9; y0 < -2; y0 += 0.01)
                {
                    var (x, y) = MultiMinFun.MinFunGradientFraction(x0, y0,0.0001,true);
                    Assert.AreEqual(x, MultiMinFun.X, 1e-4);
                    Assert.AreEqual(y, MultiMinFun.Y, 1e-4);
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
            var (x, y) = MultiMinFun.MinFunConjugateGradient(-0.3, -2.8, 0.0001, true);
            Assert.AreEqual(x, MultiMinFun.X, 1e-3);
            Assert.AreEqual(y, MultiMinFun.Y, 1e-3);
        }

        [Test]
        public void Midle()
        {
            var (x, y) = MultiMinFun.MinFunConjugateGradient(-0.5, -1.8, 0.0001, true);
            Assert.AreEqual(x, MultiMinFun.X, 1e-3);
            Assert.AreEqual(y, MultiMinFun.Y, 1e-3);
        }

        [Test]
        public void AllValue()
        {
            for (double x0 = -0.8; x0 < 0; x0 += 0.01)
            {
                for (double y0 = -3.5; y0 < -1.5; y0 += 0.01)
                {
                    var (x, y) = MultiMinFun.MinFunConjugateGradient(x0, y0, 0.0001, true);
                    Assert.AreEqual(x, MultiMinFun.X, 1e-4);
                    Assert.AreEqual(y, MultiMinFun.Y, 1e-4);
                }
            }
        }
    }
}
