/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using AquaLog.Core;
using AquaLog.Core.Model.Tanks;
using CsGL.OpenGL;

namespace AquaLog.GLViewer
{
    public static class M3DTanks
    {
        private const float ScaleFactor = 0.01f;

        // materials
        private static readonly float[] GlassDiffuse = new float[] { 0.878f, 1.0f, 1.0f, 0.5f };
        private static readonly float[] GlassSpecular = new float[] { 0.95f, 0.95f, 0.95f, 1.0f };
        private static readonly float[] WaterDiffuse = new float[] { 0.0f, 0.3f, 1.0f, 0.5f };


        public static void DrawCylinderTank(CylinderTank tank, bool showWater = true, bool aeration = false)
        {
            OpenGL.glPushMatrix();

            float height = tank.Height;
            float bottomDiameter = tank.BottomDiameter;
            float thickness = tank.GlassThickness;

            bottomDiameter *= ScaleFactor;
            height *= ScaleFactor;
            thickness *= ScaleFactor;

            OpenGL.glTranslatef(0.0f, -height / 2, 0.0f);

            M3DHelper.SetMaterial(GlassDiffuse, GlassSpecular, 128.0f);

            // bottom
            var points = M3DHelper.GetArcPoints(36, bottomDiameter / 2.0f, 0.0f, 360.0f);
            M3DHelper.DrawDisk(points, 0.0f);
            M3DHelper.DrawDisk(points, 0.0f + thickness);

            OpenGL.glPushMatrix();
            // cylinder
            OpenGL.glTranslatef(0.0f, +thickness, 0.0f);
            var radI = (bottomDiameter / 2.0f) - thickness;
            var points1i = M3DHelper.GetArcPoints(36, radI, 0.0f, 360.0f);
            M3DHelper.DrawCylinder(points1i, height - thickness, radI);
            OpenGL.glPopMatrix();

            var radO = bottomDiameter / 2.0f;
            var points1o = M3DHelper.GetArcPoints(36, radO, 0.0f, 360.0f);
            M3DHelper.DrawCylinder(points1o, height, radO);

            DrawCylinderFace(points1i, points1o, 0.0f + height);

            if (showWater) {
                M3DHelper.SetMaterial(WaterDiffuse, WaterDiffuse, 32.0f);
                float watHeight = height - thickness - (ALData.StdWaterOffset * ScaleFactor);

                M3DHelper.DrawDisk(points1i, 0.0f + thickness);
                M3DHelper.DrawDisk(points1i, 0.0f + thickness + watHeight);

                OpenGL.glTranslatef(0.0f, +thickness, 0.0f);
                M3DHelper.DrawCylinder(36, watHeight, radI, 0.0f, 360.0f);

                if (aeration) {
                    var aeraPt = new Point3D(0.0f, 0.0f, bottomDiameter / 2.0f);
                    M3DAeration.DrawBubbles(aeraPt, watHeight);
                }
            }

            OpenGL.glPopMatrix();
        }

        public static void DrawBowlTank(BowlTank tank, bool showWater = true, bool aeration = false)
        {
            OpenGL.glPushMatrix();

            float height = tank.Height;
            float bottomDiameter = tank.BottomDiameter;
            float topDiameter = tank.TopDiameter;
            float thickness = tank.GlassThickness;

            bottomDiameter *= ScaleFactor;
            topDiameter *= ScaleFactor;
            height *= ScaleFactor;
            thickness *= ScaleFactor;

            OpenGL.glTranslatef(0.0f, -height / 2, 0.0f);

            M3DHelper.SetMaterial(GlassDiffuse, GlassSpecular, 128.0f);

            // bottom
            var points = M3DHelper.GetArcPoints(36, bottomDiameter / 2.0f, 0.0f, 360.0f);
            M3DHelper.DrawDisk(points, 0.0f);
            M3DHelper.DrawDisk(points, 0.0f + thickness);

            // top face
            var points1i = M3DHelper.GetArcPoints(36, (topDiameter / 2.0f) - thickness, 0.0f, 360.0f);
            var points1o = M3DHelper.GetArcPoints(36, topDiameter / 2.0f, 0.0f, 360.0f);
            DrawCylinderFace(points1i, points1o, 0.0f + height);

            if (showWater) {
                M3DHelper.SetMaterial(WaterDiffuse, WaterDiffuse, 32.0f);
                float watHeight = height - thickness - (ALData.StdWaterOffset * ScaleFactor);

                //M3DHelper.DrawCylinder(36, height, bottomDiameter / 2.0f, 0.0f, 360.0f);

                if (aeration) {
                    var aeraPt = new Point3D(0.0f, 0.0f, bottomDiameter / 2.0f);
                    M3DAeration.DrawBubbles(aeraPt, watHeight);
                }
            }

            OpenGL.glPopMatrix();
        }

        private static void DrawCylinderFace(IList<Point3D> points1, IList<Point3D> points2, float y)
        {
            OpenGL.glPushMatrix();
            OpenGL.glBegin(OpenGL.GL_TRIANGLE_STRIP);
            for (int j = 0; j < points1.Count; ++j) {
                var pt1 = points1[j];
                var pt2 = points2[j];
                //OpenGL.glNormal3f(pt.X / radius, 0.0f, pt.Z / radius);
                OpenGL.glVertex3f(pt1.X, y, pt1.Z);
                //OpenGL.glNormal3f(pt.X / radius, 0.0f, pt.Z / radius);
                OpenGL.glVertex3f(pt2.X, y, pt2.Z);
            }
            OpenGL.glEnd();
            OpenGL.glPopMatrix();
        }

        public static void DrawRectangularTank(CubeTank tank, bool showWater = true, bool aeration = false)
        {
            var rectTank = new RectangularTank(tank.EdgeSize, tank.EdgeSize, tank.EdgeSize, tank.GlassThickness);
            DrawRectangularTank(rectTank, showWater);
        }

        public static void DrawRectangularTank(RectangularTank tank, bool showWater = true, bool aeration = false)
        {
            OpenGL.glPushMatrix();

            float length = tank.Length;
            float width = tank.Width;
            float height = tank.Height;
            float thickness = tank.GlassThickness;

            length *= ScaleFactor;
            width *= ScaleFactor;
            height *= ScaleFactor;
            thickness *= ScaleFactor;

            OpenGL.glTranslatef(0.0f, -height / 2, -width / 2);

            M3DHelper.SetMaterial(GlassDiffuse, GlassSpecular, 128.0f);

            var ld2 = length / 2.0f;
            var x1s = 0 - ld2;
            var x2s = 0 + ld2;

            var x1 = x1s;
            var x2 = x2s;

            // bottom
            var y1 = 0.0f;
            var y2 = y1 - thickness;
            var z1 = 0.0f;
            var z2 = z1 + width;
            M3DHelper.DrawBox(x1, x2, y1, y2, z1, z2);

            // front
            y1 = 0.0f + height;
            y2 = 0.0f;
            z1 = 0.0f + width;
            z2 = z1 - thickness;
            M3DHelper.DrawBox(x1, x2, y1, y2, z1, z2);

            // back
            y1 = 0.0f + height;
            y2 = 0.0f;
            z1 = 0.0f;
            z2 = z1 + thickness;
            M3DHelper.DrawBox(x1, x2, y1, y2, z1, z2);

            // sides
            y1 = 0.0f + height;
            y2 = 0.0f;
            z1 = 0.0f + thickness;
            z2 = z1 + (width - thickness * 2);

            // left side
            x1 = x1s;
            x2 = x1s + thickness;
            M3DHelper.DrawBox(x1, x2, y1, y2, z1, z2);

            // right side
            x1 = x2s;
            x2 = x2s - thickness;
            M3DHelper.DrawBox(x1, x2, y1, y2, z1, z2);

            if (showWater) {
                M3DHelper.SetMaterial(WaterDiffuse, WaterDiffuse, 32.0f);
                float watHeight = height - thickness - (ALData.StdWaterOffset * ScaleFactor);

                var x1w = x1s + thickness;
                var x2w = x2s - thickness;
                var y1w = 0;
                var y2w = 0 + watHeight;
                var z1w = 0 + thickness;
                var z2w = 0 + width - thickness;
                M3DHelper.DrawBox(x1w, x2w, y1w, y2w, z1w, z2w);

                if (aeration) {
                    var aeraPt = new Point3D(0.0f, 0.0f, width / 2.0f);
                    M3DAeration.DrawBubbles(aeraPt, watHeight);
                }
            }

            OpenGL.glPopMatrix();
        }


        public static void DrawBowfrontTank(BowFrontTank tank, bool showWater = true, bool aeration = false)
        {
            OpenGL.glPushMatrix();

            float length = tank.Length;
            float width = tank.Width;
            float fullWidth = tank.CentreWidth;
            float height = tank.Height;
            float thickness = tank.GlassThickness;

            length *= ScaleFactor;
            width *= ScaleFactor;
            fullWidth *= ScaleFactor;
            height *= ScaleFactor;
            thickness *= ScaleFactor;

            OpenGL.glTranslatef(0.0f, -height / 2, -width / 2);

            M3DHelper.SetMaterial(GlassDiffuse, GlassSpecular, 128.0f);

            var ld2 = length / 2.0f;
            var x1s = 0 - ld2;
            var x2s = 0 + ld2;

            var x1 = x1s;
            var x2 = x2s;

            // bottom
            var y1 = 0.0f - thickness;
            var y2 = 0.0f;
            var z1 = 0.0f;
            var z2 = z1 + width;
            DrawBowBox(x1, x2, y1, y2, z1, z2, fullWidth - width);

            // back
            y1 = 0.0f + height;
            y2 = 0.0f;
            z1 = 0.0f;
            z2 = z1 + thickness;
            M3DHelper.DrawBox(x1, x2, y1, y2, z1, z2);

            // sides
            y1 = 0.0f + height;
            y2 = 0.0f;
            z1 = 0.0f + thickness;
            z2 = z1 + (width - thickness);

            // left side
            x1 = x1s;
            x2 = x1s + thickness;
            M3DHelper.DrawBox(x1, x2, y1, y2, z1, z2);

            // right side
            x1 = x2s;
            x2 = x2s - thickness;
            M3DHelper.DrawBox(x1, x2, y1, y2, z1, z2);

            // front
            DrawBowfrontPlate(x1s, x2s, 0.0f, width, fullWidth, height, thickness);

            if (showWater) {
                M3DHelper.SetMaterial(WaterDiffuse, WaterDiffuse, 32.0f);
                float watHeight = height - thickness - (ALData.StdWaterOffset * ScaleFactor);

                var x1w = x1s + thickness;
                var x2w = x2s - thickness;
                var y1w = watHeight;
                var y2w = 0.0f;
                var z1w = 0.0f + thickness;
                var z2w = 0.0f + width;
                DrawBowBox(x1w, x2w, y1w, y2w, z1w, z2w, fullWidth - width - thickness);

                if (aeration) {
                    var aeraPt = new Point3D(0.0f, 0.0f, width / 2.0f);
                    M3DAeration.DrawBubbles(aeraPt, watHeight);
                }
            }

            OpenGL.glPopMatrix();
        }

        private static void DrawBowfrontPlate(float x1, float x2, float z1, float width, float fullWidth, float height, float thickness)
        {
            IList<Point3D> points1, points2;
            float centerZ1, centerZ2;

            // outer plate
            DrawBowfront(x1, x2, z1, width, fullWidth, height, out centerZ1, out points1);
            // inner plate
            DrawBowfront(x1 + thickness, x2 - thickness, z1, width - thickness, fullWidth - thickness, height, out centerZ2, out points2);

            float y1 = 0.0f;
            float y2 = y1 + height;
            DrawBowfrontFace(points1, points2, y1, centerZ1, centerZ2);
            DrawBowfrontFace(points1, points2, y2, centerZ1, centerZ2);
        }

        private static void DrawBowfrontFace(IList<Point3D> points1, IList<Point3D> points2, float y, float centerZ1, float centerZ2)
        {
            OpenGL.glPushMatrix();
            OpenGL.glBegin(OpenGL.GL_TRIANGLE_STRIP);
            for (int j = 0; j < points1.Count; ++j) {
                var pt1 = points1[j];
                var pt2 = points2[j];
                //OpenGL.glNormal3f(pt.X / radius, 0.0f, pt.Z / radius);
                OpenGL.glVertex3f(pt1.X, y, centerZ1 + pt1.Z);
                //OpenGL.glNormal3f(pt.X / radius, 0.0f, pt.Z / radius);
                OpenGL.glVertex3f(pt2.X, y, centerZ2 + pt2.Z);
            }
            OpenGL.glEnd();
            OpenGL.glPopMatrix();
        }

        // Draw an arc strip of a given height from y=0
        private static void DrawBowfront(float x1, float x2, float z1, float width, float fullWidth, float height, out float centerZ, out IList<Point3D> points)
        {
            float chordLength = x2 - x1;
            float chordWidth = fullWidth - width;

            float radius, wedgeAngle;
            ALData.CalcSegmentParams(chordWidth, chordLength, out radius, out wedgeAngle);
            wedgeAngle /= M3DHelper.DEG2RAD;

            centerZ = (z1 + fullWidth - radius);
            float startAngle = M3DHelper.GetAngle(new Point3D(0.0f, 0.0f, centerZ), new Point3D(x2, 0.0f, centerZ), new Point3D(x2, 0.0f, z1 + width));

            OpenGL.glPushMatrix();
            OpenGL.glTranslatef(0.0f, 0.0f, centerZ);
            points = M3DHelper.GetArcPoints(30, radius, startAngle, wedgeAngle);
            M3DHelper.DrawCylinder(points, height, radius);
            OpenGL.glPopMatrix();
        }

        private static void DrawBowBox(float x1, float x2, float y1, float y2, float z1, float z2, float bowWidth)
        {
            var p1 = new Point3D(x1, y1, z1);
            var p2 = new Point3D(x2, y1, z1);
            var p3 = new Point3D(x2, y1, z2);
            var p4 = new Point3D(x1, y1, z2);
            var p5 = new Point3D(x1, y2, z1);
            var p6 = new Point3D(x2, y2, z1);
            var p7 = new Point3D(x2, y2, z2);
            var p8 = new Point3D(x1, y2, z2);

            M3DHelper.DrawRect(p1, p2, p6, p5, new Point3D(0.0f, 0.0f, -1.0f)); // back
            M3DHelper.DrawRect(p2, p3, p7, p6, new Point3D(+1.0f, 0.0f, 0.0f)); // right
            M3DHelper.DrawRect(p1, p4, p8, p5, new Point3D(-1.0f, 0.0f, 0.0f)); // left

            float height = y2 - y1;
            float width = z2 - z1;

            IList<Point3D> points;
            float centerZ;

            OpenGL.glPushMatrix();
            OpenGL.glTranslatef(0.0f, -height, 0.0f);
            DrawBowfront(x1, x2, z1, width, width + bowWidth, height, out centerZ, out points);
            OpenGL.glPopMatrix();

            // top
            OpenGL.glBegin(OpenGL.GL_POLYGON);
            OpenGL.glVertex3f(p4.X, y1, p4.Z);
            OpenGL.glVertex3f(p1.X, y1, p1.Z);
            OpenGL.glVertex3f(p2.X, y1, p2.Z);
            OpenGL.glVertex3f(p3.X, y1, p3.Z);
            for (int j = 0; j < points.Count; j++) {
                var pt = points[j];
                OpenGL.glVertex3f(pt.X, y1, pt.Z + centerZ);
            }
            OpenGL.glEnd();

            // bottom
            OpenGL.glBegin(OpenGL.GL_POLYGON);
            OpenGL.glVertex3f(p8.X, y2, p8.Z);
            OpenGL.glVertex3f(p5.X, y2, p5.Z);
            OpenGL.glVertex3f(p6.X, y2, p6.Z);
            OpenGL.glVertex3f(p7.X, y2, p7.Z);
            for (int j = 0; j < points.Count; j++) {
                var pt = points[j];
                OpenGL.glVertex3f(pt.X, y2, pt.Z + centerZ);
            }
            OpenGL.glEnd();
        }
    }
}
