using Core.Interface;
using System;
using System.Diagnostics;

/// <summary>
/// Author: Laurent Goffin
/// Algorithms for ICartesianCoordinates or IVector
/// </summary>
namespace Core.Algorithm
{
    /// <summary>
    /// Properties computed from ICartesianCoordinates 
    /// </summary>
    public static class CartesianCoordinates
    {
        #region Norm

        /// <summary>
        /// Squared norm of v
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <returns></returns>
        public static double Norm2(IVector<double> vector)
        {
            var norm2 = 0.0;
            for (int i = 0; i < vector.Length; ++i)
                norm2 += vector[i] * vector[i];
            return norm2;
        }

        /// <summary>
        /// Norm of v
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <returns></returns>
        public static double Norm(IVector<double> vector) => Math.Sqrt(Norm2(vector));

        /// <summary>
        /// Return normalized vector of v multiplied by a scalar
        /// </summary>
        /// <param name="point">Vector</param>
        /// <returns></returns>
        public static I2dCartesianCoordinates<double> Normalize(I2dCartesianCoordinates<double> point, double scalar = 1.0)
        {
            var norm = Norm(point);
            var p = new Point2d();
            if (norm > 0) p.SetCartesian(scalar * point.X / norm, scalar * point.Y / norm);
            return p;
        }

        /// <summary>
        /// Return normalized vector of v multiplied by a scalar
        /// </summary>
        /// <param name="point">Vector</param>
        /// <returns></returns>
        public static I3dCartesianCoordinates<double> Normalize(I3dCartesianCoordinates<double> point, double scalar = 1.0)
        {
            var norm = Norm(point);
            if (norm > 0) return new Point3d(scalar * point.X / norm, scalar * point.Y / norm, scalar * point.Z / norm);
            else return new Point3d();
        }

        #endregion Norm

        #region Distance

        /// <summary>
        /// Squared distance between two points
        /// </summary>
        /// <param name="point1">Point1</param>
        /// <param name="point2">Point2</param>
        /// <returns></returns>
        public static double Distance2(IVector<double> point1, IVector<double> point2)
        {
            Debug.Assert(point1.Length == point2.Length);
            var distance2 = 0.0;
            var dimension = point1.Length;
            if (point2.Length < dimension) dimension = point2.Length;
            for (int i = 0; i < dimension; ++i)
            {
                var a1 = i < point1.Length ? point1[i] : 0.0;
                var a2 = i < point2.Length ? point2[i] : 0.0;
                var x = a1 - a2;
                distance2 += x * x;
            }
            Debug.Assert(distance2 >= 0.0);
            return distance2;
        }

        /// <summary>
        /// Distance between p1 and p2
        /// </summary>
        /// <param name="point1">Point1</param>
        /// <param name="point2">Point2</param>
        /// <returns></returns>
        public static double Distance(IVector<double> point1, IVector<double> point2) => Math.Sqrt(Distance2(point1, point2));

        #endregion Distance

        #region Barycenter

        internal class Point2d : IPoint2d
        {
            public Point2d(double x = 0.0, double y = 0.0) { SetCartesian(x, y); }

            public Point2d(I2dCartesianCoordinates<double> p) { SetCartesian(p); }

            public double X { get; set; }
            public double Y { get; set; }

            public void SetCartesian(double x, double y) { X = x; Y = y; }
            public void SetCartesian(I2dCartesianCoordinates<double> p) { X = p.X; Y = p.Y; }

            public double this[int index]
            {
                get
                {
                    Debug.Assert(index >= 0 && index < Length);
                    switch (index)
                    {
                        case 0: return X;
                        case 1: return Y;
                        default: return double.NaN;
                    }
                }

                set
                {
                    Debug.Assert(index >= 0 && index < Length);
                    switch (index)
                    {
                        case 0: X = value; break;
                        case 1: Y = value; break;
                        default: break;
                    }
                }
            }

            public int Length { get { return 2; } }
        }

        /// <summary>
        /// Compute the center of gravity of the point cloud (Averaged point)
        /// </summary>
        /// <param name="pl">point list</param>
        /// <returns>Center of gravity or null if pointlist is empty</returns>
        public static I2dCartesianCoordinates<double> Barycenter(I2dCartesianCoordinates<double>[] pl)
        {
            if (pl.Length < 1) return null;
            var barycenter = new Point2d(pl[0].X, pl[0].Y);
            foreach (var point in pl)
            {
                barycenter.X += point.X;
                barycenter.Y += point.Y;
            }
            if (pl.Length > 0)
            {
                var n = 1.0 / (double)pl.Length;
                barycenter.X *= n;
                barycenter.Y *= n;
            }
            return barycenter;
        }

        /// <summary>
        /// Compute the 'Top-Left' corner of the point cloud (Min x and Min y)
        /// </summary>
        /// <param name="pl">point list</param>
        /// <returns>Top-Left corner or null if pointlist is empty</returns>
        public static I2dCartesianCoordinates<double> MinXY(I2dCartesianCoordinates<double>[] pl)
        {
            if (pl.Length < 1) return null;
            var min = new Point2d(pl[0].X, pl[0].Y);
            foreach (var point in pl)
            {
                if (point.X < min.X) min.X = point.X;
                if (point.Y < min.Y) min.Y = point.Y;
            }
            return min;
        }

        /// <summary>
        /// Compute the 'Bottom-Right' corner of the point cloud (Max x and Max y)
        /// </summary>
        /// <param name="pl">point list</param>
        /// <returns>Bottom-Right corner or null if pointlist is empty</returns>
        public static I2dCartesianCoordinates<double> MaxXY(I2dCartesianCoordinates<double>[] pl)
        {
            if (pl.Length < 1) return null;
            var max = new Point2d(pl[0].X, pl[0].Y);
            foreach (var point in pl)
            {
                if (point.X > max.X) max.X = point.X;
                if (point.Y > max.Y) max.Y = point.Y;
            }
            return max;
        }

        internal class Point3d : I3dCartesianCoordinates<double>
        {
            public Point3d(double x = 0.0, double y = 0.0, double z = 0.0) { SetCartesian(x, y, z); }

            public Point3d(I3dCartesianCoordinates<double> coordinates) { SetCartesian(coordinates); }

            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }

            public void SetCartesian(double x, double y, double z) { X = x; Y = y; Z = z; }
            public void SetCartesian(I2dCartesianCoordinates<double> p) { X = p.X; Y = p.Y; Z = 0.0; }
            public void SetCartesian(I3dCartesianCoordinates<double> p) { X = p.X; Y = p.Y; Z = p.Z; }

            public double this[int index]
            {
                get
                {
                    Debug.Assert(index >= 0 && index <= 2);
                    switch (index)
                    {
                        case 0: return X;
                        case 1: return Y;
                        case 2: return Z;
                        default: return double.NaN;
                    }
                }

                set
                {
                    Debug.Assert(index >= 0 && index <= 2);
                    switch (index)
                    {
                        case 0: X = value; break;
                        case 1: Y = value; break;
                        case 2: Z = value; break;
                        default: break;
                    }
                }
            }

            public int Length { get { return 3; } }
        }

        /// <summary>
        /// Compute the center of gravity of the point cloud (Averaged point)
        /// </summary>
        /// <param name="pl">point list</param>
        /// <returns>Center of gravity</returns>
        public static I3dCartesianCoordinates<double> Barycenter(I3dCartesianCoordinates<double>[] pl)
        {
            var CenterOfGravity = new Point3d();
            foreach (var point in pl)
            {
                CenterOfGravity.X += point.X;
                CenterOfGravity.Y += point.Y;
                CenterOfGravity.Z += point.Z;
            }
            if (pl.Length > 0)
            {
                var n = 1.0 / (double)pl.Length;
                CenterOfGravity.X *= n;
                CenterOfGravity.Y *= n;
                CenterOfGravity.Z *= n;
            }
            return CenterOfGravity;
        }

        #endregion Barycenter

        /// <summary>
        /// Return if point is on a geometric shape
        /// </summary>
        /// <param name="shape">3d geometric shape</param>
        /// <param name="point">3d point</param>
        /// <param name="distanceTolerance">Is on the shape if distance is less than tolerance</param>
        public static bool IsOn(I3dPointDistance<double> shape, I3dCartesianCoordinates<double> point, double distanceTolerance = 1e-6)
        {
            var distance = shape.Distance(point);
            return distance < 0.0 ? false : distance <= distanceTolerance;
        }

        /// <summary>
        /// Return the addition: v1 + v2
        /// </summary>
        /// <param name="v1">3d vector</param>
        /// <param name="v2">3d vector</param>
        public static I3dCartesianCoordinates<double> Add(I3dCartesianCoordinates<double> v1, I3dCartesianCoordinates<double> v2)
        {
            var p = new Point3d();
            p.SetCartesian(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
            return p;
        }

        /// <summary>
        /// Mutiply scalar to Vector
        /// </summary>
        /// <param name="scalar">scalar</param>
        /// <param name="vector">Vector</param>
        /// <returns></returns>
        public static I3dCartesianCoordinates<double> Multiply(double scalar, I3dCartesianCoordinates<double> vector)
        {
            return new Point3d(scalar * vector.X, scalar * vector.Y, scalar * vector.Z);
        }

        public static I3dCartesianCoordinates<double> Multiply(I3dCartesianCoordinates<double> vector, double scalar) => Multiply(scalar, vector);

        /// <summary>
        /// Return the cross product: v1 x v2
        /// </summary>
        /// <param name="v1">3d vector</param>
        /// <param name="v2">3d vector</param>
        public static I3dCartesianCoordinates<double> CrossProduct(I3dCartesianCoordinates<double> v1, I3dCartesianCoordinates<double> v2)
        {
            var X = (v1.Y * v2.Z) - (v1.Z * v2.Y);
            var Y = (v1.Z * v2.X) - (v1.X * v2.Z);
            var Z = (v1.X * v2.Y) - (v1.Y * v2.X);
            return new Point3d(X, Y, Z);
        }

        /// <summary>
        /// Return the cross product: v1 x v2
        /// </summary>
        /// <param name="v1">2d vector</param>
        /// <param name="v2">2d vector</param>
        public static I3dCartesianCoordinates<double> CrossProduct(I2dCartesianCoordinates<double> v1, I2dCartesianCoordinates<double> v2)
        {
            var Z = (v1.X * v2.Y) - (v1.Y * v2.X);
            return new Point3d(0.0, 0.0, Z);
        }

        /// <summary>
        /// Dot product (scalar product)
        /// </summary>
        /// <param name="v1">Vector</param>
        /// <param name="v2">Vector</param>
        /// <returns>double</returns>
        public static double DotProduct(IVector<double> v1, IVector<double> v2)
        {
            var length = Math.Max(v1.Length, v2.Length);
            double s1 = 0.0;
            for (int i = 0; i < length; ++i)
            {
                var a = (i < v1.Length) ? v1[i] : 0;
                var b = (i < v2.Length) ? v2[i] : 0;
                s1 += a * b;
            }
#if DEBUG
            //var s2 = (Matrix.GetRowMatrix(v1) * Matrix.GetColMatrix(v2))[0, 0];
            //var Zero = s1 - s2;
#endif //DEBUG
            return s1;
        }

        /// <summary>
        /// Dot product (scalar product)
        /// </summary>
        /// <param name="v1">Vector</param>
        /// <param name="v2">Vector</param>
        /// <returns>double</returns>
        public static double ScalarProduct(IVector<double> v1, IVector<double> v2) => DotProduct(v1, v2);

        /// <summary>
        /// Return a vector orthogonal to V
        /// </summary>
        /// <param name="vector">Vector 3d</param>
        /// <param name="normalize">Normalize the orthogonal vector?</param>
        public static I3dCartesianCoordinates<double> Orthogonal(I3dCartesianCoordinates<double> vector, bool normalize = true)
        {
            var O = new Point3d();
            var i = 0;
            if (Math.Abs(vector[1]) < Math.Abs(vector[0])) i = 1;
            if (Math.Abs(vector[2]) < Math.Abs(vector[i])) i = 2;
            switch (i)
            {
                case 0: O.SetCartesian(0.0, -vector.Z, vector.Y); break;
                case 1: O.SetCartesian(-vector.Z, 0.0, vector.X); break;
                case 2: O.SetCartesian(-vector.Y, vector.X, 0.0); break;
                default: break;
            }
            //Debug.Assert(Core.Algorithm.Mathematics.Near(Vector3d.Angle(V, O).Get(Angle.Unit.deg), 90.0, 1e-6));
            if (normalize) return Normalize(O);
            return O;
        }

        /// <summary>
        /// Are the two vectors orthogonal?
        /// </summary>
        /// <param name="v1">Vector</param>
        /// <param name="v2">Vector</param>
        /// <param name="epsilon">Tolerance</param>
        /// <returns></returns>
        public static bool Orthogonal(IVector<double> v1, IVector<double> v2, double epsilon = 1e-6)
        {
            return DotProduct(v1, v2) < epsilon;
        }
    }
}
