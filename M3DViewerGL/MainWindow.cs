/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AquaLog.GLViewer;

[assembly: AssemblyTitle("M3DViewerGL")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyProduct("AquaLog")]
[assembly: AssemblyCopyright("Copyright © 2019 by Sergey V. Zhdanovskih")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

namespace M3DViewerGL
{
    public sealed class MainWindow : Form
    {
        private readonly M3DViewer fViewer;

        public MainWindow()
        {
            SuspendLayout();

            var infoPanel = new StatusBarPanel();
            infoPanel.AutoSize = StatusBarPanelAutoSize.Contents;
            infoPanel.Text = "Free-rotate (R)";

            var statusBar = new StatusBar();
            statusBar.Panels.AddRange(new StatusBarPanel[] { infoPanel });
            statusBar.ShowPanels = true;

            fViewer = new M3DViewer();
            fViewer.Dock = DockStyle.Fill;
            fViewer.Debug = true;

            Controls.AddRange(new Control[] { fViewer, statusBar });
            Size = new Size(800, 600);
            StartPosition = FormStartPosition.CenterScreen;
            Load += Form_Load;
            Closing += Form_Closed;

            ResumeLayout();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            fViewer.StartTimer();
        }

        private void Form_Closed(object sender, CancelEventArgs e)
        {
            fViewer.StopTimer();
        }

        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
