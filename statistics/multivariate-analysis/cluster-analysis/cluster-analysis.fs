//=====================================================================
//
//  File: cluster-analysis.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module ClusterAnalysis

#light

open System
open System.Linq

open Numerics.NET.Data.Stata
open Numerics.NET
open Numerics.NET.Statistics
open Numerics.NET.Statistics.Multivariate

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Demonstrates how to use classes that implement
// hierarchical and K-means clustering.

// This QuickStart Sample demonstrates how to run two
// common multivariate analysis techniques:
// hierarchical cluster analysis and K-means cluster analysis.
//
// The classes used in this sample reside in the
// Numerics.NET.Statistics.Multivariate namespace..

// First, our dataset, which is from
//     Computer-Aided Multivariate Analysis, 4th Edition
//     by A. A. Afifi, V. Clark and S. May, chapter 16
//     See http://www.ats.ucla.edu/stat/Stata/examples/cama4/default.htm
let frame =
    let filename = @"..\..\..\..\..\Data\companies.dta"
    StataFile.ReadDataFrame(filename)

//
// Hierarchical cluster analysis
//

printfn "Hierarchical clustering"

// Create the model:

let columns = [| "ror5"; "de"; "salesgr5"; "eps5"; "npm1"; "pe"; "payoutr1" |]
let hc = HierarchicalClusterAnalysis(frame, columns)

// Alternatively, we could use a formula to specify the variables:
let formula = "ror5 + de + salesgr5 + eps5 + npm1 + pe + payoutr1"
let hc2 = HierarchicalClusterAnalysis(frame, formula)

// Rescale the variables to their Z-scores before doing the analysis:
hc.Standardize <- true
// The linkage method defaults to Centroid:
hc.LinkageMethod <- LinkageMethod.Centroid
// We could set the distance measure. We use the default:
hc.DistanceMeasure <- DistanceMeasures.SquaredEuclideanDistance

// Fit the model:
hc.Fit()

// We can partition the cases into clusters:
let partition = hc.GetClusterPartition(5)
// Individual clusters are accessed through an index, or through enumeration.
for cluster in partition do
    printfn "Cluster %d has %d members." cluster.Index cluster.Size

// Get a variable that shows memberships:
let memberships = partition.GetMemberships()
for i in 15..memberships.Length-1 do
    printfn "Observation %d belongs to cluster %d" i (memberships[i].Index)

// A dendrogram is a graphical representation of the clustering in the form of a tree.
// You can get all the information you need to draw a dendrogram starting from
// the root node of the dendrogram:
let root = hc.DendrogramRoot
// Position and DistanceMeasure give the x and y coordinates:
printfn "Root position: (%.4f, %.4f)" root.Position root.DistanceMeasure
// The left and right children:
printfn "Position of left child: %.4f" root.LeftChild.Position
printfn "Position of right child: %.4f" root.RightChild.Position

// You can also get a filter that defines a sort order suitable for
// drawing the dendrogram:
let sortOrder = hc.GetDendrogramOrder()
printfn ""

//
// K-Means Clustering
//

printfn "K-means clustering"

// Create the model:
let kmc = KMeansClusterAnalysis(frame, columns, 3)
// Rescale the variables to their Z-scores before doing the analysis:
kmc.Standardize <- true

// Fit the model:
kmc.Fit()

// The Predictions property is a categorical vector that contains
// the cluster assignments:
let predictions = kmc.Predictions
// The GetDistancesToCenters method returns a vector containing
// the distance of each observations to its center.
let distances = kmc.GetDistancesToCenters()

// For example:
for i = 18 to predictions.Length-1 do
    printfn "Observation %d belongs to cluster %d, distance: %.4f."
        i predictions[i] distances[i]

// You can use this to compute several statistics:
let descriptives = distances.SplitBy(predictions)
                    .Map(fun x -> Descriptives<float>(x))

// We can partition the cases into clusters:
let clusters = kmc.Clusters
// Individual clusters are accessed through an index, or through enumeration.
for cluster in clusters do
    printfn "Cluster %d has %d members. Sum of squares: %.4f"
        cluster.Index cluster.Size cluster.SumOfSquares
    printfn "Center: %s" (cluster.Center.ToString("F4"))

// The distances between clusters are also available:
printfn "%s" (kmc.GetClusterDistances().ToString("F4"))

// You can get a filter for the observations in a single cluster:
let level1Indexes = (kmc.Predictions :> ICategoricalVector).GetIndexes(1).ToArray()
printfn "Number of items in cluster 1: %d" level1Indexes.Length
