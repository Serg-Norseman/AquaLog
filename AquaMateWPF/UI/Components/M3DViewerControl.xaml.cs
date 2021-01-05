/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2021 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using AquaMate.Core.Model.Tanks;
using AquaMate.Core.Types;
using AquaMate.M3DViewer;
using AquaMate.M3DViewer.Tanks;
using Point3D = System.Windows.Media.Media3D.Point3D;
using Vector3D = System.Windows.Media.Media3D.Vector3D;

namespace AquaMate.UI.Components
{
    public partial class M3DViewerControl : Viewport3D
    {
        private bool fAeration;
        private System.Timers.Timer fAnimTimer;
        private bool fBusy;
        private bool fFreeRotate;
        private double fLastX;
        private double fLastY;
        private bool fMouseDrag;
        private AquaMate.M3DViewer.Vector3D fRotation;
        private M3DRenderer fSceneRenderer;
        private BaseTank fTank;
        private ITankRenderer fTankRenderer;
        private Transform3DGroup fTransform;
        private bool fWaterVisible;
        private float fZ;


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


        public M3DViewerControl()
        {
            InitializeComponent();
            fTransform = new Transform3DGroup();

            fSceneRenderer = new M3DRenderer(fGroup, fTransform);

            Reset();

            fSceneRenderer.InitScene();

            //M3DHelper.CreateCylinder(fGroup, new Point3D(1, 0, 0), new Vector3D(-2, 0, 0), 0.1, 20, fTransform);
            //M3DRenderer.CreateRectTank(fGroup, 92f, 31f, 53f, 0.5f, fTransform);

            MouseWheel += Grid_MouseWheel;
            MouseMove += Grid_MouseMove;
            MouseDown += Grid_MouseDown;
            MouseUp += Grid_MouseUp;
            KeyDown += Grid_KeyDown;
        }

        public void Reset()
        {
            fRotation.X = +25.0f;
            fRotation.Y = +25.0f;
            fRotation.Z = 0.0f;
            fZ = -2.0f;

            fFreeRotate = true;
            fWaterVisible = false;
            fAeration = false;

            fTankRenderer = null;
            if (fTank == null) return;

            switch (fTank.GetTankShape()) {
                case TankShape.Unknown:
                    break;

                case TankShape.Bowl:
                    fTankRenderer = new BowlTankRenderer(fSceneRenderer, (BowlTank)fTank);
                    break;

                case TankShape.Cube:
                    fTankRenderer = new CubeTankRenderer(fSceneRenderer, (CubeTank)fTank);
                    break;

                case TankShape.Rectangular:
                    fTankRenderer = new RectangularTankRenderer(fSceneRenderer, (RectangularTank)fTank);
                    break;

                case TankShape.BowFront:
                    fTankRenderer = new BowfrontTankRenderer(fSceneRenderer, (BowFrontTank)fTank);
                    break;

                case TankShape.PlateFrontCorner:
                case TankShape.BowFrontCorner:
                    break;

                case TankShape.Cylinder:
                    fTankRenderer = new CylinderTankRenderer(fSceneRenderer, (CylinderTank)fTank);
                    break;
            }

            if (fTankRenderer != null) {
                fSceneRenderer.InitRender();
                fTankRenderer.Render(fWaterVisible, fAeration);
                fSceneRenderer.DoneRender();
            }
        }

        private void UpdateTV(object sender, ElapsedEventArgs e)
        {
            if (!fBusy) {
                fBusy = true;

                if (!fFreeRotate) {
                    fRotation.Y -= 0.3f;
                }

                //Invalidate(false);

                fBusy = false;
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

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key) {
                case Key.PageDown:
                    fZ -= 0.5f;
                    break;

                case Key.PageUp:
                    fZ += 0.5f;
                    break;

                case Key.R:
                    fFreeRotate = !fFreeRotate;
                    Reset();
                    break;

                case Key.A:
                    fAeration = !fAeration;
                    Reset();
                    break;

                case Key.W:
                    fWaterVisible = !fWaterVisible;
                    Reset();
                    break;
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) {
                fMouseDrag = true;
                Point pos = Mouse.GetPosition(this);

                fLastX = pos.X - this.ActualWidth / 2;
                fLastY = this.ActualHeight / 2 - pos.Y;
            }
        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            fMouseDrag = false;
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (fMouseDrag) {
                Point pos = Mouse.GetPosition(this);
                Point actualPos = new Point(pos.X - this.ActualWidth / 2, this.ActualHeight / 2 - pos.Y);
                double dx = actualPos.X - fLastX, dy = actualPos.Y - fLastY;

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

                fLastX = actualPos.X;
                fLastY = actualPos.Y;
            }
        }

        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            fCamera.Position = new Point3D(fCamera.Position.X, fCamera.Position.Y, fCamera.Position.Z - e.Delta / 250D);
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            fCamera.Position = new Point3D(fCamera.Position.X, fCamera.Position.Y, 5);
            fTransform.Children.Clear();
        }
    }
}
