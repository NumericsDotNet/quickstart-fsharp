//=====================================================================
//
//  File: matrix-vector-operations.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module MatrixVectorOperations

// Illustrates operations on DenseMatrix objects and combined
// operations on Vector and DenseMatrix objects from the
// Numerics.NET.LinearAlgebra namespace of Numerics.NET.

// Illustrates operations on DenseMatrix objects and combined
// operations on Vector and Matrix objects from the
// Numerics.NET namespace of Numerics.NET.

#light

open System

// The Vector and Matrix classes reside in the
// Numerics.NET namespace.
open Numerics.NET
open Numerics.NET.LinearAlgebra

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// For details on the basic workings of Vector
// objects, including constructing, copying and
// cloning vectors, see the BasicVectors QuickStart
// Sample.
//
// For details on the basic workings of DenseMatrix
// objects, including constructing, copying and
// cloning vectors, see the BasicVectors QuickStart
// Sample.
//
// Let's create some vectors to work with.
let v1 = Vector.Create(1.0, 2.0, 3.0, 4.0, 5.0)
let v2 = Vector.Create(1.0, -2.0, 3.0, -4.0, 5.0)
printfn "v1 = %O" (v1.ToString("F4"))
printfn "v2 = %O" (v2.ToString("F4"))

// Also, here are a couple of matrices.
// We start out with a 5x5 identity matrix:
let m1 = DenseMatrix<float>.GetIdentity(5)
// Now we use the GetDiagonal method and combine it
// with the SetValue method of the Vector class to
// set some of the off-diagonal elements.
// This is a fluent API. We ignore the return value:
m1.GetDiagonal(1).SetValue(2.0) |> ignore
m1.GetDiagonal(2).SetValue(3.0) |> ignore
m1.GetDiagonal(-1).SetValue(4.0) |> ignore
printfn "m1 = %O" (m1.ToString("F4"))
// We define our second matrix by hand:
let m2 =
    Matrix.CreateFromArray(5, 5,
        [|
            1.0; 2.0; 3.0; 4.0;  5.0;
            1.0; 3.0; 5.0; 7.0;  9.0;
            1.0; 4.0; 9.0;16.0; 25.0;
            1.0; 8.0;27.0;64.0;125.0;
            1.0;-1.0; 1.0;-1.0;  1.0
        |], MatrixElementOrder.ColumnMajor)
printfn "m2 = %O" (m2.ToString("F4"))
printfn ""

//
// Matrix arithmetic
//

// The Matrix class defines operator overloads for
// addition, subtraction, and multiplication of
// matrices.

// Addition:
printfn "Matrix arithmetic:"
printfn "m1 + m2 = %O" ((m1 + m2).ToString("F4"))
// Subtraction:
printfn "m1 - m2 = %O" ((m1 - m2).ToString("F4"))
// Multiplication is the true matrix product:
printfn "m1 * m2 = %O" ((m1 * m2).ToString("F4"))
// For F#, we have elementwise multiplication:
printfn "m1 .* m2 = %O" ((m1 .* m2).ToString("F4"))
// and elementwise division:
printfn "m1 ./ m2 = %O" ((m1 ./ m2).ToString("F4"))
printfn ""

//
// Matrix-Vector products
//

// The DenseMatrix class defines overloaded addition,
// subtraction, and multiplication operators
// for vectors and matrices:
printfn "Matrix-vector products:"
printfn "m1 v1 = %O" ((m1 * v1).ToString("F4"))
// You can also multiply a vector by a matrix on the right.
// This is equivalent to multiplying on the left by the
// transpose of the matrix:
printfn "v1 m1 = %O" ((v1 * m1).ToString("F4"))

let v = v2
// Now for some methods of the Vector class that
// involve matrices:
// Add a product of a matrix and a vector:
printfn "v + m1 v1 = %O" (v.AddProduct(m1, v1).ToString("F4"))
// Or add a scaled product:
printfn "v - 2 m1 v2 = %O" (v.AddScaledProduct(-2.0, m1, v2).ToString("F4"))
// You can also use static Subtract methods:

printfn "v - m1 v1 = %O" (v.AddScaledProduct(-1.0, m1, v1).ToString("F4"))
printfn ""

//
// Matrix norms
//
printfn "Matrix norms"
// Matrix norms are not as easily defined as
// vector norms. Three matrix norms are available.
// 1. The one-norm through the OneNorm property:
printfn "OneNorm of m2 = %.4f" (m2.OneNorm())
// 2. The infinity norm through the
//    InfinityNorm property:
printfn "InfinityNorm of m2 = %.4f" (m2.InfinityNorm())
// 3. The Frobenius norm is often used because it
//    is easy to calculate.
printfn "FrobeniusNorm of m2 = %.4f" (m2.FrobeniusNorm())
printfn ""

// The trace of a matrix is the sum of its diagonal
// elements. It is returned by the Trace property:
printfn "Trace(m2) = %.4f" (m2.Trace())

// The Transpose method returns the transpose of a
// matrix. This transposed matrix shares element storage
// with the original matrix. Use the CloneData method
// to give the transpose its own data storage.
printfn "Transpose(m2) = %O" (m2.Transpose().ToString("F4"))
