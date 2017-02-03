using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class MessageCommunicatorException : Exception
    {
        string _text;
        public MessageCommunicatorException(string messsage)
        {
            _text = messsage;
        }
    }
}
