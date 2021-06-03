using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnantMatrimony
{
    class tbl_UpdatePartnersPreferencesBAL
    {
        public int InsertUpdate_Data(tbl_UpdatePartnersPreferencesProp Objtbl_UpdatePartnersPreferencesProp)
        {
            try
            {
                tbl_UpdatePartnersPreferencesDAL Objtbl_UpdatePartnersPreferencesDAL = new tbl_UpdatePartnersPreferencesDAL();
                return Objtbl_UpdatePartnersPreferencesDAL.InsertUpdate_Data(Objtbl_UpdatePartnersPreferencesProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete_Data(tbl_UpdatePartnersPreferencesProp Objtbl_UpdatePartnersPreferencesProp)
        {
            try
            {
                tbl_UpdatePartnersPreferencesDAL Objtbl_UpdatePartnersPreferencesDAL = new tbl_UpdatePartnersPreferencesDAL();
                return Objtbl_UpdatePartnersPreferencesDAL.Delete_Data(Objtbl_UpdatePartnersPreferencesProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_UpdatePartnersPreferencesProp Objtbl_UpdatePartnersPreferencesProp)
        {
            try
            {
                tbl_UpdatePartnersPreferencesDAL Objtbl_UpdatePartnersPreferencesDAL = new tbl_UpdatePartnersPreferencesDAL();
                DataSet dsData = Objtbl_UpdatePartnersPreferencesDAL.Select_Data(Objtbl_UpdatePartnersPreferencesProp);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Search_Data(tbl_UpdatePartnersPreferencesProp Objtbl_UpdatePartnersPreferencesProp)
        {
            try
            {
                tbl_UpdatePartnersPreferencesDAL Objtbl_UpdatePartnersPreferencesDAL = new tbl_UpdatePartnersPreferencesDAL();
                return Objtbl_UpdatePartnersPreferencesDAL.Search_Data(Objtbl_UpdatePartnersPreferencesProp);
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
                tbl_UpdatePartnersPreferencesDAL Objtbl_UpdatePartnersPreferencesDAL = new tbl_UpdatePartnersPreferencesDAL();
                return Objtbl_UpdatePartnersPreferencesDAL.SelectCombo_Data();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
