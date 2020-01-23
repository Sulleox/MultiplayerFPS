using MultiplayerFPS_Server.Server;
using MultiplayerFPS_Server.UserData;
using System;
using System.Net.Sockets;
using System.Threading;

namespace MultiplayerFPS_Server.Game
{
    public class GameLobby
    {
        private bool _isFull = false;
        public bool IsFull
        {
            get
            {
                return _isFull;
            }
        }

        private bool _allPlayersReady = false;

        public void Process()
        {
            while(_allPlayersReady == false)
            {

            }
        }

        public void AddUserToLobby(User user)
        {
            AuthenticatePlayer(user);
        }

        private bool AuthenticatePlayer(User user)
        {
            PlayerAuthenticator playerAuthenticator = new PlayerAuthenticator(user);
            Thread newPlayerAuthenticatorThread = new Thread(new ThreadStart(playerAuthenticator.Process));
            return true;
        }

        public void AddPlayerToLobby(PlayerData playerData)
        {

        }
    }
}
