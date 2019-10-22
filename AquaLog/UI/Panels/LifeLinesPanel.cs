/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.Core.Types;
using BSLib.Timeline;

namespace AquaLog.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public class LifeLinesPanel : DataPanel
    {
        private readonly TimelineViewer fGraph;

        public LifeLinesPanel()
        {
            fGraph = new TimelineViewer();
            fGraph.Dock = DockStyle.Fill;
            fGraph.BackColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            fGraph.BackgroundColor = Color.Black;
            fGraph.Dock = DockStyle.Fill;
            fGraph.GridAlpha = 40;
            fGraph.TrackBorderSize = 2;
            fGraph.TrackHeight = 32;
            fGraph.TrackSpacing = 1;
            Controls.Add(fGraph);
        }

        public override void UpdateContent()
        {
            fGraph.Clear();
            if (fModel == null) return;

            IEnumerable<Inhabitant> records = fModel.QueryInhabitants();
            foreach (Inhabitant rec in records) {
                Species spc = fModel.GetRecord<Species>(rec.SpeciesId);
                SpeciesType speciesType = fModel.GetSpeciesType(rec.SpeciesId);
                ItemType itemType = ALCore.GetItemType(speciesType);

                int currAqmId = 0;
                DateTime inclusionDate, exclusionDate;
                fModel.GetInhabitantDates(rec.Id, (int)itemType, out inclusionDate, out exclusionDate, out currAqmId);
                if (exclusionDate.Equals(ALCore.ZeroDate)) {
                    exclusionDate = DateTime.Now;
                }

                fGraph.AddEventFrame(new EventFrame(rec.Name, inclusionDate, exclusionDate));
            }
        }
    }
}
