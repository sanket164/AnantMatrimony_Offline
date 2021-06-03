using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnantMatrimony
{
    class tbl_QueryProp
    {
        private int _MessageCode;
        public int MessageCode
        {
            get { return _MessageCode; }
            set { _MessageCode = value; }
        }
        private string _Surname;
        public string Surname
        {
            get { return _Surname; }
            set { _Surname = value; }
        }
        private string _SenderName;
        public string SenderName
        {
            get { return _SenderName; }
            set { _SenderName = value; }
        }
        private string _Address;
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        private string _ContactNo;
        public string ContactNo
        {
            get { return _ContactNo; }
            set { _ContactNo = value; }
        }
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private DateTime _Date;
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }


        private string _Subject;
        public string Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }
        private string _SenderMessage;
        public string SenderMessage
        {
            get { return _SenderMessage; }
            set { _SenderMessage = value; }
        }

        private bool _Status;
        public bool Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private string _SearchBy;
        public string SearchBy
        {
            get { return _SearchBy; }
            set { _SearchBy = value; }
        }
        private string _SearchVal;
        public string SearchVal
        {
            get { return _SearchVal; }
            set { _SearchVal = value; }
        }
        private int _PageNo;
        public int PageNo
        {
            get { return _PageNo; }
            set { _PageNo = value; }
        }
        private int _RecordCount;
        public int RecordCount
        {
            get { return _RecordCount; }
            set { _RecordCount = value; }
        }
    }
}
