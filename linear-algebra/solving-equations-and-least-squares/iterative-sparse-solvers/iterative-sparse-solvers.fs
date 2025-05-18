//=====================================================================
//
//  File: iterative-sparse-solvers.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module IterativeSparseSolvers

// Illustrates the use of iterative sparse solvers for efficiently
// solving large, sparse systems of linear equations using the
// iterative sparse solver and preconditioner classes from the
// Numerics.NET.LinearAlgebra.IterativeSolvers namespace of Numerics.NET.

#light

open System

open Numerics.NET;
// Sparse matrices are in the Numerics.NET.LinearAlgebra
// namespace
open Numerics.NET.LinearAlgebra;
open Numerics.NET.LinearAlgebra.IterativeSolvers;
open Numerics.NET.LinearAlgebra.IterativeSolvers.Preconditioners;
// We'll read a sparse matrix from a file:
open Numerics.NET.Data.Text;

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// This QuickStart Sample illustrates how to solve sparse linear systems
// using iterative solvers.

// IterativeSparseSolver<T> is the base class for all
// iterative solver classes.

//
// Non-symmetric systems
//

printfn "Non-symmetric systems"

// We load a sparse matrix and right-hand side from a data file:
let A = MatrixMarketFile.ReadMatrix<double>("..\..\..\..\..\data\sherman3.mtx") :?> SparseCompressedColumnMatrix<float>
let b = MatrixMarketFile.ReadMatrix<double>("..\..\..\..\..\data\sherman3_rhs1.mtx").GetColumn(0)

printfn "Solve Ax = b"
printfn "A is %dx%d with %d nonzeros." A.RowCount A.ColumnCount A.NonzeroCount

// Some solvers are suitable for symmetric matrices only.
// Our matrix is not symmetric, so we need a solver that
// can handle this:
let solver = new BiConjugateGradientSolver<float>(A);

solver.Solve(b) |> ignore
printfn "Solved in %d iterations." solver.IterationsNeeded
printfn "Estimated error: %e" solver.SolutionReport.Error

// Using a preconditioner can improve convergence. You can use
// one of the predefined preconditioners, or supply your own.

// With incomplete LU preconditioner
solver.Preconditioner <- new IncompleteLUPreconditioner<float>(A);
solver.Solve(b) |> ignore
printfn "Solved in %d iterations." solver.IterationsNeeded
printfn "Estimated error: %e" solver.SolutionReport.Error

//
// Symmetrical systems
//

printfn "Symmetric systems"

// In this example we solve the Laplace equation on a rectangular grid
// with Dirichlet boundary conditions.

// We create 100 divisions in each direction, giving us 99 interior points
// in each direction:
let nx = 99
let ny = 99

// The boundary conditions are just some arbitrary functions.
let itoy i = (float i / float (ny + 1))
let left = Vector.CreateFromFunction(ny, (fun i -> let x = itoy i in x * x))
let right = Vector.CreateFromFunction(ny, fun i -> 1.0 - (itoy i));
let itox i = (float i / float (nx + 1))
let top = Vector.CreateFromFunction(nx, fun i -> Elementary.SinPi(5.0 * (itox i)));
let bottom = Vector.CreateFromFunction(nx, fun i -> Elementary.CosPi(5.0 * (itox i)));

// We discretize the Laplace operator using the 5 point stencil.
let laplacian = Matrix.CreateSparse(nx * ny, nx * ny, 5 * nx * ny);
let rhs = Vector.Create<float>(nx * ny)
for j in 0..ny-1 do
    for i in 0..nx-1 do
        let ix = j * nx + i;
        if (j > 0) then laplacian.[ix, ix - nx] <- 0.25;
        if (i > 0) then laplacian.[ix, ix - 1] <- 0.25;
        laplacian.[ix, ix] <- -1.0;
        if (i + 1 < nx) then laplacian.[ix, ix + 1] <- 0.25;
        if (j + 1 < ny) then laplacian.[ix, ix + nx] <- 0.25;

// We build up the right-hand sides using the boundary conditions:
for i in 0..nx-1 do
    rhs.[i] <- -0.25 * top.[i]
    rhs.[nx * (ny - 1) + i] <- -0.25 * bottom.[i];

for j in 0..ny-1 do
    rhs.[j * nx] <- rhs.[j * nx] - 0.25 * left.[j];
    rhs.[j * nx + nx - 1] <- rhs.[j * nx + nx - 1] - 0.25 * right.[j];

// Finally, we create an iterative solver suitable for
// symmetric systems...
let solver2 = new QuasiMinimalResidualSolver<float>(laplacian);
// and solve using the right-hand side we just calculated:
solver2.Solve(rhs) |> ignore;

printfn "Solve Ax = b"
printfn "A is %dx%d with %d nonzeros." laplacian.RowCount laplacian.ColumnCount laplacian.NonzeroCount
printfn "Solved in %d iterations." solver2.IterationsNeeded
printfn "Estimated error: %e" solver2.EstimatedError
