using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Net.IO
{
    public class PacketReader : BinaryReader
    {
        private NetworkStream _stream;
        public PacketReader(NetworkStream stream) : base(stream)
        {
            _stream = stream;
        }
        public string ReadMessage()
        {
            byte[] messageBuffer;
            var length = ReadInt32();
            messageBuffer = new byte[length];
            _stream.Read(messageBuffer, 0, length);

            var message = Encoding.ASCII.GetString(messageBuffer);
            return message;

        }
    }
}
