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
    public class tbl_SubCasteBAL
    {
        public int InsertUpdate_Data(tbl_SubCasteProp Objtbl_SubCasteProp)
        {
            try
            {
                tbl_SubCasteDAL Objtbl_SubCasteDAL = new tbl_SubCasteDAL();
                return Objtbl_SubCasteDAL.InsertUpdate_Data(Objtbl_SubCasteProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete_Data(tbl_SubCasteProp Objtbl_SubCasteProp)
        {
            try
            {
                tbl_SubCasteDAL Objtbl_SubCasteDAL = new tbl_SubCasteDAL();
                return Objtbl_SubCasteDAL.Delete_Data(Objtbl_SubCasteProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Data(tbl_SubCasteProp Objtbl_SubCasteProp, ref int PageCount, int SubCasteCode)
        {
            try
            {
                if (Objtbl_SubCasteProp.SubCasteCode != 0)
                {
                    Objtbl_SubCasteProp.PageNo = 1;
                    Objtbl_SubCasteProp.RecordCount = 1;
                }
                int RecordCount = 0;
                tbl_SubCasteDAL Objtbl_SubCasteDAL = new tbl_SubCasteDAL();
                DataSet dsData = Objtbl_SubCasteDAL.Select_Data(Objtbl_SubCasteProp, ref RecordCount, SubCasteCode);
                Objtbl_SubCasteProp.RecordCount = dsData.Tables[0].Rows.Count;
                double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_SubCasteProp.RecordCount);
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

        public DataSet Search_Data(tbl_SubCasteProp Objtbl_SubCasteProp)
        {
            try
            {
                tbl_SubCasteDAL Objtbl_SubCasteDAL = new tbl_SubCasteDAL();
                return Objtbl_SubCasteDAL.Search_Data(Objtbl_SubCasteProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SelectCombo_Data(tbl_SubCasteProp Objtbl_SubCasteProp)
        {
            try
            {
                tbl_SubCasteDAL Objtbl_SubCasteDAL = new tbl_SubCasteDAL();
                return Objtbl_SubCasteDAL.SelectCombo_Data(Objtbl_SubCasteProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
