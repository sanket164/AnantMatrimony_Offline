using System;
namespace AnantMatrimony
{
    public class tbl_ProfileCreatedByProp
    {
        private int _ProfileCreatedByCode;
        public int ProfileCreatedByCode
        {
            get { return _ProfileCreatedByCode; }
            set { _ProfileCreatedByCode = value; }
        }
        private string _ProfileCreatedBy;
        public string ProfileCreatedBy
        {
            get { return _ProfileCreatedBy; }
            set { _ProfileCreatedBy = value; }
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
