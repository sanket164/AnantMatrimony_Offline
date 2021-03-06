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
    public class tbl_ProfileCreatedByDAL
    {
        dbInteraction objdb = new dbInteraction();

        public int InsertUpdate_Data(tbl_ProfileCreatedByProp Objtbl_ProfileCreatedByProp)
        {
            try
            {
                int _RetVal = 0;
                SqlCommand cmdToExecute = new SqlCommand();
                cmdToExecute.CommandText = "InsertUpdate_tbl_ProfileCreatedBy";
                cmdToExecute.CommandType = CommandType.StoredProcedure;

                // Use base class' connection object
                cmdToExecute.Connection = objdb.objConnection;

                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("InsertUpdate_tbl_ProfileCreatedBy");
                //DB.AddInParameter(DBCmd, "@ProfileCreatedByCode", DbType.Int32, Objtbl_ProfileCreatedByProp.ProfileCreatedByCode);
                //DB.AddInParameter(DBCmd, "@ProfileCreatedBy", DbType.String, Objtbl_ProfileCreatedByProp.ProfileCreatedBy);
                //DB.AddOutParameter(DBCmd, "@RetVal", DbType.Int32, 18);
                //DB.ExecuteNonQuery(DBCmd);
                //return Convert.ToInt32(DBCmd.Parameters["@RetVal"].Value);
                objdb.GetConnStr();
                cmdToExecute.Parameters.Add(new SqlParameter("@ProfileCreatedByCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_ProfileCreatedByProp.ProfileCreatedByCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@ProfileCreatedBy", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_ProfileCreatedByProp.ProfileCreatedBy));
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
        public int Delete_Data(tbl_ProfileCreatedByProp Objtbl_ProfileCreatedByProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Delete_tbl_ProfileCreatedBy");
                //DB.AddInParameter(DBCmd, "@ProfileCreatedByCode", DbType.Int32, Objtbl_ProfileCreatedByProp.ProfileCreatedByCode);
                //return DB.ExecuteNonQuery(DBCmd);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_ProfileCreatedByProp Objtbl_ProfileCreatedByProp, ref int TotalCount, int ProfileCreatedByCode)
        {
            try
            {
                DataSet dsData = objdb.ExecuteDataset("Select_tbl_ProfileCreatedBy", ProfileCreatedByCode, 1, 100, 0);
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Select_tbl_ProfileCreatedBy");
                //DB.AddInParameter(DBCmd, "@ProfileCreatedByCode", DbType.Int32, Objtbl_ProfileCreatedByProp.ProfileCreatedByCode);
                //DB.AddInParameter(DBCmd, "@PageNo", DbType.Int32, Objtbl_ProfileCreatedByProp.PageNo);
                //DB.AddInParameter(DBCmd, "@RecordCount", DbType.Int32, Objtbl_ProfileCreatedByProp.RecordCount);
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
        public DataSet Search_Data(tbl_ProfileCreatedByProp Objtbl_ProfileCreatedByProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Search_tbl_ProfileCreatedBy");
                //DB.AddInParameter(DBCmd, "@SearchBy", DbType.String, Objtbl_ProfileCreatedByProp.SearchBy);
                //DB.AddInParameter(DBCmd, "@SearchVal", DbType.String, Objtbl_ProfileCreatedByProp.SearchVal);
                //return DB.ExecuteDataSet(DBCmd);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SelectCombo_Data(tbl_ProfileCreatedByProp Objtbl_ProfileCreatedByProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("SelectCombo_tbl_ProfileCreatedBy");
                //DB.AddInParameter(DBCmd, "@SearchText", DbType.String, Objtbl_ProfileCreatedByProp.ProfileCreatedBy);
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
