/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;

namespace AquaMate.GLViewer
{
    public struct Point3D
    {
        public static readonly Point3D Zero = new Point3D(0, 0, 0);

        public float X;
        public float Y;
        public float Z;


        public Point3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public bool IsZero()
        {
            return (X == 0.0f && Y == 0.0f && Z == 0.0f);
        }

        public Point3D Sub(Point3D p0)
        {
            Point3D res;
            res.X = X - p0.X;
            res.Y = Y - p0.Y;
            res.Z = Z - p0.Z;
            return res;
        }
    }
}
