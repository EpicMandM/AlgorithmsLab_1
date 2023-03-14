# AlgorithmsLab_1
This project contains code for computing the first and second derivatives of a given function using Lagrange interpolation.

## Differential Class
This class provides methods for computing the first and second derivatives of a given function using Lagrange interpolation.

`f(double[] x1, double[] y1, double x)`
This method calculates the interpolated value of a function at a given point using Lagrange interpolation.

`GetFirstDiff(double[] x1, double[] y1, double x)`
This method computes the first derivative of a function at a given point using Lagrange interpolation.

`GetOutPutDiff(double[] x1, double[] y1, double x)`
This method prints the result of the second derivative of a function at a given point using Lagrange interpolation.

`GetFirstDiff(double[] x1, double[] y1, double[] x2)`
This method computes the first derivative of a function at multiple points using Lagrange interpolation.

`GetSecondDiff(double[] x1, double[] y1, double x)`
This method computes the second derivative of a function at a given point using Lagrange interpolation.

`GetSecondDiff(double[] x1, double[] y1, double[] x2)`
This method computes the second derivative of a function at multiple points using Lagrange interpolation.

## Lagrange Class
This class provides methods for calculating the global and piecewise Lagrange interpolations of a given function.

`InterpolateGlobal(double[] x, double[] y, double xval)`
This method calculates the interpolated value of a function at a given point using global Lagrange interpolation.

`InterpolateGlobal(double[] x, double[] y, double[] xvals)`
This method calculates the interpolated values of a function at multiple points using global Lagrange interpolation.

`InterpolatePiece2(double[] x, double[] y, double xval, int degree)`
This method calculates the interpolated value of a function at a given point using piecewise Lagrange interpolation.

## Program Class
This class contains the main method for running the project.

Task2()
This method prompts the user for input and calculates the piecewise Lagrange interpolation for the input values.

`Print(double[] x1, double[] y1, double[] y2)`
This method prints a formatted table of input, output, and expected values for the interpolated function.

`Initialize(int count, out double[] x1, out double[] y1)`
This method reads input values from a file and stores them in arrays.

`GetXData(out double[] x2)`
This method generates an array of x-values for interpolation.

`GetInput()`
This method prompts the user for input and returns a dictionary of x-y value pairs, along with a target x-value for interpolation.

`GetFormulaDiffFirst(double[] x2, out double[] y2)`
This method calculates the first derivative of the input function for a given set of x-values.

`GetFormulaDiffSecond(double[] x2, out double[] y2)`
This method calculates the second derivative of the input function for a given set of x-values.

`GetFormula(double[] x2, out double[] y2)`
This method calculates the input function for a given set of x-values.
