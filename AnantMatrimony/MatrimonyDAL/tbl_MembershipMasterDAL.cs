using AnantMatrimony.AnantProp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnantMatrimony.MatrimonyDAL
{
    class tbl_MembershipMasterDAL
    {
        dbInteraction objdb = new dbInteraction();

        public int InsertUpdate_Data(tbl_MembershipMasterProp Objtbl_MembershipMasterProp)
        {
            int _RetVal = 0;
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "InsertUpdate_tbl_MembershipMaster";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;

            try
            {
                objdb.GetConnStr();

                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("InsertUpdate_tbl_MembershipMaster");
                cmdToExecute.Parameters.Add(new SqlParameter("@SerialNo", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MembershipMasterProp.SerialNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MembershipMasterProp.MemberCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.DateTime, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MembershipMasterProp.StartDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@MembershipMonth", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MembershipMasterProp.MembershipMonth));
                cmdToExecute.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.DateTime, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MembershipMasterProp.EndDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberShipTypeCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MembershipMasterProp.MemberShipTypeCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@FacilityCode", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MembershipMasterProp.FacilityCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@AmountReceived", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MembershipMasterProp.AmountReceived));
                cmdToExecute.Parameters.Add(new SqlParameter("@PayBy", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MembershipMasterProp.PayBy));
                cmdToExecute.Parameters.Add(new SqlParameter("@ChequeNo", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MembershipMasterProp.ChequeNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@ChequeDate", SqlDbType.DateTime, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MembershipMasterProp.ChequeDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@BankDetail", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MembershipMasterProp.BankDetail));
                cmdToExecute.Parameters.Add(new SqlParameter("@IFSC", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MembershipMasterProp.IFSC));
                cmdToExecute.Parameters.Add(new SqlParameter("@RetVal", SqlDbType.Int, 18, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, _RetVal));
                cmdToExecute.ExecuteNonQuery();
                return Convert.ToInt32(cmdToExecute.Parameters["@RetVal"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete_Data(tbl_MembershipMasterProp Objtbl_MembershipMasterProp)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "Delete_tbl_MembershipMaster";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;
            try
            {
                objdb.GetConnStr();

                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("InsertUpdate_tbl_MembershipMaster");
                cmdToExecute.Parameters.Add(new SqlParameter("@SerialNo", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MembershipMasterProp.SerialNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MembershipMasterProp.MemberCode));

                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Delete_tbl_MembershipMaster");
                //DB.AddInParameter(DBCmd, "@MemberCode", DbType.Int32, Objtbl_MembershipMasterProp.MemberCode);
                //DB.AddInParameter(DBCmd, "@SerialNo", DbType.Int32, Objtbl_MembershipMasterProp.SerialNo);
                //return DB.ExecuteNonQuery(DBCmd);
                return (cmdToExecute.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_MembershipMasterProp Objtbl_MembershipMasterProp)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "Select_tbl_MembershipMaster";
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
                //DbCommand DBCmd = DB.GetStoredProcCommand("Select_tbl_MembershipMaster");
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MembershipMasterProp.MemberCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@SerialNo", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MembershipMasterProp.SerialNo));
                da = new SqlDataAdapter(cmdToExecute);
                da.Fill(ds);
                //DataSet dsData = DB.ExecuteDataSet(DBCmd);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Search_Data(tbl_MembershipMasterProp Objtbl_MembershipMasterProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Search_tbl_MembershipMaster");
                //DB.AddInParameter(DBCmd, "@SearchBy", DbType.String, Objtbl_MembershipMasterProp.SearchBy);
                //DB.AddInParameter(DBCmd, "@SearchVal", DbType.String, Objtbl_MembershipMasterProp.SearchVal);
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
                //DbCommand DBCmd = DB.GetStoredProcCommand("SelectCombo_tbl_MembershipMaster");

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
