# DoubleDoubleODE
 Double-Double Ordinary Differential Equation Solver 

## Requirement
.NET 8.0  
[DoubleDouble](https://github.com/tk-yoshimura/DoubleDouble)

## Install

[Download DLL](https://github.com/tk-yoshimura/DoubleDoubleODE/releases)  
[Download Nuget](https://www.nuget.org/packages/tyoshimura.doubledouble.ode/)  

## Usage
```csharp
DormandPrinceODESolver solver = new(v: 1, (x) => x);

for (int i = 0; i < 256; i++) {
    solver.Next(1d / 256);
}

Assert.AreEqual(0d, (double)(solver.X - ddouble.E), 1e-12);
```

## Licence
[MIT](https://github.com/tk-yoshimura/DoubleDoubleODE/blob/main/LICENSE)

## Author

[T.Yoshimura](https://github.com/tk-yoshimura)
