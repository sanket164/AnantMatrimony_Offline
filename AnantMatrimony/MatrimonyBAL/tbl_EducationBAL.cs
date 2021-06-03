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
    public class tbl_EducationBAL
    {
        public int InsertUpdate_Data(tbl_EducationProp Objtbl_EducationProp)
        {
            try
            {
                tbl_EducationDAL Objtbl_EducationDAL = new tbl_EducationDAL();
                return Objtbl_EducationDAL.InsertUpdate_Data(Objtbl_EducationProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete_Data(tbl_EducationProp Objtbl_EducationProp)
        {
            try
            {
                tbl_EducationDAL Objtbl_EducationDAL = new tbl_EducationDAL();
                return Objtbl_EducationDAL.Delete_Data(Objtbl_EducationProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_EducationProp Objtbl_EducationProp, ref int PageCount, int EducationCode)
        {
            try
            {
                if (Objtbl_EducationProp.EducationCode != 0)
                {
                    Objtbl_EducationProp.PageNo = 1;
                    Objtbl_EducationProp.RecordCount = 1;
                }
                int RecordCount = 0;
                tbl_EducationDAL Objtbl_EducationDAL = new tbl_EducationDAL();
                DataSet dsData = Objtbl_EducationDAL.Select_Data(Objtbl_EducationProp, ref RecordCount, EducationCode);
                Objtbl_EducationProp.RecordCount = dsData.Tables[0].Rows.Count;
                double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_EducationProp.RecordCount);
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
        public DataSet Search_Data(tbl_EducationProp Objtbl_EducationProp)
        {
            try
            {
                tbl_EducationDAL Objtbl_EducationDAL = new tbl_EducationDAL();
                return Objtbl_EducationDAL.Search_Data(Objtbl_EducationProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SelectCombo_Data(tbl_EducationProp Objtbl_EducationProp)
        {
            try
            {
                tbl_EducationDAL Objtbl_EducationDAL = new tbl_EducationDAL();
                return Objtbl_EducationDAL.SelectCombo_Data(Objtbl_EducationProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
