using System;
using System.Text;
using System.Net.Sockets;

using UnityEngine;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private const int portNum = 8001;
    private const string hostName = "88.122.180.44";

    private void Start()
    {
        ConnectToServer();
    }

    public void ConnectToServer()
    {
        try
        {
            var client = new TcpClient(hostName, portNum);

            NetworkStream ns = client.GetStream();

            byte[] bytes = new byte[1024];
            int bytesRead = ns.Read(bytes, 0, bytes.Length);

            Debug.Log("[CLIENT] " + Encoding.ASCII.GetString(bytes, 0, bytesRead));
            _slider.value = _slider.maxValue;

            client.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

}
