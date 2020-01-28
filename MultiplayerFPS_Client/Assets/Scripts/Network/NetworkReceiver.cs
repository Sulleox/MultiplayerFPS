using UnityEngine;
using System.Text;

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
            byte[] bytes = new byte[1024];
            int bytesRead = _user.NetworkStream.Read(bytes, 0, bytes.Length);

            Debug.Log("[CLIENT] Received from server : " + Encoding.ASCII.GetString(bytes, 0, bytesRead));
        }
    }
}
