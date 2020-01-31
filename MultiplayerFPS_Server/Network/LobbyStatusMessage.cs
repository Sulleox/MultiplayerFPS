using System;

namespace MultiplayerFPS_Server.Network
{
    [Serializable]
    public class LobbyStatusMessage
    {
        public int AdminID { get; set; }
        public bool IsAdmin { get; set; }
    }
}
