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
    public class tbl_WorkingWithBAL
    {
        public int InsertUpdate_Data(tbl_WorkingWithProp Objtbl_WorkingWithProp)
        {
            try
            {
                tbl_WorkingWithDAL Objtbl_WorkingWithDAL = new tbl_WorkingWithDAL();
                return Objtbl_WorkingWithDAL.InsertUpdate_Data(Objtbl_WorkingWithProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete_Data(tbl_WorkingWithProp Objtbl_WorkingWithProp)
        {
            try
            {
                tbl_WorkingWithDAL Objtbl_WorkingWithDAL = new tbl_WorkingWithDAL();
                return Objtbl_WorkingWithDAL.Delete_Data(Objtbl_WorkingWithProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Data(tbl_WorkingWithProp Objtbl_WorkingWithProp, ref int PageCount, int WorkingWithCode)
        {
            try
            {
                if (Objtbl_WorkingWithProp.WorkingWithCode != 0)
                {
                    Objtbl_WorkingWithProp.PageNo = 1;
                    Objtbl_WorkingWithProp.RecordCount = 1;
                }
                int RecordCount = 0;
                tbl_WorkingWithDAL Objtbl_WorkingWithDAL = new tbl_WorkingWithDAL();
                DataSet dsData = Objtbl_WorkingWithDAL.Select_Data(Objtbl_WorkingWithProp, ref RecordCount, WorkingWithCode);
                Objtbl_WorkingWithProp.RecordCount = dsData.Tables[0].Rows.Count;
                double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_WorkingWithProp.RecordCount);
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

        public DataSet Search_Data(tbl_WorkingWithProp Objtbl_WorkingWithProp)
        {
            try
            {
                tbl_WorkingWithDAL Objtbl_WorkingWithDAL = new tbl_WorkingWithDAL();
                return Objtbl_WorkingWithDAL.Search_Data(Objtbl_WorkingWithProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SelectCombo_Data(tbl_WorkingWithProp Objtbl_WorkingWithProp)
        {
            try
            {
                tbl_WorkingWithDAL Objtbl_WorkingWithDAL = new tbl_WorkingWithDAL();
                return Objtbl_WorkingWithDAL.SelectCombo_Data(Objtbl_WorkingWithProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
