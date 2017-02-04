using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    [Serializable]
    public class SuccesMsg:AbstractMessage
    {
        Messagetype _type;
        ulong _answerToMessageWithId;
        public SuccesMsg(ulong answerToID)
        {
            _answerToMessageWithId = answerToID;
        }
        public override AbstractMessage.Messagetype getMessageType()
        {
            return _type;
        }
    }
}
