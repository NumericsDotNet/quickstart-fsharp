//=====================================================================
//
//  File: homogeneity-of-variances-tests.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module HomogeneityOfVariancesTests

/// Illustrates how to perform a goodness of fit test
/// using the classes in the Numerics.NET.Statistics.Tests
/// namespace.

#light

open System

open Numerics.NET
open Numerics.NET.Statistics
open Numerics.NET.Statistics.Tests

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// One of the underlying assumptions of Analysis of Variance
// (ANOVA) is that the variances in the different groups are
// identical. This QuickStart Sample shows how to use
// the two tests are available that can verify this assumption.

// The data for this QuickStart Sample is measurements of
// the diameters of gears from 10 different batches.
// Two variables are provided:

// batchVariable contains the batch number of each measurement:
let batch = Vector.CreateFromFunction(100, fun i -> 1 + i / 10).AsCategorical()

// diameterVariable contains the actual measurements:
let diameter = Vector.Create(
        [|
            1.006; 0.996; 0.998; 1.000; 0.992; 0.993; 1.002; 0.999; 0.994; 1.000;
            0.998; 1.006; 1.000; 1.002; 0.997; 0.998; 0.996; 1.000; 1.006; 0.988;
            0.991; 0.987; 0.997; 0.999; 0.995; 0.994; 1.000; 0.999; 0.996; 0.996;
            1.005; 1.002; 0.994; 1.000; 0.995; 0.994; 0.998; 0.996; 1.002; 0.996;
            0.998; 0.998; 0.982; 0.990; 1.002; 0.984; 0.996; 0.993; 0.980; 0.996;
            1.009; 1.013; 1.009; 0.997; 0.988; 1.002; 0.995; 0.998; 0.981; 0.996;
            0.990; 1.004; 0.996; 1.001; 0.998; 1.000; 1.018; 1.010; 0.996; 1.002;
            0.998; 1.000; 1.006; 1.000; 1.002; 0.996; 0.998; 0.996; 1.002; 1.006;
            1.002; 0.998; 0.996; 0.995; 0.996; 1.004; 1.004; 0.998; 0.999; 0.991;
            0.991; 0.995; 0.984; 0.994; 0.997; 0.997; 0.991; 0.998; 1.004; 0.997
        |])

// To prepare the data, we create a vector of vectors,
// one for each batch. This is optional. (See below.)
let variables = diameter.SplitBy(batch);

//
// Bartlett's test
//

// Bartlett's test is relatively fast, but has the drawback that
// it requires the data in the groups to be normally distributed,
// and it is not very robust against departures from normality.
// What this means in practice is that the test can't distinguish
// between rejection because of non-homogeneity of variances
// and violation of the normality assumption.

printfn "Bartlett's test."

// We pass the array of variables to the constructor:
let bartlett = BartlettTest(variables)
// We could have also written:
let bartlett2 = BartlettTest(diameter, batch)

// We can obtan the value of the test statistic through the Statistic property,
// and the corresponding P-value through the Probability property:
printfn "Test statistic: %.4f" bartlett.Statistic
printfn "P-value:        %.4f" bartlett.PValue

printfn "Critical value: %.4f at 90%%" (bartlett.GetUpperCriticalValue(0.10))
printfn "Critical value: %.4f at 95%%" (bartlett.GetUpperCriticalValue(0.05))
printfn "Critical value: %.4f at 99%%" (bartlett.GetUpperCriticalValue(0.01))

// We can now print the test results:
printfn "Reject null hypothesis? %s" (if bartlett.Reject() then "yes" else "no")

//
// Levene's Test
//

// Levene's test is slower than Bartlett's test, but is generally more reliable.
// It comes in three variants, depending on the measure of location used.
// The default is that the group median is used.

printfn "\nLevene's Test"

// Once again, we pass an array of Variable objects to the constructor.
// The LeveneTest constructor is overloaded: you can specify
// the type of mean (mean, median, or trimmed mean):
let levene = LeveneTest(variables, LocationMeasure.Median)

// We can obtan the value of the test statistic through the Statistic property,
// and the corresponding P-value through the Probability property:
printfn "Test statistic: %.4f" levene.Statistic
printfn "P-value:        %.4f" levene.PValue

// We can obtain critical values for various significance levels:
printfn "Critical value: %.4f at 90%%" (levene.GetUpperCriticalValue(0.10))
printfn "Critical value: %.4f at 95%%" (levene.GetUpperCriticalValue(0.05))
printfn "Critical value: %.4f at 99%%" (levene.GetUpperCriticalValue(0.01))

// We can now print the test results:
printfn "Reject null hypothesis? %s" (if levene.Reject() then "yes" else "no")
