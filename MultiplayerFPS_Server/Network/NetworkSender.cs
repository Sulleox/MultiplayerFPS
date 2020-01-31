using MultiplayerFPS_Server.Server;

using System;
using System.Text;
using System.Text.Json;

namespace MultiplayerFPS_Server.Network
{
    public class NetworkSender
    {
        private User _user;

        public NetworkSender(User user)
        {
            _user = user;
        }

        public void SendMessage(string text)
        {
            Message message = new Message();
            message.Type = MessageType.textMessage;
            message.TextMessage = new TextMessage();
            message.TextMessage.Text = text;

            SendMessage(message);
        }

        public void SendMessage(Message message)
        {
            string messageAsJson = JsonSerializer.Serialize<Message>(message);
            byte[] JsonAsBytes = Encoding.UTF8.GetBytes(messageAsJson);

            _user.NetworkStream.Write(JsonAsBytes, 0, JsonAsBytes.Length);
            Console.WriteLine("[SERVER] Sending message to client : " + messageAsJson);
        }
    }
}
