using System;
namespace AnantMatrimony
{
    public class tbl_BloodGroupProp
    {
        private int _BloodGroupCode;
        public int BloodGroupCode
        {
            get { return _BloodGroupCode; }
            set { _BloodGroupCode = value; }
        }
        private string _BloodGroup;
        public string BloodGroup
        {
            get { return _BloodGroup; }
            set { _BloodGroup = value; }
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
