using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    [Serializable]
    public class TextMessage:AbstractMessage
    {
        string _textMessage;
        int i;
        Messagetype _type;
        public TextMessage(string text)
        {
            _type = Messagetype.TEXT;
            _textMessage = text;
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
