using MultiplayerFPS_Server.Game;
using MultiplayerFPS_Server.Server;
using MultiplayerFPS_Server.UserData;

using System;
using System.Collections.Generic;

using System.Net;
using System.Net.Sockets;

using System.Threading;

namespace MultiplayerFPS_Server
{
    public class ServerConnecter
    {
        public const int portNum = 8001;
        public static TcpListener _serverSocket;

        private static GameLobby _gameLobby = null;

        private static void Main(string[] args)
        {
            Console.WriteLine("[SERVER] Server starting.", Thread.CurrentThread.ManagedThreadId);

            _serverSocket = new TcpListener(IPAddress.Any, portNum);
            _serverSocket.Start();

            bool launched = true;
            
            while (launched)
            {
                Console.WriteLine("[SERVER] Waiting for a new player connection...");
                TcpClient client = _serverSocket.AcceptTcpClient();

                //Will not pass here if AcceptTcpClient isn't done.

                Console.WriteLine("[SERVER] Player connection accepted.");
                NetworkStream ns = client.GetStream();
                User newUser = new User(client, ns); 

                if(_gameLobby == null || _gameLobby.IsFull)
                {
                    InstantiateNewLobby();
                    AddPlayerToLobby(newUser);
                }
                else
                {
                    AddPlayerToLobby(newUser);
                }
            }

            Console.WriteLine("[SERVER] Server shutting down.", Thread.CurrentThread.ManagedThreadId);
        }

        private static void InstantiateNewLobby()
        {
            _gameLobby = new GameLobby();
            Thread newGameLobbyThread = new Thread(new ThreadStart(_gameLobby.Process));
            Console.WriteLine("[SERVER] Creating new game lobby.", Thread.CurrentThread.ManagedThreadId);
        }

        private static void AddPlayerToLobby(User user)
        {
            _gameLobby.AddUserToLobby(user);
            Console.WriteLine("[SERVER] Adding player to current game lobby.", Thread.CurrentThread.ManagedThreadId);
        }
    }
}

