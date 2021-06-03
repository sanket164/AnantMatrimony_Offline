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
    public partial class rfrmExpiredMembership : Form
    {
        string strCaste = "";
        dbInteraction objDb = new dbInteraction();
        Global objGlobal = new Global();
        int[] FieldLength;

        public rfrmExpiredMembership()
        {
            InitializeComponent();
        }

        private void rfrmExpiredMembership_Load(object sender, EventArgs e)
        {
            FillList();
        }

        private void rfrmExpiredMembership_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
            ((frmMain)base.MdiParent).mnuExpiredMembership.Enabled = true;
            ((frmMain)base.MdiParent).pnlMain.Visible = true;
        }

        public void FillList()
        {
            try
            {
                //strCaste = " SELECT 'All' AS Caste,0 as ORD,0 AS CasteCode";
                //strCaste += " UNION ALL ";
                strCaste = " SELECT Caste,1 as ORD,CasteCode FROM tbl_Caste ORDER BY ORD,Caste";
                FieldLength = new int[] { 100, 0, 0 };
                objGlobal.FillListView(LvwCaste, strCaste, FieldLength);

                DataTable dtBornYear = objGlobal.GetYearList(1950, DateTime.Now.Year);
                ddlPAgeFrom.DataSource = dtBornYear;
                ddlPAgeFrom.DisplayMember = "Number";
                ddlPAgeFrom.ValueMember = "NValue";

                DataTable dtToBornYear = objGlobal.GetYearList(1950, DateTime.Now.Year);
                ddlPAgeTo.DataSource = dtToBornYear;
                ddlPAgeTo.DisplayMember = "Number";
                ddlPAgeTo.ValueMember = "NValue";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string strCond = "", Caste_Sel = "";
                if (dtpFromDate.Value.ToShortDateString() != dtpToDate.Value.ToShortDateString())
                {
                    strCond += " AND MS.EndDate BETWEEN '" + dtpFromDate.Value.ToString("dd/MMM/yyyy") + "' AND '" + dtpToDate.Value.ToString("dd/MMM/yyyy") + "'";
                }
                if (Convert.ToString(ddlPAgeFrom.SelectedValue) != Convert.ToString(ddlPAgeTo.SelectedValue))
                {
                    strCond += " AND Convert(varchar(4),MM.DateOfBirth,111) Between " + ddlPAgeFrom.SelectedValue + " AND " + ddlPAgeTo.SelectedValue + " ";
                }
                if (rbtnMale.Checked)
                {
                    strCond += " AND MM.Gender=0 ";
                }
                else if (rbtnFemale.Checked)
                {
                    strCond += " AND MM.Gender=1 ";
                }
                for (int cnt = 0; cnt < LvwCaste.Items.Count; cnt++)
                {
                    if (LvwCaste.Items[cnt].Checked)
                    {
                        if (Caste_Sel == "")
                        {
                            Caste_Sel = LvwCaste.Items[cnt].SubItems[LvwCaste.Columns.Count - 1].Text;
                        }
                        else
                        {
                            Caste_Sel += "," + LvwCaste.Items[cnt].SubItems[LvwCaste.Columns.Count - 1].Text;
                        }
                    }
                }
                if (Caste_Sel != "")
                {
                    strCond += " AND MM.Caste in (" + Caste_Sel + ")";
                }
                if (strCond == "")
                {
                    MessageBox.Show("Please select Something", "Selection Validation", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                tbl_MemberMasterBAL objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
                DataSet dsdata = objtbl_MemberMasterBAL.GET_ExpiredMembership(strCond);
                if (dsdata.Tables[0].Rows.Count > 0)
                {
                    frmReportViewer objReportViewer = new frmReportViewer();
                    ReportDocument cryRpt = new ReportDocument();
                    string strPath = "";
                    strPath = Application.StartupPath + @"\REPORTS\ExpiredMembership.rpt";
                    cryRpt.Load(strPath);
                    cryRpt.SetDataSource(dsdata.Tables[0]);
                    objReportViewer.RptViewer.ReportSource = cryRpt;
                    objReportViewer.RptViewer.Refresh();
                    objReportViewer.ShowDialog();
                    objReportViewer.Focus();
                }
                else
                {
                    MessageBox.Show("No data found", "Data not found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
