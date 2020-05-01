/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaMate.M3DViewer;
using CsGL.OpenGL;

namespace AquaMate.UI.Components
{
    /// <summary>
    /// 
    /// </summary>
    public class OGLRenderer : SceneRenderer
    {
        public OGLRenderer()
        {
        }

        public override void PushMatrix()
        {
            OpenGL.glPushMatrix();
        }

        public override void PopMatrix()
        {
            OpenGL.glPopMatrix();
        }

        public override void Translatef(float x, float y, float z)
        {
            OpenGL.glTranslatef(x, y, z);
        }

        public override void Rotatef(float angle, float x, float y, float z)
        {
            OpenGL.glRotatef(angle, x, y, z);
        }

        public override void Vertex3f(float x, float y, float z)
        {
            OpenGL.glVertex3f(x, y, z);
        }

        public override void Normal3f(float nx, float ny, float nz)
        {
            OpenGL.glNormal3f(nx, ny, nz);
        }

        public override void Begin(uint mode)
        {
            OpenGL.glBegin(mode);
        }

        public override void End()
        {
            OpenGL.glEnd();
        }

        public override void BeginTriangleStrip()
        {
            OpenGL.glBegin(OpenGL.GL_TRIANGLE_STRIP);
        }

        public override void BeginPolygon()
        {
            OpenGL.glBegin(OpenGL.GL_POLYGON);
        }

        public override void BeginTriangleFan()
        {
            OpenGL.glBegin(OpenGL.GL_TRIANGLE_FAN);
        }

        public override void Color4f(float red, float green, float blue, float alpha)
        {
            OpenGL.glColor4f(red, green, blue, alpha);
        }

        public override void DrawSolidSphere(double radius, int slices, int stacks)
        {
            GLUT.glutSolidSphere(radius, slices, stacks);
        }

        public override void SetMaterial(float[] diffParams, float[] specParams, float[] shin)
        {
            if (diffParams != null) {
                GL.glMaterialfv(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, diffParams);
            }
            if (specParams != null) {
                GL.glMaterialfv(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SPECULAR, specParams);
            }
            if (shin != null) {
                GL.glMaterialfv(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SHININESS, shin);
            }
            //GL.glMaterialfv(GL.GL_FRONT_AND_BACK, GL.GL_EMISSION, new float[] { 0.7f, 0.7f, 0.7f, 0.1f });
        }

        public override void SetLight(uint index, float[] ambiParams, float[] diffParams, float[] specParams, float[] pos)
        {
            uint light = OpenGL.GL_LIGHT0 + index;
            OpenGL.glEnable(light);

            if (ambiParams != null) {
                GL.glLightfv(light, OpenGL.GL_AMBIENT, ambiParams);
            }

            if (diffParams != null) {
                GL.glLightfv(light, OpenGL.GL_DIFFUSE, diffParams);
            }

            if (specParams != null) {
                GL.glLightfv(light, OpenGL.GL_SPECULAR, specParams);
            }

            if (pos != null) {
                GL.glLightfv(light, OpenGL.GL_POSITION, pos);
            }
        }

        public override void SetViewport(int width, int height, float fovY, float zNear, float zFar)
        {
            if (width > 0 && height > 0) {
                OpenGL.glViewport(0, 0, width, height);
                OpenGL.glMatrixMode(OpenGL.GL_PROJECTION);
                OpenGL.glLoadIdentity();

                GLU.gluPerspective(fovY, (float)width / height, zNear, zFar);

                OpenGL.glMatrixMode(OpenGL.GL_MODELVIEW);
                OpenGL.glLoadIdentity();
            }
        }

        public override void DrawTriangle(Point3D point1, Point3D point2, Point3D point3, Point3D normal)
        {
            if (normal.IsZero()) {
                normal = CalculateSurfaceNormal(point1, point2, point3);
            }

            OpenGL.glBegin(OpenGL.GL_TRIANGLES);

            OpenGL.glNormal3f(normal.X, normal.Y, normal.Z);
            OpenGL.glVertex3f(point1.X, point1.Y, point1.Z);

            OpenGL.glNormal3f(normal.X, normal.Y, normal.Z);
            OpenGL.glVertex3f(point2.X, point2.Y, point2.Z);

            OpenGL.glNormal3f(normal.X, normal.Y, normal.Z);
            OpenGL.glVertex3f(point3.X, point3.Y, point3.Z);

            OpenGL.glEnd();
        }

        public override void InitScene()
        {
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

        public override void InitDrawing()
        {
            OpenGL.glClearColor(0.25f, 0.25f, 0.25f, 0.0f);
            OpenGL.glClear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            OpenGL.glLoadIdentity();

            OpenGL.glEnable(OpenGL.GL_LIGHTING);
            OpenGL.glEnable(OpenGL.GL_NORMALIZE);
            OpenGL.glLightModelf(OpenGL.GL_LIGHT_MODEL_TWO_SIDE, (int)GL.GL_TRUE);
            OpenGL.glEnable(OpenGL.GL_BLEND);
            OpenGL.glBlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);
        }
    }
}
