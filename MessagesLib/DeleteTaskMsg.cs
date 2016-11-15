using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    [Serializable]
    public class DeleteTaskMsg:AbstractMessage
    {
        AbstractMessage.Messagetype _type;
        int _id;
        public DeleteTaskMsg(int id)
        {
            _type = Messagetype.DELETETASK;
            _id = id;
        }
        public int getDeleteID()
        {
            return _id;
        }
        public override AbstractMessage.Messagetype getMessageType()
        {
            return _type;
        }
        public override string ToString()
        {
            StringBuilder temp = new StringBuilder();
            temp.Append("[MESSAGE]");
            temp.Append("\nType:\t\t\t" + _type.ToString());
            temp.Append("\nDeleteID:\t\t" + _id.ToString());
            return temp.ToString();
        }
    }
}
