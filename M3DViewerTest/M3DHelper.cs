using System;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace M3DViewerTest
{
    public static class M3DHelper
    {
        // Add a triangle to the indicated mesh.
        // Do not reuse points so triangles don't share normals.
        private static void AddTriangle(MeshGeometry3D mesh, Point3D point1, Point3D point2, Point3D point3)
        {
            // Create the points.
            int index1 = mesh.Positions.Count;
            mesh.Positions.Add(point1);
            mesh.Positions.Add(point2);
            mesh.Positions.Add(point3);

            // Create the triangle.
            mesh.TriangleIndices.Add(index1++);
            mesh.TriangleIndices.Add(index1++);
            mesh.TriangleIndices.Add(index1);
        }

        private static Vector3D ScaleVector(Vector3D vector, double length)
        {
            double scale = length / vector.Length;
            return new Vector3D(vector.X * scale, vector.Y * scale, vector.Z * scale);
        }

        // Make a thin rectangular prism between the two points.
        // If extend is true, extend the segment by half the
        // thickness so segments with the same end points meet nicely.
        private static void AddSegment(MeshGeometry3D mesh, Point3D point1, Point3D point2, Vector3D up, bool extend = false)
        {
            const double thickness = 0.25;

            // Get the segment's vector.
            Vector3D v = point2 - point1;

            if (extend) {
                // Increase the segment's length on both ends by thickness / 2.
                Vector3D n = ScaleVector(v, thickness / 2.0);
                point1 -= n;
                point2 += n;
            }

            // Get the scaled up vector.
            Vector3D n1 = ScaleVector(up, thickness / 2.0);

            // Get another scaled perpendicular vector.
            Vector3D n2 = Vector3D.CrossProduct(v, n1);
            n2 = ScaleVector(n2, thickness / 2.0);

            // Make a skinny box.
            // p1pm means point1 PLUS n1 MINUS n2.
            Point3D p1pp = point1 + n1 + n2;
            Point3D p1mp = point1 - n1 + n2;
            Point3D p1pm = point1 + n1 - n2;
            Point3D p1mm = point1 - n1 - n2;
            Point3D p2pp = point2 + n1 + n2;
            Point3D p2mp = point2 - n1 + n2;
            Point3D p2pm = point2 + n1 - n2;
            Point3D p2mm = point2 - n1 - n2;

            // Sides.
            AddTriangle(mesh, p1pp, p1mp, p2mp);
            AddTriangle(mesh, p1pp, p2mp, p2pp);

            AddTriangle(mesh, p1pp, p2pp, p2pm);
            AddTriangle(mesh, p1pp, p2pm, p1pm);

            AddTriangle(mesh, p1pm, p2pm, p2mm);
            AddTriangle(mesh, p1pm, p2mm, p1mm);

            AddTriangle(mesh, p1mm, p2mm, p2mp);
            AddTriangle(mesh, p1mm, p2mp, p1mp);

            // Ends.
            AddTriangle(mesh, p1pp, p1pm, p1mm);
            AddTriangle(mesh, p1pp, p1mm, p1mp);

            AddTriangle(mesh, p2pp, p2mp, p2mm);
            AddTriangle(mesh, p2pp, p2mm, p2pm);
        }

        public static void CreateRectTank(Model3DGroup modelGroup,
                                          float length, float width, float height, float thickness,
                                          Transform3DGroup transform)
        {
            MeshGeometry3D mesh = new MeshGeometry3D();

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

            // bottom
            var y1 = 0.0f;
            var y2 = y1 - thickness;
            var z1 = 0.0f;
            var z2 = z1 + width;
            AddBox(mesh, new Point3D(x1, y1, z1), new Point3D(x2, y1, z1), new Point3D(x2, y2, z1), new Point3D(x1, y2, z1),
                         new Point3D(x1, y1, z2), new Point3D(x2, y1, z2), new Point3D(x2, y2, z2), new Point3D(x1, y2, z2));

            // back
            y1 = 0.0f + height;
            y2 = 0.0f;
            z1 = 0.0f;
            z2 = z1 + thickness;
            AddBox(mesh, new Point3D(x1, y1, z1), new Point3D(x2, y1, z1), new Point3D(x2, y2, z1), new Point3D(x1, y2, z1),
                         new Point3D(x1, y1, z2), new Point3D(x2, y1, z2), new Point3D(x2, y2, z2), new Point3D(x1, y2, z2));

            // front
            y1 = 0.0f + height;
            y2 = 0.0f;
            z1 = z1 + width;
            z2 = z1 - thickness;
            AddBox(mesh, new Point3D(x1, y1, z1), new Point3D(x2, y1, z1), new Point3D(x2, y2, z1), new Point3D(x1, y2, z1),
                         new Point3D(x1, y1, z2), new Point3D(x2, y1, z2), new Point3D(x2, y2, z2), new Point3D(x1, y2, z2));

            // sides
            y1 = 0.0f + height;
            y2 = 0.0f;
            z1 = 0.0f + thickness;
            z2 = z1 + (width - thickness * 2);

            // left side
            x1 = x1s;
            x2 = x1s + thickness;
            AddBox(mesh, new Point3D(x1, y1, z1), new Point3D(x2, y1, z1), new Point3D(x2, y2, z1), new Point3D(x1, y2, z1),
                         new Point3D(x1, y1, z2), new Point3D(x2, y1, z2), new Point3D(x2, y2, z2), new Point3D(x1, y2, z2));

            // right side
            x1 = x2s;
            x2 = x2s - thickness;
            AddBox(mesh, new Point3D(x1, y1, z1), new Point3D(x2, y1, z1), new Point3D(x2, y2, z1), new Point3D(x1, y2, z1),
                         new Point3D(x1, y1, z2), new Point3D(x2, y1, z2), new Point3D(x2, y2, z2), new Point3D(x1, y2, z2));

            CreateGeometry(modelGroup, mesh, CreateGlass(), transform);

            var x1w = x1s + thickness;
            var x2w = x2s - thickness;
            var y1w = 0;
            var y2w = 0 + height - thickness * 4;
            var z1w = 0 + thickness;
            var z2w = 0 + width - thickness;
            MeshGeometry3D waterMesh = new MeshGeometry3D();
            AddBox(waterMesh, new Point3D(x1w, y1w, z1w), new Point3D(x2w, y1w, z1w), new Point3D(x2w, y2w, z1w), new Point3D(x1w, y2w, z1w),
                              new Point3D(x1w, y1w, z2w), new Point3D(x2w, y1w, z2w), new Point3D(x2w, y2w, z2w), new Point3D(x1w, y2w, z2w));
            CreateGeometry(modelGroup, waterMesh, CreateWater(), transform);
        }

        private static void CreateGeometry(Model3DGroup modelGroup, MeshGeometry3D mesh, Material material, Transform3DGroup transform)
        {
            var geometry = new GeometryModel3D(mesh, material);
            geometry.Transform = transform;
            geometry.BackMaterial = material;
            modelGroup.Children.Add(geometry);
        }

        private static void AddBox(MeshGeometry3D mesh,
                                   Point3D p1, Point3D p2, Point3D p3, Point3D p4,
                                   Point3D p5, Point3D p6, Point3D p7, Point3D p8)
        {
            AddRect(mesh, p1, p2, p3, p4);
            AddRect(mesh, p5, p6, p7, p8);

            AddRect(mesh, p1, p2, p6, p5);
            AddRect(mesh, p2, p3, p7, p6);
            AddRect(mesh, p3, p4, p8, p7);
            AddRect(mesh, p1, p4, p8, p5);
        }

        private static void AddRect(MeshGeometry3D mesh, Point3D p1, Point3D p2, Point3D p3, Point3D p4)
        {
            AddTriangle(mesh, p1, p2, p3);
            AddTriangle(mesh, p3, p4, p1);
        }

        // Add a cylinder
        public static void CreateCylinder(Model3DGroup modelGroup, Point3D end_point, Vector3D axis,
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
            Point3D end_point2 = end_point + axis;
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
                Point3D p1 = end_point + Math.Cos(theta) * v1 + Math.Sin(theta) * v2;
                mesh.Positions.Add(p1);
                Point3D p2 = p1 + axis;
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

        public static Material CreateGlass()
        {
            return CreateTransparentMaterial(Colors.LightCyan, 0.5f);
        }

        public static Material CreateWater()
        {
            return CreateTransparentMaterial(Colors.LightSkyBlue, 0.9f, false);
        }

        public static Material CreateTransparentMaterial(Color color, double opacity, bool specular = true)
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
    }
}
