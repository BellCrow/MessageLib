using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class MessageCommunicator
    {
        TcpClient _connection;
        NetworkStream _stream;

        //serialize objects
        BinaryFormatter _formatter;
        MemoryStream _memStream;
        //endSerialize
        byte[] _outbuffer;
        byte[] _inbuffer;
        public MessageCommunicator(TcpClient conArg)
        {
            _connection = conArg;
            if(!_connection.Connected)
                throw new Exception("No connection established");
            
            _stream = conArg.GetStream();
            _formatter = new BinaryFormatter();
        }
        public void sendMessage(AbstractMessage mes)
        {
            if (!_connection.Connected)
                return;
            _memStream = new MemoryStream();
            _formatter.Serialize(_memStream, mes);
            _outbuffer = _memStream.ToArray();
            _stream.Write(_outbuffer, 0, _outbuffer.Length);

        }
        public AbstractMessage getMessage()
        {
            if (!_connection.Connected)
                return null;
            _inbuffer = new byte[_connection.ReceiveBufferSize];
            _stream.Read(_inbuffer,0,_connection.ReceiveBufferSize);
            _memStream = new MemoryStream(_inbuffer);
            return (AbstractMessage)(_formatter.Deserialize(_memStream));
        }
    }
}
