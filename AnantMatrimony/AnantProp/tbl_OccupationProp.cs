using System;
namespace AnantMatrimony
{
    public class tbl_OccupationProp
    {
        private int _OccupationCode;
        public int OccupationCode
        {
            get { return _OccupationCode; }
            set { _OccupationCode = value; }
        }
        private string _Occupation;
        public string Occupation
        {
            get { return _Occupation; }
            set { _Occupation = value; }
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
