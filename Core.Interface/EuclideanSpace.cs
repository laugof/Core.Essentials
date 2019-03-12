using System;
/// <summary>
/// Author: Laurent Goffin
/// Generic interfaces
/// </summary>
namespace Core.Interface
{
    public interface IRigidMatrix
    {
        IMatrix<double> RotationMatrix { get; }
        I3dCartesianCoordinates<double> TranslationVector { get; }
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
        void Remove(IFrame origin, IFrame target = null);

        bool Set(IFrame origin, IFrame target, IRigidMatrix rigidMatrix = null);
        bool Set(IFrame origin, IFrame target, string filename, bool closestRotation = true);
        bool SetTranslation(IFrame origin, IFrame target, I3dCartesianCoordinates<double> p);

        bool Get(IFrame origin, IFrame target, ref IRigidMatrix rigidMatrix);
        IRigidMatrix Get(IFrame origin, IFrame target);
    }

    /// <summary>
    /// Reference frame interface
    /// </summary>
    public interface IFrame
    { }
}
