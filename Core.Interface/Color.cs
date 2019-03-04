/// <summary>
/// Author: Laurent Goffin
/// Generic interfaces
/// </summary>
namespace Core.Interface
{
    /// <summary>
    /// RGB: [0 , 1]
    /// </summary>
    public interface IRGB
    {
        double R { get; }
        double G { get; }
        double B { get; }
    }
}
