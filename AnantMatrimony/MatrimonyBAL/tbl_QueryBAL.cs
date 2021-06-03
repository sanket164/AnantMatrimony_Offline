using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnantMatrimony
{
    class tbl_QueryBAL
    {
        public int InsertUpdate_Data(tbl_QueryProp Objtbl_QueryProp)
        {
            try
            {
                tbl_QueryDAL Objtbl_QueryDAL = new tbl_QueryDAL();
                return Objtbl_QueryDAL.InsertUpdate_Data(Objtbl_QueryProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete_Data(tbl_QueryProp Objtbl_QueryProp)
        {
            try
            {
                tbl_QueryDAL Objtbl_QueryDAL = new tbl_QueryDAL();
                return Objtbl_QueryDAL.Delete_Data(Objtbl_QueryProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_QueryProp Objtbl_QueryProp, ref int PageCount)
        {
            try
            {
                if (Objtbl_QueryProp.MessageCode != 0)
                {
                    Objtbl_QueryProp.PageNo = 1;
                    Objtbl_QueryProp.RecordCount = 1;
                }
                int RecordCount = 0;
                tbl_QueryDAL Objtbl_QueryDAL = new tbl_QueryDAL();
                DataSet dsData = Objtbl_QueryDAL.Select_Data(Objtbl_QueryProp, ref RecordCount);
                double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_QueryProp.RecordCount);
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    string[] PageDecimal = Page.ToString().Split('.');
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
        public DataSet Search_Data(tbl_QueryProp Objtbl_QueryProp)
        {
            try
            {
                tbl_QueryDAL Objtbl_QueryDAL = new tbl_QueryDAL();
                return Objtbl_QueryDAL.Search_Data(Objtbl_QueryProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet CountUnreadMessage(tbl_QueryProp Objtbl_QueryProp)
        {
            try
            {
                tbl_QueryDAL Objtbl_QueryDAL = new tbl_QueryDAL();
                return Objtbl_QueryDAL.CountUnreadMessage(Objtbl_QueryProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SelectCombo_Data()
        {
            try
            {
                tbl_QueryDAL Objtbl_QueryDAL = new tbl_QueryDAL();
                return Objtbl_QueryDAL.SelectCombo_Data();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
