//=====================================================================
//
//  File: anova-one-way.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module AnovaOneWay

// Illustrates the use of the OneWayAnovaModel class for performing
// a one-way analysis of variance.

#light

open System
open System.Data

open Numerics.NET.DataAnalysis
open Numerics.NET.Statistics

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// This QuickStart Sample investigates the effect of the color of packages
// on the sales of the product. The data comes from 12 stores.
// Packages can be either red, green or blue.

// Set up the data using records.
type Observation = { Store : int; Color : string; Shape : string; Sales : float }
let dataFrame =
    let data =
        [|
            { Store = 1; Color = "Blue"; Shape = "Square"; Sales = 6.0 };
            { Store = 2; Color = "Blue"; Shape = "Square"; Sales = 14.0 };
            { Store = 3; Color = "Blue"; Shape = "Rectangle"; Sales = 19.0 };
            { Store = 4; Color = "Blue"; Shape = "Rectangle"; Sales = 17.0 };

            { Store = 5; Color = "Red"; Shape = "Square"; Sales = 18.0 };
            { Store = 6; Color = "Red"; Shape = "Square"; Sales = 11.0 };
            { Store = 7; Color = "Red"; Shape = "Rectangle"; Sales = 20.0 };
            { Store = 8; Color = "Red"; Shape = "Rectangle"; Sales = 23.0 };

            { Store = 9; Color = "Green"; Shape = "Square"; Sales = 7.0 };
            { Store = 10; Color = "Green"; Shape = "Square"; Sales = 11.0 };
            { Store = 11; Color = "Green"; Shape = "Rectangle"; Sales = 18.0 };
            { Store = 12; Color = "Green"; Shape = "Rectangle"; Sales = 10.0 };
        |]
    DataFrame.FromObjects(data)

// Construct the OneWayAnovaModel object.
let anova = OneWayAnovaModel(dataFrame, "Sales", "Color")
// Alternatively, you can use a formula to specify the variables:
let anova2 = OneWayAnovaModel(dataFrame, "Sales ~ Color")
// Verify that the design is balanced:
if (not anova.IsBalanced) then
    printfn "The design is not balanced."
// Perform the calculation.
anova.Fit()

// The AnovaTable property gives us a classic anova table.
// We can write the table directly to the console:
printfn "%O" anova.AnovaTable
printfn ""

// A Cell object represents the data in a cell of the model,
// i.e. the data related to one level of the factor.
// We can use it to access the group means of our color groups.

// First we get the index so we can easily iterate
// through the levels:
let colorFactor = anova.GetFactor<string>(0)
for level in colorFactor do
    printfn "Mean for group '%O': %.4f" level (anova.Cells.Get(level).Mean)

// We could have accessed the cells directly as well:
printfn "Variance for blue packages: %A" (anova.Cells.Get("Blue").Variance)
printfn ""

// We can get the summary data for the entire model
// by using the TotalCell property:
let totalSummary = anova.TotalCell
printfn "Summary data:"
printfn "# observations: %.0f" totalSummary.Count
printfn "Grand mean:     %.4f" totalSummary.Mean
