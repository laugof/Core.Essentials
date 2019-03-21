using Core.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Author: Laurent Goffin
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
        /// <param name="v">Vector</param>
        /// <returns></returns>
        public static double Norm2(I2dCartesianCoordinates<double> v)
        {
            return v.X * v.X + v.Y * v.Y;
        }

        /// <summary>
        /// Norm of v
        /// </summary>
        /// <param name="v">Vector</param>
        /// <returns></returns>
        public static double Norm(I2dCartesianCoordinates<double> v) => Math.Sqrt(Norm2(v));

        /// <summary>
        /// Return normalized vector of v
        /// </summary>
        /// <param name="v">Vector</param>
        /// <returns></returns>
        public static I2dCartesianCoordinates<double> Normalize(I2dCartesianCoordinates<double> v)
        {
            var norm = Norm(v);
            var p = new Point2d();
            if (norm > 0) p.SetCartesian(v.X / norm, v.Y / norm);
            return p;
        }

        /// <summary>
        /// Squared norm of v
        /// </summary>
        /// <param name="v">Vector</param>
        /// <returns></returns>
        public static double Norm2(I3dCartesianCoordinates<double> v)
        {
            return v.X * v.X + v.Y * v.Y + v.Z * v.Z;
        }

        /// <summary>
        /// Norm of v
        /// </summary>
        /// <param name="v">Vector</param>
        /// <returns></returns>
        public static double Norm(I3dCartesianCoordinates<double> v) => Math.Sqrt(Norm2(v));

        /// <summary>
        /// Return normalized vector of v
        /// </summary>
        /// <param name="v">Vector</param>
        /// <returns></returns>
        public static I3dCartesianCoordinates<double> Normalize(I3dCartesianCoordinates<double> v)
        {
            var norm = Norm(v);
            var p = new Point3d();
            if (norm > 0) p.SetCartesian(v.X / norm, v.Y / norm, v.Z / norm);
            return p;
        }

        #endregion Norm

        #region Distance

        /// <summary>
        /// Squared distance between p1 and p2
        /// </summary>
        /// <param name="p1">Point1</param>
        /// <param name="p2">Point2</param>
        /// <returns></returns>
        public static double Distance2(IVector<double> p1, IVector<double> p2)
        {
            var distance = 0.0;
            var dimension = p1.Length;
            if (p2.Length > dimension) dimension = p2.Length;
            for (int i = 0; i < dimension; ++i)
            {
                var a1 = i < p1.Length ? p1[i] : 0.0;
                var a2 = i < p2.Length ? p2[i] : 0.0;
                var x = a1 - a2;
                distance += x * x;
            }
            return distance;
        }

        /// <summary>
        /// Distance between p1 and p2
        /// </summary>
        /// <param name="p1">Point1</param>
        /// <param name="p2">Point2</param>
        /// <returns></returns>
        public static double Distance(IVector<double> p1, IVector<double> p2) => Math.Sqrt(Distance2(p1, p2));

        #endregion Distance

        #region Barycenter

        internal class Point2d : I2dCartesianCoordinates<double>
        {
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
        /// <returns>Center of gravity</returns>
        public static I2dCartesianCoordinates<double> Barycenter(List<I2dCartesianCoordinates<double>> pl)
        {
            I2dCartesianCoordinates<double> CenterOfGravity = new Point2d();
            foreach (var point in pl)
            {
                CenterOfGravity.X += point.X;
                CenterOfGravity.Y += point.Y;
            }
            if (pl.Count > 0)
            {
                var n = 1.0 / (double)pl.Count;
                CenterOfGravity.X *= n;
                CenterOfGravity.Y *= n;
            }
            return CenterOfGravity;
        }

        internal class Point3d : I3dCartesianCoordinates<double>
        {
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
        public static I3dCartesianCoordinates<double> Barycenter(List<I3dCartesianCoordinates<double>> pl)
        {
            I3dCartesianCoordinates<double> CenterOfGravity = new Point3d();
            foreach (var point in pl)
            {
                CenterOfGravity.X += point.X;
                CenterOfGravity.Y += point.Y;
                CenterOfGravity.Z += point.Z;
            }
            if (pl.Count > 0)
            {
                var n = 1.0 / (double)pl.Count;
                CenterOfGravity.X *= n;
                CenterOfGravity.Y *= n;
                CenterOfGravity.Z *= n;
            }
            return CenterOfGravity;
        }

        #endregion Barycenter

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
            var p = new Point3d();
            p.SetCartesian(X, Y, Z);
            return p;
        }

        /// <summary>
        /// Dot product (scalar product)
        /// </summary>
        /// <param name="A">Vector</param>
        /// <param name="B">Vector</param>
        /// <returns>double</returns>
        public static double DotProduct(IVector<double> A, IVector<double> B)
        {
            var length = Math.Max(A.Length, B.Length);
            double r = 0, a, b;
            for (int i = 0; i < length; ++i)
            {
                a = (i < A.Length) ? A[i] : 0;
                b = (i < B.Length) ? B[i] : 0;
                r += a * b;
            }
            return r;
        }

        /// <summary>
        /// Are the two vectors orthogonal?
        /// </summary>
        /// <param name="A">3d vector</param>
        /// <param name="B">3d vector</param>
        /// <param name="epsilon">Tolerance</param>
        /// <returns></returns>
        public static bool Orthogonal(IVector<double> A, IVector<double> B, double epsilon = 1e-6)
        {
            return DotProduct(A, B) < epsilon;
        }
    }
}
