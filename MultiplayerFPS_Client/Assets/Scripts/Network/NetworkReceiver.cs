using UnityEngine;
using System.Text;
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
            string json = Encoding.UTF8.GetString(bytes);

            Message receivedMessage = JsonConvert.DeserializeObject<Message>(json);
            ReadMessage(receivedMessage);
        }
    }

    public void ReadMessage(Message message)
    {
        switch(message.Type)
        {
            case MessageType.textMessage:
                ReadTextMessage(message.TextMessage);
                break;
        }
    }

    public void ReadTextMessage(TextMessage textMessage)
    {
        Debug.LogFormat("[CLIENT][NetworkReceiver] Text message received : {0}", textMessage.Text);
    }
}
