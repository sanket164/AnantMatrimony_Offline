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
    public partial class LogInLog : Form
    {
        public LogInLog()
        {
            InitializeComponent();
        }
        dbInteraction objDb = new dbInteraction();
        Global objGlobal = new Global();
        int[] FieldLength;

        private void LogInLog_Load(object sender, EventArgs e)
        {
            LvwDetails_A.CheckBoxes = false;
        }

        private void btnDateSearch_Click(object sender, EventArgs e)
        {
            BindList(true);
        }

        private void btnProfileIdWise_Click(object sender, EventArgs e)
        {
            BindList(false);
        }

        public void BindList(bool DateWise)
        {
            try
            {
                string strSql = "";
                if (rbtnDetails.Checked)
                {
                    if (DateWise)
                    {
                        strSql = " SELECT mm.profileid,mm.MemberCode,LoginDate,IPAddress,City FROM tbl_LogTable lt";
                        strSql += " INNER JOIN tbl_membermaster mm ON mm.membercode=lt.membercode ";
                        strSql += " WHERE LoginDate between '" + dtpFromDate.Value.ToString("dd/MMM/yyyy") + "' AND '" + dtpToDate.Value.ToString("dd/MMM/yyyy") + "'";
                        strSql += " ORDER BY LoginDate desc";
                        DataTable dtDetails = objDb.GetDataTable(strSql);
                        FieldLength = new int[] { 150, 150, 150, 150, 200};
                        objGlobal.FillListView(LvwDetails_A, dtDetails, FieldLength);
                    }
                    else
                    {
                        if (txtProfileId.Text == "")
                        {
                            MessageBox.Show("Please Insert Profileid ", "ProfileId Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtProfileId.Focus();
                            return;
                        }
                        strSql = " SELECT mm.profileid,mm.MemberCode,LoginDate,IPAddress,City FROM tbl_LogTable lt";
                        strSql += " INNER JOIN tbl_membermaster mm ON mm.membercode=lt.membercode ";
                        strSql += " WHERE mm.profileid='" + txtProfileId.Text + "' ";
                        strSql += " ORDER BY LoginDate desc";
                        DataTable dtDetails = objDb.GetDataTable(strSql);
                        FieldLength = new int[] { 150, 150, 150, 150, 200 };
                        objGlobal.FillListView(LvwDetails_A, dtDetails, FieldLength);
                    }
                }
                else
                {
                    if (DateWise)
                    {
                        strSql = " SELECT mm.profileid,Count(mm.MemberCode) as TotalCnt FROM tbl_LogTable lt";
                        strSql += " INNER JOIN tbl_membermaster mm ON mm.membercode=lt.membercode ";
                        strSql += " WHERE LoginDate between '" + dtpFromDate.Value.ToString("dd/MMM/yyyy") + "' AND '" + dtpToDate.Value.ToString("dd/MMM/yyyy") + "'";
                        strSql += " group by mm.profileid order by Count(mm.MemberCode) desc ";
                        DataTable dtDetails = objDb.GetDataTable(strSql);
                        FieldLength = new int[] { 150, 150};
                        objGlobal.FillListView(LvwDetails_A, dtDetails, FieldLength);
                    }
                    else
                    {
                        if (txtProfileId.Text == "")
                        {
                            MessageBox.Show("Please Insert Profileid ", "ProfileId Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtProfileId.Focus();
                            return;
                        }
                        strSql = " SELECT mm.profileid,Count(mm.MemberCode) as TotalCnt FROM tbl_LogTable lt";
                        strSql += " INNER JOIN tbl_membermaster mm ON mm.membercode=lt.membercode ";
                        strSql += " WHERE  mm.profileid='" + txtProfileId.Text + "' ";
                        strSql += " group by mm.profileid ";
                        DataTable dtDetails = objDb.GetDataTable(strSql);
                        FieldLength = new int[] { 150, 150 };
                        objGlobal.FillListView(LvwDetails_A, dtDetails, FieldLength);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LogInLog_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
            ((frmMain)base.MdiParent).mnuLoginLog.Enabled = true;
            ((frmMain)base.MdiParent).pnlMain.Visible = true;
        }
    }
}
