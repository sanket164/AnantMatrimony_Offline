using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Data.Common;
using AnantMatrimony.MatrimonyDAL;
using System.Data.SqlClient;
namespace AnantMatrimony
{
    public class tbl_BloodGroupDAL
    {
        dbInteraction objdb = new dbInteraction();

        public int InsertUpdate_Data(tbl_BloodGroupProp Objtbl_BloodGroupProp)
        {
            int _RetVal = 0;
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "InsertUpdate_tbl_BloodGroup";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;

            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("InsertUpdate_tbl_BloodGroup");
                //DB.AddInParameter(DBCmd, "@BloodGroupCode", DbType.Int32, Objtbl_BloodGroupProp.BloodGroupCode);
                //DB.AddInParameter(DBCmd, "@BloodGroup", DbType.String, Objtbl_BloodGroupProp.BloodGroup);
                //DB.AddOutParameter(DBCmd, "@RetVal", DbType.Int32, 18);
                //DB.ExecuteNonQuery(DBCmd);
                //return Convert.ToInt32(DBCmd.Parameters["@RetVal"].Value);
                objdb.GetConnStr();
                cmdToExecute.Parameters.Add(new SqlParameter("@BloodGroupCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_BloodGroupProp.BloodGroupCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@BloodGroup", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_BloodGroupProp.BloodGroup));
                cmdToExecute.Parameters.Add(new SqlParameter("@RetVal", SqlDbType.Int, 18, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, _RetVal));

                cmdToExecute.ExecuteNonQuery();

                string ErrorCode = cmdToExecute.Parameters["@RetVal"].Value.ToString();
                _RetVal = Convert.ToInt32(ErrorCode);

                return _RetVal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete_Data(tbl_BloodGroupProp Objtbl_BloodGroupProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Delete_tbl_BloodGroup");
                //DB.AddInParameter(DBCmd, "@BloodGroupCode", DbType.Int32, Objtbl_BloodGroupProp.BloodGroupCode);
                //return DB.ExecuteNonQuery(DBCmd);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_BloodGroupProp Objtbl_BloodGroupProp, ref int TotalCount, int BloodGroupCode)
        {
            try
            {
                DataSet dsData = objdb.ExecuteDataset("Select_tbl_BloodGroup", BloodGroupCode, 1, 100, 0);
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Select_tbl_BloodGroup");
                //DB.AddInParameter(DBCmd, "@BloodGroupCode", DbType.Int32, Objtbl_BloodGroupProp.BloodGroupCode);
                //DB.AddInParameter(DBCmd, "@PageNo", DbType.Int32, Objtbl_BloodGroupProp.PageNo);
                //DB.AddInParameter(DBCmd, "@RecordCount", DbType.Int32, Objtbl_BloodGroupProp.RecordCount);
                //DB.AddOutParameter(DBCmd, "@TotalCount", DbType.Int32, 18);
                //DataSet dsData = DB.ExecuteDataSet(DBCmd);
                //TotalCount = Convert.ToInt32(DBCmd.Parameters["@TotalCount"].Value);
                TotalCount = 100;
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Search_Data(tbl_BloodGroupProp Objtbl_BloodGroupProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Search_tbl_BloodGroup");
                //DB.AddInParameter(DBCmd, "@SearchBy", DbType.String, Objtbl_BloodGroupProp.SearchBy);
                //DB.AddInParameter(DBCmd, "@SearchVal", DbType.String, Objtbl_BloodGroupProp.SearchVal);
                //return DB.ExecuteDataSet(DBCmd);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SelectCombo_Data(tbl_BloodGroupProp Objtbl_BloodGroupProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("SelectCombo_tbl_BloodGroup");
                //DB.AddInParameter(DBCmd, "@SearchText", DbType.String, Objtbl_BloodGroupProp.BloodGroup);

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
