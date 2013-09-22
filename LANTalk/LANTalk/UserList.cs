using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace LANTalk
{
    public class SendContent
    {
        public Guid Id;
        public string Mode;
        public string From;
        public string To;
        public string Message;
        public bool Sent;
    }

    public class OnlineUser
    {
        public IPAddress IP;
        public string Name;
        public List<SendContent> SendList;

        public OnlineUser(IPAddress ip)
        {
            IP = ip;
            SendList = new List<SendContent>();
            Name = string.Empty;
        }


        public string GetFirstSendContent()
        {
            var returnString = string.Empty;
            lock (SendList)
            {
                var sendlist = from row in SendList
                               where row.Sent == false
                               select row;
                if (sendlist.Count() > 0)
                {
                    var temp = sendlist.First();
                    returnString = temp.Id + " " + temp.Mode + " " + temp.From + " " + temp.To + (temp.Message == string.Empty ? "" : " " + temp.Message);
                    if (temp.Mode == "send")
                    {
                        temp.Sent = true;
                    }
                    else
                    {
                        SendList.Remove(temp);
                    }
                }
            }
            return returnString;
        }
    }
}
