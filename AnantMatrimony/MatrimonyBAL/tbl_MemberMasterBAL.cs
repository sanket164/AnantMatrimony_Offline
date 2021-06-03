using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace AnantMatrimony
{
    public class tbl_MemberMasterBAL
    {
        public int InsertUpdate_Data(ref tbl_MemberMasterProp Objtbl_MemberMasterProp)
        {
            try
            {
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                return Objtbl_MemberMasterDAL.InsertUpdate_Data(ref Objtbl_MemberMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Created For Admin
        //public int InsertUpdate_DataNA(ref tbl_MemberMasterProp Objtbl_MemberMasterProp)
        //{
        //    try
        //    {
        //        tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
        //        return Objtbl_MemberMasterDAL.InsertUpdate_DataNA(ref Objtbl_MemberMasterProp);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public int Update_ProfileStatus(tbl_MemberMasterProp Objtbl_MemberMasterProp)
        {
            try
            {
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                return Objtbl_MemberMasterDAL.Update_ProfileStatus(Objtbl_MemberMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete_Data(tbl_MemberMasterProp Objtbl_MemberMasterProp)
        {
            try
            {
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                return Objtbl_MemberMasterDAL.Delete_Data(Objtbl_MemberMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Data(tbl_MemberMasterProp Objtbl_MemberMasterProp, ref int PageCount)
        {
            try
            {
                if (Objtbl_MemberMasterProp.MemberCode != 0)
                {
                    Objtbl_MemberMasterProp.PageNo = 1;
                    Objtbl_MemberMasterProp.RecordCount = 1;
                }
                int RecordCount = 0;
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                DataSet dsData = Objtbl_MemberMasterDAL.Select_Data(Objtbl_MemberMasterProp, ref RecordCount);
                double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_MemberMasterProp.RecordCount);
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    string[] PageDecimal = Page.ToString().Split('.');
                    if (PageDecimal.Length > 1 && Convert.ToInt32(PageDecimal[1]) > 0)
                    {
                        PageCount = Convert.ToInt32(Page.ToString().Split('.')[0]) + 1;
                    }
                    else
                    {
                        PageCount = Convert.ToInt32(Page);
                    }
                }
                else
                {
                    PageCount = 0;
                }
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public DataSet Select_DataN(tbl_MemberMasterProp Objtbl_MemberMasterProp, ref int PageCount)
        //{
        //    try
        //    {
        //        if (Objtbl_MemberMasterProp.MemberCode != 0)
        //        {
        //            Objtbl_MemberMasterProp.PageNo = 1;
        //            Objtbl_MemberMasterProp.RecordCount = 1;
        //        }
        //        int RecordCount = 0;
        //        tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
        //        DataSet dsData = Objtbl_MemberMasterDAL.Select_DataN(Objtbl_MemberMasterProp, ref RecordCount);
        //        double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_MemberMasterProp.RecordCount);
        //        if (dsData.Tables[0].Rows.Count > 0)
        //        {
        //            string[] PageDecimal = Page.ToString().Split('.');
        //            if (PageDecimal.Length > 1 && Convert.ToInt32(PageDecimal[1]) > 0)
        //            {
        //                PageCount = Convert.ToInt32(Page.ToString().Split('.')[0]) + 1;
        //            }
        //            else
        //            {
        //                PageCount = Convert.ToInt32(Page);
        //            }
        //        }
        //        else
        //        {
        //            PageCount = 0;
        //        }
        //        return dsData;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public DataSet Select_DataNA(tbl_MemberMasterProp Objtbl_MemberMasterProp)
        //{
        //    try
        //    {
        //        tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
        //        return Objtbl_MemberMasterDAL.Select_DataNA(Objtbl_MemberMasterProp);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public DataSet Select_ExpiredInDays(tbl_MemberMasterProp Objtbl_MemberMasterProp)
        {
            try
            {
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                DataSet dsData = Objtbl_MemberMasterDAL.Select_ExpiredInDays(Objtbl_MemberMasterProp);

                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Load_MFProfileList(tbl_MemberMasterProp Objtbl_MemberMasterProp)
        {
            try
            {

                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                DataSet dsData = Objtbl_MemberMasterDAL.Load_MFProfileList(Objtbl_MemberMasterProp);

                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ForgotPassword(tbl_MemberMasterProp Objtbl_MemberMasterProp)
        {
            try
            {

                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                DataSet dsData = Objtbl_MemberMasterDAL.ForgotPassword(Objtbl_MemberMasterProp);

                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ChangePassword(tbl_MemberMasterProp Objtbl_MemberMasterProp)
        {
            try
            {

                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                return Objtbl_MemberMasterDAL.ChangePassword(Objtbl_MemberMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Load_EmailReport()
        {
            try
            {

                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                DataSet dsData = Objtbl_MemberMasterDAL.Load_EmailReport();

                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Search_Data(tbl_MemberMasterProp Objtbl_MemberMasterProp, ref int PageCount)
        {
            try
            {
                if (Objtbl_MemberMasterProp.MemberCode != 0)
                {
                    Objtbl_MemberMasterProp.PageNo = 1;
                    Objtbl_MemberMasterProp.RecordCount = 1;
                }
                int RecordCount = 0;
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                DataSet dsData = Objtbl_MemberMasterDAL.Search_Data(Objtbl_MemberMasterProp, ref RecordCount);
                double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_MemberMasterProp.RecordCount);
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    string[] PageDecimal = Page.ToString().Split('.');
                    if (PageDecimal.Length > 1 && Convert.ToInt32(PageDecimal[1]) > 0)
                    {
                        PageCount = Convert.ToInt32(Page.ToString().Split('.')[0]) + 1;
                    }
                    else
                    {
                        PageCount = Convert.ToInt32(Page);
                    }
                }
                else
                {
                    PageCount = 0;
                }
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SelectCombo_Data()
        {
            try
            {
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                return Objtbl_MemberMasterDAL.SelectCombo_Data();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Load_ProfileList(tbl_MemberMasterSearchProp Objtbl_MemberMasterSearchProp, ref int PageCount, ref int RecordCount)
        {
            try
            {
                if (Objtbl_MemberMasterSearchProp.PageNo == 0 && Objtbl_MemberMasterSearchProp.sMemberCode != -1)
                {
                    Objtbl_MemberMasterSearchProp.PageNo = 1;
                    Objtbl_MemberMasterSearchProp.RecordCount = 8;
                }
                //int RecordCount = 0;
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                DataSet dsData = Objtbl_MemberMasterDAL.Load_ProfileList(Objtbl_MemberMasterSearchProp, ref RecordCount);

                if (Objtbl_MemberMasterSearchProp.sMemberCode != -1)
                {
                    double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_MemberMasterSearchProp.RecordCount);
                    if (dsData.Tables[0].Rows.Count > 0)
                    {
                        string[] PageDecimal = Page.ToString().Split('.');
                        if (PageDecimal.Length > 1 && Convert.ToInt32(PageDecimal[1]) > 0)
                        {
                            PageCount = Convert.ToInt32(Page.ToString().Split('.')[0]) + 1;
                        }
                        else
                        {
                            PageCount = Convert.ToInt32(Page);
                        }
                    }
                    else
                    {
                        PageCount = 0;
                    }
                }
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Load_ProfileList_New(string strMasterCode)
        {
            try
            {
                //int RecordCount = 0;
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                DataSet dsData = Objtbl_MemberMasterDAL.Load_ProfileList_New(strMasterCode);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GET_PAID_MEMBERSHIP(string strCondition)
        {
            try
            {
                //int RecordCount = 0;
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                DataSet dsData = Objtbl_MemberMasterDAL.GET_PAID_MEMBERSHIP(strCondition);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GET_REGISTERED_MEMBER(string strCondition)
        {
            try
            {
                //int RecordCount = 0;
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                DataSet dsData = Objtbl_MemberMasterDAL.GET_REGISTERED_MEMBER(strCondition);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GET_ExpiredMembership(string strCondition)
        {
            try
            {
                //int RecordCount = 0;
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                DataSet dsData = Objtbl_MemberMasterDAL.GET_ExpiredMembership(strCondition);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Load_BookMarkList(tbl_MemberMasterProp Objtbl_MemberMasterProp)
        {
            try
            {
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                DataSet dsData = Objtbl_MemberMasterDAL.Load_BookMarkList(Objtbl_MemberMasterProp);

                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Profile_Summary(tbl_MemberMasterProp Objtbl_MemberMasterProp)
        {
            try
            {
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                return Objtbl_MemberMasterDAL.Profile_Summary(Objtbl_MemberMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Load_MemberDetails(tbl_MemberMasterProp Objtbl_MemberMasterProp)
        {
            try
            {
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                return Objtbl_MemberMasterDAL.Load_MemberDetails(Objtbl_MemberMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet CheckforLogin(tbl_MemberMasterProp Objtbl_MemberMasterProp)
        {
            try
            {
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                return Objtbl_MemberMasterDAL.CheckforLogin(Objtbl_MemberMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetBirthYearList(tbl_MemberMasterSearchProp Objtbl_MemberMasterSearchProp)
        {
            try
            {
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                return Objtbl_MemberMasterDAL.GetBirthYearList(Objtbl_MemberMasterSearchProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet LoadHomePageSponserData()
        {
            try
            {
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                return Objtbl_MemberMasterDAL.LoadHomePageSponserData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*---Created BY Sanjay On 26-4-16 For the Date Purpose in PhotoName like 23167_2016041612004500.jpg Name in DateTime Format*/

        public DataSet Load_CurrentDate()
        {
            try
            {
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                return Objtbl_MemberMasterDAL.Load_CurrentDate();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Load_AdminDashboard()
        {
            try
            {

                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                return Objtbl_MemberMasterDAL.Load_AdminDashboard();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GET_UPLOAD_PHOTO_PENDING(string strCondition)
        {
            try
            {
                //int RecordCount = 0;
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                DataSet dsData = Objtbl_MemberMasterDAL.GET_UPLOAD_PHOTO_PENDING(strCondition);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetMarriedConfirmationList(string strCondition)
        {
            try
            {
                //int RecordCount = 0;
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                DataSet dsData = Objtbl_MemberMasterDAL.GetMarriedConfirmationList(strCondition);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GET_Delete_Photos_List(string strCondition)
        {
            try
            {
                //int RecordCount = 0;
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                DataSet dsData = Objtbl_MemberMasterDAL.GET_Delete_Photos_List(strCondition);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetMemberCode(string strProfileId)
        {
            tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
            return Objtbl_MemberMasterDAL.GetMemberCode(strProfileId);
        }

        public int InsertSearchLog(string SearchVal, string SearchName, DateTime SearchDatetime, int UserId)
        {
            int Res = 0;
            try
            {
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                Res = Objtbl_MemberMasterDAL.InsertSearchLog(SearchVal, SearchName, SearchDatetime, UserId);
                return Res;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public DataTable GetMemberListSearchLog(DateTime FromDate, DateTime Todate)
        {
            DataTable dsDetails = new DataTable();
            try
            {
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                dsDetails = Objtbl_MemberMasterDAL.GetMemberListSearchLog(FromDate, Todate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dsDetails;
        }
    }
}
