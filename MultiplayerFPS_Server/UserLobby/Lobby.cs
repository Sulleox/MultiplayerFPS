using MultiplayerFPS_Server.Server;
using System;

namespace MultiplayerFPS_Server.UserLobby
{
    public class Lobby
    {
        private LobbyParameters _lobbyParameters;

        // Constructor
        // Using default lobby parameters
        public Lobby()
        {
            _lobbyParameters = new LobbyParameters();
            _userAdminID = _lobbyParameters.ADMIN_USER_ID;
            _maxUserNumber = _lobbyParameters.MAX_USER_NUMBER;
        }

        // Using user defined lobby parameters
        public Lobby(LobbyParameters lobbyParameters)
        {
            _lobbyParameters = lobbyParameters;
            _userAdminID = lobbyParameters.ADMIN_USER_ID;
            _maxUserNumber = lobbyParameters.MAX_USER_NUMBER;
        }

        // User Number
        private int _maxUserNumber;
        private int _currentUserNumber = 0;

        public bool IsFull
        {
            get
            {
                return (_maxUserNumber - _currentUserNumber) > 0;
            }
        }

        // Lobby administration
        private int _userAdminID = -1;
        private bool _userAdminLaunchedTheGame = false;

        public void Process()
        {
            // Wait for player-admin launch
            while(_userAdminLaunchedTheGame == false)
            {

            }
        }

        public void AddUserToLobby(User user)
        {
            if(_userAdminID == -1)
            {
                _userAdminID = user.UserID;
            }
        }
    }
}
