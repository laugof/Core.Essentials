/// <summary>
/// Author: Laurent Goffin
/// Generic interfaces
/// </summary>
namespace Core.Interface
{
    public interface IRigidMatrix
    {
        IMatrix<double> RotationMatrix { get; }
        IVector<double> TranslationVector { get; }
        bool IsIdentity();
    }

    /// <summary>
    /// Reference frame interface
    /// </summary>
    public interface IEuclideanSpace
    {
        void AddFrame(IFrame frame);
        void RemoveFrame(IFrame frame);
        bool AreConnected(IFrame origin, IFrame target);
        void Set(IFrame origin, IFrame target, IRigidMatrix rigidMatrix = null);
        IRigidMatrix Get(IFrame origin, IFrame target);
        void Remove(IFrame origin, IFrame target = null);
    }

    /// <summary>
    /// Reference frame interface
    /// </summary>
    public interface IFrame
    { }
}
