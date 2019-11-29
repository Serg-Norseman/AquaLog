/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using AquaLog.Core;
using AquaLog.Core.Model;
using CsGL.OpenGL;

namespace AquaLog.GLViewer.Tanks
{
    public interface ITankRenderer
    {
        M3DWater Water { get; }
        void Render(bool showWater = true, bool aeration = false);
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class TankRenderer<T> : ITankRenderer where T : ITank
    {
        protected const float ScaleFactor = 0.01f;

        protected readonly T fTank;
        protected readonly M3DWater fWater;

        public T Tank
        {
            get { return fTank; }
        }

        public M3DWater Water
        {
            get { return fWater; }
        }

        protected TankRenderer(T tank)
        {
            fTank = tank;
            fWater = new M3DWater();
        }

        public abstract void Render(bool showWater = true, bool aeration = false);

        protected static void DrawRectangularTank(float length, float width, float height, float thickness, bool showWater = true, bool aeration = false)
        {
            OpenGL.glPushMatrix();

            length *= ScaleFactor;
            width *= ScaleFactor;
            height *= ScaleFactor;
            thickness *= ScaleFactor;

            OpenGL.glTranslatef(0.0f, -height / 2, -width / 2);

            M3DHelper.SetMaterial(M3DHelper.GlassDiffuse, M3DHelper.GlassSpecular, M3DHelper.GlassShininess);

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
                M3DHelper.SetMaterial(M3DHelper.WaterDiffuse, M3DHelper.WaterSpecular, M3DHelper.WaterShininess);
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

        protected static void DrawCylinderFace(IList<Point3D> points1, IList<Point3D> points2, float y)
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
    }
}
