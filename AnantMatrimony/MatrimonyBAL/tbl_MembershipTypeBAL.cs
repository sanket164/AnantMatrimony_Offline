using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using AnantMatrimony;
namespace AnantMatrimony
{
    public class tbl_MembershipTypeBAL
    {
        public int InsertUpdate_Data(tbl_MembershipTypeProp Objtbl_MembershipTypeProp)
        {
            try
            {
                tbl_MembershipTypeDAL Objtbl_MembershipTypeDAL = new tbl_MembershipTypeDAL();
                return Objtbl_MembershipTypeDAL.InsertUpdate_Data(Objtbl_MembershipTypeProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete_Data(tbl_MembershipTypeProp Objtbl_MembershipTypeProp)
        {
            try
            {
                tbl_MembershipTypeDAL Objtbl_MembershipTypeDAL = new tbl_MembershipTypeDAL();
                return Objtbl_MembershipTypeDAL.Delete_Data(Objtbl_MembershipTypeProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_MembershipTypeProp Objtbl_MembershipTypeProp, ref int PageCount, int MembershipTypeCode)
        {
            try
            {
                if (Objtbl_MembershipTypeProp.MembershipTypeCode != 0)
                {
                    Objtbl_MembershipTypeProp.PageNo = 1;
                    Objtbl_MembershipTypeProp.RecordCount = 1;
                }
                int RecordCount = 0;
                tbl_MembershipTypeDAL Objtbl_MembershipTypeDAL = new tbl_MembershipTypeDAL();
                DataSet dsData = Objtbl_MembershipTypeDAL.Select_Data(Objtbl_MembershipTypeProp, ref RecordCount, MembershipTypeCode);
                Objtbl_MembershipTypeProp.RecordCount = dsData.Tables[0].Rows.Count;
                double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_MembershipTypeProp.RecordCount);
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    string[] PageDecimal = Page.ToString("0.00").Split('.');
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
        public DataSet Search_Data(tbl_MembershipTypeProp Objtbl_MembershipTypeProp)
        {
            try
            {
                tbl_MembershipTypeDAL Objtbl_MembershipTypeDAL = new tbl_MembershipTypeDAL();
                return Objtbl_MembershipTypeDAL.Search_Data(Objtbl_MembershipTypeProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SelectCombo_Data(tbl_MembershipTypeProp Objtbl_MembershipTypeProp)
        {
            try
            {
                tbl_MembershipTypeDAL Objtbl_MembershipTypeDAL = new tbl_MembershipTypeDAL();
                return Objtbl_MembershipTypeDAL.SelectCombo_Data(Objtbl_MembershipTypeProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
