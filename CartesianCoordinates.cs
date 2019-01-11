using System.Collections.Generic;

/// <summary>
/// Author: Laurent Goffin
/// Generic interfaces
/// </summary>
namespace Core.Interface
{

    /// <summary>
    /// Vector of cartesian coordinates
    /// </summary>
    public interface IVector<T>
    {
        T this[int index] { get; set; }
        int Length { get; }
    }

    /// <summary>
    /// 2d cartesian coordinates
    /// </summary>
    public interface I2dCartesianCoordinates<T> : IVector<T>
    {
        T X { get; set; }
        T Y { get; set; }
        void SetCartesian(T x, T y);
        void SetCartesian(I2dCartesianCoordinates<T> p);
    }

    /// <summary>
    /// 3d cartesian coordinates
    /// </summary>
    public interface I3dCartesianCoordinates<T> : IVector<T>
    {
        T X { get; set; }
        T Y { get; set; }
        T Z { get; set; }
        void SetCartesian(T x, T y, T z);
        void SetCartesian(I2dCartesianCoordinates<T> p);
        void SetCartesian(I3dCartesianCoordinates<T> p);
    }

    /// <summary>
    /// Distance with a 3d point
    /// </summary>
    public interface I3dPointDistance<T>
    {
        double Distance(I3dCartesianCoordinates<T> p);
    }

    /// <summary>
    /// 3d cartesian metric
    /// </summary>
    public interface I3dCartesianMetric<T> : I3dCartesianCoordinates<T>, I3dPointDistance<T>
    { }

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
}
