using DoubleDouble;
using System;

namespace DoubleDoubleODE {
    public class HeunODESolver : ODESolver {
        public HeunODESolver(ddouble v, Func<ddouble, ddouble> f)
            : base(v, f) { }

        public HeunODESolver((ddouble x, ddouble y) v, Func<ddouble, ddouble, (ddouble dx, ddouble dy)> f)
            : base(v, f) { }

        public HeunODESolver((ddouble x, ddouble y, ddouble z) v, Func<ddouble, ddouble, ddouble, (ddouble dx, ddouble dy, ddouble dz)> f)
            : base(v, f) { }

        public HeunODESolver((ddouble x, ddouble y, ddouble z, ddouble w) v, Func<ddouble, ddouble, ddouble, ddouble, (ddouble dx, ddouble dy, ddouble dz, ddouble dw)> f)
            : base(v, f) { }

        public HeunODESolver(ddouble[] v, Func<ddouble[], ddouble[]> f)
            : base(v, f) { }

        public override void Next(ddouble h) {
            ddouble[] dv1 = f(v);
            ddouble[] v2 = new ddouble[Params];

            for (int i = 0; i < Params; i++) {
                v2[i] = v[i] + h * dv1[i];
            }

            ddouble[] dv2 = f(v2);

            ddouble h_half = h / 2;

            for (int i = 0; i < Params; i++) {
                v[i] += h_half * (dv1[i] + dv2[i]);
            }
        }
    }
}
