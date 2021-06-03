using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnantMatrimony
{
    class tbl_SibblingDetailsBAL
    {
        public int InsertUpdate_Data(tbl_SibblingDetailsProp Objtbl_SibblingDetailsProp)
        {
            try
            {
                tbl_SibblingDetailsDAL Objtbl_SibblingDetailsDAL = new tbl_SibblingDetailsDAL();
                return Objtbl_SibblingDetailsDAL.InsertUpdate_Data(Objtbl_SibblingDetailsProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       

        public int Delete_Data(tbl_SibblingDetailsProp Objtbl_SibblingDetailsProp)
        {
            try
            {
                tbl_SibblingDetailsDAL Objtbl_SibblingDetailsDAL = new tbl_SibblingDetailsDAL();
                return Objtbl_SibblingDetailsDAL.Delete_Data(Objtbl_SibblingDetailsProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Data(tbl_SibblingDetailsProp Objtbl_SibblingDetailsProp)
        {
            try
            {
                tbl_SibblingDetailsDAL Objtbl_SibblingDetailsDAL = new tbl_SibblingDetailsDAL();
                DataSet dsData = Objtbl_SibblingDetailsDAL.Select_Data(Objtbl_SibblingDetailsProp);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Search_Data(tbl_SibblingDetailsProp Objtbl_SibblingDetailsProp)
        {
            try
            {
                tbl_SibblingDetailsDAL Objtbl_SibblingDetailsDAL = new tbl_SibblingDetailsDAL();
                return Objtbl_SibblingDetailsDAL.Search_Data(Objtbl_SibblingDetailsProp);
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
                tbl_SibblingDetailsDAL Objtbl_SibblingDetailsDAL = new tbl_SibblingDetailsDAL();
                return Objtbl_SibblingDetailsDAL.SelectCombo_Data();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
