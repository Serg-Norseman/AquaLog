/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using AquaLog.Core;
using AquaLog.Logging;
using BSLib;

namespace AquaLog.DataCollection
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class TCPChannel : BaseChannel
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "TCPChannel");

        private byte[] fBuffer = new byte[65535];
        private Socket fSocket;


        public override bool IsOpen
        {
            get { return (fSocket != null) && fSocket.Connected; }
        }


        public TCPChannel()
        {
        }

        public override bool Open(string parameters)
        {
            try {
                IPEndPoint endPoint = TryParseEndPoint(parameters);
                fSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                fSocket.Connect(endPoint);
                BeginReceive();

                base.Open(parameters);
                return true;
            } catch (Exception ex) {
                fLogger.WriteError("Open(): ", ex);
                return false;
            }
        }

        public override void Close()
        {
            base.Close();

            if (IsOpen) {
                fSocket.Shutdown(SocketShutdown.Both);
                fSocket.Close();
                fSocket.Dispose();
                fSocket = null;
            }
        }

        private void BeginReceive()
        {
            fSocket.BeginReceive(fBuffer, 0, fBuffer.Length, SocketFlags.None, new AsyncCallback(OnBytesReceived), this);
        }

        private void OnBytesReceived(IAsyncResult result)
        {
            try {
                // End the data receiving that the socket has done and get the number of bytes read.
                int nBytesRec = fSocket.EndReceive(result);
                // If no bytes were received, the connection is closed (at least as far as we're concerned).
                if (nBytesRec <= 0) {
                    fSocket.Close();
                    return;
                }

                string response = Encoding.ASCII.GetString(fBuffer, 0, nBytesRec);
                ReceiveData(response);

                // Whenever you decide the connection should be closed, call 
                // sock.Close() and don't call sock.BeginReceive() again. But as long 
                // as you want to keep processing incoming data...

                fSocket.BeginReceive(fBuffer, 0, fBuffer.Length, SocketFlags.None,
                    new AsyncCallback(OnBytesReceived), this);
            } catch (Exception ex) {
                fLogger.WriteError("OnBytesReceived(): ", ex);
            }
        }

        public static IPEndPoint TryParseEndPoint(string value)
        {
            Uri uri;
            IPAddress ipAddress;
            if (!Uri.TryCreate(string.Format("tcp://{0}", value), UriKind.Absolute, out uri) ||
                !IPAddress.TryParse(uri.Host, out ipAddress) || uri.Port < 0 || uri.Port > 65535) {
                return default(IPEndPoint);
            }
            return new IPEndPoint(ipAddress, uri.Port);
        }

        public override void Send(string text)
        {
            if (IsOpen) {
                text += "\r";
                byte[] data = Encoding.ASCII.GetBytes(text);
                fSocket.Send(data);
            }
        }
    }
}
