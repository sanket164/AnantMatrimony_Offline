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
    public class tbl_CountryBAL
    {
        public int InsertUpdate_Data(tbl_CountryProp Objtbl_CountryProp)
        {
            try
            {
                tbl_CountryDAL Objtbl_CountryDAL = new tbl_CountryDAL();
                return Objtbl_CountryDAL.InsertUpdate_Data(Objtbl_CountryProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public int Delete_Data(tbl_CountryProp Objtbl_CountryProp)
        {
            try
            {
                tbl_CountryDAL Objtbl_CountryDAL = new tbl_CountryDAL();
                return Objtbl_CountryDAL.Delete_Data(Objtbl_CountryProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Data(tbl_CountryProp Objtbl_CountryProp, ref int PageCount, int CountryCode)
        {
            try
            {
                if (Objtbl_CountryProp.CountryCode != 0)
                {
                    Objtbl_CountryProp.PageNo = 1;
                    Objtbl_CountryProp.RecordCount = 1;
                }
                int RecordCount = 0;
                tbl_CountryDAL Objtbl_CountryDAL = new tbl_CountryDAL();
                DataSet dsData = Objtbl_CountryDAL.Select_Data(Objtbl_CountryProp, ref RecordCount, CountryCode);
                Objtbl_CountryProp.RecordCount = dsData.Tables[0].Rows.Count;
                double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_CountryProp.RecordCount);
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
        
        public DataSet Search_Data(tbl_CountryProp Objtbl_CountryProp)
        {
            try
            {
                tbl_CountryDAL Objtbl_CountryDAL = new tbl_CountryDAL();
                return Objtbl_CountryDAL.Search_Data(Objtbl_CountryProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataSet SelectCombo_Data(tbl_CountryProp Objtbl_CountryProp)
        {
            try
            {
                tbl_CountryDAL Objtbl_CountryDAL = new tbl_CountryDAL();
                return Objtbl_CountryDAL.SelectCombo_Data(Objtbl_CountryProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
