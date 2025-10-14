using Microsoft.VisualStudio.TestTools.UnitTesting;
using Comedor.Marisco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comedor.Marisco.Tests    
{
    [TestClass()]
    public class ComedorTests
    {
        [TestMethod()]
        public void AddTest()
        {
            Comedor comedor = new Comedor();
            double result = comedor.Add(5, 3);
            Assert.AreEqual(8, result);
        }

        [TestMethod()]
        public void subtractTest()
        {
            Comedor comedor = new Comedor();
            double result = comedor.subtract(5, 3);
            Assert.AreEqual(2, result);
        }

        [TestMethod()]
        public void multiplyTest()
        {
            Comedor comedor = new Comedor();
            double result = comedor.multiply(5, 3);
            Assert.AreEqual(15, result);
        }

        [TestMethod()]
        public void divideTest()
        {
            Comedor comedor = new Comedor();
            double result = comedor.divide(6, 2);
            Assert.AreEqual(3, result);
        }

        [TestMethod()]

        [ExpectedException(typeof(ArgumentException))]

        public void DivideByZeroTest()
        {
            Comedor comedor = new Comedor();
            double result = comedor.divide(5, 0);
        }

    }
}