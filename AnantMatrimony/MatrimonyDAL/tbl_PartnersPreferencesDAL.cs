using AnantMatrimony.AnantProp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnantMatrimony.MatrimonyDAL
{
    class tbl_PartnersPreferencesDAL
    {
        dbInteraction objdb = new dbInteraction();

        public int InsertUpdate_Data(tbl_PartnersPreferencesProp Objtbl_PartnersPreferencesProp)
        {
            int _RetVal = 0;
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "InsertUpdate_tbl_PartnersPreferences";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;

            try
            {
                objdb.GetConnStr();
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("InsertUpdate_tbl_PartnersPreferences");
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_PartnersPreferencesProp.MemberCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@AgeFrom", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_PartnersPreferencesProp.AgeFrom));
                cmdToExecute.Parameters.Add(new SqlParameter("@AgeTo", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_PartnersPreferencesProp.AgeTo));
                cmdToExecute.Parameters.Add(new SqlParameter("@HeightFrom", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_PartnersPreferencesProp.HeightFrom));
                cmdToExecute.Parameters.Add(new SqlParameter("@HeightTo", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_PartnersPreferencesProp.HeightTo));
                cmdToExecute.Parameters.Add(new SqlParameter("@MaritalStatus", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_PartnersPreferencesProp.MaritalStatus));
                cmdToExecute.Parameters.Add(new SqlParameter("@HaveChildren", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_PartnersPreferencesProp.HaveChildren));
                cmdToExecute.Parameters.Add(new SqlParameter("@Religion", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_PartnersPreferencesProp.Religion));
                cmdToExecute.Parameters.Add(new SqlParameter("@MotherTongue", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_PartnersPreferencesProp.MotherTongue));
                cmdToExecute.Parameters.Add(new SqlParameter("@Caste", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_PartnersPreferencesProp.Caste));
                cmdToExecute.Parameters.Add(new SqlParameter("@SubCaste", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_PartnersPreferencesProp.SubCaste));
                cmdToExecute.Parameters.Add(new SqlParameter("@Manglik", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_PartnersPreferencesProp.Manglik));
                cmdToExecute.Parameters.Add(new SqlParameter("@CountryLivingIn", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_PartnersPreferencesProp.CountryLivingIn));
                cmdToExecute.Parameters.Add(new SqlParameter("@StateCity", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_PartnersPreferencesProp.StateCity));
                cmdToExecute.Parameters.Add(new SqlParameter("@ResidencyStatus", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_PartnersPreferencesProp.ResidencyStatus));

                cmdToExecute.Parameters.Add(new SqlParameter("@Education", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_PartnersPreferencesProp.Education));
                cmdToExecute.Parameters.Add(new SqlParameter("@Occupation", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_PartnersPreferencesProp.Occupation));
                cmdToExecute.Parameters.Add(new SqlParameter("@WorkingWith", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_PartnersPreferencesProp.WorkingWith));
                cmdToExecute.Parameters.Add(new SqlParameter("@AnnualIncomeCurrency", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_PartnersPreferencesProp.AnnualIncomeCurrency));
                cmdToExecute.Parameters.Add(new SqlParameter("@AnnualIncome", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_PartnersPreferencesProp.AnnualIncome));
                cmdToExecute.Parameters.Add(new SqlParameter("@Diet", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_PartnersPreferencesProp.Diet));
                cmdToExecute.Parameters.Add(new SqlParameter("@Smoke", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_PartnersPreferencesProp.Smoke));
                cmdToExecute.Parameters.Add(new SqlParameter("@Drink", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_PartnersPreferencesProp.Drink));
                cmdToExecute.Parameters.Add(new SqlParameter("@BodyType", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_PartnersPreferencesProp.BodyType));
                cmdToExecute.Parameters.Add(new SqlParameter("@Complexion", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_PartnersPreferencesProp.Complexion));
                cmdToExecute.Parameters.Add(new SqlParameter("@HealthProblem", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_PartnersPreferencesProp.HealthProblem));
                cmdToExecute.Parameters.Add(new SqlParameter("@AboutPartner", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_PartnersPreferencesProp.AboutPartner));
                cmdToExecute.Parameters.Add(new SqlParameter("@RetVal", SqlDbType.Int, 20, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, 18));
                cmdToExecute.ExecuteNonQuery();
                return Convert.ToInt32(cmdToExecute.Parameters["@RetVal"].Value);
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
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Delete_tbl_PartnersPreferences");
                //return DB.ExecuteNonQuery(DBCmd);
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_PartnersPreferencesProp Objtbl_PartnersPreferencesProp)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "Select_tbl_PartnersPreferences";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = null;
            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;
            int _TotalCount = 0;

            try
            {
                objdb.GetConnStr();
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Select_tbl_PartnersPreferences");

                cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_PartnersPreferencesProp.MemberCode));
                da = new SqlDataAdapter(cmdToExecute);
                da.Fill(ds);

                //TotalCount = Convert.ToInt32(cmdToExecute.Parameters["@TotalCount"].Value);
                return ds;
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
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Search_tbl_PartnersPreferences");
                //DB.AddInParameter(DBCmd, "@SearchBy", DbType.String, Objtbl_PartnersPreferencesProp.SearchBy);
                //DB.AddInParameter(DBCmd, "@SearchVal", DbType.String, Objtbl_PartnersPreferencesProp.SearchVal);
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
                //DbCommand DBCmd = DB.GetStoredProcCommand("SelectCombo_tbl_PartnersPreferences");
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
