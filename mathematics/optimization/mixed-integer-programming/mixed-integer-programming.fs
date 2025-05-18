//=====================================================================
//
//  File: mixed-integer-programming.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module MixedIntegerProgramming

// Illustrates solving mixed integer programming problems
// using the classes in the Numerics.NET.Optimization
// namespace of Numerics.NET.

#light

open System

// The linear programming classes reside in their own namespace.
open Numerics.NET.Optimization
// Vectors and matrices are in the Numerics.NET namespace
open Numerics.NET

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// In this QuickStart sample, we'll use the Mixed Integer
// programming capabilities to solve Sudoku puzzles.
// The rules of Sudoku will be4 expressed in terms of
// linear constraints on binary variables.

// First, create an empty linear program.
let lp = new LinearProgram()

// Create a binary variable for each digit in each row and column.
// The AddBinaryVariable method creates a variable that can have values of 0 or 1.
let varInit =
    let name row column digit = String.Format("x{0}{1}{2}", row, column, digit)
    fun row column digit -> lp.AddBinaryVariable(name row column digit, 0.0) :> DecisionVariable
// To add integer variables, you can use the AddIntegerVariable method.
// To add real variables, you can use the AddVariable method.

// Create an array of binary variables that indicate whether
// the cell at a specific row and column contain a specific digit.
// - The first index corresponds to the row.
// - The second index corresponds to the column.
// - The third index corresponds to the digit.
let variables = Array3D.init 9 9 9 varInit

// Now add constraints that represent the rules of Sudoku.

// There are 4 rules in Sudoku. They are all of the kind
// where only one of a certain set of combinations
// of (row, column, digit) can occur at the same time.
// We can express this by stating that the sum of the corresponding
// binary variables must be one.

// AddConstraints is a helper function.
// For each combination of the first two arguments,
// it builds a constraint by iterating over the third argument.
let coefficients = [| 1.0; 1.0; 1.0; 1.0; 1.0; 1.0; 1.0; 1.0; 1.0 |]
let AddConstraints (lp : LinearProgram) variable =
    for i in 0..8 do
        for j in 0..8 do
            let variables = Array.init 9 (fun k -> variable i j k)
            lp.AddLinearConstraint(variables, coefficients, ConstraintType.Equal, 1.0) |> ignore

// Rule 1: each posiion contains exactly one digit
AddConstraints lp (fun row column digit -> variables[row, column, digit])
// Rule 2: each digit appears once in each row
AddConstraints lp (fun row digit column -> variables[row, column, digit])
// Rule 3: each digit appears once in each column
AddConstraints lp (fun column digit row -> variables[row, column, digit])
// Rule 4: each digit appears exactly once in each block
AddConstraints lp (fun block digit index ->
    variables[3 * (block % 3) + (index % 3), 3 * (block / 3) + (index / 3), digit])

// We represent the board with a 9x9 sparse matrix.
// The nonzero entries correspond to the numbers
// already on the board.

// Let's see if we can solve "the world's hardest Sudoku" puzzle:
// http://www.mirror.co.uk/fun-games/sudoku/2010/08/19/world-s-hardest-sudoku-can-you-solve-dr-arto-inkala-s-puzzle-115875-22496946/
let rows = [| 0;0;1;1;2;2;2;3;3;3;4;4;4;5;5;5;6;6;6;7;7;8;8 |]
let columns = [| 2;3;0;7;1;4;6;0;5;6;1;4;8;2;3;7;1;3;8;2;7;5;6 |]
let digits = [| 5.0;3.0;8.0;2.0;7.0;1.0;5.0;4.0;5.0;3.0;
    1.0;7.0;6.0;3.0;2.0;8.0;6.0;5.0;9.0;4.0;3.0;9.0;7.0 |]
let board = Matrix.CreateSparse(9, 9, rows, columns, digits)

// Now fix the variables for the for the digits that are already on the board.
// We do this by setting the lower bound equal to the upper bound:
for triplet in board.NonzeroElements do
    variables[triplet.Row, triplet.Column, (int)triplet.Value - 1].LowerBound <- 1.0

// Solve the linear program.
let solution = lp.Solve();

// Scan the variables and print the digit if the value is 1.
let getDigit row column =
    let rec getDigitRec row column digit =
        match digit with
        | 9 -> '.'
        | _ -> if (variables[row, column, digit].Value = 1.0) then
                char(49 + digit)
                else getDigitRec row column (digit+1)
    getDigitRec row column 0

for row in 0..8 do
    for column in 0..8 do
        printf "%c" (getDigit row column)
    printfn ""
