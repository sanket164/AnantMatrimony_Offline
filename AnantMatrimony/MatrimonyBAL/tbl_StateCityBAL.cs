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
    public class tbl_StateCityBAL
    {
        public int InsertUpdate_Data(tbl_StateCityProp Objtbl_StateCityProp)
        {
            try
            {
                tbl_StateCityDAL Objtbl_StateCityDAL = new tbl_StateCityDAL();
                return Objtbl_StateCityDAL.InsertUpdate_Data(Objtbl_StateCityProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete_Data(tbl_StateCityProp Objtbl_StateCityProp)
        {
            try
            {
                tbl_StateCityDAL Objtbl_StateCityDAL = new tbl_StateCityDAL();
                return Objtbl_StateCityDAL.Delete_Data(Objtbl_StateCityProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_StateCityProp Objtbl_StateCityProp, ref int PageCount, int StateCityCode)
        {
            try
            {
                if (Objtbl_StateCityProp.StateCityCode != 0)
                {
                    Objtbl_StateCityProp.PageNo = 1;
                    Objtbl_StateCityProp.RecordCount = 1;
                }
                int RecordCount = 0;
                tbl_StateCityDAL Objtbl_StateCityDAL = new tbl_StateCityDAL();
                DataSet dsData = Objtbl_StateCityDAL.Select_Data(Objtbl_StateCityProp, ref RecordCount, StateCityCode);
                Objtbl_StateCityProp.RecordCount = dsData.Tables[0].Rows.Count;
                double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_StateCityProp.RecordCount);
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
        public DataSet Search_Data(tbl_StateCityProp Objtbl_StateCityProp)
        {
            try
            {
                tbl_StateCityDAL Objtbl_StateCityDAL = new tbl_StateCityDAL();
                return Objtbl_StateCityDAL.Search_Data(Objtbl_StateCityProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SelectCombo_Data(tbl_StateCityProp Objtbl_StateCityProp)
        {
            try
            {
                tbl_StateCityDAL Objtbl_StateCityDAL = new tbl_StateCityDAL();
                return Objtbl_StateCityDAL.SelectCombo_Data(Objtbl_StateCityProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
