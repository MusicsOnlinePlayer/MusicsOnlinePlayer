﻿using Musics___Server.Authentification;
using System;
using System.Net;
using System.Net.Sockets;
using Utility.Network;
using Utility.Network.Users;

namespace Musics___Server.Network
{
    class Server
    {
        public static readonly Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public const int BUFFER_SIZE = 100000000;
        public static readonly int PORT = 2003;
        public static byte[] buffer = new byte[BUFFER_SIZE];

        public ClientList Clients = new ClientList();
        public AuthentificationService AuthService = new AuthentificationService();

        public void Setup()
        {
            try
            {
                serverSocket.Bind(new IPEndPoint(IPAddress.Any, PORT));
                Console.WriteLine("Setup server Ok");
            }
            catch
            {
                Console.WriteLine("Erreur Setup");
            }
            serverSocket.SendBufferSize = BUFFER_SIZE;
            serverSocket.Listen(0);
            serverSocket.BeginAccept(AcceptCallback, null);
        }

        private void AcceptCallback(IAsyncResult ar)
        {
            Socket socket;

            try
            {
                socket = serverSocket.EndAccept(ar);
                socket.SendTimeout = 600000;
                socket.ReceiveTimeout = 600000;
            }
            catch (ObjectDisposedException)
            {
                return;
            }

            socket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.Partial, ReceiveCallback, socket);
            Clients.AddUser(new User(), socket);
            Console.WriteLine("Client connected with ip : " + socket.RemoteEndPoint.ToString());
            serverSocket.BeginAccept(AcceptCallback, null);
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            Socket current = (Socket)ar.AsyncState;
            int received = 0;

            try
            {
                received = current.EndReceive(ar);
            }
            catch
            {
                Console.WriteLine("Client disconnected =(");
                Clients.List.Remove(current);
            }

            byte[] recBuf = new byte[received];
            Array.Copy(buffer, recBuf, received);

            Program.TreatRequest(recBuf, current);
            recBuf = new byte[BUFFER_SIZE];

            try
            {
                current.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.Partial, ReceiveCallback, current);
            }
            catch
            {
                Console.WriteLine("Client disconnected =(");
                Clients.List.Remove(current);
            }
        }

        public void SendObject(object obj, Socket socket)
        {
            var msg = Function.Serialize(obj);

            try
            {
                socket.Send(msg.Data, 0, msg.Data.Length, SocketFlags.Partial);
            }
            catch
            {
            }
        }

        public void SendData(byte[] data, Socket socket)
        {
            try
            {
                socket.Send(data, 0, data.Length, SocketFlags.Partial);
            }
            catch
            {
            }
        }
    } 
}
