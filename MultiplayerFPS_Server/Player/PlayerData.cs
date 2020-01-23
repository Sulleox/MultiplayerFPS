namespace MultiplayerFPS_Server.UserData
{
    public class PlayerData
    {
        private string _userName;
        private int _userLevel;

        public PlayerData(string name = "newPlayer", int level = 0)
        {
            _userName = name;
            _userLevel = level;
        }

        public void ChangeUserName(string name)
        {
            _userName = name;
        }

        public void ChangeUserLevel(int level)
        {
            _userLevel = level;
        }
    }
}
