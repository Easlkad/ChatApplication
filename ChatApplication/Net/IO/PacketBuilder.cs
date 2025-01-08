using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Net.IO
{
    public class PacketBuilder
    {
        MemoryStream _ms;
        public PacketBuilder()
        {
            _ms = new MemoryStream();
        }
        public void WriteOpCode(byte opCode)
        {
            _ms.WriteByte(opCode);
        }
        public void WriteMessage(string msg)
        {
            // Get the length of the string as bytes
            var msgLengthBytes = BitConverter.GetBytes(msg.Length);

            // Convert the string to bytes
            var msgBytes = Encoding.ASCII.GetBytes(msg);

            // Write the length of the string
            _ms.Write(msgLengthBytes, 0, msgLengthBytes.Length);

            // Write the string itself
            _ms.Write(msgBytes, 0, msgBytes.Length);

        }   
        public byte[] GetPackedBytes()
        {
            return _ms.ToArray();
        }

    }
}
