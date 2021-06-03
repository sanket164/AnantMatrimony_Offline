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
    class tbl_PartnersPreferencesBAL
    {
        public int InsertUpdate_Data(tbl_PartnersPreferencesProp Objtbl_PartnersPreferencesProp)
        {
            try
            {
                tbl_PartnersPreferencesDAL Objtbl_PartnersPreferencesDAL = new tbl_PartnersPreferencesDAL();
                return Objtbl_PartnersPreferencesDAL.InsertUpdate_Data(Objtbl_PartnersPreferencesProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete_Data(tbl_PartnersPreferencesProp Objtbl_PartnersPreferencesProp)
        {
            try
            {
                tbl_PartnersPreferencesDAL Objtbl_PartnersPreferencesDAL = new tbl_PartnersPreferencesDAL();
                return Objtbl_PartnersPreferencesDAL.Delete_Data(Objtbl_PartnersPreferencesProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_PartnersPreferencesProp Objtbl_PartnersPreferencesProp)
        {
            try
            {
                tbl_PartnersPreferencesDAL Objtbl_PartnersPreferencesDAL = new tbl_PartnersPreferencesDAL();
                DataSet dsData = Objtbl_PartnersPreferencesDAL.Select_Data(Objtbl_PartnersPreferencesProp);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Search_Data(tbl_PartnersPreferencesProp Objtbl_PartnersPreferencesProp)
        {
            try
            {
                tbl_PartnersPreferencesDAL Objtbl_PartnersPreferencesDAL = new tbl_PartnersPreferencesDAL();
                return Objtbl_PartnersPreferencesDAL.Search_Data(Objtbl_PartnersPreferencesProp);
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
                tbl_PartnersPreferencesDAL Objtbl_PartnersPreferencesDAL = new tbl_PartnersPreferencesDAL();
                return Objtbl_PartnersPreferencesDAL.SelectCombo_Data();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
