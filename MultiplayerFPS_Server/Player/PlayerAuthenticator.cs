using MultiplayerFPS_Server.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerFPS_Server.Game
{
    class PlayerAuthenticator
    {
        private User _user;

        public PlayerAuthenticator(User user)
        {
            _user = user;
        }

        public void Process()
        {
            /*
             
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

            int bytesRead = _networkStream.Read(readBytes, 0, readBytes.Length);
            Console.WriteLine("[CLIENT to SERVER] " + _playerName + " : " + Encoding.ASCII.GetString(readBytes, 0, bytesRead));

            */
        }
    }
}
