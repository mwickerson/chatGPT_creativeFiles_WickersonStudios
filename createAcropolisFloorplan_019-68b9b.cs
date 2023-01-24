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
  private void RunScript(double xVar, int numPoints, double yVar, double amplitude, double frequency, double phaseShift, ref object A, ref object B, ref object C, ref object D)
  {
    //Write the c# script for the following psuedo code for the c# node in grasshopper for Rhino3d
    // 1. Create a list of points
    List<Point3d> points = new List<Point3d>();

    // Create a loop to create the points
    for (double t = 0; t < 2*Math.PI; t += 0.01)
    {
      //Calcutate the x and y coordinates
      double x = xVar*Math.Cos(t);
      double y = yVar*Math.Sin(t);

      //Calculate the z coordinate
      double z = amplitude*Math.Sin(frequency*t + phaseShift);

      //Create a point and add it to the list
      Point3d pt = new Point3d(x, y, z);
      points.Add(pt);
    }

    //Outputs
    A = points;
    B = points.Count;
    C = points[0];
    D = points[points.Count-1];

  
  }
  #endregion
  #region Additional

  #endregion
}