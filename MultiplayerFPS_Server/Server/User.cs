using MultiplayerFPS_Server.Network;
using System.Net.Sockets;

namespace MultiplayerFPS_Server.Server
{
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

        private NetworkSender _messageSender;
        public NetworkSender MessageSender
        {
            get
            {
                return _messageSender;
            }
        }

        private int _userID;
        public int UserID
        {
            get
            {
                return _userID;
            }
        }

        public User(TcpClient client, NetworkStream networkStream, int userID)
        {
            _tcpClient = client;
            _networkStream = networkStream;
            _userID = userID;
            _messageSender = new NetworkSender(this);
        }
    }
}
