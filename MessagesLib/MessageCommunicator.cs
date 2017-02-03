using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;

namespace Messages
{
    public class MessageCommunicator
    {
        #region Objects for handling messages
        Queue<AbstractMessage> _messageQueue;
        #endregion
        bool _isServer;
        bool _working;
        TcpClient _connection;
        int _port;
        NetworkStream _readWriteStream;
        Thread _receiverThread;

        //Events
        public delegate void ReceivedNewMessageEventHandler();
        public event ReceivedNewMessageEventHandler ReceivedMessageEvent;
        
        //listener Object and IP only for server
        TcpListener _listener;
        string _ip;
        #region Constructors
        //constructor for the server part
        public MessageCommunicator(int port)
        {

            _port = port;
            _listener = new TcpListener(_port);
            _isServer = true;
            initObjects();
        }
        //constructor for client
        public MessageCommunicator(string ip,int port)
        {
            _port = port;
            _ip = ip;
            _isServer = false;
            initObjects();
        }

        private void initObjects()
        {
            _messageQueue = new Queue<AbstractMessage>();
            _working = false;
            _receiverThread = new Thread(receiveInLoop);
        }
        #endregion

        #region connect client and server methods
        public void connectToServer()
        {
            if (_isServer)
                throw new MessageCommunicatorException("Tried to connect to server from server");
            //create new tcpclient and automatically connect to the server
            _connection = new TcpClient(_ip, _port);
            if(!_connection.Connected)
                throw new MessageCommunicatorException("Could not connect to Remotehost");
            _readWriteStream = _connection.GetStream();
        }
        public void listenForClient()
        {
            if (!_isServer)
                throw new MessageCommunicatorException("Tried to listen on a client");
            _listener.Start();
            _connection = _listener.AcceptTcpClient();
            _readWriteStream = _connection.GetStream();
        }
        #endregion

        #region communication with messages
        public void sendMessage(AbstractMessage sMessage)
        {
            if (!_connection.Connected)
                throw new MessageCommunicatorException("Not connected");
            byte[] writeBuffer = AbstractMessage.serializeMessage(sMessage);
            _readWriteStream.Write(writeBuffer, 0, writeBuffer.Length);
        }
        public AbstractMessage getMessage()
        {
            if (_messageQueue.Count <= 0)
                return null;
            return _messageQueue.Dequeue();
        }
        private Boolean receiveMessage()
        {
            Boolean ret = false;
            if (!_connection.Connected)
                throw new MessageCommunicatorException("Not connected");
            AbstractMessage buf = null;
            
            byte[] readBuffer = new byte[0];
            if(_readWriteStream.DataAvailable)
            {
                 readBuffer = new byte[_connection.ReceiveBufferSize];
               _readWriteStream.Read(readBuffer, 0, _connection.ReceiveBufferSize);
               buf = AbstractMessage.deserializeMessage(readBuffer);
               ret = true;
            }
            if (buf != null) 
                _messageQueue.Enqueue( AbstractMessage.deserializeMessage(readBuffer));
            return ret;
        }
        #endregion

        #region loopThreading receiver
        public void startReceivingMessages()
        {
            if (!_connection.Connected)
                throw new MessageCommunicatorException("Not connected");
            _working = true;
            _receiverThread.Start();
        }
        public void stopReceivingMessages()
        {
            _working = false;
        }
        private void receiveInLoop()
        {
            if (!_connection.Connected)
                throw new MessageCommunicatorException("Not connected");
            while(_working)
            {
                if (receiveMessage() && ReceivedMessageEvent != null)
                    ReceivedMessageEvent();
            }
        }
        public bool isWorking()
        {
            return _working;
        }
        #endregion
    }
    
}
