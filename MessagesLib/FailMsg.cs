using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    [Serializable]
    public class FailMsg:AbstractMessage
    {
        Messagetype _type;
        string _comment;
        public FailMsg(string comment)
        {
            _type = Messagetype.FAIL;
            _comment = comment;
        }
        public string getComment()
        {
            return _comment;
        }
        public override AbstractMessage.Messagetype getMessageType()
        {
            return _type;
        }
    }
}
