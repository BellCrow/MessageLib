using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    [Serializable]
    public class PostTaskMsg:AbstractMessage
    {
        public enum repeatIntervall
        {
            NONE = 0,
            HOUR,
            DAY,
            MONTH,
            YEAR
        }
        int _updateID;
        Messagetype _type;
        DateTime _timeOfTask;
        int _repeatEveryX;
        repeatIntervall _rep;
        string _comment;
        public PostTaskMsg(DateTime timeOfTask,string comment,int repeatX = 0,repeatIntervall rep = repeatIntervall.NONE,int updateID = -1)
        {
            _updateID = updateID;
            _type = Messagetype.POSTTASK;
            _comment = comment;
            _repeatEveryX = repeatX;
            _rep = rep;
        }
        public DateTime getTimeOfTask()
        {
            return _timeOfTask;
        }
        public void getRepeatIntervall(out int repeatNumber,out repeatIntervall rep)
        {
            repeatNumber = _repeatEveryX;
            rep = _rep;
        }
        public string getComment()
        {
            return _comment;
        }
        public override string ToString()
        {
            StringBuilder temp = new StringBuilder();
            temp.Append("[MESSAGE]");
            temp.Append("\nType:\t\t\t"+_type.ToString());
            temp.Append("\nUpdate:\t\t\t" + ((_updateID != -1)?"TRUE":"FALSE"));
            temp.Append("\nTimepoint:\t\t" + _timeOfTask.ToLongDateString());
            temp.Append("\nRepeatintervall:\t" + ((_repeatEveryX == 0) ? "No repeat" : _repeatEveryX.ToString()+" "+_rep.ToString()));
            temp.Append("\nComment:\t\t" + _comment.ToString());
            return temp.ToString();
        }
        public override Messagetype getMessageType()
        {
            return _type;
        }
    }
}
