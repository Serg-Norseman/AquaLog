﻿/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.Core.Types;
using BSLib.Timeline;

namespace AquaMate.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class LifeLinesPanel : DataPanel
    {
        private readonly TimelineViewer fGraph;

        public LifeLinesPanel()
        {
            fGraph = new TimelineViewer();
            fGraph.Dock = DockStyle.Fill;
            fGraph.BackColor = Color.FromArgb(64, 64, 64);
            fGraph.BackgroundColor = Color.Black;
            fGraph.Dock = DockStyle.Fill;
            fGraph.GridAlpha = 40;
            fGraph.TrackBorderSize = 2;
            fGraph.TrackHeight = 32;
            fGraph.TrackSpacing = 1;
            Controls.Add(fGraph);
        }

        internal override void UpdateContent()
        {
            fGraph.Clear();
            if (fModel == null) return;

            IList<Inhabitant> records = fModel.QueryInhabitants();
            foreach (Inhabitant rec in records) {
                SpeciesType speciesType = fModel.GetSpeciesType(rec.SpeciesId);
                ItemType itemType = ALCore.GetItemType(speciesType);

                int currAqmId = 0;
                DateTime inclusionDate, exclusionDate;
                fModel.GetInhabitantDates(rec.Id, itemType, out inclusionDate, out exclusionDate, out currAqmId);

                if (ALCore.IsZeroDate(inclusionDate)) {
                    continue;
                }

                if (ALCore.IsZeroDate(exclusionDate)) {
                    exclusionDate = DateTime.Now;
                }

                fGraph.AddEventFrame(new EventFrame(rec.Name, inclusionDate, exclusionDate));
            }
        }
    }
}
