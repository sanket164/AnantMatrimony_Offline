using AnantMatrimony.AnantProp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnantMatrimony
{
    class tbl_FollowUpBAL
    {
        public int InsertUpdate_Data(tbl_FollowUp Objtbl_tbl_FollowUpProp)
        {
            try
            {
                tbl_FollowUpDAL Objtbl_FollowUpDAL = new tbl_FollowUpDAL();
                return Objtbl_FollowUpDAL.InsertUpdate_Data(Objtbl_tbl_FollowUpProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete_Data(tbl_FollowUp Objtbl_tbl_FollowUpProp)
        {
            try
            {
                tbl_FollowUpDAL Objtbl_FollowUpDAL = new tbl_FollowUpDAL();
                return Objtbl_FollowUpDAL.Delete_Data(Objtbl_tbl_FollowUpProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Data(tbl_FollowUp Objtbl_tbl_FollowUpProp)
        {
            try
            {
                tbl_FollowUpDAL Objtbl_FollowUpDAL = new tbl_FollowUpDAL();
                DataSet dsData = Objtbl_FollowUpDAL.Select_Data(Objtbl_tbl_FollowUpProp);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
