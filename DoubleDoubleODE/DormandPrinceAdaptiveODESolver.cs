using DoubleDouble;
using System;

namespace DoubleDoubleODE {
    public class DormandPrinceAdaptiveODESolver : AdaptiveODESolver {

        public DormandPrinceAdaptiveODESolver(ddouble v, Func<ddouble, ddouble> f, ddouble abstol, ddouble reltol, int maxdepth = -1)
            : base(v, f, abstol, reltol, maxdepth) { }

        public DormandPrinceAdaptiveODESolver((ddouble x, ddouble y) v, Func<ddouble, ddouble, (ddouble dx, ddouble dy)> f, ddouble abstol, ddouble reltol, int maxdepth = -1)
            : base(v, f, abstol, reltol, maxdepth) { }

        public DormandPrinceAdaptiveODESolver((ddouble x, ddouble y, ddouble z) v, Func<ddouble, ddouble, ddouble, (ddouble dx, ddouble dy, ddouble dz)> f, ddouble abstol, ddouble reltol, int maxdepth = -1)
            : base(v, f, abstol, reltol, maxdepth) { }

        public DormandPrinceAdaptiveODESolver((ddouble x, ddouble y, ddouble z, ddouble w) v, Func<ddouble, ddouble, ddouble, ddouble, (ddouble dx, ddouble dy, ddouble dz, ddouble dw)> f, ddouble abstol, ddouble reltol, int maxdepth = -1)
            : base(v, f, abstol, reltol, maxdepth) { }

        public DormandPrinceAdaptiveODESolver(ddouble[] v, Func<ddouble[], ddouble[]> f, ddouble abstol, ddouble reltol, int maxdepth = -1)
            : base(v, f, abstol, reltol, maxdepth) { }

        internal static (ddouble[] dv7, ddouble[] v7, ddouble[] v_err) Step(int n, ddouble[] v, Func<ddouble[], ddouble[]> f, ddouble h) {
            (ddouble[] dv1, ddouble[] dv2, ddouble[] dv3, ddouble[] dv4, ddouble[] dv5, ddouble[] dv6, ddouble[] v7) = DormandPrinceODESolver.Step(n, v, f, h);

            ddouble[] v_err = new ddouble[n];

            ddouble[] dv7 = f(v7);

            for (int i = 0; i < n; i++) {
                v_err[i] = ddouble.Abs(h * (26341d * dv1[i] - 90880d * dv3[i] + 790230d * dv4[i] - 1086939d * dv5[i] + 895488d * dv6[i] - 534240d * dv7[i]) / 21369600d);
            }

            return (dv7, v7, v_err);
        }

        internal static (ddouble[] v7, ddouble[] v_err) Step(int n, ddouble[] v, Func<ddouble[], ddouble[]> f, ddouble h, ddouble abserr, ddouble relerr, int depth, int maxdepth) {
            (ddouble[] dv7, ddouble[] v7, ddouble[] v_err) = Step(n, v, f, h);

            if (maxdepth < 0 || depth < maxdepth) {
                bool is_ok = true;

                for (int i = 0; i < n; i++) {
                    if (v_err[i] >= ddouble.Abs(dv7[i]) * relerr + abserr) {
                        is_ok = false;
                        break;
                    }
                }

                if (!is_ok) {
                    ddouble h_1d2 = ddouble.Ldexp(h, -1), abserr_1d2 = ddouble.Ldexp(abserr, -1);

                    (ddouble[] v7_1, ddouble[] v_err_1) = Step(n, v, f, h_1d2, abserr_1d2, relerr, depth + 1, maxdepth);
                    (ddouble[] v7_2, ddouble[] v_err_2) = Step(n, v7_1, f, h_1d2, abserr_1d2, relerr, depth + 1, maxdepth);

                    v7 = v7_2;

                    for (int i = 0; i < n; i++) {
                        v_err[i] = v_err_1[i] + v_err_2[i];
                    }
                }
            }

            return (v7, v_err);
        }

        public override void Next(ddouble h) {
            lock (v){
                (ddouble[] v7, ddouble[] v_err) = Step(Params, v, f, h, AbsoluteTolerance, RelativeTolerance, 0, MaxDepth);

                v = v7;
                for (int i = 0; i < Params; i++) {
                    err[i] += v_err[i];
                }
            }
        }
    }
}
