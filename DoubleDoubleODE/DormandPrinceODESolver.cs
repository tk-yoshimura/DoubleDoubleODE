using DoubleDouble;
using System;

namespace DoubleDoubleODE {
    public class DormandPrinceODESolver : ODESolver {        
        private static readonly ddouble c_1d5 = (ddouble)1 / 5, c_3d40 = (ddouble)3 / 40;
        private static readonly ddouble c_9d40 = (ddouble)9 / 40, c_44d45 = (ddouble)44 / 45;
        private static readonly ddouble c_56d15 = (ddouble)56 / 15, c_32d9 = (ddouble)32 / 9;
        private static readonly ddouble c_19372d6561 = (ddouble)19372 / 6561, c_25360d2187 = (ddouble)25360 / 2187;
        private static readonly ddouble c_64448d6561 = (ddouble)64448 / 6561, c_212d729 = (ddouble)212 / 729;
        private static readonly ddouble c_9017d3168 = (ddouble)9017 / 3168, c_355d33 = (ddouble)355 / 33;
        private static readonly ddouble c_46732d5247 = (ddouble)46732 / 5247, c_49d176 = (ddouble)49 / 176;
        private static readonly ddouble c_5103d18656 = (ddouble)5103 / 18656, c_35d384 = (ddouble)35 / 384;
        private static readonly ddouble c_500d1113 = (ddouble)500 / 1113, c_125d192 = (ddouble)125 / 192;
        private static readonly ddouble c_2187d6784 = (ddouble)2187 / 6784, c_11d84 = (ddouble)11 / 84;

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

        public override void Next(ddouble h) {
            ddouble[] dv1 = f(v);
            ddouble[] v2 = new ddouble[Params];

            for (int i = 0; i < Params; i++) {
                v2[i] = v[i] + h * c_1d5 * dv1[i];
            }

            ddouble[] dv2 = f(v2);
            ddouble[] v3 = new ddouble[Params];

            for (int i = 0; i < Params; i++) {
                v3[i] = v[i] + h * (c_3d40 * dv1[i] + c_9d40 * dv2[i]);
            }

            ddouble[] dv3 = f(v3);
            ddouble[] v4 = new ddouble[Params];

            for (int i = 0; i < Params; i++) {
                v4[i] = v[i] + h * (c_44d45 * dv1[i] - c_56d15 * dv2[i] + c_32d9 * dv3[i]);
            }

            ddouble[] dv4 = f(v4);
            ddouble[] v5 = new ddouble[Params];

            for (int i = 0; i < Params; i++) {
                v5[i] = v[i] + h * (c_19372d6561 * dv1[i] - c_25360d2187 * dv2[i] + c_64448d6561 * dv3[i] - c_212d729 * dv4[i]);
            }

            ddouble[] dv5 = f(v5);
            ddouble[] v6 = new ddouble[Params];

            for (int i = 0; i < Params; i++) {
                v6[i] = v[i] + h * (c_9017d3168 * dv1[i] - c_355d33 * dv2[i] + c_46732d5247 * dv3[i] + c_49d176 * dv4[i] - c_5103d18656 * dv5[i]);
            }

            ddouble[] dv6 = f(v6);

            for (int i = 0; i < Params; i++) {
                v[i] += h * (c_35d384 * dv1[i] + c_500d1113 * dv3[i] + c_125d192 * dv4[i] - c_2187d6784 * dv5[i] + c_11d84 * dv6[i]);
            }
        }
    }
}
