using UnityEngine;

using System;
using System.Net.Sockets;

using System.Threading;

public class NetworkManager : MonoBehaviour
{
    private const int portNum = 8001;
    private const string hostName = "88.122.180.44";

    private TcpClient _tcpClient;
    private NetworkStream _networkStream;

    private NetworkReceiver _networkReceiver;
    private Thread _networkReceiverThread;

    private void Start()
    {
        ConnectToServer();
    }

    public void ConnectToServer()
    {
        try
        {
            // Loggin to server
            _tcpClient = new TcpClient(hostName, portNum);
            _networkStream = _tcpClient.GetStream();
            User newUser = new User(_tcpClient, _networkStream);

            // Creating network receiver
            _networkReceiver = new NetworkReceiver(newUser);
            _networkReceiverThread = new Thread(new ThreadStart(_networkReceiver.Process));
            _networkReceiverThread.Start();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    private void OnApplicationQuit()
    {
        _networkReceiverThread.Abort();
        _tcpClient.Close();
    }
}
