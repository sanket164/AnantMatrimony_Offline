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
    public class tbl_WorkingAsBAL
    {
        public int InsertUpdate_Data(tbl_WorkingAsProp Objtbl_WorkingAsProp)
        {
            try
            {
                tbl_WorkingAsDAL Objtbl_WorkingAsDAL = new tbl_WorkingAsDAL();
                return Objtbl_WorkingAsDAL.InsertUpdate_Data(Objtbl_WorkingAsProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete_Data(tbl_WorkingAsProp Objtbl_WorkingAsProp)
        {
            try
            {
                tbl_WorkingAsDAL Objtbl_WorkingAsDAL = new tbl_WorkingAsDAL();
                return Objtbl_WorkingAsDAL.Delete_Data(Objtbl_WorkingAsProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_WorkingAsProp Objtbl_WorkingAsProp, ref int PageCount, int WorkingAsCode)
        {
            try
            {
                if (Objtbl_WorkingAsProp.WorkingAsCode != 0)
                {
                    Objtbl_WorkingAsProp.PageNo = 1;
                    Objtbl_WorkingAsProp.RecordCount = 1;
                }
                int RecordCount = 0;
                tbl_WorkingAsDAL Objtbl_WorkingAsDAL = new tbl_WorkingAsDAL();
                DataSet dsData = Objtbl_WorkingAsDAL.Select_Data(Objtbl_WorkingAsProp, ref RecordCount, WorkingAsCode);
                Objtbl_WorkingAsProp.RecordCount = dsData.Tables[0].Rows.Count;
                double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_WorkingAsProp.RecordCount);
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
        public DataSet Search_Data(tbl_WorkingAsProp Objtbl_WorkingAsProp)
        {
            try
            {
                tbl_WorkingAsDAL Objtbl_WorkingAsDAL = new tbl_WorkingAsDAL();
                return Objtbl_WorkingAsDAL.Search_Data(Objtbl_WorkingAsProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SelectCombo_Data(tbl_WorkingAsProp Objtbl_WorkingAsProp)
        {
            try
            {
                tbl_WorkingAsDAL Objtbl_WorkingAsDAL = new tbl_WorkingAsDAL();
                return Objtbl_WorkingAsDAL.SelectCombo_Data(Objtbl_WorkingAsProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
