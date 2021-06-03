using System;
namespace AnantMatrimony
{
    public class tbl_EducationProp
    {
        private int _EducationCode;
        public int EducationCode
        {
            get { return _EducationCode; }
            set { _EducationCode = value; }
        }
        private string _Education;
        public string Education
        {
            get { return _Education; }
            set { _Education = value; }
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
