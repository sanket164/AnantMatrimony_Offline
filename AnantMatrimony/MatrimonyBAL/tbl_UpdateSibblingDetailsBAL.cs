using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnantMatrimony
{
    class tbl_UpdateSibblingDetailsBAL
    {
        public int InsertUpdate_Data(tbl_UpdateSibblingDetailsProp Objtbl_UpdateSibblingDetailsProp)
        {
            try
            {
                tbl_UpdateSibblingDetailsDAL Objtbl_UpdateSibblingDetailsDAL = new tbl_UpdateSibblingDetailsDAL();
                return Objtbl_UpdateSibblingDetailsDAL.InsertUpdate_Data(Objtbl_UpdateSibblingDetailsProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete_Data(tbl_UpdateSibblingDetailsProp Objtbl_UpdateSibblingDetailsProp)
        {
            try
            {
                tbl_UpdateSibblingDetailsDAL Objtbl_UpdateSibblingDetailsDAL = new tbl_UpdateSibblingDetailsDAL();
                return Objtbl_UpdateSibblingDetailsDAL.Delete_Data(Objtbl_UpdateSibblingDetailsProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Data(tbl_UpdateSibblingDetailsProp Objtbl_UpdateSibblingDetailsProp)
        {
            try
            {
                tbl_UpdateSibblingDetailsDAL Objtbl_UpdateSibblingDetailsDAL = new tbl_UpdateSibblingDetailsDAL();
                DataSet dsData = Objtbl_UpdateSibblingDetailsDAL.Select_Data(Objtbl_UpdateSibblingDetailsProp);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Search_Data(tbl_UpdateSibblingDetailsProp Objtbl_UpdateSibblingDetailsProp)
        {
            try
            {
                tbl_UpdateSibblingDetailsDAL Objtbl_UpdateSibblingDetailsDAL = new tbl_UpdateSibblingDetailsDAL();
                return Objtbl_UpdateSibblingDetailsDAL.Search_Data(Objtbl_UpdateSibblingDetailsProp);
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
                tbl_UpdateSibblingDetailsDAL Objtbl_UpdateSibblingDetailsDAL = new tbl_UpdateSibblingDetailsDAL();
                return Objtbl_UpdateSibblingDetailsDAL.SelectCombo_Data();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
