//=====================================================================
//
//  File: matrix-decompositions.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module MatrixDecompositions

// Illustrates the use of matrix decompositions for solving systems of
// simultaneous linear equations and related operations using the
// Decomposition class and its derived classes from the
// Numerics.NET.LinearAlgebra namespace of Numerics.NET.

#light

open System

// The Vector and Matrix classes reside in the
// Numerics.NET namespace.
open Numerics.NET

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// For details on the basic workings of Vector
// objects; including constructing; copying and
// cloning vectors; see the BasicVectors QuickStart
// Sample.
//
// For details on the basic workings of Matrix
// objects; including constructing; copying and
// cloning vectors; see the BasicVectors QuickStart
// Sample.
//

//
// LU Decomposition
//

// The LU decomposition of a matrix rewrites a matrix A in the
// form A = PLU with P a permutation matrix; L a unit-
// lower triangular matrix; and U an upper triangular matrix.

let aLU =
    Matrix.CreateFromArray(4, 4,
        [|
            1.80; 5.25; 1.58; -1.11;
            2.88;-2.95; -2.69; -0.66;
            2.05;-0.95; -2.90; -0.59;
            -0.89;-3.80;-1.04; 0.80
        |], MatrixElementOrder.ColumnMajor)

let bLU =
    Matrix.CreateFromArray(4, 2,
        [|
            9.52;24.35;0.77;-6.22;
            18.47;2.25;-13.28;-6.21
        |], MatrixElementOrder.ColumnMajor)

// The decomposition is obtained by calling the GetLUDecomposition
// method of the matrix. It takes zero or one parameters. The
// parameter is a bool value that indicates whether the
// matrix may be overwritten with its decomposition.
let lu = aLU.GetLUDecomposition(true)
printfn "A = %s" (aLU.ToString("F2"))

// The Decompose method performs the decomposition. You don't need
// to call it explicitly; as it is called automatically as needed.

// The IsSingular method checks for singularity.
printfn "'A is singular' is %b." (lu.IsSingular())
// The LowerTriangularFactor and UpperTriangularFactor properties
// return the two main components of the decomposition.
printfn "L = %s" (lu.LowerTriangularFactor.ToString("F6"))
printfn "U = %s" (lu.UpperTriangularFactor.ToString("F6"))

// GetInverse() gives the matrix inverse; Determinant() the determinant:
printfn "Inv A = %s" (lu.GetInverse().ToString("F6"))
printfn "Det A = %s" (lu.GetDeterminant().ToString("F6"))

// The Solve method solves a system of simultaneous linear equations; with
// one or more right-hand-sides:
let xLU = lu.Solve(bLU)
printfn "x = %s" (xLU.ToString("F6"))

// The permutation is available through the RowPermutation property:
printfn "P = %O" lu.RowPermutation
printfn "Px = %s" (xLU.PermuteRowsInPlace(lu.RowPermutation).ToString("F6"))

//
// QR Decomposition
//

// The QR decomposition of a matrix A rewrites the matrix
// in the form A = QR; with Q a square; orthogonal matrix;
// and R an upper triangular matrix.

let aQR =
    Matrix.CreateFromArray(5, 3,
        [|
            2.0; 2.0; 1.6; 2.0; 1.2;
            2.5; 2.5;-0.4;-0.5;-0.3;
            2.5; 2.5; 2.8; 0.5;-2.9
        |], MatrixElementOrder.ColumnMajor)
let bQR = Vector.Create(1.1, 0.9, 0.6, 0.0,-0.8)

// The decomposition is obtained by calling the GetQRDecomposition
// method of the matrix. It takes zero or one parameters. The
// parameter is a bool value that indicates whether the
// matrix may be overwritten with its decomposition.
let qr = aQR.GetQRDecomposition(true)
printfn "A = %s" (aQR.ToString("F1"))

// The Decompose method performs the decomposition. You don't need
// to call it explicitly; as it is called automatically as needed.

// The IsSingular method checks for singularity.
printfn "'A is singular' is %b" (qr.IsSingular())

// GetInverse() gives the matrix inverse; Determinant() the determinant;
// but these are defined only for square matrices.

// The Solve method solves a system of simultaneous linear equations; with
// one or more right-hand-sides. If the matrix is over-determined; you can
// use the LeastSquaresSolve method to find a least squares solution:
let xQR = qr.LeastSquaresSolve(bQR)
printfn "x = %s" (xQR.ToString("F6"))

// The OrthogonalFactor and UpperTriangularFactor properties
// return the two main components of the decomposition.
printfn "Q = %s" (qr.OrthogonalFactor.ToDenseMatrix().ToString("F6"))
printfn "R = %s" (qr.UpperTriangularFactor.ToString("F6"))

// You don't usually need to form Q explicitly. You can multiply
// a vector or matrix on either side by Q using the Multiply method:
printfn "Qx = %s" ((qr.OrthogonalFactor * bQR).ToString("F6"))
printfn "transpose(Q)x = %s"
    ((qr.OrthogonalFactor.Transpose() * bQR).ToString("F6"))

//
// Singular Value Decomposition
//

// The singular value decomposition of a matrix A rewrites the matrix
// in the form A = USVt; with U and V orthogonal matrices;
// S a diagonal matrix. The diagonal elements of S are called
// the singular values.

let aSvd =
    Matrix.CreateFromArray(3, 5,
        [|
            2.0; 2.0; 1.6; 2.0; 1.2;
            2.5; 2.5;-0.4;-0.5;-0.3;
            2.5; 2.5; 2.8; 0.5;-2.9
        |], MatrixElementOrder.RowMajor)
let bSvd = Vector.Create(1.1, 0.9, 0.6)

// The decomposition is obtained by calling the GetSingularValueDecomposition
// method of the matrix. It takes zero or one parameters. The
// parameter indicates which parts of the decomposition
// are to be calculated. The default is All.
let svd = aSvd.GetSingularValueDecomposition()
printfn "A = %s" (aSvd.ToString("F1"))

// The Decompose method performs the decomposition. You don't need
// to call it explicitly; as it is called automatically as needed.

// The IsSingular method checks for singularity.
printfn "'A is singular' is %b." (svd.IsSingular())

// Several methods are specific to this class. The GetPseudoInverse
// method returns the Moore-Penrose pseudo-inverse; a generalization
// of the inverse of a matrix to rectangular and/or singular matrices:
let aInv = svd.GetPseudoInverse()

// It can be used to solve over- or under-determined systems.
let xSvd = aInv * bSvd
printfn "x = %s" (xSvd.ToString("F6"))

// The SingularValues property returns a vector that contains
// the singular values in descending order:
printfn "S = %s" (svd.SingularValues.ToString("F6"))

// The LeftSingularVectors and RightSingularVectors properties
// return matrices that contain the U and V factors
// of the decomposition.
printfn "U = %s" (svd.LeftSingularVectors.ToString("F6"))
printfn "V = %s" (svd.RightSingularVectors.ToString("F6"))

//
// Cholesky decomposition
//

// The Cholesky decomposition of a symmetric matrix A
// rewrites the matrix in the form A = GGt with
// G a lower-triangular matrix.

// Remember the column-major storage mode: each line of
// components contains one COLUMN of the matrix.
let aC =
    Matrix.CreateSymmetric(4,
        [|
            4.16;-3.12; 0.56;-0.10;
            0.00; 5.03;-0.83; 1.18;
            0.00; 0.00; 0.76; 0.34;
            0.00; 0.00; 0.00; 1.18
        |], MatrixTriangle.Lower, MatrixElementOrder.ColumnMajor)
let bC =
    Matrix.CreateFromArray(4, 2,
        [| 8.70;-13.35;1.89;-4.14;8.30;2.13;1.61;5.00 |],
        MatrixElementOrder.ColumnMajor)

// The decomposition is obtained by calling the GetCholeskyDecomposition
// method of the matrix. It takes zero or one parameters. The
// parameter is a bool value that indicates whether the
// matrix should be overwritten with its decomposition.
let c = aC.GetCholeskyDecomposition(true)
printfn "A = %s" (aC.ToString("F2"))

// The Decompose method performs the decomposition. You don't need
// to call it explicitly; as it is called automatically as needed.

// The IsSingular method checks for singularity.
printfn "'A is singular' is %b." (c.IsSingular())
// The LowerTriangularFactor returns the component of the decomposition.
printfn "L = %s" (c.LowerTriangularFactor.ToString("F6"))

// GetInverse() gives the matrix inverse; Determinant() the determinant:
printfn "Inv A = %s" (c.GetInverse().ToString("F6"))
printfn "Det A = %s" (c.GetDeterminant().ToString("F6"))

// The Solve method solves a system of simultaneous linear equations; with
// one or more right-hand-sides:
let xC = c.Solve(bC)
printfn "x = %s" (xC.ToString("F6"))

//
// Symmetric eigenvalue decomposition
//

// The eigenvalue decomposition of a symmetric matrix A
// rewrites the matrix in the form A = XLXt with
// X an orthogonal matrix and L a diagonal matrix.
// The diagonal elements of L are the eigenvalues.
// The columns of X are the eigenvectors.

// Remember the column-major storage mode: each line of
// components contains one COLUMN of the matrix.
let aEig =
    Matrix.CreateSymmetric(4,
        [|
          0.5;  0.0;  2.3; -2.6;
          0.0;  0.5; -1.4; -0.7;
          2.3; -1.4;  0.5;  0.0;
         -2.6; -0.7;  0.0;  0.5
        |], MatrixTriangle.Lower, MatrixElementOrder.ColumnMajor)

// The decomposition is obtained by calling the GetLUDecomposition
// method of the matrix. It takes zero or one parameters. The
// parameter is a bool value that indicates whether the
// matrix should be overwritten with its decomposition.
let eig = aEig.GetEigenvalueDecomposition()
printfn "A = %s" (aEig.ToString("F1"))

// The Decompose method performs the decomposition. You don't need
// to call it explicitly; as it is called automatically as needed.

// The IsSingular method checks for singularity.
printfn "'A is singular' is %b." (eig.IsSingular())
// The eigenvalues and eigenvectors of a symmetric matrix are all real.
// The RealEigenvalues property returns a vector containing the eigenvalues:
printfn "L = %s" (eig.Eigenvalues.ToString("F6"))
// The RealEigenvectors property returns a matrix whose columns
// contain the corresponding eigenvectors:
printfn "X = %s" (eig.Eigenvectors.ToString("F6"))

// GetInverse() gives the matrix inverse; Determinant() the determinant:
printfn "Inv A = %s" (eig.GetInverse().ToString("F6"))
printfn "Det A = %s" (eig.GetDeterminant().ToString("F6"))
