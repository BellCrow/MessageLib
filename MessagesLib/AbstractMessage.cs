using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Messages
{
    [Serializable]
    //base class for all messageobjects and the enum to recognize the sent message into the categorys
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
        public static byte[] serializeMessage(AbstractMessage mes)
        {
            byte[] ret;
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            binForm.Serialize(memStream,mes);
            ret = memStream.ToArray();
            memStream.Close();
            return ret;
        }
        public static AbstractMessage deserializeMessage(byte[] messageAsByteArray)
        {

            AbstractMessage ret;
            MemoryStream memStream = new MemoryStream(messageAsByteArray);
            BinaryFormatter binForm = new BinaryFormatter();

            ret = (AbstractMessage)binForm.Deserialize(memStream);
            return ret;
        }
    }
}
