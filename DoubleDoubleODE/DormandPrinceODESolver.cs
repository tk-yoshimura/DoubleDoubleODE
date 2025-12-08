using DoubleDouble;
using System;

namespace DoubleDoubleODE {
    public class DormandPrinceODESolver : ODESolver {
        public DormandPrinceODESolver(ddouble v, Func<ddouble, ddouble> f)
            : base(v, f) { }

        public DormandPrinceODESolver((ddouble x, ddouble y) v, Func<ddouble, ddouble, (ddouble dx, ddouble dy)> f)
            : base(v, f) { }

        public DormandPrinceODESolver((ddouble x, ddouble y, ddouble z) v, Func<ddouble, ddouble, ddouble, (ddouble dx, ddouble dy, ddouble dz)> f)
            : base(v, f) { }

        public DormandPrinceODESolver((ddouble x, ddouble y, ddouble z, ddouble w) v, Func<ddouble, ddouble, ddouble, ddouble, (ddouble dx, ddouble dy, ddouble dz, ddouble dw)> f)
            : base(v, f) { }

        public DormandPrinceODESolver(ddouble[] v, Func<ddouble[], ddouble[]> f)
            : base(v, f) { }

        internal static (ddouble[] dv1, ddouble[] dv2, ddouble[] dv3, ddouble[] dv4, ddouble[] dv5, ddouble[] dv6, ddouble[] v7) Step(int n, ddouble[] v, Func<ddouble[], ddouble[]> f, ddouble h) { 
            ddouble[] v2 = new ddouble[n], v3 = new ddouble[n], v4 = new ddouble[n]; 
            ddouble[] v5 = new ddouble[n], v6 = new ddouble[n], v7 = new ddouble[n];
            
            ddouble[] dv1 = f(v);

            for (int i = 0; i < n; i++) {
                v2[i] = v[i] + h * dv1[i] / 5d;
            }

            ddouble[] dv2 = f(v2);

            for (int i = 0; i < n; i++) {
                v3[i] = v[i] + h * (3d * dv1[i] + 9d * dv2[i]) / 40d;
            }

            ddouble[] dv3 = f(v3);

            for (int i = 0; i < n; i++) {
                v4[i] = v[i] + h * (44d * dv1[i] - 168d * dv2[i] + 160d * dv3[i]) / 45d;
            }

            ddouble[] dv4 = f(v4);

            for (int i = 0; i < n; i++) {
                v5[i] = v[i] + h * (19372d * dv1[i] - 76080d * dv2[i] + 64448d * dv3[i] - 1908d * dv4[i]) / 6561d;
            }

            ddouble[] dv5 = f(v5);

            for (int i = 0; i < n; i++) {
                v6[i] = v[i] + h * (477901d * dv1[i] - 1806240d * dv2[i] + 1495424d * dv3[i] + 46746d * dv4[i] - 45927d * dv5[i]) / 167904d;
            }

            ddouble[] dv6 = f(v6);

            for (int i = 0; i < n; i++) {
                v7[i] = v[i] + h * (12985d * dv1[i] + 64000d * dv3[i] + 92750d * dv4[i] - 45927d * dv5[i] + 18656d * dv6[i]) / 142464d;
            }

            return (dv1, dv2, dv3, dv4, dv5, dv6, v7);
        }

        public override void Next(ddouble h) {
            v = Step(Params, v, f, h).v7;
        }
    }
}
