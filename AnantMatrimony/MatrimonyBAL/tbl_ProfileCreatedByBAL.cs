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
    public class tbl_ProfileCreatedByBAL
    {
        public int InsertUpdate_Data(tbl_ProfileCreatedByProp Objtbl_ProfileCreatedByProp)
        {
            try
            {
                tbl_ProfileCreatedByDAL Objtbl_ProfileCreatedByDAL = new tbl_ProfileCreatedByDAL();
                return Objtbl_ProfileCreatedByDAL.InsertUpdate_Data(Objtbl_ProfileCreatedByProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete_Data(tbl_ProfileCreatedByProp Objtbl_ProfileCreatedByProp)
        {
            try
            {
                tbl_ProfileCreatedByDAL Objtbl_ProfileCreatedByDAL = new tbl_ProfileCreatedByDAL();
                return Objtbl_ProfileCreatedByDAL.Delete_Data(Objtbl_ProfileCreatedByProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_ProfileCreatedByProp Objtbl_ProfileCreatedByProp, ref int PageCount, int ProfileCreatedByCode)
        {
            try
            {
                if (Objtbl_ProfileCreatedByProp.ProfileCreatedByCode != 0)
                {
                    Objtbl_ProfileCreatedByProp.PageNo = 1;
                    Objtbl_ProfileCreatedByProp.RecordCount = 1;
                }
                int RecordCount = 1;
                tbl_ProfileCreatedByDAL Objtbl_ProfileCreatedByDAL = new tbl_ProfileCreatedByDAL();
                DataSet dsData = Objtbl_ProfileCreatedByDAL.Select_Data(Objtbl_ProfileCreatedByProp, ref RecordCount, ProfileCreatedByCode);
                Objtbl_ProfileCreatedByProp.RecordCount = dsData.Tables[0].Rows.Count;
                double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_ProfileCreatedByProp.RecordCount);
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
        public DataSet Search_Data(tbl_ProfileCreatedByProp Objtbl_ProfileCreatedByProp)
        {
            try
            {
                tbl_ProfileCreatedByDAL Objtbl_ProfileCreatedByDAL = new tbl_ProfileCreatedByDAL();
                return Objtbl_ProfileCreatedByDAL.Search_Data(Objtbl_ProfileCreatedByProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SelectCombo_Data(tbl_ProfileCreatedByProp Objtbl_ProfileCreatedByProp)
        {
            try
            {
                tbl_ProfileCreatedByDAL Objtbl_ProfileCreatedByDAL = new tbl_ProfileCreatedByDAL();
                return Objtbl_ProfileCreatedByDAL.SelectCombo_Data(Objtbl_ProfileCreatedByProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
