/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaLog.Core;
using AquaLog.Core.Model.Tanks;
using CsGL.OpenGL;

namespace AquaLog.GLViewer.Tanks
{
    /// <summary>
    /// 
    /// </summary>
    public class CylinderTankRenderer : TankRenderer<CylinderTank>
    {
        public CylinderTankRenderer(CylinderTank tank) : base(tank)
        {
        }

        public override void Render(bool showWater = true, bool aeration = false)
        {
            OpenGL.glPushMatrix();

            float height = fTank.Height;
            float bottomDiameter = fTank.BottomDiameter;
            float thickness = fTank.GlassThickness;

            bottomDiameter *= ScaleFactor;
            height *= ScaleFactor;
            thickness *= ScaleFactor;

            OpenGL.glTranslatef(0.0f, -height / 2, 0.0f);

            M3DHelper.SetGlassMaterial();

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
                M3DHelper.SetWaterMaterial();
                float watHeight = height - thickness - (StdWaterOffset * ScaleFactor);

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
    }
}
