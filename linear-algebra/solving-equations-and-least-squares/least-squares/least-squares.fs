//=====================================================================
//
//  File: least-squares.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module LeastSquares

// Illustrates solving least squares problems using the
// LeastSquaresSolver class in the Numerics.NET.LinearAlgebra
// namespace of Numerics.NET.

#light

open System

open Numerics.NET
// The DenseMatrix and LeastSquaresSolver classes reside in the
// Numerics.NET.LinearAlgebra namespace.
open Numerics.NET.LinearAlgebra

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// A least squares problem consists in finding
// the solution to an overdetermined system of
// simultaneous linear equations so that the
// sum of the squares of the error is minimal.
//
// A common application is fitting data to a
// curve. See the CurveFitting sample application
// for a complete example.

// Let's start with a general matrix. This will be
// the matrix a in the left hand side ax=b:
let a =
    Matrix.CreateFromArray(6, 4,
        [|
            1.0; 1.0; 1.0; 1.0; 1.0; 1.0;
            1.0; 2.0; 3.0; 4.0; 5.0; 6.0;
            1.0; 4.0; 9.0;16.0;25.0;36.0;
            1.0; 2.0; 1.0; 2.0; 1.0; 2.0
        |], MatrixElementOrder.ColumnMajor)
// Here is the right hand side:
let b = Vector.Create(1.0, 3.0, 6.0, 11.0, 15.0, 21.0)
let b2 =
    Matrix.CreateFromArray(6, 2,
        [|
            1.0; 3.0; 6.0;11.0;15.0;21.0;
            1.0; 2.0; 3.0; 4.0; 5.0; 7.0
        |], MatrixElementOrder.ColumnMajor)
printfn "a = %O" (a.ToString("F4"))
printfn "b = %O" (b.ToString("F4"))

//
// The LeastSquaresSolver class
//

// The following creates an instance of the
// LeastSquaresSolver class for our problem:
let solver = LeastSquaresSolver(a, b)
// We can specify the solution method: normal
// equations or QR decomposition. In most cases,
// a QR decomposition is the most desirable:
solver.SolutionMethod <- LeastSquaresSolutionMethod.QRDecomposition
// The Solve method calculates the solution:
let x = solver.Solve()
printfn "x = %O" (x.ToString("F4"))
// The Solution property also returns the solution:
printfn "x = %O" (solver.Solution.ToString("F4"))
// More detailed information is available from
// additional methods.
// The values of the right hand side predicted
// by the solution:
printfn "Predictions = %O" (solver.GetPredictions().ToString("F4"))
// The residuals (errors) of the solution:
printfn "Residuals = %O" (solver.GetResiduals().ToString("F4"))
// The total sum of squares of the residues:
printfn "Residual square error = %A" (solver.GetResidualSumOfSquares())

//
// Direct normal equations
//

// Alternatively, you can create a least squares
// solution by providing the normal equations
// directly. This may be useful when it is easy
// to calculate the normal equations directly.
//
// Here, we'll just calculate the normal equation:
let aTa = SymmetricMatrix<float>.FromOuterProduct(a)
let aTb = b * a; // a.Transpose() * b
// We find the solution by solving the normal equations
// directly:
let x2 = aTa.Solve(aTb)
printfn "x2 = %O" (x2.ToString("F4"))
// However, properties of the least squares solution, such as
// error estimates and residuals are not available.
