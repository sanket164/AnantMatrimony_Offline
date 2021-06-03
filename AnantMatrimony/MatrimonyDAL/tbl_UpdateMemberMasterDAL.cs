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
    class tbl_UpdateMemberMasterDAL
    {
        dbInteraction objdb = new dbInteraction();

        public int InsertUpdate_Data(tbl_UpdateMemberMasterProp Objtbl_UpdateMemberMasterProp)
        {
            int _RetVal = 0;
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "InsertUpdate_tbl_UpdateMemberMaster";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;

            try
            {
                objdb.GetConnStr();

                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("InsertUpdate_tbl_UpdateMemberMaster");
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.MemberCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@ProfileID", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.ProfileID));
                cmdToExecute.Parameters.Add(new SqlParameter("@ProfileCreatedBy", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.ProfileCreatedBy));
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.MemberName));
                cmdToExecute.Parameters.Add(new SqlParameter("@Gender", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.Gender));
                cmdToExecute.Parameters.Add(new SqlParameter("@DateofBirth", SqlDbType.DateTime, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.DateofBirth));
                cmdToExecute.Parameters.Add(new SqlParameter("@TimeofBirth", SqlDbType.DateTime, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.TimeofBirth));
                cmdToExecute.Parameters.Add(new SqlParameter("@BirthPlace", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.BirthPlace));
                cmdToExecute.Parameters.Add(new SqlParameter("@MaritalStatus", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.MaritalStatus));
                cmdToExecute.Parameters.Add(new SqlParameter("@NoOfChildren", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.NoOfChildren));
                cmdToExecute.Parameters.Add(new SqlParameter("@LiveChildrenTogether", SqlDbType.Int, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.LiveChildrenTogether));
                cmdToExecute.Parameters.Add(new SqlParameter("@Height", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.Height));
                cmdToExecute.Parameters.Add(new SqlParameter("@Weight", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.Weight));
                cmdToExecute.Parameters.Add(new SqlParameter("@BodyType", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.BodyType));
                cmdToExecute.Parameters.Add(new SqlParameter("@HealthInformation", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.HealthInformation));
                cmdToExecute.Parameters.Add(new SqlParameter("@Complexion", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.Complexion));
                cmdToExecute.Parameters.Add(new SqlParameter("@AnyDisability", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.AnyDisability));
                cmdToExecute.Parameters.Add(new SqlParameter("@BloodGroup", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.BloodGroup));
                cmdToExecute.Parameters.Add(new SqlParameter("@HomeAddress1", SqlDbType.NVarChar, 100, Objtbl_UpdateMemberMasterProp.HomeAddress1));
                cmdToExecute.Parameters.Add(new SqlParameter("@HomeAddress2", SqlDbType.NVarChar, 100, Objtbl_UpdateMemberMasterProp.HomeAddress2));
                cmdToExecute.Parameters.Add(new SqlParameter("@VisaStatus", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.VisaStatus));
                cmdToExecute.Parameters.Add(new SqlParameter("@Country", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.Country));
                cmdToExecute.Parameters.Add(new SqlParameter("@StateCity", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.StateCity));
                cmdToExecute.Parameters.Add(new SqlParameter("@MobileNo", SqlDbType.NVarChar, 100, Objtbl_UpdateMemberMasterProp.MobileNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@LandlineNo", SqlDbType.NVarChar, 100, Objtbl_UpdateMemberMasterProp.LandlineNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@MobileNo1", SqlDbType.NVarChar, 100, Objtbl_UpdateMemberMasterProp.MobileNo1));
                cmdToExecute.Parameters.Add(new SqlParameter("@LandlineNo1", SqlDbType.NVarChar, 100, Objtbl_UpdateMemberMasterProp.LandlineNo1));
                cmdToExecute.Parameters.Add(new SqlParameter("@SecondaryEmailID", SqlDbType.NVarChar, 100, Objtbl_UpdateMemberMasterProp.SecondaryEmailID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Religion", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.Religion));
                cmdToExecute.Parameters.Add(new SqlParameter("@MotherTongue", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.MotherTongue));
                cmdToExecute.Parameters.Add(new SqlParameter("@Caste", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.Caste));
                cmdToExecute.Parameters.Add(new SqlParameter("@SubCaste", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.SubCaste));
                cmdToExecute.Parameters.Add(new SqlParameter("@Gotra", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.Gotra));
                cmdToExecute.Parameters.Add(new SqlParameter("@FatherName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.FatherName));
                cmdToExecute.Parameters.Add(new SqlParameter("@FatherOccupation", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.FatherOccupation));
                cmdToExecute.Parameters.Add(new SqlParameter("@MotherName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.MotherName));
                cmdToExecute.Parameters.Add(new SqlParameter("@MotherOccupation", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.MotherOccupation));
                cmdToExecute.Parameters.Add(new SqlParameter("@MosalPlace", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.MosalPlace));
                cmdToExecute.Parameters.Add(new SqlParameter("@NativePlace", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.NativePlace));
                cmdToExecute.Parameters.Add(new SqlParameter("@FamilyType", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.FamilyType));
                cmdToExecute.Parameters.Add(new SqlParameter("@FamilyValues", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.FamilyValues));
                cmdToExecute.Parameters.Add(new SqlParameter("@Manglik", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.Manglik));
                cmdToExecute.Parameters.Add(new SqlParameter("@Nakshtra", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.Nakshtra));
                cmdToExecute.Parameters.Add(new SqlParameter("@Rashi", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.Rashi));
                cmdToExecute.Parameters.Add(new SqlParameter("@Education", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.Education));
                cmdToExecute.Parameters.Add(new SqlParameter("@Occupation", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.Occupation));
                cmdToExecute.Parameters.Add(new SqlParameter("@WorkingAs", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.WorkingAs));
                cmdToExecute.Parameters.Add(new SqlParameter("@WorkingWith", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.WorkingWith));
                cmdToExecute.Parameters.Add(new SqlParameter("@WorkAddress", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.WorkAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@AnnualIncomeCurrency", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.AnnualIncomeCurrency));
                cmdToExecute.Parameters.Add(new SqlParameter("@AnnualIncome", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.AnnualIncome));
                cmdToExecute.Parameters.Add(new SqlParameter("@Diet", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.Diet));
                cmdToExecute.Parameters.Add(new SqlParameter("@Drink", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.Drink));
                cmdToExecute.Parameters.Add(new SqlParameter("@Smoke", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.Smoke));
                cmdToExecute.Parameters.Add(new SqlParameter("@AboutInfo", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.AboutInfo));
                cmdToExecute.Parameters.Add(new SqlParameter("@EmailID", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.EmaiID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.Password));
                cmdToExecute.Parameters.Add(new SqlParameter("@RegisterDate", SqlDbType.DateTime, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.RegisterDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@isActive", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.isActive));
                cmdToExecute.Parameters.Add(new SqlParameter("@Choice", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.Choice));
                cmdToExecute.Parameters.Add(new SqlParameter("@Remarks", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.Remarks));

                cmdToExecute.Parameters.Add(new SqlParameter("@VisaCountry", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.VisaCountry));
                cmdToExecute.Parameters.Add(new SqlParameter("@Degree", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.Degree));
                cmdToExecute.Parameters.Add(new SqlParameter("@OccupationDtls", SqlDbType.NVarChar, 100, Objtbl_UpdateMemberMasterProp.OccupationDtls));

                cmdToExecute.Parameters.Add(new SqlParameter("@mStatus", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.mStatus));
                cmdToExecute.Parameters.Add(new SqlParameter("@FileNote", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.FileNote));

                return cmdToExecute.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete_Data(tbl_UpdateMemberMasterProp Objtbl_UpdateMemberMasterProp)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "Delete_tbl_UpdateMemberMaster";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;

            try
            {
                objdb.GetConnStr();
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.MemberCode));
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Delete_tbl_UpdateMemberMaster");
                //cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Int, 20, Objtbl_UpdateMemberMasterProp.MemberCode);
                //return DB.ExecuteNonQuery(DBCmd);
                return cmdToExecute.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Data(tbl_UpdateMemberMasterProp Objtbl_UpdateMemberMasterProp, ref int TotalCount)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "Select_tbl_UpdateMemberMaster";
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
                //DbCommand DBCmd = DB.GetStoredProcCommand("Select_tbl_UpdateMemberMaster");
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.MemberCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNo", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.PageNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@RecordCount", SqlDbType.Int, 18, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateMemberMasterProp.RecordCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalCount", SqlDbType.Int, 18, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, _TotalCount));
                da = new SqlDataAdapter(cmdToExecute);
                da.Fill(ds);
                TotalCount = Convert.ToInt32(cmdToExecute.Parameters["@TotalCount"].Value);
                return ds;
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
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Search_tbl_UpdateMemberMaster");
                //cmdToExecute.Parameters.Add(new SqlParameter("@SearchBy", SqlDbType.NVarChar, 100, Objtbl_UpdateMemberMasterProp.SearchBy);
                //cmdToExecute.Parameters.Add(new SqlParameter("@SearchVal", SqlDbType.NVarChar, 100, Objtbl_UpdateMemberMasterProp.SearchVal);
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
