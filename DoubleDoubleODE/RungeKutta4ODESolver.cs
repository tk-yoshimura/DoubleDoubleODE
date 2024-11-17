﻿using DoubleDouble;
using System;

namespace DoubleDoubleODE {
    public class RungeKutta4ODESolver : ODESolver {
        private static readonly ddouble c_1d6 = (ddouble)1 / 6;

        public RungeKutta4ODESolver(ddouble v, Func<ddouble, ddouble> f)
            : base(v, f) { }

        public RungeKutta4ODESolver((ddouble x, ddouble y) v, Func<ddouble, ddouble, (ddouble dx, ddouble dy)> f)
            : base(v, f) { }

        public RungeKutta4ODESolver((ddouble x, ddouble y, ddouble z) v, Func<ddouble, ddouble, ddouble, (ddouble dx, ddouble dy, ddouble dz)> f)
            : base(v, f) { }

        public RungeKutta4ODESolver((ddouble x, ddouble y, ddouble z, ddouble w) v, Func<ddouble, ddouble, ddouble, ddouble, (ddouble dx, ddouble dy, ddouble dz, ddouble dw)> f)
            : base(v, f) { }

        public RungeKutta4ODESolver(ddouble[] v, Func<ddouble[], ddouble[]> f)
            : base(v, f) { }

        public override void Next(ddouble h) {
            ddouble h_1d2 = ddouble.Ldexp(h, -1), h_1d6 = h * c_1d6;

            ddouble[] dv1 = f(v);
            ddouble[] v2 = new ddouble[Params], v_new = new ddouble[Params];

            for (int i = 0; i < Params; i++) {
                v2[i] = v[i] + h_1d2 * dv1[i];
            }

            ddouble[] dv2 = f(v2);
            ddouble[] v3 = new ddouble[Params];

            for (int i = 0; i < Params; i++) {
                v3[i] = v[i] + h_1d2 * dv2[i];
            }

            ddouble[] dv3 = f(v3);
            ddouble[] v4 = new ddouble[Params];

            for (int i = 0; i < Params; i++) {
                v4[i] = v[i] + h * dv3[i];
            }

            ddouble[] dv4 = f(v4);

            for (int i = 0; i < Params; i++) {
                v_new[i] = v[i] + h_1d6 * (dv1[i] + ddouble.Ldexp(dv2[i] + dv3[i], 1) + dv4[i]);
            }

            v = v_new;
        }
    }
}
