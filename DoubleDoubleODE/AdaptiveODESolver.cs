using DoubleDouble;
using System;

namespace DoubleDoubleODE {
    public abstract class AdaptiveODESolver : ODESolver {
        protected readonly ddouble[] err;

        protected int MaxDepth { private set; get; }

        public ddouble AbsoluteTolerance { private set; get; }
        public ddouble RelativeTolerance { private set; get; }

        public ddouble[] Error => (ddouble[])err.Clone();

        public ddouble MaxError => err.Max();

        private static void ValidateArguments(ddouble abstol, ddouble reltol, int maxdepth = -1) {
            if (!(abstol >= 0d)) {
                throw new ArgumentOutOfRangeException(nameof(abstol));
            }

            if (!(reltol > 0d)) {
                throw new ArgumentOutOfRangeException(nameof(reltol));
            }

            if (maxdepth < -1) {
                throw new ArgumentOutOfRangeException(nameof(maxdepth), "Invalid param. maxdepth=-1: infinite, maxdepth>=0: finite");
            }
        }

        public AdaptiveODESolver(ddouble v, Func<ddouble, ddouble> f, ddouble abstol, ddouble reltol, int maxdepth = -1) : base(v, f) {
            ValidateArguments(abstol, reltol, maxdepth);

            this.AbsoluteTolerance = abstol;
            this.RelativeTolerance = reltol;
            this.MaxDepth = maxdepth;
            this.err = new ddouble[Params];
        }

        public AdaptiveODESolver((ddouble x, ddouble y) v, Func<ddouble, ddouble, (ddouble dx, ddouble dy)> f, ddouble abstol, ddouble reltol, int maxdepth = -1) : base(v, f) {
            ValidateArguments(abstol, reltol, maxdepth);

            this.AbsoluteTolerance = abstol;
            this.RelativeTolerance = reltol;
            this.MaxDepth = maxdepth;
            this.err = new ddouble[Params];
        }

        public AdaptiveODESolver((ddouble x, ddouble y, ddouble z) v, Func<ddouble, ddouble, ddouble, (ddouble dx, ddouble dy, ddouble dz)> f, ddouble abstol, ddouble reltol, int maxdepth = -1) : base(v, f) {
            ValidateArguments(abstol, reltol, maxdepth);

            this.AbsoluteTolerance = abstol;
            this.RelativeTolerance = reltol;
            this.MaxDepth = maxdepth;
            this.err = new ddouble[Params];
        }

        public AdaptiveODESolver((ddouble x, ddouble y, ddouble z, ddouble w) v, Func<ddouble, ddouble, ddouble, ddouble, (ddouble dx, ddouble dy, ddouble dz, ddouble dw)> f, ddouble abstol, ddouble reltol, int maxdepth = -1) : base(v, f) {
            ValidateArguments(abstol, reltol, maxdepth);

            this.AbsoluteTolerance = abstol;
            this.RelativeTolerance = reltol;
            this.MaxDepth = maxdepth;
            this.err = new ddouble[Params];
        }

        public AdaptiveODESolver(ddouble[] v, Func<ddouble[], ddouble[]> f, ddouble abstol, ddouble reltol, int maxdepth = -1) : base(v, f) {
            ValidateArguments(abstol, reltol, maxdepth);

            this.AbsoluteTolerance = abstol;
            this.RelativeTolerance = reltol;
            this.MaxDepth = maxdepth;
            this.err = new ddouble[Params];
        }
    }
}
