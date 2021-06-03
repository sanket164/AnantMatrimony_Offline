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
    public partial class frmFirstPageEmail : Form
    {
        DataView dvCaste, dvEducation, dvCountry, dvCity, dvMaritalStatus;
        dbInteraction objDb = new dbInteraction();
        Global objGlobal = new Global();
        int[] FieldLength;
        string strCaste = "", strEducation = "", strCountry = "", strCity = "", strMaritalStatus = "", strIncome = "", strHeight = "";
        string strSql = "", Caste_Sel = "", Education_Sel = "", State_Sel = "", MaritalStatus_Sel = "", Country_Sel = "", Manglik_Sel = "", Height_Sel = "", Income_Sel = "", Weight_Sel = "";

        public frmFirstPageEmail()
        {
            InitializeComponent();
        }

        private void frmFirstPageEmail_Load(object sender, EventArgs e)
        {
            FillList();
        }

        public void FillList()
        {
            try
            {
                //strCaste = " SELECT 'All' AS Caste,0 as ORD,0 AS CasteCode";
                //strCaste += " UNION ALL ";
                strCaste = " SELECT Caste,1 as ORD,CasteCode FROM tbl_Caste ORDER BY ORD,Caste";
                DataTable dtCaste = objDb.GetDataTable(strCaste);
                FieldLength = new int[] { 150, 0, 0 };
                objGlobal.FillListView(LvwCaste_A, dtCaste, FieldLength);
                objGlobal.FillListView(LvwCaste_B, dtCaste, FieldLength);

                strEducation += " SELECT Education,1 as ORD,EducationCode FROM tbl_Education ORDER BY ORD,Education";
                DataTable dtEducation = objDb.GetDataTable(strEducation);
                FieldLength = new int[] { 150, 0, 0 };
                objGlobal.FillListView(LvwEducation_A, dtEducation, FieldLength);
                objGlobal.FillListView(LvwEducation_B, dtEducation, FieldLength);


                DataTable dtBornYear = objGlobal.GetYearList(1950, DateTime.Now.Year);
                ddlPAgeFrom_A.DataSource = dtBornYear;
                ddlPAgeFrom_A.DisplayMember = "Number";
                ddlPAgeFrom_A.ValueMember = "NValue";

                ddlPAgeFrom_B.DataSource = dtBornYear.Copy();
                ddlPAgeFrom_B.DisplayMember = "Number";
                ddlPAgeFrom_B.ValueMember = "NValue";

                ddlPAgeTo_A.DataSource = dtBornYear.Copy();
                ddlPAgeTo_A.DisplayMember = "Number";
                ddlPAgeTo_A.ValueMember = "NValue";

                ddlPAgeTo_B.DataSource = dtBornYear.Copy();
                ddlPAgeTo_B.DisplayMember = "Number";
                ddlPAgeTo_B.ValueMember = "NValue";

                strMaritalStatus += " SELECT MaritalStatus,1 as ORD,MaritalStatusCode from tbl_MaritalStatus ORDER BY ORD";
                DataTable dtMaritalStatus = objDb.GetDataTable(strMaritalStatus);
                FieldLength = new int[] { 150, 0, 0 };
                objGlobal.FillListView(LvwMaritalStatus_A, dtMaritalStatus, FieldLength);
                objGlobal.FillListView(LvwMaritalStatus_B, dtMaritalStatus, FieldLength);

                //strCity += " SELECT StateCity,StateCityCode FROM tbl_StateCity ORDER BY StateCity";
                //FieldLength = new int[] { 100, 0 };
                //DataTable dtState = objDb.GetDataTable(strCity);
                //objGlobal.FillListView(LvwState_A, dtState, FieldLength);
                //objGlobal.FillListView(LvwState_B, dtState.Copy(), FieldLength);

                strCountry = " SELECT 'All' AS Country,0 as ORD,-1 AS CountryCode ";
                strCountry += " UNION ALL ";
                strCountry += " SELECT Country,1 as ORD,CountryCode FROM tbl_Country ORDER BY ORD,Country";
                DataTable dtCountry = objDb.GetDataTable(strCountry);
                FieldLength = new int[] { 150, 0, 0 };
                objGlobal.FillListView(LvwCountry_A, dtCountry, FieldLength);
                objGlobal.FillListView(LvwCountry_B, dtCountry, FieldLength);

                strHeight = " select Height,HeightCM from tbl_Height order by HeightCM";
                DataTable dtHeight = objDb.GetDataTable(strHeight);
                FieldLength = new int[] { 150, 0 };
                objGlobal.FillListView(LvwHeight_A, dtHeight, FieldLength);
                objGlobal.FillListView(LvwHeight_B, dtHeight, FieldLength);

                string strManglic = " SELECT 'Yes' as Manglik ,0 as Code ";
                strManglic += " UNION ALL ";
                strManglic += " SELECT 'No' as Manglik,1 as Code ";
                strManglic += " UNION ALL   ";
                strManglic += " SELECT 'Doesn''t Know'  as Manglik,2 as Code";
                DataTable dtManglic = objDb.GetDataTable(strManglic);
                FieldLength = new int[] { 150, 0 };
                objGlobal.FillListView(LvwManglic_A, dtManglic, FieldLength);
                objGlobal.FillListView(LvwManglic_B, dtManglic, FieldLength);

                strIncome += " SELECT AnnualIncome,1 as ORD,AnnualIncomeCode FROM tbl_AnnualIncome ";
                DataTable dtIncome = objDb.GetDataTable(strIncome);
                FieldLength = new int[] { 150, 0, 0 };
                objGlobal.FillListView(LvwIncome_A, dtIncome, FieldLength);
                objGlobal.FillListView(LvwIncome_B, dtIncome, FieldLength);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmFirstPageEmail_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
            ((frmMain)base.MdiParent).mnuFirstPageEmail.Enabled = true;
            ((frmMain)base.MdiParent).pnlMain.Visible = true;
        }

        private void btnSearch_A_Click(object sender, EventArgs e)
        {
            try
            {
                strSql = "";
                strSql += " AND MM.Gender =" + (rdbtnMale_A.Checked == true ? "0" : "1");
                ////Born Year Condition
                //if (Convert.ToString(ddlPAgeFrom_A.SelectedValue) != Convert.ToString(ddlPAgeTo_A.SelectedValue))
                //{
                strSql += " AND Convert(varchar(4),MM.DateOfBirth,111) Between " + ddlPAgeFrom_A.Text + " AND " + ddlPAgeTo_A.Text + "";
                //}
                ////Registration Date Condition
                strSql += " AND RegisterDate between '" + dtpFromDate_A.Value.ToString("dd/MMM/yyyy") + "' AND '" + dtpToDate_A.Value.ToString("dd/MMM/yyyy") + "'";
                ////Caste Condition
                for (int cnt = 0; cnt < LvwCaste_A.Items.Count; cnt++)
                {
                    if (LvwCaste_A.Items[cnt].Checked)
                    {
                        if (Caste_Sel == "")
                        {
                            Caste_Sel = LvwCaste_A.Items[cnt].SubItems[LvwCaste_A.Columns.Count - 1].Text;
                        }
                        else
                        {
                            Caste_Sel += "," + LvwCaste_A.Items[cnt].SubItems[LvwCaste_A.Columns.Count - 1].Text;
                        }
                    }
                }
                if (Caste_Sel != "")
                {
                    strSql += " AND MM.Caste in (" + Caste_Sel + ")";
                }
                ////Education Condition
                for (int cnt = 0; cnt < LvwEducation_A.Items.Count; cnt++)
                {
                    if (LvwEducation_A.Items[cnt].Checked)
                    {
                        if (Education_Sel == "")
                        {
                            Education_Sel = LvwEducation_A.Items[cnt].SubItems[LvwEducation_A.Columns.Count - 1].Text;
                        }
                        else
                        {
                            Education_Sel += "," + LvwEducation_A.Items[cnt].SubItems[LvwEducation_A.Columns.Count - 1].Text;
                        }
                    }
                }
                if (Education_Sel != "")
                {
                    strSql += " AND MM.Education in (" + Education_Sel + ")";
                }
                ////State Condition
                for (int cnt = 0; cnt < LvwState_A.Items.Count; cnt++)
                {
                    if (LvwState_A.Items[cnt].Checked)
                    {
                        if (State_Sel == "")
                        {
                            State_Sel = LvwState_A.Items[cnt].SubItems[LvwState_A.Columns.Count - 1].Text;
                        }
                        else
                        {
                            State_Sel += "," + LvwState_A.Items[cnt].SubItems[LvwState_A.Columns.Count - 1].Text;
                        }
                    }
                }
                if (State_Sel != "")
                {
                    strSql += " AND MM.StateCity in (" + State_Sel + ")";
                }
                ////MaritalStatus Condition
                for (int cnt = 0; cnt < LvwMaritalStatus_A.Items.Count; cnt++)
                {
                    if (LvwMaritalStatus_A.Items[cnt].Checked)
                    {
                        if (MaritalStatus_Sel == "")
                        {
                            MaritalStatus_Sel = LvwMaritalStatus_A.Items[cnt].SubItems[LvwMaritalStatus_A.Columns.Count - 1].Text;
                        }
                        else
                        {
                            MaritalStatus_Sel += "," + LvwMaritalStatus_A.Items[cnt].SubItems[LvwMaritalStatus_A.Columns.Count - 1].Text;
                        }
                    }
                }
                if (MaritalStatus_Sel != "")
                {
                    strSql += " AND MM.MaritalStatus in (" + MaritalStatus_Sel + ")";
                }
                ////Country Condition
                for (int cnt = 0; cnt < LvwCountry_A.Items.Count; cnt++)
                {
                    if (LvwCountry_A.Items[cnt].Checked)
                    {
                        if (Country_Sel == "")
                        {
                            Country_Sel = LvwCountry_A.Items[cnt].SubItems[LvwCountry_A.Columns.Count - 1].Text;
                        }
                        else
                        {
                            Country_Sel += "," + LvwCountry_A.Items[cnt].SubItems[LvwCountry_A.Columns.Count - 1].Text;
                        }
                    }
                }
                if (Country_Sel != "")
                {
                    strSql += " AND MM.Country in (" + Country_Sel + ")";
                }
                ////Income Condition
                for (int cnt = 0; cnt < LvwIncome_A.Items.Count; cnt++)
                {
                    if (LvwIncome_A.Items[cnt].Checked)
                    {
                        if (Income_Sel == "")
                        {
                            Income_Sel = LvwIncome_A.Items[cnt].SubItems[LvwIncome_A.Columns.Count - 1].Text;
                        }
                        else
                        {
                            Income_Sel += "," + LvwIncome_A.Items[cnt].SubItems[LvwIncome_A.Columns.Count - 1].Text;
                        }
                    }
                }
                if (Income_Sel != "")
                {
                    strSql += " AND MM.AnnualIncome in (" + Income_Sel + ")";
                }
                ////Weight Condition
                for (int cnt = 0; cnt < LvwHeight_A.Items.Count; cnt++)
                {
                    if (LvwHeight_A.Items[cnt].Checked)
                    {
                        if (Height_Sel == "")
                        {
                            Height_Sel = LvwHeight_A.Items[cnt].SubItems[LvwHeight_A.Columns.Count - 1].Text;
                        }
                        else
                        {
                            Height_Sel += "," + LvwHeight_A.Items[cnt].SubItems[LvwHeight_A.Columns.Count - 1].Text;
                        }
                    }
                }
                if (Height_Sel != "")
                {
                    strSql += " AND MM.Height in (" + Height_Sel + ")";
                }
                ////Maglik Condition
                for (int cnt = 0; cnt < LvwManglic_A.Items.Count; cnt++)
                {
                    if (LvwManglic_A.Items[cnt].Checked)
                    {
                        if (Manglik_Sel == "")
                        {
                            Manglik_Sel = LvwManglic_A.Items[cnt].SubItems[LvwManglic_A.Columns.Count - 1].Text;
                        }
                        else
                        {
                            Manglik_Sel += "," + LvwManglic_A.Items[cnt].SubItems[LvwManglic_A.Columns.Count - 1].Text;
                        }
                    }
                }
                if (Manglik_Sel != "")
                {
                    strSql += " AND MM.Manglik in (" + Manglik_Sel + ")";
                }
                if (txtFromWeight_A.Text != "" && txtToWeight_A.Text != "")
                {
                    strSql += " AND MM.Weight BETWEEN " + txtFromWeight_A.Text + " AND " + txtToWeight_A.Text;
                }
                FillGrid(strSql, "A");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_B_Click(object sender, EventArgs e)
        {
            try
            {
                strSql = "";
                strSql += " AND MM.Gender =" + (rdbtnMale_B.Checked == true ? "0" : "1");
                ////Birth Year Condition
                //if (Convert.ToString(ddlPAgeFrom_B.SelectedValue) != Convert.ToString(ddlPAgeTo_B.SelectedValue))
                //{
                strSql += " AND Convert(varchar(4),MM.DateOfBirth,111) Between " + ddlPAgeFrom_B.Text + " AND " + ddlPAgeTo_B.Text + "";
                //}
                ////Register Date Condition
                strSql += " AND RegisterDate between '" + dtpFromDate_A.Value.ToString("dd/MMM/yyyy") + "' AND '" + dtpToDate_A.Value.ToString("dd/MMM/yyyy") + "'";
                for (int cnt = 0; cnt < LvwCaste_B.Items.Count; cnt++)
                {
                    if (LvwCaste_B.Items[cnt].Checked)
                    {
                        if (Caste_Sel == "")
                        {
                            Caste_Sel = LvwCaste_B.Items[cnt].SubItems[LvwCaste_B.Columns.Count - 1].Text;
                        }
                        else
                        {
                            Caste_Sel += "," + LvwCaste_B.Items[cnt].SubItems[LvwCaste_B.Columns.Count - 1].Text;
                        }
                    }
                }
                ////Caste Condition
                if (Caste_Sel != "")
                {
                    strSql += " AND MM.Caste in (" + Caste_Sel + ")";
                }
                for (int cnt = 0; cnt < LvwEducation_B.Items.Count; cnt++)
                {
                    if (LvwEducation_B.Items[cnt].Checked)
                    {
                        if (Education_Sel == "")
                        {
                            Education_Sel = LvwEducation_B.Items[cnt].SubItems[LvwEducation_B.Columns.Count - 1].Text;
                        }
                        else
                        {
                            Education_Sel += "," + LvwEducation_B.Items[cnt].SubItems[LvwEducation_B.Columns.Count - 1].Text;
                        }
                    }
                }
                ////Education Condition
                if (Education_Sel != "")
                {
                    strSql += " AND MM.Education in (" + Education_Sel + ")";
                }
                for (int cnt = 0; cnt < LvwState_B.Items.Count; cnt++)
                {
                    if (LvwState_B.Items[cnt].Checked)
                    {
                        if (State_Sel == "")
                        {
                            State_Sel = LvwState_B.Items[cnt].SubItems[LvwState_B.Columns.Count - 1].Text;
                        }
                        else
                        {
                            State_Sel += "," + LvwState_B.Items[cnt].SubItems[LvwState_B.Columns.Count - 1].Text;
                        }
                    }
                }
                if (State_Sel != "")
                {
                    strSql += " AND MM.StateCity in (" + State_Sel + ")";
                }
                ////MaritalStatus Condition
                for (int cnt = 0; cnt < LvwMaritalStatus_B.Items.Count; cnt++)
                {
                    if (LvwMaritalStatus_B.Items[cnt].Checked)
                    {
                        if (MaritalStatus_Sel == "")
                        {
                            MaritalStatus_Sel = LvwMaritalStatus_B.Items[cnt].SubItems[LvwMaritalStatus_B.Columns.Count - 1].Text;
                        }
                        else
                        {
                            MaritalStatus_Sel += "," + LvwMaritalStatus_B.Items[cnt].SubItems[LvwMaritalStatus_B.Columns.Count - 1].Text;
                        }
                    }
                }
                if (MaritalStatus_Sel != "")
                {
                    strSql += " AND MM.MaritalStatus in (" + MaritalStatus_Sel + ")";
                }
                ////Country Condition
                for (int cnt = 0; cnt < LvwCountry_A.Items.Count; cnt++)
                {
                    if (LvwCountry_A.Items[cnt].Checked)
                    {
                        if (Country_Sel == "")
                        {
                            Country_Sel = LvwCountry_A.Items[cnt].SubItems[LvwCountry_A.Columns.Count - 1].Text;
                        }
                        else
                        {
                            Country_Sel += "," + LvwCountry_A.Items[cnt].SubItems[LvwCountry_A.Columns.Count - 1].Text;
                        }
                    }
                }
                if (Country_Sel != "")
                {
                    strSql += " AND MM.Country in (" + Country_Sel + ")";
                }
                ////Income Condition
                for (int cnt = 0; cnt < LvwIncome_A.Items.Count; cnt++)
                {
                    if (LvwIncome_A.Items[cnt].Checked)
                    {
                        if (Income_Sel == "")
                        {
                            Income_Sel = LvwIncome_A.Items[cnt].SubItems[LvwIncome_A.Columns.Count - 1].Text;
                        }
                        else
                        {
                            Income_Sel += "," + LvwIncome_A.Items[cnt].SubItems[LvwIncome_A.Columns.Count - 1].Text;
                        }
                    }
                }
                if (Income_Sel != "")
                {
                    strSql += " AND MM.AnnualIncome in (" + Income_Sel + ")";
                }
                ////Weight Condition
                for (int cnt = 0; cnt < LvwHeight_A.Items.Count; cnt++)
                {
                    if (LvwHeight_A.Items[cnt].Checked)
                    {
                        if (Height_Sel == "")
                        {
                            Height_Sel = LvwHeight_A.Items[cnt].SubItems[LvwHeight_A.Columns.Count - 1].Text;
                        }
                        else
                        {
                            Height_Sel += "," + LvwHeight_A.Items[cnt].SubItems[LvwHeight_A.Columns.Count - 1].Text;
                        }
                    }
                }
                if (Height_Sel != "")
                {
                    strSql += " AND MM.Height in (" + Height_Sel + ")";
                }
                ////Maglik Condition
                for (int cnt = 0; cnt < LvwManglic_A.Items.Count; cnt++)
                {
                    if (LvwManglic_A.Items[cnt].Checked)
                    {
                        if (Manglik_Sel == "")
                        {
                            Manglik_Sel = LvwManglic_A.Items[cnt].SubItems[LvwManglic_A.Columns.Count - 1].Text;
                        }
                        else
                        {
                            Manglik_Sel += "," + LvwManglic_A.Items[cnt].SubItems[LvwManglic_A.Columns.Count - 1].Text;
                        }
                    }
                }
                if (Manglik_Sel != "")
                {
                    strSql += " AND MM.Manglik in (" + Manglik_Sel + ")";
                }
                FillGrid(strSql, "B");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void FillGrid(string strCond, string AorB)
        {
            try
            {
                tbl_MemberMasterBAL objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
                DataSet dsdata = objtbl_MemberMasterBAL.GET_REGISTERED_MEMBER(strCond);
                if (dsdata.Tables[0].Rows.Count > 0)
                {
                    FieldLength = new int[] { 120, 0, 150, 0, 80, 0, 50, 0, 0 };
                    if (AorB == "A")
                    {
                        objGlobal.FillListView(LvwDetails_A, dsdata.Tables[0], FieldLength);
                        lblTotalCnt_A.Text = "Total : " + dsdata.Tables[0].Rows.Count;
                    }
                    else
                    {
                        objGlobal.FillListView(LvwDetails_B, dsdata.Tables[0], FieldLength);
                        lblTotalCnt_B.Text = "Total : " + dsdata.Tables[0].Rows.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAll_A_Click(object sender, EventArgs e)
        {
            objGlobal.LISTVIEWSELECTION(LvwDetails_A, true, false, false);
        }

        private void btnClear_A_Click(object sender, EventArgs e)
        {
            objGlobal.LISTVIEWSELECTION(LvwDetails_A, false, true, false);
        }

        private void btnInvert_A_Click(object sender, EventArgs e)
        {
            objGlobal.LISTVIEWSELECTION(LvwDetails_A, false, false, true);
        }

        private void btnAll_B_Click(object sender, EventArgs e)
        {
            objGlobal.LISTVIEWSELECTION(LvwDetails_B, true, false, false);
        }

        private void btnClear_B_Click(object sender, EventArgs e)
        {
            objGlobal.LISTVIEWSELECTION(LvwDetails_B, false, true, false);
        }

        private void btnInvert_B_Click(object sender, EventArgs e)
        {
            objGlobal.LISTVIEWSELECTION(LvwDetails_B, false, false, true);
        }

        private void btnSendEmail_A_Click(object sender, EventArgs e)
        {
            try
            {
                string[] FromArr, ToArr;
                FromArr = null;
                ToArr = null;
                ////ToArr for Send Mail
                ////FormArr for Design
                string strSlectVal_A = "", strSlectVal_B = "";
                for (int cnt = 0; cnt < LvwDetails_A.Items.Count; cnt++)
                {
                    if (LvwDetails_A.Items[cnt].Checked)
                    {
                        if (strSlectVal_A == "")
                        {
                            strSlectVal_A = LvwDetails_A.Items[cnt].SubItems[1].Text;
                        }
                        else
                        {
                            strSlectVal_A += "|" + LvwDetails_A.Items[cnt].SubItems[1].Text;
                        }
                    }
                }
                if (strSlectVal_A != "")
                {
                    ToArr = strSlectVal_A.Split('|');
                }
                for (int cnt = 0; cnt < LvwDetails_B.Items.Count; cnt++)
                {
                    if (LvwDetails_B.Items[cnt].Checked)
                    {
                        if (strSlectVal_B == "")
                        {
                            strSlectVal_B = LvwDetails_B.Items[cnt].SubItems[1].Text;
                        }
                        else
                        {
                            strSlectVal_B += "|" + LvwDetails_B.Items[cnt].SubItems[1].Text;
                        }
                    }
                }
                if (strSlectVal_B != "")
                {
                    FromArr = strSlectVal_B.Split('|');
                }
                pnlLog.Visible = true;
                CreateEmailDesign(FromArr, ToArr);
                pnlLog.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSendEmail_B_Click(object sender, EventArgs e)
        {

        }

        public string CreateHTML(string[] MemberCodeArr)
        {
            string strHTML = "";
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return strHTML;
        }

        private void LvwCountry_A_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void LvwCountry_B_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                string strCountry_Sel = "";
                for (int cnt = 0; cnt < LvwCountry_B.Items.Count; cnt++)
                {
                    if (LvwCountry_B.Items[cnt].Checked)
                    {
                        if (strCountry_Sel == "")
                        {
                            strCountry_Sel = LvwCountry_B.Items[cnt].SubItems[LvwCountry_B.Columns.Count - 1].Text;
                        }
                        else
                        {
                            strCountry_Sel += "," + LvwCountry_B.Items[cnt].SubItems[LvwCountry_B.Columns.Count - 1].Text;
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
                    objGlobal.FillListView(LvwState_B, strCity, FieldLength);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LvwCountry_A_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                string strCountry_Sel = "";
                for (int cnt = 0; cnt < LvwCountry_A.Items.Count; cnt++)
                {
                    if (LvwCountry_A.Items[cnt].Checked)
                    {
                        if (strCountry_Sel == "")
                        {
                            strCountry_Sel = LvwCountry_A.Items[cnt].SubItems[LvwCountry_A.Columns.Count - 1].Text;
                        }
                        else
                        {
                            strCountry_Sel += "," + LvwCountry_A.Items[cnt].SubItems[LvwCountry_A.Columns.Count - 1].Text;
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
                    objGlobal.FillListView(LvwState_A, strCity, FieldLength);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CreateEmailDesign(string[] ArrDesign, string[] ArrTo)
        {
            try
            {
                if (ArrTo.Length > 0 && ArrDesign.Length > 0)
                {
                    string strHtml = "";
                    strHtml += " <html xmlns='http://www.w3.org/1999/xhtml'> ";
                    strHtml += " <head> ";
                    strHtml += " <meta http-equiv='Content-Type' content='text/html; charset=utf-8' /> ";
                    strHtml += " <title></title> ";
                    strHtml += " <link href='https://fonts.googleapis.com/css?family=Lato:400,500,600,700' rel='stylesheet' /> ";
                    strHtml += " </head> ";
                    strHtml += " <body style='font-family: ' lato',=Lato', sans-serif;background-color=sans-serif;background-color #ffffff;margin=#ffffff;margin 0px;padding=0px;padding 0px;width=0px;width 100%;font-size=100%;font-size 15px;font-weight=15px;font-weight 400;color=400;color #323232;line-height=#323232;line-height 18px;text-align:left;'=18px;text-align:left;'> ";

                    strHtml += " <table width='700px' border='0' align='center' cellpadding='0' cellspacing='0' class='contentbg'> ";
                    strHtml += " <tr><td valign='top'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr> ";
                    strHtml += " <td valign='top' bgcolor='#FFFFFF'><table width='800' border='0' align='center' cellpadding='0' cellspacing='0'> ";
                    strHtml += " <tr><td width='800' height='105' align='left' valign='top'><table width='800' border='0' cellspacing='0' cellpadding='0'> ";
                    strHtml += " <tr><td valign='top' bgcolor='#ca3b3b' style='padding:35px;'><a href='#'><img src='http://www.anantmatrimony.com/images/logo.png' width='349' height='107' alt='logo' style='margin-left: auto;margin-right: auto;' /></a></td> ";
                    strHtml += " </tr></table><table width='800' border='0' cellspacing='0' cellpadding='0'> ";
                    strHtml += " <tr><td width='800' valign='top' style='padding:35px;text-align:center;font-size: 24px;font-weight: 600;color: #ca3b3b;'>Match with your profile</td> ";
                    strHtml += " </tr></table></td></tr></table></td></tr></table></td></tr><tr><td> ";
                    strHtml += " <table width='100%' border='0' cellspacing='0' cellpadding='0'><tr> <td valign='top' bgcolor='#ffffff'> ";
                    strHtml += " <table width='540px' style='margin-left:160px;' border='0' align='center' cellpadding='0' cellspacing='0'> ";
                    for (int cnt = 0; cnt < ArrDesign.Length; cnt++)
                    {
                        //<!--Loop Start-->
                        tbl_MemberMasterBAL objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
                        DataSet dsdata = objtbl_MemberMasterBAL.Load_ProfileList_New(ArrDesign[cnt]);
                        if (dsdata.Tables[0].Rows.Count > 0)
                        {
                            strHtml += " <tr> ";
                            strHtml += " <td width='200' valign='top'> ";
                            strHtml += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
                            strHtml += " <tr> ";
                            strHtml += " <td valign='top' width='100' style='color:#ca3b3b;line-height:24px;'>" + dsdata.Tables[0].Rows[0]["ProfileId"] + "</td> ";
                            strHtml += " </tr>   </table>  </td>  </tr>  <tr> ";
                            strHtml += " <td width='800' valign='top'> ";
                            strHtml += " <table width='100%' border='0' cellspacing='0' cellpadding='0'>  <tr> ";
                            strHtml += " <td valign='top' width='100'><img src='http://www.anantmatrimony.com/MemberPhoto/" + Convert.ToString(dsdata.Tables[0].Rows[0]["PhotoFileName"]) + "' width='166' height='166' alt='sub image' style='display:block;' /></td> ";
                            strHtml += " <td width='700' valign='top'> ";

                            strHtml += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
                            strHtml += " <tr> ";
                            strHtml += " <td valign='top' width='300'> ";
                            strHtml += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";

                            strHtml += " <tr> ";
                            strHtml += " <td> ";
                            strHtml += " <ul> ";
                            strHtml += " <li style='list-style-type: none;line-height: 26px;'>Birth Year: " + Convert.ToString(dsdata.Tables[0].Rows[0]["BirthYear"]) + "</li> ";
                            strHtml += " <li style='list-style-type: none;line-height: 26px;'>Caste: " + Convert.ToString(dsdata.Tables[0].Rows[0]["Caste"]) + "</li> ";
                            strHtml += " <li style='list-style-type: none;line-height: 26px;'>Height: " + Convert.ToString(dsdata.Tables[0].Rows[0]["Height"]) + "</li> ";
                            strHtml += " <li style='list-style-type: none;line-height: 26px;'>Weight: " + Convert.ToString(dsdata.Tables[0].Rows[0]["Weight"]) + "</li> ";
                            strHtml += " <li style='list-style-type: none;line-height: 26px;'>Marital Status : " + Convert.ToString(dsdata.Tables[0].Rows[0]["MaritalStatus"]) + "</li> ";                            

                            strHtml += " </ul> ";
                            strHtml += " </td> ";
                            strHtml += " <td width='400' valign='top'> ";

                            strHtml += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
                            strHtml += " <tr> ";
                            strHtml += " <td valign='top' style='padding-left:30px;'> ";
                            strHtml += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";

                            strHtml += " <tr> ";
                            strHtml += " <td> ";
                            strHtml += " <ul> ";
                            strHtml += " <li style='list-style-type: none;line-height: 26px;'>Education: " + Convert.ToString(dsdata.Tables[0].Rows[0]["Education"]) + "</li> ";
                            strHtml += " <li style='list-style-type: none;line-height: 26px;'>Degree: " + Convert.ToString(dsdata.Tables[0].Rows[0]["Degree"]) + "</li> ";
                            strHtml += " <li style='list-style-type: none;line-height: 26px;'>State / City: " + Convert.ToString(dsdata.Tables[0].Rows[0]["StateCity"]) + "</li> ";
                            strHtml += " <li style='list-style-type: none;line-height: 26px;'>Visa Status: " + Convert.ToString(dsdata.Tables[0].Rows[0]["VisaStatus"]) + "</li> ";
                            strHtml += " <li style='list-style-type: none;line-height: 26px;'>Visa Country: " + Convert.ToString(dsdata.Tables[0].Rows[0]["VisaCountry"]) + "</li> ";
                            strHtml += " </ul> ";
                            strHtml += " </td> ";
                            strHtml += " </tr>  ";
                            strHtml += " </table> ";
                            strHtml += " </td> ";
                            strHtml += " </tr> ";
                            strHtml += " </table> ";
                            strHtml += " </td> ";
                            strHtml += " </tr>  ";
                            strHtml += " </table> ";
                            strHtml += " </td> ";
                            strHtml += " </tr> ";
                            strHtml += " </table> ";
                            //<!--Promotion End-->

                            strHtml += " </td> ";
                            strHtml += " </tr> ";
                            strHtml += " </table> ";
                            strHtml += " </td> ";
                            strHtml += " </tr> ";
                            //<!--Loop END-->
                            //<!--Browse All-->
                        }
                    }
                    strHtml += " <tr><td width='800' valign='top'><table width='650' border='0' cellspacing='0' cellpadding='0' style='padding-top:20px;'> ";
                    strHtml += " <tr><td valign='top' width='500' style='color:#ca3b3b;line-height:24px;text-align:center;font-size:18px;padding-left:50px;'><b><a href='http://www.anantmatrimony.com' target='_blank' style='color:#ca3b3b;'>BROWSE ALL >></a></b></td> ";
                    strHtml += " </tr></table></td></tr><tr> <td valign='top'> <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
                    strHtml += " <tr> <td valign='top'> <table width='600' border='0' align='center' cellpadding='0' cellspacing='0'> <tr> <td valign='top' style='padding:20px 0px;'> ";
                    strHtml += " <table width='500px' border='0' cellspacing='0' cellpadding='0'> <tr>  <td width='800' valign='top'> <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
                    strHtml += " <tr> <td class='footerheading' width='800' valign='top' style='padding-bottom:16px;text-align:center;font-size: 22px;font-weight: 600;color: #323232;line-height: 44px;'>For More Details, Call Us!</td>  ";
                    strHtml += " </tr> <tr> <td width='800' valign='top' style='padding-bottom:16px;border-bottom:1px solid #e8e8e8;font-size: 35px;font-weight: 600;color: #f54d56;line-height: 24px;text-align:center;'>9428412065/9998489093</td> ";
                    strHtml += " </tr> </table> </td> </tr> </table> </td> </tr> </table> </td> </tr> <tr> <td valign='top'> <table width='800' border='0' align='center' cellpadding='0' cellspacing='0'> ";
                    strHtml += " <tr> <td valign='top' style='padding-bottom:33px;'> <table width='100%' border='0' cellspacing='0' cellpadding='0'> <tr> <td width='800' valign='top'> ";
                    strHtml += " <table width='800' border='0' cellspacing='0' cellpadding='0'> <tr> <td valign='top' style='padding-top:21px; padding-bottom:17px;'> ";
                    strHtml += " <table width='100%' border='0' cellspacing='0' cellpadding='0'></table> </td> </tr> <tr>  ";
                    strHtml += " <td valign='top' style='font-size:13px;color:#989797;text-align:center; padding-right:84px;'>  ";
                    strHtml += "  © 2003 - 2019 AnantMatrimony.com & Kankukanya.com. All Rights Reserved.<br /> </td> </tr> </table> </td> </tr> <tr> <td width='150' valign='top'> ";
                    strHtml += "  <table width='100%' border='0' cellspacing='0' cellpadding='0'></table> </td> <td width='150' valign='top'> <table width='100%' border='0' cellspacing='0' cellpadding='0'></table> ";
                    strHtml += "  </td></tr></table></td></tr></table></td></tr></table></td></tr> </table></td></tr></table></td></tr></table></body></html> ";
                    txtMessageLog.Text = "Design Ready";
                    txtMessageLog.Text += Environment.NewLine;
                    txtMessageLog.Text += "Total " + ArrTo.Length + " email going to send";
                    for (int cnt1 = 0; cnt1 < ArrTo.Length; cnt1++)
                    {
                        tbl_MemberMasterBAL objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
                        DataSet dsdata = objtbl_MemberMasterBAL.Load_ProfileList_New(ArrTo[cnt1]);
                        objGlobal.SendMail(Convert.ToString(dsdata.Tables[0].Rows[0]["EmailId"]), "AnantMatrimony : Match with your profile", strHtml, true, "customerservice@anantmatrimony.com", "Changeme@123");
                        txtMessageLog.Text += " >> Mail Number (" + (cnt1 + 1) + ") >> Mail sent on " + Convert.ToString(dsdata.Tables[0].Rows[0]["EmailId"]);
                        txtMessageLog.Text += Environment.NewLine;
                    }
                }
                MessageBox.Show("Mail Send", "Mail send", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
