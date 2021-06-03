using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using AnantMatrimony.MatrimonyDAL;
using System.Windows.Forms;

namespace AnantMatrimony
{
    public class tbl_MemberMasterDAL
    {
        dbInteraction objdb = new dbInteraction();

        public int InsertUpdate_Data(ref tbl_MemberMasterProp Objtbl_MemberMasterProp)
        {
            int _RetVal = 0;
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "InsertUpdate_tbl_MemberMaster";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;

            try
            {
                objdb.GetConnStr();
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.MemberCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@ProfileID", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.ProfileID));
                cmdToExecute.Parameters.Add(new SqlParameter("@ProfileCreatedBy", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.ProfileCreatedBy));
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.MemberName));
                cmdToExecute.Parameters.Add(new SqlParameter("@Gender", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.Gender));
                cmdToExecute.Parameters.Add(new SqlParameter("@DateofBirth", SqlDbType.DateTime, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.DateofBirth));
                cmdToExecute.Parameters.Add(new SqlParameter("@TimeofBirth", SqlDbType.DateTime, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.TimeofBirth));
                cmdToExecute.Parameters.Add(new SqlParameter("@BirthPlace", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.BirthPlace));
                cmdToExecute.Parameters.Add(new SqlParameter("@MaritalStatus", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.MaritalStatus));
                cmdToExecute.Parameters.Add(new SqlParameter("@NoOfChildren", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.NoOfChildren));
                cmdToExecute.Parameters.Add(new SqlParameter("@LiveChildrenTogether", SqlDbType.Int, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.LiveChildrenTogether));
                cmdToExecute.Parameters.Add(new SqlParameter("@Height", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.Height));
                cmdToExecute.Parameters.Add(new SqlParameter("@Weight", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.Weight));
                cmdToExecute.Parameters.Add(new SqlParameter("@BodyType", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.BodyType));
                cmdToExecute.Parameters.Add(new SqlParameter("@HealthInformation", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.HealthInformation));
                cmdToExecute.Parameters.Add(new SqlParameter("@Complexion", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.Complexion));
                cmdToExecute.Parameters.Add(new SqlParameter("@AnyDisability", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.AnyDisability));
                cmdToExecute.Parameters.Add(new SqlParameter("@BloodGroup", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.BloodGroup));
                cmdToExecute.Parameters.Add(new SqlParameter("@HomeAddress1", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.HomeAddress1));
                cmdToExecute.Parameters.Add(new SqlParameter("@HomeAddress2", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.HomeAddress2));
                cmdToExecute.Parameters.Add(new SqlParameter("@VisaStatus", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.VisaStatus));
                cmdToExecute.Parameters.Add(new SqlParameter("@Country", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.Country));
                cmdToExecute.Parameters.Add(new SqlParameter("@StateCity", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.StateCity));
                cmdToExecute.Parameters.Add(new SqlParameter("@MobileNo", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.MobileNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@LandlineNo", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.LandlineNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@MobileNo1", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.MobileNo1));
                cmdToExecute.Parameters.Add(new SqlParameter("@LandlineNo1", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.LandlineNo1));
                cmdToExecute.Parameters.Add(new SqlParameter("@SecondaryEmailID", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.SecondaryEmailID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Religion", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.Religion));
                cmdToExecute.Parameters.Add(new SqlParameter("@MotherTongue", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.MotherTongue));
                cmdToExecute.Parameters.Add(new SqlParameter("@Caste", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.Caste));
                cmdToExecute.Parameters.Add(new SqlParameter("@SubCaste", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.SubCaste));
                cmdToExecute.Parameters.Add(new SqlParameter("@Gotra", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.Gotra));
                cmdToExecute.Parameters.Add(new SqlParameter("@FatherName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.FatherName));
                cmdToExecute.Parameters.Add(new SqlParameter("@FatherOccupation", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.FatherOccupation));
                cmdToExecute.Parameters.Add(new SqlParameter("@MotherName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.MotherName));
                cmdToExecute.Parameters.Add(new SqlParameter("@MotherOccupation", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.MotherOccupation));
                cmdToExecute.Parameters.Add(new SqlParameter("@MosalPlace", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.MosalPlace));
                cmdToExecute.Parameters.Add(new SqlParameter("@NativePlace", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.NativePlace));
                cmdToExecute.Parameters.Add(new SqlParameter("@FamilyType", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.FamilyType));
                cmdToExecute.Parameters.Add(new SqlParameter("@FamilyValues", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.FamilyValues));
                cmdToExecute.Parameters.Add(new SqlParameter("@Manglik", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.Manglik));
                cmdToExecute.Parameters.Add(new SqlParameter("@Nakshtra", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.Nakshtra));
                cmdToExecute.Parameters.Add(new SqlParameter("@Rashi", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.Rashi));
                cmdToExecute.Parameters.Add(new SqlParameter("@Education", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.Education));
                cmdToExecute.Parameters.Add(new SqlParameter("@Occupation", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.Occupation));
                cmdToExecute.Parameters.Add(new SqlParameter("@WorkingAs", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.WorkingAs));
                cmdToExecute.Parameters.Add(new SqlParameter("@WorkingWith", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.WorkingWith));
                cmdToExecute.Parameters.Add(new SqlParameter("@WorkAddress", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.WorkAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@AnnualIncomeCurrency", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.AnnualIncomeCurrency));
                cmdToExecute.Parameters.Add(new SqlParameter("@AnnualIncome", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.AnnualIncome));
                cmdToExecute.Parameters.Add(new SqlParameter("@Diet", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.Diet));
                cmdToExecute.Parameters.Add(new SqlParameter("@Drink", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.Drink));
                cmdToExecute.Parameters.Add(new SqlParameter("@Smoke", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.Smoke));
                cmdToExecute.Parameters.Add(new SqlParameter("@AboutInfo", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.AboutInfo));
                cmdToExecute.Parameters.Add(new SqlParameter("@EmailID", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.EmailID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.Password));
                cmdToExecute.Parameters.Add(new SqlParameter("@RegisterDate", SqlDbType.DateTime, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.RegisterDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@isActive", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.isActive));
                cmdToExecute.Parameters.Add(new SqlParameter("@Choice", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.Choice));
                cmdToExecute.Parameters.Add(new SqlParameter("@Remarks", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.Remarks));
                cmdToExecute.Parameters.Add(new SqlParameter("@mStatus", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.mStatus));
                cmdToExecute.Parameters.Add(new SqlParameter("@FileNote", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.FileNote));

                cmdToExecute.Parameters.Add(new SqlParameter("@Degree", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.Degree));
                cmdToExecute.Parameters.Add(new SqlParameter("@OccupationDtls", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.OccupationDtls));
                cmdToExecute.Parameters.Add(new SqlParameter("@VisaCountry", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.VisaCountry));


                cmdToExecute.Parameters.Add(new SqlParameter("@AgeDiff", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.AgeDiff));
                cmdToExecute.Parameters.Add(new SqlParameter("@MobileNo_Rel", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.MobileNo_Rel));
                cmdToExecute.Parameters.Add(new SqlParameter("@MobileNo1_Rel", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.MobileNo1_Rel));
                cmdToExecute.Parameters.Add(new SqlParameter("@LandlineNo1_Rel", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.LandlineNo1_Rel));
                cmdToExecute.Parameters.Add(new SqlParameter("@MobileNo2_Rel", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.MobileNo2_Rel));


                cmdToExecute.Parameters.Add(new SqlParameter("@RetVal", SqlDbType.Int, 20, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, 18));
                cmdToExecute.Parameters.Add(new SqlParameter("@RetProfileID", SqlDbType.NVarChar, 100, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, 15));
                cmdToExecute.Parameters.Add(new SqlParameter("@RetPassword", SqlDbType.NVarChar, 100, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, 15));

                cmdToExecute.ExecuteNonQuery();

                Objtbl_MemberMasterProp.ProfileID = Convert.ToString(cmdToExecute.Parameters["@RetProfileID"].Value);
                Objtbl_MemberMasterProp.Password = Convert.ToString(cmdToExecute.Parameters["@RetPassword"].Value);

                return Convert.ToInt32(cmdToExecute.Parameters["@RetVal"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update_ProfileStatus(tbl_MemberMasterProp Objtbl_MemberMasterProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Update_ProfileStatus");
                //DB.AddInParameter(DBCmd, "@MemberCode", DbType.Int32, Objtbl_MemberMasterProp.MemberCode);
                //DB.AddInParameter(DBCmd, "@isActive", DbType.Int32, Objtbl_MemberMasterProp.isActive);
                //return DB.ExecuteNonQuery(DBCmd);
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete_Data(tbl_MemberMasterProp Objtbl_MemberMasterProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Delete_tbl_MemberMaster");
                //DB.AddInParameter(DBCmd, "@MemberCode", DbType.Int32, Objtbl_MemberMasterProp.MemberCode);
                //DB.AddInParameter(DBCmd, "@DeletionType", DbType.Int32, 1);
                //return DB.ExecuteNonQuery(DBCmd);
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Data(tbl_MemberMasterProp Objtbl_MemberMasterProp, ref int TotalCount)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "Select_tbl_MemberMaster";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = null;
            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;
            int _TotalCount = 0;

            try
            {
                objdb.GetConnStr();
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.MemberCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNo", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.PageNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@RecordCount", SqlDbType.Int, 18, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.RecordCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalCount", SqlDbType.Int, 18, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, _TotalCount));

                da = new SqlDataAdapter(cmdToExecute);
                da.Fill(ds);

                TotalCount = Convert.ToInt32(cmdToExecute.Parameters["@TotalCount"].Value);
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Select_tbl_MemberMaster");
                //DB.AddInParameter(DBCmd, "@MemberCode", DbType.Int32, Objtbl_MemberMasterProp.MemberCode);
                //DB.AddInParameter(DBCmd, "@PageNo", DbType.Int32, Objtbl_MemberMasterProp.PageNo);
                //DB.AddInParameter(DBCmd, "@RecordCount", DbType.Int32, Objtbl_MemberMasterProp.RecordCount);
                //DB.AddOutParameter(DBCmd, "@TotalCount", DbType.Int32, 18);
                //DataSet dsData = DB.ExecuteDataSet(DBCmd);
                //TotalCount = Convert.ToInt32(DBCmd.Parameters["@TotalCount"].Value);
                //return dsData;
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_ExpiredInDays(tbl_MemberMasterProp Objtbl_MemberMasterProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Select_ExpiredInDays");
                //DB.AddInParameter(DBCmd, "@SearchVal", DbType.Int32, Objtbl_MemberMasterProp.SearchVal);

                //DataSet dsData = DB.ExecuteDataSet(DBCmd);

                //return dsData;
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Search_Data(tbl_MemberMasterProp Objtbl_MemberMasterProp, ref int TotalCount)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "Search_tbl_MemberMaster";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = null;
            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;
            int _TotalCount = 0;

            try
            {
                objdb.GetConnStr();
                cmdToExecute.Parameters.Add(new SqlParameter("@SearchBy", SqlDbType.NVarChar, 120, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.SearchBy));
                cmdToExecute.Parameters.Add(new SqlParameter("@SearchVal", SqlDbType.NVarChar, 220, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.SearchVal));
                //cmdToExecute.Parameters.Add(new SqlParameter("@RecordCount", SqlDbType.Int, 18, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.RecordCount));
                //cmdToExecute.Parameters.Add(new SqlParameter("@TotalCount", SqlDbType.Int, 18, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, _TotalCount));

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

        public DataSet SelectCombo_Data()
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("SelectCombo_tbl_MemberMaster");
                //return DB.ExecuteDataSet(DBCmd);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Load_ProfileList(tbl_MemberMasterSearchProp Objtbl_MemberMasterSearchProp, ref int TotalCount)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "Load_ProfileList";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = null;
            cmdToExecute.Connection = objdb.objConnection;
            int _TotalCount = 0;
            try
            {
                objdb.GetConnStr();
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.NVarChar, 120, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterSearchProp.sMemberCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@Gender", SqlDbType.NVarChar, 120, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterSearchProp.sGender));
                cmdToExecute.Parameters.Add(new SqlParameter("@AgeStart", SqlDbType.NVarChar, 120, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterSearchProp.sAgeStart));

                cmdToExecute.Parameters.Add(new SqlParameter("@AgeUpto", SqlDbType.NVarChar, 120, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterSearchProp.sAgeUpto));
                cmdToExecute.Parameters.Add(new SqlParameter("@MaritalStatusList", SqlDbType.NVarChar, 120, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterSearchProp.sMaritalStatus));
                cmdToExecute.Parameters.Add(new SqlParameter("@EducationList", SqlDbType.NVarChar, 120, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterSearchProp.sEducation));
                cmdToExecute.Parameters.Add(new SqlParameter("@CasteList", SqlDbType.NVarChar, 120, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterSearchProp.sCaste));
                cmdToExecute.Parameters.Add(new SqlParameter("@CountryList", SqlDbType.NVarChar, 120, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterSearchProp.sCountry));
                cmdToExecute.Parameters.Add(new SqlParameter("@StateCityList", SqlDbType.NVarChar, 120, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterSearchProp.sStateCity));

                cmdToExecute.Parameters.Add(new SqlParameter("@SqlCondition", SqlDbType.Bit, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterSearchProp.sSqlCondition));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNo", SqlDbType.Int, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterSearchProp.PageNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@RecordCount", SqlDbType.Int, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterSearchProp.RecordCount));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalCount", SqlDbType.Int, 5, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, _TotalCount));

                da = new SqlDataAdapter(cmdToExecute);
                da.Fill(ds);
                TotalCount = Convert.ToInt32(cmdToExecute.Parameters["@TotalCount"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }

        public DataSet Load_ProfileList_New(string strMasterCode)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "Load_ProfileList_New";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = null;
            cmdToExecute.Connection = objdb.objConnection;
            int _TotalCount = 0;
            try
            {
                objdb.GetConnStr();
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.NVarChar, 5000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, strMasterCode));
                da = new SqlDataAdapter(cmdToExecute);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }

        public DataSet GET_PAID_MEMBERSHIP(string strCondition)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "sp_GetPaidMembership";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = null;
            cmdToExecute.Connection = objdb.objConnection;
            try
            {
                objdb.GetConnStr();
                cmdToExecute.Parameters.Add(new SqlParameter("@strCondition", SqlDbType.NVarChar, 5000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, strCondition));
                da = new SqlDataAdapter(cmdToExecute);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }

        public DataSet GET_REGISTERED_MEMBER(string strCondition)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "sp_GetRegistrerMember";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = null;
            cmdToExecute.Connection = objdb.objConnection;
            try
            {
                objdb.GetConnStr();
                cmdToExecute.Parameters.Add(new SqlParameter("@strCondition", SqlDbType.NVarChar, 5000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, strCondition));
                da = new SqlDataAdapter(cmdToExecute);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }

        public DataSet GET_ExpiredMembership(string strCondition)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "sp_ExpiredMembership";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = null;
            cmdToExecute.Connection = objdb.objConnection;
            try
            {
                objdb.GetConnStr();
                cmdToExecute.Parameters.Add(new SqlParameter("@strCondition", SqlDbType.NVarChar, 5000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, strCondition));
                da = new SqlDataAdapter(cmdToExecute);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }

        public DataSet Load_BookMarkList(tbl_MemberMasterProp Objtbl_MemberMasterProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Load_BookmarkList");

                //DB.AddInParameter(DBCmd, "@BookmarkList", DbType.String, Objtbl_MemberMasterProp.SearchVal);

                //DataSet dsData = DB.ExecuteDataSet(DBCmd);

                //return dsData;
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Load_EmailReport()
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Load_EmailReport");
                //return DB.ExecuteDataSet(DBCmd);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ForgotPassword(tbl_MemberMasterProp objtbl_MemberMasterProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("ForgotPassword");
                //DB.AddInParameter(DBCmd, "@EmailID", DbType.String, objtbl_MemberMasterProp.EmailID);
                //return DB.ExecuteDataSet(DBCmd);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ChangePassword(tbl_MemberMasterProp Objtbl_MemberMasterProp)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "ChangePassword";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = null;
            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;
            try
            {
                objdb.GetConnStr();
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Int, 120, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.MemberCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@EmailID", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.EmailID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OldPassword", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.Password));
                cmdToExecute.Parameters.Add(new SqlParameter("@NewPassword", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.NewPassword));
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("ChangePassword");
                //DB.AddInParameter(DBCmd, "@MemberCode", DbType.Int32, Objtbl_MemberMasterProp.);
                //DB.AddInParameter(DBCmd, "@EmailID", DbType.String, Objtbl_MemberMasterProp.EmailID);
                //DB.AddInParameter(DBCmd, "@OldPassword", DbType.String, Objtbl_MemberMasterProp.Password);
                //DB.AddInParameter(DBCmd, "@NewPassword", DbType.String, Objtbl_MemberMasterProp.NewPassword);

                //return DB.ExecuteNonQuery(DBCmd);
                return Convert.ToInt32(cmdToExecute.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Load_MemberDetails(tbl_MemberMasterProp Objtbl_MemberMasterProp)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "Load_MemberDetails";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = null;
            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;
            try
            {
                objdb.GetConnStr();
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Load_MemberDetails");
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Int, 120, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.MemberCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@ProfileID", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.ProfileID));
                cmdToExecute.Parameters.Add(new SqlParameter("@LoginCode", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.LoginCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@isLogedin", SqlDbType.Bit, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.isLogedin));

                //DB.AddInParameter(DBCmd, "@ProfileID", DbType.String, Objtbl_MemberMasterProp.ProfileID);
                //DB.AddInParameter(DBCmd, "@LoginCode", DbType.String, Objtbl_MemberMasterProp.LoginCode);
                //DB.AddInParameter(DBCmd, "@isLogedin", DbType.Boolean, Objtbl_MemberMasterProp.isLogedin);
                //DB.AddInParameter(DBCmd, "@MemberCode", DbType.Int32, Objtbl_MemberMasterProp.MemberCode);

                //return DB.ExecuteDataSet(DBCmd);
                da = new SqlDataAdapter(cmdToExecute);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Profile_Summary(tbl_MemberMasterProp Objtbl_MemberMasterProp)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "Profile_Summary";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = null;
            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;

            try
            {
                objdb.GetConnStr();
                cmdToExecute.Parameters.Add(new SqlParameter("@isActive", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.isActive));
                da = new SqlDataAdapter(cmdToExecute);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }

        public DataSet Load_MFProfileList(tbl_MemberMasterProp Objtbl_MemberMasterProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Load_MFProfileList");
                //DB.AddInParameter(DBCmd, "@Gender", DbType.String, Objtbl_MemberMasterProp.Gender);

                //return DB.ExecuteDataSet(DBCmd);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet CheckforLogin(tbl_MemberMasterProp Objtbl_MemberMasterProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("CheckforLogin");
                //DB.AddInParameter(DBCmd, "@LoginID", DbType.String, Objtbl_MemberMasterProp.EmailID);
                //DB.AddInParameter(DBCmd, "@Password", DbType.String, Objtbl_MemberMasterProp.Password);
                //return DB.ExecuteDataSet(DBCmd);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetBirthYearList(tbl_MemberMasterSearchProp Objtbl_MemberMasterSearchProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("GetBirthYearList");
                //DB.AddInParameter(DBCmd, "@StartYear", DbType.Int32, Objtbl_MemberMasterSearchProp.sAgeStart);
                //DB.AddInParameter(DBCmd, "@EndYear", DbType.Int32, Objtbl_MemberMasterSearchProp.sAgeUpto);
                //return DB.ExecuteDataSet(DBCmd);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet LoadHomePageSponserData()
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Load_HomepageSponser");
                //return DB.ExecuteDataSet(DBCmd);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*---Created BY Sanjay On 26-4-16 For the Date Purpose in PhotoName like 23167_2016041612004500.jpg Name in DateTime Format*/
        public DataSet Load_CurrentDate()
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Load_CurrentDate");
                //return DB.ExecuteDataSet(DBCmd);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*---Created BY Sanjay On 23-5-16 For the Load Admin DashBoard */
        public DataSet Load_AdminDashboard()
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Load_AdminDashboard");
                //return DB.ExecuteDataSet(DBCmd);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GET_UPLOAD_PHOTO_PENDING(string strCondition)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "sp_GetUploadPhotoPending";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = null;
            cmdToExecute.Connection = objdb.objConnection;
            try
            {
                objdb.GetConnStr();
                cmdToExecute.Parameters.Add(new SqlParameter("@strCondition", SqlDbType.NVarChar, 5000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, strCondition));
                da = new SqlDataAdapter(cmdToExecute);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }

        public DataSet GetMarriedConfirmationList(string strCondition)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "sp_GetMarriedConfirmationList";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = null;
            cmdToExecute.Connection = objdb.objConnection;
            try
            {
                objdb.GetConnStr();
                cmdToExecute.Parameters.Add(new SqlParameter("@strCondition", SqlDbType.NVarChar, 5000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, strCondition));
                da = new SqlDataAdapter(cmdToExecute);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }

        public DataSet GET_Delete_Photos_List(string strCondition)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "sp_GetPhotosDeleteList";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = null;
            cmdToExecute.Connection = objdb.objConnection;
            try
            {
                objdb.GetConnStr();
                cmdToExecute.Parameters.Add(new SqlParameter("@strCondition", SqlDbType.NVarChar, 5000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, strCondition));
                da = new SqlDataAdapter(cmdToExecute);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }

        public int GetMemberCode(string strProfileId)
        {
            try
            {
                string strSql = "SELECT MemberCode FROM tbl_MemberMaster WHERE ProfileId='" + strProfileId + "'";
                return Convert.ToInt32(objdb.ExecuteScalar(strSql));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public int InsertSearchLog(string SearchVal, string SearchName, DateTime SearchDatetime, int UserId)
        {
            try
            {
                string strSql = " INSERT INTO tbl_MemberSearchListLog (SearchVal,SearchName,SearchDatetime,UserId) VALUES (";
                strSql += "'" + SearchVal + "','" + SearchName + "','" + SearchDatetime.ToString("dd-MMM-yyyy HH:mm:ss") + "'," + UserId + " )";
                return objdb.ExecuteNonQuery(strSql);
            }
            catch (Exception ex)
            {                
                throw ex;
                return 0;
            }
        }

        public DataTable GetMemberListSearchLog(DateTime FromDate, DateTime Todate)
        {
            DataTable dsDetails = new DataTable();
            try
            {
                string strSql = " select * from tbl_MemberSearchListLog where CONVERT(date, SearchDatetime) between '" + FromDate.ToString("dd/MMM/yyyy") + "' and '" + Todate.ToString("dd/MMM/yyyy") + "' order by SearchDatetime desc";
                dsDetails = objdb.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dsDetails;
        }

    }
}
