using System;
namespace AnantMatrimony
{
    public class tbl_AnnualIncomeProp
    {
        private int _AnnualIncomeCode;
        public int AnnualIncomeCode
        {
            get { return _AnnualIncomeCode; }
            set { _AnnualIncomeCode = value; }
        }
        private string _AnnualIncome;
        public string AnnualIncome
        {
            get { return _AnnualIncome; }
            set { _AnnualIncome = value; }
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
