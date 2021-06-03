using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnantMatrimony.MatrimonyDAL
{
    class tbl_CasteDAL
    {
        dbInteraction objdb = new dbInteraction();

        public int InsertUpdate_Data(tbl_CasteProp Objtbl_CasteProp)
        {
            int _RetVal = 0;
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "InsertUpdate_tbl_Caste";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;

            try
            {
                objdb.GetConnStr();
                cmdToExecute.Parameters.Add(new SqlParameter("@CasteCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_CasteProp.CasteCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@Caste", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_CasteProp.Caste));
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
            finally
            {
                objdb.CloseConnection(); ;
            }
        }
        public int Delete_Data(tbl_CasteProp Objtbl_CasteProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Delete_tbl_Caste");
                //DB.AddInParameter(DBCmd, "@CasteCode", DbType.Int32, Objtbl_CasteProp.CasteCode);
                //return DB.ExecuteNonQuery(DBCmd);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_CasteProp Objtbl_CasteProp, ref int TotalCount, int CasteCode)
        {
            try
            {
                DataSet dsData= objdb.ExecuteDataset("Select_tbl_Caste", CasteCode, 1, 50, 0);
                //DbCommand DBCmd = DB.GetStoredProcCommand("Select_tbl_Caste");
                //DB.AddInParameter(DBCmd, "@CasteCode", DbType.Int32, Objtbl_CasteProp.CasteCode);
                //DB.AddInParameter(DBCmd, "@PageNo", DbType.Int32, Objtbl_CasteProp.PageNo);
                //DB.AddInParameter(DBCmd, "@RecordCount", DbType.Int32, Objtbl_CasteProp.RecordCount);
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
        public DataSet Search_Data(tbl_CasteProp Objtbl_CasteProp)
        {
            try
            {
                //DataSet dsData = objdb.ExecuteDataset("Search_tbl_Caste", CasteCode, 1, 50, 0);
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Search_tbl_Caste");
                //DB.AddInParameter(DBCmd, "@SearchBy", DbType.String, Objtbl_CasteProp.SearchBy);
                //DB.AddInParameter(DBCmd, "@SearchVal", DbType.String, Objtbl_CasteProp.SearchVal);
                //return DB.ExecuteDataSet(DBCmd);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SelectCombo_Data(tbl_CasteProp Objtbl_CasteProp)
        {
            try
            {
                DataSet dsData = objdb.ExecuteDataset("SelectCombo_tbl_Caste", "");
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("SelectCombo_tbl_Caste");
                //DB.AddInParameter(DBCmd, "@SearchText", DbType.String, Objtbl_CasteProp.Caste);
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
