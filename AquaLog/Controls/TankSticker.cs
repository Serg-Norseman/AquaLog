/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using AquaLog.Core;

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
        private bool fSelected;

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

            e.Graphics.DrawString(fAquarium.Name, Font, new SolidBrush(ForeColor), ClientRectangle);
        }
    }
}
