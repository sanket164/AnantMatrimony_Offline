using System;
namespace AnantMatrimony
{
    public class tbl_WorkingWithProp
    {
        private int _WorkingWithCode;
        public int WorkingWithCode
        {
            get { return _WorkingWithCode; }
            set { _WorkingWithCode = value; }
        }
        private string _WorkingWith;
        public string WorkingWith
        {
            get { return _WorkingWith; }
            set { _WorkingWith = value; }
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
