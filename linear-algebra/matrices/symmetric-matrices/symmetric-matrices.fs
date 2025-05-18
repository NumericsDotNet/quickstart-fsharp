//=====================================================================
//
//  File: symmetric-matrices.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module SymmetricMatrices

// Illustrates the use of the SymmetricMatrix class in the
// Numerics.NET.LinearAlgebra namespace of Numerics.NET.

#light

open System

open Numerics.NET
// The SymmetricMatrix class resides in the Numerics.NET.LinearAlgebra
// namespace.
open Numerics.NET.LinearAlgebra

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Symmetric matrices are matrices whose elements
// are symmetrical around the main diagonal.
// Symmetric matrices are always square, and are
// equal to their own transpose.

//
// Constructing symmetric matrices
//

// Constructing symmetric matrices is similar to
// constructing general matrices. See the
// BasicMatrices QuickStart samples for a more
// complete discussion.

// Symmetric matrices are always square. You don't
// have to specify both the number of rows and the
// number of columns.
//
// The following creates a 5x5 symmetric matrix:
let s1 = Matrix.CreateSymmetric<float>(5)
// Symmetric matrices access and modify only the
// elements on and either above or below the
// main diagonal. When initializing a
// symmetric matrix in a constructor, you must
// specify a triangleMode parameter that specifies
// whether to use the upper or lower triangle:
let elements =
    [|
        11.0; 12.0; 13.0; 14.0; 15.0;
        21.0; 22.0; 23.0; 24.0; 25.0;
        31.0; 32.0; 33.0; 34.0; 35.0;
        41.0; 42.0; 43.0; 44.0; 45.0;
        51.0; 52.0; 53.0; 54.0; 55.0
    |]
let s2 = Matrix.CreateSymmetric(5, elements,
            MatrixTriangle.Upper, MatrixElementOrder.ColumnMajor)
printfn "s2 = %O" s2

// You can also create a symmetric matrix by
// multiplying any matrix by its transpose:
let m =
    Matrix.CreateFromArray(
        3, 4,
        [|
            1.0; 2.0; 3.0;
            2.0; 3.0; 4.0;
            3.0; 4.0; 5.0;
            4.0; 5.0; 7.0
        |], MatrixElementOrder.ColumnMajor)
printfn "m = %O" m
// This calculates transpose(m) times m:
let s3 = SymmetricMatrix<float>.FromOuterProduct(m)
printfn "s3 = %O" s3
// An optional 'side' parameter lets you specify
// whether the left or right operand of the
// multiplication is the transposed matrix.
// This calculates m times transpose(m):
let s4 = SymmetricMatrix<float>.FromOuterProduct(m, MatrixOperationSide.Right)
printfn "s4 = %O" s4

//
// SymmetricMatrix methods
//

// The GetEigenvalues method returns a vector
// containing the eigenvalues.
let l = s4.GetEigenvalues()
printfn "Eigenvalues: %s" (l.ToString("F4"))

// The ApplyMatrixFunction calculates a function
// of the entire matrix. For example, to calculate
// the 'sine' of a matrix:
let sinS = s4.ApplyMatrixFunction(new Func<double, double>(Math.Sin))
printfn "sin(s4): %s" (sinS.ToString("F4"))

// Symmetric matrices don't have any specific
// properties.

// You can get and set matrix elements:
s3.[1, 3] <- 55.0
printfn "s3.[1, 3] = %.0f" s3.[1, 3]
// And the change will automatically be reflected
// in the symmetric element:
printfn "s3.[3, 1] = %.0f" s3.[3, 1]

//
// Row and column views
//

// The GetRow and GetColumn methods are
// available.
let row = s2.GetRow(1)
printfn "row 1 of s2 = %O" row
let column = s2.GetColumn(2, 3, 4)
printfn "column 3 of s2 from row 4 to "
printfn "  row 5 = %O" column
