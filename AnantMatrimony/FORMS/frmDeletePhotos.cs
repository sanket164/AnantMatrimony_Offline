using AnantMatrimony.MatrimonyDAL;
using AnantMatrimony.UD_CLASS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnantMatrimony.FORMS
{
    public partial class frmDeletePhotos : Form
    {
        public frmDeletePhotos()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ShowIcon = true;
        }

        EventLogging objEventLoging = new EventLogging();
        Global objGlobal = new Global();
        dbInteraction objDb = new dbInteraction();
        string strSql = "";
        int[] FieldLength;

        private void frmDeletePhotos_Load(object sender, EventArgs e)
        {
            try
            {
                FillHelp();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FillHelp()
        {
            try
            {
                DataTable dtBornYear = objGlobal.GetYearList(1950, DateTime.Now.Year);
                ddlPAgeFrom.DataSource = dtBornYear;
                ddlPAgeFrom.DisplayMember = "Number";
                ddlPAgeFrom.ValueMember = "NValue";

                DataTable dtToBornYear = dtBornYear.Copy();
                ddlPAgeTo.DataSource = dtToBornYear;
                ddlPAgeTo.DisplayMember = "Number";
                ddlPAgeTo.ValueMember = "NValue";

                strSql = " SELECT 0 AS CasteCode,'All' AS Caste,0 as ORD";
                strSql += " UNION ALL ";
                strSql += "SELECT CasteCode,Caste,1 as ORD FROM tbl_Caste ORDER BY ORD,Caste";
                DataTable dvCaste = objDb.GetDataTable(strSql);
                ddlCaste.DataSource = dvCaste;
                ddlCaste.DisplayMember = "Caste";
                ddlCaste.ValueMember = "CasteCode";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmDeletePhotos_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
            ((frmMain)base.MdiParent).mnuPhotoDelete.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                FillGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FillGrid()
        {
            try
            {
                string strCondi = "";
                //strSql = "  SELECT TOP 1000 MemberCode,ProfileId,MobileNo,MobileNo_Rel,MobileNo1,MobileNo1_Rel,LandlineNo,MobileNo2_Rel,LandlineNo1,LandlineNo1_Rel FROM tbl_membermaster WHERE isnull(MobileNo_Rel,'')='' ";
                strCondi += " AND MM.Gender =" + (rbtnMale.Checked == true ? "0" : "1");
                if (Convert.ToString(ddlPAgeFrom.SelectedValue) != Convert.ToString(ddlPAgeTo.SelectedValue))
                {
                    strCondi += " AND Convert(varchar(4),MM.DateOfBirth,111) Between " + ddlPAgeFrom.Text + " AND " + ddlPAgeTo.Text + "";
                }
                if (Convert.ToInt32(ddlCaste.SelectedValue) > 0)
                {
                    strCondi += " AND MM.Caste = " + ddlCaste.SelectedValue;
                }
                tbl_MemberMasterBAL objMembermaster = new tbl_MemberMasterBAL();
                DataSet dtDetails = objMembermaster.GET_Delete_Photos_List(strCondi);
                if (dtDetails.Tables[0].Rows.Count > 0)
                {
                    lblTotalCnt.Text = "Total : " + Convert.ToString(dtDetails.Tables[0].Rows.Count);
                    FieldLength = new int[] { 150, 200, 100, 120, 170, 80, 0 };
                    objGlobal.FillListView(LvwDetails, dtDetails.Tables[0], FieldLength);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            objGlobal.LISTVIEWSELECTION(LvwDetails, true, false, false);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            objGlobal.LISTVIEWSELECTION(LvwDetails, false, true, false);
        }

        private void btnInvert_Click(object sender, EventArgs e)
        {
            objGlobal.LISTVIEWSELECTION(LvwDetails, false, false, true);
        }

        private void btnDeletePhotos_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string EmailAdd = "", strMemberName = "";
                for (int cnt = 0; cnt < LvwDetails.Items.Count; cnt++)
                {
                    if (LvwDetails.Items[cnt].Checked)
                    {
                        string MemberCode = Convert.ToString(LvwDetails.Items[cnt].SubItems[6].Text);
                        strSql = "Select * from tbl_MemberPhotos where MemberCode=" + MemberCode;
                        DataTable dtDetails = objDb.GetDataTable(strSql);
                        for (int icnt = 0; icnt < dtDetails.Rows.Count; icnt++)
                        {
                            string sPath = Convert.ToString(dtDetails.Rows[cnt]["PhotoFileName"]);
                            var uri = new Uri("https://anantmatrimony.com/" + sPath, UriKind.Absolute);
                            System.IO.File.Delete(uri.LocalPath);

                            tbl_MemberPhotosProp Objtbl_MemberPhotosProp = new tbl_MemberPhotosProp();

                            Objtbl_MemberPhotosProp.MemberCode = Convert.ToInt32(MemberCode);
                            Objtbl_MemberPhotosProp.PhotoFileName = sPath;

                            tbl_MemberPhotosBAL Objtbl_MemberPhotosBAL = new tbl_MemberPhotosBAL();
                            Objtbl_MemberPhotosBAL.Delete_Data(Objtbl_MemberPhotosProp);
                        }

                        //if (EmailAdd == "")
                        //{
                        //    EmailAdd = LvwDetails.Items[cnt].SubItems[4].Text;
                        //    strMemberName = LvwDetails.Items[cnt].SubItems[1].Text;
                        //}
                        //else
                        //{
                        //    EmailAdd += "|" + LvwDetails.Items[cnt].SubItems[4].Text;
                        //    strMemberName += "|" + LvwDetails.Items[cnt].SubItems[1].Text;
                        //}
                    }
                }


                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
