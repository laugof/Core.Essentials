/// <summary>
/// Author: Laurent Goffin
/// Generic interfaces for euclidean spaces and 3d rigid transformations between frames
/// </summary>
namespace Core.Interface
{
    /// <summary>
    /// A rigid matrix is a 4x4 matrix coding for 3d euclidean space transformation
    /// It is composed of a rotation matrix (3x3 orthogonal matrix) and a 3d translation
    /// </summary>
    public interface IRigidMatrix
    {
        /// <summary>
        /// 3x3 orthogonal matrix (rotation matrix)
        /// </summary>
        IMatrix<double> RotationMatrix { get; }

        /// <summary>
        /// 3d vector (X,Y,Z)
        /// </summary>
        I3dCartesianCoordinates<double> TranslationVector { get; }

        /// <summary>
        /// Is the rigid matrix identity?
        /// </summary>
        bool IsIdentity();
    }

    /// <summary>
    /// Euclidean space interface
    /// An euclidean space is a graph where nodes are frames and edges are rigid transformations between two frames
    /// </summary>
    public interface IEuclideanSpace
    {
        /// <summary>
        /// Add a new frame (node) in the graph
        /// </summary>
        /// <param name="frame">IFrame</param>
        void AddFrame(IFrame frame);

        /// <summary>
        /// Remove a frame (node) in the graph
        /// </summary>
        /// <param name="frame">IFrame</param>
        void RemoveFrame(IFrame frame);

        /// <summary>
        /// Return if two frames (nodes) are connected in the graph
        /// </summary>
        /// <param name="origin">IFrame</param>
        /// <param name="target">IFrame</param>
        /// <returns>Return if frames are connected</returns>
        bool AreConnected(IFrame origin, IFrame target);

        /// <summary>
        /// Remove a connection (edge) in the graph between two frames (nodes)
        /// or if target is null,
        /// remove all connections (edges) in the graph linked to the origin frame (node)
        /// </summary>
        /// <param name="origin">IFrame</param>
        /// <param name="target">IFrame</param>
        void Remove(IFrame origin, IFrame target = null);

        /// <summary>
        /// Set a connection (edge) between two frames (nodes) and
        /// affect rigidMatrix from origin to target
        /// and rigidMatrix inverse from target to origin
        /// </summary>
        /// <param name="origin">IFrame</param>
        /// <param name="target">IFrame</param>
        /// <param name="rigidMatrix">IRigidMatrix</param>
        bool Set(IFrame origin, IFrame target, IRigidMatrix rigidMatrix = null);

        /// <summary>
        /// Set a connection (edge) between two frames (nodes) and
        /// affect a loaded rigidMatrix from origin to target
        /// and rigidMatrix inverse from target to origin
        /// </summary>
        /// <param name="origin">IFrame</param>
        /// <param name="target">IFrame</param>
        /// <param name="filename">IRigidMatrix filename</param>
        /// <param name="closestRotation">Correct the rotation if necessary</param>
        bool Set(IFrame origin, IFrame target, string filename, bool closestRotation = true);

        /// <summary>
        /// Set a connection (edge) between two frames (nodes) and
        /// affect a pure translation from origin to target
        /// and its inverse from target to origin
        /// </summary>
        /// <param name="origin">IFrame</param>
        /// <param name="target">IFrame</param>
        /// <param name="translation">Cartesian translation</param>
        bool SetTranslation(IFrame origin, IFrame target, I3dCartesianCoordinates<double> translation);

        /// <summary>
        /// Get the IRigidMatrix of a connection (edge) between two frames (nodes):
        /// Rigid transformation from origin to target
        /// </summary>
        /// <param name="origin">IFrame</param>
        /// <param name="target">IFrame</param>
        /// <param name="rigidMatrix">IRigidMatrix</param>
        /// <returns>Return if the connection exists</returns>
        bool Get(IFrame origin, IFrame target, ref IRigidMatrix rigidMatrix);

        /// <summary>
        /// Return the IRigidMatrix of a connection (edge) between two frames (nodes):
        /// Rigid transformation from origin to target
        /// </summary>
        /// <param name="origin">IFrame</param>
        /// <param name="target">IFrame</param>
        /// <returns>Return the IRigidMatrix or null if frames are not connected</returns>
        IRigidMatrix Get(IFrame origin, IFrame target);
    }

    /// <summary>
    /// Reference frame interface
    /// </summary>
    public interface IFrame
    { }
}
