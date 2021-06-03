using AnantMatrimony.AnantProp;
using AnantMatrimony.MatrimonyDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnantMatrimony.MatrimonyBAL
{
    class tbl_MembershipMasterBAL
    {
        public int InsertUpdate_Data(tbl_MembershipMasterProp Objtbl_MembershipMasterProp)
        {
            try
            {
                tbl_MembershipMasterDAL Objtbl_MembershipMasterDAL = new tbl_MembershipMasterDAL();
                return Objtbl_MembershipMasterDAL.InsertUpdate_Data(Objtbl_MembershipMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete_Data(tbl_MembershipMasterProp Objtbl_MembershipMasterProp)
        {
            try
            {
                tbl_MembershipMasterDAL Objtbl_MembershipMasterDAL = new tbl_MembershipMasterDAL();
                return Objtbl_MembershipMasterDAL.Delete_Data(Objtbl_MembershipMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_MembershipMasterProp Objtbl_MembershipMasterProp)
        {
            try
            {
                tbl_MembershipMasterDAL Objtbl_MembershipMasterDAL = new tbl_MembershipMasterDAL();
                DataSet dsData = Objtbl_MembershipMasterDAL.Select_Data(Objtbl_MembershipMasterProp);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Search_Data(tbl_MembershipMasterProp Objtbl_MembershipMasterProp)
        {
            try
            {
                tbl_MembershipMasterDAL Objtbl_MembershipMasterDAL = new tbl_MembershipMasterDAL();
                return Objtbl_MembershipMasterDAL.Search_Data(Objtbl_MembershipMasterProp);
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
                tbl_MembershipMasterDAL Objtbl_MembershipMasterDAL = new tbl_MembershipMasterDAL();
                return Objtbl_MembershipMasterDAL.SelectCombo_Data();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
