/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;

namespace AquaMate.GLViewer
{
    public struct Vector3D
    {
        public static readonly Vector3D Zero = new Vector3D(0, 0, 0);

        public float X;
        public float Y;
        public float Z;


        public Vector3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public bool IsZero()
        {
            return (X == 0.0f && Y == 0.0f && Z == 0.0f);
        }

        public float Length()
        {
            return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
        }
    }
}
