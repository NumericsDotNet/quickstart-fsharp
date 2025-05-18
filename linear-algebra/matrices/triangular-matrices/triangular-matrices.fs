//=====================================================================
//
//  File: triangular-matrices.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module TriangularMatrices

// Illustrates the use of the TriangularMatrix class in the
// Numerics.NET.LinearAlgebra namespace of Numerics.NET.

#light

open System

open Numerics.NET
// The TriangularMatrix class resides in the Numerics.NET.LinearAlgebra
// namespace.
open Numerics.NET.LinearAlgebra

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Triangular matrices are matrices whose elements
// above or below the diagonal are all zero. The
// former is called lower triangular, the latter
// lower triangular. In addition, triangular matrices
// can have all 1's on the diagonal.

//
// Constructing triangular matrices
//

// Constructing triangular matrices is similar to
// constructing general matrices. See the
// BasicMatrices QuickStart samples for a more
// complete discussion.
//
// All constructors take a MatrixTriangle
// value as their first parameter. This indicates
// whether an upper or lower triangular matrix
// should be created. The following creates a
// 5x5 lower triangular matrix:
let t1 = Matrix.CreateLowerTriangular<float>(5, 5)
// You can also specify whether the diagonal
// consists of all 1's using a unitDiagonal parameter:
let t2 = Matrix.CreateLowerTriangular<float>(5, 5, MatrixDiagonal.UnitDiagonal)
// Triangular matrices access and modify only the
// elements that are non-zero. If the diagonal
// mode is UnitDiagonal, the diagonal elements
// are not used, since they are all equal to 1.
let elements =
    [|
        11.0; 12.0; 13.0; 14.0; 15.0;
        21.0; 22.0; 23.0; 24.0; 25.0;
        31.0; 32.0; 33.0; 34.0; 35.0;
        41.0; 42.0; 43.0; 44.0; 45.0;
        51.0; 52.0; 53.0; 54.0; 55.0
    |]
// The following creates a matrix using the
// upper triangular part of the above.
let t3 = Matrix.CreateUpperTriangular(5, 5, elements, MatrixElementOrder.RowMajor)
printfn "t3 = %O" t3
// Same as above, but unit diagonal:
let t4 =
    Matrix.CreateUpperTriangular(5, 5,
        elements, MatrixDiagonal.UnitDiagonal,
        MatrixElementOrder.RowMajor, true)
printfn "t4 = %O" t4

//
// Extracting triangular matrices
//

// You may want to use part of a dense matrix
// as a triangular matrix. The static
// ExtractUpperTriangle and ExtractLowerTriangle
// methods perform this task.
let m = Matrix.CreateFromArray(5, 5, elements, MatrixElementOrder.ColumnMajor)
printfn "m = %O" m
// Both methods are overloaded. The simplest
// returns a triangular matrix of the same dimension:
let t5 = Matrix.ExtractLowerTriangle(m)
printfn "t5 = %O" t5
// You can also specify if the matrix is unit diagonal:
let t6 = Matrix.ExtractUpperTriangle(m, MatrixDiagonal.UnitDiagonal)
printfn "t6 = %O" t6
// Or the dimensions of the matrix if they don't
// match the original:
let t7 = Matrix.ExtractUpperTriangle(m, 3, 3, MatrixDiagonal.UnitDiagonal)
printfn "t7 = %O" t7
printfn ""

//
// TriangularMatrix properties
//

// The IsLowerTriangular and IsUpperTriangular return
// a boolean value:
printfn "t4 is lower triangular? - %b" t4.IsLowerTriangular
printfn "t4 is upper triangular? - %b" t4.IsUpperTriangular
// The IsUnitDiagonal property indicates whether the
// matrix has all 1's on its diagonal:
printfn "t3 is unit diagonal? - %b" t3.IsUnitDiagonal
printfn "t4 is unit diagonal? - %b" t4.IsUnitDiagonal
printfn ""
// You can get and set matrix elements:
t3.[1, 3] <- 55.0
printfn "t3.[1, 3] = %O" t3.[1, 3]
// But trying to set an element that is zero or
// is on the diagonal for a unit diagonal matrix
// causes an exception to be thrown:
try
    t3.[3, 1] <- 100.0
with :? ComponentReadOnlyException as e -> printfn "Error accessing element: %s" e.Message

//
// Rows and columns
//

// The GetRow and GetColumn methods are
// available.
let row = t3.GetRow(1)
printfn "row 2 of t3 = %O" row
let column = t4.GetColumn(1, 0, 2)
printfn "2nd column of t4 from row 1 to 3 = %O" column
