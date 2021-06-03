using AnantMatrimony.MatrimonyDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnantMatrimony
{
    class tbl_UpdatePartnersPreferencesDAL
    {
        dbInteraction objdb = new dbInteraction();

        public int InsertUpdate_Data(tbl_UpdatePartnersPreferencesProp Objtbl_UpdatePartnersPreferencesProp)
        {
            int _RetVal = 0;
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "InsertUpdate_tbl_UpdatePartnersPreferences";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;

            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("InsertUpdate_tbl_UpdatePartnersPreferences");
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdatePartnersPreferencesProp.MemberCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@AgeFrom", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdatePartnersPreferencesProp.AgeFrom));
                cmdToExecute.Parameters.Add(new SqlParameter("@AgeTo", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdatePartnersPreferencesProp.AgeTo));
                cmdToExecute.Parameters.Add(new SqlParameter("@HeightFrom", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdatePartnersPreferencesProp.HeightFrom));
                cmdToExecute.Parameters.Add(new SqlParameter("@HeightTo", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdatePartnersPreferencesProp.HeightTo));
                cmdToExecute.Parameters.Add(new SqlParameter("@MaritalStatus", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdatePartnersPreferencesProp.MaritalStatus));
                cmdToExecute.Parameters.Add(new SqlParameter("@HaveChildren", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdatePartnersPreferencesProp.HaveChildren));
                cmdToExecute.Parameters.Add(new SqlParameter("@Religion", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdatePartnersPreferencesProp.Religion));
                cmdToExecute.Parameters.Add(new SqlParameter("@MotherTongue", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdatePartnersPreferencesProp.MotherTongue));
                cmdToExecute.Parameters.Add(new SqlParameter("@Caste", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdatePartnersPreferencesProp.Caste));
                cmdToExecute.Parameters.Add(new SqlParameter("@SubCaste", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdatePartnersPreferencesProp.SubCaste));
                cmdToExecute.Parameters.Add(new SqlParameter("@Manglik", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdatePartnersPreferencesProp.Manglik));
                cmdToExecute.Parameters.Add(new SqlParameter("@CountryLivingIn", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdatePartnersPreferencesProp.CountryLivingIn));
                cmdToExecute.Parameters.Add(new SqlParameter("@StateCity", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdatePartnersPreferencesProp.StateCity));
                cmdToExecute.Parameters.Add(new SqlParameter("@ResidencyStatus", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdatePartnersPreferencesProp.ResidencyStatus));

                cmdToExecute.Parameters.Add(new SqlParameter("@Education", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdatePartnersPreferencesProp.Education));
                cmdToExecute.Parameters.Add(new SqlParameter("@Occupation", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdatePartnersPreferencesProp.Occupation));
                cmdToExecute.Parameters.Add(new SqlParameter("@WorkingWith", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdatePartnersPreferencesProp.WorkingWith));
                cmdToExecute.Parameters.Add(new SqlParameter("@AnnualIncomeCurrency", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdatePartnersPreferencesProp.AnnualIncomeCurrency));
                cmdToExecute.Parameters.Add(new SqlParameter("@AnnualIncome", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdatePartnersPreferencesProp.AnnualIncome));
                cmdToExecute.Parameters.Add(new SqlParameter("@Diet", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdatePartnersPreferencesProp.Diet));
                cmdToExecute.Parameters.Add(new SqlParameter("@Smoke", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdatePartnersPreferencesProp.Smoke));
                cmdToExecute.Parameters.Add(new SqlParameter("@Drink", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdatePartnersPreferencesProp.Drink));
                cmdToExecute.Parameters.Add(new SqlParameter("@BodyType", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdatePartnersPreferencesProp.BodyType));
                cmdToExecute.Parameters.Add(new SqlParameter("@Complexion", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdatePartnersPreferencesProp.Complexion));
                cmdToExecute.Parameters.Add(new SqlParameter("@HealthProblem", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdatePartnersPreferencesProp.HealthProblem));
                cmdToExecute.Parameters.Add(new SqlParameter("@AboutPartner", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdatePartnersPreferencesProp.AboutPartner));
                return cmdToExecute.ExecuteNonQuery();
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
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Delete_tbl_UpdatePartnersPreferences");
                //return DB.ExecuteNonQuery(DBCmd);
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Data(tbl_UpdatePartnersPreferencesProp Objtbl_UpdatePartnersPreferencesProp)
        {
             SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "Select_tbl_UpdatePartnersPreferences";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = null;
            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;
            int _TotalCount = 0;

            try
            {
                objdb.GetConnStr();
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdatePartnersPreferencesProp.MemberCode));
                da = new SqlDataAdapter(cmdToExecute);
                da.Fill(ds);                
                return ds;
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
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Search_tbl_UpdatePartnersPreferences");
                //cmdToExecute.Parameters.Add(new SqlParameter("@SearchBy", SqlDbType.NVarChar, 100, Objtbl_UpdatePartnersPreferencesProp.SearchBy);
                //cmdToExecute.Parameters.Add(new SqlParameter("@SearchVal", SqlDbType.NVarChar, 100, Objtbl_UpdatePartnersPreferencesProp.SearchVal);
                //return DB.ExecuteDataSet(DBCmd);
                return null;
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
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("SelectCombo_tbl_UpdatePartnersPreferences");
                //return DB.ExecuteDataSet(DBCmd);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
