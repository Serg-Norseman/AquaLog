/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using CsGL.OpenGL;

namespace AquaLog.GLViewer
{
    [Flags]
    public enum BoxSide
    {
        Top,
        Bottom,
        Left,
        Right,
        Back,
        Front
    }

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

    public static class M3DHelper
    {
        public const float DEG2RAD = (float)Math.PI / 180.0f;
        public const BoxSide AllSides = BoxSide.Top | BoxSide.Bottom | BoxSide.Left | BoxSide.Right | BoxSide.Back | BoxSide.Front;
        public const BoxSide AllSidesWF = BoxSide.Top | BoxSide.Bottom | BoxSide.Left | BoxSide.Right | BoxSide.Back;


        public static void SetMaterial(float[] diffParams, float[] specParams, float shin)
        {
            GL.glMaterialfv(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, diffParams);
            GL.glMaterialfv(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SPECULAR, specParams);
            OpenGL.glMaterialf(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SHININESS, shin);
            //GL.glMaterialfv(GL.GL_FRONT_AND_BACK, GL.GL_EMISSION, new float[] { 0.7f, 0.7f, 0.7f, 0.1f });
        }

        public static void SetLight(uint index, float[] ambiParams, float[] diffParams, float[] specParams, float[] pos)
        {
            uint light = (uint)(OpenGL.GL_LIGHT0 + index);
            OpenGL.glEnable(light);

            if (ambiParams != null) {
                GL.glLightfv(light, OpenGL.GL_AMBIENT, ambiParams);
            }

            if (diffParams != null) {
                GL.glLightfv(light, OpenGL.GL_DIFFUSE, diffParams);
            }

            if (specParams != null) {
                GL.glLightfv(light, OpenGL.GL_SPECULAR, specParams);
            }

            if (pos != null) {
                GL.glLightfv(light, OpenGL.GL_POSITION, pos);
            }

            //OpenGL.glLightf(OpenGL.GL_LIGHT1, OpenGL.GL_LINEAR_ATTENUATION, 1.0f / 32.0f);
            //OpenGL.glLightf(OpenGL.GL_LIGHT1, OpenGL.GL_QUADRATIC_ATTENUATION, 1.0f / 64.0f);
        }

        public static Point3D CalculateSurfaceNormal(Point3D p1, Point3D p2, Point3D p3)
        {
            Point3D u = p2.Sub(p1);
            Point3D v = p3.Sub(p1);

            Point3D normal;
            normal.X = (u.Y * v.Z) - (u.Z * v.Y);
            normal.Y = (u.Z * v.X) - (u.X * v.Z);
            normal.Z = (u.X * v.Y) - (u.Y * v.X);

            float distance = (float)Math.Sqrt((normal.X * normal.X) + (normal.Y * normal.Y) + (normal.Z * normal.Z));
            normal.X = normal.X / distance;
            normal.Y = normal.Y / distance;
            normal.Z = normal.Z / distance;
    
            return normal;
        }

        /*public static Point3D ScaleVector(Point3D vector, double length)
        {
            double scale = length / vector.Length;
            return new Point3D(vector.X * scale, vector.Y * scale, vector.Z * scale);
        }*/

        public static float GetAngle(Point3D v1, Point3D v2)
        {
            float radAngle = (float)Math.Acos((v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z) / ((Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y + v1.Z * v1.Z) * Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y + v2.Z * v2.Z))));
            return radAngle / M3DHelper.DEG2RAD;
        }

        public static float GetAngle(Point3D p0, Point3D p1, Point3D p2)
        {
            var v1 = p1.Sub(p0);
            var v2 = p2.Sub(p0);
            return M3DHelper.GetAngle(v1, v2);
        }

        public static Point3D GetLineMidpoint(Point3D p1, Point3D p2)
        {
            float mx = (p1.X + p2.X) / 2.0f;
            float my = (p1.Y + p2.Y) / 2.0f;
            float mz = (p1.Z + p2.Z) / 2.0f;
            return new Point3D(mx, my, mz);
        }

        public static IList<Point3D> GetArcPoints(int slices, float radius, float startAngle, float wedgeAngle)
        {
            var points = new List<Point3D>();

            float angleStep = wedgeAngle / slices;
            for (int j = 0; j <= slices; ++j) {
                double a = (startAngle + j * angleStep) * DEG2RAD;
                float x = radius * (float)Math.Cos(a);
                float z = radius * (float)Math.Sin(a);
                points.Add(new Point3D(x, 0.0f, z));
            }

            return points;
        }

        public static void DrawCylinder(IList<Point3D> points, float height, float radius)
        {
            float y1 = 0.0f;
            float y2 = y1 + height;

            OpenGL.glBegin(OpenGL.GL_TRIANGLE_STRIP);
            for (int j = 0; j < points.Count; ++j) {
                var pt = points[j];

                OpenGL.glNormal3f(pt.X / radius, 0.0f, pt.Z / radius);
                OpenGL.glVertex3f(pt.X, y1, pt.Z);

                OpenGL.glNormal3f(pt.X / radius, 0.0f, pt.Z / radius);
                OpenGL.glVertex3f(pt.X, y2, pt.Z);
            }
            OpenGL.glEnd();
        }

        public static void DrawCylinder(int slices, float height, float radius, float startAngle, float wedgeAngle)
        {
            var points = GetArcPoints(slices, radius, startAngle, wedgeAngle);
            DrawCylinder(points, height, radius);
        }

        public static double Dist(Point3D pt1, Point3D pt2)
        {
            float dx = pt2.X - pt1.X;
            float dy = pt2.Y - pt1.Y;
            float dz = pt2.Z - pt1.Z;
            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        public static void DrawTriangle(Point3D point1, Point3D point2, Point3D point3)
        {
            DrawTriangle(point1, point2, point3, Point3D.Zero);
        }

        public static void DrawTriangle(Point3D point1, Point3D point2, Point3D point3, Point3D normal)
        {
            if (normal.IsZero()) {
                normal = CalculateSurfaceNormal(point1, point2, point3);
            }

            OpenGL.glBegin(OpenGL.GL_TRIANGLES);

            OpenGL.glNormal3f(normal.X, normal.Y, normal.Z);
            OpenGL.glVertex3f(point1.X, point1.Y, point1.Z);

            OpenGL.glNormal3f(normal.X, normal.Y, normal.Z);
            OpenGL.glVertex3f(point2.X, point2.Y, point2.Z);

            OpenGL.glNormal3f(normal.X, normal.Y, normal.Z);
            OpenGL.glVertex3f(point3.X, point3.Y, point3.Z);

            OpenGL.glEnd();
        }

        public static void DrawCubeSide(float size, int divisions)
        {
            float squareSize = size / divisions;
            float startPoint = -size / 2;
            for (int i = 0; i < divisions; ++i)
                for (int j = 0; j < divisions; ++j) {
                    float x0 = i * squareSize + startPoint, x1 = x0 + squareSize;
                    float y0 = j * squareSize + startPoint, y1 = y0 + squareSize;
                    OpenGL.glBegin(OpenGL.GL_TRIANGLES);
                    OpenGL.glNormal3f(0, 0, -1);
                    OpenGL.glVertex3f(x0, y0, startPoint);
                    OpenGL.glVertex3f(x1, y0, startPoint);
                    OpenGL.glVertex3f(x0, y1, startPoint);
                    OpenGL.glVertex3f(x0, y1, startPoint);
                    OpenGL.glVertex3f(x1, y0, startPoint);
                    OpenGL.glVertex3f(x1, y1, startPoint);
                    OpenGL.glEnd();
                }
        }

        public static void DrawRect(Point3D p1, Point3D p2, Point3D p3, Point3D p4)
        {
            DrawRect(p1, p2, p3, p4, Point3D.Zero);
        }

        public static void DrawRect(Point3D p1, Point3D p2, Point3D p3, Point3D p4, Point3D normal)
        {
            Point3D pm = GetLineMidpoint(p1, p3);

            DrawTriangle(p1, pm, p2, normal);
            DrawTriangle(p2, pm, p3, normal);
            DrawTriangle(p3, pm, p4, normal);
            DrawTriangle(p4, pm, p1, normal);

            /*OpenGL.glBegin(OpenGL.GL_POLYGON);
            OpenGL.glVertex3f(p1.X, p1.Y, p1.Z);
            OpenGL.glVertex3f(p2.X, p2.Y, p2.Z);
            OpenGL.glVertex3f(p3.X, p3.Y, p3.Z);
            OpenGL.glVertex3f(p4.X, p4.Y, p4.Z);
            OpenGL.glEnd();*/
        }

        public static void DrawBox(Point3D p1, Point3D p2, Point3D p3, Point3D p4,
                                   Point3D p5, Point3D p6, Point3D p7, Point3D p8,
                                   BoxSide sides = AllSides)
        {
            // GL_CCW(default), GL_CW
            //GL.glFrontFace(GL.GL_CW);

            if (sides.HasFlag(BoxSide.Top)) DrawRect(p1, p2, p3, p4, new Point3D(0.0f, 1.0f, 0.0f));
            if (sides.HasFlag(BoxSide.Bottom)) DrawRect(p5, p6, p7, p8, new Point3D(0.0f, -1.0f, 0.0f));

            if (sides.HasFlag(BoxSide.Back)) DrawRect(p1, p2, p6, p5, new Point3D(0.0f, 0.0f, -1.0f));
            if (sides.HasFlag(BoxSide.Right)) DrawRect(p2, p3, p7, p6, new Point3D(+1.0f, 0.0f, 0.0f));
            if (sides.HasFlag(BoxSide.Front)) DrawRect(p3, p4, p8, p7, new Point3D(0.0f, 0.0f, +1.0f));
            if (sides.HasFlag(BoxSide.Left)) DrawRect(p1, p4, p8, p5, new Point3D(-1.0f, 0.0f, 0.0f));
        }

        public static void DrawBox(float x1, float x2, float y1, float y2, float z1, float z2, BoxSide sides = M3DHelper.AllSides)
        {
            M3DHelper.DrawBox(
                new Point3D(x1, y1, z1), new Point3D(x2, y1, z1), new Point3D(x2, y1, z2), new Point3D(x1, y1, z2),
                new Point3D(x1, y2, z1), new Point3D(x2, y2, z1), new Point3D(x2, y2, z2), new Point3D(x1, y2, z2), sides);
        }
    }
}
