using ChatApplication.Net.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Net
{
    public class Server
    {
        TcpClient _client;
        public PacketReader packetReader;
        public event Action connectedEvent;
        public event Action messageReceivedEvent;
        public event Action userDisconnectedEvent;
        public Server()
        {
            _client = new TcpClient();
        }
        public void ConnectToServer(string username)
        {
                if(!_client.Connected)
              {
                _client.Connect("127.0.0.1", 1234);
                packetReader = new PacketReader(_client.GetStream());
                if(!string.IsNullOrEmpty(username))
                {
                    var connectPacket = new PacketBuilder();
                    connectPacket.WriteOpCode(0);
                    connectPacket.WriteMessage(username);
                    _client.Client.Send(connectPacket.GetPackedBytes());
                }
                ReadPackets();

            }
        }
        private void ReadPackets()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    var opCode = packetReader.ReadByte();
                    switch (opCode)
                    {
                        case 1:
                            connectedEvent?.Invoke();
                            break;

                        case 5:
                            messageReceivedEvent?.Invoke();
                            break;
                        case 10:
                            userDisconnectedEvent?.Invoke();
                            break;

                        default: 
                            Console.WriteLine("Unknown OpCode: " + opCode);
                            break;
                    }
                }
            }); 
        }
        public void SendMessageToServer(string message)
        {
            var messagePacket = new PacketBuilder();
            messagePacket.WriteOpCode(5);
            messagePacket.WriteMessage(message);
            _client.Client.Send(messagePacket.GetPackedBytes());
        }

    }
    }

