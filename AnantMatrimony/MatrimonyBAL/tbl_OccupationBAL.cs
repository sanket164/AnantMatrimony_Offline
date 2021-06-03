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
    public class tbl_OccupationBAL
    {
        public int InsertUpdate_Data(tbl_OccupationProp Objtbl_OccupationProp)
        {
            try
            {
                tbl_OccupationDAL Objtbl_OccupationDAL = new tbl_OccupationDAL();
                return Objtbl_OccupationDAL.InsertUpdate_Data(Objtbl_OccupationProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete_Data(tbl_OccupationProp Objtbl_OccupationProp)
        {
            try
            {
                tbl_OccupationDAL Objtbl_OccupationDAL = new tbl_OccupationDAL();
                return Objtbl_OccupationDAL.Delete_Data(Objtbl_OccupationProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_OccupationProp Objtbl_OccupationProp, ref int PageCount, int OccupationCode)
        {
            try
            {
                if (Objtbl_OccupationProp.OccupationCode != 0)
                {
                    Objtbl_OccupationProp.PageNo = 1;
                    Objtbl_OccupationProp.RecordCount = 1;
                }
                int RecordCount = 0;
                tbl_OccupationDAL Objtbl_OccupationDAL = new tbl_OccupationDAL();
                DataSet dsData = Objtbl_OccupationDAL.Select_Data(Objtbl_OccupationProp, ref RecordCount, OccupationCode);
                Objtbl_OccupationProp.RecordCount = dsData.Tables[0].Rows.Count;
                double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_OccupationProp.RecordCount);
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
        public DataSet Search_Data(tbl_OccupationProp Objtbl_OccupationProp)
        {
            try
            {
                tbl_OccupationDAL Objtbl_OccupationDAL = new tbl_OccupationDAL();
                return Objtbl_OccupationDAL.Search_Data(Objtbl_OccupationProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SelectCombo_Data(tbl_OccupationProp Objtbl_OccupationProp)
        {
            try
            {
                tbl_OccupationDAL Objtbl_OccupationDAL = new tbl_OccupationDAL();
                return Objtbl_OccupationDAL.SelectCombo_Data(Objtbl_OccupationProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
