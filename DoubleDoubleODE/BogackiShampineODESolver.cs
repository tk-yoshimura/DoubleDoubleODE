using DoubleDouble;
using System;

namespace DoubleDoubleODE {
    public class BogackiShampineODESolver : ODESolver {
        private static readonly ddouble c_1d2 = (ddouble)1 / 2, c_3d4 = (ddouble)3 / 4, c_1d9 = (ddouble)1 / 9;

        public BogackiShampineODESolver(ddouble v, Func<ddouble, ddouble> f)
            : base(v, f) { }

        public BogackiShampineODESolver((ddouble x, ddouble y) v, Func<ddouble, ddouble, (ddouble dx, ddouble dy)> f)
            : base(v, f) { }

        public BogackiShampineODESolver((ddouble x, ddouble y, ddouble z) v, Func<ddouble, ddouble, ddouble, (ddouble dx, ddouble dy, ddouble dz)> f)
            : base(v, f) { }

        public BogackiShampineODESolver((ddouble x, ddouble y, ddouble z, ddouble w) v, Func<ddouble, ddouble, ddouble, ddouble, (ddouble dx, ddouble dy, ddouble dz, ddouble dw)> f)
            : base(v, f) { }

        public BogackiShampineODESolver(ddouble[] v, Func<ddouble[], ddouble[]> f)
            : base(v, f) { }

        public override void Next(ddouble h) {
            ddouble h_1d2 = h * c_1d2, h_3d4 = h * c_3d4, h_1d9 = h * c_1d9;

            ddouble[] dv1 = f(v);
            ddouble[] v2 = new ddouble[Params];

            for (int i = 0; i < Params; i++) {
                v2[i] = v[i] + h_1d2 * dv1[i];
            }

            ddouble[] dv2 = f(v2);
            ddouble[] v3 = new ddouble[Params];

            for (int i = 0; i < Params; i++) {
                v3[i] = v[i] + h_3d4 * dv2[i];
            }

            ddouble[] dv3 = f(v3);

            for (int i = 0; i < Params; i++) {
                v[i] += h_1d9 * (2 * dv1[i] + 3 * dv2[i] + 4 * dv3[i]);
            }
        }
    }
}
