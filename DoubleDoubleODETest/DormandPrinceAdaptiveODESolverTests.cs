using DoubleDouble;
using DoubleDoubleODE;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DoubleDoubleODETest {
    [TestClass]
    public class DormandPrinceAdaptiveODESolverTests {
        [TestMethod]
        public void ExpTest() {
            DormandPrinceAdaptiveODESolver solver = new(v: 1, (x) => x, abstol: "1e-30", reltol: "1e-28", maxdepth: 12);

            for (int i = 0; i < 256; i++) {
                solver.Next(1d / 256);
            }

            Console.WriteLine(solver.X);

            Assert.AreEqual(0d, (double)(solver.X - ddouble.E), 1e-28);
        }

        [TestMethod]
        public void UnlimitedExpTest() {
            DormandPrinceAdaptiveODESolver solver = new(v: 1, (x) => x, abstol: "1e-30", reltol: "1e-28");

            for (int i = 0; i < 256; i++) {
                solver.Next(1d / 256);
            }

            Console.WriteLine(solver.X);

            Assert.AreEqual(0d, (double)(solver.X - ddouble.E), 1e-28);
        }
    }
}
