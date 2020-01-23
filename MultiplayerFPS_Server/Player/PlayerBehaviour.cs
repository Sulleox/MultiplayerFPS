using System;
using System.Text;
using System.Collections.Generic;

using System.Net.Sockets;
using MultiplayerFPS_Server.UserData;

namespace MultiplayerFPS_Server
{
    public class PlayerBehaviour
    {
        private TcpClient _client;
        private NetworkStream _networkStream;

        private string _playerName = string.Empty;
        private PlayerData _playerData = new PlayerData();

        public PlayerBehaviour(TcpClient client, NetworkStream networkStream, PlayerData playerData)
        {
            _client = client;
            _networkStream = networkStream;
            _playerData = playerData;
        }

        public void PlayerThreadProc()
        {
            byte[] sendBytes = Encoding.ASCII.GetBytes("[SERVER To CLIENT] " + DateTime.Now.ToString());
            byte[] readBytes = new byte[1024];

            try
            {
                //Sending server time.
                _networkStream.Write(sendBytes, 0, sendBytes.Length);

                _networkStream.Close();
                _client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
