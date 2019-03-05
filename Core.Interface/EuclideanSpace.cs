/// <summary>
/// Author: Laurent Goffin
/// Generic interfaces
/// </summary>
namespace Core.Interface
{
    /// <summary>
    /// Reference frame interface
    /// </summary>
    public interface IEuclideanSpace
    {
        bool Set(IFrame origin, IFrame target, IMatrix<double> rigidMatrix = null);
        IMatrix<double> Get(IFrame origin, IFrame target);
    }

    /// <summary>
    /// Reference frame interface
    /// </summary>
    public interface IFrame
    { }
}
