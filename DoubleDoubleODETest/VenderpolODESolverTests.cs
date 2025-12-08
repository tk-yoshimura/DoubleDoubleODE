using DoubleDouble;
using DoubleDoubleODE;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DoubleDoubleODETest {
    [TestClass]
    public class VenderpolODESolverTests {
        [TestMethod]
        public void VenderpolTest() {
            ddouble mu = 1.5;

            DormandPrinceAdaptiveODESolver solver = new(
                v: (0, 1), 
                (x, y) => (y, mu * (1 - x * x) * y - x), 
                abstol: "1e-20", reltol: "1e-20", maxdepth: 12
            );

            for (int i = 0; i <= 65536; i++) {
                Console.WriteLine($"{i / 256d},{solver.X},{solver.Y}");
                solver.Next(1d / 256);
            }

            Assert.IsTrue(solver.MaxError < 1e-14);
        }
    }
}
