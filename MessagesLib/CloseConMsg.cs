using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    [Serializable]
    public class CloseConMsg:AbstractMessage
    {

        Messagetype _type;
        public CloseConMsg()
        {
            _type = Messagetype.CLOSECON;
        }

        public override AbstractMessage.Messagetype getMessageType()
        {
            return _type;
        }
    }
}
