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
    public partial class frmSetting : Form
    {
        public frmSetting()
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

        private void txtAgeDiff_KeyPress(object sender, KeyPressEventArgs e)
        {
            objGlobal.onlyNumber(sender, e, false);
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            try
            {
                strSql = "exec SelectCombo_tbl_MaritalStatus ''";
                DataTable dtMaritalStatus = objDb.GetDataTable(strSql);
                chkPMaritalStatus.DataSource = dtMaritalStatus;
                chkPMaritalStatus.ValueMember = "MaritalStatusCode";
                chkPMaritalStatus.DisplayMember = "MaritalStatus";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmSetting_Activated(object sender, EventArgs e)
        {
            objGlobal.FocusColor(this);
        }

        private void frmSetting_Deactivate(object sender, EventArgs e)
        {

        }

        private void frmSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
            ((frmMain)base.MdiParent).mnuMemberSetting.Enabled = true;
            ((frmMain)base.MdiParent).pnlMain.Visible = true;
        }

        private void txtProfileId_TextChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            try
            {
                string strPartnerData = "";
                for (int i = 0; i < chkPMaritalStatus.CheckedItems.Count; i++)
                {
                    strPartnerData += ((System.Data.DataRowView)(chkPMaritalStatus.CheckedItems[i])).Row.ItemArray[0] + ",";
                }
                strPartnerData = strPartnerData.TrimEnd(',');
                strSql = "UPDATE tbl_membermaster SET AgeDiff=" + txtAgeDiff.Text + ", MStatus_Preference='" + strPartnerData + "' WHERE ProfileId='" + txtProfileId.Text + "'";
                if (objDb.ExecuteNonQuery(strSql) > 0)
                {
                    MessageBox.Show("Setting Updated", "Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAgeDiff.Text = "";
                    txtProfileId.Text = "";
                    for (int i = 0; i < chkPMaritalStatus.Items.Count; i++)
                    {
                        chkPMaritalStatus.SetItemCheckState(i, CheckState.Unchecked);
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProfileId.Text != "")
                {
                    strSql = " Select * from tbl_MemberMaster where profileid='" + txtProfileId.Text + "'";
                    DataTable dtDetails = objDb.GetDataTable(strSql);
                    if (dtDetails.Rows.Count > 0)
                    {
                        txtAgeDiff.Text = Convert.ToString(dtDetails.Rows[0]["AgeDiff"]);
                        string MStatus_Preference = Convert.ToString(dtDetails.Rows[0]["MStatus_Preference"]);
                        string[] PartnerData;
                        PartnerData = MStatus_Preference.Split(',');
                        for (int i = 0; i < chkPMaritalStatus.Items.Count; i++)
                        {
                            if (PartnerData.Contains(((System.Data.DataRowView)(chkPMaritalStatus.Items[i])).Row.ItemArray[0].ToString()))
                                chkPMaritalStatus.SetItemCheckState(i, CheckState.Checked);
                            else
                                chkPMaritalStatus.SetItemCheckState(i, CheckState.Unchecked);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtProfileId_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtProfileId.Text != "")
                {
                    strSql = " Select * from tbl_MemberMaster where profileid='" + txtProfileId.Text + "'";
                    DataTable dtDetails = objDb.GetDataTable(strSql);
                    if (dtDetails.Rows.Count > 0)
                    {
                        txtAgeDiff.Text = Convert.ToString(dtDetails.Rows[0]["AgeDiff"]);
                        string MStatus_Preference = Convert.ToString(dtDetails.Rows[0]["MStatus_Preference"]);
                        string[] PartnerData;
                        PartnerData = MStatus_Preference.Split(',');
                        for (int i = 0; i < chkPMaritalStatus.Items.Count; i++)
                        {
                            if (PartnerData.Contains(((System.Data.DataRowView)(chkPMaritalStatus.Items[i])).Row.ItemArray[0].ToString()))
                                chkPMaritalStatus.SetItemCheckState(i, CheckState.Checked);
                            else
                                chkPMaritalStatus.SetItemCheckState(i, CheckState.Unchecked);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
