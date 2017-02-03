using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    [Serializable]
    public class OpenConMsg:AbstractMessage
    {
        Messagetype _type;
        public OpenConMsg()
        {
            _type = Messagetype.OPENCON;
        }
        public override AbstractMessage.Messagetype getMessageType()
        {
            return _type;
        }
    }
}
