using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnantMatrimony
{
    class tbl_MemberPhotosBAL
    {
        public int InsertUpdate_Data(tbl_MemberPhotosProp Objtbl_MemberPhotosProp, ref int TotalPhoto)
        {
            try
            {
                tbl_MemberPhotosDAL Objtbl_MemberPhotosDAL = new tbl_MemberPhotosDAL();
                return Objtbl_MemberPhotosDAL.InsertUpdate_Data(Objtbl_MemberPhotosProp, ref TotalPhoto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete_Data(tbl_MemberPhotosProp Objtbl_MemberPhotosProp)
        {
            try
            {
                tbl_MemberPhotosDAL Objtbl_MemberPhotosDAL = new tbl_MemberPhotosDAL();
                return Objtbl_MemberPhotosDAL.Delete_Data(Objtbl_MemberPhotosProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_MemberPhotosProp Objtbl_MemberPhotosProp)
        {
            try
            {
                tbl_MemberPhotosDAL Objtbl_MemberPhotosDAL = new tbl_MemberPhotosDAL();
                DataSet dsData = Objtbl_MemberPhotosDAL.Select_Data(Objtbl_MemberPhotosProp);
                return dsData;
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
                tbl_MemberPhotosDAL Objtbl_MemberPhotosDAL = new tbl_MemberPhotosDAL();
                return Objtbl_MemberPhotosDAL.Search_Data(Objtbl_MemberPhotosProp);
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
                tbl_MemberPhotosDAL Objtbl_MemberPhotosDAL = new tbl_MemberPhotosDAL();
                return Objtbl_MemberPhotosDAL.SelectCombo_Data();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
