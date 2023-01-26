using System;
using System.Collections;
using System.Collections.Generic;

using Rhino;
using Rhino.Geometry;

using Grasshopper;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;



/// <summary>
/// This class will be instantiated on demand by the Script component.
/// </summary>
public abstract class Script_Instance_68b9b : GH_ScriptInstance
{
  #region Utility functions
  /// <summary>Print a String to the [Out] Parameter of the Script component.</summary>
  /// <param name="text">String to print.</param>
  private void Print(string text) { /* Implementation hidden. */ }
  /// <summary>Print a formatted String to the [Out] Parameter of the Script component.</summary>
  /// <param name="format">String format.</param>
  /// <param name="args">Formatting parameters.</param>
  private void Print(string format, params object[] args) { /* Implementation hidden. */ }
  /// <summary>Print useful information about an object instance to the [Out] Parameter of the Script component. </summary>
  /// <param name="obj">Object instance to parse.</param>
  private void Reflect(object obj) { /* Implementation hidden. */ }
  /// <summary>Print the signatures of all the overloads of a specific method to the [Out] Parameter of the Script component. </summary>
  /// <param name="obj">Object instance to parse.</param>
  private void Reflect(object obj, string method_name) { /* Implementation hidden. */ }
  #endregion

  #region Members
  /// <summary>Gets the current Rhino document.</summary>
  private readonly RhinoDoc RhinoDocument;
  /// <summary>Gets the Grasshopper document that owns this script.</summary>
  private readonly GH_Document GrasshopperDocument;
  /// <summary>Gets the Grasshopper script component that owns this script.</summary>
  private readonly IGH_Component Component;
  /// <summary>
  /// Gets the current iteration count. The first call to RunScript() is associated with Iteration==0.
  /// Any subsequent call within the same solution will increment the Iteration count.
  /// </summary>
  private readonly int Iteration;
  #endregion
  /// <summary>
  /// This procedure contains the user code. Input parameters are provided as regular arguments,
  /// Output parameters as ref arguments. You don't have to assign output parameters,
  /// they will have a default value.
  /// </summary>
  #region Runscript
  private void RunScript(double frequency, double amplitude, ref object A, ref object B, ref object C, ref object D, ref object E)
  {
    //Write the c# script for the following psuedo code for the c# node in grasshopper for Rhino3d
    //create a curve for a robotic tool path that maps our the best permiculture 
    //layout for an trigonometeric surface that represents a 20 acre farm
    //Create a new curve object with rhino common
    Curve myCurve = Rhino.Geometry.Curve.CreateControlPointCurve(new Point3d[] { new Point3d(0, 0, 0), new Point3d(1, 0, 0), new Point3d(1, 1, 0), new Point3d(0, 1, 0) }, 3);

    //Define the parameters for the curve
    double[] myCurveParameters = myCurve.DivideByCount(10, true);
    myCurve.Domain = new Interval(0, 1);

    //create a list of points to define the curve
    List<Point3d> points = new List<Point3d>();

    //Loop through the surface to create the points for the curve with frequency and amplitude
    for (int i = 0; i < 20; i++)
    {
      for (int j = 0; j < 20; j++)
      {
        Point3d point = new Point3d(i, j, amplitude * Math.Sin(frequency * i) * Math.Cos(frequency * j));
        points.Add(point);
      }

      //Create the curve from the points
      myCurve = Rhino.Geometry.Curve.CreateControlPointCurve(points, 3);


      //Outputs
      A = myCurve;
      B = myCurveParameters;
      C = myCurve.Domain;
      D = points;
      E = myCurve;


    }
    



    //Outputs
    A = myCurve;
    B = myCurveParameters;
    C = myCurve.Domain;

  
  }
  #endregion
  #region Additional

  #endregion
}