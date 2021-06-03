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
    public partial class frmMobileNoUpdate : Form
    {
        string strProfileCreatedBy = "";
        EventLogging objEventLoging = new EventLogging();
        Global objGlobal = new Global();
        ToolbarPositions TpLast;
        dbInteraction objDb = new dbInteraction();
        string strSql = "";

        public enum CI
        {
            Edit = 0,
            MemberCode,
            ProfileId,
            MobileNo1,
            MobileNo1_Rel,
            MobileNo2,
            MobileNo2_Rel,
            MobileNo3,
            MobileNo3_Rel,
            MobileNo4,
            MobileNo4_Rel,
            EX,
            EX1
        }

        public frmMobileNoUpdate()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMobileNo.Text == "")
                {
                    MessageBox.Show("Please Enter Mobile number1", "Mobile Number1 validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMobileNo.Focus();
                    return;
                }
                else
                {
                    if (Convert.ToInt32(ddlMobileNo_Rel.SelectedValue) <= 0)
                    {
                        MessageBox.Show("Please Select Mobile Number 1 Relation", "Mobile Number 1 validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ddlMobileNo_Rel.Focus();
                        return;
                    }
                }
                if (txtMobileNo1.Text == "")
                {
                    MessageBox.Show("Please Enter Mobile number2", "Mobile Number2 validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMobileNo1.Focus();
                    return;
                }
                else
                {
                    if (Convert.ToInt32(ddlMobileNo1_Rel.SelectedValue) <= 0)
                    {
                        MessageBox.Show("Please Select Mobile Number 2 Relation", "Mobile Number 2 validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ddlMobileNo_Rel.Focus();
                        return;
                    }
                }

                if (txtLandlineNo.Text != "")
                {
                    if (Convert.ToInt32(ddlMobileNo2_Rel.SelectedValue) <= 0)
                    {
                        MessageBox.Show("Please Select Mobile Number 3 Relation", "Mobile Number 3 validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ddlMobileNo2_Rel.Focus();
                        return;
                    }
                }
                if (txtLandlineNo1.Text != "")
                {
                    if (Convert.ToInt32(ddlLandlineNo1_Rel.SelectedValue) <= 0)
                    {
                        MessageBox.Show("Please Select Mobile Number 4 Relation", "Mobile Number 4 validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ddlLandlineNo1_Rel.Focus();
                        return;
                    }
                }
                if (lblMemberCode.Text != "")
                {
                    strSql = " UPDATE tbl_membermaster SET MobileNo='" + txtMobileNo.Text.Trim() + "' , MobileNo_Rel='" + ddlMobileNo_Rel.Text + "'";
                    if (txtMobileNo1.Text.Trim() != "")
                    {
                        strSql += " , MobileNo1='" + txtMobileNo1.Text.Trim() + "' , MobileNo1_Rel='" + ddlMobileNo1_Rel.Text + "'";
                    }
                    if (txtLandlineNo.Text.Trim() != "")
                    {
                        strSql += " , LandlineNo='" + txtLandlineNo.Text.Trim() + "' , MobileNo2_Rel='" + ddlMobileNo2_Rel.Text + "'";
                    }
                    if (txtLandlineNo1.Text.Trim() != "")
                    {
                        strSql += " , LandlineNo1='" + txtLandlineNo1.Text.Trim() + "' , LandlineNo1_Rel='" + ddlLandlineNo1_Rel.Text + "'";
                    }

                    strSql += " WHERE MemberCode=" + lblMemberCode.Text;
                    int Res = objDb.ExecuteNonQuery(strSql);
                    if (Res > 0)
                    {
                        MessageBox.Show(txtProfileId.Text + " Contact Details Updated", "Mobile Number 4 validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblMemberCode.Text = "";
                        txtLandlineNo.Text = "";
                        txtLandlineNo1.Text = "";
                        txtMobileNo.Text = "";
                        txtMobileNo1.Text = "";
                        txtProfileId.Text = "";
                        FillGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
            }
        }

        private void frmMobileNoUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                GridDesign(dgvDetails);
                strProfileCreatedBy += " SELECT 0 AS ProfileCreatedByCode,'--SELECT--' AS ProfileCreatedBy";
                strProfileCreatedBy += " UNION ALL ";
                strProfileCreatedBy += "SELECT ProfileCreatedByCode,ProfileCreatedBy FROM tbl_ProfileCreatedBy ORDER BY ProfileCreatedBy";
                DataTable dtProfileCreated = objDb.GetDataTable(strProfileCreatedBy);

                ddlMobileNo_Rel.DataSource = dtProfileCreated.Copy();
                ddlMobileNo_Rel.DisplayMember = "ProfileCreatedBy";
                ddlMobileNo_Rel.ValueMember = "ProfileCreatedByCode";

                ddlMobileNo1_Rel.DataSource = dtProfileCreated.Copy();
                ddlMobileNo1_Rel.DisplayMember = "ProfileCreatedBy";
                ddlMobileNo1_Rel.ValueMember = "ProfileCreatedByCode";

                ddlMobileNo2_Rel.DataSource = dtProfileCreated.Copy();
                ddlMobileNo2_Rel.DisplayMember = "ProfileCreatedBy";
                ddlMobileNo2_Rel.ValueMember = "ProfileCreatedByCode";

                ddlLandlineNo1_Rel.DataSource = dtProfileCreated.Copy();
                ddlLandlineNo1_Rel.DisplayMember = "ProfileCreatedBy";
                ddlLandlineNo1_Rel.ValueMember = "ProfileCreatedByCode";

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

                FillGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMobileNoUpdate.frmMobileNoUpdate_Load() " + ex.ToString());
            }
        }

        private void frmMobileNoUpdate_Activated(object sender, EventArgs e)
        {

        }

        private void frmMobileNoUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
            ((frmMain)base.MdiParent).mnuMobileNoUpdate.Enabled = true;
            ((frmMain)base.MdiParent).pnlMain.Visible = true;
        }

        public void GridDesign(DataGridView dgv)
        {
            try
            {
                int index = 0;
                //dgv.TopLeftHeaderCell.Value = "SrNo.";
                //dgv.RowHeadersWidth = 50;
                dgv.RowHeadersVisible = false;
                int btnCounter = 0;
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToDeleteRows = false;
                dgv.EditMode = DataGridViewEditMode.EditOnEnter;
                DataGridViewTextBoxColumn[] columnArray = new DataGridViewTextBoxColumn[20];
                DataGridViewButtonColumn grdButton;
                string[] strArray = new string[] { 
                "Edit","MemberCode","Profile Id", "Mobile 1","Mobile 1 Rel", "Mobile 2","Mobile 2 Rel", "Mobile 3","Mobile 3 Rel", "Mobile 4","Mobile 4 Rel","Ex","Ex1"
            };
                int[] numArray = new int[] { 
                80,0,100, 100,100, 100, 100,100,100, 100, 100, 0, 0
            };
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i] == "Edit")
                    {
                        grdButton = new DataGridViewButtonColumn();
                        grdButton.HeaderText = strArray[i];
                        grdButton.Width = numArray[i];
                        grdButton.FlatStyle = FlatStyle.Popup;
                        dgv.Columns.Add(grdButton);
                        btnCounter = btnCounter + 1;
                    }
                    else
                    {
                        columnArray[index] = new DataGridViewTextBoxColumn();
                        columnArray[index].HeaderText = strArray[i];
                        columnArray[index].Width = numArray[i];
                        dgv.Columns.Add(columnArray[index]);
                        dgv.Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;
                        index++;
                    }
                }
                dgv.Columns[(int)CI.EX].Visible = false;
                dgv.Columns[(int)CI.EX1].Visible = false;

                dgv.ReadOnly = true;

                dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                dgv.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                dgv.EditMode = DataGridViewEditMode.EditOnEnter;
                dgv.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
                dgv.DefaultCellStyle.ForeColor = Color.Blue;
                dgv.DefaultCellStyle.BackColor = SystemColors.Control;
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMobileNoUpdate.GridDesign() " + exception.ToString());
            }
        }

        public void FillGrid()
        {
            try
            {
                strSql = "  SELECT TOP 1000 MemberCode,ProfileId,MobileNo,MobileNo_Rel,MobileNo1,MobileNo1_Rel,LandlineNo,MobileNo2_Rel,LandlineNo1,LandlineNo1_Rel FROM tbl_membermaster WHERE isnull(MobileNo_Rel,'')='' ";
                strSql += " AND IsActive IN (1,2) ";
                strSql += " AND Gender =" + (rdbtnMale.Checked == true ? "0" : "1");
                if (Convert.ToString(ddlPAgeFrom.SelectedValue) != Convert.ToString(ddlPAgeTo.SelectedValue))
                {
                    strSql += " AND Convert(varchar(4),DateOfBirth,111) Between " + ddlPAgeFrom.Text + " AND " + ddlPAgeTo.Text + "";
                }
                if (Convert.ToInt32(ddlCaste.SelectedValue) > 0)
                {
                    strSql += " AND Caste = " + ddlCaste.SelectedValue;
                }
                DataTable dtDetails = objDb.GetDataTable(strSql);
                if (dtDetails.Rows.Count > 0)
                {
                    lblTotalCnt.Text = Convert.ToString(dtDetails.Rows.Count);
                    dgvDetails.RowCount = dtDetails.Rows.Count;
                    for (int cnt = 0; cnt < dtDetails.Rows.Count; cnt++)
                    {
                        dgvDetails[(int)CI.MemberCode, cnt].Value = Convert.ToString(dtDetails.Rows[cnt]["MemberCode"]);
                        dgvDetails[(int)CI.ProfileId, cnt].Value = Convert.ToString(dtDetails.Rows[cnt]["ProfileId"]);
                        dgvDetails[(int)CI.Edit, cnt].Value = Convert.ToString("EDIT");
                        dgvDetails[(int)CI.MobileNo1, cnt].Value = Convert.ToString(dtDetails.Rows[cnt]["MobileNo"]);
                        dgvDetails[(int)CI.MobileNo1_Rel, cnt].Value = Convert.ToString(dtDetails.Rows[cnt]["MobileNo_Rel"]);
                        dgvDetails[(int)CI.MobileNo2, cnt].Value = Convert.ToString(dtDetails.Rows[cnt]["MobileNo1"]);
                        dgvDetails[(int)CI.MobileNo2_Rel, cnt].Value = Convert.ToString(dtDetails.Rows[cnt]["MobileNo1_Rel"]);
                        dgvDetails[(int)CI.MobileNo3, cnt].Value = Convert.ToString(dtDetails.Rows[cnt]["LandlineNo"]);
                        dgvDetails[(int)CI.MobileNo3_Rel, cnt].Value = Convert.ToString(dtDetails.Rows[cnt]["MobileNo2_Rel"]);
                        dgvDetails[(int)CI.MobileNo4, cnt].Value = Convert.ToString(dtDetails.Rows[cnt]["LandlineNo1"]);
                        dgvDetails[(int)CI.MobileNo4_Rel, cnt].Value = Convert.ToString(dtDetails.Rows[cnt]["LandlineNo1_Rel"]);
                    }
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
                FillGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int intRowNo = e.RowIndex;
                string strCode = Convert.ToString(dgvDetails[(int)CI.MemberCode, e.RowIndex].Value);
                if (e.ColumnIndex == (int)CI.Edit)
                {
                    lblMemberCode.Text = Convert.ToString(dgvDetails[(int)CI.MemberCode, e.RowIndex].Value);
                    txtProfileId.Text = Convert.ToString(dgvDetails[(int)CI.ProfileId, e.RowIndex].Value);
                    txtMobileNo.Text = Convert.ToString(dgvDetails[(int)CI.MobileNo1, e.RowIndex].Value);
                    txtMobileNo1.Text = Convert.ToString(dgvDetails[(int)CI.MobileNo2, e.RowIndex].Value);
                    txtLandlineNo1.Text = Convert.ToString(dgvDetails[(int)CI.MobileNo3, e.RowIndex].Value);
                    txtLandlineNo.Text = Convert.ToString(dgvDetails[(int)CI.MobileNo4, e.RowIndex].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
