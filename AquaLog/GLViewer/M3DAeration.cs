/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using BSLib;
using CsGL.OpenGL;

namespace AquaLog.GLViewer
{
    public static class M3DAeration
    {
        private class Bubble
        {
            public float X;
            public float Y;
            public float Z;
            public float Size;

            public void Init()
            {
                Size = RandomHelper.GetBoundedRnd(1, 3) / 1000.0f;
                X = 0.0f;
                Y = 0.0f;
                Z = 0.0f;
            }
        }

        private const int BUBBLES_COUNT = 150;

        private static Bubble[] fBubbles;
        private static float fWaterHeight;

        public static void InitBubbles(float waterHeight)
        {
            fWaterHeight = waterHeight;

            fBubbles = new Bubble[BUBBLES_COUNT];
            for (int i = 0; i < fBubbles.Length; i++) {
                fBubbles[i] = new Bubble();
                fBubbles[i].Init();
            }
        }

        public static void UpdateBubbles()
        {
            foreach (Bubble bubble in fBubbles) {
                float vel = bubble.Size;

                float dx = (1 - RandomHelper.GetRandom(3)) / 1000.0f;
                float dz = (1 - RandomHelper.GetRandom(3)) / 1000.0f;
                float dy = vel;

                int num = RandomHelper.GetRandom(3);
                switch (num) {
                    case 0:
                        dx = 0.0f;
                        break;
                    case 1:
                        dy = 0.0f;
                        break;
                    case 2:
                        dz = 0.0f;
                        break;
                }

                bubble.X += dx;
                bubble.Y += dy;
                bubble.Z += dz;

                if (bubble.Y >= fWaterHeight) {
                    bubble.Init();
                }
            }
        }

        public static void DrawBubbles()
        {
            foreach (Bubble bubble in fBubbles) {
                OpenGL.glPushMatrix();
                OpenGL.glTranslatef(bubble.X, bubble.Y, bubble.Z);
                OpenGL.glColor4f(1.0f, 1.0f, 1.0f, 0.45f);
                GLUT.glutSolidSphere(bubble.Size, 16, 16);
                OpenGL.glPopMatrix();
            }
        }
    }
}