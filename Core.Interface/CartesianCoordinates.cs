/// <summary>
/// Author: Laurent Goffin
/// Generic interfaces
/// </summary>
namespace Core.Interface
{
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
    /// 2d vector
    /// </summary>
    public interface IVector2d : I2dCartesianCoordinates<double>
    { }

    /// <summary>
    /// 2d point
    /// </summary>
    public interface IPoint2d : I2dCartesianCoordinates<double>
    { }

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
    /// 3d vector
    /// </summary>
    public interface IVector3d : I3dCartesianCoordinates<double>
    { }

    /// <summary>
    /// 2d point
    /// </summary>
    public interface IPoint3d : I3dCartesianCoordinates<double>
    { }

    /// <summary>
    /// Distance with a 3d point
    /// </summary>
    public interface I3dPointDistance<T>
    {
        double Distance(IPoint3d p);
    }

    /// <summary>
    /// 3d cartesian metric
    /// </summary>
    public interface I3dCartesianMetric<T> : I3dCartesianCoordinates<T>, I3dPointDistance<T>
    { }
}
