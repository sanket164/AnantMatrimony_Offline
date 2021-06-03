using System;
namespace AnantMatrimony
{
    public class tbl_WorkingAsProp
    {
        private int _WorkingAsCode;
        public int WorkingAsCode
        {
            get { return _WorkingAsCode; }
            set { _WorkingAsCode = value; }
        }
        private string _WorkingAs;
        public string WorkingAs
        {
            get { return _WorkingAs; }
            set { _WorkingAs = value; }
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
