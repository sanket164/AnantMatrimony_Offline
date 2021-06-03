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
    public class tbl_VisaStatusDAL
    {
        dbInteraction objdb = new dbInteraction();

        public int InsertUpdate_Data(tbl_VisaStatusProp Objtbl_VisaStatusProp)
        {
            int _RetVal = 0;
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "InsertUpdate_tbl_Caste";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;

            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("InsertUpdate_tbl_VisaStatus");
                //DB.AddInParameter(DBCmd, "@VisaStatusCode", DbType.Int32, Objtbl_VisaStatusProp.VisaStatusCode);
                //DB.AddInParameter(DBCmd, "@VisaStatus", DbType.String, Objtbl_VisaStatusProp.VisaStatus);
                //DB.AddOutParameter(DBCmd, "@RetVal", DbType.Int32, 18);
                //DB.ExecuteNonQuery(DBCmd);
                //return Convert.ToInt32(DBCmd.Parameters["@RetVal"].Value);
                objdb.GetConnStr();
                cmdToExecute.Parameters.Add(new SqlParameter("@VisaStatusCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_VisaStatusProp.VisaStatusCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@VisaStatus", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_VisaStatusProp.VisaStatus));
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
        public int Delete_Data(tbl_VisaStatusProp Objtbl_VisaStatusProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Delete_tbl_VisaStatus");
                //DB.AddInParameter(DBCmd, "@VisaStatusCode", DbType.Int32, Objtbl_VisaStatusProp.VisaStatusCode);
                //return DB.ExecuteNonQuery(DBCmd);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_VisaStatusProp Objtbl_VisaStatusProp, ref int TotalCount, int VisaStatusCode)
        {
            try
            {
                DataSet dsData = objdb.ExecuteDataset("Select_tbl_VisaStatus", VisaStatusCode, 1, 100, 0);
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Select_tbl_VisaStatus");
                //DB.AddInParameter(DBCmd, "@VisaStatusCode", DbType.Int32, Objtbl_VisaStatusProp.VisaStatusCode);
                //DB.AddInParameter(DBCmd, "@PageNo", DbType.Int32, Objtbl_VisaStatusProp.PageNo);
                //DB.AddInParameter(DBCmd, "@RecordCount", DbType.Int32, Objtbl_VisaStatusProp.RecordCount);
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
        public DataSet Search_Data(tbl_VisaStatusProp Objtbl_VisaStatusProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Search_tbl_VisaStatus");
                //DB.AddInParameter(DBCmd, "@SearchBy", DbType.String, Objtbl_VisaStatusProp.SearchBy);
                //DB.AddInParameter(DBCmd, "@SearchVal", DbType.String, Objtbl_VisaStatusProp.SearchVal);
                //return DB.ExecuteDataSet(DBCmd);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SelectCombo_Data(tbl_VisaStatusProp Objtbl_VisaStatusProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("SelectCombo_tbl_VisaStatus");
                //DB.AddInParameter(DBCmd, "@SearchText", DbType.String, Objtbl_VisaStatusProp.VisaStatus);

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
