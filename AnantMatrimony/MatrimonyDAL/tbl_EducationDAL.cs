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
    public class tbl_EducationDAL
    {
        dbInteraction objdb = new dbInteraction();

        public int InsertUpdate_Data(tbl_EducationProp Objtbl_EducationProp)
        {
            int _RetVal = 0;
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "InsertUpdate_tbl_Education";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;

            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("InsertUpdate_tbl_Education");
                //DB.AddInParameter(DBCmd, "@EducationCode", DbType.Int32, Objtbl_EducationProp.EducationCode);
                //DB.AddInParameter(DBCmd, "@Education", DbType.String, Objtbl_EducationProp.Education);
                //DB.AddOutParameter(DBCmd, "@RetVal", DbType.Int32, 18);
                //DB.ExecuteNonQuery(DBCmd);
                //return Convert.ToInt32(DBCmd.Parameters["@RetVal"].Value);
                objdb.GetConnStr();
                cmdToExecute.Parameters.Add(new SqlParameter("@EducationCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_EducationProp.EducationCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@Education", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_EducationProp.Education));
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
        public int Delete_Data(tbl_EducationProp Objtbl_EducationProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Delete_tbl_Education");
                //DB.AddInParameter(DBCmd, "@EducationCode", DbType.Int32, Objtbl_EducationProp.EducationCode);
                //return DB.ExecuteNonQuery(DBCmd);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_EducationProp Objtbl_EducationProp, ref int TotalCount, int EducationCode)
        {
            try
            {
                DataSet dsData = objdb.ExecuteDataset("Select_tbl_Education", EducationCode, 1, 100, 0);
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Select_tbl_Education");
                //DB.AddInParameter(DBCmd, "@EducationCode", DbType.Int32, Objtbl_EducationProp.EducationCode);
                //DB.AddInParameter(DBCmd, "@PageNo", DbType.Int32, Objtbl_EducationProp.PageNo);
                //DB.AddInParameter(DBCmd, "@RecordCount", DbType.Int32, Objtbl_EducationProp.RecordCount);
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
        public DataSet Search_Data(tbl_EducationProp Objtbl_EducationProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Search_tbl_Education");
                //DB.AddInParameter(DBCmd, "@SearchBy", DbType.String, Objtbl_EducationProp.SearchBy);
                //DB.AddInParameter(DBCmd, "@SearchVal", DbType.String, Objtbl_EducationProp.SearchVal);
                //return DB.ExecuteDataSet(DBCmd);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SelectCombo_Data(tbl_EducationProp Objtbl_EducationProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("SelectCombo_tbl_Education");
                //DB.AddInParameter(DBCmd, "@SearchText", DbType.String, Objtbl_EducationProp.Education);
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
