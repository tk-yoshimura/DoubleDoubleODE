﻿using DoubleDouble;
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

        public override void Next(ddouble h) {
            ddouble[] dv = f(v);
            ddouble[] v_new = new ddouble[Params];

            for (int i = 0; i < Params; i++) {
                v_new[i] = v[i] + h * dv[i];
            }

            v = v_new;
        }
    }
}
