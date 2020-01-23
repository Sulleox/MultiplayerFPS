using System;
using System.Text;
using System.Collections.Generic;

using System.Net.Sockets;

namespace MultiplayerFPS_Server
{
    public class PlayerBehaviour
    {
        private TcpClient _client;
        private NetworkStream _networkStream;
        private string _playerName = string.Empty;
        private HashSet<string> _registeredNames = new HashSet<string>();

        public PlayerBehaviour(TcpClient client, NetworkStream networkStream, HashSet<string> playerNames)
        {
            _client = client;
            _networkStream = networkStream;
            _registeredNames = playerNames;
        }

        public void PlayerThreadProc()
        {
            byte[] sendBytes = Encoding.ASCII.GetBytes("[SERVER To CLIENT] " + DateTime.Now.ToString());
            byte[] readBytes = new byte[1024];

            try
            {
                //Sending server time.
                _networkStream.Write(sendBytes, 0, sendBytes.Length);

                while (_client.Connected)
                {
                    if (_playerName.Length <= 0)
                    {
                        //Asking player name.
                        sendBytes = Encoding.ASCII.GetBytes("[SERVER To CLIENT] Insert Username : ");
                        _networkStream.Write(sendBytes, 0, sendBytes.Length);

                        //Reading player name.
                        int bytesRead = _networkStream.Read(readBytes, 0, readBytes.Length);
                        string name = Encoding.ASCII.GetString(readBytes, 0, bytesRead);

                        if (_registeredNames.Contains(name))
                        {
                            sendBytes = Encoding.ASCII.GetBytes("[SERVER To CLIENT] Rentre chez ta mère péquenaud.");
                            _networkStream.Write(sendBytes, 0, sendBytes.Length);
                            _client.Close();

                            Console.WriteLine("[SERVER] Kicked player");
                        }
                        else
                        {
                            _playerName = name;
                            Console.WriteLine("[SERVER] Player added : " + _playerName);
                            _registeredNames.Add(_playerName);
                        }
                    }
                    else
                    {
                        int bytesRead = _networkStream.Read(readBytes, 0, readBytes.Length);
                        Console.WriteLine("[CLIENT to SERVER] " + _playerName + " : " + Encoding.ASCII.GetString(readBytes, 0, bytesRead));
                    }
                }

                //_networkStream.Close();
                //_client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
