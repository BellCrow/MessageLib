using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Messages
{
    [Serializable]
    //base class for all messageobjects and the enum o recognize the sent message into the categorys
    public abstract class AbstractMessage
    {
        [Serializable]
        public enum Messagetype
        {
            OPENCON,
            CLOSECON,
            POSTTASK,
            DELETETASK,
            GETTASKS,
            SUCCES,
            FAIL,
            TEXT
        };

        public abstract Messagetype getMessageType();
    }
}
