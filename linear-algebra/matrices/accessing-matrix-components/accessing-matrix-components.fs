//=====================================================================
//
//  File: accessing-matrix-components.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module AccessingMatrixComponents

// Illustrates accessing matrix elements and iterating
// through the rows and columns of a matrix. Matrix classes
// reside in the Numerics.NET.LinearAlgebra namespace
// of Numerics.NET.

open System

open Numerics.NET.FSharp
open Numerics.NET
// The Vector and Vector classes resides in the
// Numerics.NET.LinearAlgebra namespace.
open Numerics.NET.LinearAlgebra

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// We'll work with this matrix:
let m = Matrix.CreateFromArray(2, 3, [| 1.0; 2.0; 3.0; 4.0; 5.0; 6.0 |],
    MatrixElementOrder.ColumnMajor)

//
// Individual elements
//
// The Matrix class has an indexer property that takes two arguments:
// the row and column index. Both are zero based.
printfn "m.[1,1] = %f" m.[1, 1]

//
// Rows and columns
//

// Indexed range access

// The indexer property is overloaded to allow for direct indexed access
// to complete or partial rows or columns.

let row1 = m.[0, new Range(1, 2)]
// This prints "[3, 5]":
printfn "row1 = %A" row1

// The special range Range.All lets you access an entire row
// or column without having to specify any details about the range.
let row2 = m.[1, Range.All]
// This prints "[2, 4, 6]":
printfn "2nd row = %A" row2

// You can also use F# slicing syntax (*) instead of Range.All:
let column1 = m.[*, 0]
// This prints "[1, 2]":
printfn "column1 = %A" column1

// We can assign to rows and columns, too:
m.[*, 0] <- row1
// This prints "[[3, 3, 5] [5, 4, 6]]"
printfn "m = %A" m

// GetRow and GetColumn provide an alternate mechanism
// for achieving the same result.

// Passing just one parameter retrieves the specified row or column:
let row3 = m.GetRow(1)
// This prints "[2, 4, 6]":
printfn "row3 = %A" row1
let column3 = m.GetColumn(1)
// This prints "[3, 4]":
printfn "column3 = %A" column3

// You can also pass a start and end index:
let row4 = m.GetRow(0, 1, 2)
// This prints "[3, 5]":
printfn "row4 = %A" row4
// Or using F# slicing syntax:
let row4_2 = m.[0, 1..2]
// This prints "[3, 5]":
printfn "row4 = %A" row4_2

// We can assign to rows and columns, too, using CopyTo:
row4.CopyTo(m.GetColumn(0)) |> ignore
// This prints "[[3, 3, 5] [5, 4, 6]]"
printfn "m = %A" m

// Enumeration

// The Rows and Columns methods allow you to enumerate over
// the rows and columns of a matrix.

// For example: this calculates the sum of the absolute values
// of the elements of the matrix m:
let mutable sum = 0.0
for column in m.Columns do
    sum <- sum + column.OneNorm()

//
// Accessing diagonals
//

// Diagonals are retrieved using the GetDiagonal method:
let mainDiagonal = m.GetDiagonal()
// An optional parameter specifies which diagonal:
//   n < 0 means subdiagonal
//   n > 0 means nth superdiagonal:
let superDiagonal = m.GetDiagonal(1)

//
// Accessing submatrices
//

// Indexed range access

// A fourth overload of the indexer property lets you
// extract a part of a matrix. Both parameters are Range
// structures:
let a = Matrix.Create<float>(10, 10)
// Extract the 2nd to the 5th row of m:
let a1 = a.[1..4, *]
// Extract the odd columns.
// F# slice syntax doesn't support strides
// so we have to use Range structures here:
let a2 = a.[Range.All, new Range(1, 9, 2)]
// Extract the 4x4 leading submatrix of m:
let a3 = a.[0..3, 0..3]

// You can also assign to submatrices:
let identity5 = DenseMatrix<double>.GetIdentity(5)
a.[0..4, 5..9] <- identity5
a.[5..9, 0..4] <- identity5

// The same results can be achieved with the GetSubmatrix method.

// Extract the 2nd to the 5th row of m.
// Start and end columns are supplied manually.
let a4 = a.GetSubmatrix(1, 4, 0, 9)
// Extract the odd columns:
// Here we need to supply the transpose parameter.
let a5 = a.GetSubmatrix(0, 9, 1, 1, 9, 2, TransposeOperation.None)
// Extract the 4x4 leading submatrix of m.
// And let's get its transpose, just because we can.
// We need to specify the row and column stride:
let a6 = a.GetSubmatrix(0, 3, 1, 0, 3, 1, TransposeOperation.Transpose)

// You can still assign to submatrices, using the
// CopyTo method:
identity5.CopyTo(a.GetSubmatrix(0, 4, 5, 9)) |> ignore
identity5.CopyTo(a.GetSubmatrix(5, 9, 0, 4)) |> ignore
