/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using CsGL.OpenGL;

namespace M3DViewerGL
{
    public static class M3DTanks
    {
        private const float ScaleFactor = 0.01f;

        // materials
        private static float[] GlassDiffuse = new float[] { 0.878f, 1.0f, 1.0f, 0.5f };
        private static float[] GlassSpecular = new float[] { 0.95f, 0.95f, 0.95f, 1.0f };
        private static float[] WaterDiffuse = new float[] { 0.0f, 0.3f, 1.0f, 0.5f };


        public static void DrawRectTank(float length, float width, float fullWidth, float height, float thickness,
            bool showWater = true)
        {
            OpenGL.glPushMatrix();

            length *= ScaleFactor;
            width *= ScaleFactor;
            fullWidth *= ScaleFactor;
            height *= ScaleFactor;
            thickness *= ScaleFactor;
            var thick2 = thickness * 2;
            bool bowfront = (fullWidth != 0.0f);

            OpenGL.glTranslatef(0.0f, -width / 2, 0.0f);

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
            M3DHelper.DrawBox(new Point3D(x1, y1, z1), new Point3D(x2, y1, z1), new Point3D(x2, y2, z1), new Point3D(x1, y2, z1),
                new Point3D(x1, y1, z2), new Point3D(x2, y1, z2), new Point3D(x2, y2, z2), new Point3D(x1, y2, z2));

            // back
            y1 = 0.0f + height;
            y2 = 0.0f;
            z1 = 0.0f;
            z2 = z1 + thickness;
            M3DHelper.DrawBox(new Point3D(x1, y1, z1), new Point3D(x2, y1, z1), new Point3D(x2, y2, z1), new Point3D(x1, y2, z1),
                new Point3D(x1, y1, z2), new Point3D(x2, y1, z2), new Point3D(x2, y2, z2), new Point3D(x1, y2, z2));

            // sides
            float delta = (!bowfront) ? thick2 : thickness;

            y1 = 0.0f + height;
            y2 = 0.0f;
            z1 = 0.0f + thickness;
            z2 = z1 + (width - delta);

            // left side
            x1 = x1s;
            x2 = x1s + thickness;
            M3DHelper.DrawBox(new Point3D(x1, y1, z1), new Point3D(x2, y1, z1), new Point3D(x2, y2, z1), new Point3D(x1, y2, z1),
                new Point3D(x1, y1, z2), new Point3D(x2, y1, z2), new Point3D(x2, y2, z2), new Point3D(x1, y2, z2));

            // right side
            x1 = x2s;
            x2 = x2s - thickness;
            M3DHelper.DrawBox(new Point3D(x1, y1, z1), new Point3D(x2, y1, z1), new Point3D(x2, y2, z1), new Point3D(x1, y2, z1),
                new Point3D(x1, y1, z2), new Point3D(x2, y1, z2), new Point3D(x2, y2, z2), new Point3D(x1, y2, z2));

            // front
            if (!bowfront) {
                x1 = x1s;
                x2 = x2s;
                y1 = 0.0f + height;
                y2 = 0.0f;
                z1 = 0.0f + width;
                z2 = z1 - thickness;
                M3DHelper.DrawBox(new Point3D(x1, y1, z1), new Point3D(x2, y1, z1), new Point3D(x2, y2, z1), new Point3D(x1, y2, z1),
                    new Point3D(x1, y1, z2), new Point3D(x2, y1, z2), new Point3D(x2, y2, z2), new Point3D(x1, y2, z2));
            } else {
                DrawBowfront(length, width, fullWidth, height, thickness, x1s, x2s);
                DrawBowfront(length - thick2, width - thickness, fullWidth - thickness, height, thickness, x1s + thickness, x2s - thickness);
            }

            if (showWater) {
                M3DHelper.SetMaterial(WaterDiffuse, WaterDiffuse, 32.0f);

                if (!bowfront) {
                    var x1w = x1s + thickness;
                    var x2w = x2s - thickness;
                    var y1w = 0;
                    var y2w = 0 + height - thickness * 4;
                    var z1w = 0 + thickness;
                    var z2w = 0 + width - thickness;
                    M3DHelper.DrawBox(new Point3D(x1w, y1w, z1w), new Point3D(x2w, y1w, z1w), new Point3D(x2w, y2w, z1w), new Point3D(x1w, y2w, z1w),
                        new Point3D(x1w, y1w, z2w), new Point3D(x2w, y1w, z2w), new Point3D(x2w, y2w, z2w), new Point3D(x1w, y2w, z2w));
                }
            }

            OpenGL.glPopMatrix();
        }

        private static void DrawBowfront(float length, float width, float fullWidth, float height, float thickness, float x1s, float x2s)
        {
            float chordWidth, radius, wedgeAngle, centerZ, startAngle;

            chordWidth = fullWidth - width;
            radius = (chordWidth / 2) + (length * length) / (8 * chordWidth);
            wedgeAngle = (float)(2 * Math.Asin(length / (2 * radius))) / M3DHelper.DEG2RAD;
            centerZ = (0.0f + fullWidth - radius);
            startAngle = M3DHelper.GetAngle(new Point3D(0.0f, 0.0f, centerZ), new Point3D(x2s, 0.0f, centerZ), new Point3D(x2s, 0.0f, width));

            OpenGL.glTranslatef(0.0f, 0.0f, centerZ);
            M3DHelper.DrawCylinder(16, height, radius, startAngle, wedgeAngle);
            OpenGL.glTranslatef(0.0f, 0.0f, -centerZ);
        }
    }
}
