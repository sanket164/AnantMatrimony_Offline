using AnantMatrimony.MatrimonyDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnantMatrimony
{
    class tbl_SibblingDetailsDAL
    {
        dbInteraction objdb = new dbInteraction();
        public int InsertUpdate_Data(tbl_SibblingDetailsProp Objtbl_SibblingDetailsProp)
        {
            int _RetVal = 0;
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "InsertUpdate_tbl_SibblingDetails";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;

            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("InsertUpdate_tbl_SibblingDetails");
                objdb.GetConnStr();
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_SibblingDetailsProp.MemberCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@BrotherSister", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_SibblingDetailsProp.BrotherSister));
                cmdToExecute.Parameters.Add(new SqlParameter("@SibblingName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_SibblingDetailsProp.SibblingName));
                cmdToExecute.Parameters.Add(new SqlParameter("@MaritalStatus", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_SibblingDetailsProp.MaritalStatus));
                cmdToExecute.Parameters.Add(new SqlParameter("@Occupation", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_SibblingDetailsProp.Occupation));
                cmdToExecute.Parameters.Add(new SqlParameter("@RetVal", SqlDbType.Int, 20, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, _RetVal));

                cmdToExecute.ExecuteNonQuery();

                //DB.AddOutParameter(DBCmd, "@RetVal", DbType.Int32, 18);
                //DB.ExecuteNonQuery(DBCmd);
                return Convert.ToInt32(cmdToExecute.Parameters["@RetVal"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public int Delete_Data(tbl_SibblingDetailsProp Objtbl_SibblingDetailsProp)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "Delete_tbl_SibblingDetails";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;
            try
            {
                objdb.GetConnStr();
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Delete_tbl_SibblingDetails");
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_SibblingDetailsProp.MemberCode));
                //DB.AddInParameter(DBCmd, "@MemberCode", DbType.String, Objtbl_SibblingDetailsProp.MemberCode);
                //return DB.ExecuteNonQuery(DBCmd);
                return cmdToExecute.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public DataSet Select_Data(tbl_SibblingDetailsProp Objtbl_SibblingDetailsProp)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "Select_tbl_SibblingDetails";
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
                //DbCommand DBCmd = DB.GetStoredProcCommand("Select_tbl_SibblingDetails");
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_SibblingDetailsProp.MemberCode));
                da = new SqlDataAdapter(cmdToExecute);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public DataSet Search_Data(tbl_SibblingDetailsProp Objtbl_SibblingDetailsProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Search_tbl_SibblingDetails");
                //DB.AddInParameter(DBCmd, "@SearchBy", DbType.String, Objtbl_SibblingDetailsProp.SearchBy);
                //DB.AddInParameter(DBCmd, "@SearchVal", DbType.String, Objtbl_SibblingDetailsProp.SearchVal);
                //return DB.ExecuteDataSet(DBCmd);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public DataSet SelectCombo_Data()
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("SelectCombo_tbl_SibblingDetails");
                //return DB.ExecuteDataSet(DBCmd);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
