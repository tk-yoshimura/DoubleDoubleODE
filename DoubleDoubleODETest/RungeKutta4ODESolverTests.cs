using DoubleDouble;
using DoubleDoubleODE;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DoubleDoubleODETest {
    [TestClass]
    public class RungeKutta4ODESolverTests {
        [TestMethod]
        public void ExpTest() {
            RungeKutta4ODESolver solver = new(v: 1, (x) => x);

            for (int i = 0; i < 256; i++) {
                solver.Next(1d / 256);
            }

            Console.WriteLine(solver.X);

            Assert.AreEqual(0d, (double)(solver.X - ddouble.E), 1e-10);
        }
    }
}
