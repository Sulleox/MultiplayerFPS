using System;

using System.Collections.Generic;

using System.Net;
using System.Net.Sockets;

using System.Threading;

namespace MultiplayerFPS_Server
{
    public class Server
    {
        public const int portNum = 8001;
        public static TcpListener _serverSocket;

        static void Main(string[] args)
        {
            _serverSocket = new TcpListener(IPAddress.Any, portNum);
            _serverSocket.Start();

            bool launched = true;
            HashSet<string> playerNames = new HashSet<string>();

            while (launched)
            {
                Console.WriteLine("[SERVER] Waiting for a new player connection...");
                TcpClient client = _serverSocket.AcceptTcpClient();

                //Will not pass here if AcceptTcpClient isn't done.

                Console.WriteLine("[SERVER] Player connection accepted.");
                NetworkStream ns = client.GetStream();

                PlayerBehaviour newPlayerBehaviour = new PlayerBehaviour(client, ns, playerNames);

                Thread newThread = new Thread(new ThreadStart(newPlayerBehaviour.PlayerThreadProc));
                newThread.Start();

            }

            Console.WriteLine("[SERVER] Main thread ({0}) exiting...", Thread.CurrentThread.ManagedThreadId);
        }
    }
}

