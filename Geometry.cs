using System.Collections.Generic;

/// <summary>
/// Author: Laurent Goffin
/// Generic interfaces
/// </summary>
namespace Core.Interface
{
    public interface IPolygon
    {
        double Surface { get; }
    }

    public interface IMesh
    {
        List<I3dCartesianCoordinates<double>> Point3dList();
        List<Triangle> Triangles { get; }
        IPolygon Triangle3d(int i);
    }

    /// <summary>
    /// List of 3 index a,b,c :
    /// One for each point of the triangle
    /// </summary>
    public class Triangle
    {
        public Triangle(int a, int b, int c)
        {
            index.Add(a);
            index.Add(b);
            index.Add(c);
        }
        public List<int> index = new List<int>(3);
    }
}
