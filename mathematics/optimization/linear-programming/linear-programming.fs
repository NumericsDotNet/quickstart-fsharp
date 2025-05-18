//=====================================================================
//
//  File: linear-programming.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module LinearProgramming

// Illustrates solving linear programming problems
// using the classes in the Numerics.NET.Optimization
// namespace of Numerics.NET.

#light

open System

// Vectors and matrices are in the Numerics.NET
// namespace
open Numerics.NET
// The linear programming classes reside in their own namespace.
open Numerics.NET.Optimization

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// This QuickStart sample illustrates the three ways to create a Linear Program.

// The first is in terms of matrices. The coefficients
// are supplied as a matrix. The cost vector, right-hand side
// and constraints on the variables are supplied as a vector.

// The cost vector:
let c = Vector.Create(-1.0, -3.0, 0.0, 0.0, 0.0, 0.0)
// The coefficients of the constraints:
let A =
    Matrix.CreateFromArray(4, 6,
        [|
            1.0; 1.0; 1.0; 0.0; 0.0; 0.0;
            1.0; 1.0; 0.0; -1.0; 0.0; 0.0;
            1.0; 0.0; 0.0; 0.0; 1.0; 0.0;
            0.0; 1.0; 0.0; 0.0; 0.0; 1.0
        |], MatrixElementOrder.RowMajor)
// The right-hand sides of the constraints:
let b = Vector.Create(1.5, 0.5, 1.0, 1.0)

// We're now ready to call the constructor.
// The last parameter specifies the number of equality
// constraints.
let lp1 = LinearProgram(c, A, b, 4)

// Now we can call the Solve method to run the Revised
// Simplex algorithm:
let x = lp1.Solve()
// The GetDualSolution method returns the dual solution:
let y = lp1.GetDualSolution()
printfn "Primal: %O" (x.ToString("F1"))
printfn "Dual:   %O" (y.ToString("F1"))
// The optimal value is returned by the OptimalValue property:
printfn "Optimal value:   %O" (lp1.OptimalValue.ToString("F1"))

// The second way to create a Linear Program is by constructing
// it by hand. We start with an 'empty' linear program.
let lp2 = LinearProgram()

// Next, we add two variables: we specify the name, the cost,
// and optionally the lower and upper bound.
// The method returns the new variable, which we ignore here.
lp2.AddVariable("X1", -1.0, 0.0, 1.0) |> ignore
lp2.AddVariable("X2", -3.0, 0.0, 1.0) |> ignore

// Next, we add constraints. Constraints also have a name.
// We also specify the coefficients of the variables,
// the lower bound and the upper bound.
lp2.AddLinearConstraint("C1", Vector.Create(1.0, 1.0), 0.5, 1.5) |> ignore
// If a constraint is a simple equality or inequality constraint,
// you can supply a LinearProgramConstraintType value and the
// right-hand side of the constraint.

// We can now solve the linear program:
let x2 = lp2.Solve()
let y2 = lp2.GetDualSolution()
printfn "Primal: %O" (x2.ToString("F1"))
printfn "Dual:   %O" (y2.ToString("F1"))
printfn "Optimal value:   %O" (lp2.OptimalValue.ToString("F1"))

// Finally, we can create a linear program from an MPS file.
// The MPS format is a standard format.
let lp3 = MpsReader.Read(@"..\..\..\..\..\data\sample.mps")
// We can go straight to solving the linear program:
let x3 = lp3.Solve()
let y3 = lp3.GetDualSolution()
printfn "Primal: %O" (x3.ToString("F1"))
printfn "Dual:   %O" (y3.ToString("F1"))
printfn "Optimal value:   %O" (lp3.OptimalValue.ToString("F1"))
