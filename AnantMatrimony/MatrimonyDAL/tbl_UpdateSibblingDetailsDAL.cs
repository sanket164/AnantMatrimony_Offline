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
    class tbl_UpdateSibblingDetailsDAL
    {
        dbInteraction objdb = new dbInteraction();

        public int InsertUpdate_Data(tbl_UpdateSibblingDetailsProp Objtbl_UpdateSibblingDetailsProp)
        {
            int _RetVal = 0;
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "InsertUpdate_tbl_UpdateSibblingDetails";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;

            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("InsertUpdate_tbl_UpdateSibblingDetails");
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateSibblingDetailsProp.MemberCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@BrotherSister", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateSibblingDetailsProp.BrotherSister));
                cmdToExecute.Parameters.Add(new SqlParameter("@SibblingName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateSibblingDetailsProp.SibblingName));
                cmdToExecute.Parameters.Add(new SqlParameter("@MaritalStatus", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateSibblingDetailsProp.MaritalStatus));
                cmdToExecute.Parameters.Add(new SqlParameter("@Occupation", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateSibblingDetailsProp.Occupation));

                return cmdToExecute.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete_Data(tbl_UpdateSibblingDetailsProp Objtbl_UpdateSibblingDetailsProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Delete_tbl_UpdateSibblingDetails");
                //cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.String, Objtbl_UpdateSibblingDetailsProp.MemberCode);
                //return DB.ExecuteNonQuery(DBCmd);
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Data(tbl_UpdateSibblingDetailsProp Objtbl_UpdateSibblingDetailsProp)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "Select_tbl_UpdateSibblingDetails";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = null;
            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;
            int _TotalCount = 0;

            try
            {
                objdb.GetConnStr();

                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Select_tbl_UpdateSibblingDetails");
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_UpdateSibblingDetailsProp.MemberCode));
                da = new SqlDataAdapter(cmdToExecute);
                da.Fill(ds);                
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Search_Data(tbl_UpdateSibblingDetailsProp Objtbl_UpdateSibblingDetailsProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Search_tbl_UpdateSibblingDetails");
                //cmdToExecute.Parameters.Add(new SqlParameter("@SearchBy", SqlDbType.String, Objtbl_UpdateSibblingDetailsProp.SearchBy);
                //cmdToExecute.Parameters.Add(new SqlParameter("@SearchVal", SqlDbType.String, Objtbl_UpdateSibblingDetailsProp.SearchVal);
                //return DB.ExecuteDataSet(DBCmd);
                return null;
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
                //DbCommand DBCmd = DB.GetStoredProcCommand("SelectCombo_tbl_UpdateSibblingDetails");
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
