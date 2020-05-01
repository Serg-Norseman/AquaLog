/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;

namespace AquaMate.M3DViewer
{
    public sealed class M3DWaterSurface
    {
        public static readonly float[] Water2Diffuse = new float[] { 0.1f, 0.4f, 1.0f, 0.5f };
        public static readonly float[] Water2Specular = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };
        public static readonly float[] Water2Shininess = new float[] { 32.0f }; // 50f


        private class Cell
        {
            public float Y, V;
        }

        private BoundingBox3D fBoundingBox;
        private float fCellStep;
        private Cell[,] fCells;
        private float fCurrentTime;
        private bool fIsInitiated;
        private float fLastTime;
        private Vector3D[,] fNormals;
        private readonly Random fRandom;
        private readonly int fSize;
        private long fStartTime;


        public bool IsInitiated
        {
            get { return fIsInitiated; }
        }


        public M3DWaterSurface(int size = 200)
        {
            fIsInitiated = false;
            fRandom = new Random();
            fSize = size;
            fStartTime = DateTime.Now.Ticks;
        }

        public void Initialize(Point3D[] surfacePolygon)
        {
            fBoundingBox = new BoundingBox3D(0);
            foreach (var pt in surfacePolygon) {
                fBoundingBox.CheckPoint(pt);
            }

            // Y ignored
            float xSize = fBoundingBox.GetSizeX();
            float zSize = fBoundingBox.GetSizeZ();

            float maxSize = (xSize > zSize) ? xSize : zSize;
            fCellStep = maxSize / fSize;

            int mtxDim = fSize + 2;
            fCells = new Cell[mtxDim, mtxDim];
            fNormals = new Vector3D[fSize, fSize];
            for (int row = 0; row < mtxDim; row++) {
                for (int col = 0; col < mtxDim; col++) {
                    var cell = new Cell();
                    cell.Y = 0.1f * (fRandom.Next(1000) / 100 - 5);
                    fCells[row, col] = cell;
                }
            }

            fIsInitiated = true;
        }

        public void Draw(SceneRenderer renderer)
        {
            // In tank's rendering, x: left>right (length), y: bottom>top (height), z: back>front (width)
            // For starters, I have to scale the range of the water surface to the range of the top of the tank.
            // Scale range of the water surface to the range of the top of the tank - before calculations of normals.
            // TODO: scale ranges water surface -> tank's top surface

            for (int row = 1; row <= fSize; row++) {
                for (int col = 1; col <= fSize; col++) {
                    Vector3D normal;
                    normal.Z = fCells[row - 1, col].Y - fCells[row + 1, col].Y;
                    normal.X = fCells[row, col - 1].Y - fCells[row, col + 1].Y;
                    normal.Y = 4;
                    fNormals[row - 1, col - 1] = normal;
                }
            }

            renderer.SetMaterial(Water2Diffuse, Water2Specular, Water2Shininess);

            for (int row = 1; row <= fSize - 1; row++) {
                renderer.BeginTriangleStrip();

                for (int col = 1; col <= fSize; col++) {
                    float xx, yy, zz;
                    xx = fBoundingBox.XMin + (col - 0) * fCellStep;

                    var nrm = fNormals[row - 1, col - 1];
                    renderer.Normal3f(nrm.X, nrm.Y, nrm.Z);

                    yy = fBoundingBox.YMin + fCells[row, col].Y / 1000;
                    zz = fBoundingBox.ZMin + (row - 1) * fCellStep;
                    renderer.Vertex3f(xx, yy, zz);

                    nrm = fNormals[row, col - 1];
                    renderer.Normal3f(nrm.X, nrm.Y, nrm.Z);

                    yy = fBoundingBox.YMin + fCells[row + 1, col].Y / 1000;
                    zz = fBoundingBox.ZMin + (row + 0) * fCellStep;
                    renderer.Vertex3f(xx, yy, zz);
                }

                renderer.End();
            }
        }

        public void Next(IList<M3DBubble> surfacedBubbles)
        {
            GenerateBubbles(surfacedBubbles);

            fLastTime = fCurrentTime;
            fCurrentTime = (DateTime.Now.Ticks - fStartTime) / 1000.0f;
            float dt = (-fLastTime + fCurrentTime) / 100.0f;

            // ???
            const float w = 0.01f;
            const float b = 0.01f;

            for (int row = 1; row <= fSize; row++) {
                float y_prv = fCells[row, 0].Y;
                float y_cur = fCells[row, 1].Y;

                for (int col = 1; col <= fSize; col++) {
                    float y_nxt = fCells[row, col + 1].Y;
                    float dy = 4 * y_cur - fCells[row + 1, col].Y - y_nxt - fCells[row - 1, col].Y - y_prv;
                    float v = fCells[row, col].V;
                    float dv = -(dy * w + b * v) * dt;
                    fCells[row, col].V = v + dv;
                    y_prv = y_cur;
                    y_cur = y_nxt;
                }
            }

            for (int row = 1; row <= fSize; row++) {
                for (int col = 1; col <= fSize; col++) {
                    var cell = fCells[row, col];
                    cell.Y = cell.Y + cell.V * dt;
                }
            }
        }

        private void ApplyBubble(int bSize)
        {
            int yy = (fRandom.Next(fSize - bSize * 2) + 1 + bSize);
            int xx = (fRandom.Next(fSize - bSize * 2) + 1 + bSize);

            for (int row = -bSize; row <= +bSize; row++) {
                for (int col = -bSize; col <= +bSize; col++) {
                    var cell = fCells[yy + row, xx + col];
                    cell.Y = cell.Y + 10 * (float)Math.Exp(-(row * row + col * col) / 5.0d);
                }
            }
        }

        private void GenerateBubbles(IList<M3DBubble> surfacedBubbles)
        {
            if (surfacedBubbles.Count == 0) {
                // debug bubbles
                if (fRandom.Next(10) == 1) {
                    ApplyBubble(7);
                }
            } else {
                // bubbles from aeration
                foreach (var bubble in surfacedBubbles) {
                    var bSize = (int)(bubble.Size * 1000.0f);
                    ApplyBubble(bSize);
                }
            }
        }
    }
}
