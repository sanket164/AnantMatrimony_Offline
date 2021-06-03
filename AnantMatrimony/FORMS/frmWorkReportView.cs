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
    public partial class frmWorkReportView : Form
    {
        public frmWorkReportView()
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
        string strSql = "";
        bool IsEdit = false, isValid = false;
        string strMasterTable = "tbl_WorkReport";
        int Intcout = 0;

        private void frmWorkReportView_Load(object sender, EventArgs e)
        {
            FillCombo();
        }

        private void frmWorkReportView_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
            ((frmMain)base.MdiParent).mnuWorkReportView.Enabled = true;
            ((frmMain)base.MdiParent).pnlMain.Visible = true;
        }

        public void FillCombo()
        {
            try
            {
                strSql = " SELECT '0' as EmployeeCode,'ALL' as EmployeeName ";
                strSql += " UNION ALL ";
                strSql += " SELECT EmployeeCode,EmployeeName FROM tbl_EmployeeMaster ORDER BY EmployeeCode";
                DataTable dtEmp = objDb.GetDataTable(strSql);
                ddlEmployee.DataSource = dtEmp;
                ddlEmployee.ValueMember = "EmployeeCode";
                ddlEmployee.DisplayMember = "EmployeeName";

                strSql = " SELECT '0' as WorkTypeCode,'ALL' as WorkType ";
                strSql += " UNION ALL ";
                strSql += " SELECT WorkTypeCode,WorkType FROM tbl_WorkType ORDER BY WorkTypeCode";
                DataTable dtWT = objDb.GetDataTable(strSql);
                ddlWorkType.DataSource = dtWT;
                ddlWorkType.ValueMember = "WorkTypeCode";
                ddlWorkType.DisplayMember = "WorkType";

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
                string strCond = "";
                strSql = " SELECT WR.ProfileId,WR.EntryDate,EM.EmployeeName,WT.WorkType,WR.Description ";
                strSql += " FROM tbl_WorkReport WR ";
                strSql += " INNER JOIN tbl_EmployeeMaster EM ON EM.EmployeeCode=WR.EmployeeCode ";
                strSql += " INNER JOIN tbl_WorkType WT ON WT.WorkTypeCode=WR.WorkTypeCode ";
                if (Convert.ToInt32(ddlEmployee.SelectedValue) > 0)
                {
                    strCond += " WHERE EM.EmployeeCode=" + ddlEmployee.SelectedValue;
                }
                if (Convert.ToInt32(ddlWorkType.SelectedValue) > 0)
                {
                    if (strCond != "")
                    {
                        strCond += " AND  WT.WorkTypeCode=" + ddlWorkType.SelectedValue;
                    }
                    else
                    {
                        strCond += " WHERE  WT.WorkTypeCode=" + ddlWorkType.SelectedValue;
                    }
                }
                if (dtpFromDate.Value.ToShortDateString() != dtpToDate.Value.ToShortDateString())
                {
                    if (strCond != "")
                    {
                        strCond += " AND WR.EntryDate BETWEEN '" + dtpFromDate.Value.ToString("dd/MMM/yyyy") + "' AND '" + dtpToDate.Value.ToString("dd/MMM/yyyy") + "'";
                    }
                    else
                    {
                        strCond += " WHERE WR.EntryDate BETWEEN '" + dtpFromDate.Value.ToString("dd/MMM/yyyy") + "' AND '" + dtpToDate.Value.ToString("dd/MMM/yyyy") + "'";
                    }
                }
                strSql += " ORDER BY EntryDate";
                DataTable dtDetails = objDb.GetDataTable(strSql);
                dgvDetails.DataSource = dtDetails;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
