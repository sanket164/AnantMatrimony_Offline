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
    public class tbl_CountryDAL
    {
        dbInteraction objdb = new dbInteraction();

        public int InsertUpdate_Data(tbl_CountryProp Objtbl_CountryProp)
        {
            int _RetVal = 0;
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "InsertUpdate_tbl_Country";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;

            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("InsertUpdate_tbl_Country");
                //DB.AddInParameter(DBCmd, "@CountryCode", DbType.Int32, Objtbl_CountryProp.CountryCode);
                //DB.AddInParameter(DBCmd, "@Country", DbType.String, Objtbl_CountryProp.Country);
                //DB.AddOutParameter(DBCmd, "@RetVal", DbType.Int32, 18);
                //DB.ExecuteNonQuery(DBCmd);
                //return Convert.ToInt32(DBCmd.Parameters["@RetVal"].Value);
                objdb.GetConnStr();
                cmdToExecute.Parameters.Add(new SqlParameter("@CountryCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_CountryProp.CountryCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@Country", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_CountryProp.Country));
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
        
        public int Delete_Data(tbl_CountryProp Objtbl_CountryProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Delete_tbl_Country");
                //DB.AddInParameter(DBCmd, "@CountryCode", DbType.Int32, Objtbl_CountryProp.CountryCode);
                //return DB.ExecuteNonQuery(DBCmd);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Data(tbl_CountryProp Objtbl_CountryProp, ref int TotalCount, int CountryCode)
        {
            try
            {
                DataSet dsData = objdb.ExecuteDataset("Select_tbl_Country", CountryCode, 1, 100, 0);
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Select_tbl_Country");
                //DB.AddInParameter(DBCmd, "@CountryCode", DbType.Int32, Objtbl_CountryProp.CountryCode);
                //DB.AddInParameter(DBCmd, "@PageNo", DbType.Int32, Objtbl_CountryProp.PageNo);
                //DB.AddInParameter(DBCmd, "@RecordCount", DbType.Int32, Objtbl_CountryProp.RecordCount);
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
        
        public DataSet Search_Data(tbl_CountryProp Objtbl_CountryProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Search_tbl_Country");
                //DB.AddInParameter(DBCmd, "@SearchBy", DbType.String, Objtbl_CountryProp.SearchBy);
                //DB.AddInParameter(DBCmd, "@SearchVal", DbType.String, Objtbl_CountryProp.SearchVal);
                //return DB.ExecuteDataSet(DBCmd);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataSet SelectCombo_Data(tbl_CountryProp Objtbl_CountryProp)
        {
            try
            {
                DataSet dsData = objdb.ExecuteDataset("SelectCombo_tbl_Country", "");
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("SelectCombo_tbl_Country");
                //DB.AddInParameter(DBCmd, "@SearchText", DbType.String, Objtbl_CountryProp.Country);
                //return DB.ExecuteDataSet(DBCmd);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
