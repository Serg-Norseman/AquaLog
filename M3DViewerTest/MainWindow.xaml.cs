using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace M3DViewerTest
{
    public partial class MainWindow : Window
    {
        private bool fIsMouseDown;
        private Point fLastPos;
        private Transform3DGroup fTransform;

        public MainWindow()
        {
            InitializeComponent();

            fTransform = new Transform3DGroup();

            //M3DHelper.CreateCylinder(fGroup, new Point3D(1, 0, 0), new Vector3D(-2, 0, 0), 0.1, 20, fTransform);
            M3DHelper.CreateRectTank(fGroup, 92f, 31f, 53f, 0.5f, fTransform);
        }

        #region Event handlers

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            fCamera.Position = new Point3D(fCamera.Position.X, fCamera.Position.Y, 5);
            fTransform.Children.Clear();
        }

        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            fCamera.Position = new Point3D(fCamera.Position.X, fCamera.Position.Y, fCamera.Position.Z - e.Delta / 250D);
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (fIsMouseDown) {
                Point pos = Mouse.GetPosition(fViewport);
                Point actualPos = new Point(pos.X - fViewport.ActualWidth / 2, fViewport.ActualHeight / 2 - pos.Y);
                double dx = actualPos.X - fLastPos.X, dy = actualPos.Y - fLastPos.Y;

                double mouseAngle = 0;
                if (dx != 0 && dy != 0) {
                    mouseAngle = Math.Asin(Math.Abs(dy) / Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2)));
                    if (dx < 0 && dy > 0)
                        mouseAngle += Math.PI / 2;
                    else if (dx < 0 && dy < 0)
                        mouseAngle += Math.PI;
                    else if (dx > 0 && dy < 0)
                        mouseAngle += Math.PI * 1.5;
                } else if (dx == 0 && dy != 0)
                    mouseAngle = Math.Sign(dy) > 0 ? Math.PI / 2 : Math.PI * 1.5;
                else if (dx != 0 && dy == 0)
                    mouseAngle = Math.Sign(dx) > 0 ? 0 : Math.PI;

                double axisAngle = mouseAngle + Math.PI / 2;

                Vector3D axis = new Vector3D(Math.Cos(axisAngle) * 4, Math.Sin(axisAngle) * 4, 0);

                double rotation = 0.01 * Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));

                QuaternionRotation3D r = new QuaternionRotation3D(new Quaternion(axis, rotation * 180 / Math.PI));
                fTransform.Children.Add(new RotateTransform3D(r));

                fLastPos = actualPos;
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) {
                fIsMouseDown = true;
                Point pos = Mouse.GetPosition(fViewport);
                fLastPos = new Point(pos.X - fViewport.ActualWidth / 2, fViewport.ActualHeight / 2 - pos.Y);
            }
        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            fIsMouseDown = false;
        }

        #endregion
    }
}
