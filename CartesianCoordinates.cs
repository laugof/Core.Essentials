/// <summary>
/// Author: Laurent Goffin
/// Generic interfaces
/// </summary>
namespace Core.Interface
{
    /// <summary>
    /// Vector of cartesian coordinates
    /// </summary>
    public interface IVector
    {
        double this[int index] { get; set; }
        int Length { get; }
    }

    /// <summary>
    /// 2d cartesian coordinates
    /// </summary>
    public interface I2dCartesianCoordinates : IVector
    {
        double X { get; set; }
        double Y { get; set; }
        void SetCartesian(double x, double y);
        void SetCartesian(I2dCartesianCoordinates p);
    }

    /// <summary>
    /// 3d cartesian coordinates
    /// </summary>
    public interface I3dCartesianCoordinates : IVector
    {
        double X { get; set; }
        double Y { get; set; }
        double Z { get; set; }
        void SetCartesian(double x, double y, double z = 0.0);
        void SetCartesian(I2dCartesianCoordinates p);
        void SetCartesian(I3dCartesianCoordinates p);
    }

    /// <summary>
    /// Distance with a 3d point
    /// </summary>
    public interface I3dPointDistance
    {
        double Distance(I3dCartesianCoordinates p);
    }

    /// <summary>
    /// 3d cartesian metric
    /// </summary>
    public interface I3dCartesianMetric : I3dCartesianCoordinates, I3dPointDistance
    { }
}
