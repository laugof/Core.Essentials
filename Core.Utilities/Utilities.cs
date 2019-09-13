namespace Core
{
    /// <summary>
    /// Author: Laurent Goffin
    /// </summary>
    public class Utilities
    {
        /// <summary>
        /// Swap two generic variables
        /// </summary>
        public static void Swap<T>(ref T a, ref T b)
        {
            T c = a;
            a = b;
            b = c;
        }
    }
}
