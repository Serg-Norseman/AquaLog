/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using CsGL.OpenGL;

namespace AquaLog.GLViewer
{
    public sealed class M3DWater
    {
        private class Cell
        {
            public float x, v;
        }

        private const float dist = 2.5f;
        private const float w = 0.01f;
        private const float b = 0.01f;

        private int fSize;
        private Cell[] fCells;
        private Vector3D[] fNormals;
        private Random fRandom;

        public M3DWater(int size = 200)
        {
            fSize = size;
            int nx2 = fSize + 2;
            fCells = new Cell[nx2 * nx2];
            fNormals = new Vector3D[fSize * fSize];

            fRandom = new Random();
            for (int y = 0; y < nx2; y++) {
                for (int x = 0; x < nx2; x++) {
                    var cell = new Cell();
                    cell.x = 0.1f * (fRandom.Next(1000) / 100 - 5);
                    fCells[y * nx2 + x] = cell;
                }
            }
        }

        public void Draw()
        {
            for (int i = 1; i <= fSize; i++) {
                int ad1 = (i - 1) * fSize + (1 - 1);
                int ad2 = (i) * (fSize + 2) + 1;

                for (int j = 1; j <= fSize; j++) {
                    fNormals[ad1].Z = fCells[ad2 - fSize - 2].x - fCells[ad2 + fSize + 2].x;
                    fNormals[ad1].X = fCells[ad2 - 1].x - fCells[ad2 + 1].x;
                    fNormals[ad1].Y = 4 * dist;
                    ad1++;
                    ad2++;
                }
            }

            M3DHelper.SetMaterial(M3DHelper.WaterDiffuse, M3DHelper.WaterSpecular, M3DHelper.WaterShininess);

            for (int i = 1; i <= fSize - 1; i++) {
                OpenGL.glBegin(OpenGL.GL_TRIANGLE_STRIP);

                int ad1 = (i - 1) * fSize + (1 - 1);
                int ad2 = i * (fSize + 2) + (+1);
                float ix = dist * (i - fSize / 2);
                float jz = dist * (1 - fSize / 2);

                for (int j = 1; j <= fSize; j++) {
                    var nrm = fNormals[ad1];
                    OpenGL.glNormal3f(nrm.X, nrm.Y, nrm.Z);
                    OpenGL.glVertex3f(jz / 100, fCells[ad2].x / 100, ix / 100);

                    nrm = fNormals[ad1 + fSize];
                    OpenGL.glNormal3f(nrm.X, nrm.Y, nrm.Z);
                    OpenGL.glVertex3f(jz / 100, fCells[ad2 + fSize + 2].x / 100, (ix + dist) / 100);

                    ad1++;
                    ad2++;
                    jz = jz + dist;
                }

                OpenGL.glEnd();
            }
        }

        public void Bubbles()
        {
            if (fRandom.Next(10) == 1) {
                int ad = (fRandom.Next(fSize - 7 * 2) + 1 + 7) * (fSize + 2) + (fRandom.Next(fSize - 7 * 2) + 1 + 7);

                for (int i = -7; i <= 7; i++) {
                    for (int j = -7; j <= 7; j++) {
                        var cell = fCells[ad + i * (fSize + 2) + j];
                        cell.x = cell.x + 10 * (float)Math.Exp(-(i * i + j * j) / 5);
                    }
                }
            }
        }

        public void Next(float dt)
        {
            Bubbles();

            for (int i = 1; i <= fSize; i++) {
                int ad = i * (fSize + 2) + 1;
                float x1 = fCells[ad - 1].x;
                float x2 = fCells[ad].x;

                for (int j = 1; j <= fSize; j++) {
                    float x3 = fCells[ad + 1].x;
                    float dx = 4 * x2 - fCells[(ad + fSize) + 2].x - x3 - fCells[(ad - fSize) - 2].x - x1;
                    float v = fCells[ad].v;
                    float dv = -(dx * w + b * v) * dt;
                    fCells[ad].v = v + dv;
                    x1 = x2;
                    x2 = x3;
                    ad++;
                }
            }

            for (int i = 1; i <= fSize; i++) {
                int ad = i * (fSize + 2) + 1;
                for (int j = 1; j <= fSize; j++) {
                    var cell = fCells[ad];
                    cell.x = cell.x + cell.v * dt;
                    ad++;
                }
            }
        }
    }
}
