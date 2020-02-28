/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

#if !NETCOREAPP30

using System;
using System.IO.Ports;

namespace AquaLog.DataCollection
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SerialChannel : BaseChannel
    {
        private SerialPort fPort;


        public override bool IsOpen
        {
            get { return (fPort != null) && fPort.IsOpen; }
        }


        public SerialChannel()
        {
        }

        public override bool Open(string parameters)
        {
            try {
                fPort = new SerialPort(parameters, 115200, Parity.None, 8, StopBits.One);

                // This option ensures the arduino restarts when we run the program
                fPort.DtrEnable = true;
                fPort.ReadTimeout = 500;
                fPort.WriteTimeout = 500;
                fPort.DataReceived += DataReceived;
                fPort.Open();

                // Opening the serial port causes the arduino to restart, so wait a second for it to do that
                //System.Threading.Thread.Sleep(1000);

                base.Open(parameters);

                return true;
            } catch {
                return false;
            }
        }

        public override void Close()
        {
            base.Close();

            fPort.DtrEnable = false;
            fPort.Close();
            fPort = null;
        }

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string response = sp.ReadLine();
            ReceiveData(response);
        }

        public override void Send(string text)
        {
            if (IsOpen) {
                fPort.Write(text);
            }
        }
    }
}

#endif
