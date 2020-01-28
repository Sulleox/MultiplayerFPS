namespace MultiplayerFPS_Server.UserLobby
{
    public class LobbyParameters
    {
        public int ADMIN_USER_ID;
        public int MAX_USER_NUMBER;

        public LobbyParameters()
        {
            ADMIN_USER_ID = -1;
            MAX_USER_NUMBER = 4;
        }

        public LobbyParameters(int maxUserNumber)
        {
            ADMIN_USER_ID = -1;
            MAX_USER_NUMBER = maxUserNumber;
        }

        public LobbyParameters(int maxUserNumber, int adminUserId)
        {
            ADMIN_USER_ID = adminUserId;
            MAX_USER_NUMBER = maxUserNumber;
        }
    }
}
