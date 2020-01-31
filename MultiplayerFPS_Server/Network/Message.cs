using System;

namespace MultiplayerFPS_Server.Network
{
    [Serializable]
    public class Message
    {
        public MessageType Type { get; set; }
        public TextMessage TextMessage { get; set; }
    }
}
