/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;

namespace AquaLog.Controls
{
    public enum TankState
    {
        Normal,
        Warning,
        Alert
    }

    /// <summary>
    /// 
    /// </summary>
    public class TankSticker : UserControl
    {
        private Aquarium fAquarium;
        private ContextMenu fContextMenu;
        private bool fSelected;
        private StringFormat fStrFormat;

        public Aquarium Aquarium
        {
            get { return fAquarium; }
            set {
                if (fAquarium != value) {
                    fAquarium = value;
                    UpdateView();
                }
            }
        }

        public bool Selected
        {
            get { return fSelected; }
            set {
                if (fSelected != value) {
                    fSelected = value;
                    UpdateView();
                }
            }
        }


        public TankSticker()
        {
            Margin = new Padding(10);
            MinimumSize = new Size(200, 100);
            MaximumSize = new Size(200, 100);

            SetTankState(TankState.Normal);

            var miEdit = new MenuItem();
            miEdit.Text = "Edit";
            //miEdit.Click += miEdit_Click;

            var miDelete = new MenuItem();
            miDelete.Text = "Delete";
            //miDelete.Click += miDelete_Click;

            fContextMenu = new ContextMenu();
            fContextMenu.MenuItems.AddRange(new MenuItem[] { miEdit, miDelete});
            ContextMenu = fContextMenu;

            fStrFormat = new StringFormat();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                fStrFormat.Dispose();
            }
            base.Dispose(disposing);
        }

        public void SetTankState(TankState state)
        {
            int color;
            switch (state) {
                case TankState.Normal:
                    color = ALCore.NormalState;
                    break;
                case TankState.Warning:
                    color = ALCore.WarningState;
                    break;
                case TankState.Alert:
                    color = ALCore.AlertState;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            BackColor = ALCore.CreateColor(color);
        }

        public void UpdateView()
        {
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            ButtonBorderStyle style = (fSelected) ? ButtonBorderStyle.Inset : ButtonBorderStyle.Outset;
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Silver, style);

            if (fAquarium == null) return;

            var layoutRect = ClientRectangle;
            layoutRect.Inflate(-4, -4);

            fStrFormat.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(fAquarium.Name, Font, new SolidBrush(ForeColor), layoutRect, fStrFormat);

            string volumes = ALCore.GetDecimalStr(fAquarium.WaterVolume) + " / " + ALCore.GetDecimalStr(fAquarium.TankVolume);
            fStrFormat.Alignment = StringAlignment.Far;
            e.Graphics.DrawString(volumes, Font, new SolidBrush(ForeColor), layoutRect, fStrFormat);
        }
    }
}
