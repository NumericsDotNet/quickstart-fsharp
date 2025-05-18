//=====================================================================
//
//  File: sparse-matrices.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module SparseMatrices

// Illustrates using sparse vectors and matrices using the classes
// in the Numerics.NET.LinearAlgebra namespace
// of Numerics.NET.

#light

open System

// The sparse vector and matrix classes reside in the
// Numerics.NET.LinearAlgebra namespace.
open Numerics.NET

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

//
// Sparse vectors
//

// The SparseVector class has three constructors. The
// first simply takes the length of the vector. All elements
// are initially zero.
let v1 = Vector.CreateSparse<float>(1000000)

// The second constructor lets you specify how many elements
// are expected to be nonzero. This 'fill factor' is a number
// between 0 and 1.
let v2 = Vector.CreateSparse<float>(1000000, 1e-4)

// The second constructor lets you specify how many elements
// are expected to be nonzero. This 'fill factor' is a number
// between 0 and 1.
let v3 = Vector.CreateSparse<float>(1000000, 100)

// The fourth constructor lets you specify the indexes of the nonzero
// elements and their values as arrays:
let indexes = [| 1; 10; 100; 1000; 10000 |]
let values = [| 1.0; 10.0; 100.0; 1000.0; 10000.0 |]
let v4 = Vector.CreateSparse(1000000, indexes, values)

// Elements can be accessed individually:
v1[1000] <- 2.0
printfn "v1[1000] = %A" v1[1000]

// The NonzeroCount returns how many elements are non zero:
printfn "v1 has %d nonzeros" v1.NonzeroCount
printfn "v4 has %d nonzeros" v4.NonzeroCount

// The NonzeroElements property returns a collection of
// IndexValuePair structures that you can use to iterate
// over the elements of the vector:
printfn "Nonzero elements of v4:"
for pair in v4.NonzeroElements do
    printfn "Element %d = %A" pair.Index pair.Value

// All other vector methods and properties are also available,
// Their implementations take advantage of sparsity.
printfn "Norm(v4) = %A" (v4.Norm())
printfn "Sum(v4) = %A" (v4.Sum())

// Note that some operations convert a sparse vector to a
// DenseVector, causing memory to be allocated for all
// elements.

//
// Sparse Matrices
//

// All sparse matrix classes inherit from SparseMatrix. This is an abstract class.
// There currently is only one implementation class:
// SparseCompressedColumnMatrix.

// Sparse matrices are created by calling the CreateSparse factory
// method on the Matrix class. It has 4 overloads:

// The first overload takes the number of rows and columns as arguments:
let m1 = Matrix.CreateSparse<float>(100000, 100000)

// The second overload adds a fill factor:
let m2 = Matrix.CreateSparse<float>(100000, 100000, 1e-5)

// The third overload uses the actual number of nonzero elements rather than
// the fraction:
let m3 = Matrix.CreateSparse<float>(10000, 10000, 20000)

// The fourth overload lets you specify the locations and values of the
// nonzero elements:
let rows = [| 1; 11; 111; 1111 |]
let columns = [| 2; 22; 222; 2222 |]
let matrixValues = [| 3.0; 33.0; 333.0; 3333.0 |]
let m4 = Matrix.CreateSparse(10000, 10000, rows, columns, matrixValues)

// You can access elements as before...
printfn "m4[111, 222] = %A" m4[111, 222]
m4[99, 22] <- 99.0

// A series of Insert methods lets you build a sparse matrix from scratch:
// A single value:
m1.InsertEntry(25.0, 200, 500)
// Multiple values:
m1.InsertEntries(matrixValues, rows, columns)
// Multiple values all in the same column:
m1.InsertColumn(33, values, indexes)
// Multiple values all in the same row:
m1.InsertRow(55, values, indexes)

// A clique is a 2-dimensional submatrix with indexed rows and columns.
let clique = Matrix.CreateFromArray(2, 2, [| 11.0; 12.0; 21.0; 22.0|],
    MatrixElementOrder.ColumnMajor)
let cliqueIndexes = [| 5; 8 |]
m1.InsertClique(clique, cliqueIndexes, cliqueIndexes)

// You can use the NonzeroElements collection to iterate
// over the nonzero elements of the matrix. The items
// are of type RowColumnValueTriplet:
printfn "Nonzero elements of m1:"
for triplet in m1.NonzeroElements do
    printfn "m1[%d,%d] = %A" triplet.Row triplet.Column triplet.Value

// ... including rows and columns.
let column = m4.GetColumn(22)
printfn "Nonzero elements in column 22 of m4:"
for pair in column.NonzeroElements do
    printfn "Element %d = %A" pair.Index pair.Value

// Many matrix methods have been optimized to take advantage of sparsity:
printfn "F-norm(m1) = %A" (m1.FrobeniusNorm())

// But beware: some revert to a dense algorithm and will fail on huge matrices:
try
    let inverse = m1.GetInverse()
    printfn "%O" inverse
with
| :? OutOfMemoryException as e -> printfn "%s" e.Message
