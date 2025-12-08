# DoubleDoubleODE
 Double-Double Ordinary Differential Equation Solver

## Requirement
.NET 10.0  
[DoubleDouble](https://github.com/tk-yoshimura/DoubleDouble)

## Install

[Download DLL](https://github.com/tk-yoshimura/DoubleDoubleODE/releases)  
[Download Nuget](https://www.nuget.org/packages/tyoshimura.doubledouble.ode/)  

## Usage
```csharp
ddouble mu = 1.5;

DormandPrinceAdaptiveODESolver solver = new(
    v: (0, 1),
    (x, y) => (y, mu * (1 - x * x) * y - x),
    abstol: "1e-20", reltol: "1e-20", maxdepth: 12
);

for (int i = 0; i <= 65536; i++) {
    Console.WriteLine($"{i / 256d},{solver.X},{solver.Y}");
    solver.Next(1d / 256);
}

Assert.IsTrue(solver.MaxError < 1e-14);
```

## Licence
[MIT](https://github.com/tk-yoshimura/DoubleDoubleODE/blob/main/LICENSE)

## Author

[T.Yoshimura](https://github.com/tk-yoshimura)
