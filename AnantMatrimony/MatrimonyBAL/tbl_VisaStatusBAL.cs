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
    public class tbl_VisaStatusBAL
    {
        public int InsertUpdate_Data(tbl_VisaStatusProp Objtbl_VisaStatusProp)
        {
            try
            {
                tbl_VisaStatusDAL Objtbl_VisaStatusDAL = new tbl_VisaStatusDAL();
                return Objtbl_VisaStatusDAL.InsertUpdate_Data(Objtbl_VisaStatusProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete_Data(tbl_VisaStatusProp Objtbl_VisaStatusProp)
        {
            try
            {
                tbl_VisaStatusDAL Objtbl_VisaStatusDAL = new tbl_VisaStatusDAL();
                return Objtbl_VisaStatusDAL.Delete_Data(Objtbl_VisaStatusProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_VisaStatusProp Objtbl_VisaStatusProp, ref int PageCount, int VisaStatusCode)
        {
            try
            {
                if (Objtbl_VisaStatusProp.VisaStatusCode != 0)
                {
                    Objtbl_VisaStatusProp.PageNo = 1;
                    Objtbl_VisaStatusProp.RecordCount = 1;
                }
                int RecordCount = 0;
                tbl_VisaStatusDAL Objtbl_VisaStatusDAL = new tbl_VisaStatusDAL();
                DataSet dsData = Objtbl_VisaStatusDAL.Select_Data(Objtbl_VisaStatusProp, ref RecordCount, VisaStatusCode);
                Objtbl_VisaStatusProp.RecordCount = dsData.Tables[0].Rows.Count;
                double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_VisaStatusProp.RecordCount);
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
        public DataSet Search_Data(tbl_VisaStatusProp Objtbl_VisaStatusProp)
        {
            try
            {
                tbl_VisaStatusDAL Objtbl_VisaStatusDAL = new tbl_VisaStatusDAL();
                return Objtbl_VisaStatusDAL.Search_Data(Objtbl_VisaStatusProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SelectCombo_Data(tbl_VisaStatusProp Objtbl_VisaStatusProp)
        {
            try
            {
                tbl_VisaStatusDAL Objtbl_VisaStatusDAL = new tbl_VisaStatusDAL();
                return Objtbl_VisaStatusDAL.SelectCombo_Data(Objtbl_VisaStatusProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
