﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Omnix.Base;

namespace Omnix.Network.Connection.Tests.Internal
{
    internal static class SocketHelpers
    {
        private static readonly object _lockObject = new object();

        public static (Socket, Socket) GetSockets()
        {
            lock (_lockObject)
            {
                for (; ; )
                {
                    try
                    {
                        var random = RandomProvider.GetThreadRandom();

                        int port = random.Next(1024, 20000);
                        Socket socket1, socket2;

                        var listener = new TcpListener(new IPEndPoint(IPAddress.Loopback, port));
                        listener.Start();
                        var acceptSocketTask = listener.AcceptSocketAsync();

                        var client = new TcpClient();
                        client.ConnectAsync(IPAddress.Loopback, port).Wait();

                        var server = acceptSocketTask.Result;
                        listener.Stop();

                        socket1 = client.Client;
                        socket2 = server;

                        listener.Stop();

                        return (socket1, socket2);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }
    }
}

