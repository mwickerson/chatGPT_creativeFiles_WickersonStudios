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
public abstract class Script_Instance_09a0a : GH_ScriptInstance
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
  private void RunScript(List<Point3d> points, int degree, ref object InterpolateCrv, ref object NurbsCrv)
  {
    //Write the c# script for the following psuedo code for the c# node in grasshopper for Rhino3d

//Declare a curve variable
    Rhino.Geometry.Curve interCrv = default(Rhino.Geometry.Curve);
    //Create new instance of a curve from interpolate points
    interCrv = Rhino.Geometry.Curve.CreateInterpolatedCurve(points, degree);

    //Declare a curve variable
    Rhino.Geometry.Curve nurbsCrv = default(Rhino.Geometry.Curve);
    //Create new instance of a curve from control points
    nurbsCrv = Rhino.Geometry.Curve.CreateControlPointCurve(points, degree);


    Rhino.Geometry.Curve crv = Curve.CreateControlPointCurve(points, degree);
    Rhino.Geometry.NurbsCurve nc = crv as Rhino.Geometry.NurbsCurve;

    //Assign output
    InterpolateCrv = interCrv;
    NurbsCrv = nurbsCrv;
  }
  #endregion
  #region Additional
    
  #endregion
}