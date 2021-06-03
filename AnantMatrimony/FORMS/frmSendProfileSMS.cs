using AnantMatrimony.MatrimonyDAL;
using AnantMatrimony.UD_CLASS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;

namespace AnantMatrimony.FORMS
{
    public partial class frmSendProfileSMS : Form
    {
        public frmSendProfileSMS()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ShowIcon = false;
        }

        string strCaste = "", strEducation = "", strCountry = "", strCity = "", strMaritalStatus = "", strHeight = "", strWeight = "", strIncome = "";
        DataView dvCaste, dvEducation, dvCountry, dvCity, dvMaritalStatus, dvHeight, dvWeight;
        dbInteraction objDb = new dbInteraction();
        Global objGlobal = new Global();
        int[] FieldLength;

        string strSql = "", Caste_Sel = "", Education_Sel = "", State_Sel = "", MaritalStatus_Sel = "", Country_Sel = "", Manglik_Sel = "", Height_Sel = "", Income_Sel = "", Weight_Sel = "";


        private void frmSendProfileSMS_Load(object sender, EventArgs e)
        {
            FillList();
        }

        private void frmSendProfileSMS_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
            ((frmMain)base.MdiParent).mnuSendProfileSMS.Enabled = true;
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

                strEducation = " SELECT 'All' AS Education,0 as ORD,-1 AS EducationCode ";
                strEducation += " UNION ALL ";
                strEducation += " SELECT Education,1 as ORD,EducationCode FROM tbl_Education ORDER BY ORD,Education";
                FieldLength = new int[] { 100, 0, 0 };
                objGlobal.FillListView(LvwEducation, strEducation, FieldLength);

                strCountry = " SELECT 'All' AS Country,0 as ORD,-1 AS CountryCode ";
                strCountry += " UNION ALL ";
                strCountry += " SELECT Country,1 as ORD,CountryCode FROM tbl_Country ORDER BY ORD,Country";
                FieldLength = new int[] { 100, 0, 0 };
                objGlobal.FillListView(LvwCountry, strCountry, FieldLength);

                DataTable dtBornYear = objGlobal.GetYearList(1950, DateTime.Now.Year);
                ddlPAgeFrom.DataSource = dtBornYear;
                ddlPAgeFrom.DisplayMember = "Number";
                ddlPAgeFrom.ValueMember = "NValue";

                DataTable dtToBornYear = objGlobal.GetYearList(1950, DateTime.Now.Year);
                ddlPAgeTo.DataSource = dtToBornYear;
                ddlPAgeTo.DisplayMember = "Number";
                ddlPAgeTo.ValueMember = "NValue";

                string strTemplate = " SELECT '--Select--' AS TemplateName,0 as ORD,-1 AS Template_Id ";
                strTemplate += " UNION ALL ";
                strTemplate += " SELECT TemplateName,1 as ORD,Template_Id from tbl_template_master ORDER BY ORD";
                DataTable dtTemplate = objDb.GetDataTable(strTemplate);
                ddlTemplate.DataSource = dtTemplate;
                ddlTemplate.DisplayMember = "TemplateName";
                ddlTemplate.ValueMember = "Template_Id";

                strMaritalStatus = " SELECT 'All' AS MaritalStatus,0 as ORD,-1 AS MaritalStatusCode ";
                strMaritalStatus += " UNION ALL ";
                strMaritalStatus += " SELECT MaritalStatus,1 as ORD,MaritalStatusCode from tbl_MaritalStatus ORDER BY ORD";
                FieldLength = new int[] { 100, 0, 0 };
                objGlobal.FillListView(LvwMaritalStatus, strMaritalStatus, FieldLength);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_A_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Caste_Sel = "";
                Education_Sel = "";
                State_Sel = "";
                MaritalStatus_Sel = "";
                Country_Sel = "";

                strSql = "";
                strSql += " AND MM.Gender =" + (rdbtnMale.Checked == true ? "0" : "1");
                ////Born Year Condition
                //if (Convert.ToString(ddlPAgeFrom_A.SelectedValue) != Convert.ToString(ddlPAgeTo_A.SelectedValue))
                //{
                strSql += " AND Convert(varchar(4),MM.DateOfBirth,111) Between " + ddlPAgeFrom.Text + " AND " + ddlPAgeTo.Text + "";
                ////Caste Condition
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
                    strSql += " AND MM.Caste in (" + Caste_Sel + ")";
                }
                ////Education Condition
                for (int cnt = 0; cnt < LvwEducation.Items.Count; cnt++)
                {
                    if (LvwEducation.Items[cnt].SubItems[LvwEducation.Columns.Count - 1].Text != "-1")
                    {
                        if (LvwEducation.Items[cnt].Checked)
                        {
                            if (Education_Sel == "")
                            {
                                Education_Sel = LvwEducation.Items[cnt].SubItems[LvwEducation.Columns.Count - 1].Text;
                            }
                            else
                            {
                                Education_Sel += "," + LvwEducation.Items[cnt].SubItems[LvwEducation.Columns.Count - 1].Text;
                            }
                        }
                    }
                }
                if (Education_Sel != "")
                {
                    strSql += " AND MM.Education in (" + Education_Sel + ")";
                }
                ////State Condition
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
                    strSql += " AND MM.StateCity in (" + State_Sel + ")";
                }
                ////MaritalStatus Condition
                for (int cnt = 0; cnt < LvwMaritalStatus.Items.Count; cnt++)
                {
                    if (LvwMaritalStatus.Items[cnt].Checked)
                    {
                        if (MaritalStatus_Sel == "")
                        {
                            MaritalStatus_Sel = LvwMaritalStatus.Items[cnt].SubItems[LvwMaritalStatus.Columns.Count - 1].Text;
                        }
                        else
                        {
                            MaritalStatus_Sel += "," + LvwMaritalStatus.Items[cnt].SubItems[LvwMaritalStatus.Columns.Count - 1].Text;
                        }
                    }
                }
                if (MaritalStatus_Sel != "")
                {
                    strSql += " AND MM.MaritalStatus in (" + MaritalStatus_Sel + ")";
                }
                ////Country Condition
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
                    strSql += " AND MM.Country in (" + Country_Sel + ")";
                }
                if (dtpFromDate.Value.ToString("dd/MMM/yyyy") != dtpToDate.Value.ToString("dd/MMM/yyyy"))
                {
                    strSql += " and MM.RegisterDate between '" + dtpFromDate.Value.ToString("dd/MMM/yyyy") + "' and '" + dtpToDate.Value.ToString("dd/MMM/yyyy") + "'";
                }
                FillGrid(strSql);
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        public void FillGrid(string strCond)
        {
            try
            {
                tbl_MemberMasterBAL objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
                DataSet dsdata = objtbl_MemberMasterBAL.GetMarriedConfirmationList(strCond);
                if (dsdata.Tables[0].Rows.Count > 0)
                {
                    FieldLength = new int[] { 120, 150, 0, 150, 0, 80, 80, 0, 0 };
                    objGlobal.FillListView(LvwDetails, dsdata.Tables[0], FieldLength);
                    lblTotalCnt_A.Text = "Total : " + dsdata.Tables[0].Rows.Count;
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

        private void btnSendSMS_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string[] FromArr;
                string strSlectVal = "";
                for (int cnt = 0; cnt < LvwDetails.Items.Count; cnt++)
                {
                    if (LvwDetails.Items[cnt].Checked)
                    {
                        if (strSlectVal == "")
                        {
                            strSlectVal = LvwDetails.Items[cnt].SubItems[3].Text;
                        }
                        else
                        {
                            strSlectVal += "," + LvwDetails.Items[cnt].SubItems[3].Text;
                        }
                    }
                }
                string[] PhoneArr = strSlectVal.Split(',');
                string _tempPhNo = "";
                bool tThread = false;
                if (PhoneArr.Length > 0)
                {
                    for (int i = 0; i < PhoneArr.Length; i++)
                    {
                        if (_tempPhNo == PhoneArr[i].ToString())
                        {
                            tThread = true;
                        }
                        if (!objGlobal.SendSMS(PhoneArr[i].ToString(), txtMessage.Text, tThread))
                        {
                            break;
                        }
                        _tempPhNo = PhoneArr[i].ToString();
                    }
                }
                Cursor = Cursors.Default;
                MessageBox.Show("Message Sent", "Send Message info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblTotalCnt.Text = "Total : " + (txtMessage.Text.Length).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ddlTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlTemplate.SelectedIndex > 0)
                {
                    strSql = "Select * from tbl_template_master where Template_Id= " + ddlTemplate.SelectedValue;
                    DataTable dtDetails = objDb.GetDataTable(strSql);
                    if (dtDetails.Rows.Count > 0)
                    {
                        txtMessage.Text = Convert.ToString(dtDetails.Rows[0]["TemplateMessage"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCovert_Click(object sender, EventArgs e)
        {
            try
            {
                string URL = "http://thelink.la/api-shorten.php?url=" + txtLink.Text;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URL);
                string urlParameters = "";
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    txtMessage.Text = txtMessage.Text.Replace("[link]", dataObjects);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
