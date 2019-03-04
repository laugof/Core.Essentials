/// <summary>
/// Author: Laurent Goffin
/// Generic interfaces for linear algebra
/// </summary>
namespace Core.Interface
{
    /// <summary>
    /// Vector
    /// </summary>
    public interface IVector<T>
    {
        T this[int index] { get; set; }
        int Length { get; }
    }

    /// <summary>
    /// Matrix
    /// </summary>
    public interface IMatrix<T>
    {
        T this[int row, int column] { get; set; }
        int RowCount { get; }
        int ColumnCount { get; }
    }
}
