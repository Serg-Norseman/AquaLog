﻿/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AquaLog.Core.Export
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class CSVExporter
    {
        public static void Generate(ListView listView, string fileName)
        {
            if (listView == null || string.IsNullOrEmpty(fileName)) return;

            using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.UTF8)) {
                StringBuilder line = new StringBuilder();
                int num = listView.Columns.Count;
                for (int i = 0; i < num; i++) {
                    ColumnHeader columnHeader = listView.Columns[i];

                    if (line.Length > 0) line.Append(";");
                    line.Append(columnHeader.Text);
                }
                sw.WriteLine(line);

                num = listView.Items.Count;
                for (int i = 0; i < num; i++) {
                    ListViewItem item = listView.Items[i];

                    line.Clear();
                    int colNum = item.SubItems.Count;
                    for (int k = 0; k < colNum; k++) {
                        string val = item.SubItems[k].Text;

                        if (line.Length > 0) line.Append(";");
                        line.Append(val);
                    }
                    sw.WriteLine(line);
                }
            }
        }
    }
}
