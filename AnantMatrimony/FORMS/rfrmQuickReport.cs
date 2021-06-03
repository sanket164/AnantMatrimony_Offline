using AnantMatrimony.MatrimonyDAL;
using AnantMatrimony.UD_CLASS;
using CrystalDecisions.CrystalReports.Engine;
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
    public partial class rfrmQuickReport : Form
    {
        public rfrmQuickReport()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ShowIcon = false;
        }
        EventLogging objEventLoging = new EventLogging();
        Global objGlobal = new Global();
        ToolbarPositions TpLast;
        dbInteraction objDb = new dbInteraction();


        private void rfrmQuickReport_Load(object sender, EventArgs e)
        {

        }

        private void rfrmQuickReport_Activated(object sender, EventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
            objGlobal.FocusColor(this);
        }

        private void rfrmQuickReport_Deactivate(object sender, EventArgs e)
        {
            this.AutoValidate = AutoValidate.Disable;
        }

        private void rfrmQuickReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
            ((frmMain)base.MdiParent).mnuQuickPrint.Enabled = true;
            ((frmMain)base.MdiParent).pnlMain.Visible = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string strCode = "";
                if (txtProfileId.Text == "")
                {
                    MessageBox.Show("Please Enter Profile Id", "Profile Id Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtProfileId.Focus();
                    return;
                }
                if (txtProfileId.Text != "")
                {
                    string strSQl = "select * from tbl_Membermaster where ProfileId='" + txtProfileId.Text.Trim() + "' ";
                    DataTable dt = objDb.GetDataTable(strSQl);
                    if (dt.Rows.Count > 0)
                    {
                        strCode = Convert.ToString(dt.Rows[0]["MemberCode"]);
                    }
                    else
                    {
                        MessageBox.Show("Please Enter valid Profile Id", "Valid Profile Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtProfileId.Focus();
                        return;
                    }
                }
                tbl_MemberMasterProp Objtbl_MemberMasterProp = new tbl_MemberMasterProp();
                Objtbl_MemberMasterProp.MemberCode = Convert.ToInt32(strCode);
                Objtbl_MemberMasterProp.ProfileID = ""; // ProfileID;
                Objtbl_MemberMasterProp.isLogedin = true;
                Objtbl_MemberMasterProp.LoginCode = 0;

                tbl_MemberMasterBAL Objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
                DataSet dsMemberMaster = Objtbl_MemberMasterBAL.Load_MemberDetails(Objtbl_MemberMasterProp);

                dsMemberMaster.Tables[0].TableName = "dsMemberMaster";

                tbl_SibblingDetailsProp Objtbl_SibblingDetailsProp = new tbl_SibblingDetailsProp();
                Objtbl_SibblingDetailsProp.MemberCode = Convert.ToInt32(dsMemberMaster.Tables[0].Rows[0]["MemberCode"]);

                tbl_SibblingDetailsBAL Objtbl_SibblingDetailsBAL = new tbl_SibblingDetailsBAL();
                DataSet dsSibbling = Objtbl_SibblingDetailsBAL.Select_Data(Objtbl_SibblingDetailsProp);
                dsSibbling.Tables[0].TableName = "dsSibblingDtl";

                tbl_MemberPhotosBAL objtbl_MemberPhotosBAL = new tbl_MemberPhotosBAL();
                tbl_MemberPhotosProp objtbl_MemberPhotosProp = new tbl_MemberPhotosProp();
                objtbl_MemberPhotosProp.MemberCode = Convert.ToInt32(strCode);
                DataSet dsMemberPhotos = objtbl_MemberPhotosBAL.Select_Data(objtbl_MemberPhotosProp);
                dsMemberPhotos.Tables[0].TableName = "dsMemberPhotos";

                // dsMemberMaster.Tables.Add(dsSibbling.Tables[0]);
                //dsMemberMaster.Tables.Add(dsMemberPhotos.Tables[0]);
                frmReportViewer objReportViewer = new frmReportViewer();
                ReportDocument cryRpt = new ReportDocument();
                string strPath = Application.StartupPath + @"\REPORTS\MemberMaster.rpt";
                cryRpt.Load(strPath);
                DataSet dstest = new DataSet();

                dstest.Tables.Add(dsMemberMaster.Tables[0].Copy());
                //dstest.Tables.Add(dsMemberPhotos.Tables[0].Copy());
                cryRpt.Subreports["Sibbling"].SetDataSource(dsSibbling.Tables[0]);
                //cryRpt.Subreports["MemberPhotos"].SetDataSource(dsMemberPhotos.Tables[0]);

                cryRpt.SetDataSource(dstest);

                objReportViewer.RptViewer.ReportSource = cryRpt;
                objReportViewer.RptViewer.Refresh();
                objReportViewer.ShowDialog();
                objReportViewer.Focus();
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.rfrmQuickReport.btnSearch_Click() " + ex.ToString());
            }
        }
    }
}
