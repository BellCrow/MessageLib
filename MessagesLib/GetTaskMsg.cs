using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    [Serializable]
    public class GetTaskMsg:AbstractMessage
    {
        Messagetype _type;
        string _filterFunction;
        public GetTaskMsg(string filterFunction)
        {
            _type = Messagetype.GETTASKS;
            _filterFunction = filterFunction;
        }
        public string getFilterFunction()
        {
            return _filterFunction;
        }
        public override AbstractMessage.Messagetype getMessageType()
        {
            return _type;
        }
    }
}
