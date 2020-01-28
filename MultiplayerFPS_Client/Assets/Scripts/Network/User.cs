using System.Net.Sockets;

public class User
{
    private TcpClient _tcpClient;
    public TcpClient Client
    {
        get
        {
            return _tcpClient;
        }
    }

    private NetworkStream _networkStream;
    public NetworkStream NetworkStream
    {
        get
        {
            return _networkStream;
        }
    }

    public User(TcpClient client, NetworkStream networkStream)
    {
        _tcpClient = client;
        _networkStream = networkStream;
    }
}
