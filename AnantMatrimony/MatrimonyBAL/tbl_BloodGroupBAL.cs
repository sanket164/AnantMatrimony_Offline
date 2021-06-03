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
    public class tbl_BloodGroupBAL
    {
        public int InsertUpdate_Data(tbl_BloodGroupProp Objtbl_BloodGroupProp)
        {
            try
            {
                tbl_BloodGroupDAL Objtbl_BloodGroupDAL = new tbl_BloodGroupDAL();
                return Objtbl_BloodGroupDAL.InsertUpdate_Data(Objtbl_BloodGroupProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete_Data(tbl_BloodGroupProp Objtbl_BloodGroupProp)
        {
            try
            {
                tbl_BloodGroupDAL Objtbl_BloodGroupDAL = new tbl_BloodGroupDAL();
                return Objtbl_BloodGroupDAL.Delete_Data(Objtbl_BloodGroupProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_BloodGroupProp Objtbl_BloodGroupProp, ref int PageCount, int BloodGroupCode)
        {
            try
            {
                if (Objtbl_BloodGroupProp.BloodGroupCode != 0)
                {
                    Objtbl_BloodGroupProp.PageNo = 1;
                    Objtbl_BloodGroupProp.RecordCount = 1;
                }
                int RecordCount = 0;
                tbl_BloodGroupDAL Objtbl_BloodGroupDAL = new tbl_BloodGroupDAL();
                DataSet dsData = Objtbl_BloodGroupDAL.Select_Data(Objtbl_BloodGroupProp, ref RecordCount, BloodGroupCode);
                Objtbl_BloodGroupProp.RecordCount = dsData.Tables[0].Rows.Count;
                double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_BloodGroupProp.RecordCount);
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
        public DataSet Search_Data(tbl_BloodGroupProp Objtbl_BloodGroupProp)
        {
            try
            {
                tbl_BloodGroupDAL Objtbl_BloodGroupDAL = new tbl_BloodGroupDAL();
                return Objtbl_BloodGroupDAL.Search_Data(Objtbl_BloodGroupProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SelectCombo_Data(tbl_BloodGroupProp Objtbl_BloodGroupProp)
        {
            try
            {
                tbl_BloodGroupDAL Objtbl_BloodGroupDAL = new tbl_BloodGroupDAL();
                return Objtbl_BloodGroupDAL.SelectCombo_Data(Objtbl_BloodGroupProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
