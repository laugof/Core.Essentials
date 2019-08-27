namespace Core.Algorithm
{
    /// <summary>
    /// Author: Laurent Goffin
    /// Useful mathematics methods
    /// </summary>
    public static class Mathematics
    {
        /// <summary>
        /// Return if a is near b about +/- epsilon
        /// or if Abs(a - b) is inferior to Epsilon 
        /// </summary>
        public static bool Near(double a, double b, double Epsilon)
        {
            return System.Math.Abs(a - b) < Epsilon;
        }

        /// <summary>
        /// Return if a is near zero about +/- epsilon
        /// or if Abs(a) is inferior to Epsilon
        /// </summary>
        public static bool NearEpsilon(double a, double Epsilon)
        {
            return System.Math.Abs(a) < System.Math.Abs(Epsilon);
        }

        public enum SignType { ZeroIsNegative, ZeroIsZero, ZeroIsPositive };

        /// <summary>
        /// Return the value sign
        /// -1, 0 or +1 in function of the sign type
        /// </summary>
        public static int Sign(double value, SignType type)
        {
            double Epsilon = 0.0;//1e-8;
            if (value < -Epsilon) return -1;
            if (value > Epsilon) return +1;
            if (type == SignType.ZeroIsNegative) return -1;
            if (type == SignType.ZeroIsPositive) return +1;
            return 0;
        }

        /// <summary>
        /// Return the value sign
        /// -1, 0 or +1
        /// </summary>
        public static int Sign(double value)
        {
            return Sign(value, SignType.ZeroIsZero);
        }

        public static T Minimum<T>(T a, T b) where T : System.IComparable<T>
        {
            if (a.CompareTo(b) <= 0) return a; else return b;
        }

        public static T Maximum<T>(T a, T b) where T : System.IComparable<T>
        {
            if (a.CompareTo(b) >= 0) return a; else return b;
        }

        public static T Clamp<T>(T value, T min, T max) where T : System.IComparable<T>
        {
            return Maximum(min, Minimum(max, value));
        }

        /// <summary>
        /// Return if an integer is even
        /// .. -4 -2 0 +2 +4 ..
        /// </summary>
        public static bool Even(int value)
        {
            int half = value / 2;
            return half * 2 == value;
        }

        /// <summary>
        /// Return if an integer is odd
        /// .. -3 -1 +1 +3..
        /// </summary>
        public static bool Odd(int value)
        {
            return !Even(value);
        }

        /// <summary>
        /// Cross ration of 4 scalars
        /// </summary>
        public static double CrossRatio(double a, double b, double c, double d)
        {
            return ((c - a) * (d - b)) / ((d - a) * (c - b));
        }
    }
}
