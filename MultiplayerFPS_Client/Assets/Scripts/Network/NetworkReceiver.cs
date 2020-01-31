using UnityEngine;

using System.Text;
using System.Collections.Generic;

using Newtonsoft.Json;

public class NetworkReceiver
{
    private User _user;

    public NetworkReceiver(User user)
    {
        _user = user;
        Debug.Log("[CLIENT] Network receiver created.");
    }

    public void Process()
    {
        while(_user.Client.Connected)
        {
            byte[] bytes = new byte[64000];
            int bytesRead = _user.NetworkStream.Read(bytes, 0, bytes.Length);
            string receivedJson = Encoding.UTF8.GetString(bytes, 0, bytesRead-1);

            string[] splittedJsonMessages = receivedJson.Split('\0');
            //Debug.LogFormat("[CLIENT][NetworkReceiver] Json received count : {0}", splittedJsonMessages.Length);

            for (int i = 0; i < splittedJsonMessages.Length; i++)
            {
                //Debug.LogFormat("[CLIENT][NetworkReceiver] Json received : {0}", splittedJsonMessages[i]);
                Message receivedMessage = JsonConvert.DeserializeObject<Message>(splittedJsonMessages[i]);
                ReadMessage(receivedMessage);
            }
        }
    }

    public void ReadMessage(Message message)
    {
        switch(message.Type)
        {
            case MessageType.textMessage:
                ReadTextMessage(message.TextMessage);
                break;
            case MessageType.lobbyStatus:
                ReadLobbyStatusMessage(message.LobbyStatus);
                break;
        }
    }

    public void ReadTextMessage(TextMessage textMessage)
    {
        Debug.LogFormat("[CLIENT][NetworkReceiver] Text message received : {0}", textMessage.Text);
    }

    public void ReadLobbyStatusMessage(LobbyStatusMessage lobbyStatus)
    {
        Debug.LogFormat("[CLIENT][NetworkReceiver] Lobby isAdmin : {0}, AdminID : {1}", lobbyStatus.IsAdmin, lobbyStatus.AdminID);
    }
}
