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
    public partial class rfrmPaidMembership : Form
    {
        string strCaste = "";
        dbInteraction objDb = new dbInteraction();
        Global objGlobal = new Global();
        int[] FieldLength;
        string strCountry = "", strCity = "";

        public rfrmPaidMembership()
        {
            InitializeComponent();
        }

        private void rfrmPaidMembership_Load(object sender, EventArgs e)
        {
            FillList();
            strCountry = " SELECT 'All' AS Country,0 as ORD,-1 AS CountryCode ";
            strCountry += " UNION ALL ";
            strCountry += " SELECT Country,1 as ORD,CountryCode FROM tbl_Country ORDER BY ORD,Country";
            FieldLength = new int[] { 100, 0, 0 };
            objGlobal.FillListView(LvwCountry, strCountry, FieldLength);
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

        private void rfrmPaidMembership_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
            ((frmMain)base.MdiParent).mnuPaidMembership.Enabled = true;
            ((frmMain)base.MdiParent).pnlMain.Visible = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string strCond = "", Caste_Sel = "", Country_Sel = "", State_Sel = "";
                if (rbtnFree.Checked)
                {
                    strCond = " and dbo.isYetMember(MM.MemberCode, 0) <= 0 ";
                }
                else
                {
                    strCond = " and dbo.isYetMember(MM.MemberCode, 0) > 0 ";
                }
                if (dtpFromDate.Value.ToShortDateString() != dtpToDate.Value.ToShortDateString())
                {
                    strCond += " AND MS.StartDate BETWEEN '" + dtpFromDate.Value.ToString("dd/MMM/yyyy") + "' AND '" + dtpToDate.Value.ToString("dd/MMM/yyyy") + "'";
                    //strCond += " AND MM.RegisterDate BETWEEN '" + dtpFromDate.Value.ToString("dd/MMM/yyyy") + "' AND '" + dtpToDate.Value.ToString("dd/MMM/yyyy") + "'";
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
                Country_Sel = "";
                for (int cnt = 0; cnt < LvwCountry.Items.Count; cnt++)
                {
                    if (LvwCountry.Items[cnt].SubItems[LvwCountry.Columns.Count - 1].Text != "-1")
                    {
                        if (LvwCountry.Items[cnt].Checked)
                        {
                            if (Country_Sel == "")
                            {
                                Country_Sel = LvwCountry.Items[cnt].SubItems[LvwCountry.Columns.Count - 1].Text;
                            }
                            else
                            {
                                Country_Sel += "," + LvwCountry.Items[cnt].SubItems[LvwCountry.Columns.Count - 1].Text;
                            }
                        }
                    }
                }
                if (Country_Sel != "")
                {
                    strCond += " AND MM.Country IN (" + Country_Sel + ")";
                }
                State_Sel = "";
                for (int cnt = 0; cnt < LvwState.Items.Count; cnt++)
                {
                    if (LvwState.Items[cnt].SubItems[LvwState.Columns.Count - 1].Text != "-1")
                    {
                        if (LvwState.Items[cnt].Checked)
                        {
                            if (State_Sel == "")
                            {
                                State_Sel = LvwState.Items[cnt].SubItems[LvwState.Columns.Count - 1].Text;
                            }
                            else
                            {
                                State_Sel += "," + LvwState.Items[cnt].SubItems[LvwState.Columns.Count - 1].Text;
                            }
                        }
                    }
                }
                if (State_Sel != "")
                {
                    strCond += " AND MM.StateCity IN (" + State_Sel + ")";
                }
                if (strCond == "")
                {
                    MessageBox.Show("Please select Something", "Selection Validation", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                tbl_MemberMasterBAL objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
                DataSet dsdata = objtbl_MemberMasterBAL.GET_PAID_MEMBERSHIP(strCond);
                if (dsdata.Tables[0].Rows.Count > 0)
                {
                    frmReportViewer objReportViewer = new frmReportViewer();
                    ReportDocument cryRpt = new ReportDocument();
                    string strPath = "";
                    strPath = Application.StartupPath + @"\REPORTS\PaidMembership.rpt";
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

        private void LvwCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LvwCountry_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                string strCountry_Sel = "";
                for (int cnt = 0; cnt < LvwCountry.Items.Count; cnt++)
                {
                    if (LvwCountry.Items[cnt].Checked)
                    {
                        if (strCountry_Sel == "")
                        {
                            strCountry_Sel = LvwCountry.Items[cnt].SubItems[LvwCountry.Columns.Count - 1].Text;
                        }
                        else
                        {
                            strCountry_Sel += "," + LvwCountry.Items[cnt].SubItems[LvwCountry.Columns.Count - 1].Text;
                        }
                    }
                }
                if (strCountry_Sel != "")
                {
                    if (strCountry_Sel != "0")
                    {
                        strCity = " SELECT 'All' AS StateCity,-1 AS StateCityCode";
                        strCity += " UNION ALL ";
                        strCity += " SELECT StateCity,StateCityCode FROM tbl_StateCity WHERE CountryCode in (" + strCountry_Sel + ") ORDER BY StateCity";
                    }
                    else
                    {
                        strCity = " SELECT 'All' AS StateCity,0 AS StateCityCode";
                    }
                    FieldLength = new int[] { 100, 0 };
                    objGlobal.FillListView(LvwState, strCity, FieldLength);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
