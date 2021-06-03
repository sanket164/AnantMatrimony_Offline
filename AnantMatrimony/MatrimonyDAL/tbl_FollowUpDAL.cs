using AnantMatrimony.AnantProp;
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
    class tbl_FollowUpDAL
    {
        dbInteraction objdb = new dbInteraction();

        public int InsertUpdate_Data(tbl_FollowUp Objtbl_FollowUpProp)
        {
            int _RetVal = 0;
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "InsertUpdate_tbl_FollowUp";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;

            try
            {
                objdb.GetConnStr();
                //cmdToExecute.Parameters.Add(new SqlParameter("@FollowUpId", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberMasterProp.MemberCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@ProfileId", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_FollowUpProp.ProfileId));
                cmdToExecute.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 120, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_FollowUpProp.Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@Date", SqlDbType.DateTime, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_FollowUpProp.Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_FollowUpProp.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@Remark1", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_FollowUpProp.Remark1));
                cmdToExecute.Parameters.Add(new SqlParameter("@Remark2", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_FollowUpProp.Remark2));
                cmdToExecute.Parameters.Add(new SqlParameter("@Remark3", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_FollowUpProp.Remark3));
                cmdToExecute.Parameters.Add(new SqlParameter("@Remark4", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_FollowUpProp.Remark4));
                cmdToExecute.Parameters.Add(new SqlParameter("@Remark5", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_FollowUpProp.Remark5));
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_FollowUpProp.MemberCode));

                //cmdToExecute.ExecuteNonQuery();

                return Convert.ToInt32(cmdToExecute.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete_Data(tbl_FollowUp Objtbl_FollowUpProp)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "Sp_Delete_tbl_FollowUp";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;

            try
            {
                objdb.GetConnStr();
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_FollowUpProp.MemberCode));
                return Convert.ToInt32(cmdToExecute.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Data(tbl_FollowUp Objtbl_FollowUpProp)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "Select_tbl_tbl_FollowUp";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = null;
            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;
            int _TotalCount = 0;

            try
            {
                objdb.GetConnStr();
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_FollowUpProp.MemberCode));               

                da = new SqlDataAdapter(cmdToExecute);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
