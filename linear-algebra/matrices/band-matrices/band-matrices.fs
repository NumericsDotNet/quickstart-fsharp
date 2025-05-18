//=====================================================================
//
//  File: band-matrices.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module BandMatrices

// Illustrates the use of the BandMatrix class in the
// Numerics.NET.LinearAlgebra namespace of Numerics.NET.

#light

open System

open Numerics.NET
// The BandMatrix class resides in the Numerics.NET.LinearAlgebra
// namespace.
open Numerics.NET.LinearAlgebra

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Band matrices are matrices whose elements
// are nonzero only in a diagonal band around
// the main diagonal.
//
// General band matrices, upper and lower band
// matrices, and symmetric band matrices are all
// represented by a single class: BandMatrix.

//
// Constructing band matrices
//

// Constructing band matrices is similar to
// constructing general matrices. It is done by
// calling a factory method on the Matrix class.
// See theBasicMatrices QuickStart samples
// for a more complete discussion.

// The following creates a 7x5 band matrix with
// upper bandwidth 1 and lower bandwidth 2:
let b1 = Matrix.CreateBanded<float>(7, 5, 2, 1)

// Once the upper and lower bandwidth are set,
// it cannot be changed. Elements that are outside
// the band cannot be set.

// A second factory method lets you create upper
// or lower band matrices. The following constructs
// an 11x11 upper band matrix with unit diagonal
// and three non-zero upper diagonals.
let b2 = Matrix.CreateUpperBanded<float>(11, 11, 3, MatrixDiagonal.UnitDiagonal)

// To create a symmetric band matrix, you only need
// the size and the bandwith. The following creates
// a 6x6 symmetric tri-diagonal matrix:
let b3 = Matrix.CreateSymmetricBanded<float>(7, 1)

// We can assign values to the components by using
// the GetDiagonal method.
b3.GetDiagonal(0).SetValue(2.0) |> ignore
b3.GetDiagonal(1).SetValue(-1.0) |> ignore

// Extracting band matrices

// Another way to construct a band matrix is by
// extracting them from an existing matrix.
let m = Matrix.CreateFromArray(3, 4,
    [|
        1.0; 2.0; 3.0;
        2.0; 3.0; 4.0;
        3.0; 4.0; 5.0;
        4.0; 5.0; 7.0
    |], MatrixElementOrder.ColumnMajor)
// To get the lower band part of m with bandwidth 2:
let b4 = BandMatrix.Extract(m, 2, 0)

//
// BandMatrix properties
//

// A number of properties are available to determine
// whether a BandMatrix has a special structure:
printfn "b2 is upper? %b" b2.IsUpperTriangular
printfn "b2 is lower? %b" b2.IsUpperTriangular
printfn "b2 is unit diagonal? %b" b2.IsUnitDiagonal
printfn "b2 is symmetrical? %b" b2.IsSymmetrical

//
// BandMatrix methods
//

// You can get and set matrix elements:
b3[2, 3] <- 55.0
printfn "b3[2, 3] = %.0f" b3[2, 3]
// And the change will automatically be reflected
// in the symmetric element:
printfn "b3[3, 2] = %.0f" b3[3, 2]

//
// Row and column views
//

// The GetRow and GetColumn methods are
// available.
let row = b2.GetRow(1)
printfn "row 1 of b2 = %s" (row.ToString("F0"))
let column = b2.GetColumn(2, 3, 4)
printfn "column 3 of b2 from row 4 to "
printfn "  row 5 = %s" (column.ToString("F0"))

//
// Band matrix decompositions
//

// Specialized classes exist to represent the
// LU decomposition of a general band matrix
// and the Cholesky decomposition of a
// symmetric band matrix.

// Because of pivoting, the upper band matrix of
// the LU decomposition has larger bandwidth.
// You need to allocate extra space to be able to
// overwrite a matrix with its LU decomposition.

// The following creates a 7x5 band matrix with
// upper bandwidth 1 and lower bandwidth 2.
let b5 = Matrix.CreateBanded(7, 7, 2, 1, true)
b5.GetDiagonal(0).SetValue(2.0) |> ignore
b5.GetDiagonal(-2).SetValue(-1.0) |> ignore
b5.GetDiagonal(1).SetValue(-1.0) |> ignore

// Other than that, the API is the same as
// other decomposition classes.
let blu = b5.GetLUDecomposition(true)
let solution = blu.Solve(Vector.CreateConstant(b5.ColumnCount, 1.0))
printfn "  solution of b5*x = ones: %s" (solution.ToString("F4"))

