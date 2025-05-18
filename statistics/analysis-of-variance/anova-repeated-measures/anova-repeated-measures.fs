//=====================================================================
//
//  File: anova-repeated-measures.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module AnovaRepeatedMeasures

// Illustrates the use of the OneWayRAnovaModel class for performing
// a one-way analysis of variance with repeated measures.

#light

open System
open Numerics.NET.DataAnalysis
open Numerics.NET.Statistics

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// This QuickStart Sample investigates the effect of the color of packages
// on the sales of the product. The data comes from 12 stores.
// Packages can be either red, green or blue.

// Set up the data in an ADO.NET data table.
type Observation = { Person:int; Drug:int; Score:int }
let dataFrame =
    let data =
        [|
            { Person = 1; Drug = 1; Score = 30 };
            { Person = 1; Drug = 2; Score = 28 };
            { Person = 1; Drug = 3; Score = 16 };
            { Person = 1; Drug = 4; Score = 34 };
            { Person = 2; Drug = 1; Score = 14 };
            { Person = 2; Drug = 2; Score = 18 };
            { Person = 2; Drug = 3; Score = 10 };
            { Person = 2; Drug = 4; Score = 22 };
            { Person = 3; Drug = 1; Score = 24 };
            { Person = 3; Drug = 2; Score = 20 };
            { Person = 3; Drug = 3; Score = 18 };
            { Person = 3; Drug = 4; Score = 30 };
            { Person = 4; Drug = 1; Score = 38 };
            { Person = 4; Drug = 2; Score = 34 };
            { Person = 4; Drug = 3; Score = 20 };
            { Person = 4; Drug = 4; Score = 44 };
            { Person = 5; Drug = 1; Score = 26 };
            { Person = 5; Drug = 2; Score = 28 };
            { Person = 5; Drug = 3; Score = 14 };
            { Person = 5; Drug = 4; Score = 30 };
        |]
    DataFrame.FromObjects(data)

// Construct the OneWayAnova object.
let anova = OneWayRAnovaModel(dataFrame, "Score", "Drug", "Person")
// Construct the OneWayAnova object.
let anova2 = OneWayRAnovaModel(dataFrame, "Score ~ Drug + Person")
// Perform the calculation.
anova.Fit()

// Verify that the design is balanced:
if (not anova.IsBalanced) then
    printfn "The design is not balanced."

// The AnovaTable property gives us a classic anova table.
// We can write the table directly to the console:
printfn "%O" anova.AnovaTable
printfn ""

// A Cell object represents the data in a cell of the model,
// i.e. the data related to one level of the factor.
// We can use it to access the group means for each drug.

// We need two indices here: the second index corresponds
// to the person factor.

// First we get the index so we can easily iterate
// through the levels:
let drugFactor = anova.GetFactor<int>(0)
for level in drugFactor do
    printfn "Mean for group '%O': %.4f" level (anova.SubjectTotals.Get(level).Mean)

// We could have accessed the cells directly as well:
printfn "Variance for second drug: %A" (anova.TreatmentTotals.Get(2).Variance)
printfn ""

// We can get the summary data for the entire model
// by using the TotalCell property:
let totalSummary = anova.TotalCell
printfn "Summary data:"
printfn "# observations: %.0f" totalSummary.Count
printfn "Grand mean:     %.4f" totalSummary.Mean
