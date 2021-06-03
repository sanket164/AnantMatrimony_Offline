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
    class tbl_MemberPhotosDAL
    {
        dbInteraction objdb = new dbInteraction();

        public int InsertUpdate_Data(tbl_MemberPhotosProp Objtbl_MemberPhotosProp, ref int TotalPhoto)
        {
            int _RetVal = 0;
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "InsertUpdate_tbl_MemberPhotos";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;

            try
            {
                objdb.GetConnStr();
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("InsertUpdate_tbl_MemberPhotos");
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberPhotosProp.MemberCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@PhotoFileName", SqlDbType.NVarChar,200,ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberPhotosProp.PhotoFileName));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalCount", SqlDbType.Int, 20, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, _RetVal));

                cmdToExecute.ExecuteNonQuery();
                //DB.AddOutParameter(DBCmd, "@TotalCount", DbType.Int16, 2);

                //DB.ExecuteNonQuery(DBCmd);
                return Convert.ToInt32(_RetVal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete_Data(tbl_MemberPhotosProp Objtbl_MemberPhotosProp)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "Delete_tbl_MemberPhotos";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = objdb.objConnection;
            try
            {
                objdb.GetConnStr();
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberPhotosProp.MemberCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@PhotoFileName", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberPhotosProp.PhotoFileName));
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Delete_tbl_MemberPhotos");
                //DB.AddInParameter(DBCmd, "@MemberCode", DbType.Int32, Objtbl_MemberPhotosProp.MemberCode);
                //DB.AddInParameter(DBCmd, "@PhotoFileName", DbType.String, Objtbl_MemberPhotosProp.PhotoFileName);

                //return DB.ExecuteNonQuery(DBCmd);
                return Convert.ToInt32(cmdToExecute.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_MemberPhotosProp Objtbl_MemberPhotosProp)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "Select_tbl_MemberPhotos";
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
                //DbCommand DBCmd = DB.GetStoredProcCommand("Select_tbl_MemberPhotos");
                cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Objtbl_MemberPhotosProp.MemberCode));
                //DataSet dsData = DB.ExecuteDataSet(DBCmd);
                //return dsData;
                da = new SqlDataAdapter(cmdToExecute);
                da.Fill(ds);
                return ds;                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Search_Data(tbl_MemberPhotosProp Objtbl_MemberPhotosProp)
        {
            try
            {
                //Database DB = DatabaseFactory.CreateDatabase("AppConAnant");
                //DbCommand DBCmd = DB.GetStoredProcCommand("Search_tbl_MemberPhotos");
                //DB.AddInParameter(DBCmd, "@SearchBy", DbType.String, Objtbl_MemberPhotosProp.SearchBy);
                //DB.AddInParameter(DBCmd, "@SearchVal", DbType.String, Objtbl_MemberPhotosProp.SearchVal);
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
                //DbCommand DBCmd = DB.GetStoredProcCommand("SelectCombo_tbl_MemberPhotos");
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
