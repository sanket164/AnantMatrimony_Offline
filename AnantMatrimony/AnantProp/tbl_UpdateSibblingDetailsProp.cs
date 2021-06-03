using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnantMatrimony
{
    class tbl_UpdateSibblingDetailsProp
    {
        private int _MemberCode;
        public int MemberCode
        {
            get { return _MemberCode; }
            set { _MemberCode = value; }
        }
        private string _BrotherSister;
        public string BrotherSister
        {
            get { return _BrotherSister; }
            set { _BrotherSister = value; }
        }
        private string _SibblingName;
        public string SibblingName
        {
            get { return _SibblingName; }
            set { _SibblingName = value; }
        }
        private string _MaritalStatus;
        public string MaritalStatus
        {
            get { return _MaritalStatus; }
            set { _MaritalStatus = value; }
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
