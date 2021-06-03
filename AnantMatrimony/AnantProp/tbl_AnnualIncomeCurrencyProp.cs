using System;
namespace AnantMatrimony
{
    public class tbl_AnnualIncomeCurrencyProp
    {
        private int _AnnualIncomeCurrencyCode;
        public int AnnualIncomeCurrencyCode
        {
            get { return _AnnualIncomeCurrencyCode; }
            set { _AnnualIncomeCurrencyCode = value; }
        }
        private string _AnnualIncomeCurrency;
        public string AnnualIncomeCurrency
        {
            get { return _AnnualIncomeCurrency; }
            set { _AnnualIncomeCurrency = value; }
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
