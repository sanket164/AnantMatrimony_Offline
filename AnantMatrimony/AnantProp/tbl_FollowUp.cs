using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnantMatrimony.AnantProp
{
    class tbl_FollowUp
    {
        private int _FollowUpId;
        public int FollowUpId
        {
            get { return _FollowUpId; }
            set { _FollowUpId = value; }
        }
        private string _ProfileId;
        public string ProfileId
        {
            get { return _ProfileId; }
            set { _ProfileId = value; }
        }
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private DateTime _Date;
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        private string _Status;
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private string _Remark1;
        public string Remark1
        {
            get { return _Remark1; }
            set { _Remark1 = value; }
        }

        private string _Remark2;
        public string Remark2
        {
            get { return _Remark2; }
            set { _Remark2 = value; }
        }

        private string _Remark3;
        public string Remark3
        {
            get { return _Remark3; }
            set { _Remark3 = value; }
        }

        private string _Remark4;
        public string Remark4
        {
            get { return _Remark4; }
            set { _Remark4 = value; }
        }

        private string _Remark5;
        public string Remark5
        {
            get { return _Remark5; }
            set { _Remark5 = value; }
        }

        private int _MemberCode;
        public int MemberCode
        {
            get { return _MemberCode; }
            set { _MemberCode = value; }
        }
    }
}
