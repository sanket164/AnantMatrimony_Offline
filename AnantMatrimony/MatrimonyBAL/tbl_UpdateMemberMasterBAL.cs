using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnantMatrimony
{
    class tbl_UpdateMemberMasterBAL
    {
        public int InsertUpdate_Data(tbl_UpdateMemberMasterProp Objtbl_UpdateMemberMasterProp)
        {
            try
            {
                tbl_UpdateMemberMasterDAL Objtbl_UpdateMemberMasterDAL = new tbl_UpdateMemberMasterDAL();
                return Objtbl_UpdateMemberMasterDAL.InsertUpdate_Data(Objtbl_UpdateMemberMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete_Data(tbl_UpdateMemberMasterProp Objtbl_UpdateMemberMasterProp)
        {
            try
            {
                tbl_UpdateMemberMasterDAL Objtbl_UpdateMemberMasterDAL = new tbl_UpdateMemberMasterDAL();
                return Objtbl_UpdateMemberMasterDAL.Delete_Data(Objtbl_UpdateMemberMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Data(tbl_UpdateMemberMasterProp Objtbl_UpdateMemberMasterProp, ref int PageCount)
        {
            try
            {
                if (Objtbl_UpdateMemberMasterProp.MemberCode != 0)
                {
                    Objtbl_UpdateMemberMasterProp.PageNo = 1;
                    Objtbl_UpdateMemberMasterProp.RecordCount = 1;
                }
                int RecordCount = 0;
                tbl_UpdateMemberMasterDAL Objtbl_UpdateMemberMasterDAL = new tbl_UpdateMemberMasterDAL();
                DataSet dsData = Objtbl_UpdateMemberMasterDAL.Select_Data(Objtbl_UpdateMemberMasterProp, ref RecordCount);
                double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_UpdateMemberMasterProp.RecordCount);
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

        public DataSet Search_Data(tbl_UpdateMemberMasterProp Objtbl_UpdateMemberMasterProp)
        {
            try
            {
                tbl_UpdateMemberMasterDAL Objtbl_UpdateMemberMasterDAL = new tbl_UpdateMemberMasterDAL();
                return Objtbl_UpdateMemberMasterDAL.Search_Data(Objtbl_UpdateMemberMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
