/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Drawing;
using CsGL.OpenGL;

namespace M3DViewerGL
{
    public struct Point3D
    {
        public float X;
        public float Y;
        public float Z;

        public Point3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public static class M3DHelper
    {
        public const float DEG2RAD = 3.14159F / 180;


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
            Point3D U, V, Normal;

            U.X = p2.X - p1.X;
            U.Y = p2.Y - p1.Y;
            U.Z = p2.Z - p1.Z;

            V.X = p3.X - p1.X;
            V.Y = p3.Y - p1.Y;
            V.Z = p3.Z - p1.Z;

            Normal.X = (U.Y * V.Z) - (U.Z * V.Y);
            Normal.Y = (U.Z * V.X) - (U.X * V.Z);
            Normal.Z = (U.X * V.Y) - (U.Y * V.X);

            float distance = (float)Math.Sqrt((Normal.X * Normal.X) + (Normal.Y * Normal.Y) + (Normal.Z * Normal.Z));
            Normal.X = Normal.X / distance;
            Normal.Y = Normal.Y / distance;
            Normal.Z = Normal.Z / distance;
    
            return Normal;
        }

        /*public static Point3D ScaleVector(Point3D vector, double length)
        {
            double scale = length / vector.Length;
            return new Point3D(vector.X * scale, vector.Y * scale, vector.Z * scale);
        }*/

        public static Point3D GetVector(Point3D p1, Point3D p2)
        {
            Point3D res;
            res.X = p2.X - p1.X;
            res.Y = p2.Y - p1.Y;
            res.Z = p2.Z - p1.Z;
            return res;
        }

        public static float GetAngle(Point3D v1, Point3D v2)
        {
            float radAngle = (float)Math.Acos((v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z) / ((Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y + v1.Z * v1.Z) * Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y + v2.Z * v2.Z))));
            return radAngle / M3DHelper.DEG2RAD;
        }

        public static float GetAngle(Point3D p0, Point3D p1, Point3D p2)
        {
            var v1 = M3DHelper.GetVector(p0, p1);
            var v2 = M3DHelper.GetVector(p0, p2);
            return M3DHelper.GetAngle(v1, v2);
        }

        public static PointF GetLineMidpoint(float x1, float y1, float x2, float y2)
        {
            float mx = x1 + (x2 - x1) / 2;
            float my = y1 + (y2 - y1) / 2;
            return new PointF(mx, my);
        }

        public static Point3D GetLineMidpoint(Point3D p1, Point3D p2)
        {
            float mx = (p1.X + p2.X) / 2.0f;
            float my = (p1.Y + p2.Y) / 2.0f;
            float mz = (p1.Z + p2.Z) / 2.0f;
            return new Point3D(mx, my, mz);
        }

        public static PointF[] GetArcPoints(PointF center, int count, float radius, float startAngle, float endAngle)
        {
            PointF[] result = new PointF[count];

            if (count > 0) {
                float delta = endAngle - startAngle;
                // size of the circle's partition, grad
                float degSection = delta / count;

                for (int i = 0; i < count; i++) {
                    float degInRad = (startAngle + i * degSection) * DEG2RAD;
                    float dx = (float)Math.Cos(degInRad) * radius;
                    float dy = (float)Math.Sin(degInRad) * radius;

                    result[i] = new PointF(center.X + dx, center.Y + dy);
                }
            }

            return result;
        }

        public static void DrawCylinder(int slices, float height, float radius, float startAngle, float wedgeAngle)
        {
            float angleStep = wedgeAngle / slices;
            float y1 = 0.0f;
            float y2 = y1 + height;

            OpenGL.glBegin(OpenGL.GL_TRIANGLE_STRIP);
            for (int j = 0; j <= slices; ++j) {
                double a = (startAngle + j * angleStep) * DEG2RAD;

                float x = radius * (float)Math.Cos(a);
                float z = radius * (float)Math.Sin(a);

                OpenGL.glNormal3f(x / radius, 0.0f, z / radius);
                OpenGL.glVertex3f(x, y1, z);

                OpenGL.glNormal3f(x / radius, 0.0f, z / radius);
                OpenGL.glVertex3f(x, y2, z);
            }
            OpenGL.glEnd();
        }

        public static double Dist(PointF pt1, PointF pt2)
        {
            float dx = pt2.X - pt1.X;
            float dy = pt2.Y - pt1.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public static void DrawTriangle(Point3D point1, Point3D point2, Point3D point3)
        {
            var n = CalculateSurfaceNormal(point1, point2, point3);

            OpenGL.glBegin(OpenGL.GL_TRIANGLES);

            OpenGL.glNormal3f(n.X, n.Y, n.Z);
            OpenGL.glVertex3f(point1.X, point1.Y, point1.Z);

            OpenGL.glNormal3f(n.X, n.Y, n.Z);
            OpenGL.glVertex3f(point2.X, point2.Y, point2.Z);

            OpenGL.glNormal3f(n.X, n.Y, n.Z);
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
            Point3D pm = GetLineMidpoint(p1, p3);

            DrawTriangle(p1, pm, p2);
            DrawTriangle(p2, pm, p3);
            DrawTriangle(p3, pm, p4);
            DrawTriangle(p4, pm, p1);

            /*OpenGL.glBegin(OpenGL.GL_POLYGON);
            OpenGL.glVertex3f(p1.X, p1.Y, p1.Z);
            OpenGL.glVertex3f(p2.X, p2.Y, p2.Z);
            OpenGL.glVertex3f(p3.X, p3.Y, p3.Z);
            OpenGL.glVertex3f(p4.X, p4.Y, p4.Z);
            OpenGL.glEnd();*/
        }

        public static void DrawBox(Point3D p1, Point3D p2, Point3D p3, Point3D p4,
                                   Point3D p5, Point3D p6, Point3D p7, Point3D p8)
        {
            // GL_CCW(default), GL_CW
            //GL.glFrontFace(GL.GL_CW);

            DrawRect(p1, p2, p3, p4);
            DrawRect(p5, p6, p7, p8);

            DrawRect(p1, p2, p6, p5);
            DrawRect(p2, p3, p7, p6);
            DrawRect(p3, p4, p8, p7);
            DrawRect(p1, p4, p8, p5);
        }
    }
}
