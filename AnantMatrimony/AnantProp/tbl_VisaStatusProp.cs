using System;
namespace AnantMatrimony
{
    public class tbl_VisaStatusProp
    {
        private int _VisaStatusCode;
        public int VisaStatusCode
        {
            get { return _VisaStatusCode; }
            set { _VisaStatusCode = value; }
        }
        private string _VisaStatus;
        public string VisaStatus
        {
            get { return _VisaStatus; }
            set { _VisaStatus = value; }
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
