using System;
using NUnit.Framework;
using System.Linq;

namespace MaximPractice3course
{
    public class NUnitTests
    {
        // Тест при >= 5 водителей на карте
        [Test]
        public void Test1() {

            var drivers = new Driver[]
            {
                new Driver(1,0,0),
                new Driver(2,1,0),
                new Driver(3,2,0),
                new Driver(4,3,0),
                new Driver(5,4,0),
                new Driver(6,10,10)
            };

            var method1 = Methods.Method1(drivers, 0, 0, 100, 100);
            var method2 = Methods.Method2(drivers, 0, 0);
            var method3 = Methods.Method3(drivers, 0, 0);

            Assert.AreEqual(5, method1.Count);
            Assert.AreEqual(5, method2.Count);
            Assert.AreEqual(5, method3.Count);
        }

        // Тест при < 5 водителей на карте
        [Test]
        public void Test2()
        {
            var drivers = new Driver[]
            {
                new Driver(1,5,5),
                new Driver(2,6,6)
            };

            var method1 = Methods.Method1(drivers, 0, 0, 100, 100);
            var method2 = Methods.Method2(drivers, 0, 0);
            var method3 = Methods.Method3(drivers, 0, 0);

            Assert.AreEqual(drivers.Length, method1.Count);
            Assert.AreEqual(drivers.Length, method2.Count);
            Assert.AreEqual(drivers.Length, method3.Count);
        }

    }
}
