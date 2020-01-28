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
        }
    }
}
