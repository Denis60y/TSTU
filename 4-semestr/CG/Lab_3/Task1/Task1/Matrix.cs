using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task1
{
    public class Matrix
    {
        public double[,] Data = new double[4, 4];

        public Matrix()
        {
            ResetToIdentity();
        }

        public void ResetToIdentity()
        {
            Data[0, 0] = 1; Data[0, 1] = 0; Data[0, 2] = 0; Data[0, 3] = 0;
            Data[1, 0] = 0; Data[1, 1] = 1; Data[1, 2] = 0; Data[1, 3] = 0;
            Data[2, 0] = 0; Data[2, 1] = 0; Data[2, 2] = 1; Data[2, 3] = 0;
            Data[3, 0] = 0; Data[3, 1] = 0; Data[3, 2] = 0; Data[3, 3] = 1;
        }

        public void CavaleProjection()
        {
            ResetToIdentity();
            Data[2, 0] = Math.Cos(45.0 * Math.PI / 180.0); 
            Data[2, 1] = Math.Sin(45.0 * Math.PI / 180.0);
            Data[2, 2] = 0.0;
        }

        public void CabinProjection()
        {
            ResetToIdentity();
            Data[2, 0] = 0.5 * Math.Cos(63.435 * Math.PI / 180.0); 
            Data[2, 1] = 0.5 * Math.Sin(63.435 * Math.PI / 180.0);
            Data[2, 2] = 0.0;
        }

        public void CenterProjection(double d)
        {
            ResetToIdentity();
            Data[2, 3] = -1.0/d;
            Data[2, 2] = 0.0;
        }

        public void MakeTranslation(double dx, double dy, double dz)
        {
            ResetToIdentity();
            Data[3, 0] = dx;
            Data[3, 1] = dy;
            Data[3, 2] = dz;
        }

        public void MakeScaling(double sx, double sy, double sz)
        {
            ResetToIdentity();
            Data[0, 0] = sx;
            Data[1, 1] = sy;
            Data[2, 2] = sz;
        }

        public void MakeRotationX(double angleDegrees)
        {
            ResetToIdentity();
            double rad = angleDegrees * Math.PI / 180.0;
            double cos = Math.Cos(rad);
            double sin = Math.Sin(rad);

            Data[1, 1] = cos; Data[2, 1] = sin;
            Data[1, 2] = -sin; Data[2, 2] = cos;
        }

        public void MakeRotationY(double angleDegrees)
        {
            ResetToIdentity();
            double rad = angleDegrees * Math.PI / 180.0;
            double cos = Math.Cos(rad);
            double sin = Math.Sin(rad);

            Data[0, 0] = cos; Data[0, 2] = -sin;
            Data[2, 0] = sin; Data[2, 2] = cos;
        }

        public void MakeRotationZ(double angleDegrees)
        {
            ResetToIdentity();
            double rad = angleDegrees * Math.PI / 180.0;
            double cos = Math.Cos(rad);
            double sin = Math.Sin(rad);

            Data[0, 0] = cos; Data[0, 1] = sin;
            Data[1, 0] = -sin; Data[1, 1] = cos;
        }

        public static Matrix Multiply(Matrix A, Matrix B)
        {
            Matrix result = new Matrix();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result.Data[i, j] = A.Data[i, 0] * B.Data[0, j] +
                                        A.Data[i, 1] * B.Data[1, j] +
                                        A.Data[i, 2] * B.Data[2, j] +
                                        A.Data[i, 3] * B.Data[3, j];
                }
            }
            return result;
        }
    }
}
