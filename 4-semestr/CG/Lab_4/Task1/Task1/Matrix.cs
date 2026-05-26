using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Matrix
    {
        public double[,] Data = new double[3, 3];

        public Matrix()
        {
            ResetToIdentity();
        }

        public void ResetToIdentity()
        {
            Data[0, 0] = 1; Data[0, 1] = 0; Data[0, 2] = 0;
            Data[1, 0] = 0; Data[1, 1] = 1; Data[1, 2] = 0;
            Data[2, 0] = 0; Data[2, 1] = 0; Data[2, 2] = 1;
        }

        public void MakeTranslation(double dx, double dy)
        {
            ResetToIdentity();
            Data[2, 0] = dx;
            Data[2, 1] = dy;
        }

        public void MakeScaling(double sx, double sy)
        {
            ResetToIdentity();
            Data[0, 0] = sx;
            Data[1, 1] = sy;
        }

        public void MakeRotation(double angleDegrees)
        {
            ResetToIdentity();
            double rad = angleDegrees * Math.PI / 180.0;
            double cos = Math.Cos(rad);
            double sin = Math.Sin(rad);

            Data[0, 0] = cos; Data[0, 1] = -sin;
            Data[1, 0] = sin; Data[1, 1] = cos;
        }

        public static Matrix Multiply(Matrix A, Matrix B)
        {
            Matrix result = new Matrix();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result.Data[i, j] = A.Data[i, 0] * B.Data[0, j] +
                                        A.Data[i, 1] * B.Data[1, j] +
                                        A.Data[i, 2] * B.Data[2, j];
                }
            }
            return result;
        }
    }
}
