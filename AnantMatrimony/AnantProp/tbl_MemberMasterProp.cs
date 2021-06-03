using System;
namespace AnantMatrimony
{

    public enum iManglik
    {
        No = 0,
        Yes = 1,
        Doesnt_Know = 2
    }

    public enum iDiet
    {
        Doesnt_Matter = 0,
        Veg = 1,
        Non_Veg = 2,
        Occationally_Non_Veg = 3,
        Eggetarian = 4,
        Jain = 5,
        Vegan = 6
    }

    public enum iDrink
    {
        Doesnt_Matter = 0,
        No = 1,
        yes = 2,
        Occationally = 3

    }

    public enum iSmoke
    {
        Doesnt_Matter = 0,
        No = 1,
        yes = 2,
        Occationally = 3
    }

    public class tbl_MemberMasterProp
    {
        private int _MemberCode = 0;
        public int MemberCode
        {
            get { return _MemberCode; }
            set { _MemberCode = value; }
        }

        private string _ProfileID;
        public string ProfileID
        {
            get { return _ProfileID; }
            set { _ProfileID = value; }
        }

        private int _ProfileCreatedBy;
        public int ProfileCreatedBy
        {
            get { return _ProfileCreatedBy; }
            set { _ProfileCreatedBy = value; }
        }

        private string _MemberName;
        public string MemberName
        {
            get { return _MemberName; }
            set { _MemberName = value; }
        }

        private int _Gender;
        public int Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }

        private DateTime _DateofBirth = DateTime.Today.Date;
        public DateTime DateofBirth
        {
            get { return _DateofBirth; }
            set { _DateofBirth = Convert.ToDateTime(value.ToString("yyyy-MM-dd")); }
        }

        private DateTime _TimeofBirth = DateTime.Today.Date;
        public DateTime TimeofBirth
        {
            get { return _TimeofBirth; }
            set { _TimeofBirth = Convert.ToDateTime(value.ToString("yyyy-MM-dd HH:mm:ss ttt")); }
        }

        private string _BirthPlace;
        public string BirthPlace
        {
            get { return _BirthPlace; }
            set { _BirthPlace = value; }
        }

        private int _MaritalStatus;
        public int MaritalStatus
        {
            get { return _MaritalStatus; }
            set { _MaritalStatus = value; }
        }

        private int _NoOfChildren;
        public int NoOfChildren
        {
            get { return _NoOfChildren; }
            set { _NoOfChildren = value; }
        }

        private bool _LiveChildrenTogether;
        public bool LiveChildrenTogether
        {
            get { return _LiveChildrenTogether; }
            set { _LiveChildrenTogether = value; }
        }

        private int _Height;
        public int Height
        {
            get { return _Height; }
            set { _Height = value; }
        }

        private int _Weight;
        public int Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }

        private int _BodyType;
        public int BodyType
        {
            get { return _BodyType; }
            set { _BodyType = value; }
        }

        private int _HealthInformation;
        public int HealthInformation
        {
            get { return _HealthInformation; }
            set { _HealthInformation = value; }
        }

        private int _Complexion;
        public int Complexion
        {
            get { return _Complexion; }
            set { _Complexion = value; }
        }

        private int _AnyDisability;
        public int AnyDisability
        {
            get { return _AnyDisability; }
            set { _AnyDisability = value; }
        }

        private int _BloodGroup;
        public int BloodGroup
        {
            get { return _BloodGroup; }
            set { _BloodGroup = value; }
        }

        private string _HomeAddress1;
        public string HomeAddress1
        {
            get { return _HomeAddress1; }
            set { _HomeAddress1 = value; }
        }

        private string _HomeAddress2;
        public string HomeAddress2
        {
            get { return _HomeAddress2; }
            set { _HomeAddress2 = value; }
        }

        private int _VisaStatus;
        public int VisaStatus
        {
            get { return _VisaStatus; }
            set { _VisaStatus = value; }
        }

        private int _VisaCountry;
        public int VisaCountry
        {
            get { return _VisaCountry; }
            set { _VisaCountry = value; }
        }

        private int _Country;
        public int Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

        private int _StateCity;
        public int StateCity
        {
            get { return _StateCity; }
            set { _StateCity = value; }
        }

        private string _MobileNo;
        public string MobileNo
        {
            get { return _MobileNo; }
            set { _MobileNo = value; }
        }

        private string _LandlineNo;
        public string LandlineNo
        {
            get { return _LandlineNo; }
            set { _LandlineNo = value; }
        }

        private string _MobileNo1;
        public string MobileNo1
        {
            get { return _MobileNo1; }
            set { _MobileNo1 = value; }
        }

        private string _LandlineNo1;
        public string LandlineNo1
        {
            get { return _LandlineNo1; }
            set { _LandlineNo1 = value; }
        }

        private string _SecondaryEmailID;
        public string SecondaryEmailID
        {
            get { return _SecondaryEmailID; }
            set { _SecondaryEmailID = value; }
        }

        private int _Religion;
        public int Religion
        {
            get { return _Religion; }
            set { _Religion = value; }
        }

        private int _MotherTongue;
        public int MotherTongue
        {
            get { return _MotherTongue; }
            set { _MotherTongue = value; }
        }

        private int _Caste;
        public int Caste
        {
            get { return _Caste; }
            set { _Caste = value; }
        }

        private int _SubCaste;
        public int SubCaste
        {
            get { return _SubCaste; }
            set { _SubCaste = value; }
        }

        private int _Gotra;
        public int Gotra
        {
            get { return _Gotra; }
            set { _Gotra = value; }
        }

        private string _FatherName;
        public string FatherName
        {
            get { return _FatherName; }
            set { _FatherName = value; }
        }

        private string _FatherOccupation;
        public string FatherOccupation
        {
            get { return _FatherOccupation; }
            set { _FatherOccupation = value; }
        }

        private string _MotherName;
        public string MotherName
        {
            get { return _MotherName; }
            set { _MotherName = value; }
        }

        private string _MotherOccupation;
        public string MotherOccupation
        {
            get { return _MotherOccupation; }
            set { _MotherOccupation = value; }
        }

        private string _MosalPlace;
        public string MosalPlace
        {
            get { return _MosalPlace; }
            set { _MosalPlace = value; }
        }

        private int _MarriedBrothers;
        public int MarriedBrothers
        {
            get { return _MarriedBrothers; }
            set { _MarriedBrothers = value; }
        }

        private int _TotalSisters;
        public int TotalSisters
        {
            get { return _TotalSisters; }
            set { _TotalSisters = value; }
        }

        private int _MarriedSisters;
        public int MarriedSisters
        {
            get { return _MarriedSisters; }
            set { _MarriedSisters = value; }
        }

        private string _NativePlace;
        public string NativePlace
        {
            get { return _NativePlace; }
            set { _NativePlace = value; }
        }

        private int _FamilyType;
        public int FamilyType
        {
            get { return _FamilyType; }
            set { _FamilyType = value; }
        }

        private int _FamilyValues;
        public int FamilyValues
        {
            get { return _FamilyValues; }
            set { _FamilyValues = value; }
        }

        private iManglik _Manglik;
        public iManglik Manglik
        {
            get { return _Manglik; }
            set { _Manglik = value; }
        }

        private int _Nakshtra;
        public int Nakshtra
        {
            get { return _Nakshtra; }
            set { _Nakshtra = value; }
        }

        private int _Rashi;
        public int Rashi
        {
            get { return _Rashi; }
            set { _Rashi = value; }
        }

        private int _Sunsign;
        public int Sunsign
        {
            get { return _Sunsign; }
            set { _Sunsign = value; }
        }

        private int _Education;
        public int Education
        {
            get { return _Education; }
            set { _Education = value; }
        }

        private string _Degree;
        public string Degree
        {
            get { return _Degree; }
            set { _Degree = value; }
        }

        private int _Occupation;
        public int Occupation
        {
            get { return _Occupation; }
            set { _Occupation = value; }
        }

        private string _OccupationDtls;
        public string OccupationDtls
        {
            get { return _OccupationDtls; }
            set { _OccupationDtls = value; }
        }

        private int _WorkingAs;
        public int WorkingAs
        {
            get { return _WorkingAs; }
            set { _WorkingAs = value; }
        }

        private int _WorkingWith;
        public int WorkingWith
        {
            get { return _WorkingWith; }
            set { _WorkingWith = value; }
        }

        private string _WorkAddress;
        public string WorkAddress
        {
            get { return _WorkAddress; }
            set { _WorkAddress = value; }
        }

        private int _AnnualIncomeCurrency;
        public int AnnualIncomeCurrency
        {
            get { return _AnnualIncomeCurrency; }
            set { _AnnualIncomeCurrency = value; }
        }

        private int _AnnualIncome;
        public int AnnualIncome
        {
            get { return _AnnualIncome; }
            set { _AnnualIncome = value; }
        }

        private iDiet _Diet;
        public iDiet Diet
        {
            get { return _Diet; }
            set { _Diet = value; }
        }

        private iDrink _Drink;
        public iDrink Drink
        {
            get { return _Drink; }
            set { _Drink = value; }
        }

        private iSmoke _Smoke;
        public iSmoke Smoke
        {
            get { return _Smoke; }
            set { _Smoke = value; }
        }

        private string _AboutInfo;
        public string AboutInfo
        {
            get { return _AboutInfo; }
            set { _AboutInfo = value; }
        }

        private string _EmailID;
        public string EmailID
        {
            get { return _EmailID; }
            set { _EmailID = value; }
        }
        private string _NewPassword;

        public string NewPassword
        {
            get { return _NewPassword; }
            set { _NewPassword = value; }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private DateTime _RegisterDate = DateTime.Today.Date;
        public DateTime RegisterDate
        {
            get { return _RegisterDate; }
            set { _RegisterDate = Convert.ToDateTime(value.ToString("yyyy-MM-dd")); }
        }

        private int _isActive;
        public int isActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        private string _Choice;
        public string Choice
        {
            get { return _Choice; }
            set { _Choice = value; }
        }

        private string _Remarks;
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }

        private int _mStatus;
        public int mStatus
        {
            get { return _mStatus; }
            set { _mStatus = value; }
        }

        private string _FileNote;
        public string FileNote
        {
            get { return _FileNote; }
            set { _FileNote = value; }
        }

        private int _isPhotoDisplay;
        public int isPhotoDisplay
        {
            get { return _isPhotoDisplay; }
            set { _isPhotoDisplay = value; }
        }

        private int _Shani;
        public int Shani
        {
            get { return _Shani; }
            set { _Shani = value; }
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

        private string _SearchBy1;
        public string SearchBy1
        {
            get { return _SearchBy1; }
            set { _SearchBy1 = value; }
        }

        private string _SearchVal1;
        public string SearchVal1
        {
            get { return _SearchVal1; }
            set { _SearchVal1 = value; }
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

        private bool _isLogedin;
        public bool isLogedin
        {
            get { return _isLogedin; }
            set { _isLogedin = value; }
        }

        private int _LoginCode;
        public int LoginCode
        {
            get { return _LoginCode; }
            set { _LoginCode = value; }
        }

        private int _FormNo;
        public int FormNo
        {
            get { return _FormNo; }
            set { _FormNo = value; }
        }

        private int _AgeDiff;
        public int AgeDiff
        {
            get { return _AgeDiff; }
            set { _AgeDiff = value; }
        }

        private string _MobileNo_Rel;
        public string MobileNo_Rel
        {
            get { return _MobileNo_Rel; }
            set { _MobileNo_Rel = value; }
        }
        private string _MobileNo1_Rel;
        public string MobileNo1_Rel
        {
            get { return _MobileNo1_Rel; }
            set { _MobileNo1_Rel = value; }
        }

        private string _LandlineNo1_Rel;
        public string LandlineNo1_Rel
        {
            get { return _LandlineNo1_Rel; }
            set { _LandlineNo1_Rel = value; }
        }

        private string _MobileNo2_Rel;
        public string MobileNo2_Rel
        {
            get { return _MobileNo2_Rel; }
            set { _MobileNo2_Rel = value; }
        }

    }

    public class tbl_MemberMasterSearchProp
    {
        //--------SQL Condition Search
        private int _sMemberCode;
        public int sMemberCode
        {
            get { return _sMemberCode; }
            set { _sMemberCode = value; }
        }

        private string _sGender;
        public string sGender
        {
            get { return _sGender; }
            set { _sGender = value; }
        }

        private string _sAgeStart;
        public string sAgeStart
        {
            get { return _sAgeStart; }
            set { _sAgeStart = value; }
        }

        private string _sAgeUpto;
        public string sAgeUpto
        {
            get { return _sAgeUpto; }
            set { _sAgeUpto = value; }
        }

        private string _sMaritalStatus;
        public string sMaritalStatus
        {
            get { return _sMaritalStatus; }
            set { _sMaritalStatus = value; }
        }

        private string _sEducation;
        public string sEducation
        {
            get { return _sEducation; }
            set { _sEducation = value; }
        }

        private string _sCountry;
        public string sCountry
        {
            get { return _sCountry; }
            set { _sCountry = value; }
        }

        private string _sStateCity;
        public string sStateCity
        {
            get { return _sStateCity; }
            set { _sStateCity = value; }
        }

        private bool _sSqlCondition;
        public bool sSqlCondition
        {
            get { return _sSqlCondition; }
            set { _sSqlCondition = value; }
        }

        private string _sReligion;
        public string sReligion
        {
            get { return _sReligion; }
            set { _sReligion = value; }
        }

        private string _sCaste;
        public string sCaste
        {
            get { return _sCaste; }
            set { _sCaste = value; }
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
