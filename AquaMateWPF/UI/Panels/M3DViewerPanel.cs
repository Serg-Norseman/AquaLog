/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2021 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using AquaMate.Core.Model.Tanks;
using AquaMate.UI.Components;

namespace AquaMate.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class M3DViewerPanel : DataPanel
    {
        private readonly Label fFooter;
        private readonly M3DViewerControl fViewer;

        public M3DViewerPanel()
        {
            fViewer = new M3DViewerControl();
            fViewer.SetGridCell(0, 0);

            fFooter = new Label();
            fFooter.BorderThickness = new Thickness(1);
            fFooter.BorderBrush = new SolidColorBrush(Colors.Black);
            fFooter.Margin = new Thickness(0, 10, 0, 0);
            fFooter.SetGridCell(0, 1);
            fFooter.Content = "Free-rotate (R); Water visible (W); Aeration (A)";

            Content = null;
            var stackPanel = new Grid() {
                ColumnDefinitions = {
                    new ColumnDefinition()
                },
                RowDefinitions = {
                    new RowDefinition(),
                    new RowDefinition() { Height = GridLength.Auto }
                },
                Children = {
                    fViewer,
                    fFooter
                }
            };
            Content = stackPanel;

            IsVisibleChanged += Panel_VisibleChanged;
        }

        public override void SetExtData(object extData)
        {
            fViewer.Tank = (BaseTank)extData;
        }

        private void Panel_VisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsVisible) {
                fViewer.StartTimer();
            } else {
                fViewer.StopTimer();
            }
        }
    }
}
