using System;
namespace AnantMatrimony
{
    public class tbl_MembershipTypeProp
    {
        private int _MembershipTypeCode;
        public int MembershipTypeCode
        {
            get { return _MembershipTypeCode; }
            set { _MembershipTypeCode = value; }
        }
        private string _MembershipType;
        public string MembershipType
        {
            get { return _MembershipType; }
            set { _MembershipType = value; }
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
