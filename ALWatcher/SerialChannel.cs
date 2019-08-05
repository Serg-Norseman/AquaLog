/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.IO.Ports;
using System.Threading;
using BSLib;

namespace ALWatcher
{
    public delegate void UpdateDelegate(string text);

    /// <summary>
    /// 
    /// </summary>
    public sealed class SerialChannel : BaseObject, IChannel
    {
        private SerialPort fPort;

        public bool IsOpen
        {
            get {
                return (fPort != null) && fPort.IsOpen;
            }
        }

        public SerialChannel()
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (fPort != null) {
                    fPort.DtrEnable = false;
                    fPort.Close();
                }
            }
            base.Dispose(disposing);
        }

        public void Open(string parameters)
        {
            //string[] ports = SerialPort.GetPortNames();

            fPort = new SerialPort(parameters, 9600);
            fPort.DtrEnable = true;
            fPort.ReadTimeout = 1000;
            fPort.Handshake = Handshake.None;
            fPort.Open();

            Thread.Sleep(500);
        }

        public void Close()
        {
            fPort.Close();
        }

        public string ReadLine()
        {
            if (fPort != null) {
                fPort.DiscardInBuffer();
                return fPort.ReadLine();
            } else {
                return string.Empty;
            }
        }

        public void WriteLine(string text)
        {
            if (fPort != null) {
                fPort.Write(text);
            }
        }
    }
}
