using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class TextMessage:AbstractMessage
    {
        string _textMessage;
        int i;
        Messagetype _type;
        public TextMessage()
        {
            _type = Messagetype.TEXT;
        }
        public string getText()
        {
            return _textMessage;
        }
        public override AbstractMessage.Messagetype getMessageType()
        {
            return _type;
        }
    }
}
