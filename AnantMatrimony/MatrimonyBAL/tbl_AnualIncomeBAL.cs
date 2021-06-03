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
    public class tbl_AnnualIncomeBAL
    {
        public int InsertUpdate_Data(tbl_AnnualIncomeProp Objtbl_AnnualIncomeProp)
        {
            try
            {
                tbl_AnnualIncomeDAL Objtbl_AnnualIncomeDAL = new tbl_AnnualIncomeDAL();
                return Objtbl_AnnualIncomeDAL.InsertUpdate_Data(Objtbl_AnnualIncomeProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete_Data(tbl_AnnualIncomeProp Objtbl_AnnualIncomeProp)
        {
            try
            {
                tbl_AnnualIncomeDAL Objtbl_AnnualIncomeDAL = new tbl_AnnualIncomeDAL();
                return Objtbl_AnnualIncomeDAL.Delete_Data(Objtbl_AnnualIncomeProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_AnnualIncomeProp Objtbl_AnnualIncomeProp, ref int PageCount, int AnnualIncomeCode)
        {
            try
            {
                if (Objtbl_AnnualIncomeProp.AnnualIncomeCode != 0)
                {
                    Objtbl_AnnualIncomeProp.PageNo = 1;
                    Objtbl_AnnualIncomeProp.RecordCount = 1;
                }
                int RecordCount = 0;
                tbl_AnnualIncomeDAL Objtbl_AnnualIncomeDAL = new tbl_AnnualIncomeDAL();
                DataSet dsData = Objtbl_AnnualIncomeDAL.Select_Data(Objtbl_AnnualIncomeProp, ref RecordCount, AnnualIncomeCode);
                Objtbl_AnnualIncomeProp.RecordCount = dsData.Tables[0].Rows.Count;
                double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_AnnualIncomeProp.RecordCount);
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
        public DataSet Search_Data(tbl_AnnualIncomeProp Objtbl_AnnualIncomeProp)
        {
            try
            {
                tbl_AnnualIncomeDAL Objtbl_AnnualIncomeDAL = new tbl_AnnualIncomeDAL();
                return Objtbl_AnnualIncomeDAL.Search_Data(Objtbl_AnnualIncomeProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SelectCombo_Data(tbl_AnnualIncomeProp Objtbl_AnnualIncomeProp)
        {
            try
            {
                tbl_AnnualIncomeDAL Objtbl_AnnualIncomeDAL = new tbl_AnnualIncomeDAL();
                return Objtbl_AnnualIncomeDAL.SelectCombo_Data(Objtbl_AnnualIncomeProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
