/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Timers;
using System.Windows.Forms;
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
        private float[] LightAmbient = {0.5f, 0.5f, 0.5f, 0.95f};
        private float[] LightDiffuse = {1.0f, 1.0f, 1.0f, 1.0f};
        private float[] LightPosition = {0.0f, 5.0f, -5.0f, 1.0f};

        // rendering
        private float xrot;
        private float yrot;
        private float zrot;
        private float z;

        // control
        private int fHeight;
        private int fWidth;
        private bool fMouseDrag;
        private int fLastX;
        private int fLastY;
        private bool fFreeRotate;
        private System.Timers.Timer fAnimTimer;
        private bool fBusy;


        public M3DViewer()
        {
            xrot = -55.0f;
            yrot = 0;
            zrot = 25.0F;
            z = -2f;
            fFreeRotate = true;

            OpenGL.glClearColor(0.25f, 0.25f, 0.25f, 0.0f);
            OpenGL.glClearDepth(1.0f);
            OpenGL.glShadeModel(OpenGL.GL_SMOOTH); // GL_FLAT?
            OpenGL.glEnable(OpenGL.GL_DEPTH_TEST);
            OpenGL.glHint(OpenGL.GL_PERSPECTIVE_CORRECTION_HINT, OpenGL.GL_NICEST);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
            }
            base.Dispose(disposing);
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

            Size sz = Size;
            if (sz.Width != 0 && sz.Height != 0) {
                fHeight = sz.Height;
                fWidth = sz.Width;

                if (fHeight == 0) {
                    fHeight = 1;
                }

                OpenGL.glViewport(0, 0, fWidth, fHeight);
                OpenGL.glMatrixMode(OpenGL.GL_PROJECTION);
                OpenGL.glLoadIdentity();

                GLU.gluPerspective(FOV_Y, (float)fWidth / fHeight, NEAR_CLIPPING_PLANE, FAR_CLIPPING_PLANE);

                OpenGL.glMatrixMode(OpenGL.GL_MODELVIEW);
                OpenGL.glLoadIdentity();
            }
        }

        public override void glDraw()
        {
            OpenGL.glClear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            OpenGL.glLoadIdentity();

            //GL.glLightModelfv(OpenGL.GL_LIGHT_MODEL_AMBIENT, new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
            OpenGL.glEnable(OpenGL.GL_LIGHTING);
            OpenGL.glEnable(OpenGL.GL_LIGHT0);
            GL.glLightfv(OpenGL.GL_LIGHT0, OpenGL.GL_AMBIENT, new float[] { 0.5f, 0.5f, 0.5f, 1.0f });
            OpenGL.glEnable(OpenGL.GL_LIGHT1);
            GL.glLightfv(OpenGL.GL_LIGHT1, OpenGL.GL_AMBIENT, LightAmbient);
            GL.glLightfv(OpenGL.GL_LIGHT1, OpenGL.GL_DIFFUSE, LightDiffuse);
            GL.glLightfv(OpenGL.GL_LIGHT1, OpenGL.GL_POSITION, LightPosition);

            OpenGL.glEnable(OpenGL.GL_BLEND);
            OpenGL.glBlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);

            OpenGL.glTranslatef(0.0f, 0.0f, z);
            OpenGL.glRotatef(xrot, 1.0f, 0.0f, 0.0f);
            OpenGL.glRotatef(yrot, 0.0f, 1.0f, 0.0f);
            OpenGL.glRotatef(zrot, 0.0f, 0.0f, 1.0f);

            DrawRectTank(92f, 31f, 53f, 0.5f, false);
        }

        private void DrawRectTank(float length, float width, float height, float thickness, bool showWater = true)
        {
            var glass = new float[] { 0.878f, 1.0f, 1.0f, 0.5f };
            GL.glMaterialfv(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, glass);
            GL.glMaterialfv(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SPECULAR, new float[] { 0.75f, 0.75f, 0.75f, 1.0f });
            GL.glMaterialf(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SHININESS, 32.0f);
            //GL.glMaterialfv(GL.GL_FRONT_AND_BACK, GL.GL_EMISSION, new float[] { 0.7f, 0.7f, 0.7f, 0.1f });

            OpenGL.glPushMatrix();

            const float factor = 0.01f;
            length *= factor;
            width *= factor;
            height *= factor;
            thickness *= factor;

            var ld2 = length / 2.0f;
            var x1s = 0 - ld2;
            var x2s = 0 + ld2;
            
            var x1 = x1s;
            var x2 = x2s;

            OpenGL.glTranslatef(0.0f, -width / 2, 0.0f);

            // bottom
            var y1 = 0.0f;
            var y2 = y1 + width;
            var z1 = 0.0f;
            var z2 = z1 - thickness;
            DrawBox(new Point3D(x1, y1, z1), new Point3D(x2, y1, z1), new Point3D(x2, y2, z1), new Point3D(x1, y2, z1),
                    new Point3D(x1, y1, z2), new Point3D(x2, y1, z2), new Point3D(x2, y2, z2), new Point3D(x1, y2, z2));

            // back
            y1 = 0.0f;
            y2 = y1 + thickness;
            z1 = 0.0f + height;
            z2 = 0.0f;
            DrawBox(new Point3D(x1, y1, z1), new Point3D(x2, y1, z1), new Point3D(x2, y2, z1), new Point3D(x1, y2, z1),
                    new Point3D(x1, y1, z2), new Point3D(x2, y1, z2), new Point3D(x2, y2, z2), new Point3D(x1, y2, z2));

            // front
            y1 = 0.0f + width;
            y2 = y1 - thickness;
            z1 = 0.0f + height;
            z2 = 0.0f;
            DrawBox(new Point3D(x1, y1, z1), new Point3D(x2, y1, z1), new Point3D(x2, y2, z1), new Point3D(x1, y2, z1),
                    new Point3D(x1, y1, z2), new Point3D(x2, y1, z2), new Point3D(x2, y2, z2), new Point3D(x1, y2, z2));

            // sides
            y1 = 0.0f + thickness;
            y2 = y1 + (width - thickness * 2);
            z1 = 0.0f + height;
            z2 = 0.0f;

            // left side
            x1 = x1s;
            x2 = x1s + thickness;
            DrawBox(new Point3D(x1, y1, z1), new Point3D(x2, y1, z1), new Point3D(x2, y2, z1), new Point3D(x1, y2, z1),
                    new Point3D(x1, y1, z2), new Point3D(x2, y1, z2), new Point3D(x2, y2, z2), new Point3D(x1, y2, z2));

            // right side
            x1 = x2s;
            x2 = x2s - thickness;
            DrawBox(new Point3D(x1, y1, z1), new Point3D(x2, y1, z1), new Point3D(x2, y2, z1), new Point3D(x1, y2, z1),
                    new Point3D(x1, y1, z2), new Point3D(x2, y1, z2), new Point3D(x2, y2, z2), new Point3D(x1, y2, z2));

            if (showWater) {
                var water = new float[] { 0.0f, 0.3f, 1.0f, 0.5f };
                GL.glMaterialfv(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, water);
                GL.glMaterialfv(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SPECULAR, water);

                var x1w = x1s + thickness;
                var x2w = x2s - thickness;
                var y1w = 0 + thickness;
                var y2w = 0 + width - thickness;
                var z1w = 0;
                var z2w = 0 + height - thickness * 4;
                DrawBox(new Point3D(x1w, y1w, z1w), new Point3D(x2w, y1w, z1w), new Point3D(x2w, y2w, z1w), new Point3D(x1w, y2w, z1w),
                    new Point3D(x1w, y1w, z2w), new Point3D(x2w, y1w, z2w), new Point3D(x2w, y2w, z2w), new Point3D(x1w, y2w, z2w));
            }

            OpenGL.glPopMatrix();
        }

        private static void DrawBox(Point3D p1, Point3D p2, Point3D p3, Point3D p4,
                                    Point3D p5, Point3D p6, Point3D p7, Point3D p8)
        {
            DrawRect(p1, p2, p3, p4);
            DrawRect(p5, p6, p7, p8);

            DrawRect(p1, p2, p6, p5);
            DrawRect(p2, p3, p7, p6);
            DrawRect(p3, p4, p8, p7);
            DrawRect(p1, p4, p8, p5);
        }

        private static void DrawRect(Point3D p1, Point3D p2, Point3D p3, Point3D p4)
        {
            Point3D pm = GetLineMidpoint(p1, p3);

            DrawTriangle(p1, pm, p2);
            DrawTriangle(p2, pm, p3);
            DrawTriangle(p3, pm, p4);
            DrawTriangle(p4, pm, p1);
        }

        private static void DrawTriangle(Point3D point1, Point3D point2, Point3D point3)
        {
            var n = CalculateSurfaceNormal(point1, point2, point3);

            OpenGL.glBegin(OpenGL.GL_TRIANGLES);

            OpenGL.glNormal3f(n.X, n.Y, n.Z);

            OpenGL.glVertex3f(point1.X, point1.Y, point1.Z);
            OpenGL.glVertex3f(point2.X, point2.Y, point2.Z);
            OpenGL.glVertex3f(point3.X, point3.Y, point3.Z);

            OpenGL.glEnd();
        }

        private static Point3D CalculateSurfaceNormal(Point3D p1, Point3D p2, Point3D p3)
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

        private void UpdateTV(object sender, ElapsedEventArgs e)
        {
            if (!fBusy) {
                fBusy = true;

                if (!fFreeRotate) {
                    zrot -= 0.3f;
                }

                Invalidate(false);

                fBusy = false;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            switch (e.KeyCode) {
                case Keys.F5:
                    Screenshot();
                    break;

                case Keys.PageDown:
                    z -= 0.5f;
                    break;

                case Keys.PageUp:
                    z += 0.5f;
                    break;

                case Keys.R:
                    fFreeRotate = !fFreeRotate;
                    break;
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
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
                    zrot += 0.005f * dx;
                } else {
                    zrot += 0.005f * dx;
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

        private void Screenshot()
        {
            try {
                using (Image image = Context.ToImage()) {
                    image.Save(@"d:\Screenshot.jpg", ImageFormat.Jpeg);
                }
            } catch (Exception e) {
                MessageBox.Show(e.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        #region Misc

        public const float DEG2RAD = 3.14159F / 180;

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

        // beauty - random offset for "beauty", grad
        public static PointF[] GetCirclePoints(PointF center, int count, float radius)
        {
            PointF[] result = new PointF[count];

            if (count > 0) {
                // size of the circle's partition, grad
                float degSection = 360.0f / count;

                for (int i = 0; i < count; i++) {
                    float degInRad = (i * degSection) * DEG2RAD;
                    float dx = (float)Math.Cos(degInRad) * radius;
                    float dy = (float)Math.Sin(degInRad) * radius;

                    result[i] = new PointF(center.X + dx, center.Y + dy);
                }
            }

            return result;
        }

        public static double Dist(PointF pt1, PointF pt2)
        {
            float dx = pt2.X - pt1.X;
            float dy = pt2.Y - pt1.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        #endregion
    }
}
