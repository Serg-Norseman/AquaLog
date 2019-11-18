/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
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
            using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.UTF8)) {
                string line = string.Empty;

                int num = listView.Columns.Count;
                for (int i = 0; i < num; i++) {
                    ColumnHeader columnHeader = listView.Columns[i];

                    if (line.Length > 0) line += ";";
                    line += columnHeader.Text;
                }
                sw.WriteLine(line);

                num = listView.Items.Count;
                for (int i = 0; i < num; i++) {
                    ListViewItem item = listView.Items[i];

                    line = string.Empty;
                    int colNum = item.SubItems.Count;
                    for (int k = 0; k < colNum; k++) {
                        string val = item.SubItems[k].Text;

                        if (line.Length > 0) line += ";";
                        line += val;
                    }
                    sw.WriteLine(line);
                }
            }
        }
    }
}
