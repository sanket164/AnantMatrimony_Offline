using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnantMatrimony.AnantProp
{
    class tbl_MembershipMasterProp
    {
        private int _SerialNo;
        public int SerialNo
        {
            get { return _SerialNo; }
            set { _SerialNo = value; }
        }
        private int _MemberCode;
        public int MemberCode
        {
            get { return _MemberCode; }
            set { _MemberCode = value; }
        }
        private DateTime _StartDate;
        public DateTime StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }

        private int _MembershipMonth;
        public int MembershipMonth
        {
            get { return _MembershipMonth; }
            set { _MembershipMonth = value; }
        }

        private DateTime _EndDate;
        public DateTime EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }
        private int _MemberShipTypeCode;
        public int MemberShipTypeCode
        {
            get { return _MemberShipTypeCode; }
            set { _MemberShipTypeCode = value; }
        }
        private string _FacilityCode;
        public string FacilityCode
        {
            get { return _FacilityCode; }
            set { _FacilityCode = value; }
        }
        private int _AmountReceived;
        public int AmountReceived
        {
            get { return _AmountReceived; }
            set { _AmountReceived = value; }
        }
        private int _PayBy;
        public int PayBy
        {
            get { return _PayBy; }
            set { _PayBy = value; }
        }
        private int _ChequeNo;
        public int ChequeNo
        {
            get { return _ChequeNo; }
            set { _ChequeNo = value; }
        }
        private DateTime _ChequeDate;
        public DateTime ChequeDate
        {
            get { return _ChequeDate; }
            set { _ChequeDate = value; }
        }
        private string _BankDetail;
        public string BankDetail
        {
            get { return _BankDetail; }
            set { _BankDetail = value; }
        }
        private string _IFSC;
        public string IFSC
        {
            get { return _IFSC; }
            set { _IFSC = value; }
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
