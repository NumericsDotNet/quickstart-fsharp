# Numerics.NET QuickStart Samples (F#)

Welcome to the **Numerics.NET QuickStart Samples** repository! 

This collection of F# projects is designed to demonstrate the capabilities 
of **[Numerics.NET](https://numerics.net)**, a comprehensive library for .NET developers 
tackling challenges in mathematical computations, data analysis, statistics, 
and machine learning.

These self-contained samples showcase how Numerics.NET can be effectively used 
to solve real-world problems, helping you integrate advanced numerical capabilities 
into your .NET applications efficiently.

This repository is available in multiple languages and tailored to different .NET versions.

[![C#](https://img.shields.io/badge/language-C%23-blue.svg)](https://github.com/NumericsDotNet/quickstart-csharp/tree/net8.0)
[![Visual Basic](https://img.shields.io/badge/language-Visual%20Basic-blue.svg)](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net8.0)
![F#](https://img.shields.io/badge/language-F%23-brightgreen.svg)


![.NET-8.0+](https://img.shields.io/badge/.NET-8.0+-brightgreen.svg)
[![.NET-6.0](https://img.shields.io/badge/.NET-6.0-blue.svg)](https://github.com/NumericsDotNet/quickstart-fsharp/tree/net6.0)
[![.NET%20Framework-4.6.2](https://img.shields.io/badge/.NET%20Framework-4.6.2-blue.svg)](https://github.com/NumericsDotNet/quickstart-fsharp/tree/net462)


## Why Numerics.NET for Your .NET Projects?

Numerics.NET empowers professional developers to:

* **Address Complex Numerical Tasks Efficiently:** Implement solutions with significantly less code compared to manual approaches.
* **Streamline Development:** Utilize intuitive APIs designed with .NET developers in mind, reducing the learning curve.
* **Achieve Reliable Performance:** Leverage highly optimized and rigorously tested algorithms suitable for production environments.
* **Integrate with Ease:** Seamlessly incorporate numerical capabilities into new or existing .NET projects.
* **Enhance Robustness:** Minimize common mathematical and numerical errors through a well-tested library.

## Solves Real-World Challenges

Numerics.NET is used by development teams in various domains, including:

* Optimizing irrigation system layouts.
* Calculating precise radiation treatment dosages.
* Developing financial trading systems with advanced statistical modeling.
* Creating engineering simulations for structural analysis.
* Implementing scientific algorithms in biotech and healthcare research.

Explore the samples to see how Numerics.NET can be applied to your specific challenges.

## Table of Contents

-   [🚀 Getting Started](#-getting-started)
-   [Prerequisites](#prerequisites)
-   [Installation & Setup](#installation--setup)
-   [Repository Structure](#repository-structure)
-   [Sample Overview](#sample-overview)
-   [Quick Example](#quick-example)
-   [📚 Full Documentation](#-full-documentation)
-   [License](#license)
-   [Acknowledgments](#acknowledgments)

## 🚀 Getting Started

### Prerequisites

* **.NET 8.0 SDK or later** (required for this `net8.0` sample branch).
* An IDE such as Visual Studio, VS Code, XCode, Cursor...
* Compatible with Windows, Linux, and macOS for development.

*Note: Numerics.NET as a library supports a wider range of .NET versions, 
including .NET Framework 4.6.2, .NET Standard 2.0, .NET 6.0, and up to the latest 
.NET releases (e.g., .NET 10.0 Preview).*

### Installation & Setup

1.  **Clone this Repository:**
    ```bash
    git clone https://github.com/NumericsDotNet/quickstart-fsharp.git
    cd quickstart-fsharp
    ```
    Ensure you are on the correct branch for your desired .NET version 
    (this README is for the `net8.0` targeted branch).

2.  **Open the Solution:** Launch the `quickStart-fsharp.sln` solution file 
    in your preferred .NET IDE.

3.  **Obtain a Trial Key:**
    * Visit the [Numerics.NET website](https://numerics.net/trial-key) to request a 30-day trial key.
    * Sign in using your preferred provider to receive your key.

4.  **Activate the Trial:**
    Within each sample project, locate a line similar to:
    ```csharp
    Numerics.NET.License.Verify("your-trial-key-here");
    ```
    Replace `"your-trial-key-here"` with the actual trial key you received.

5.  **Run the Samples:**
    * Execute samples directly from your IDE (right-click on a project and choose "Run" or "Debug").
    * Or, use the command line from the root `quickstart-fsharp` directory:
        ```bash
        dotnet run --project <sample_project_folder_name>
        ```
        For example:
        ```bash
        dotnet run --project data-analysis/data-wrangling
        ```
        (Adjust the project path as needed based on the sample you wish to run.)


## Repository Structure

The samples are organized into folders by category. Each sample resides in its own dedicated project folder. Data files used by the samples are located in the top-level `data` directory.

```plaintext
quickstart-csharp/
│
├── data-analysis/              # Data analysis and manipulation examples
│   └── data-frames/
├── mathematics/                # Fundamental and advanced mathematical functions
│   └── ...
├── linear-algebra/             # Matrix, vector operations, and equation solving
│   └── ...
├── statistics/                 # Statistical analysis and modeling
│   └── ...
├── data/                       # Data files for samples (e.g., CSV files)
├── quickStart-fsharp           # Solution file
└── README.md                   # This file
```

This repository has multiple branches corresponding to different .NET versions. 
Some features may only be available in newer .NET versions. 
The current branch targets **net8.0** and higher.

## Sample Overview

This repository provides practical examples for various Numerics.NET features, including:

- **Mathematics**: Calculus (differentiation, integration), numerical analysis, special functions, complex numbers, and more.
- **Linear Algebra**: Operations on vectors and matrices (dense and sparse), solving linear systems, matrix decompositions (LU, QR, SVD, Eigenvalue), and tensor operations.
- **Statistics**: Descriptive statistics, probability distributions, hypothesis testing, correlation, regression, and other statistical models.
- **Data Analysis**: Tools for data import (e.g., CSV), data frames for data manipulation, cleaning, transformation, and analysis including pivoting and grouping.

## Quick Example

Here’s a brief illustration of Numerics.NET's concise syntax for common tasks:

```csharp
// Create a matrix and a vector and perform operations
Matrix<double> A = [[1, 2], [3, 4]];
Vector<double> b = [5, 6];
var x = A.Solve(b); // Solve Ax = b
var eigenValues = A.GetEigenValues();
var (U, S, V) = A.GetSingularValueDecomposition();

// Find the minimum of the famous Rosenbrock function:
var minimum = SymbolicMath.FindMinimum(
    (x, y) => (1.0 - x) * (1.0 - x) + 100 * Elementary.Pow(y - x * x, 2), 
    initialGuess: [-1, 1]);
Console.WriteLine(minimum);

// Find out the survival rate for the Titanic disaster by class:
var titanic = DelimitedTextFile.ReadDataFrame(@"titanic.csv");
var survived = titanic["Survived"].As<bool>();
var pclass = titanic["Pclass"].AsCategorical();
var survivedByClass = new Pivot(pclass, survived.AsCategorical())
    .CountsMatrix().WithColumnIndex(["Died", "Survived"])
    .NormalizeRowsInPlace(VectorNorm.OneNorm);
Console.WriteLine(survivedByClass.Summarize());
```

## 📚 Full Documentation

For comprehensive information, API references, and further examples, please visit 
the official [Numerics.NET Documentation](https://numerics.net/documentation).

## License

The samples in this repository are licensed under the MIT License 
(refer to the [LICENSE](LICENSE) file in the root of this repository).

Numerics.NET itself is a commercial library. A license is required for development 
and for deployment in commercial applications. A free 30-day trial license is available 
from the Numerics.NET website.

## Acknowledgments

Thank you for exploring Numerics.NET! We hope these samples effectively demonstrate 
the library's capabilities and help you accelerate your .NET development projects. 
If you find this repository useful, please consider giving it a ⭐!

Happy Coding! 😊