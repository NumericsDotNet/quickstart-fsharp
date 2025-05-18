//=====================================================================
//
//  File: nonlinear-programming.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module NonlinearProgramming

#light

open System

open Numerics.NET
// The nonlinear programming classes reside in their own namespace.
open Numerics.NET.Optimization

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

/// Illustrates solving nonlinear programming problems
/// using the classes in the Numerics.NET.Optimization
/// namespace of Numerics.NET.

// This QuickStart Sample illustrates the two ways to create a Nonlinear Program.

// The first is in terms of matrices. The coefficients of the linear constraints
// are supplied as a matrix. The cost vector, right-hand side
// and constraints on the variables are supplied as a vector.

printfn "Problem with only linear constraints:"

// The variables are the concentrations of each chemical compound:
// H, H2, H2O, N, N2, NH, NO, O, O2, OH

// The objective function is the free energy, which we want to minimize:
let c = Vector.Create(-6.089, -17.164, -34.054, -5.914, -24.721, -14.986, -24.100, -10.708, -26.662, -22.179);
let objectiveFunction = fun (x : Vector<float>) -> x.DotProduct(c + Vector.Log(x) - log(x.Sum()));
let objectiveGradient = fun (x : Vector<float>) -> fun (y : Vector<float>) ->
    let s = x.Sum();
    (c + Vector.Log(x) - Math.Log(s) + 1.0 - x / s).CopyTo(y)

// The constraints are the mass balance relationships for each element.
// The rows correspond to the elements H, N, and O.
// The columns are the index of the variable.
// The value is the number of times the element occurs in the
// compound corresponding to the variable:
// H, H2, H2O, N, N2, NH, NO, O, O2, OH
// All this is stored in a sparse matrix, so 0 values are omitted:
let A = Matrix.CreateSparse(3, 10,
            [| 0; 0; 0; 0; 0; 1; 1; 1; 1; 2; 2; 2; 2; 2 |],
            [| 0; 1; 2; 5; 9; 3; 4; 5; 6; 2; 6; 7; 8; 9 |],
            [| 1.0; 2.0; 2.0; 1.0; 1.0; 1.0; 2.0; 1.0; 1.0; 1.0; 1.0; 1.0; 2.0; 1.0 |]);
// The right-hand sides are the atomic weights of the elements
// in the mixture.
let b = Vector.Create(2.0, 1.0, 1.0);

// The number of moles for each compound must be positive.
let l = Vector.CreateConstant(10, 1e-6);
let u = Vector.CreateConstant(10, System.Double.PositiveInfinity);

// We create the nonlinear program with the specified constraints:
// Because we have variable bounds, we use the constructor
// that lets us do this.
let nlp1 = new NonlinearProgram(Func<_,_> objectiveFunction, Func<_,_,_> objectiveGradient, A, b, b, l, u);

// We could add more (linear or nonlinear) constraints here,
// but this is all we have in our problem.

nlp1.InitialGuess <- Vector.CreateConstant(10, 0.1);
let x1 = nlp1.Solve();

printfn "Solution: %O" (x1.ToString("F6"))
// The optimal value is returned by the OptimalValue property:
printfn "Optimal value:   %5f" nlp1.OptimalValue
printfn "# iterations: %d" nlp1.SolutionReport.IterationsNeeded

// The second method is building the nonlinear program from scratch.

Console.WriteLine("Problem with nonlinear constraints:");

// We start by creating a nonlinear program object. We supply
// the number of variables in the constructor.
let nlp2 = new NonlinearProgram(2);

nlp2.ObjectiveFunction <- (fun x -> exp(x.[0]) * (4.0 * x.[0] * x.[0] + 2.0 * x.[1] * x.[1] + 4.0 * x.[0] * x.[1] + 2.0 * x.[1] + 1.0));
nlp2.ObjectiveGradient <- (fun x -> fun y ->
    let exp = exp(x.[0]);
    y.[0] <- exp * (4.0 * x.[0] * x.[0] + 2.0 * x.[1] * x.[1] + 4.0 * x.[0] * x.[1] + 8.0 * x.[0] + 6.0 * x.[1] + 1.0);
    y.[1] <- exp * (4.0 * x.[0] + 4.0 * x.[1] + 2.0);
    y
)

// Add constraint x0*x1 - x0 -x1 <= -1.5
nlp2.AddNonlinearConstraint(
    (fun (x : Vector<float>) -> x.[0] * x.[1] - x.[0] - x.[1] + 1.5),
    ConstraintType.LessThanOrEqual, 0.0,
    (fun (x : Vector<float>) (y : Vector<float>) -> y.[0] <- x.[1] - 1.0; y.[1] <- x.[0] - 1.0; y)) |> ignore;

// Add constraint x0*x1 >= -10
// If the gradient is omitted, it is approximated using divided differences.
nlp2.AddNonlinearConstraint((fun (x : Vector<float>) -> x.[0] * x.[1]), ConstraintType.GreaterThanOrEqual, -10.0) |> ignore;

nlp2.InitialGuess <- Vector.Create(-1.0, 1.0);

let x2 = nlp2.Solve();

printfn "Solution: %O" (x2.ToString("F6"))
// The optimal value is returned by the OptimalValue property:
printfn "Optimal value:   %5f" nlp2.OptimalValue
printfn "# iterations: %d" nlp2.SolutionReport.IterationsNeeded
