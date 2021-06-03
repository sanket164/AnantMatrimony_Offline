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
    public class tbl_SubCasteDAL
    {
        dbInteraction objdb = new dbInteraction();

        public int InsertUpdate_Data(tbl_SubCasteProp Objtbl_SubCasteProp)
        {
            int _RetVal = 0;
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "InsertUpdate_tbl_SubCaste";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;

            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("InsertUpdate_tbl_SubCaste");
                //DB.AddInParameter(DBCmd, "@SubCasteCode", DbType.Int32, Objtbl_SubCasteProp.CasteCode);
                //DB.AddInParameter(DBCmd, "@SubCaste", DbType.String, Objtbl_SubCasteProp.CasteCode);
                //DB.AddInParameter(DBCmd, "@CasteCode", DbType.Int32, Objtbl_SubCasteProp.CasteCode);
                //DB.AddOutParameter(DBCmd, "@RetVal", DbType.Int32, 18);
                //DB.ExecuteNonQuery(DBCmd);
                //return Convert.ToInt32(DBCmd.Parameters["@RetVal"].Value);
                objdb.GetConnStr();
                cmdToExecute.Parameters.Add(new SqlParameter("@SubCasteCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_SubCasteProp.SubCasteCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@SubCaste", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_SubCasteProp.SubCaste));
                cmdToExecute.Parameters.Add(new SqlParameter("@CasteCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_SubCasteProp.CasteCode));
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

        public int Delete_Data(tbl_SubCasteProp Objtbl_SubCasteProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Delete_tbl_SubCaste");
                //DB.AddInParameter(DBCmd, "@SubCasteCode", DbType.Int32, Objtbl_SubCasteProp.SubCasteCode);
                //return DB.ExecuteNonQuery(DBCmd);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Data(tbl_SubCasteProp Objtbl_SubCasteProp, ref int TotalCount, int SubCasteCode)
        {
            try
            {
                DataSet dsData = objdb.ExecuteDataset("Select_tbl_SubCaste", SubCasteCode, 1, 99999, 0);
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Select_tbl_SubCaste");
                //DB.AddInParameter(DBCmd, "@SubCasteCode", DbType.Int32, Objtbl_SubCasteProp.SubCasteCode);
                //DB.AddInParameter(DBCmd, "@PageNo", DbType.Int32, Objtbl_SubCasteProp.PageNo);
                //DB.AddInParameter(DBCmd, "@RecordCount", DbType.Int32, Objtbl_SubCasteProp.RecordCount);
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

        public DataSet Search_Data(tbl_SubCasteProp Objtbl_SubCasteProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Search_tbl_SubCaste");
                //DB.AddInParameter(DBCmd, "@SearchBy", DbType.String, Objtbl_SubCasteProp.SearchBy);
                //DB.AddInParameter(DBCmd, "@SearchVal", DbType.String, Objtbl_SubCasteProp.SearchVal);
                //return DB.ExecuteDataSet(DBCmd);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SelectCombo_Data(tbl_SubCasteProp Objtbl_SubCasteProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("SelectCombo_tbl_SubCaste");
                //DB.AddInParameter(DBCmd, "@SearchText", DbType.String, Objtbl_SubCasteProp.SubCaste);
                //DB.AddInParameter(DBCmd, "@CasteCode", DbType.String, Objtbl_SubCasteProp.CasteCode);

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
