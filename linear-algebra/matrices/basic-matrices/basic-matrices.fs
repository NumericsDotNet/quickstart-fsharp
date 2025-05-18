//=====================================================================
//
//  File: basic-matrices.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module BasicMatrices

// Illustrates the use of the Matrix class in the
// Numerics.NET namespace of Numerics.NET.

#light

open System

// The Matrix class resides in the Numerics.NET namespace.
open Numerics.NET
open Numerics.NET.LinearAlgebra

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

//
// Constructing matrices
//

// Option #1: specify number of rows and columns.
// The following constructs a matrix with 3 rows
// and 5 columns:
let m1 = Matrix.Create(3, 5)
printfn "m1 = %O" m1
// Option #2: specify a rank 2 double array.
// By default, elements are taken in column-major
// order. Therefore, the following creates a matrix
// with 3 rows and 4 columns:
let m2 =
    Matrix.Create(array2D
        [|
            [1.0; 2.0; 3.0]
            [2.0; 3.0; 4.0]
            [3.0; 4.0; 5.0]
            [4.0; 5.0; 6.0]
        |])
printfn "m2 = %O" m2

let m3 = m2
// Option #4: Specify component array, and number
// of rows and columns. The elements are listed
// in column-major order. The following matrix
// is identical to m3:
let elements =
    [|
        1.0; 2.0; 3.0;
        2.0; 3.0; 4.0;
        3.0; 4.0; 5.0;
        4.0; 5.0; 6.0
    |]
let m4 = Matrix.CreateFromArray(3, 4, elements, MatrixElementOrder.ColumnMajor)
printfn "m4 = %O" m4
// Option #5: same as above, but specify element
// order. The following matrix is identical to m4:
let m5 = Matrix.CreateFromArray(4, 3, elements, MatrixElementOrder.RowMajor)
printfn "m5 = %O" m5
// Option #6: same as #4, but specify whether to copy
// the matrix elements, or use the specified array
// as internal storage.
let m6 = Matrix.CreateFromArray(3, 4, elements, MatrixElementOrder.ColumnMajor, false)
// Option #7: same as #5, but specify whether to copy
// the matrix elements, or use the specified array
// as internal storage.
let m7 = Matrix.CreateFromArray(4, 3, elements, MatrixElementOrder.RowMajor, false)
// In addition, you can also create an identity
// matrix by calling the static GetIdentity method.
// The following constructs a 4x4 identity matrix:
let m8 = DenseMatrix<float>.GetIdentity(4)
printfn "m8 = %O" m8

//
// DenseMatrix properties
//

// The RowCount and ColumnCount properties give the
// number of rows and columns, respectively:
printfn "m1.RowCount = %d" m1.RowCount
printfn "m1.ColumnCount = %d" m1.ColumnCount
// The ToArray method returns a one-dimensional
// double array that contains the elements of the
// vector. By default, elements are returned in
// column major order. This is always a copy:
let components3 = m3.ToArray()
printfn "elements:"
printfn "elements[3] = %A" components3[3]
components3[3] <- 1.0
printfn "m3[0,1] = %A" m3[0,1]
// The ToArray method is overloaded, so you can
// choose whether you want the elements in row major
// or in column major order. The order parameter is
// of type MatrixElementOrder:
let components3a = m3.ToArray(MatrixElementOrder.RowMajor)
printfn "In row major order:"
printfn "elements[3] = %A" components3a[3]

//
// Accessing matrix elements
//

// The DenseMatrix class defines an indexer property
// that takes zero-based row and column indices.
printfn "Assigning with private storage:"
printfn "m1[0,2] = %A" m1[0,2]
// You can assign to this property:
m1[0,2] <- 7.0
printfn "m1[0,2] = %A" m1[0,2]

// The matrices m6 and m7 had the copy parameter in
// the constructor set to false. As a result, they
// share their component storage. Changing one vector
// also changes the other:
printfn "Assigning with shared storage:"
printfn "m6[0,0] = %A" m6[0,0]
m7[0,0] <- 3.0
printfn "m6[0,0] = %A" m6[0,0]

//
// Copying and cloning matrices
//

// A shallow copy of a matrix constructs a matrix
// that shares the component storage with the original.
// This is done using the ShallowCopy method. Note
// that we have to cast the return value since it is
// of type Matrix, the abstract base type of all
// the matrix classes:
printfn "Shallow copy vs. clone:"
let m10 = m2.ShallowCopy()
// The clone method creates a full copy.
let m11 = m2.Clone()
// When we change m2, m10 changes, but m11 is left unchanged:
printfn "m2[1,1] = %A" m2[1,1]
m2[1,1] <- -2.0
printfn "m10[1,1] = %A" m10[1,1]
printfn "m11[1,1] = %A" m11[1,1]
// We can give a matrix its own component storage
// by calling the CloneData method:
printfn "CloneData:"
m11.CloneData()
// Now, changing the original v2 no longer changes v7:
m2[1,1] <- 4.0
printfn "m11[1,1] = %A" m11[1,1]

