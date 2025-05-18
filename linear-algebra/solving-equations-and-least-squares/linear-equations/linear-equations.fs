//=====================================================================
//
//  File: linear-equations.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module LinearEquations

// Illustrates solving systems of simultaneous linear
// equations using the DenseMatrix and LUDecomposition classes
// in the Numerics.NET.LinearAlgebra namespace of Numerics.NET.

#light

open System

open Numerics.NET
// The DenseMatrix and LUDecomposition classes reside in the
// Numerics.NET.LinearAlgebra namespace.
open Numerics.NET.LinearAlgebra

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// A system of simultaneous linear equations is
// defined by a square matrix A and a right-hand
// side B, which can be a vector or a matrix.
//
// You can use any matrix type for the matrix A.
// The optimal algorithm is automatically selected.

// Let's start with a general matrix:
let m =
    Matrix.CreateFromArray(4, 4,
        [|
            10.0; 10.0; 10.0; 10.0;
            10.0; 20.0; 30.0; 40.0;
            10.0; 40.0; 90.0; 160.0;
            10.0; 20.0; 10.0; 2.0
        |], MatrixElementOrder.ColumnMajor)
let b1 = Vector.Create(1.0, 3.0, 6.0, 3.0)
let b2 =
    Matrix.CreateFromArray(4, 2,
        [|
            10.0; 30.0; 60.0; 30.0;
            20.0; 30.0; 50.0;  8.0
        |], MatrixElementOrder.ColumnMajor)
printfn "m = %O" m

//
// The Solve method
//

// The following solves m x = b1. The second
// parameter specifies whether to overwrite the
// right-hand side with the result.
let x1 = m.Solve(b1)
printfn "x1 = %O" (x1.ToString("F4"))
// If the overwrite parameter is true, the
// right-hand-side is overwritten with the solution.
// We can the ignore the return value:
m.Solve(b1, true) |> ignore
printfn "b1 = %O" (b1.ToString("F4"))
// You can solve for multiple right hand side
// vectors by passing them in a Matrix:
let x2 = m.Solve(b2, false)
printfn "x2 = %O" (x2.ToString("F4"))

//
// Related Methods
//

// You can verify whether a matrix is singular
// using the IsSingular method:
printfn "IsSingular(m) = %b" (m.IsSingular())
// The inverse matrix is returned by the Inverse
// method:
printfn "Inverse(m) = %O" (m.GetInverse().ToString("F4"))
// The determinant is also available:
printfn "Det(m) = %.4f" (m.GetDeterminant())
// The condition number is an estimate for the
// loss of precision in solving the equations
printfn "Cond(m) = %.4f" (m.EstimateConditionNumber())
printfn ""

//
// The LUDecomposition class
//

// If multiple operations need to be performed
// on the same matrix, it is more efficient to use
// the LUDecomposition class. This class does the
// bulk of the calculations only once.
printfn "Using LU Decomposition:"
// The constructor takes an optional second argument
// indicating whether to overwrite the original
// matrix with its decomposition:
let lu = m.GetLUDecomposition(false)
// All methods mentioned earlier are still available:
let x3 = lu.Solve(b2, false)
printfn "x3 = %O" (x2.ToString("F4"))
printfn "IsSingular(m) = %b" (lu.IsSingular())
printfn "Inverse(m) = %O" (lu.GetInverse().ToString("F4"))
printfn "Det(m) = %.4f" (lu.GetDeterminant())
printfn "Cond(m) = %.4f" (lu.EstimateConditionNumber())
// In addition, you have access to the
// components, L and U of the decomposition.
// L is lower unit-triangular:
printfn "  L = %O" (lu.LowerTriangularFactor.ToString("F4"))
// U is upper triangular:
printfn "  U = %O" (lu.UpperTriangularFactor.ToString("F4"))
