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
  private void RunScript(int x, int y, int z, int uCount, int vCount, double factor, ref object A, ref object B, ref object C, ref object D, ref object E, ref object F)
  {
    //Write the c# script for the following psuedo code for the c# node in grasshopper for Rhino3d

//create a script the generated a basic floorplan of the acropolis
//Pseudo code:
//Create a point at the origin
Point3d origin = new Point3d(0,0,0);
//Create a plane at the origin
Plane originPlane = new Plane(origin, Vector3d.XAxis, Vector3d.YAxis);
//Create a line from the origin to the point x units away in the x direction
Line xLine = new Line(origin, new Point3d(x,0,0));
//find the length of the line
double xLength = xLine.Length;
//Create a line from the origin to the point y units away in the y direction
Line yLine = new Line(origin, new Point3d(0,y,0));
//find the length of the line
double yLength = yLine.Length;

//Create a line from the origin to a point z units away in the z direction
Line zLine = new Line(origin, new Point3d(0,0,z));
//Create a rectangle from the x and y lines
Rectangle3d rect = new Rectangle3d(originPlane, xLength, yLength);

//create a surface from the edge curves of the rectangle
Surface rectSurface = Surface.CreateExtrusion(rect.ToNurbsCurve(), zLine.Direction);

//evaluate the surface at the point (uCount, vCount)
Point3d surfacePoint = rectSurface.PointAt(uCount, vCount);

//find the normal at the point (uCount, vCount)
Vector3d surfaceNormal = rectSurface.NormalAt(uCount, vCount);

//find the centroid of the surface
Point3d surfaceCentroid = rectSurface.PointAt(rectSurface.Domain(0).Mid, rectSurface.Domain(1).Mid);

//create the vectors from the centroid to the point (uCount, vCount)
Vector3d centroidToPoint = surfacePoint - surfaceCentroid;


//Output the mesh
A = rect;
B = rectSurface;
C = surfacePoint;
D = surfaceNormal;
E = surfaceCentroid;
F = centroidToPoint;





  }
  #endregion
  #region Additional

  #endregion
}