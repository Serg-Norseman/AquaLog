/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

//#define WATER_TEST

using System;
using System.Timers;
using System.Windows.Forms;
using AquaLog.Core.Model.Tanks;
using AquaLog.Core.Types;
using AquaLog.GLViewer.Tanks;
using CsGL.OpenGL;

namespace AquaLog.GLViewer
{
    public sealed class M3DViewer : OpenGLControl
    {
        private const byte ACCUM_DEPTH = 32;         // OpenGL's Accumulation Buffer Depth, In Bits Per Pixel.
        private const byte STENCIL_DEPTH = 32;       // OpenGL's Stencil Buffer Depth, In Bits Per Pixel.
        private const byte Z_DEPTH = 32;            // OpenGL's Z-Buffer Depth, In Bits Per Pixel.
        private const byte COLOR_DEPTH = 32;        // The Current Color Depth, In Bits Per Pixel.
        private const double NEAR_CLIPPING_PLANE = 0.0f;    // GLU's Distance From The Viewer To The Near Clipping Plane (Always Positive).
        private const double FAR_CLIPPING_PLANE = 1000.0f;  // GLU's Distance From The Viewer To The Far Clipping Plane (Always Positive).
        private const double FOV_Y = 45.0f;         // GLU's Field Of View Angle, In Degrees, In The Y Direction.

        // spot light
        private readonly float[] LightAmbient = {0.5f, 0.5f, 0.5f, 0.95f};
        private readonly float[] LightDiffuse = {1.0f, 1.0f, 1.0f, 1.0f};
        private readonly float[] LightSpecular = {1.0f, 1.0f, 1.0f, 1.0f};
        private readonly float[] LightPosition = {0.0f, 5.0f, -5.0f, 1.0f};

        //private readonly float[] LightAmbient2 = {0.5f, 0.5f, 0.5f, 0.95f};
        //private readonly float[] LightDiffuse2 = {1.0f, 0.0f, 0.0f, 1.0f};
        //private readonly float[] LightPosition2 = {2.0f, 2.0f, 0.0f, 1.0f};

        // rendering
        private float xrot;
        private float yrot;
        private float zrot;
        private float z;

        // control
        private bool fMouseDrag;
        private int fLastX;
        private int fLastY;
        private bool fFreeRotate;
        private System.Timers.Timer fAnimTimer;
        private bool fBusy;
        private bool fAeration;
        private BaseTank fTank;
        private bool fWaterVisible = true;
        private ITankRenderer fRenderer;


        public BaseTank Tank
        {
            get {
                return fTank;
            }
            set {
                fTank = value;
                Reset();
            }
        }


        public M3DViewer()
        {
            Reset();
            fFreeRotate = true;

            OpenGL.glClearColor(0.25f, 0.25f, 0.25f, 0.0f);
            OpenGL.glClearDepth(1.0f);
            OpenGL.glShadeModel(OpenGL.GL_SMOOTH); // GL_FLAT?
            OpenGL.glEnable(OpenGL.GL_DEPTH_TEST);
            OpenGL.glHint(OpenGL.GL_PERSPECTIVE_CORRECTION_HINT, OpenGL.GL_NICEST);
            OpenGL.glEnable(OpenGL.GL_COLOR_MATERIAL);
            OpenGL.glEnable(OpenGL.GL_CULL_FACE);

            OpenGL.glEnable(OpenGL.GL_POINT_SMOOTH);
            OpenGL.glHint(OpenGL.GL_POINT_SMOOTH_HINT, OpenGL.GL_NICEST);

            OpenGL.glEnable(OpenGL.GL_LINE_SMOOTH);
            OpenGL.glHint(OpenGL.GL_LINE_SMOOTH_HINT, OpenGL.GL_NICEST);

            OpenGL.glEnable(OpenGL.GL_POLYGON_SMOOTH);
            OpenGL.glHint(OpenGL.GL_POLYGON_SMOOTH_HINT, OpenGL.GL_NICEST);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
            }
            base.Dispose(disposing);
        }

        public void Reset()
        {
            xrot = +25.0f;
            yrot = +25.0f;
            zrot = 0.0f;
            z = -2.0f;

            fRenderer = null;
            if (fTank == null) return;

            switch (fTank.GetTankShape()) {
                case TankShape.Unknown:
                    break;

                case TankShape.Bowl:
                    fRenderer = new BowlTankRenderer((BowlTank)fTank);
                    break;

                case TankShape.Cube:
                    fRenderer = new CubeTankRenderer((CubeTank)fTank);
                    break;

                case TankShape.Rectangular:
                    fRenderer = new RectangularTankRenderer((RectangularTank)fTank);
                    break;

                case TankShape.BowFront:
                    fRenderer = new BowfrontTankRenderer((BowFrontTank)fTank);
                    break;

                case TankShape.PlateFrontCorner:
                case TankShape.BowFrontCorner:
                    break;

                case TankShape.Cylinder:
                    fRenderer = new CylinderTankRenderer((CylinderTank)fTank);
                    break;
            }
        }

        protected override OpenGLContext CreateContext()
        {
            ControlGLContext context = new ControlGLContext(this);
            DisplayType displayType = new DisplayType(COLOR_DEPTH, Z_DEPTH, STENCIL_DEPTH, ACCUM_DEPTH);
            context.Create(displayType, null);
            return context;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            GrabContext();

            var sz = Size;
            var height = sz.Height;
            var width = sz.Width;
            if (width > 0 && height > 0) {
                OpenGL.glViewport(0, 0, width, height);
                OpenGL.glMatrixMode(OpenGL.GL_PROJECTION);
                OpenGL.glLoadIdentity();

                GLU.gluPerspective(FOV_Y, (float)width / height, NEAR_CLIPPING_PLANE, FAR_CLIPPING_PLANE);

                OpenGL.glMatrixMode(OpenGL.GL_MODELVIEW);
                OpenGL.glLoadIdentity();
            }

            start_time = DateTime.Now.Ticks;
            time = 0;
        }

        private long start_time;
        private float last_time, time;
 
        public override void glDraw()
        {
            OpenGL.glClear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            OpenGL.glLoadIdentity();

            OpenGL.glEnable(OpenGL.GL_LIGHTING);

            M3DHelper.SetLight(0, new float[] { 0.5f, 0.5f, 0.5f, 1.0f }, null, LightSpecular, null);
            M3DHelper.SetLight(1, LightAmbient, LightDiffuse, LightSpecular, LightPosition);

            OpenGL.glEnable(OpenGL.GL_NORMALIZE);
            OpenGL.glLightModelf(OpenGL.GL_LIGHT_MODEL_TWO_SIDE, (int)GL.GL_TRUE);

            OpenGL.glEnable(OpenGL.GL_BLEND);
            OpenGL.glBlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);

            OpenGL.glTranslatef(0.0f, 0.0f, z);
            OpenGL.glRotatef(xrot, 1.0f, 0.0f, 0.0f);
            OpenGL.glRotatef(yrot, 0.0f, 1.0f, 0.0f);
            OpenGL.glRotatef(zrot, 0.0f, 0.0f, 1.0f);

            if (fRenderer != null) {
                #if !WATER_TEST
                fRenderer.Render(fWaterVisible, fAeration);
                #else
                last_time = time;
                time = (DateTime.Now.Ticks - start_time) / 1000.0f;
                float dt = (-last_time + time) / 100.0f;
                fRenderer.Water.Draw();
                fRenderer.Water.Next(dt);
                #endif
            }
        }

        #region Control functions

        private void UpdateTV(object sender, ElapsedEventArgs e)
        {
            if (!fBusy) {
                fBusy = true;

                if (!fFreeRotate) {
                    yrot -= 0.3f;
                }

                Invalidate(false);

                fBusy = false;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            switch (e.KeyCode) {
                case Keys.PageDown:
                    z -= 0.5f;
                    break;

                case Keys.PageUp:
                    z += 0.5f;
                    break;

                case Keys.R:
                    fFreeRotate = !fFreeRotate;
                    break;

                case Keys.A:
                    M3DAeration.InitBubbles();
                    fAeration = !fAeration;
                    break;

                case Keys.W:
                    fWaterVisible = !fWaterVisible;
                    Invalidate(false);
                    break;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (!Focused) Focus();

            if (e.Button == MouseButtons.Left) {
                fMouseDrag = true;
                fLastX = e.X;
                fLastY = e.Y;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.Button == MouseButtons.Left) {
                fMouseDrag = false;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (fMouseDrag) {
                int dx = e.X - fLastX;
                int dy = e.Y - fLastY;

                if (fFreeRotate) {
                    xrot += 0.005f * dy;
                    yrot += 0.005f * dx;
                } else {
                    yrot += 0.005f * dx;
                }
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (e.Delta != 0) {
                z += 0.001f * e.Delta;
            }
        }

        public void StartTimer()
        {
            if (fAnimTimer != null) return;

            fAnimTimer = new System.Timers.Timer();
            fAnimTimer.AutoReset = true;
            fAnimTimer.Interval = 20;
            fAnimTimer.Elapsed += UpdateTV;
            fAnimTimer.Start();
        }

        public void StopTimer()
        {
            if (fAnimTimer == null) return;

            fAnimTimer.Stop();
            fAnimTimer = null;
        }

        #endregion
    }
}
