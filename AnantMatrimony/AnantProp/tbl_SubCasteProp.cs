using System;
namespace AnantMatrimony
{
    public class tbl_SubCasteProp
    {
        private int _SubCasteCode;
        public int SubCasteCode
        {
            get { return _SubCasteCode; }
            set { _SubCasteCode = value; }
        }
        private string _SubCaste;
        public string SubCaste
        {
            get { return _SubCaste; }
            set { _SubCaste = value; }
        }

        private int _CasteCode;
        public int CasteCode
        {
            get { return _CasteCode; }
            set { _CasteCode = value; }
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
