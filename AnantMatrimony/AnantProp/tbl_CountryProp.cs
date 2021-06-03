using System;
namespace AnantMatrimony
{
    public class tbl_CountryProp
    {
        private int _CountryCode;
        public int CountryCode
        {
            get { return _CountryCode; }
            set { _CountryCode = value; }
        }
        private string _Country;
        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
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
