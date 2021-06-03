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
    class tbl_QueryDAL
    {
        dbInteraction objdb = new dbInteraction();

        public int InsertUpdate_Data(tbl_QueryProp Objtbl_QueryProp)
        {
            int _RetVal = 0;
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "InsertUpdate_tbl_Query";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;

            try
            {
                objdb.GetConnStr();
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("InsertUpdate_tbl_Query");
                cmdToExecute.Parameters.Add(new SqlParameter("@MessageCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_QueryProp.MessageCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@Surname", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_QueryProp.Surname));
                cmdToExecute.Parameters.Add(new SqlParameter("@SenderName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_QueryProp.SenderName));
                cmdToExecute.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_QueryProp.Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@ContactNo", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_QueryProp.ContactNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_QueryProp.Email));
                cmdToExecute.Parameters.Add(new SqlParameter("@Subject", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_QueryProp.Subject));
                cmdToExecute.Parameters.Add(new SqlParameter("@SenderMessage", SqlDbType.NVarChar, 5000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_QueryProp.SenderMessage));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.Bit, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_QueryProp.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@Date", SqlDbType.Date, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_QueryProp.Date));

                return cmdToExecute.ExecuteNonQuery();

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
        public int Delete_Data(tbl_QueryProp Objtbl_QueryProp)
        {
            int _RetVal = 0;
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "Delete_tbl_Query";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;
            try
            {
                objdb.GetConnStr();
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Delete_tbl_Query");
                cmdToExecute.Parameters.Add(new SqlParameter("@MessageCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_QueryProp.MessageCode));
                return cmdToExecute.ExecuteNonQuery();
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
        public DataSet Select_Data(tbl_QueryProp Objtbl_QueryProp, ref int TotalCount)
        {
            int TotalCnt = 0;
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "Select_tbl_Query";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = null;
            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;
            try
            {
                objdb.GetConnStr();
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Select_tbl_Query");
                cmdToExecute.Parameters.Add(new SqlParameter("@MessageCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_QueryProp.MessageCode));
                //cmdToExecute.Parameters.Add(new SqlParameter("@MsgFrom", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_QueryProp.SearchVal));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_QueryProp.Status));

                cmdToExecute.Parameters.Add(new SqlParameter("@PageNo", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_QueryProp.PageNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@RecordCount", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_QueryProp.RecordCount));

                cmdToExecute.Parameters.Add(new SqlParameter("@TotalCount", SqlDbType.Int, 20, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, TotalCount));

                //DB.AddOutParameter(DBCmd, "@TotalCount", DbType.Int32, 18);
                //DataSet dsData = DB.ExecuteDataSet(DBCmd);
                //TotalCount = Convert.ToInt32(DBCmd.Parameters["@TotalCount"].Value);
                da = new SqlDataAdapter(cmdToExecute);
                da.Fill(ds);

                TotalCount = Convert.ToInt32(cmdToExecute.Parameters["@TotalCount"].Value);
                return ds;
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

        public DataSet CountUnreadMessage(tbl_QueryProp Objtbl_QueryProp)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "CountUnreadMessage";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = null;
            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("CountUnreadMessage");
                objdb.GetConnStr();

                da = new SqlDataAdapter(cmdToExecute);
                da.Fill(ds);
                return ds;
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

        public DataSet Search_Data(tbl_QueryProp Objtbl_QueryProp)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "Search_tbl_Query";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = null;
            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;
            try
            {
                 objdb.GetConnStr();

                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Search_tbl_Query");
                cmdToExecute.Parameters.Add(new SqlParameter("@SearchBy", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_QueryProp.SearchBy));
                cmdToExecute.Parameters.Add(new SqlParameter("@SearchVal", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_QueryProp.SearchVal));
                da = new SqlDataAdapter(cmdToExecute);
                da.Fill(ds);
                return ds;
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
        public DataSet SelectCombo_Data()
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("SelectCombo_tbl_Query");
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
