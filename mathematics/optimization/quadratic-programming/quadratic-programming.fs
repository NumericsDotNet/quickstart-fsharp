//=====================================================================
//
//  File: quadratic-programming.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module QuadraticProgramming

#light

open System

open Numerics.NET
// The quadratic programming classes reside in their own namespace.
open Numerics.NET.Optimization

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

/// Illustrates solving quadratic programming problems
/// using the classes in the Numerics.NET.Optimization
/// namespace of Numerics.NET.

// This QuickStart sample illustrates the quadratic programming
// functionality by solving a portfolio optimization problem.

// Portfolio optimization is a common application of QP.
// For a collection of assets, the goal is to minimize
// the risk (variance of the return) while achieving
// a minimal return for a set maximum amount invested.

// The variables are the amounts invested in each asset.
// The quadratic term is the covariance matrix of the assets.
// THere is no linear term in this case.

// There are three ways to create a Quadratic Program.

// The first is in terms of matrices. The coefficients
// of the constraints and the quadratic terms are supplied
// as matrices. The cost vector, right-hand side and
// constraints on the variables are supplied as vectors.

// The linear term in the objective function:
let c = Vector.CreateConstant(4, 0.0);
// The quaratic term in the objective function:
let R = Matrix.CreateSymmetric(4,
            [|   0.08;-0.05;-0.05;-0.05;
                -0.05; 0.16;-0.02;-0.02;
                -0.05;-0.02; 0.35; 0.06;
                -0.05;-0.02; 0.06; 0.35
            |], MatrixTriangle.Upper, MatrixElementOrder.ColumnMajor)
// The coefficients of the constraints:
let A = Matrix.CreateFromArray(2, 4,
            [|  1.0; 1.0; 1.0; 1.0;
                -0.05; 0.2; -0.15; -0.30
            |], MatrixElementOrder.RowMajor)
// The right-hand sides of the constraints:
let b = Vector.Create(10000.0, -1000.0)

// We're now ready to call the constructor.
// The last parameter specifies the number of equality
// constraints.
let qp1 = new QuadraticProgram(c, R, A, b, 0)

// Now we can call the Solve method to run the Revised
// Simplex algorithm:
let x1 = qp1.Solve()
printfn "Solution: %A" x1
// The optimal value is returned by the OptimalValue property:
printfn "Optimal value:   %A" qp1.OptimalValue

// The second way to create a Quadratic Program is by constructing
// it by hand. We start with an 'empty' quadratic program.
let qp2 = new QuadraticProgram()

// Next, we add two variables: we specify the name, the cost,
// and optionally the lower and upper bound.
qp2.AddVariable("X1", 0.0) |> ignore
qp2.AddVariable("X2", 0.0) |> ignore
qp2.AddVariable("X3", 0.0) |> ignore
qp2.AddVariable("X4", 0.0) |> ignore

// Next, we add constraints. Constraints also have a name.
// We also specify the coefficients of the variables,
// the lower bound and the upper bound.
qp2.AddLinearConstraint("C1", Vector.Create(1.0, 1.0, 1.0, 1.0), ConstraintType.LessThanOrEqual, 10000.0) |> ignore
qp2.AddLinearConstraint("C2", Vector.Create(0.05, -0.2, 0.15, 0.3), ConstraintType.GreaterThanOrEqual, 1000.0) |> ignore
// If a constraint is a simple equality or inequality constraint,
// you can supply a QuadraticProgramConstraintType value and the
// right-hand side of the constraint.

// Quadratic terms must be set individually.
// Each combination appears at most once.
qp2.SetQuadraticCoefficient("X1", "X1", 0.08) |> ignore
qp2.SetQuadraticCoefficient("X1", "X2", -0.05 * 2.0) |> ignore
qp2.SetQuadraticCoefficient("X1", "X3", -0.05 * 2.0) |> ignore
qp2.SetQuadraticCoefficient("X1", "X4", -0.05 * 2.0) |> ignore
qp2.SetQuadraticCoefficient("X2", "X2", 0.16) |> ignore
qp2.SetQuadraticCoefficient("X2", "X3", -0.02 * 2.0) |> ignore
qp2.SetQuadraticCoefficient("X2", "X4", -0.02 * 2.0) |> ignore
qp2.SetQuadraticCoefficient("X3", "X3", 0.35) |> ignore
qp2.SetQuadraticCoefficient("X3", "X4", 0.06 * 2.0) |> ignore
qp2.SetQuadraticCoefficient("X4", "X4", 0.35) |> ignore

// We can now solve the quadratic program:
let x2 = qp2.Solve()
printfn "Solution: %A" x2
printfn "Optimal value:   %A" qp2.OptimalValue

// Finally, we can create a quadratic program from an MPS file.
// The MPS format is a standard format.
let qp3 = MpsReader.ReadQuadraticProgram(@"..\..\..\..\..\data\portfolio.qps")
// We can go straight to solving the quadratic program:
let x3 = qp3.Solve()
printfn "Solution: %A" x3
printfn "Optimal value:   %A" qp3.OptimalValue
