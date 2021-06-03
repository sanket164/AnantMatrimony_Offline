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
using AnantMatrimony.MatrimonyDAL;
using AnantMatrimony.AnantProp;
using AnantMatrimony.MatrimonyBAL;
using System.Net;
using System.IO;

namespace AnantMatrimony.FORMS
{
    public partial class frmMemberMaster : Form, ICommonFunctions
    {
        public static int isActiveStatus;
        public static string strMemberCode = "";
        public frmMemberMaster()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ShowIcon = true;
        }

        private int PhotoExists = 0;

        public enum CI
        {
            Edit = 0,
            Delete,
            SerialNo,
            StartDate,
            MembershipMonth,
            EndDate,
            MemberShipTypeCode,
            MemberShipType,
            AmountReceived,
            PayBy,
            ChequeNo,
            ChequeDate,
            BankDetail,
            EX,
            EX1
        }

        public enum BS
        {
            BroSis = 0,
            Name,
            Occupation,
            MaritalStatus,
            Edit,
            Delete,
            ID,
            Ex,
            EX1
        }

        public enum FL
        {
            Edit = 0,
            Delete,
            FollowUpId,
            ProfileId,
            Name,
            Date,
            Status,
            Remark1,
            Remark2,
            Remark3,
            Remark4,
            Remark5,
            EX
        }

        EventLogging objEventLoging = new EventLogging();
        Global objGlobal = new Global();
        ToolbarPositions TpLast;
        dbInteraction objDb = new dbInteraction();
        bool IsEdit = false;

        string strSQL = "";
        int RowNo = 0;
        bool isValid = false;
        //string strCode = "";
        string strCaste = "", strSubCaste = "", strBloodGrp = "", strCountry = "", strStateCity = "", strVisaStatus = "", strEducation = "", strOccupation = "",
            strProfileCreatedBy = "", strMemberShipType = "";
        DataView dvCaste, dvSubCaste, dvBloodGrp, dvCountry, dvSateCity, dvVisaStatus, dvEducation, dvOccupation, dvProfileCreatedBy, dvMemberShipType;
        DataTable dtMobileNo_Rel, dtMobileNo1_Rel, dtMobileNo2_Rel, dtMobileNo3_Rel;
        ContextMenu cnxMenu = new ContextMenu();


        private void frmMemberMaster_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                //this.TpLast = ToolbarPositions.eTPOk;
                //((frmMain)base.MdiParent).setControlState(false, true, this);
                ddlNoOfChildren.Enabled = true;
                ddlLiveChildrenTogether.Enabled = true;
                GridDesign(dgvMemershipDetails);
                GridDesignSubblings(dgvSiblingDetails);
                GridDesign_FollowUp(dgvFollowUpList);
                GetHelpList();
                FillCombo();
                //dgvFollowUpList.Rows.Add();
                if (strMemberCode != "")
                {
                    FillPartnerPrefBirthYear();
                    DisplalyData(strMemberCode);
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCaste.frmCaste_Load() " + ex.ToString());
            }
        }

        private void GetHelpList()
        {
            try
            {
                strBloodGrp = " SELECT 0 AS BloodGroupCode,'--SELECT--' AS BloodGroup";
                strBloodGrp += " UNION ALL ";
                strBloodGrp += " SELECT BloodGroupCode,BloodGroup FROM tbl_BloodGroup ORDER BY BloodGroup";
                dvBloodGrp = objDb.GetDataView(strBloodGrp);
                ddlBloodGroup.DataSource = dvBloodGrp;
                ddlBloodGroup.DisplayMember = "BloodGroup";
                ddlBloodGroup.ValueMember = "BloodGroupCode";

                strCaste = " SELECT 0 AS CasteCode,'--SELECT--' AS Caste";
                strCaste += " UNION ALL ";
                strCaste += "SELECT CasteCode,Caste FROM tbl_Caste ORDER BY Caste";
                dvCaste = objDb.GetDataView(strCaste);
                ddlCaste.DataSource = dvCaste;
                ddlCaste.DisplayMember = "Caste";
                ddlCaste.ValueMember = "CasteCode";


                strCountry = " SELECT 0 AS CountryCode,'--SELECT--' AS Country";
                strCountry += " UNION ALL ";
                strCountry += "SELECT CountryCode,Country FROM tbl_Country ORDER BY Country";
                dvCountry = objDb.GetDataView(strCountry);
                ddlCountry.DataSource = dvCountry;
                ddlCountry.DisplayMember = "Country";
                ddlCountry.ValueMember = "CountryCode";

                //DataView dvVisaCountry = objDb.GetDataView(strCountry);
                ddlVisaCountry.DataSource = dvCountry.Table.Copy();
                ddlVisaCountry.DisplayMember = "Country";
                ddlVisaCountry.ValueMember = "CountryCode";


                strEducation = " SELECT 0 AS EducationCode,'--SELECT--' AS Education";
                strEducation += " UNION ALL ";
                strEducation += "SELECT EducationCode,Education FROM tbl_Education ORDER BY Education";
                dvEducation = objDb.GetDataView(strEducation);
                ddlEducation.DataSource = dvEducation;
                ddlEducation.DisplayMember = "Education";
                ddlEducation.ValueMember = "EducationCode";


                //strStateCity = "SELECT StateCityCode,StateCity FROM tbl_StateCity WHERE CountryCode=" + txtCountryCode.Text + " ORDER BY StateCity";
                //dvSateCity = objDb.GetDataView(strStateCity);

                strOccupation = " SELECT 0 AS OccupationCode,'--SELECT--' AS Occupation";
                strOccupation += " UNION ALL ";
                strOccupation += "SELECT OccupationCode,Occupation FROM tbl_Occupation ORDER BY Occupation";
                dvOccupation = objDb.GetDataView(strOccupation);
                ddlOccupation.DataSource = dvOccupation;
                ddlOccupation.DisplayMember = "Occupation";
                ddlOccupation.ValueMember = "OccupationCode";

                strVisaStatus += " SELECT 0 AS VisaStatusCode,'--SELECT--' AS VisaStatus";
                strVisaStatus += " UNION ALL ";
                strVisaStatus += "SELECT VisaStatusCode,VisaStatus FROM tbl_VisaStatus ORDER BY VisaStatus";
                dvVisaStatus = objDb.GetDataView(strVisaStatus);
                ddlVisaStatus.DataSource = dvVisaStatus;
                ddlVisaStatus.DisplayMember = "VisaStatus";
                ddlVisaStatus.ValueMember = "VisaStatusCode";

                strProfileCreatedBy += " SELECT 0 AS ProfileCreatedByCode,'--SELECT--' AS ProfileCreatedBy";
                strProfileCreatedBy += " UNION ALL ";
                strProfileCreatedBy += "SELECT ProfileCreatedByCode,ProfileCreatedBy FROM tbl_ProfileCreatedBy ORDER BY ProfileCreatedBy";
                dvProfileCreatedBy = objDb.GetDataView(strProfileCreatedBy);

                ddlProfileCreatedBy.DataSource = dvProfileCreatedBy;
                ddlProfileCreatedBy.DisplayMember = "ProfileCreatedBy";
                ddlProfileCreatedBy.ValueMember = "ProfileCreatedByCode";
                dtMobileNo_Rel = dvProfileCreatedBy.Table.Copy();
                dtMobileNo1_Rel = dtMobileNo_Rel.Copy();
                dtMobileNo2_Rel = dtMobileNo_Rel.Copy();
                dtMobileNo3_Rel = dtMobileNo_Rel.Copy();


                strMemberShipType = " select MembershipTypeCode,MembershipType from tbl_MembershipType ";
                dvMemberShipType = objDb.GetDataView(strMemberShipType);

                strStateCity = " SELECT 0 AS StateCityCode,'--SELECT--' AS StateCity,0 as ORD";
                strStateCity += " UNION ALL ";
                strStateCity += "SELECT StateCityCode,StateCity,1 as ORD FROM tbl_StateCity ORDER BY ORD,StateCity";
                dvSateCity = objDb.GetDataView(strStateCity);
                ddlWorkAddress.DataSource = dvSateCity;
                ddlWorkAddress.DisplayMember = "StateCity";
                ddlWorkAddress.ValueMember = "StateCityCode";


                //DataSet ds = new DataSet();
                //DataRow drNew = ds.Tables[0].NewRow();
                //drNew["Caste"] = "All";
                //drNew["CasteCode"] = "-1";

                //ds.Tables[0].Rows.InsertAt(drNew, 0);
                //ds.Tables.Add(dvCaste.ToTable());

                strCaste = " SELECT 0 AS CasteCode,'All' AS Caste,0 as ORD";
                strCaste += " UNION ALL ";
                strCaste += "SELECT CasteCode,Caste,1 as ORD FROM tbl_Caste ORDER BY ORD,Caste";
                dvCaste = objDb.GetDataView(strCaste);
                chkPCaste.DataSource = dvCaste;
                chkPCaste.DisplayMember = "Caste";
                chkPCaste.ValueMember = "CasteCode";

                strEducation = " SELECT 0 AS EducationCode,'All' AS Education,0 as ORD";
                strEducation += " UNION ALL ";
                strEducation += "SELECT EducationCode,Education,1 as ORD FROM tbl_Education ORDER BY ORD,Education";
                dvEducation = objDb.GetDataView(strEducation);
                chkPEducation.DataSource = dvEducation;
                chkPEducation.DisplayMember = "Education";
                chkPEducation.ValueMember = "EducationCode";

                strCountry = " SELECT 0 AS CountryCode,'All' AS Country,0 as ORD";
                strCountry += " UNION ALL ";
                strCountry += "SELECT CountryCode,Country,1 as ORD FROM tbl_Country ORDER BY ORD,Country";
                dvCountry = objDb.GetDataView(strCountry);
                chkPCountryLivingIn.DataSource = dvCountry;
                chkPCountryLivingIn.DisplayMember = "Country";
                chkPCountryLivingIn.ValueMember = "CountryCode";

                //chkPMaritalStatus
                strOccupation = " SELECT 0 AS OccupationCode,'All' AS Occupation,0 as ORD";
                strOccupation += " UNION ALL ";
                strOccupation += "SELECT OccupationCode,Occupation,1 as ORD FROM tbl_Occupation ORDER BY ORD,Occupation";
                dvOccupation = objDb.GetDataView(strOccupation);
                chkPOccupation.DataSource = dvOccupation;
                chkPOccupation.DisplayMember = "Occupation";
                chkPOccupation.ValueMember = "OccupationCode";

                strVisaStatus = " SELECT 0 AS VisaStatusCode,'All' AS VisaStatus,0 as ORD";
                strVisaStatus += " UNION ALL ";
                strVisaStatus += "SELECT VisaStatusCode,VisaStatus,1 as ORD FROM tbl_VisaStatus ORDER BY ORD,VisaStatus";
                dvVisaStatus = objDb.GetDataView(strVisaStatus);
                chkPVisaStatus.DataSource = dvVisaStatus;
                chkPVisaStatus.DisplayMember = "VisaStatus";
                chkPVisaStatus.ValueMember = "VisaStatusCode";

                //strSQL = " SELECT 0 AS MaritalStatusCode,'All' AS MaritalStatus,0 as ORD";
                //strSQL += " UNION ALL ";
                //strSQL += "select MaritalStatusCode,MaritalStatus,1 as ORD from tbl_MaritalStatus order by ORD";


                strSQL = " SELECT 0 AS WorkingWithCode,'All' AS WorkingWith,0 as ORD";
                strSQL += " UNION ALL ";
                strSQL += "select WorkingWithCode,WorkingWith,1 as ORD from tbl_WorkingWith order by ORD,WorkingWith";
                DataTable dtWorkingWith = objDb.GetDataTable(strSQL);
                chkPWorkingWith.DataSource = dtWorkingWith;
                chkPWorkingWith.ValueMember = "WorkingWithCode";
                chkPWorkingWith.DisplayMember = "WorkingWith";

                strSQL = "select distinct ltrim(BirthPlace) as BirthPlace from tbl_memberMaster order by BirthPlace";
                DataTable dtBirthPlace = objDb.GetDataTable(strSQL);
                cmbBirthPlace.DataSource = dtBirthPlace;
                cmbBirthPlace.DisplayMember = "BirthPlace";
                cmbBirthPlace.ValueMember = "BirthPlace";

                strSQL = "select distinct ltrim(Degree) as Degree from tbl_Membermaster  order by Degree ";
                DataTable dtDegree = objDb.GetDataTable(strSQL);
                cmbDegree.DataSource = dtDegree;
                cmbDegree.DisplayMember = "Degree";
                cmbDegree.ValueMember = "Degree";

                strSQL = "select distinct ltrim(OccupationDtls) as OccupationDtls from tbl_Membermaster  order by OccupationDtls ";
                DataTable dtOccupationDtls = objDb.GetDataTable(strSQL);
                cmbOccupationDtls.DataSource = dtOccupationDtls;
                cmbOccupationDtls.DisplayMember = "OccupationDtls";
                cmbOccupationDtls.ValueMember = "OccupationDtls";

                strSQL = " select distinct ltrim(FatherOccupation) as Occupation from tbl_Membermaster  ";
                strSQL += " UNION ALL ";
                strSQL += " select distinct ltrim(MotherOccupation) as Occupation from tbl_Membermaster  ";
                strSQL += " UNION ALL ";
                strSQL += " select distinct ltrim(Occupation) as Occupation from tbl_SibblingDetails order by Occupation ";
                DataTable dtFatherOccupation = objDb.GetDataTable(strSQL);
                cmbFatherOccupation.DataSource = dtFatherOccupation;
                cmbFatherOccupation.DisplayMember = "Occupation";
                cmbFatherOccupation.ValueMember = "Occupation";
                cmbFatherOccupation.SelectedValue = "";

                //strSQL = "select distinct ltrim(MotherOccupation) as MotherOccupation from tbl_Membermaster  order by MotherOccupation ";
                //DataTable dtMotherOccupation = objDb.GetDataTable(strSQL);
                cmbMotherOccupation.DataSource = dtFatherOccupation.Copy();
                cmbMotherOccupation.DisplayMember = "Occupation";
                cmbMotherOccupation.ValueMember = "Occupation";

                //strSQL = "";
                //DataTable dtOccupation = objDb.GetDataTable(strSQL);
                cmbBroSisOccupation.DataSource = dtFatherOccupation.Copy();
                cmbBroSisOccupation.DisplayMember = "Occupation";
                cmbBroSisOccupation.ValueMember = "Occupation";
                cmbBroSisOccupation.SelectedValue = "";

                strSQL = "select distinct ltrim(MosalPlace) as MosalPlace from tbl_Membermaster  order by MosalPlace";
                DataTable dtMosalPlace = objDb.GetDataTable(strSQL);
                cmbMosalPlace.DataSource = dtMosalPlace;
                cmbMosalPlace.DisplayMember = "MosalPlace";
                cmbMosalPlace.ValueMember = "MosalPlace";

                strSQL = "select distinct NativePlace from tbl_Membermaster order by NativePlace ";
                DataTable dtNativePlace = objDb.GetDataTable(strSQL);
                cmbNativePlace.DataSource = dtNativePlace;
                cmbNativePlace.DisplayMember = "NativePlace";
                cmbNativePlace.ValueMember = "NativePlace";

                strSQL = "select distinct ltrim(Choice) as Choice from tbl_Membermaster order by Choice";
                DataTable dtChoice = objDb.GetDataTable(strSQL);
                cmbChoice.DataSource = dtChoice;
                cmbChoice.DisplayMember = "Choice";
                cmbChoice.ValueMember = "Choice";
                cmbChoice.SelectedValue = "";

                strSQL = "select distinct ltrim(Remarks) as Remarks from tbl_Membermaster order by Remarks";
                DataTable dtRemarks = objDb.GetDataTable(strSQL);
                cmdRemark.DataSource = dtRemarks;
                cmdRemark.DisplayMember = "Remarks";
                cmdRemark.ValueMember = "Remarks";
                cmdRemark.SelectedValue = "";


            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCaste.GetHelpList() " + ex.ToString());
            }
        }

        private void frmMemberMaster_Activated(object sender, EventArgs e)
        {
            try
            {
                //((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                //this.AutoValidate = AutoValidate.EnableAllowFocusChange;
                objGlobal.FocusColor(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCaste.frmCaste_Activated() " + ex.ToString());
            }
        }

        private void frmMemberMaster_Deactivate(object sender, EventArgs e)
        {
            try
            {
                //this.AutoValidate = AutoValidate.Disable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCaste.frmCaste_Deactivate() " + ex.ToString());
            }
        }

        private void frmMemberMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                //((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
                //((frmMain)base.MdiParent).mnuMemberMaster.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCaste.frmCaste_FormClosed() " + ex.ToString());
            }
        }

        private void txtCaste_Validating(object sender, CancelEventArgs e)
        {
            //this.objGlobal.ScreenPosition(this.txtCaste, "0:300");
            //this.objGlobal.OpenHelpTxtBox_Validating(this.dvCaste, this.strCaste, "Caste", true, this.txtCaste, this.txtCasteCode);
        }

        private void txtCaste_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtSubCaste_Validating(object sender, CancelEventArgs e)
        {
            //if (txtCasteCode.Text != "")
            //{
            //    strSubCaste = "SELECT SubCasteCode,SubCaste FROM tbl_SubCaste WHERE CasteCode=" + txtCasteCode.Text + " ORDER BY SubCaste";
            //    dvSubCaste = objDb.GetDataView(strSubCaste);
            //    this.objGlobal.ScreenPosition(this.txtCaste, "0:300");
            //    this.objGlobal.OpenHelpTxtBox_Validating(this.dvSubCaste, this.strSubCaste, "SubCaste", true, this.txtSubCaste, this.txtSubCasteCode);
            //}
        }

        private void txtSubCaste_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtBloodGroup_Validating(object sender, CancelEventArgs e)
        {
            //this.objGlobal.ScreenPosition(this.txtBloodGroup, "0:300");
            //this.objGlobal.OpenHelpTxtBox_Validating(this.dvBloodGrp, this.strBloodGrp, "BloodGroup", true, this.txtBloodGroup, this.txtBloodGroupCode);
        }

        private void txtBloodGroup_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtEducation_Validating(object sender, CancelEventArgs e)
        {
            //this.objGlobal.ScreenPosition(this.txtWeight, "0:300");
            //this.objGlobal.OpenHelpTxtBox_Validating(this.dvEducation, this.strEducation, "Education", true, this.txtEducation, this.txtEducationCode);
        }

        private void txtOccupation_Validating(object sender, CancelEventArgs e)
        {
            //this.objGlobal.ScreenPosition(this.txtWeight, "0:300");
            //this.objGlobal.OpenHelpTxtBox_Validating(this.dvOccupation, this.strOccupation, "Occupation", true, this.txtOccupation, this.txtOccupationCode);
        }

        private void txtWorkAddress_Validating(object sender, CancelEventArgs e)
        {
            //this.objGlobal.ScreenPosition(this.txtWeight, "0:300");
            //this.objGlobal.OpenHelpTxtBox_Validating(this.dvSateCity, this.strStateCity, "StateCity", true, this.txtWorkAddress, this.txtWorkingStateCityCode);
        }

        public void FillCombo()
        {
            try
            {
                strSQL = " SELECT 0 AS HeightCM,'--SELECT--' AS Height";
                strSQL += " UNION ALL ";
                strSQL += " SELECT HeightCM,Height FROM tbl_Height ORDER BY HeightCM ";
                DataTable dtHeight = objDb.GetDataTable(strSQL);
                ddlHeight.DataSource = dtHeight;
                ddlHeight.ValueMember = "HeightCM";
                ddlHeight.DisplayMember = "Height";

                DataTable dtPFromHeight = objDb.GetDataTable(strSQL);
                ddlPHeightFrom.DataSource = dtPFromHeight;
                ddlPHeightFrom.ValueMember = "HeightCM";
                ddlPHeightFrom.DisplayMember = "Height";

                //DataTable dtPToHeight = objDb.GetDataTable(strSQL);
                ddlPHeightTo.DataSource = dtPFromHeight.Copy();
                ddlPHeightTo.ValueMember = "HeightCM";
                ddlPHeightTo.DisplayMember = "Height";

                strSQL = " SELECT 0 AS MaritalStatusCode,'--SELECT--' AS MaritalStatus";
                strSQL += " UNION ALL ";
                strSQL += "select MaritalStatusCode,MaritalStatus from tbl_MaritalStatus";
                DataTable dtMaritalStatus = objDb.GetDataTable(strSQL);
                ddlMaritalStatus.DataSource = dtMaritalStatus;
                ddlMaritalStatus.ValueMember = "MaritalStatusCode";
                ddlMaritalStatus.DisplayMember = "MaritalStatus";

                strSQL = " SELECT 0 AS AnnualIncomeCurrencyCode,'--SELECT--' AS AnnualIncomeCurrency";
                strSQL += " UNION ALL ";
                strSQL += "SELECT AnnualIncomeCurrencyCode,AnnualIncomeCurrency FROM tbl_AnnualIncomeCurrency ORDER BY AnnualIncomeCurrency";
                DataTable dtAnnualIncomeCurrency = objDb.GetDataTable(strSQL);
                ddlAnnualIncomeCurrency.DataSource = dtAnnualIncomeCurrency;
                ddlAnnualIncomeCurrency.ValueMember = "AnnualIncomeCurrencyCode";
                ddlAnnualIncomeCurrency.DisplayMember = "AnnualIncomeCurrency";

                //DataTable dtAnnualIncomeCurrency_p = objDb.GetDataTable(strSQL);
                ddlPAnnualIncomeCurrency.DataSource = dtAnnualIncomeCurrency.Copy();
                ddlPAnnualIncomeCurrency.ValueMember = "AnnualIncomeCurrencyCode";
                ddlPAnnualIncomeCurrency.DisplayMember = "AnnualIncomeCurrency";

                strSQL = " SELECT 0 AS AnnualIncomeCode,'--SELECT--' AS AnnualIncome";
                strSQL += " UNION ALL ";
                strSQL += " SELECT AnnualIncomeCode,AnnualIncome FROM tbl_AnnualIncome where isnull(isDelete,0)=0 ";
                DataTable dtAnnualIncome = objDb.GetDataTable(strSQL);
                ddlAnnualIncome.DataSource = dtAnnualIncome;
                ddlAnnualIncome.ValueMember = "AnnualIncomeCode";
                ddlAnnualIncome.DisplayMember = "AnnualIncome";

                DataTable dtAnnualIncome_p = objDb.GetDataTable(strSQL);
                ddlPAnnualIncome.DataSource = dtAnnualIncome_p;
                ddlPAnnualIncome.ValueMember = "AnnualIncomeCode";
                ddlPAnnualIncome.DisplayMember = "AnnualIncome";

                ddlMobileNo_Rel.DataSource = dtMobileNo_Rel;
                ddlMobileNo_Rel.DisplayMember = "ProfileCreatedBy";
                ddlMobileNo_Rel.ValueMember = "ProfileCreatedByCode";

                ddlMobileNo1_Rel.DataSource = dtMobileNo1_Rel;
                ddlMobileNo1_Rel.DisplayMember = "ProfileCreatedBy";
                ddlMobileNo1_Rel.ValueMember = "ProfileCreatedByCode";

                ddlMobileNo2_Rel.DataSource = dtMobileNo2_Rel;
                ddlMobileNo2_Rel.DisplayMember = "ProfileCreatedBy";
                ddlMobileNo2_Rel.ValueMember = "ProfileCreatedByCode";

                ddlLandlineNo1_Rel.DataSource = dtMobileNo3_Rel;
                ddlLandlineNo1_Rel.DisplayMember = "ProfileCreatedBy";
                ddlLandlineNo1_Rel.ValueMember = "ProfileCreatedByCode";

                //strSQL = " Select 0 as MaritalStatusCode,'Married' as MaritalStatus";
                //strSQL += " UNION ALL ";
                strSQL = " SELECT MaritalStatusCode,MaritalStatus FROM tbl_MaritalStatus";
                DataTable dtBriSisMaritalStatus = objDb.GetDataTable(strSQL);
                cmdBroSisMaritalStatus.DataSource = dtBriSisMaritalStatus;
                cmdBroSisMaritalStatus.ValueMember = "MaritalStatusCode";
                cmdBroSisMaritalStatus.DisplayMember = "MaritalStatus";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillPartnerPrefBirthYear()
        {
            try
            {
                //int AgeDiff = objGlobal.GetAgeDiff(MemberCode);
                int FromYear = 1950, ToYear = 1996;
                int AgeDiff = 6;
                DateTime DOB = Convert.ToDateTime(dtpDateofBirth.Value);
                FromYear = DOB.Year;
                if (rdbtnMale.Checked)
                {
                    ToYear = FromYear + AgeDiff;
                }
                else
                {
                    ToYear = FromYear;
                    FromYear = FromYear - AgeDiff;
                }
                DataTable dtBornYear = objGlobal.GetYearList(FromYear, ToYear);
                ddlPAgeFrom.DataSource = dtBornYear;
                ddlPAgeFrom.DisplayMember = "Number";
                ddlPAgeFrom.ValueMember = "NValue";

                DataTable dtToBornYear = objGlobal.GetYearList(FromYear, ToYear);
                ddlPAgeTo.DataSource = dtToBornYear;
                ddlPAgeTo.DisplayMember = "Number";
                ddlPAgeTo.ValueMember = "NValue";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void funAdd()
        {
            try
            {
                ((frmMain)base.MdiParent).setControlState(true, true, this);
                this.AutoValidate = AutoValidate.EnableAllowFocusChange;
                this.TpLast = ToolbarPositions.eTPAdd;
                ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                //this.txtProfileCreatedBy.Focus();
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.funAdd() " + exception.ToString());
            }
        }

        public void funClear()
        {
            try
            {
                ((frmMain)base.MdiParent).setControlState(false, true, this);
                this.TpLast = ToolbarPositions.eTPOk;
                ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                this.ddlCaste.Focus();
                this.IsEdit = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.funClear() " + exception.ToString());
            }
        }

        public void funDelete()
        {
            try
            {
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.funDelete() " + exception.ToString());
            }
        }

        public void funEdit()
        {
            try
            {
                ((frmMain)base.MdiParent).setControlState(true, false, this);
                this.TpLast = ToolbarPositions.eTPEdit;
                ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                IsEdit = true;
                ddlCaste.Focus();
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.funEdit() " + exception.ToString());
            }
        }

        public void funExit()
        {
            try
            {
                this.TpLast = ToolbarPositions.eTPNoAction;
                ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                base.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.funExit() " + exception.ToString());
            }
        }

        public void funReport()
        {
            try
            {
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.funReport() " + exception.ToString());
            }
        }

        public void funSave()
        {
            try
            {

            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.funSave() " + exception.ToString());
            }
        }

        public void funSearch()
        {
            try
            {

            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.funSearch() " + exception.ToString());
            }
        }

        public void DisplalyData(string strCode)
        {
            try
            {
                int PageCount = 0;
                lblMemberCode.Text = strCode;
                DataSet dsDataList = new DataSet();
                if (isActiveStatus == 2)
                {
                    tbl_UpdateMemberMasterProp Objtbl_MemberMasterProp = new tbl_UpdateMemberMasterProp();
                    Objtbl_MemberMasterProp.MemberCode = Convert.ToInt32(strCode);

                    tbl_UpdateMemberMasterBAL Objtbl_MemberMasterBAL = new tbl_UpdateMemberMasterBAL();
                    dsDataList = Objtbl_MemberMasterBAL.Select_Data(Objtbl_MemberMasterProp, ref PageCount);
                }
                else
                {
                    tbl_MemberMasterProp Objtbl_MemberMasterProp = new tbl_MemberMasterProp();
                    Objtbl_MemberMasterProp.MemberCode = Convert.ToInt32(strCode);

                    tbl_MemberMasterBAL Objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
                    dsDataList = Objtbl_MemberMasterBAL.Select_Data(Objtbl_MemberMasterProp, ref PageCount);
                }
                if (dsDataList.Tables[0].Rows.Count == 0)
                {
                    tbl_MemberMasterProp Objtbl_MemberMasterProp = new tbl_MemberMasterProp();
                    Objtbl_MemberMasterProp.MemberCode = Convert.ToInt32(strCode);

                    tbl_MemberMasterBAL Objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
                    dsDataList = Objtbl_MemberMasterBAL.Select_Data(Objtbl_MemberMasterProp, ref PageCount);
                }

                //this.objGlobal.DisplayFields(this, dsDataList.Tables[0]);

                txtMemberName.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["MemberName"]);

                this.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["ProfileID"]);
                txtProfileId.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["ProfileID"]);

                //lblProfileID.Text = "- " + Convert.ToString(dsDataList.Tables[0].Rows[0]["ProfileID"]);
                if (Convert.ToString(dsDataList.Tables[0].Rows[0]["ProfileCreatedBy"]) != "")
                {
                    ddlProfileCreatedBy.SelectedValue = Convert.ToString(dsDataList.Tables[0].Rows[0]["ProfileCreatedByCode"]);
                }

                //dtpRegisterDate.Enabled = true;
                dtpRegisterDate.Value = Convert.ToDateTime(dsDataList.Tables[0].Rows[0]["RegisterDate"]);//.ToString("dd/MM/yyyy");
                //dtpRegisterDate.Enabled = false;

                cmbisActive.SelectedIndex = Convert.ToInt16(dsDataList.Tables[0].Rows[0]["isActive"]);

                if (Convert.ToInt32(dsDataList.Tables[0].Rows[0]["Gender"]) == 0)
                    rdbtnMale.Checked = true;
                else
                    rdbtnFemale.Checked = true;

                dtpDateofBirth.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["DateofBirth"]);
                dtpTime.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["TimeofBirth"]);
                cmbBirthPlace.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["BirthPlace"]);
                //txtMaritalStatusCode.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["MaritalStatusCode"]);
                ddlMaritalStatus.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["MaritalStatus"]);
                ddlNoOfChildren.SelectedIndex = Convert.ToInt32(dsDataList.Tables[0].Rows[0]["NoOfChildren"]);
                if (Convert.ToString(dsDataList.Tables[0].Rows[0]["LiveChildrenTogether"]) != "")
                {
                    ddlLiveChildrenTogether.SelectedIndex = Convert.ToInt32(dsDataList.Tables[0].Rows[0]["LiveChildrenTogether"]);
                }
                txtHomeAddress1.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["HomeAddress1"]);
                txtHomeAddress2.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["HomeAddress2"]);
                txtAboutSelf_1.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["AboutInfo"]);
                cmbChoice.SelectedValue = Convert.ToString(dsDataList.Tables[0].Rows[0]["Choice"]);
                cmdRemark.SelectedValue = Convert.ToString(dsDataList.Tables[0].Rows[0]["Remarks"]);
                cmbmStatus.SelectedIndex = Convert.ToInt32(dsDataList.Tables[0].Rows[0]["mStatus"]);
                txtFileNote.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["FileNote"]);


                if (Convert.ToString(dsDataList.Tables[0].Rows[0]["CountryCode"]) != "")
                {
                    ddlCountry.SelectedValue = Convert.ToString(dsDataList.Tables[0].Rows[0]["CountryCode"]);
                }

                //if (ddlCountry.SelectedValue != "")
                //{
                //    strStateCity = " SELECT 0 AS StateCityCode,'--SELECT--' AS StateCity UNION ALL ";
                //    strStateCity += "SELECT StateCityCode,StateCity FROM tbl_StateCity WHERE CountryCode=" + ddlCountry.SelectedValue + " ORDER BY StateCity";
                //    dvSateCity = objDb.GetDataView(strStateCity);
                //    ddlStateCity.DataSource = dvSateCity;
                //    ddlStateCity.DisplayMember = "StateCity";
                //    ddlStateCity.ValueMember = "StateCityCode";
                //}


                if (Convert.ToString(dsDataList.Tables[0].Rows[0]["StateCityCode"]) != "")
                {
                    ddlStateCity.SelectedValue = Convert.ToString(dsDataList.Tables[0].Rows[0]["StateCityCode"]);
                }

                if (Convert.ToString(dsDataList.Tables[0].Rows[0]["VisaStatusCode"]) != "")
                {
                    ddlVisaStatus.SelectedValue = Convert.ToString(dsDataList.Tables[0].Rows[0]["VisaStatusCode"]);
                }

                if (Convert.ToString(dsDataList.Tables[0].Rows[0]["VisaCountryCode"]) != "")
                {
                    ddlVisaCountry.SelectedValue = Convert.ToString(dsDataList.Tables[0].Rows[0]["VisaCountryCode"]);
                }


                txtMobileNo.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["MobileNo"]);
                txtLandlineNo.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["LandlineNo"]);
                txtMobileNo1.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["MobileNo1"]);
                txtLandlineNo1.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["LandlineNo1"]);
                txtEmailID.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["EmailID"]);
                txtSecondaryEmailID.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["SecondaryEmailID"]);
                txtPassword.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["Password"]);


                if (Convert.ToString(dsDataList.Tables[0].Rows[0]["EducationCode"]) != "")
                {
                    ddlEducation.SelectedValue = Convert.ToString(dsDataList.Tables[0].Rows[0]["EducationCode"]);
                }
                cmbDegree.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["Degree"]);
                if (Convert.ToString(dsDataList.Tables[0].Rows[0]["OccupationCode"]) != "")
                {
                    ddlOccupation.SelectedValue = Convert.ToString(dsDataList.Tables[0].Rows[0]["OccupationCode"]);
                }

                cmbOccupationDtls.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["OccupationDtls"]);
                ddlAnnualIncomeCurrency.SelectedValue = Convert.ToString(dsDataList.Tables[0].Rows[0]["AnnualIncomeCurrency"]);
                ddlAnnualIncome.SelectedValue = Convert.ToString(dsDataList.Tables[0].Rows[0]["AnnualIncome"]);
                ddlWorkAddress.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["WorkAddress"]);

                ddlCaste.SelectedValue = Convert.ToString(dsDataList.Tables[0].Rows[0]["CasteCode"]);
                if (Convert.ToString(dsDataList.Tables[0].Rows[0]["SubCasteCode"]) != "")
                {
                    ddlSubCaste.SelectedValue = Convert.ToString(dsDataList.Tables[0].Rows[0]["SubCasteCode"]);
                }


                if (Convert.ToInt32(dsDataList.Tables[0].Rows[0]["Manglik"]) == Convert.ToInt32(iManglik.No))
                    rdbtnManglikNo.Checked = true;
                else if (Convert.ToInt32(dsDataList.Tables[0].Rows[0]["Manglik"]) == Convert.ToInt32(iManglik.Yes))
                    rdbtnManglikYes.Checked = true;
                else
                    rdbtnManglikDontKnow.Checked = true;

                txtFatherName.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["FatherName"]);
                cmbFatherOccupation.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["FatherOccupation"]);
                txtMotherName.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["MotherName"]);
                cmbMotherOccupation.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["MotherOccupation"]);

                cmbMosalPlace.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["MosalPlace"]);
                cmbNativePlace.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["NativePlace"]);

                ddlHeight.SelectedValue = Convert.ToString(dsDataList.Tables[0].Rows[0]["Height"]);
                txtWeight.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["Weight"]);

                if (Convert.ToString(dsDataList.Tables[0].Rows[0]["BloodGroupCode"]) != "")
                {
                    ddlBloodGroup.SelectedValue = Convert.ToString(dsDataList.Tables[0].Rows[0]["BloodGroupCode"]);
                }
                ddlMobileNo_Rel.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["MobileNo_Rel"]);
                ddlMobileNo1_Rel.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["MobileNo1_Rel"]);
                ddlLandlineNo1_Rel.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["LandlineNo1_Rel"]);
                ddlMobileNo2_Rel.Text = Convert.ToString(dsDataList.Tables[0].Rows[0]["MobileNo2_Rel"]);
                //grdComboItems.Visible = false;

                PartnerPrefrence(Convert.ToInt32(strCode));
                FillMembershipDetail(Convert.ToInt32(strCode));
                FillSibbling_Details(Convert.ToInt32(strCode));
                GetFollowUpList(Convert.ToInt32(strCode));
                FillMemberPhotos(Convert.ToInt32(strCode));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtProfileCreatedBy_Validating(object sender, CancelEventArgs e)
        {
            //this.objGlobal.ScreenPosition(this.txtProfileCreatedBy, "0:300");
            //this.objGlobal.OpenHelpTxtBox_Validating(this.dvProfileCreatedBy, this.strProfileCreatedBy, "ProfileCreatedBy", true, this.txtProfileCreatedBy, this.txtProfileCreatedByCode);
        }

        private void txtCountry_Validated(object sender, EventArgs e)
        {
            //this.objGlobal.ScreenPosition(this.txtCountry, "0:300");
            //this.objGlobal.OpenHelpTxtBox_Validating(this.dvCountry, this.strCountry, "Country", true, this.txtCountry, this.txtCountryCode);
            //if (txtCountryCode.Text != "")
            //{
            //    strStateCity = "SELECT StateCityCode,StateCity FROM tbl_StateCity WHERE CountryCode=" + txtCountryCode.Text + " ORDER BY StateCity";
            //    dvSateCity = objDb.GetDataView(strStateCity);
            //}
        }

        private void txtStateCity_Validated(object sender, EventArgs e)
        {
            //if (txtCountryCode.Text == "")
            //{
            //    MessageBox.Show("Please Select Country", "Country Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtCountryCode.Focus();
            //    return;
            //}
            //this.objGlobal.ScreenPosition(this.txtStateCity, "0:300");
            //this.objGlobal.OpenHelpTxtBox_Validating(this.dvSateCity, this.strStateCity, "StateCity", true, this.txtStateCity, this.txtStateCityCode);
        }

        private void txtVisaStatus_Validated(object sender, EventArgs e)
        {
            //this.objGlobal.ScreenPosition(this.txtWeight, "0:300");
            //this.objGlobal.OpenHelpTxtBox_Validating(this.dvVisaStatus, this.strVisaStatus, "VisaStatus", true, this.txtVisaStatus, this.txtVisaStatusCode);
        }

        private void txtVisaCountry_Validated(object sender, EventArgs e)
        {
            //this.objGlobal.ScreenPosition(this.txtWeight, "0:300");
            //this.objGlobal.OpenHelpTxtBox_Validating(this.dvCountry, this.strCountry, "Country", true, this.txtVisaCountry, this.txtVisaCountryCode);
        }

        private void ddlLiveChildrenTogether_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void PartnerPrefrence(int MemberCode)
        {
            try
            {
                DataSet dsPDataList = new DataSet();
                if (isActiveStatus == 2)
                {
                    tbl_UpdatePartnersPreferencesProp Objtbl_PartnersPreferencesProp = new tbl_UpdatePartnersPreferencesProp();
                    Objtbl_PartnersPreferencesProp.MemberCode = MemberCode;

                    tbl_UpdatePartnersPreferencesBAL Objtbl_PartnersPreferencesBAL = new tbl_UpdatePartnersPreferencesBAL();
                    dsPDataList = Objtbl_PartnersPreferencesBAL.Select_Data(Objtbl_PartnersPreferencesProp);
                }
                else
                {
                    tbl_PartnersPreferencesProp Objtbl_PartnersPreferencesProp = new tbl_PartnersPreferencesProp();
                    Objtbl_PartnersPreferencesProp.MemberCode = MemberCode;

                    tbl_PartnersPreferencesBAL Objtbl_PartnersPreferencesBAL = new tbl_PartnersPreferencesBAL();
                    dsPDataList = Objtbl_PartnersPreferencesBAL.Select_Data(Objtbl_PartnersPreferencesProp);
                }
                if (dsPDataList.Tables[0].Rows.Count == 0)
                {
                    tbl_PartnersPreferencesProp Objtbl_PartnersPreferencesProp = new tbl_PartnersPreferencesProp();
                    Objtbl_PartnersPreferencesProp.MemberCode = MemberCode;

                    tbl_PartnersPreferencesBAL Objtbl_PartnersPreferencesBAL = new tbl_PartnersPreferencesBAL();
                    dsPDataList = Objtbl_PartnersPreferencesBAL.Select_Data(Objtbl_PartnersPreferencesProp);
                }

                if (dsPDataList.Tables[0].Rows.Count > 0)
                {
                    ddlPAgeFrom.SelectedValue = Convert.ToString(dsPDataList.Tables[0].Rows[0]["AgeFrom"]);
                    ddlPAgeTo.SelectedValue = Convert.ToString(dsPDataList.Tables[0].Rows[0]["AgeTo"]);
                    ddlPHeightFrom.SelectedValue = Convert.ToString(dsPDataList.Tables[0].Rows[0]["HeightFrom"]);
                    ddlPHeightTo.SelectedValue = Convert.ToString(dsPDataList.Tables[0].Rows[0]["HeightTo"]);

                    string[] PartnerData;

                    if (dsPDataList.Tables[0].Rows[0]["MaritalStatus"] != null && Convert.ToString(dsPDataList.Tables[0].Rows[0]["MaritalStatus"]) != "")
                    {
                        PartnerData = Convert.ToString(dsPDataList.Tables[0].Rows[0]["MaritalStatus"]).Split(',');

                        for (int i = 0; i < chkPMaritalStatus.Items.Count; i++)
                        {
                            if (PartnerData.Contains(((System.Data.DataRowView)(chkPMaritalStatus.Items[i])).Row.ItemArray[0].ToString()))
                                chkPMaritalStatus.SetItemCheckState(i, CheckState.Checked);
                            else
                                chkPMaritalStatus.SetItemCheckState(i, CheckState.Unchecked);

                            //Objtbl_PartnersPreferencesProp.MaritalStatus = Convert.ToString(PartnerData);
                        }
                    }
                    else
                    {
                        chkPMaritalStatus.SetItemCheckState(0, CheckState.Checked);
                    }
                    //--------
                    PartnerData = null;

                    if (dsPDataList.Tables[0].Rows[0]["CountryLivingIn"] != null && Convert.ToString(dsPDataList.Tables[0].Rows[0]["CountryLivingIn"]) != "")
                    {
                        PartnerData = Convert.ToString(dsPDataList.Tables[0].Rows[0]["CountryLivingIn"]).Split(',');

                        for (int i = 0; i < chkPCountryLivingIn.Items.Count; i++)
                        {
                            if (PartnerData.Contains(((System.Data.DataRowView)(chkPCountryLivingIn.Items[i])).Row.ItemArray[0].ToString()))
                                chkPCountryLivingIn.SetItemCheckState(i, CheckState.Checked);
                            else
                                chkPCountryLivingIn.SetItemCheckState(i, CheckState.Unchecked);

                            //Objtbl_PartnersPreferencesProp.CountryLivingIn = Convert.ToString(PartnerData);
                        }
                    }
                    else
                    {
                        chkPCountryLivingIn.SetItemCheckState(0, CheckState.Checked);
                    }
                    //--------

                    PartnerData = null;
                    if (dsPDataList.Tables[0].Rows[0]["ResidencyStatus"] != null && Convert.ToString(dsPDataList.Tables[0].Rows[0]["ResidencyStatus"]) != "")
                    {
                        PartnerData = Convert.ToString(dsPDataList.Tables[0].Rows[0]["ResidencyStatus"]).Split(',');

                        for (int i = 0; i < chkPVisaStatus.Items.Count; i++)
                        {
                            if (PartnerData.Contains(((System.Data.DataRowView)(chkPVisaStatus.Items[i])).Row.ItemArray[0].ToString()))
                                chkPVisaStatus.SetItemCheckState(i, CheckState.Checked);
                            else
                                chkPVisaStatus.SetItemCheckState(i, CheckState.Unchecked);

                            //Objtbl_PartnersPreferencesProp.ResidencyStatus = Convert.ToString(PartnerData);
                        }
                    }
                    else
                    {
                        chkPVisaStatus.SetItemCheckState(0, CheckState.Checked);
                    }

                    //--------
                    PartnerData = null;
                    if (dsPDataList.Tables[0].Rows[0]["Education"] != null && Convert.ToString(dsPDataList.Tables[0].Rows[0]["Education"]) != "")
                    {
                        PartnerData = Convert.ToString(dsPDataList.Tables[0].Rows[0]["Education"]).Split(',');

                        for (int i = 0; i < chkPEducation.Items.Count; i++)
                        {
                            if (PartnerData.Contains(((System.Data.DataRowView)(chkPEducation.Items[i])).Row.ItemArray[0].ToString()))
                                chkPEducation.SetItemCheckState(i, CheckState.Checked);
                            else
                                chkPEducation.SetItemCheckState(i, CheckState.Unchecked);

                            //Objtbl_PartnersPreferencesProp.Education = Convert.ToString(PartnerData);
                        }
                    }
                    else
                    {
                        chkPEducation.SetItemCheckState(0, CheckState.Checked);
                    }

                    //--------
                    PartnerData = null;
                    if (dsPDataList.Tables[0].Rows[0]["Occupation"] != null && Convert.ToString(dsPDataList.Tables[0].Rows[0]["Occupation"]) != "")
                    {
                        PartnerData = Convert.ToString(dsPDataList.Tables[0].Rows[0]["Occupation"]).Split(',');

                        for (int i = 0; i < chkPOccupation.Items.Count; i++)
                        {
                            if (PartnerData.Contains(((System.Data.DataRowView)(chkPOccupation.Items[i])).Row.ItemArray[0].ToString()))
                                chkPOccupation.SetItemCheckState(i, CheckState.Checked);
                            else
                                chkPOccupation.SetItemCheckState(i, CheckState.Unchecked);

                            //Objtbl_PartnersPreferencesProp.Occupation = Convert.ToString(PartnerData);
                        }
                    }
                    else
                    {
                        chkPOccupation.SetItemCheckState(0, CheckState.Checked);
                    }

                    //--------
                    PartnerData = null;
                    if (dsPDataList.Tables[0].Rows[0]["WorkingWith"] != null && Convert.ToString(dsPDataList.Tables[0].Rows[0]["WorkingWith"]) != "")
                    {
                        PartnerData = Convert.ToString(dsPDataList.Tables[0].Rows[0]["WorkingWith"]).Split(',');

                        for (int i = 0; i < chkPWorkingWith.Items.Count; i++)
                        {
                            if (PartnerData.Contains(((System.Data.DataRowView)(chkPWorkingWith.Items[i])).Row.ItemArray[0].ToString()))
                                chkPWorkingWith.SetItemCheckState(i, CheckState.Checked);
                            else
                                chkPWorkingWith.SetItemCheckState(i, CheckState.Unchecked);

                            //Objtbl_PartnersPreferencesProp.WorkingWith = Convert.ToString(PartnerData);
                        }
                    }
                    else
                    {
                        chkPWorkingWith.SetItemCheckState(0, CheckState.Checked);
                    }
                    //--------
                    PartnerData = null;
                    if (dsPDataList.Tables[0].Rows[0]["Caste"] != null && Convert.ToString(dsPDataList.Tables[0].Rows[0]["Caste"]) != "")
                    {
                        PartnerData = Convert.ToString(dsPDataList.Tables[0].Rows[0]["Caste"]).Split(',');

                        for (int i = 0; i < chkPCaste.Items.Count; i++)
                        {
                            if (PartnerData.Contains(((System.Data.DataRowView)(chkPCaste.Items[i])).Row.ItemArray[0].ToString()))
                                chkPCaste.SetItemCheckState(i, CheckState.Checked);
                            else
                                chkPCaste.SetItemCheckState(i, CheckState.Unchecked);

                            //Objtbl_PartnersPreferencesProp.Caste = Convert.ToString(PartnerData);
                        }
                    }
                    else
                    {
                        chkPCaste.SetItemCheckState(0, CheckState.Checked);
                    }

                    //--------
                    cmbPHaveChildrens.SelectedValue = Convert.ToInt32(dsPDataList.Tables[0].Rows[0]["HaveChildren"]);
                    ddlPAnnualIncomeCurrency.SelectedValue = Convert.ToInt32(dsPDataList.Tables[0].Rows[0]["AnnualIncomeCurrency"]);
                    ddlPAnnualIncome.SelectedValue = Convert.ToInt32(dsPDataList.Tables[0].Rows[0]["AnnualIncome"]);

                    if (Convert.ToInt32(dsPDataList.Tables[0].Rows[0]["Manglik"]) == Convert.ToInt32(iManglik.No))
                        rdbtnPManglikNo.Checked = true;
                    else if (Convert.ToInt32(dsPDataList.Tables[0].Rows[0]["Manglik"]) == Convert.ToInt32(iManglik.Yes))
                        rdbtnPManglikYes.Checked = true;
                    else
                        rdbtnPManglikDontKnow.Checked = true;

                    txtAboutPartner.Text = Convert.ToString(dsPDataList.Tables[0].Rows[0]["AboutPartner"]);
                }
                else
                {
                    if (rdbtnMale.Checked == true)
                    {
                        ddlPAgeFrom.SelectedValue = dtpDateofBirth.Value.Year;
                        ddlPAgeTo.SelectedValue = dtpDateofBirth.Value.Year + 5;
                    }
                    else
                    {
                        ddlPAgeFrom.SelectedValue = dtpDateofBirth.Value.Year - 5;
                        ddlPAgeTo.SelectedValue = dtpDateofBirth.Value.Year;
                    }

                    chkPMaritalStatus.SetItemCheckState(0, CheckState.Checked);
                    chkPCountryLivingIn.SetItemCheckState(0, CheckState.Checked);
                    chkPVisaStatus.SetItemCheckState(0, CheckState.Checked);
                    chkPEducation.SetItemCheckState(0, CheckState.Checked);
                    chkPOccupation.SetItemCheckState(0, CheckState.Checked);
                    chkPWorkingWith.SetItemCheckState(0, CheckState.Checked);
                    chkPCaste.SetItemCheckState(0, CheckState.Checked);
                    if (dsPDataList.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(dsPDataList.Tables[0].Rows[0]["Manglik"]) == "0")
                        {
                            rdbtnManglikNo.Checked = true;
                        }
                        else if (Convert.ToString(dsPDataList.Tables[0].Rows[0]["Manglik"]) == "1")
                        {
                            rdbtnPManglikYes.Checked = true;
                        }
                        else
                        {
                            rdbtnPManglikDontKnow.Checked = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillSibbling_Details(int MemberCode)
        {
            DataSet dsSibbling = new DataSet();
            if (isActiveStatus == 2)
            {
                tbl_UpdateSibblingDetailsProp Objtbl_SibblingDetailsProp = new tbl_UpdateSibblingDetailsProp();
                Objtbl_SibblingDetailsProp.MemberCode = MemberCode;

                tbl_UpdateSibblingDetailsBAL Objtbl_SibblingDetailsBAL = new tbl_UpdateSibblingDetailsBAL();
                dsSibbling = Objtbl_SibblingDetailsBAL.Select_Data(Objtbl_SibblingDetailsProp);

            }
            else
            {
                tbl_SibblingDetailsProp Objtbl_SibblingDetailsProp = new tbl_SibblingDetailsProp();
                Objtbl_SibblingDetailsProp.MemberCode = MemberCode;

                tbl_SibblingDetailsBAL Objtbl_SibblingDetailsBAL = new tbl_SibblingDetailsBAL();
                dsSibbling = Objtbl_SibblingDetailsBAL.Select_Data(Objtbl_SibblingDetailsProp);
            }
            if (dsSibbling.Tables[0].Rows.Count == 0)
            {
                tbl_SibblingDetailsProp Objtbl_SibblingDetailsProp = new tbl_SibblingDetailsProp();
                Objtbl_SibblingDetailsProp.MemberCode = MemberCode;

                tbl_SibblingDetailsBAL Objtbl_SibblingDetailsBAL = new tbl_SibblingDetailsBAL();
                dsSibbling = Objtbl_SibblingDetailsBAL.Select_Data(Objtbl_SibblingDetailsProp);
            }
            if (dsSibbling.Tables[0].Rows.Count > 0)
            {
                dgvSiblingDetails.RowCount = dsSibbling.Tables[0].Rows.Count;
                for (int cnt = 0; cnt < dsSibbling.Tables[0].Rows.Count; cnt++)
                {
                    dgvSiblingDetails[(int)BS.Edit, cnt].Value = "Edit";
                    dgvSiblingDetails[(int)BS.Delete, cnt].Value = "Delete";
                    dgvSiblingDetails[(int)BS.ID, cnt].Value = cnt.ToString();
                    dgvSiblingDetails[(int)BS.BroSis, cnt].Value = Convert.ToString(dsSibbling.Tables[0].Rows[cnt]["BrotherSister"]);
                    dgvSiblingDetails[(int)BS.MaritalStatus, cnt].Value = Convert.ToString(dsSibbling.Tables[0].Rows[cnt]["MaritalStatus"]);
                    dgvSiblingDetails[(int)BS.Name, cnt].Value = Convert.ToString(dsSibbling.Tables[0].Rows[cnt]["SibblingName"]);
                    dgvSiblingDetails[(int)BS.Occupation, cnt].Value = Convert.ToString(dsSibbling.Tables[0].Rows[cnt]["Occupation"]);
                }
            }
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
                "Edit", "Delete","SrNo", "StartDate", "MembershipMonth","EndDate","MemberShipTypeCode", "MemberShipType", "AmountReceived","PayBy","ChequeNo","ChequeDate","BankDetail","Ex","Ex1"
            };
                int[] numArray = new int[] { 
                80, 80,100, 100, 150,100,0, 100, 150, 0, 0,0,0,0,0,0
            };
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i] == "Delete" || strArray[i] == "Edit")
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
                dgv.Columns[(int)CI.MemberShipTypeCode].Visible = false;
                dgv.Columns[(int)CI.PayBy].Visible = true;
                dgv.Columns[(int)CI.ChequeNo].Visible = false;
                dgv.Columns[(int)CI.ChequeDate].Visible = false;
                dgv.Columns[(int)CI.BankDetail].Visible = false;

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
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.GridDesign() " + exception.ToString());
            }
        }

        public void GridDesign_FollowUp(DataGridView dgv)
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
                "Edit", "Delete","FollowUpId", "ProfileId", "Name","Date","Status", "Remark1", "Remark2","Remark3","Remark4","Remark5","Ex"
            };
                int[] numArray = new int[] {
                60, 60, 0, 100, 150, 100,100, 100, 150, 150, 150, 150, 0
            };
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i] == "Delete" || strArray[i] == "Edit")
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
                dgv.Columns[(int)FL.FollowUpId].Visible = false;
                dgv.Columns[(int)FL.EX].Visible = false;
                //dgv.Columns[(int)FL.EX1].Visible = false;
                //dgv.Columns[(int)FL.Edit].Visible = false;
                //dgv.Columns[(int)FL.Delete].Visible = false;

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
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.GridDesign() " + exception.ToString());
            }
        }

        public void GridDesignSubblings(DataGridView dgv)
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
                "Brother/Sister", "Name","Occupation", "MaritalStatus","Edit","Delete","ID","Ex1","Ex"
            };
                int[] numArray = new int[] { 
                200, 150 , 100, 150,100,100,10, 0, 0
            };
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i] == "Delete" || strArray[i] == "Edit")
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
                dgv.Columns[(int)BS.Ex].Visible = false;
                dgv.Columns[(int)BS.EX1].Visible = false;
                dgv.Columns[(int)BS.ID].Visible = false;

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
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.GridDesign() " + exception.ToString());
            }
        }

        public void FillMembershipDetail(int MemberCode)
        {
            dgvMemershipDetails.Rows.Clear();
            dgvMemershipDetails.DataSource = null;
            tbl_MembershipMasterProp objtbl_MembershipMasterProp = new tbl_MembershipMasterProp();
            objtbl_MembershipMasterProp.MemberCode = MemberCode;

            tbl_MembershipMasterBAL objtbl_MembershipMasterBAL = new tbl_MembershipMasterBAL();
            DataSet dsData = objtbl_MembershipMasterBAL.Select_Data(objtbl_MembershipMasterProp);

            dgvMemershipDetails.RowCount = dsData.Tables[0].Rows.Count;
            for (int cnt = 0; cnt < dsData.Tables[0].Rows.Count; cnt++)
            {
                dgvMemershipDetails[(int)CI.MembershipMonth, cnt].Value = Convert.ToString(dsData.Tables[0].Rows[cnt]["MembershipMonth"]);
                dgvMemershipDetails[(int)CI.MemberShipType, cnt].Value = Convert.ToString(dsData.Tables[0].Rows[cnt]["MemberShipType"]);
                dgvMemershipDetails[(int)CI.SerialNo, cnt].Value = Convert.ToString(dsData.Tables[0].Rows[cnt]["SerialNo"]);
                dgvMemershipDetails[(int)CI.StartDate, cnt].Value = Convert.ToString(dsData.Tables[0].Rows[cnt]["StartDate"]);
                dgvMemershipDetails[(int)CI.AmountReceived, cnt].Value = Convert.ToString(dsData.Tables[0].Rows[cnt]["AmountReceived"]);
                dgvMemershipDetails[(int)CI.EndDate, cnt].Value = Convert.ToString(dsData.Tables[0].Rows[cnt]["EndDate"]);
                dgvMemershipDetails[(int)CI.MemberShipTypeCode, cnt].Value = Convert.ToString(dsData.Tables[0].Rows[cnt]["MemberShipTypeCode"]);
                dgvMemershipDetails[(int)CI.PayBy, cnt].Value = Convert.ToString(dsData.Tables[0].Rows[cnt]["PayBy"]);
                dgvMemershipDetails[(int)CI.ChequeNo, cnt].Value = Convert.ToString(dsData.Tables[0].Rows[cnt]["ChequeNo"]);
                dgvMemershipDetails[(int)CI.ChequeDate, cnt].Value = Convert.ToString(dsData.Tables[0].Rows[cnt]["ChequeDate"]);
                dgvMemershipDetails[(int)CI.BankDetail, cnt].Value = Convert.ToString(dsData.Tables[0].Rows[cnt]["BankDetail"]);

                dgvMemershipDetails[(int)CI.Delete, cnt].Value = "Delete";
                dgvMemershipDetails[(int)CI.Edit, cnt].Value = "Edit";
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckValidate())
                {
                    return;
                }
                //string s = cmbBirthPlace.Text;
                int intMemberCode = 0;
                if (strMemberCode != "")
                {
                    intMemberCode = Convert.ToInt32(strMemberCode);
                    lblMemberCode.Text = strMemberCode.ToString();
                }
                int newIndex = tabMain.SelectedIndex + 1;
                ////1. Member Master Details
                ////2. Family Master Details
                ////3. Partner Prefrence Details
                ////4. Phots Details
                ////5. Membership Details
                bool isMasterSaved = false;
                if (newIndex == 1 || newIndex == 2)
                {
                    isMasterSaved = SaveMember_Details(intMemberCode);
                }
                if (newIndex == 3)
                {
                    isMasterSaved = false;
                    isMasterSaved = SavePartnerPreferences(intMemberCode);
                    if (isMasterSaved)
                    {
                        Delete_UpdateMemberData(intMemberCode);
                    }
                }
                tabMain.SelectedIndex = newIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool CheckValidate()
        {
            isValid = true;
            try
            {
                if (cmbisActive.SelectedIndex == 2)
                {
                    cmbisActive.SelectedIndex = 1;
                }
                if (cmbmStatus.SelectedIndex == 3 || cmbmStatus.SelectedIndex == 4 || cmbmStatus.SelectedIndex == 5)
                {
                    if (MessageBox.Show("Are you Sure to " + cmbisActive.Text + " Profile", cmbisActive.Text, MessageBoxButtons.YesNo) == DialogResult.No)
                        return false;
                }
                if (ddlProfileCreatedBy.SelectedIndex <= 0)
                {
                    MessageBox.Show("Please Select Profile Created By", "Profile Created By Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ddlProfileCreatedBy.Focus();
                    isValid = false;
                    return isValid;
                }
                if (ddlCaste.SelectedIndex <= 0)
                {
                    MessageBox.Show("Please Select Cast", "Caste Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ddlCaste.Focus();
                    isValid = false;
                    return isValid;
                }
                //if (ddlSubCaste.SelectedIndex <= 0)
                //{
                //    MessageBox.Show("Please Select Sub Cast", "SubCaste Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    ddlSubCaste.Focus();
                //    isValid = false;
                //    return isValid;
                //}
                if (txtHomeAddress1.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Home Address", "Home Address Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtHomeAddress1.Focus();
                    isValid = false;
                    return isValid;
                }
                if (txtMobileNo.Text == "")
                {
                    MessageBox.Show("Please Enter Mobile Number", "Mobile Number Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMobileNo.Focus();
                    isValid = false;
                    return isValid;
                }
                if (txtMobileNo.Text.Trim() != "")
                {
                    if (txtMobileNo.Text.Trim().Length < 10)
                    {
                        MessageBox.Show("Please Enter valid Mobile Number", "Mobile Number Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMobileNo.Focus();
                        isValid = false;
                        return isValid;
                    }
                }
                if (txtMobileNo1.Text.Trim() != "")
                {
                    if (txtMobileNo1.Text.Trim().Length < 10)
                    {
                        MessageBox.Show("Please Enter valid Mobile Number", "Mobile Number Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMobileNo1.Focus();
                        isValid = false;
                        return isValid;
                    }
                }
                if (ddlMobileNo_Rel.SelectedIndex <= 0)
                {
                    MessageBox.Show("Please Enter Mobile Number Relation", "Mobile Number Relation Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ddlMobileNo_Rel.Focus();
                    isValid = false;
                    return isValid;
                }
                if (txtEmailID.Text == "")
                {
                    MessageBox.Show("Please Enter Email", "Email Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmailID.Focus();
                    isValid = false;
                    return isValid;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return isValid;
        }

        private bool SaveMember_Details(int MemberCode)
        {
            try
            {
                if (cmbisActive.SelectedIndex == 3 || cmbisActive.SelectedIndex == 4 || cmbisActive.SelectedIndex == 5)
                {
                    if (MessageBox.Show("Are you Sure to " + cmbisActive.Text + " Profile", cmbisActive.Text, MessageBoxButtons.YesNo) == DialogResult.No)
                        return false;

                    strSQL = "DELETE FROM tbl_ProfilevisitLog_new WHERE MemberCode=" + MemberCode;
                    objDb.ExecuteNonQuery(strSQL);
                    strSQL = "DELETE FROM tbl_LogTable WHERE MemberCode=" + MemberCode;
                    objDb.ExecuteNonQuery(strSQL);
                }

                tbl_MemberMasterProp Objtbl_MemberMasterProp = new tbl_MemberMasterProp();
                Objtbl_MemberMasterProp.MemberCode = MemberCode;
                Objtbl_MemberMasterProp.MemberName = txtMemberName.Text;
                Objtbl_MemberMasterProp.ProfileID = (this.Text == "Member Master" ? "" : this.Text);
                Objtbl_MemberMasterProp.ProfileCreatedBy = Convert.ToInt32(ddlProfileCreatedBy.SelectedValue);
                Objtbl_MemberMasterProp.RegisterDate = new DateTime(Convert.ToInt32(dtpRegisterDate.Value.Year), Convert.ToInt32(dtpRegisterDate.Value.Month), Convert.ToInt32(dtpRegisterDate.Value.Day));
                Objtbl_MemberMasterProp.isActive = cmbisActive.SelectedIndex;

                if (rdbtnMale.Checked == true)
                    Objtbl_MemberMasterProp.Gender = 0;
                else
                    Objtbl_MemberMasterProp.Gender = 1;

                Objtbl_MemberMasterProp.DateofBirth = (dtpDateofBirth.Value);
                if (!dtpTime.Checked)
                {
                    //Objtbl_MemberMasterProp.TimeofBirth = default(DateTime);                    
                }
                else
                {
                    Objtbl_MemberMasterProp.TimeofBirth = (dtpTime.Value);
                }

                Objtbl_MemberMasterProp.BirthPlace = cmbBirthPlace.Text;
                Objtbl_MemberMasterProp.MaritalStatus = Convert.ToInt32(ddlMaritalStatus.SelectedValue);
                Objtbl_MemberMasterProp.NoOfChildren = Convert.ToInt32(ddlNoOfChildren.SelectedIndex);
                Objtbl_MemberMasterProp.LiveChildrenTogether = Convert.ToBoolean(ddlLiveChildrenTogether.SelectedIndex);
                Objtbl_MemberMasterProp.Height = Convert.ToInt16(ddlHeight.SelectedValue);
                if (txtWeight.Text != "")
                {
                    Objtbl_MemberMasterProp.Weight = Convert.ToInt16(txtWeight.Text);
                }
                else
                {
                    Objtbl_MemberMasterProp.Weight = 0;
                }
                Objtbl_MemberMasterProp.BloodGroup = Convert.ToInt32(ddlBloodGroup.SelectedValue);
                Objtbl_MemberMasterProp.HomeAddress1 = Convert.ToString(txtHomeAddress1.Text);
                Objtbl_MemberMasterProp.HomeAddress2 = Convert.ToString(txtHomeAddress2.Text);
                Objtbl_MemberMasterProp.VisaStatus = Convert.ToInt32(ddlVisaStatus.SelectedValue);
                Objtbl_MemberMasterProp.VisaCountry = Convert.ToInt32(ddlVisaCountry.SelectedValue);
                Objtbl_MemberMasterProp.Country = Convert.ToInt32(ddlCountry.SelectedValue);
                Objtbl_MemberMasterProp.StateCity = Convert.ToInt32(ddlStateCity.SelectedValue);
                Objtbl_MemberMasterProp.MobileNo = Convert.ToString(txtMobileNo.Text);
                Objtbl_MemberMasterProp.LandlineNo = Convert.ToString(txtLandlineNo.Text);
                Objtbl_MemberMasterProp.MobileNo1 = Convert.ToString(txtMobileNo1.Text);
                Objtbl_MemberMasterProp.LandlineNo1 = Convert.ToString(txtLandlineNo1.Text);
                Objtbl_MemberMasterProp.EmailID = Convert.ToString(txtEmailID.Text);
                //if (chkChangePassword.Checked)
                //{
                Objtbl_MemberMasterProp.Password = txtPassword.Text;
                //}


                Objtbl_MemberMasterProp.SecondaryEmailID = Convert.ToString(txtSecondaryEmailID.Text);
                Objtbl_MemberMasterProp.Caste = Convert.ToInt32(ddlCaste.SelectedValue);
                Objtbl_MemberMasterProp.SubCaste = Convert.ToInt32(ddlSubCaste.SelectedValue);

                Objtbl_MemberMasterProp.FatherName = Convert.ToString(txtFatherName.Text);
                Objtbl_MemberMasterProp.FatherOccupation = cmbFatherOccupation.Text;
                Objtbl_MemberMasterProp.MotherName = Convert.ToString(txtMotherName.Text);
                Objtbl_MemberMasterProp.MotherOccupation = cmbMotherOccupation.Text;
                Objtbl_MemberMasterProp.MosalPlace = Convert.ToString(cmbMosalPlace.Text);
                Objtbl_MemberMasterProp.NativePlace = Convert.ToString(cmbNativePlace.Text);

                Objtbl_MemberMasterProp.AboutInfo = Convert.ToString(txtAboutSelf_1.Text);
                Objtbl_MemberMasterProp.Choice = Convert.ToString(cmbChoice.Text);
                Objtbl_MemberMasterProp.Remarks = Convert.ToString(cmdRemark.Text);
                Objtbl_MemberMasterProp.mStatus = cmbmStatus.SelectedIndex;
                Objtbl_MemberMasterProp.FileNote = Convert.ToString(txtFileNote.Text);

                if (rdbtnManglikNo.Checked == true)
                    Objtbl_MemberMasterProp.Manglik = iManglik.No;
                else if (rdbtnManglikYes.Checked == true)
                    Objtbl_MemberMasterProp.Manglik = iManglik.Yes;
                else
                    Objtbl_MemberMasterProp.Manglik = iManglik.Doesnt_Know;

                Objtbl_MemberMasterProp.Education = Convert.ToInt32(ddlEducation.SelectedValue);
                Objtbl_MemberMasterProp.Degree = Convert.ToString(cmbDegree.Text);
                Objtbl_MemberMasterProp.Occupation = Convert.ToInt32(ddlOccupation.SelectedValue);
                Objtbl_MemberMasterProp.OccupationDtls = Convert.ToString(cmbOccupationDtls.Text);
                Objtbl_MemberMasterProp.WorkingWith = 0;
                Objtbl_MemberMasterProp.WorkingAs = 0;
                Objtbl_MemberMasterProp.WorkAddress = Convert.ToString(ddlWorkAddress.Text);
                Objtbl_MemberMasterProp.AnnualIncome = Convert.ToInt32(ddlAnnualIncome.SelectedValue);
                Objtbl_MemberMasterProp.AnnualIncomeCurrency = Convert.ToInt32(ddlAnnualIncomeCurrency.SelectedValue);

                Objtbl_MemberMasterProp.Choice = cmbChoice.Text;
                Objtbl_MemberMasterProp.Remarks = cmdRemark.Text;
                Objtbl_MemberMasterProp.mStatus = cmbmStatus.SelectedIndex;
                Objtbl_MemberMasterProp.FileNote = txtFileNote.Text;

                Objtbl_MemberMasterProp.AgeDiff = 0;
                Objtbl_MemberMasterProp.MobileNo_Rel = ddlMobileNo_Rel.Text;
                Objtbl_MemberMasterProp.MobileNo1_Rel = ddlMobileNo1_Rel.Text;
                Objtbl_MemberMasterProp.LandlineNo1_Rel = ddlLandlineNo1_Rel.Text;
                Objtbl_MemberMasterProp.MobileNo2_Rel = ddlMobileNo2_Rel.Text;

                tbl_MemberMasterBAL objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
                int NewMemCode = objtbl_MemberMasterBAL.InsertUpdate_Data(ref Objtbl_MemberMasterProp);

                Objtbl_MemberMasterProp.NewPassword = txtPassword.Text;
                Objtbl_MemberMasterProp.MemberCode = NewMemCode;

                if (chkChangePassword.Checked == true)
                {
                    objtbl_MemberMasterBAL.ChangePassword(Objtbl_MemberMasterProp);
                }
                strMemberCode = NewMemCode.ToString();
                //Objtbl_MemberMasterProp_Global = Objtbl_MemberMasterProp;
                //Objtbl_MemberMasterProp_Global.MemberCode = NewMemCode;

                this.Text = Objtbl_MemberMasterProp.ProfileID;
                txtProfileId.Text = Objtbl_MemberMasterProp.ProfileID;
                //lblProfileID.Text = "- " + Objtbl_MemberMasterProp.ProfileID;

                string[] toAdd = new string[2];
                toAdd[0] = Objtbl_MemberMasterProp.EmailID;
                toAdd[1] = Objtbl_MemberMasterProp.SecondaryEmailID;

                tbl_UpdateMemberMasterProp Objtbl_UpdateMemberMasterProp = new tbl_UpdateMemberMasterProp();
                Objtbl_UpdateMemberMasterProp.MemberCode = MemberCode;

                tbl_UpdateMemberMasterBAL Objtbl_UpdateMemberMasterBAL = new tbl_UpdateMemberMasterBAL();
                Objtbl_UpdateMemberMasterBAL.Delete_Data(Objtbl_UpdateMemberMasterProp);

                tbl_SibblingDetailsProp Objtbl_SibblingDetailsProp = new tbl_SibblingDetailsProp();
                Objtbl_SibblingDetailsProp.MemberCode = MemberCode;

                tbl_SibblingDetailsBAL Objtbl_SibblingDetailsBAL = new tbl_SibblingDetailsBAL();
                Objtbl_SibblingDetailsBAL.Delete_Data(Objtbl_SibblingDetailsProp);

                for (int i = 0; i < dgvSiblingDetails.Rows.Count; i++)
                {
                    if (Convert.ToString(dgvSiblingDetails[(int)BS.BroSis, i].Value) != ""
                        && Convert.ToString(dgvSiblingDetails[(int)BS.Name, i].Value) != ""
                        && Convert.ToString(dgvSiblingDetails[(int)BS.Occupation, i].Value) != ""
                        && Convert.ToString(dgvSiblingDetails[(int)BS.MaritalStatus, i].Value) != "")
                    {
                        Objtbl_SibblingDetailsProp.BrotherSister = Convert.ToString(dgvSiblingDetails[(int)BS.BroSis, i].Value);
                        Objtbl_SibblingDetailsProp.SibblingName = Convert.ToString(dgvSiblingDetails[(int)BS.Name, i].Value);
                        Objtbl_SibblingDetailsProp.Occupation = Convert.ToString(dgvSiblingDetails[(int)BS.Occupation, i].Value);
                        Objtbl_SibblingDetailsProp.MaritalStatus = Convert.ToString(dgvSiblingDetails[(int)BS.MaritalStatus, i].Value);

                        Objtbl_SibblingDetailsBAL.InsertUpdate_Data(Objtbl_SibblingDetailsProp);
                    }
                }

                //RegistrationMail(Objtbl_MemberMasterProp.MemberName, Objtbl_MemberMasterProp.ProfileID, Objtbl_MemberMasterProp.Password, toAdd);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool SavePartnerPreferences(int MemberCode)
        {
            try
            {
                tbl_PartnersPreferencesProp objtbl_PartnersPreferencesProp = new tbl_PartnersPreferencesProp();
                objtbl_PartnersPreferencesProp.MemberCode = MemberCode;

                objtbl_PartnersPreferencesProp.AgeFrom = Convert.ToInt16(ddlPAgeFrom.SelectedValue);
                objtbl_PartnersPreferencesProp.AgeTo = Convert.ToInt16(ddlPAgeTo.SelectedValue);

                objtbl_PartnersPreferencesProp.HeightFrom = Convert.ToInt32(ddlPHeightFrom.SelectedValue);
                objtbl_PartnersPreferencesProp.HeightTo = Convert.ToInt32(ddlPHeightTo.SelectedValue);

                string strPartnerData = "";
                //if (chkPCaste. GetItemCheckState(0) != CheckState.Checked)
                //{
                for (int i = 0; i < chkPCaste.CheckedItems.Count; i++)
                {
                    strPartnerData += ((System.Data.DataRowView)(chkPCaste.CheckedItems[i])).Row.ItemArray[0] + ",";
                }
                strPartnerData = strPartnerData.TrimEnd(',');
                objtbl_PartnersPreferencesProp.Caste = strPartnerData;
                //}
                // ----------

                strPartnerData = "";
                //if (chkPMaritalStatus.GetItemCheckState(0) != CheckState.Checked)
                //{
                for (int i = 0; i < chkPMaritalStatus.CheckedItems.Count; i++)
                {
                    strPartnerData += ((System.Data.DataRowView)(chkPMaritalStatus.CheckedItems[i])).Row.ItemArray[0] + ",";
                }
                strPartnerData = strPartnerData.TrimEnd(',');
                objtbl_PartnersPreferencesProp.MaritalStatus = strPartnerData;
                //}
                // ----------

                if (rdbtnPManglikNo.Checked == true)
                    objtbl_PartnersPreferencesProp.Manglik = 0;
                else if (rdbtnPManglikYes.Checked == true)
                    objtbl_PartnersPreferencesProp.Manglik = 1;
                else
                    objtbl_PartnersPreferencesProp.Manglik = 2;
                // ----------

                strPartnerData = "";
                //if (chkPCountryLivingIn.GetItemCheckState(0) != CheckState.Checked)
                //{
                for (int i = 0; i < chkPCountryLivingIn.CheckedItems.Count; i++)
                {
                    strPartnerData += ((System.Data.DataRowView)(chkPCountryLivingIn.CheckedItems[i])).Row.ItemArray[0] + ",";
                }
                strPartnerData = strPartnerData.TrimEnd(',');
                objtbl_PartnersPreferencesProp.CountryLivingIn = strPartnerData;
                //}// ----------

                strPartnerData = "";
                //if (chkPVisaStatus.GetItemCheckState(0) != CheckState.Checked)
                //{
                for (int i = 0; i < chkPVisaStatus.CheckedItems.Count; i++)
                {
                    strPartnerData += ((System.Data.DataRowView)(chkPVisaStatus.CheckedItems[i])).Row.ItemArray[0] + ",";
                }

                strPartnerData = strPartnerData.TrimEnd(',');
                objtbl_PartnersPreferencesProp.ResidencyStatus = strPartnerData;
                //}// ----------

                strPartnerData = "";
                //if (chkPEducation.GetItemCheckState(0) != CheckState.Checked)
                //{
                for (int i = 0; i < chkPEducation.CheckedItems.Count; i++)
                {
                    strPartnerData += ((System.Data.DataRowView)(chkPEducation.CheckedItems[i])).Row.ItemArray[0] + ",";
                }
                strPartnerData = strPartnerData.TrimEnd(',');
                objtbl_PartnersPreferencesProp.Education = strPartnerData;
                //}// ----------

                strPartnerData = "";
                //if (chkPOccupation.GetItemCheckState(0) != CheckState.Checked)
                //{
                for (int i = 0; i < chkPOccupation.CheckedItems.Count; i++)
                {
                    strPartnerData += ((System.Data.DataRowView)(chkPOccupation.CheckedItems[i])).Row.ItemArray[0] + ",";
                }
                strPartnerData = strPartnerData.TrimEnd(',');
                objtbl_PartnersPreferencesProp.Occupation = strPartnerData;
                //}// ----------

                strPartnerData = "";
                //if (chkPWorkingWith.GetItemCheckState(0) != CheckState.Checked)
                //{
                for (int i = 0; i < chkPWorkingWith.CheckedItems.Count; i++)
                {
                    strPartnerData += ((System.Data.DataRowView)(chkPWorkingWith.CheckedItems[i])).Row.ItemArray[0] + ",";
                }
                strPartnerData = strPartnerData.TrimEnd(',');
                objtbl_PartnersPreferencesProp.WorkingWith = strPartnerData;
                //}
                // ----------
                objtbl_PartnersPreferencesProp.HaveChildren = Convert.ToBoolean(cmbPHaveChildrens.SelectedValue);
                objtbl_PartnersPreferencesProp.AnnualIncome = Convert.ToInt32(ddlPAnnualIncome.SelectedValue);
                objtbl_PartnersPreferencesProp.AnnualIncomeCurrency = Convert.ToInt32(ddlPAnnualIncomeCurrency.SelectedValue);
                objtbl_PartnersPreferencesProp.AboutPartner = txtAboutPartner.Text;

                objtbl_PartnersPreferencesProp.Religion = "";
                objtbl_PartnersPreferencesProp.MotherTongue = "";
                objtbl_PartnersPreferencesProp.SubCaste = "";
                objtbl_PartnersPreferencesProp.Diet = "0";
                objtbl_PartnersPreferencesProp.Smoke = "0";
                objtbl_PartnersPreferencesProp.Drink = "0";
                objtbl_PartnersPreferencesProp.BodyType = "";
                objtbl_PartnersPreferencesProp.Complexion = "";
                objtbl_PartnersPreferencesProp.HealthProblem = "";
                objtbl_PartnersPreferencesProp.StateCity = "";


                tbl_PartnersPreferencesBAL objtbl_PartnersPreferencesBAL = new tbl_PartnersPreferencesBAL();
                objtbl_PartnersPreferencesBAL.InsertUpdate_Data(objtbl_PartnersPreferencesProp);
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void Delete_UpdateMemberData(int MemberCode)
        {
            try
            {
                tbl_UpdateMemberMasterProp Objtbl_UpdateMemberMasterProp = new tbl_UpdateMemberMasterProp();
                Objtbl_UpdateMemberMasterProp.MemberCode = MemberCode;

                tbl_UpdateMemberMasterBAL Objtbl_UpdateMemberMasterBAL = new tbl_UpdateMemberMasterBAL();
                Objtbl_UpdateMemberMasterBAL.Delete_Data(Objtbl_UpdateMemberMasterProp);
            }
            catch
            {
            }
        }

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                //if (PhotoExists >= 3)
                //{
                //    ShowGuidMessage(0, new Exception("Maximum 3 Photos can be uploaded!"));
                //    return;
                //}
                OpenFileDialog opFilePhoto = new OpenFileDialog();
                opFilePhoto.Filter = "Image files (*.jpg, *.png, *.jpeg)|*.jpg;*.jpeg;*.png";

                if (opFilePhoto.ShowDialog() == DialogResult.OK)
                {
                    //List<string> UploadedFilesPath = new List<string>();
                    if (opFilePhoto.FileNames.Length <= 5)
                    {
                        bool SizeErr = false;
                        foreach (string singlefile in opFilePhoto.FileNames)
                        {
                            byte[] b = System.IO.File.ReadAllBytes(singlefile);
                            if (b.Length > 0)
                            {
                                if (b.Length > 500000)
                                {
                                    SizeErr = true;
                                    continue;
                                }
                                int MemberCode = Convert.ToInt32(lblMemberCode.Text);
                                UploadImage(singlefile, MemberCode);

                                //ftpUpload ObjftpUpload = new ftpUpload();
                                //string Result = ObjftpUpload.UploadFile(singlefile, "ftp://mehtainfosoft.com/httpdocs/images/1/" + System.IO.Path.GetFileName(singlefile), "mehtain1", "mehta@123");
                                //if (Result != "")
                                //{
                                //    PictureBox pic = new PictureBox();
                                //    pic.Parent = flMemberPhotos;
                                //    pic.Height = 225;
                                //    pic.Width = 150;
                                //    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                                //    pic.Load("http://www.mehtainfosoft.com/images/1/" + System.IO.Path.GetFileName(singlefile));
                                //    pic.Show();
                                //}
                            }
                        }
                        if (SizeErr)
                            throw new Exception("Problem in uploading one or more file(s)! size are too large. (Limit 500 KB)");
                    }
                    else
                        throw new Exception("Maximum 5 files can be uploaded in profile picture.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        private void UploadImage(string FName, int MemCode)
        {
            string sSavePath = "";
            string sThumbExtension = "";

            string sFilename = "";

            int intThumbWidth;
            int intThumbHeight;

            try
            {
                // Set constant values
                sSavePath = "ftp://anantmatrimony.com/httpdocs/MemberPhoto/";
                sThumbExtension = "_thumb";
                intThumbWidth = 200;//130;
                intThumbHeight = 272;//175;

                // Check file extension (must be JPG)
                string ext = System.IO.Path.GetExtension(FName).ToLower();
                if (ext != ".jpg" && ext != ".jpeg" && ext != ".png")
                {
                    MessageBox.Show("The file must have an extension of JPG, JPEG or PNG", "Image Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                sFilename = MemCode + "_" + DateTime.Now.ToString("HHmmssfff"); // System.IO.Path.GetFileName(myFile.FileName);
                string sThumbFile = sFilename + sThumbExtension + ext;
                sFilename = sFilename + ext;

                string SourceFile = System.IO.Path.GetDirectoryName(FName) + "\\" + sFilename;

                byte[] b = System.IO.File.ReadAllBytes(FName);

                System.IO.MemoryStream msImage = new System.IO.MemoryStream(b);
                //--------------- Water Mark Text ----------------------

                Bitmap bmp = new Bitmap(msImage); //op.OpenFile());
                Graphics canvas = null; // Graphics.FromImage(bmp);
                try
                {
                    Bitmap bmpNew = new Bitmap(bmp.Width, bmp.Height);
                    canvas = Graphics.FromImage(bmpNew);
                    canvas.DrawImage(bmp, new Rectangle(0, 0,
    bmpNew.Width, bmpNew.Height), 0, 0, bmp.Width, bmp.Height,
    GraphicsUnit.Pixel);
                    //canvas.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);
                    bmp = bmpNew;
                }
                catch (Exception ee) // Catch exceptions 
                {
                    MessageBox.Show(ee.Message);
                }
                // Here replace "Text" with your text and you also can assign Font Family, Color, Position Of Text etc. 
                //            canvas.DrawString("ANANT MATRIMONY", new Font("Verdana", 14,
                //FontStyle.Bold), new SolidBrush(Color.Red), (bmp.Width / 2),
                //(bmp.Height / 2));

                //canvas.RotateTransform(0, MatrixOrder.Append);

                canvas.DrawString("ANANT MATRIMONY", new Font("Verdana", 20,
    FontStyle.Bold), new SolidBrush(Color.Beige), 20,
    bmp.Height - 50);

                // Save or display the image where you want. 
                bmp.Save(SourceFile, System.Drawing.Imaging.ImageFormat.Jpeg);

                //-------------------End Water Mark Text--------------------


                Bitmap myBitmap = null;

                ftpUpload ObjftpUpload = new ftpUpload();
                string Result = ObjftpUpload.UploadFile(SourceFile, sSavePath + sFilename, "kankukanya_ftp", "Changeme@123");
                //string Result = ObjftpUpload.UploadFile(SourceFile, sSavePath, "anantmatrimony", "anant@123");
                if (Result != "")
                {
                    // Check whether the file is really a JPEG by opening it
                    System.Drawing.Image.GetThumbnailImageAbort myCallBack =
                                   new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);

                    myBitmap = new Bitmap(SourceFile);

                    // Save thumbnail and output it onto the webpage
                    System.Drawing.Image myThumbnail
                            = myBitmap.GetThumbnailImage(intThumbWidth,
                                                         intThumbHeight, myCallBack, IntPtr.Zero);

                    myThumbnail.Save(sThumbFile);
                    ftpUpload ObjThumbUpload = new ftpUpload();
                    string ResultThumb = ObjThumbUpload.UploadFile(sThumbFile, sSavePath + sThumbFile, "kankukanya_ftp", "Changeme@123");
                    //string ResultThumb = ObjThumbUpload.UploadFile(sThumbFile, sSavePath, "anantmatrimony", "anant@123");

                    PictureBox pic = new PictureBox();
                    pic.Parent = flMemberPhotos;
                    pic.Height = 225;
                    pic.Width = 150;
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Load("http://www.anantmatrimony.com/MemberPhoto/" + sThumbFile);
                    //pic.Load("http://www.kankukanya/MemberPhoto/" + sThumbFile);
                    pic.Show();

                    myThumbnail.Dispose();
                    myBitmap.Dispose();

                    SavePhotosDB(sFilename, MemCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillMemberPhotos(int MemberCode)
        {
            lnkPhoto1.Visible = false;
            lnkPhoto2.Visible = false;
            lnkPhoto3.Visible = false;

            tbl_MemberPhotosProp Objtbl_MemberPhotosProp = new tbl_MemberPhotosProp();
            Objtbl_MemberPhotosProp.MemberCode = MemberCode;

            tbl_MemberPhotosBAL Objtbl_MemberPhotosBAL = new tbl_MemberPhotosBAL();
            DataSet dsPhotos = Objtbl_MemberPhotosBAL.Select_Data(Objtbl_MemberPhotosProp);

            for (int i = 0; i < dsPhotos.Tables[0].Rows.Count; i++)
            {
                Panel pnl = new Panel();
                pnl.Parent = flMemberPhotos;
                pnl.Height = 225;
                pnl.Width = 150;

                string strp = @"http://anantmatrimony.com/MemberPhoto/" + Convert.ToString(dsPhotos.Tables[0].Rows[i]["PhotoFileName"]);
                if (i == 0)
                {
                    lnkPhoto1.Visible = true;
                    lnkPhoto1.Tag = strp;
                }
                if (i == 1)
                {
                    lnkPhoto2.Visible = true;
                    lnkPhoto2.Tag = strp;
                }
                if (i == 2)
                {
                    lnkPhoto3.Visible = true;
                    lnkPhoto3.Tag = strp;
                }

                PictureBox pic = new PictureBox();
                pic.Parent = pnl;
                pic.Height = 180;
                pic.Width = 120;
                pic.Location = new Point(15, 3);

                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                try
                {
                    //string strp = @"http://www.anantmatrimony.com/MemberPhoto/" + Convert.ToString(dsPhotos.Tables[0].Rows[i]["PhotoFileName"]);
                    pic.LoadAsync(strp);
                    pic.ImageLocation = strp;
                    pic.Load(strp);
                    //pic.Load("http://www.anantmatrimony.com/MemberPhoto/" + Convert.ToString(dsPhotos.Tables[0].Rows[i]["PhotoFileName"]));
                    WebRequest request = WebRequest.Create(strp);
                    request.Credentials = new System.Net.NetworkCredential("hemish22_a", "Changeme@123");
                    using (var responce = request.GetResponse())
                    {
                        using (var str = responce.GetResponseStream())
                        {
                            pic.Image = Bitmap.FromStream(str);
                        }
                    }
                }
                catch
                {
                }

                pic.Show();

                Button btnDelete = new Button();
                btnDelete.Parent = pnl;
                btnDelete.Height = 25;
                btnDelete.Width = 50;
                btnDelete.Location = new Point(15, 189);
                btnDelete.Tag = MemberCode + "|" + Convert.ToString(dsPhotos.Tables[0].Rows[i]["PhotoFileName"]);
                btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
                btnDelete.Text = "Delete";
                btnDelete.FlatStyle = FlatStyle.Flat;

                btnDelete.Show();

                Button btnEdit = new Button();
                btnEdit.Parent = pnl;
                btnEdit.Height = 25;
                btnEdit.Width = 75;
                btnEdit.Location = new Point(70, 189);
                btnEdit.Tag = MemberCode + "|" + Convert.ToString(dsPhotos.Tables[0].Rows[i]["PhotoFileName"]);
                btnEdit.Click += new System.EventHandler(this.btnDownload_Click);
                btnEdit.Text = "Download Full Image";
                btnEdit.FlatStyle = FlatStyle.Flat;

                btnDelete.Show();
            }
            PhotoExists = dsPhotos.Tables[0].Rows.Count;
        }



        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                int mCode = Convert.ToInt32(btn.Tag.ToString().Split('|')[0]);
                string PhotoFileName = Convert.ToString(btn.Tag.ToString().Split('|')[1]);

                PictureBox MemberPic = new PictureBox();
                MemberPic.Load("http://www.anantmatrimony.com/MemberPhoto/" + PhotoFileName);
                // MemberPic.Load("http://www.kankukanya.com/MemberPhoto/" + PhotoFileName);


                SaveFileDialog svDlg = new SaveFileDialog();
                svDlg.FileName = btn.Tag.ToString().Split('|')[0] + "." + Convert.ToString(PhotoFileName.Split('.')[1]);
                svDlg.Filter = Convert.ToString(PhotoFileName.Split('.')[1]) + "|" + Convert.ToString(PhotoFileName.Split('.')[1]);
                if (svDlg.ShowDialog() == DialogResult.OK)
                {
                    if (svDlg.FileName != "")
                    {
                        if (!svDlg.FileName.EndsWith(Convert.ToString(PhotoFileName.Split('.')[1])))
                            MemberPic.Image.Save(svDlg.FileName + "." + Convert.ToString(PhotoFileName.Split('.')[1]));
                        else
                            MemberPic.Image.Save(svDlg.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SavePhotosDB(string fileName, int MemCode)
        {
            try
            {
                int TotalPhoto = 0;
                tbl_MemberPhotosProp Objtbl_MemberPhotosProp = new tbl_MemberPhotosProp();
                Objtbl_MemberPhotosProp.MemberCode = MemCode;
                Objtbl_MemberPhotosProp.PhotoFileName = fileName;

                tbl_MemberPhotosBAL Objtbl_MemberPhotosBAL = new tbl_MemberPhotosBAL();
                Objtbl_MemberPhotosBAL.InsertUpdate_Data(Objtbl_MemberPhotosProp, ref TotalPhoto);
                //PhotoExists = TotalPhoto;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddMemberShip_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMemberShipType.Text == "")
                {
                    MessageBox.Show("Please Select MembershipType", "MembershipType Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMemberShipType.Focus();
                    return;
                }
                if (txtMemberShipType.Text != "")
                {
                    if (txtAmountReceived.Text == "")
                    {
                        MessageBox.Show("Please Enater Amount", "Amount Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtAmountReceived.Focus();
                        return;
                    }
                }
                RowNo = dgvMemershipDetails.Rows.Count;
                if (lblSrNo.Text != "")
                {
                    for (int cnt = 0; cnt < dgvMemershipDetails.Rows.Count; cnt++)
                    {
                        if (lblSrNo.Text == Convert.ToString(dgvMemershipDetails[(int)CI.SerialNo, cnt].Value))
                        {
                            dgvMemershipDetails[(int)CI.StartDate, cnt].Value = dtpStartDate.Text;
                            dgvMemershipDetails[(int)CI.MembershipMonth, cnt].Value = updwnMembershipMonth.Value;
                            dgvMemershipDetails[(int)CI.EndDate, cnt].Value = dtpEndDate.Text;
                            dgvMemershipDetails[(int)CI.MemberShipTypeCode, cnt].Value = txtMemberShipTypeCode.Text;
                            dgvMemershipDetails[(int)CI.MemberShipType, cnt].Value = txtMemberShipType.Text;
                            dgvMemershipDetails[(int)CI.AmountReceived, cnt].Value = txtAmountReceived.Text;
                            dgvMemershipDetails[(int)CI.PayBy, cnt].Value = ddlPayBy.SelectedValue;
                            dgvMemershipDetails[(int)CI.ChequeNo, cnt].Value = txtChaqueNo.Text;
                            dgvMemershipDetails[(int)CI.ChequeDate, cnt].Value = dtpChaqueDate.Text;
                            dgvMemershipDetails[(int)CI.BankDetail, cnt].Value = txtBankBranch.Text;
                        }
                    }
                }
                else
                {
                    dgvMemershipDetails.Rows.Add();
                    lblSrNo.Text = RowNo.ToString();
                    dgvMemershipDetails[(int)CI.Edit, RowNo].Value = "Edit";
                    dgvMemershipDetails[(int)CI.Delete, RowNo].Value = "Delete";
                    dgvMemershipDetails[(int)CI.SerialNo, RowNo].Value = 0;
                    dgvMemershipDetails[(int)CI.StartDate, RowNo].Value = dtpStartDate.Text;
                    dgvMemershipDetails[(int)CI.MembershipMonth, RowNo].Value = updwnMembershipMonth.Value;
                    dgvMemershipDetails[(int)CI.EndDate, RowNo].Value = dtpEndDate.Text;
                    dgvMemershipDetails[(int)CI.MemberShipTypeCode, RowNo].Value = txtMemberShipTypeCode.Text;
                    dgvMemershipDetails[(int)CI.MemberShipType, RowNo].Value = txtMemberShipType.Text;
                    dgvMemershipDetails[(int)CI.AmountReceived, RowNo].Value = txtAmountReceived.Text;
                    dgvMemershipDetails[(int)CI.PayBy, RowNo].Value = ddlPayBy.SelectedValue;
                    dgvMemershipDetails[(int)CI.ChequeNo, RowNo].Value = txtChaqueNo.Text;
                    dgvMemershipDetails[(int)CI.ChequeDate, RowNo].Value = dtpChaqueDate.Text;
                    dgvMemershipDetails[(int)CI.BankDetail, RowNo].Value = txtBankBranch.Text;

                }
                lblSrNo.Text = "";
                txtMemberShipType.Text = "";
                txtMemberShipTypeCode.Text = "";
                dtpJoinDate.Text = DateTime.Now.ToString();
                dtpStartDate.Text = DateTime.Now.ToString();
                updwnMembershipMonth.Value = 1;
                dtpEndDate.Text = DateTime.Now.ToString();
                txtAmountReceived.Text = "";
                ddlPayBy.SelectedIndex = 1;
                txtChaqueNo.Text = "";
                dtpChaqueDate.Text = DateTime.Now.ToString();
                txtBankBranch.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtMemberShipType_Validated(object sender, EventArgs e)
        {
            try
            {
                this.objGlobal.ScreenPosition(this.txtMemberShipType, "0:300");
                this.objGlobal.OpenHelpTxtBox_Validating(this.dvMemberShipType, this.strMemberShipType, "MembershipType", true, this.txtMemberShipType, this.txtMemberShipTypeCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updwnMembershipMonth_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                CalculateEndDate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CalculateEndDate()
        {
            dtpEndDate.Value = dtpStartDate.Value.AddMonths(Convert.ToInt32(updwnMembershipMonth.Value));
        }

        private void frmMemberMaster_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ActiveControl != null)
                {
                    if (ActiveControl.Tag.ToString() != "NoTab")
                    {
                        //SendKeys.Send("{TAB}");
                    }
                }
            }
        }

        private void txtMemberName_Validating(object sender, CancelEventArgs e)
        {
            if (txtMemberName.Text == "")
            {
                MessageBox.Show("Please Enter Member Name", "Member Name Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemberName.Focus();
                return;
            }
        }

        private void txtHomeAddress1_Validating(object sender, CancelEventArgs e)
        {
            if (txtHomeAddress1.Text == "")
            {
                MessageBox.Show("Please Enter Address 1", "Address 1 Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHomeAddress1.Focus();
                return;
            }
        }

        private void txtMobileNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtMobileNo.Text == "")
            {
                MessageBox.Show("Please Enter Mobile Number", "Mobile Number Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMobileNo.Focus();
                return;
            }
        }

        private void txtEmailID_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmailID.Text == "")
            {
                MessageBox.Show("Please Enter Email", "Email Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmailID.Focus();
                return;
            }
        }

        public void SaveMemebrshipMaster(int MemberCode)
        {
            try
            {
                int intSrNo = 1;
                bool bolSave = false;

                tbl_MembershipMasterProp objtbl_MembershipMasterProp = new tbl_MembershipMasterProp();
                if (MemberCode > 0)
                {
                    objtbl_MembershipMasterProp.MemberCode = MemberCode;
                }

                tbl_MembershipMasterBAL objtbl_MembershipMasterBAL = new tbl_MembershipMasterBAL();
                //objtbl_MembershipMasterBAL.Delete_Data(objtbl_MembershipMasterProp);

                for (int cnt = 0; cnt < dgvMemershipDetails.Rows.Count; cnt++)
                {
                    if (Convert.ToString(dgvMemershipDetails[(int)CI.MemberShipType, cnt].Value) != "")
                    {
                        objtbl_MembershipMasterProp.MemberCode = MemberCode;
                        objtbl_MembershipMasterProp.SerialNo = Convert.ToInt32(dgvMemershipDetails[(int)CI.SerialNo, cnt].Value);
                        objtbl_MembershipMasterProp.MemberShipTypeCode = Convert.ToInt32(dgvMemershipDetails[(int)CI.MemberShipTypeCode, cnt].Value);
                        objtbl_MembershipMasterProp.StartDate = Convert.ToDateTime(dgvMemershipDetails[(int)CI.StartDate, cnt].Value);
                        objtbl_MembershipMasterProp.EndDate = Convert.ToDateTime(dgvMemershipDetails[(int)CI.EndDate, cnt].Value);
                        objtbl_MembershipMasterProp.MembershipMonth = Convert.ToInt32(dgvMemershipDetails[(int)CI.MembershipMonth, cnt].Value);

                        objtbl_MembershipMasterProp.FacilityCode = "";

                        objtbl_MembershipMasterProp.AmountReceived = Convert.ToInt32(dgvMemershipDetails[(int)CI.AmountReceived, cnt].Value);
                        objtbl_MembershipMasterProp.PayBy = Convert.ToInt32(dgvMemershipDetails[(int)CI.PayBy, cnt].Value);
                        if (Convert.ToString(dgvMemershipDetails[(int)CI.ChequeNo, cnt].Value) != "")
                        {
                            objtbl_MembershipMasterProp.ChequeNo = Convert.ToInt32(dgvMemershipDetails[(int)CI.ChequeNo, cnt].Value);
                        }
                        else
                        {
                            objtbl_MembershipMasterProp.ChequeNo = 0;
                        }
                        if (Convert.ToString(dgvMemershipDetails[(int)CI.ChequeDate, cnt].Value) != "")
                        {
                            objtbl_MembershipMasterProp.ChequeDate = Convert.ToDateTime(dgvMemershipDetails[(int)CI.ChequeDate, cnt].Value);
                        }
                        else
                        {
                            //objtbl_MembershipMasterProp.ChequeDate = "NULL";
                        }
                        objtbl_MembershipMasterProp.BankDetail = Convert.ToString(dgvMemershipDetails[(int)CI.BankDetail, cnt].Value);
                        objtbl_MembershipMasterProp.IFSC = "";
                        objtbl_MembershipMasterBAL.InsertUpdate_Data(objtbl_MembershipMasterProp);
                        intSrNo++;
                        bolSave = true;
                    }
                }
                //dgvMemershipDetails.Rows.Clear();
                //if (bolSave)
                //{
                MessageBox.Show("Membership Details Update", "Membership Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillMembershipDetail(Convert.ToInt32(lblMemberCode.Text));
                return;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvMemershipDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == (int)CI.Edit)
                {
                    RowNo = e.RowIndex;
                    lblSrNo.Text = Convert.ToString(dgvMemershipDetails[(int)CI.SerialNo, e.RowIndex].Value);
                    txtMemberShipType.Text = Convert.ToString(dgvMemershipDetails[(int)CI.MemberShipType, e.RowIndex].Value);
                    txtMemberShipTypeCode.Text = Convert.ToString(dgvMemershipDetails[(int)CI.MemberShipTypeCode, e.RowIndex].Value);
                    dtpJoinDate.Text = Convert.ToString(dgvMemershipDetails[(int)CI.StartDate, e.RowIndex].Value);
                    dtpStartDate.Text = Convert.ToString(dgvMemershipDetails[(int)CI.StartDate, e.RowIndex].Value);
                    updwnMembershipMonth.Value = Convert.ToInt32(dgvMemershipDetails[(int)CI.MembershipMonth, e.RowIndex].Value);
                    dtpEndDate.Text = Convert.ToString(dgvMemershipDetails[(int)CI.EndDate, e.RowIndex].Value);
                    txtAmountReceived.Text = Convert.ToString(dgvMemershipDetails[(int)CI.AmountReceived, e.RowIndex].Value);
                    ddlPayBy.SelectedIndex = Convert.ToInt32(dgvMemershipDetails[(int)CI.PayBy, e.RowIndex].Value);
                    txtChaqueNo.Text = Convert.ToString(dgvMemershipDetails[(int)CI.ChequeNo, e.RowIndex].Value);
                    dtpChaqueDate.Text = Convert.ToString(dgvMemershipDetails[(int)CI.ChequeDate, e.RowIndex].Value);
                    txtBankBranch.Text = Convert.ToString(dgvMemershipDetails[(int)CI.BankDetail, e.RowIndex].Value);
                    txtMemberShipType.Focus();
                }
                else if (e.ColumnIndex == (int)CI.Delete)
                {
                    if (MessageBox.Show("Are you sure you want to Delete?", "Delete Membership Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        RowNo = e.RowIndex;
                        if (Convert.ToString(dgvMemershipDetails[(int)CI.SerialNo, e.RowIndex].Value) != "")
                        {
                            int SrNo = Convert.ToInt32(dgvMemershipDetails[(int)CI.SerialNo, e.RowIndex].Value);
                            if (SrNo > 0)
                            {
                                tbl_MembershipMasterProp objtbl_MembershipMasterProp = new tbl_MembershipMasterProp();
                                int MemberCode = Convert.ToInt32(lblMemberCode.Text);
                                if (MemberCode > 0)
                                {
                                    objtbl_MembershipMasterProp.MemberCode = MemberCode;
                                    objtbl_MembershipMasterProp.SerialNo = SrNo;
                                }
                                tbl_MembershipMasterBAL objtbl_MembershipMasterBAL = new tbl_MembershipMasterBAL();
                                objtbl_MembershipMasterBAL.Delete_Data(objtbl_MembershipMasterProp);
                            }
                        }
                        dgvMemershipDetails.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_MemberShipDetails_Click(object sender, EventArgs e)
        {
            try
            {
                SaveMemebrshipMaster(Convert.ToInt32(lblMemberCode.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtAmountReceived_Validating(object sender, CancelEventArgs e)
        {
            if (txtMemberShipType.Text != "")
            {
                if (txtAmountReceived.Text == "")
                {
                    MessageBox.Show("Please Enter Amount", "Amount Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAmountReceived.Focus();
                }
            }
        }

        private void txtChaqueNo_Validating(object sender, CancelEventArgs e)
        {
            if (ddlPayBy.SelectedText == "Cheque / DD")
            {
                if (txtChaqueNo.Text == "")
                {
                    MessageBox.Show("Please Enter Cheque Number", "Cheque Number Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtChaqueNo.Focus();
                }
            }
        }

        private void txtBankBranch_Validating(object sender, CancelEventArgs e)
        {
            if (ddlPayBy.SelectedText == "Cheque / DD")
            {
                if (txtBankBranch.Text == "")
                {
                    MessageBox.Show("Please Enter Bank Branch", "Bank Branch Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBankBranch.Focus();
                }
            }
        }

        private void updwnMembershipMonth_Validated(object sender, EventArgs e)
        {
            CalculateEndDate();
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            CalculateEndDate();
        }

        private void dtpStartDate_Validated(object sender, EventArgs e)
        {
            CalculateEndDate();
        }

        private void btnSave_MemberDtl_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckValidate())
                {
                    return;
                }
                string _status = "New";
                if (txtProfileId.Text != "")
                {
                    _status = "Update";
                }

                //string s = cmbBirthPlace.Text;
                this.objEventLoging.AppClickLog("MemberMaster", "Save", txtProfileId.Text, strMemberCode, cmbisActive.Text + ", Status= " + _status);
                int intMemberCode = 0;
                if (strMemberCode != "")
                {
                    intMemberCode = Convert.ToInt32(strMemberCode);
                    lblMemberCode.Text = strMemberCode.ToString();
                }
                //if (Global.strMemberCode != "")
                //{
                //    intMemberCode = Convert.ToInt32(Global.strMemberCode);
                //    lblMemberCode.Text = Global.strMemberCode.ToString();
                //}
                bool isMasterSaved = false;
                isMasterSaved = SaveMember_Details(intMemberCode);
                if (isMasterSaved)
                {
                    if (intMemberCode != 0)
                    {
                        //objGlobal.SendMail("noreply@anantmatrimony.com", "sanket164@gmail.com", "Subject Test", "Testing Body Welcome Anant");
                        MessageBox.Show("Member Details Update successfully ", "Member Details Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string strHTML = "<html> ";
                        strHTML += " <head> ";
                        strHTML += " <title>Anant Matrimony</title> ";
                        strHTML += " <link href='https://fonts.googleapis.com/css?family=Lato:400,500,600,700' rel='stylesheet' /> ";
                        strHTML += " </head> ";
                        strHTML += " <body style='font-family: 'Lato', sans-serif;background-color: #ffffff;margin: 0px;padding: 0px;width: 100%;font-size: 15px;font-weight: 400;color: #323232;line-height: 18px;text-align:left;'> ";
                        strHTML += " <table width='100%' border='0' align='center' cellpadding='0' cellspacing='0' class='contentbg'> ";
                        strHTML += " <tr> <td valign='top'>  ";
                        strHTML += " <table width='50%' border='0' cellspacing='0' cellpadding='0' align='center'> ";
                        strHTML += " <tr> <td valign='top' bgcolor='#FFFFFF'>  ";
                        strHTML += " <table width='100%' border='0' align='center' cellpadding='0' cellspacing='0'>  ";
                        strHTML += " <tr> <td width='80%' height='105' align='left' valign='top'> ";
                        strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
                        strHTML += " <tr>  ";
                        strHTML += " <td valign='top' bgcolor='#ca3b3b' style='padding:35px;'><a href='#'><img src='http://www.anantmatrimony.com/images/logo.png' width='349' height='107' alt='logo' style='margin-left: auto;margin-right: auto;' /></a></td> ";
                        strHTML += " </tr> </table> </td> </tr> </table> </td> </tr> </table> </td> </tr> <tr> ";
                        strHTML += " <td valign='top'> ";
                        strHTML += " <table width='50%' border='0' cellspacing='0' cellpadding='0' align='center'> ";
                        strHTML += " <tr> <td valign='top'> ";
                        strHTML += " <table width='100%' border='0' align='center' cellpadding='0' cellspacing='0'> ";
                        strHTML += " <tr> <td valign='top' style='padding:20px 0px;'> ";
                        strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> <tr> ";
                        strHTML += " <td width='100%' valign='top'> ";
                        strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
                        strHTML += " <tr> ";
                        strHTML += " <td width='100%' valign='top' style='text-align: left; font-size: 22px; font-weight: 600; color: #323232; border-bottom: 1px solid #e8e8e8;font-family: inherit; '> ";
                        strHTML += " <p>Hello " + txtMemberName.Text + " ,</p> ";
                        strHTML += " <p>Thank you for register with us.</p> ";
                        strHTML += " <p>AnantMatrimony.com Has Gained Expertise in Matrimony Services and match making From More than 15 Years (since2003)</p> ";
                        strHTML += " <p>More than 22000+ Profiles registered with us and they have experienced the best Services from Us</p> ";
                        strHTML += " <p>2200+ Pair of Couples From all over the World have Found Their Soul mates With the Support of us.</p> ";

                        strHTML += " <p>Visis us on <a href='http://www.anantmatrimony.com' target='_blank'>www.anantmatrimony.com</a></p> ";
                        strHTML += " </td> </tr> <tr> ";
                        strHTML += " <td class='footerheading' width='100%' valign='top' style='padding-bottom:16px;text-align:center;font-size: 22px;font-weight: 600;color: #323232;line-height: 44px;'>For More Details, Call Us!</td> ";
                        strHTML += " </tr> <tr> ";
                        strHTML += " <td width='100%' valign='top' style='padding-bottom:16px;border-bottom:1px solid #e8e8e8;font-size: 35px;font-weight: 600;color: #f54d56;line-height: 24px;text-align:center;'>9428412065/9998489093</td> ";
                        strHTML += " </tr> <tr> ";
                        strHTML += " <td width='100%' valign='top' style='padding-bottom: 16px; border-bottom: 1px solid #e8e8e8; color: #323232; line-height: 24px; text-align: justify; '> ";
                        strHTML += " <p style=' padding: 0px; margin: 0px; margin-top: 15px;'>425, 4th Floor, Saman Complex,</p> ";
                        strHTML += " <p style=' padding: 0px; margin: 0px;'>Opp. Satyam Mall,</p> ";
                        strHTML += " <p style=' padding: 0px; margin: 0px;'>Near Jodhpur Cross Roads,</p> ";
                        strHTML += " <p style=' padding: 0px; margin: 0px;'>Satellite, Ahmedabad,</p> ";
                        strHTML += " <p style=' padding: 0px; margin: 0px;'>Gujarat 380015</p> ";
                        strHTML += " </td> </tr> </table> </td> </tr> </table> </td> </tr> </table> </td> </tr> <tr> <td valign='top'> ";
                        strHTML += " <table width='100%' border='0' align='center' cellpadding='0' cellspacing='0'> ";
                        strHTML += " <tr> <td valign='top' style='padding-bottom:33px;'> ";
                        strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
                        strHTML += " <tr> <td width='100%' valign='top'> ";
                        strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
                        strHTML += " <tr> <td valign='top' style='padding-top:21px; padding-bottom:17px;'> ";
                        strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'></table> ";
                        strHTML += " </td> </tr> <tr> ";
                        strHTML += " <td valign='top' style='font-size:13px;color:#989797;text-align:center; padding-right:84px;'> ";
                        strHTML += " © 2003 - 2019 AnantMatrimony.com & Kankukanya.com. All Rights Reserved.<br /> ";
                        strHTML += " </td> </tr> </table> </td>  </tr> </table> </td> </tr> </table> </td> </tr> ";
                        strHTML += " </table> </td> </tr> </table> </body> </html>";
                        objGlobal.SendMail(txtEmailID.Text, "AnantMatrimony : Registration ", strHTML, true, "noreply@anantmatrimony.com", "Changeme@123");
                        MessageBox.Show("Member Details Insert successfully ", "Member Details Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_FamilyDtl_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckValidate())
                {
                    return;
                }
                //string s = cmbBirthPlace.Text;
                int intMemberCode = 0;
                if (strMemberCode != "")
                {
                    intMemberCode = Convert.ToInt32(strMemberCode);
                    lblMemberCode.Text = strMemberCode.ToString();
                }
                //if (strMemberCode != "")
                //{
                //    intMemberCode = Convert.ToInt32(strMemberCode);
                //    lblMemberCode.Text = strMemberCode.ToString();
                //}
                bool isMasterSaved = false;
                isMasterSaved = SaveMember_Details(intMemberCode);
                if (isMasterSaved)
                {
                    if (intMemberCode != 0)
                    {
                        MessageBox.Show("Member's Family Details Update successfully ", "Member's Family Details Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Member's Family Details Insert successfully ", "Member's Family Details Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_PartnerPref_Click(object sender, EventArgs e)
        {
            try
            {
                int intMemberCode = 0;
                if (strMemberCode != "")
                {
                    intMemberCode = Convert.ToInt32(strMemberCode);
                    lblMemberCode.Text = strMemberCode.ToString();
                }
                bool isMasterSaved = false;
                isMasterSaved = SavePartnerPreferences(intMemberCode);
                if (isMasterSaved)
                {
                    Delete_UpdateMemberData(intMemberCode);
                    MessageBox.Show("Partner Preference details update successfully ", "Partner Preference Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFollowUpListSave_Click(object sender, EventArgs e)
        {
            try
            {
                tbl_FollowUpBAL objBal = new tbl_FollowUpBAL();
                tbl_FollowUp Objtbl_tbl_FollowUpProp = new tbl_FollowUp();

                Objtbl_tbl_FollowUpProp.MemberCode = Convert.ToInt32(lblMemberCode.Text);
                objBal.Delete_Data(Objtbl_tbl_FollowUpProp);

                for (int cnt = 0; cnt < dgvFollowUpList.Rows.Count; cnt++)
                {
                    if (Convert.ToString(dgvFollowUpList[(int)FL.ProfileId, cnt].Value) != "")
                    {
                        Objtbl_tbl_FollowUpProp.FollowUpId = 0;
                        Objtbl_tbl_FollowUpProp.ProfileId = Convert.ToString(dgvFollowUpList[(int)FL.ProfileId, cnt].Value);
                        Objtbl_tbl_FollowUpProp.Name = Convert.ToString(dgvFollowUpList[(int)FL.Name, cnt].Value);
                        if (Convert.ToString(dgvFollowUpList[(int)FL.Date, cnt].Value) != "")
                        {
                            Objtbl_tbl_FollowUpProp.Date = Convert.ToDateTime(dgvFollowUpList[(int)FL.Date, cnt].Value);
                        }
                        Objtbl_tbl_FollowUpProp.Status = Convert.ToString(dgvFollowUpList[(int)FL.Status, cnt].Value);
                        Objtbl_tbl_FollowUpProp.Remark1 = Convert.ToString(dgvFollowUpList[(int)FL.Remark1, cnt].Value);
                        Objtbl_tbl_FollowUpProp.Remark2 = Convert.ToString(dgvFollowUpList[(int)FL.Remark2, cnt].Value);
                        Objtbl_tbl_FollowUpProp.Remark3 = Convert.ToString(dgvFollowUpList[(int)FL.Remark3, cnt].Value);
                        Objtbl_tbl_FollowUpProp.Remark4 = Convert.ToString(dgvFollowUpList[(int)FL.Remark4, cnt].Value);
                        Objtbl_tbl_FollowUpProp.Remark5 = Convert.ToString(dgvFollowUpList[(int)FL.Remark5, cnt].Value);
                        Objtbl_tbl_FollowUpProp.MemberCode = Convert.ToInt32(lblMemberCode.Text);
                        objBal.InsertUpdate_Data(Objtbl_tbl_FollowUpProp);
                    }
                }
                MessageBox.Show("Follow up Details Updated", "Follow up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtAddFollowUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProfileId_F.Text == "")
                {
                    MessageBox.Show("Please Insert Profile Id", "Profile Id Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtProfileId_F.Focus();
                    return;
                }
                if (txtName_F.Text == "")
                {
                    MessageBox.Show("Please Insert Name", "Name Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName_F.Focus();
                    return;
                }
                RowNo = dgvFollowUpList.Rows.Count;
                if (txtFollowUpId.Text != "" && txtFollowUpId.Text != "0")
                {
                    for (int cnt = 0; cnt < dgvFollowUpList.Rows.Count; cnt++)
                    {
                        if (txtFollowUpId.Text == Convert.ToString(dgvFollowUpList[(int)FL.FollowUpId, cnt].Value))
                        {
                            dgvFollowUpList[(int)FL.ProfileId, cnt].Value = txtProfileId_F.Text;
                            dgvFollowUpList[(int)FL.Name, cnt].Value = txtName_F.Text;
                            dgvFollowUpList[(int)FL.Date, cnt].Value = dtpDate_F.Text;
                            dgvFollowUpList[(int)FL.Status, cnt].Value = txtStatus_F.Text;
                            dgvFollowUpList[(int)FL.Remark1, cnt].Value = txtRemark1_f.Text;
                            dgvFollowUpList[(int)FL.Remark2, cnt].Value = txtRemark2_f.Text;
                            dgvFollowUpList[(int)FL.Remark3, cnt].Value = txtRemark3_f.Text;
                            dgvFollowUpList[(int)FL.Remark4, cnt].Value = txtRemark4_f.Text;
                            dgvFollowUpList[(int)FL.Remark5, cnt].Value = txtRemark5_f.Text;
                            break;
                        }
                    }
                }
                else
                {
                    dgvFollowUpList.Rows.Add();
                    dgvFollowUpList[(int)FL.Edit, RowNo].Value = "Edit";
                    dgvFollowUpList[(int)FL.Delete, RowNo].Value = "Delete";
                    dgvFollowUpList[(int)FL.FollowUpId, RowNo].Value = 0;
                    dgvFollowUpList[(int)FL.ProfileId, RowNo].Value = txtProfileId_F.Text;
                    dgvFollowUpList[(int)FL.Name, RowNo].Value = txtName_F.Text;
                    dgvFollowUpList[(int)FL.Date, RowNo].Value = dtpDate_F.Text;
                    dgvFollowUpList[(int)FL.Status, RowNo].Value = txtStatus_F.Text;
                    dgvFollowUpList[(int)FL.Remark1, RowNo].Value = txtRemark1_f.Text;
                    dgvFollowUpList[(int)FL.Remark2, RowNo].Value = txtRemark2_f.Text;
                    dgvFollowUpList[(int)FL.Remark3, RowNo].Value = txtRemark3_f.Text;
                    dgvFollowUpList[(int)FL.Remark4, RowNo].Value = txtRemark4_f.Text;
                    dgvFollowUpList[(int)FL.Remark5, RowNo].Value = txtRemark5_f.Text;
                }
                txtFollowUpId.Text = "";
                txtProfileId_F.Text = "";
                txtName_F.Text = "";
                dtpDate_F.Text = "";
                txtStatus_F.Text = "";
                txtRemark1_f.Text = "";
                txtRemark2_f.Text = "";
                txtRemark3_f.Text = "";
                txtRemark4_f.Text = "";
                txtRemark5_f.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetFollowUpList(int MemberCode)
        {
            try
            {
                if (lblMemberCode.Text != "")
                {
                    tbl_FollowUpBAL objBal = new tbl_FollowUpBAL();
                    tbl_FollowUp Objtbl_tbl_FollowUpProp = new tbl_FollowUp();
                    Objtbl_tbl_FollowUpProp.MemberCode = MemberCode;
                    DataSet ds = objBal.Select_Data(Objtbl_tbl_FollowUpProp);
                    if (ds != null)
                    {
                        dgvFollowUpList.RowCount = ds.Tables[0].Rows.Count;
                        for (int cnt = 0; cnt < ds.Tables[0].Rows.Count; cnt++)
                        {
                            dgvFollowUpList[(int)FL.Edit, cnt].Value = "Edit";
                            dgvFollowUpList[(int)FL.Delete, cnt].Value = "Delete";
                            dgvFollowUpList[(int)FL.FollowUpId, cnt].Value = Convert.ToString(ds.Tables[0].Rows[cnt]["FollowUpId"]);
                            dgvFollowUpList[(int)FL.ProfileId, cnt].Value = Convert.ToString(ds.Tables[0].Rows[cnt]["ProfileId"]);
                            dgvFollowUpList[(int)FL.Name, cnt].Value = Convert.ToString(ds.Tables[0].Rows[cnt]["Name"]);
                            dgvFollowUpList[(int)FL.Date, cnt].Value = Convert.ToString(ds.Tables[0].Rows[cnt]["Date"]);
                            dgvFollowUpList[(int)FL.Status, cnt].Value = Convert.ToString(ds.Tables[0].Rows[cnt]["Status"]);
                            dgvFollowUpList[(int)FL.Remark1, cnt].Value = Convert.ToString(ds.Tables[0].Rows[cnt]["Remark1"]);
                            dgvFollowUpList[(int)FL.Remark2, cnt].Value = Convert.ToString(ds.Tables[0].Rows[cnt]["Remark2"]);
                            dgvFollowUpList[(int)FL.Remark3, cnt].Value = Convert.ToString(ds.Tables[0].Rows[cnt]["Remark3"]);
                            dgvFollowUpList[(int)FL.Remark4, cnt].Value = Convert.ToString(ds.Tables[0].Rows[cnt]["Remark4"]);
                            dgvFollowUpList[(int)FL.Remark5, cnt].Value = Convert.ToString(ds.Tables[0].Rows[cnt]["Remark5"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.GetFollowUpList() " + ex.ToString());
            }
        }

        private void dgvFollowUpList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == (int)FL.Edit)
                {
                    RowNo = e.RowIndex;
                    txtProfileId_F.Text = Convert.ToString(dgvFollowUpList[(int)FL.ProfileId, RowNo].Value);
                    txtName_F.Text = Convert.ToString(dgvFollowUpList[(int)FL.Name, RowNo].Value);
                    dtpDate_F.Text = Convert.ToString(dgvFollowUpList[(int)FL.Date, RowNo].Value);
                    txtStatus_F.Text = Convert.ToString(dgvFollowUpList[(int)FL.Status, RowNo].Value);
                    txtRemark1_f.Text = Convert.ToString(dgvFollowUpList[(int)FL.Remark1, RowNo].Value);
                    txtRemark2_f.Text = Convert.ToString(dgvFollowUpList[(int)FL.Remark2, RowNo].Value);
                    txtRemark3_f.Text = Convert.ToString(dgvFollowUpList[(int)FL.Remark3, RowNo].Value);
                    txtRemark4_f.Text = Convert.ToString(dgvFollowUpList[(int)FL.Remark4, RowNo].Value);
                    txtRemark5_f.Text = Convert.ToString(dgvFollowUpList[(int)FL.Remark5, RowNo].Value);
                    txtFollowUpId.Text = Convert.ToString(dgvFollowUpList[(int)FL.FollowUpId, RowNo].Value);
                }
                else if (e.ColumnIndex == (int)FL.Delete)
                {
                    dgvFollowUpList.Rows.RemoveAt(e.RowIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.dgvFollowUpList_CellClick() " + ex.ToString());
            }
        }

        private void btnBroSisAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbBroSis.SelectedIndex < 0)
                {
                    MessageBox.Show("Please Select Brother/Sister", "Brother/Sister Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbBroSis.Focus();
                    return;
                }
                if (txtBroSisName.Text == "")
                {
                    MessageBox.Show("Please Enter Brother/Sister Name", "Brother/Sister Name Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBroSisName.Focus();
                    return;
                }
                if (cmdBroSisMaritalStatus.SelectedIndex < 0)
                {
                    MessageBox.Show("Please Select Brother/Sister Marital Status", "Brother/Sister Marital Status Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmdBroSisMaritalStatus.Focus();
                    return;
                }
                int iRowNo = dgvSiblingDetails.Rows.Count;
                if (lblBrSrNo.Text != "")
                {
                    for (int cnt = 0; cnt < dgvSiblingDetails.Rows.Count; cnt++)
                    {
                        if (lblBrSrNo.Text == Convert.ToString(dgvSiblingDetails[(int)BS.ID, cnt].Value))
                        {
                            dgvSiblingDetails[(int)BS.BroSis, cnt].Value = cmbBroSis.Text;
                            dgvSiblingDetails[(int)BS.MaritalStatus, cnt].Value = cmdBroSisMaritalStatus.Text;
                            dgvSiblingDetails[(int)BS.Occupation, cnt].Value = cmbBroSisOccupation.Text;
                            dgvSiblingDetails[(int)BS.Name, cnt].Value = txtBroSisName.Text;
                            break;
                        }
                    }
                }
                else
                {
                    dgvSiblingDetails.Rows.Add();
                    dgvSiblingDetails[(int)BS.Edit, iRowNo].Value = "Edit";
                    dgvSiblingDetails[(int)BS.Delete, iRowNo].Value = "Delete";
                    dgvSiblingDetails[(int)BS.ID, iRowNo].Value = iRowNo;
                    dgvSiblingDetails[(int)BS.Name, iRowNo].Value = txtBroSisName.Text;
                    dgvSiblingDetails[(int)BS.BroSis, iRowNo].Value = cmbBroSis.Text;
                    dgvSiblingDetails[(int)BS.MaritalStatus, iRowNo].Value = cmdBroSisMaritalStatus.Text;
                    dgvSiblingDetails[(int)BS.Occupation, iRowNo].Value = cmbBroSisOccupation.Text;
                }
                lblBrSrNo.Text = "";
                cmbBroSis.SelectedIndex = 0;
                cmdBroSisMaritalStatus.SelectedIndex = 0;
                cmbBroSisOccupation.SelectedIndex = 0;
                txtBroSisName.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.btnBroSisAdd_Click() " + ex.ToString());
            }
        }

        private void dgvSiblingDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == (int)BS.Edit)
                {
                    int iRowNo = e.RowIndex;
                    lblBrSrNo.Text = iRowNo.ToString();
                    cmbBroSis.Text = Convert.ToString(dgvSiblingDetails[(int)BS.BroSis, iRowNo].Value);
                    txtBroSisName.Text = Convert.ToString(dgvSiblingDetails[(int)BS.Name, iRowNo].Value);
                    cmbBroSisOccupation.SelectedValue = Convert.ToString(dgvSiblingDetails[(int)BS.Occupation, iRowNo].Value);
                    cmdBroSisMaritalStatus.Text = Convert.ToString(dgvSiblingDetails[(int)BS.MaritalStatus, iRowNo].Value);
                }
                if (e.ColumnIndex == (int)BS.Delete)
                {
                    dgvSiblingDetails.Rows.RemoveAt(e.RowIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.dgvSiblingDetails_CellClick() " + ex.ToString());
            }
        }

        private void ddlMaritalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(ddlMaritalStatus.SelectedValue) == "1")////Unmarried
                {
                    ddlNoOfChildren.Enabled = false;
                    ddlLiveChildrenTogether.Enabled = false;
                }
                else if (Convert.ToString(ddlMaritalStatus.SelectedValue) == "2")////Divorced
                {
                    ddlNoOfChildren.Enabled = true;
                    ddlLiveChildrenTogether.Enabled = true;
                }
                else if (Convert.ToString(ddlMaritalStatus.SelectedValue) == "3")
                {
                    ddlNoOfChildren.Enabled = true;
                    ddlLiveChildrenTogether.Enabled = true;
                }
                if (ddlMaritalStatus.Text != "")
                {
                    string _maritalStatus = ddlMaritalStatus.Text;
                    if (_maritalStatus == "")
                    {

                    }
                    strSQL = " exec SelectCombo_tbl_MaritalStatus '" + ddlMaritalStatus.Text + "'";
                    DataTable dtMaritalStatus = objDb.GetDataTable(strSQL);
                    chkPMaritalStatus.DataSource = dtMaritalStatus;
                    chkPMaritalStatus.ValueMember = "MaritalStatusCode";
                    chkPMaritalStatus.DisplayMember = "MaritalStatus";
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.ddlMaritalStatus_SelectedIndexChanged() " + ex.ToString());
            }
        }

        private void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlCountry.SelectedIndex > 0)
                {
                    strStateCity = " SELECT 0 AS StateCityCode,'--SELECT--' AS StateCity";
                    strStateCity += " UNION ALL ";
                    strStateCity += "SELECT StateCityCode,StateCity FROM tbl_StateCity WHERE CountryCode=" + ddlCountry.SelectedValue + " ORDER BY StateCity";
                    dvSateCity = objDb.GetDataView(strStateCity);
                    ddlStateCity.DataSource = dvSateCity;
                    ddlStateCity.DisplayMember = "StateCity";
                    ddlStateCity.ValueMember = "StateCityCode";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.ddlCountry_SelectedIndexChanged() " + ex.ToString());
            }
        }

        private void ddlCaste_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlCaste.SelectedIndex > 0)
                {
                    strSubCaste = " SELECT 0 AS SubCasteCode,'--SELECT--' AS SubCaste";
                    strSubCaste += " UNION ALL ";
                    strSubCaste += "SELECT SubCasteCode,SubCaste FROM tbl_SubCaste WHERE CasteCode=" + ddlCaste.SelectedValue + " ORDER BY SubCaste";
                    dvSubCaste = objDb.GetDataView(strSubCaste);
                    ddlSubCaste.DataSource = dvSubCaste;
                    ddlSubCaste.DisplayMember = "SubCaste";
                    ddlSubCaste.ValueMember = "SubCasteCode";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.ddlCaste_SelectedIndexChanged() " + ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                int mCode = Convert.ToInt32(btn.Tag.ToString().Split('|')[0]);
                string PhotoFileName = Convert.ToString(btn.Tag.ToString().Split('|')[1]);

                //string sSavePath = "ftp://anantmatrimony.com/httpdocs/MemberPhoto/";
                string sSavePath = "ftp://anantmatrimony.com/httpdocs/MemberPhoto/";
                string sThumbExtension = "_thumb.";

                ftpUpload ObjftpUpload = new ftpUpload();
                string Result = "";
                try
                {
                    Result = ObjftpUpload.DeleteFile(sSavePath + PhotoFileName, "anantmatrimony", "Mehta@123");
                }
                catch (Exception ex) { }
                try
                {
                    Result = ObjftpUpload.DeleteFile(sSavePath + PhotoFileName.Split('.')[0] + sThumbExtension + PhotoFileName.Split('.')[1], "anantmatrimony", "Mehta@123");
                }
                catch (Exception ex) { }
                tbl_MemberPhotosProp Objtbl_MemberPhotosProp = new tbl_MemberPhotosProp();

                Objtbl_MemberPhotosProp.MemberCode = Convert.ToInt32(btn.Tag.ToString().Split('|')[0]);
                Objtbl_MemberPhotosProp.PhotoFileName = Convert.ToString(btn.Tag.ToString().Split('|')[1]);

                tbl_MemberPhotosBAL Objtbl_MemberPhotosBAL = new tbl_MemberPhotosBAL();
                Objtbl_MemberPhotosBAL.Delete_Data(Objtbl_MemberPhotosProp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtpDateofBirth_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDateofBirth.Value != null)
            {
                FillPartnerPrefBirthYear();
            }
        }

        private void rdbtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (dtpDateofBirth.Value != null)
            {
                FillPartnerPrefBirthYear();
            }
        }

        private void rdbtnMale_CheckedChanged(object sender, EventArgs e)
        {
            if (dtpDateofBirth.Value != null)
            {
                FillPartnerPrefBirthYear();
            }
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////1. Member Master Details
            ////2. Family Master Details
            ////3. Partner Prefrence Details
            ////4. Phots Details
            ////5. Membership Details
            //int newIndex = tabMain.SelectedIndex + 1;
            //string strCode = "";
            //try
            //{
            //    if (lblMemberCode.Text != "")
            //    {
            //        strCode = lblMemberCode.Text;
            //    }
            //    if (newIndex == 3)
            //    {
            //        if (strCode != "")
            //        {
            //            PartnerPrefrence(Convert.ToInt32(strCode));
            //        }
            //    }
            //    else if (newIndex == 4)
            //    {
            //        FillMemberPhotos(Convert.ToInt32(strCode));
            //    }
            //    else if (newIndex == 5)
            //    {
            //        FillMembershipDetail(Convert.ToInt32(strCode));
            //    }
            //    else if (newIndex == 6)
            //    {
            //        GetFollowUpList(Convert.ToInt32(strCode));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(Convert.ToString(ex.Message));
            //    this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.tabMain_SelectedIndexChanged() " + ex.ToString());
            //}
        }

        private void btnSendSMS_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblMemberCode.Text != "" && txtProfileId.Text != "")
                {
                    string strMobileNo = "";
                    string StrMsg = "Your Profile id:- " + txtProfileId.Text + Environment.NewLine;
                    StrMsg += " Your Password:- " + txtPassword.Text + Environment.NewLine;
                    StrMsg += " Please use the above Credentials For login at anantmatrimony.com";


                    if (rbtnFirst_Mobile.Checked)
                    {
                        strMobileNo = txtMobileNo.Text;
                    }
                    else if (rbtnSecound.Checked)
                    {
                        strMobileNo = txtMobileNo1.Text;
                    }
                    if (objGlobal.SendSMS(strMobileNo, StrMsg, false))
                    {
                        //objGlobal.CreateSMSLog(StrMsg, strMobileNo);
                        MessageBox.Show("Message Sent successfully", "Message Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMemberName.Focus();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Somthing went wrong", "Message Sent error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        txtMemberName.Focus();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please Save Profile first", "Save Profile", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMemberName.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.btnSendSMS_Click() " + ex.ToString());
            }
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblMemberCode.Text != "" && txtProfileId.Text != "")
                {
                    string strEmail = "";
                    //string StrMsg = "Your Profile id:- " + txtProfileId.Text + Environment.NewLine;
                    //StrMsg += " Your Password:- " + txtPassword.Text + Environment.NewLine;
                    //StrMsg += " Please use the above Credentials For login at anantmatrimony.com";


                    if (rbtnFirstEmail.Checked)
                    {
                        strEmail = txtEmailID.Text;
                    }
                    else if (rbtnSecoundEmail.Checked)
                    {
                        if (txtSecondaryEmailID.Text == "")
                        {
                            MessageBox.Show("Please enter Secound Email Address", "Secound Email Address validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtSecondaryEmailID.Focus();
                            return;
                        }
                        strEmail = txtSecondaryEmailID.Text;
                    }
                    string strHTML = "<html> ";
                    strHTML += " <head> ";
                    strHTML += " <title>Anant Matrimony</title> ";
                    strHTML += " <link href='https://fonts.googleapis.com/css?family=Lato:400,500,600,700' rel='stylesheet' /> ";
                    strHTML += " </head> ";
                    strHTML += " <body style='font-family: 'Lato', sans-serif;background-color: #ffffff;margin: 0px;padding: 0px;width: 100%;font-size: 15px;font-weight: 400;color: #323232;line-height: 18px;text-align:left;'> ";
                    strHTML += "  <table width='100%' border='0' align='center' cellpadding='0' cellspacing='0' class='contentbg'> ";
                    strHTML += " <tr> <td valign='top'>  ";
                    strHTML += "  <table width='50%' border='0' cellspacing='0' cellpadding='0' align='center'> ";
                    strHTML += " <tr> <td valign='top' bgcolor='#FFFFFF'>  ";
                    strHTML += "  <table width='100%' border='0' align='center' cellpadding='0' cellspacing='0'>  ";
                    strHTML += "  <tr> <td width='80%' height='105' align='left' valign='top'> ";
                    strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
                    strHTML += " <tr>  ";
                    strHTML += "  <td valign='top' bgcolor='#ca3b3b' style='padding:35px;'><a href='#'><img src='http://www.anantmatrimony.com/images/logo.png' width='349' height='107' alt='logo' style='margin-left: auto;margin-right: auto;' /></a></td> ";
                    strHTML += "  </tr> </table> </td> </tr> </table> </td> </tr> </table> </td> </tr> <tr> ";
                    strHTML += " <td valign='top'> ";
                    strHTML += " <table width='50%' border='0' cellspacing='0' cellpadding='0' align='center'> ";
                    strHTML += " <tr> <td valign='top'> ";
                    strHTML += " <table width='100%' border='0' align='center' cellpadding='0' cellspacing='0'> ";
                    strHTML += " <tr> <td valign='top' style='padding:20px 0px;'> ";
                    strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> <tr> ";
                    strHTML += " <td width='100%' valign='top'> ";
                    strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
                    strHTML += " <tr> ";
                    strHTML += " <td width='100%' valign='top' style='padding-bottom: 16px; text-align: left; font-size: 22px; font-weight: 600; color: #323232; line-height: 44px; border-bottom: 1px solid #e8e8e8; '> ";
                    strHTML += " <p>Hello " + txtMemberName.Text + ",</p> ";
                    strHTML += " <p>Your ProfileId : " + txtProfileId.Text + " <br />Password : " + txtPassword.Text + "  </p> ";
                    strHTML += " <p>Visit us on : <a href='http://www.anantmatrimony.com' target='_blank'>www.anantmatrimony.com</a></p>";
                    strHTML += " </td> </tr> <tr> ";
                    strHTML += " <td class='footerheading' width='100%' valign='top' style='padding-bottom:16px;text-align:center;font-size: 22px;font-weight: 600;color: #323232;line-height: 44px;'>For More Details, Call Us!</td> ";
                    strHTML += " </tr> <tr> ";
                    strHTML += " <td width='100%' valign='top' style='padding-bottom:16px;border-bottom:1px solid #e8e8e8;font-size: 35px;font-weight: 600;color: #f54d56;line-height: 24px;text-align:center;'>9428412065/9998489093</td> ";
                    strHTML += " </tr> <tr> ";
                    strHTML += " <td width='100%' valign='top' style='padding-bottom: 16px; border-bottom: 1px solid #e8e8e8; color: #323232; line-height: 24px; text-align: justify; '> ";
                    strHTML += " <p style=' padding: 0px; margin: 0px; margin-top: 15px;'>425, 4th Floor, Saman Complex,</p> ";
                    strHTML += " <p style=' padding: 0px; margin: 0px;'>Opp. Satyam Mall,</p> ";
                    strHTML += " <p style=' padding: 0px; margin: 0px;'>Near Jodhpur Cross Roads,</p> ";
                    strHTML += " <p style=' padding: 0px; margin: 0px;'>Satellite, Ahmedabad,</p> ";
                    strHTML += " <p style=' padding: 0px; margin: 0px;'>Gujarat 380015</p> ";
                    strHTML += " </td> </tr> </table> </td> </tr> </table> </td> </tr> </table> </td> </tr> <tr> <td valign='top'> ";
                    strHTML += " <table width='100%' border='0' align='center' cellpadding='0' cellspacing='0'> ";
                    strHTML += " <tr> <td valign='top' style='padding-bottom:33px;'> ";
                    strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
                    strHTML += " <tr> <td width='100%' valign='top'> ";
                    strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
                    strHTML += " <tr> <td valign='top' style='padding-top:21px; padding-bottom:17px;'> ";
                    strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'></table> ";
                    strHTML += " </td> </tr> <tr> ";
                    strHTML += " <td valign='top' style='font-size:13px;color:#989797;text-align:center; padding-right:84px;'> ";
                    strHTML += " © 2003 - 2019 AnantMatrimony.com & Kankukanya.com. All Rights Reserved.<br /> ";
                    strHTML += "  </td> </tr> </table> </td>  </tr> </table> </td> </tr> </table> </td> </tr> ";
                    strHTML += " </table> </td> </tr> </table> </body> </html>";
                    if (objGlobal.SendMail(strEmail, "AnantMatrimony : User details", strHTML, true, "users@anantmatrimony.com", "Changeme@123"))
                    {
                        MessageBox.Show("Message Sent successfully", "Message Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMemberName.Focus();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Somthing went wrong", "Message Sent error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        txtMemberName.Focus();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please Save Profile first", "Save Profile", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMemberName.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.btnSendEmail_Click() " + ex.ToString());
            }
        }

        private void lnkPhoto1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string path = Convert.ToString(lnkPhoto1.Tag);
            System.Diagnostics.Process.Start(path);
        }

        private void lnkPhoto2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string path = Convert.ToString(lnkPhoto2.Tag);
            System.Diagnostics.Process.Start(path);
        }

        private void lnkPhoto3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string path = Convert.ToString(lnkPhoto3.Tag);
            System.Diagnostics.Process.Start(path);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtProfileId_F_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
