using AnantMatrimony.MatrimonyDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnantMatrimony
{
    class tbl_CasteBAL
    {
        public int InsertUpdate_Data(tbl_CasteProp Objtbl_CasteProp)
        {
            try
            {
                tbl_CasteDAL Objtbl_CasteDAL = new tbl_CasteDAL();
                return Objtbl_CasteDAL.InsertUpdate_Data(Objtbl_CasteProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete_Data(tbl_CasteProp Objtbl_CasteProp)
        {
            try
            {
                tbl_CasteDAL Objtbl_CasteDAL = new tbl_CasteDAL();
                return Objtbl_CasteDAL.Delete_Data(Objtbl_CasteProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_CasteProp Objtbl_CasteProp, int CasteCode, ref int PageCount)
        {
            try
            {
                if (Objtbl_CasteProp.CasteCode != 0)
                {
                    Objtbl_CasteProp.PageNo = 1;
                    Objtbl_CasteProp.RecordCount = 1;
                }
                int RecordCount = 0;
                tbl_CasteDAL Objtbl_CasteDAL = new tbl_CasteDAL();
                DataSet dsData = Objtbl_CasteDAL.Select_Data(Objtbl_CasteProp, ref RecordCount, CasteCode);
                Objtbl_CasteProp.RecordCount = dsData.Tables[0].Rows.Count;
                double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_CasteProp.RecordCount);
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
        public DataSet Search_Data(tbl_CasteProp Objtbl_CasteProp)
        {
            try
            {
                tbl_CasteDAL Objtbl_CasteDAL = new tbl_CasteDAL();
                return Objtbl_CasteDAL.Search_Data(Objtbl_CasteProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SelectCombo_Data(tbl_CasteProp Objtbl_CasteProp)
        {
            try
            {
                tbl_CasteDAL Objtbl_CasteDAL = new tbl_CasteDAL();
                return Objtbl_CasteDAL.SelectCombo_Data(Objtbl_CasteProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
