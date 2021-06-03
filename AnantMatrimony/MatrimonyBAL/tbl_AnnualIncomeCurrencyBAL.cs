using AnantMatrimony.MatrimonyDAL;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace AnantMatrimony
{
    public class tbl_AnnualIncomeCurrencyBAL
    {
        public int InsertUpdate_Data(tbl_AnnualIncomeCurrencyProp Objtbl_AnnualIncomeCurrencyProp)
        {
            try
            {
                tbl_AnnualIncomeCurrencyDAL Objtbl_AnnualIncomeCurrencyDAL = new tbl_AnnualIncomeCurrencyDAL();
                return Objtbl_AnnualIncomeCurrencyDAL.InsertUpdate_Data(Objtbl_AnnualIncomeCurrencyProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete_Data(tbl_AnnualIncomeCurrencyProp Objtbl_AnnualIncomeCurrencyProp)
        {
            try
            {
                tbl_AnnualIncomeCurrencyDAL Objtbl_AnnualIncomeCurrencyDAL = new tbl_AnnualIncomeCurrencyDAL();
                return Objtbl_AnnualIncomeCurrencyDAL.Delete_Data(Objtbl_AnnualIncomeCurrencyProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_AnnualIncomeCurrencyProp Objtbl_AnnualIncomeCurrencyProp, ref int PageCount, int AnnualIncomeCurrencyCode)
        {
            try
            {
                if (Objtbl_AnnualIncomeCurrencyProp.AnnualIncomeCurrencyCode != 0)
                {
                    Objtbl_AnnualIncomeCurrencyProp.PageNo = 1;
                    Objtbl_AnnualIncomeCurrencyProp.RecordCount = 1;
                }
                int RecordCount = 0;
                tbl_AnnualIncomeCurrencyDAL Objtbl_AnnualIncomeCurrencyDAL = new tbl_AnnualIncomeCurrencyDAL();
                DataSet dsData = Objtbl_AnnualIncomeCurrencyDAL.Select_Data(Objtbl_AnnualIncomeCurrencyProp, ref RecordCount, AnnualIncomeCurrencyCode);
                Objtbl_AnnualIncomeCurrencyProp.RecordCount = dsData.Tables[0].Rows.Count;
                double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_AnnualIncomeCurrencyProp.RecordCount);
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
        public DataSet Search_Data(tbl_AnnualIncomeCurrencyProp Objtbl_AnnualIncomeCurrencyProp)
        {
            try
            {
                tbl_AnnualIncomeCurrencyDAL Objtbl_AnnualIncomeCurrencyDAL = new tbl_AnnualIncomeCurrencyDAL();
                return Objtbl_AnnualIncomeCurrencyDAL.Search_Data(Objtbl_AnnualIncomeCurrencyProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SelectCombo_Data(tbl_AnnualIncomeCurrencyProp Objtbl_AnnualIncomeCurrencyProp)
        {
            try
            {
                tbl_AnnualIncomeCurrencyDAL Objtbl_AnnualIncomeCurrencyDAL = new tbl_AnnualIncomeCurrencyDAL();
                return Objtbl_AnnualIncomeCurrencyDAL.SelectCombo_Data(Objtbl_AnnualIncomeCurrencyProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
