/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Windows;
using System.Windows.Controls;
using AquaMate.Core.Model;
using AquaMate.UI.Components;

namespace AquaMate.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public class AquaQualityPanel : DataPanel
    {
        private const int LayoutPadding = 4;

        private Aquarium fAquarium;
        private readonly Grid fLayoutPanel;


        public AquaQualityPanel() : base()
        {
            Padding = new Thickness(10);

            fLayoutPanel = new Grid();
            //fLayoutPanel.Padding = new Padding(LayoutPadding);
            fLayoutPanel.ColumnDefinitions.Add(new ColumnDefinition());
            fLayoutPanel.ColumnDefinitions.Add(new ColumnDefinition());
            Content = fLayoutPanel;
        }

        public override void SetExtData(object extData)
        {
            fAquarium = (Aquarium)extData;
            UpdateContent();
        }

        public override void UpdateContent()
        {
            fLayoutPanel.Children.Clear();
            if (fModel == null) return;

            if (fAquarium != null) {
                fLayoutPanel.RowDefinitions.Add(new RowDefinition());
                int col = 0, row = 0;
                var values = fModel.CollectData(fAquarium);
                foreach (var mVal in values) {
                    if (!double.IsNaN(mVal.Value) && mVal.Ranges != null) {
                        string title = mVal.Name;
                        if (!string.IsNullOrEmpty(mVal.Unit)) {
                            title += ", " + mVal.Unit;
                        }

                        var qCtl = new QualityControl();
                        qCtl.Margin = new Thickness(LayoutPadding);
                        qCtl.SetData(title, mVal.Value, mVal.Ranges);

                        Grid.SetRow(qCtl, row);
                        Grid.SetColumn(qCtl, col);
                        fLayoutPanel.Children.Add(qCtl);

                        if (col == 0) {
                            col += 1;
                        } else {
                            col = 0;
                            row += 1;
                            fLayoutPanel.RowDefinitions.Add(new RowDefinition());
                        }
                    }
                }
            }
        }
    }
}
