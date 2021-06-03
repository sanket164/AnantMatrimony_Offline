using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

//using Microsoft.Practices.EnterpriseLibrary;
//using Microsoft.Practices.EnterpriseLibrary.Data;
//using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;
using System.Data.SqlClient;

namespace AnantMatrimony.MatrimonyDAL
{
    public class tbl_AnnualIncomeCurrencyDAL
    {
        dbInteraction objdb = new dbInteraction();

        public int InsertUpdate_Data(tbl_AnnualIncomeCurrencyProp Objtbl_AnnualIncomeCurrencyProp)
        {
            int _RetVal = 0;
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "InsertUpdate_tbl_AnnualIncomeCurrency";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;

            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("InsertUpdate_tbl_AnnualIncomeCurrency");
                //DB.AddInParameter(DBCmd, "@AnnualIncomeCurrencyCode", DbType.Int32, Objtbl_AnnualIncomeCurrencyProp.AnnualIncomeCurrencyCode);
                //DB.AddInParameter(DBCmd, "@AnnualIncomeCurrency", DbType.String, Objtbl_AnnualIncomeCurrencyProp.AnnualIncomeCurrency);
                //DB.AddOutParameter(DBCmd, "@RetVal", DbType.Int32, 18);
                //DB.ExecuteNonQuery(DBCmd);
                //return Convert.ToInt32(DBCmd.Parameters["@RetVal"].Value);

                objdb.GetConnStr();
                cmdToExecute.Parameters.Add(new SqlParameter("@AnnualIncomeCurrencyCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_AnnualIncomeCurrencyProp.AnnualIncomeCurrencyCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@AnnualIncomeCurrency", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_AnnualIncomeCurrencyProp.AnnualIncomeCurrency));
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
        public int Delete_Data(tbl_AnnualIncomeCurrencyProp Objtbl_AnnualIncomeCurrencyProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Delete_tbl_AnnualIncomeCurrency");
                //DB.AddInParameter(DBCmd, "@AnnualIncomeCurrencyCode", DbType.Int32, Objtbl_AnnualIncomeCurrencyProp.AnnualIncomeCurrencyCode);
                //return DB.ExecuteNonQuery(DBCmd);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_AnnualIncomeCurrencyProp Objtbl_AnnualIncomeCurrencyProp, ref int TotalCount, int AnnualIncomeCurrencyCode)
        {
            try
            {
                DataSet dsData = objdb.ExecuteDataset("Select_tbl_AnnualIncomeCurrency", AnnualIncomeCurrencyCode, 1, 50, 0);
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Select_tbl_AnnualIncomeCurrency");
                //DB.AddInParameter(DBCmd, "@AnnualIncomeCurrencyCode", DbType.Int32, Objtbl_AnnualIncomeCurrencyProp.AnnualIncomeCurrencyCode);
                //DB.AddInParameter(DBCmd, "@PageNo", DbType.Int32, Objtbl_AnnualIncomeCurrencyProp.PageNo);
                //DB.AddInParameter(DBCmd, "@RecordCount", DbType.Int32, Objtbl_AnnualIncomeCurrencyProp.RecordCount);
                //DB.AddOutParameter(DBCmd, "@TotalCount", DbType.Int32, 18);
                //DataSet dsData = DB.ExecuteDataSet(DBCmd);
                //TotalCount = Convert.ToInt32(DBCmd.Parameters["@TotalCount"].Value);
                //return dsData;
                TotalCount = 100;
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Search_Data(tbl_AnnualIncomeCurrencyProp Objtbl_AnnualIncomeCurrencyProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Search_tbl_AnnualIncomeCurrency");
                //DB.AddInParameter(DBCmd, "@SearchBy", DbType.String, Objtbl_AnnualIncomeCurrencyProp.SearchBy);
                //DB.AddInParameter(DBCmd, "@SearchVal", DbType.String, Objtbl_AnnualIncomeCurrencyProp.SearchVal);
                //return DB.ExecuteDataSet(DBCmd);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SelectCombo_Data(tbl_AnnualIncomeCurrencyProp Objtbl_AnnualIncomeCurrencyProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("SelectCombo_tbl_AnnualIncomeCurrency");
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
