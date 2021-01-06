/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2021 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using AquaMate.M3DViewer;
using AMPoint3D = AquaMate.M3DViewer.Point3D;
using WMPoint3D = System.Windows.Media.Media3D.Point3D;
using Vector3D = System.Windows.Media.Media3D.Vector3D;

namespace AquaMate.UI.Components
{
    /// <summary>
    /// 
    /// </summary>
    public class M3DRenderer : SceneRenderer
    {
        private Material fCurrentMaterial;
        private MeshGeometry3D fCurrentMesh;
        private Model3DGroup fModelGroup;
        private Transform3DGroup fTransform;

        public M3DRenderer(Model3DGroup modelGroup, Transform3DGroup transform)
        {
            fModelGroup = modelGroup;
            fTransform = transform;
        }

        public override void PushMatrix()
        {
        }

        public override void PopMatrix()
        {
        }

        public override void Translatef(float x, float y, float z)
        {
            fTransform.Children.Add(new TranslateTransform3D(x, y, z));
        }

        public override void Rotatef(float angle, float x, float y, float z)
        {
            QuaternionRotation3D r = new QuaternionRotation3D(new Quaternion(new Vector3D(x, y, z), angle));
            fTransform.Children.Add(new RotateTransform3D(r));
        }

        public override void Vertex3f(float x, float y, float z)
        {
        }

        public override void Normal3f(float nx, float ny, float nz)
        {
        }

        public override void Begin(uint mode)
        {
        }

        public override void End()
        {
        }

        public override void BeginTriangleStrip()
        {
        }

        public override void BeginPolygon()
        {
        }

        public override void BeginTriangleFan()
        {
        }

        public override void Color4f(float red, float green, float blue, float alpha)
        {
        }

        public override void DrawSolidSphere(double radius, int slices, int stacks)
        {
        }

        public override void SetMaterial(float[] diffParams, float[] specParams, float[] shin)
        {
            Color color = Color.FromRgb((byte)(diffParams[0] * 255), (byte)(diffParams[1] * 255), (byte)(diffParams[2] * 255));
            fCurrentMaterial = CreateTransparentMaterial(color, 0.5f);
        }

        public override void SetLight(uint index, float[] ambiParams, float[] diffParams, float[] specParams, float[] pos)
        {
        }

        public override void SetViewport(int width, int height, float fovY, float zNear, float zFar)
        {
        }

        public override void DrawTriangle(AMPoint3D point1, AMPoint3D point2, AMPoint3D point3, AMPoint3D normal)
        {
            WMPoint3D mpt1 = new WMPoint3D(point1.X, point1.Y, point1.Z);
            WMPoint3D mpt2 = new WMPoint3D(point2.X, point2.Y, point2.Z);
            WMPoint3D mpt3 = new WMPoint3D(point3.X, point3.Y, point3.Z);

            // Create the points.
            int index1 = fCurrentMesh.Positions.Count;
            fCurrentMesh.Positions.Add(mpt1);
            fCurrentMesh.Positions.Add(mpt2);
            fCurrentMesh.Positions.Add(mpt3);

            // Create the triangle.
            fCurrentMesh.TriangleIndices.Add(index1++);
            fCurrentMesh.TriangleIndices.Add(index1++);
            fCurrentMesh.TriangleIndices.Add(index1);
        }

        public override void InitScene()
        {
        }

        public override void InitDrawing()
        {
        }

        #region Helper functions

        public void InitMesh()
        {
            fCurrentMesh = new MeshGeometry3D();
        }

        public void DoneMesh()
        {
            CreateGeometry(fModelGroup, fCurrentMesh, fCurrentMaterial, fTransform);
        }

        public void InitRender()
        {
        }

        public void DoneRender()
        {
        }

        private static void CreateGeometry(Model3DGroup modelGroup, MeshGeometry3D mesh, Material material, Transform3DGroup transform)
        {
            var geometry = new GeometryModel3D(mesh, material);
            geometry.Transform = transform;
            geometry.BackMaterial = material;
            modelGroup.Children.Add(geometry);
        }

        // Add a cylinder
        public static void CreateCylinder(Model3DGroup modelGroup, WMPoint3D end_point, Vector3D axis,
                                          double radius, int num_sides, Transform3DGroup transform)
        {
            MeshGeometry3D mesh = new MeshGeometry3D();

            // Get two vectors perpendicular to the axis.
            Vector3D v1;
            if ((axis.Z < -0.01) || (axis.Z > 0.01))
                v1 = new Vector3D(axis.Z, axis.Z, -axis.X - axis.Y);
            else
                v1 = new Vector3D(-axis.Y - axis.Z, axis.X, axis.X);
            Vector3D v2 = Vector3D.CrossProduct(v1, axis);

            // Make the vectors have length radius.
            v1 *= (radius / v1.Length);
            v2 *= (radius / v2.Length);

            // Make the top end cap.
            // Make the end point.
            int pt0 = mesh.Positions.Count; // Index of end_point.
            mesh.Positions.Add(end_point);

            // Make the top points.
            double theta = 0;
            double dtheta = 2 * Math.PI / num_sides;
            for (int i = 0; i < num_sides; i++) {
                mesh.Positions.Add(end_point + Math.Cos(theta) * v1 + Math.Sin(theta) * v2);
                theta += dtheta;
            }

            // Make the top triangles.
            int pt1 = mesh.Positions.Count - 1; // Index of last point.
            int pt2 = pt0 + 1;                  // Index of first point in this cap.
            for (int i = 0; i < num_sides; i++) {
                mesh.TriangleIndices.Add(pt0);
                mesh.TriangleIndices.Add(pt1);
                mesh.TriangleIndices.Add(pt2);
                pt1 = pt2++;
            }

            // Make the bottom end cap.
            // Make the end point.
            pt0 = mesh.Positions.Count; // Index of end_point2.
            WMPoint3D end_point2 = end_point + axis;
            mesh.Positions.Add(end_point2);

            // Make the bottom points.
            theta = 0;
            for (int i = 0; i < num_sides; i++) {
                mesh.Positions.Add(end_point2 + Math.Cos(theta) * v1 + Math.Sin(theta) * v2);
                theta += dtheta;
            }

            // Make the bottom triangles.
            theta = 0;
            pt1 = mesh.Positions.Count - 1; // Index of last point.
            pt2 = pt0 + 1;                  // Index of first point in this cap.
            for (int i = 0; i < num_sides; i++) {
                mesh.TriangleIndices.Add(num_sides + 1);    // end_point2
                mesh.TriangleIndices.Add(pt2);
                mesh.TriangleIndices.Add(pt1);
                pt1 = pt2++;
            }

            // Make the sides.
            // Add the points to the mesh.
            int first_side_point = mesh.Positions.Count;
            theta = 0;
            for (int i = 0; i < num_sides; i++) {
                WMPoint3D p1 = end_point + Math.Cos(theta) * v1 + Math.Sin(theta) * v2;
                mesh.Positions.Add(p1);
                WMPoint3D p2 = p1 + axis;
                mesh.Positions.Add(p2);
                theta += dtheta;
            }

            // Make the side triangles.
            pt1 = mesh.Positions.Count - 2;
            pt2 = pt1 + 1;
            int pt3 = first_side_point;
            int pt4 = pt3 + 1;
            for (int i = 0; i < num_sides; i++) {
                mesh.TriangleIndices.Add(pt1);
                mesh.TriangleIndices.Add(pt2);
                mesh.TriangleIndices.Add(pt4);

                mesh.TriangleIndices.Add(pt1);
                mesh.TriangleIndices.Add(pt4);
                mesh.TriangleIndices.Add(pt3);

                pt1 = pt3;
                pt3 += 2;
                pt2 = pt4;
                pt4 += 2;
            }

            CreateGeometry(modelGroup, mesh, CreateGlass(), transform);
        }

        private static Material CreateGlass()
        {
            return CreateTransparentMaterial(Colors.LightCyan, 0.5f);
        }

        private static Material CreateWater()
        {
            return CreateTransparentMaterial(Colors.LightSkyBlue, 0.9f, false);
        }

        private static Material CreateTransparentMaterial(Color color, double opacity, bool specular = true)
        {
            MaterialGroup material = new MaterialGroup();

            var brush = new SolidColorBrush(color);
            brush.Opacity = opacity;

            var diffMaterial = new DiffuseMaterial(brush);
            //diffMaterial.AmbientColor = Color.FromScRgb(0.0f, 0.0f, 0.0f, 1.0f);
            material.Children.Add(diffMaterial);

            if (specular) {
                var specMaterial = new SpecularMaterial(Brushes.White, 100d);
                material.Children.Add(specMaterial);
            }

            //var emMaterial = new EmissiveMaterial(Brushes.Transparent);
            //material.Children.Add(emMaterial);

            return material;
        }

        #endregion
    }
}
