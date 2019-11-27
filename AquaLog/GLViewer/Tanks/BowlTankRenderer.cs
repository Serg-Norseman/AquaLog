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
    public class BowlTankRenderer : TankRenderer<BowlTank>
    {
        public BowlTankRenderer(BowlTank tank) : base(tank)
        {
        }

        public override void Render(bool showWater = true, bool aeration = false)
        {
            OpenGL.glPushMatrix();

            float height = fTank.Height;
            float bottomDiameter = fTank.BottomDiameter;
            float topDiameter = fTank.TopDiameter;
            float thickness = fTank.GlassThickness;

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
    }
}
