using DoubleDouble;
using System;

namespace DoubleDoubleODE {
    public abstract class ODESolver {
        protected readonly ddouble[] v;
        protected readonly Func<ddouble[], ddouble[]> f;

        public int Params => v.Length;

        public ddouble[] State => (ddouble[])v.Clone();

        public ddouble X => v.Length > 0 ? v[0] : ddouble.Zero;

        public ddouble Y => v.Length > 1 ? v[1] : ddouble.Zero;

        public ddouble Z => v.Length > 2 ? v[2] : ddouble.Zero;

        public ddouble W => v.Length > 3 ? v[3] : ddouble.Zero;

        public ddouble this[int index] => v[index];

        public ODESolver(ddouble v, Func<ddouble, ddouble> f) {
            this.v = new ddouble[] { v };
            this.f = (v) => new ddouble[] { f(v[0]) };
        }

        public ODESolver((ddouble x, ddouble y) v, Func<ddouble, ddouble, (ddouble dx, ddouble dy)> f) {
            this.v = new ddouble[] { v.x, v.y };
            this.f = (v) => { var (dx, dy) = f(v[0], v[1]); return new ddouble[] { dx, dy }; };
        }

        public ODESolver((ddouble x, ddouble y, ddouble z) v, Func<ddouble, ddouble, ddouble, (ddouble dx, ddouble dy, ddouble dz)> f) {
            this.v = new ddouble[] { v.x, v.y, v.z };
            this.f = (v) => { var (dx, dy, dz) = f(v[0], v[1], v[2]); return new ddouble[] { dx, dy, dz }; };
        }

        public ODESolver((ddouble x, ddouble y, ddouble z, ddouble w) v, Func<ddouble, ddouble, ddouble, ddouble, (ddouble dx, ddouble dy, ddouble dz, ddouble dw)> f) {
            this.v = new ddouble[] { v.x, v.y, v.z, v.w };
            this.f = (v) => { var (dx, dy, dz, dw) = f(v[0], v[1], v[2], v[3]); return new ddouble[] { dx, dy, dz, dw }; };
        }

        public ODESolver(ddouble[] v, Func<ddouble[], ddouble[]> f) {
            this.v = (ddouble[])v.Clone();
            this.f = f;
        }

        public abstract void Next(ddouble h);
    }
}
