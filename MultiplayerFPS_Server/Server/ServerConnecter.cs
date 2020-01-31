using MultiplayerFPS_Server.Server;
using MultiplayerFPS_Server.UserLobby;

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

        private static Lobby _lobby = null;
        private static List<Lobby> _lobbies = new List<Lobby>();

        private static HashSet<User> _users = new HashSet<User>();

        private static void Main(string[] args)
        {
            Console.WriteLine("[SERVER] Server starting.");

            _serverSocket = new TcpListener(IPAddress.Any, portNum);
            _serverSocket.Start();

            bool launched = true;
            
            while (launched)
            {
                Console.WriteLine("[SERVER] Waiting for a new user connection...");
                TcpClient client = _serverSocket.AcceptTcpClient();

                //Will not pass here if AcceptTcpClient isn't done.

                Console.WriteLine("[SERVER] User connection accepted.");
                NetworkStream ns = client.GetStream();
                User newUser = new User(client, ns, GenerateNextUserID());
                _users.Add(newUser);

                newUser.MessageSender.SendTextMessage("[SERVER To CLIENT] Welcome on the server ");

                //Adding user to lobby
                _lobby = GetLobbyWithFreeSlot();
                _lobby.AddUserToLobby(newUser);
                Console.WriteLine("[SERVER] Adding user to lobby.");
            }

            Console.WriteLine("[SERVER] Server shutting down.");
        }

        private static int _lastUserID = -1;
        private static int GenerateNextUserID()
        {
            _lastUserID++;
            return _lastUserID;
        }

        private static Lobby CreateNewLobby()
        {
            Lobby newLobby = new Lobby();
            Thread newLobbyThread = new Thread(new ThreadStart(newLobby.Process));
            newLobbyThread.Start();

            _lobbies.Add(newLobby);
            Console.WriteLine("[SERVER] Creating new lobby.");

            return newLobby;
        }

        private static Lobby GetLobbyWithFreeSlot()
        {
            // Return the first game lobby with free slot
            for (int i = 0; i < _lobbies.Count; i++)
            {
                if(_lobbies[i].IsFull == false)
                {
                    return _lobbies[i];
                }
            }

            // Create a new game lobby
            return CreateNewLobby();
        }
    }
}

