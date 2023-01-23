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
  private void RunScript(int numPoints, double amplitude, double frequency, double phaseShift, ref object A, ref object B, ref object C)
  {
    //Write the c# script for the following psuedo code for the c# node in grasshopper for Rhino3d
      //Write the c# script for the following psuedo code for the c# node in grasshopper for Rhino3d

    //set the inputs on the c# node in grasshopper

    //define the points for the curves
    Point3d [] keelPoints = new Point3d[numPoints];
    Point3d [] haulPoinst = new Point3d[numPoints];
    Point3d [] ribPoints = new Point3d[numPoints];

    //calculate the points for the curves
    for (int i = 0; i < numPoints; i++)
    {
      double t = (double) i / (double) (numPoints - 1);
      double x = amplitude * Math.Sin(2 * Math.PI * frequency * t + phaseShift);
      double y = amplitude * Math.Cos(2 * Math.PI * frequency * t + phaseShift);
      double z = amplitude * Math.Tan(2 * Math.PI * frequency * t + phaseShift);

      keelPoints[i] = new Point3d(x, 0, z);
      haulPoinst[i] = new Point3d(x, y, 0);
      ribPoints[i] = new Point3d(0, y, z);
    }

    //output the curves
    Curve keelCurve = Curve.CreateInterpolatedCurve(keelPoints, 3);
    Curve haulCurve = Curve.CreateInterpolatedCurve(haulPoinst, 3);
    Curve ribCurve = Curve.CreateInterpolatedCurve(ribPoints, 3);

    //outputs
    A = keelCurve;
    B = haulCurve;
    C = ribCurve;
    //create a script that generates a beautiful trigonometric curves for the keel, haul, and ribs of a boat



  
  }
  #endregion
  #region Additional

  #endregion
}