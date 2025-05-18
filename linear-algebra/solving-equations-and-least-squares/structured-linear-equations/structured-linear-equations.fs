//=====================================================================
//
//  File: structured-linear-equations.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module StructuredLinearEquations

// Illustrates solving symmetrical and triangular systems
// of simultaneous linear equations using classes
// in the Numerics.NET.LinearAlgebra namespace of Numerics.NET.

#light

open System

open Numerics.NET
// The structured matrix classes reside in the
// Numerics.NET.LinearAlgebra namespace.
open Numerics.NET.LinearAlgebra

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// To learn more about solving general systems of
// simultaneous linear equations, see the
// LinearEquations QuickStart Sample.
//
// The methods and classes available for solving
// structured systems of equations are similar
// to those for general equations.

//
// Triangular systems and matrices
//

printfn "Triangular matrices:"
// For the basics of working with triangular
// matrices, see the TriangularMatrices QuickStart
// Sample.
//
// Let's start with a triangular matrix. Remember
// that elements are stored in column-major order
// by default.
let t =
    Matrix.CreateUpperTriangular(
        4, 4,
        [|
            1.0; 0.0; 0.0; 0.0;
            1.0; 2.0; 0.0; 0.0;
            1.0; 4.0; 1.0; 0.0;
            1.0; 3.0; 1.0; 2.0
        |], MatrixElementOrder.ColumnMajor)
let b1 = Vector.Create(1.0, 3.0, 6.0, 3.0)
let b2 =
    Matrix.CreateFromArray(4, 2,
        [|
            1.0; 3.0; 6.0; 3.0;
            2.0; 3.0; 5.0; 8.0
        |], MatrixElementOrder.ColumnMajor)
printfn "t = %O" (t.ToString("F4"))

//
// The Solve method
//

// The following solves m x = b1.
let x1 = t.Solve(b1)
printfn "x1 = %O" (x1.ToString("F4"))
// A second parameter specifies whether to overwrite
// the right-hand side with the result. Solve also
// returns the result, which we ignore here:
t.Solve(b1, true) |> ignore
printfn "b1 = %O" (b1.ToString("F4"))
// You can solve for multiple right hand side
// vectors by passing them in a DenseMatrix:
let x2 = t.Solve(b2, false)
printfn "x2 = %O" (x2.ToString("F4"))

//
// Related Methods
//

// You can verify whether a matrix is singular
// using the IsSingular method:
printfn "IsSingular(t) = %b" (t.IsSingular())
// The inverse matrix is returned by the Inverse
// method:
printfn "Inverse(t) = %O" (t.GetInverse().ToString("F4"))
// The determinant is also available:
printfn "Det(t) = %.4f" (t.GetDeterminant())
// The condition number is an estimate for the
// loss of precision in solving the equations
printfn "Cond(t) = %.4f" (t.EstimateConditionNumber())
printfn ""

//
// Symmetric systems and matrices
//

printfn "Symmetric matrices:"
// For the basics of working with symmetric
// matrices, see the SymmetricMatrices QuickStart
// Sample.
//
// Let's start with a symmetric matrix. Remember
// that elements are stored in column-major order
// by default.
let s =
    Matrix.CreateSymmetric(4,
        [|
            1.0; 0.0; 0.0; 0.0;
            1.0; 2.0; 0.0; 0.0;
            1.0; 1.0; 2.0; 0.0;
            1.0; 0.0; 1.0; 4.0
        |], MatrixTriangle.Upper, MatrixElementOrder.ColumnMajor)
let b3 = Vector.Create(1.0, 3.0, 6.0, 3.0)
printfn "s = %O" (s.ToString("F4"))

//
// The Solve method
//

// The following solves m x = b1.
let x3 = s.Solve(b3)
printfn "x3 = %O" (x1.ToString("F4"))
// A second parameter specifies whether to overwrite the
// right-hand side with the result.
s.Solve(b2, true) |> ignore
printfn "b2 = %O" (b2.ToString("F4"))
// You can solve for multiple right hand side
// vectors by passing them in a DenseMatrix:
let x4 = s.Solve(b3, false)
printfn "x4 = %O" (x4.ToString("F4"))

//
// Related Methods
//

// You can verify whether a matrix is singular
// using the IsSingular method:
printfn "IsSingular(s) = %b" (s.IsSingular())
// The inverse matrix is returned by the Inverse
// method:
printfn "Inverse(s) = %O" (s.GetInverse().ToString("F4"))
// The determinant is also available:
printfn "Det(s) = %.4f" (s.GetDeterminant())
// The condition number is an estimate for the
// loss of precision in solving the equations
printfn "Cond(s) = %.4f" (s.EstimateConditionNumber())
printfn ""

//
// The CholeskyDecomposition class
//

// If the symmetric matrix is positive definite,
// you can use the CholeskyDecomposition class
// to optimize performance if multiple operations
// need to be performed. This class does the
// bulk of the calculations only once. This
// decomposes the matrix into G x transpose(G)
// where G is a lower triangular matrix.
//
// If the matrix is indefinite, you need to use
// the LUDecomposition class instead. See the
// LinearEquations QuickStart Sample for details.
printfn "Using Cholesky Decomposition:"
// The constructor takes an optional second argument
// indicating whether to overwrite the original
// matrix with its decomposition:
let cf = s.GetCholeskyDecomposition(false)
// The Factor method performs the actual
// factorization. It is called automatically
// if needed.
cf.Decompose()
// All methods mentioned earlier are still available:
let x5 = cf.Solve(b2, false)
printfn "x5 = %O" (x5.ToString("F4"))
printfn "IsSingular(m) = %b" (cf.IsSingular())
printfn "Inverse(m) = %O" (cf.GetInverse().ToString("F4"))
printfn "Det(m) = %.4f" (cf.GetDeterminant())
printfn "Cond(m) = %.4f" (cf.EstimateConditionNumber())
// In addition, you have access to the
// triangular matrix, G, of the composition.
printfn "  G = %O" (cf.LowerTriangularFactor.ToString("F4"))

// Note that if the matrix is indefinite,
// the factorization will fail and throw a
// MatrixNotPositiveDefiniteException.
s[0, 0] <- -99.0
let cf2 = s.GetCholeskyDecomposition()
try
    cf2.Decompose()
with :? MatrixNotPositiveDefiniteException as e -> printfn "%s" e.Message

// To avoid this, you can use the TryDecompose method,
// which returns true if the decomposition succeeds,
// and false otherwise:
if (cf2.TryDecompose()) then
    printfn "Decomposition succeeded!"
else
    printfn "Decomposition failed!"
