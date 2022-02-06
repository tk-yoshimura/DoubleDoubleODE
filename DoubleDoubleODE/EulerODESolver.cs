using DoubleDouble;
using System;

namespace DoubleDoubleODE {
    public class EulerODESolver : ODESolver {
        public EulerODESolver(ddouble v, Func<ddouble, ddouble> f)
            : base(v, f) { }

        public EulerODESolver((ddouble x, ddouble y) v, Func<ddouble, ddouble, (ddouble dx, ddouble dy)> f)
            : base(v, f) { }

        public EulerODESolver((ddouble x, ddouble y, ddouble z) v, Func<ddouble, ddouble, ddouble, (ddouble dx, ddouble dy, ddouble dz)> f)
            : base(v, f) { }

        public EulerODESolver((ddouble x, ddouble y, ddouble z, ddouble w) v, Func<ddouble, ddouble, ddouble, ddouble, (ddouble dx, ddouble dy, ddouble dz, ddouble dw)> f)
            : base(v, f) { }

        public EulerODESolver(ddouble[] v, Func<ddouble[], ddouble[]> f)
            : base(v, f) { }

        protected override void Next(ddouble h, ddouble[] v, Func<ddouble[], ddouble[]> f) {
            ddouble[] dv = f(v);

            for (int i = 0; i < Params; i++) {
                this.v[i] = v[i] + h * dv[i];
            }
        }
    }
}
