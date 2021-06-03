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
    public partial class frmCommonMaster : Form, ICommonFunctions
    {
        EventLogging objEventLoging = new EventLogging();
        Global objGlobal = new Global();
        ToolbarPositions TpLast;
        dbInteraction objDb = new dbInteraction();

        string strMaxId = "";
        string strMasterTable = "";
        string strSQL = "";
        int Intcout = 0;

        int Record_Exist = 0;
        bool isValid = false;
        bool IsEdit = false;
        string strCode = "";

        public frmCommonMaster()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ShowIcon = false;
            SetInitialize();
        }

        private void frmCommonMaster_Load(object sender, EventArgs e)
        {
            try
            {
                this.TpLast = ToolbarPositions.eTPOk;
                ((frmMain)base.MdiParent).setControlState(false, true, this);
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonMaster.funDelete() " + exception.ToString());
            }
        }

        private void frmCommonMaster_Activated(object sender, EventArgs e)
        {
            try
            {
                ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                this.AutoValidate = AutoValidate.EnableAllowFocusChange;
                objGlobal.FocusColor(this);
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonMaster.funDelete() " + exception.ToString());
            }
        }

        private void frmCommonMaster_Deactivate(object sender, EventArgs e)
        {
            try
            {
                this.AutoValidate = AutoValidate.Disable;
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonMaster.funDelete() " + exception.ToString());
            }
        }

        private void frmCommonMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
                if (lblFrmName.Text == Global.fAnnualIncome)
                {
                    ((frmMain)base.MdiParent).mnuAnnualIncome.Enabled = true;
                }
                else if (lblFrmName.Text == Global.fAnnualIncomeCurrency)
                {
                    ((frmMain)base.MdiParent).mnuAnnualIncomeCurrency.Enabled = true;
                }
                else if (lblFrmName.Text == Global.fBloodGroup)
                {
                    ((frmMain)base.MdiParent).mnuBloodGroup.Enabled = true;
                }
                else if (lblFrmName.Text == Global.fCaste)
                {
                    ((frmMain)base.MdiParent).mnuCaste.Enabled = true;
                }
                else if (lblFrmName.Text == Global.fCountry)
                {
                    ((frmMain)base.MdiParent).mnuCountry.Enabled = true;
                }
                else if (lblFrmName.Text == Global.fEducation)
                {
                    ((frmMain)base.MdiParent).mnuEducation.Enabled = true;
                }
                else if (lblFrmName.Text == Global.fMembershipType)
                {
                    ((frmMain)base.MdiParent).mnuMembershipType.Enabled = true;
                }
                else if (lblFrmName.Text == Global.fOccupation)
                {
                    ((frmMain)base.MdiParent).mnuOccupation.Enabled = true;
                }
                else if (lblFrmName.Text == Global.fProfileCreatedBy)
                {
                    ((frmMain)base.MdiParent).mnuProfileCreatedBy.Enabled = true;
                }
                else if (lblFrmName.Text == Global.fVisaStatus)
                {
                    ((frmMain)base.MdiParent).mnuVisaCountry.Enabled = true;
                }
                else if (lblFrmName.Text == Global.fWorkingAs)
                {
                    ((frmMain)base.MdiParent).mnuWorkingAs.Enabled = true;
                }
                else if (lblFrmName.Text == Global.fWorkingWith)
                {
                    ((frmMain)base.MdiParent).mnuWorkingWith.Enabled = true;
                }
                else if (lblFrmName.Text == Global.fWorkType)
                {
                    ((frmMain)base.MdiParent).mnuWorkType.Enabled = true;
                }
                else if (lblFrmName.Text == Global.fEmployeeMaster)
                {
                    ((frmMain)base.MdiParent).mnuEmployeeMaster.Enabled = true;
                }
                ((frmMain)base.MdiParent).pnlMain.Visible = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonMaster.funReport() " + exception.ToString());
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
                this.txtName.Focus();
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonMaster.funAdd() " + exception.ToString());
            }
        }

        public void funClear()
        {
            try
            {
                ((frmMain)base.MdiParent).setControlState(false, true, this);
                this.TpLast = ToolbarPositions.eTPOk;
                ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                this.txtName.Focus();
                this.IsEdit = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonMaster.funClear() " + exception.ToString());
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
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonMaster.funDelete() " + exception.ToString());
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
                txtName.Focus();
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonMaster.funEdit() " + exception.ToString());
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
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonMaster.funExit() " + exception.ToString());
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
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonMaster.funReport() " + exception.ToString());
            }
        }

        public void funSave()
        {
            try
            {
                this.objGlobal.strvalues = "";
                this.objGlobal.strfields = "";
                this.objGlobal.strUpdate = "";
                if (checkValidation())
                {
                    if (this.IsEdit)
                    {
                        this.objGlobal.UpdateFields(this);
                    }
                    else
                    {
                        this.objGlobal.SaveFields(this);
                    }
                    //this.objtransaction2 = Global.objConnection.BeginTransaction();
                    string Code_Name = txtCode.Tag.ToString().Replace("%", "");
                    this.Intcout = this.objGlobal.SaveMasterRecords(this.strMasterTable, Code_Name.ToString(), this.txtCode.Text, "", this.IsEdit);
                    if (this.Intcout > 0)
                    {
                        //Global.strMasterString = this.txtName.Text;
                        //this.objtransaction2.Commit();
                        this.objGlobal.showMessage(lblFrmName.Text, "success", this.IsEdit, this.txtName);
                        ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPOk);
                        ((frmMain)base.MdiParent).setControlState(false, true, this);
                        this.TpLast = ToolbarPositions.eTPOk;
                        ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                        this.IsEdit = false;
                    }
                    else
                    {
                        //this.objtransaction2.Rollback();
                        this.objGlobal.showMessage(lblFrmName.Text, "", this.IsEdit, this.txtName);
                    }
                }
                else
                {
                    objGlobal.showMessage(lblFrmName.Text, "", IsEdit, txtName);
                    txtName.Focus();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonMaster.funSave() " + exception.ToString());
            }
        }

        public void funSearch()
        {
            try
            {
                DataSet ds = GetSaveList();
                DataView dvSearch = ds.Tables[0].DefaultView;
                Global.strSearchSqlWidth = " 0:200 ";
                strCode = objGlobal.openSearch(dvSearch);
                if (strCode != "")
                {
                    DisplayRecord(strCode, dvSearch);
                    ((frmMain)this.MdiParent).setControlState(false, false, this);
                    TpLast = ToolbarPositions.eTPDataDisplayed;
                    ((frmMain)this.MdiParent).setToolbarPositions(TpLast);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonMaster.funSearch() " + exception.ToString());
            }
        }

        private void DisplayRecord(string Code, DataView dvSearch)
        {
            try
            {
                funClear();
                dvSearch.RowFilter = "";
                dvSearch.RowFilter = dvSearch.DataViewManager.DataSet.Tables[0].Columns[0].Caption + "='" + Code + "'";
                if (dvSearch.Count > 0)
                {
                    DataRow row = dvSearch[0].Row;
                    txtCode.Text = Convert.ToString(row[0]);
                    txtName.Text = Convert.ToString(row[1]);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmAnnualIncome.DisplayRecord() " + exception.ToString());
            }
        }

        private bool checkValidation()
        {
            this.isValid = true;
            try
            {
                if (this.txtName.Text == "")
                {
                    MessageBox.Show("Please Insert AnnualIncomeCurrency", "AnnualIncomeCurrency validation", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.isValid = false;
                    this.txtName.Focus();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonMaster.funSave() " + exception.ToString());
            }
            return isValid;
        }

        private void SetInitialize()
        {
            try
            {
                if (Global.strMasterName == Global.fAnnualIncome)
                {
                    this.Text = "Annual Income";
                    lblFrmName.Text = Global.fAnnualIncome;
                    lblName.Text = "Annual Income";
                    strMasterTable = "tbl_AnnualIncome";
                    txtCode.Tag = "%AnnualIncomeCode";
                    txtName.Tag = "AnnualIncome";
                }
                else if (Global.strMasterName == Global.fAnnualIncomeCurrency)
                {
                    this.Text = "Annual Income Currency";
                    lblFrmName.Text = Global.fAnnualIncomeCurrency;
                    lblName.Text = "Annual Income Currency";
                    strMasterTable = "tbl_AnnualIncomeCurrency";
                    txtCode.Tag = "%AnnualIncomeCurrencyCode";
                    txtName.Tag = "AnnualIncomeCurrency";
                }
                else if (Global.strMasterName == Global.fBloodGroup)
                {
                    this.Text = "Blood Group";
                    lblFrmName.Text = Global.fBloodGroup;
                    lblName.Text = "Blood Group";
                    strMasterTable = "tbl_BloodGroup";
                    txtCode.Tag = "%BloodGroupCode";
                    txtName.Tag = "BloodGroup";
                }
                else if (Global.strMasterName == Global.fCaste)
                {
                    this.Text = "Caste";
                    lblFrmName.Text = Global.fCaste;
                    lblName.Text = "Caste";
                    strMasterTable = "tbl_Caste";
                    txtCode.Tag = "%CasteCode";
                    txtName.Tag = "Caste";
                }
                else if (Global.strMasterName == Global.fCountry)
                {
                    this.Text = "Country";
                    lblFrmName.Text = Global.fCountry;
                    lblName.Text = "Country";
                    strMasterTable = "tbl_Country";
                    txtCode.Tag = "%CountryCode";
                    txtName.Tag = "Country";
                }
                else if (Global.strMasterName == Global.fEducation)
                {
                    this.Text = "Education";
                    lblFrmName.Text = Global.fEducation;
                    lblName.Text = "Education";
                    strMasterTable = "tbl_Education";
                    txtCode.Tag = "%EducationCode";
                    txtName.Tag = "Education";
                }
                else if (Global.strMasterName == Global.fMembershipType)
                {
                    this.Text = "Membership Type";
                    lblFrmName.Text = Global.fMembershipType;
                    lblName.Text = "Membership Type";
                    strMasterTable = "tbl_MembershipType";
                    txtCode.Tag = "%MembershipTypeCode";
                    txtName.Tag = "MembershipType";
                }
                else if (Global.strMasterName == Global.fOccupation)
                {
                    this.Text = "Occupation";
                    lblFrmName.Text = Global.fOccupation;
                    lblName.Text = "Occupation";
                    strMasterTable = "tbl_Occupation";
                    txtCode.Tag = "%OccupationCode";
                    txtName.Tag = "Occupation";
                }
                else if (Global.strMasterName == Global.fProfileCreatedBy)
                {
                    this.Text = "Profile Created By";
                    lblFrmName.Text = Global.fProfileCreatedBy;
                    lblName.Text = "Profile Created By";
                    strMasterTable = "tbl_ProfileCreatedBy";
                    txtCode.Tag = "%ProfileCreatedByCode";
                    txtName.Tag = "ProfileCreatedBy";
                }
                //else if (objGlobal.strMasterName == Global.fQueryMessage)
                //{
                //    this.Name = "Annual Income";
                //    lblFrmName.Text = Global.fQueryMessage;
                //    lblName.Text = "Annual Income";
                //    strMasterTable = "tbl_AnnualIncome";
                //    txtCode.Tag = "AnnualIncomeCode";
                //    txtName.Text = "AnnualIncome";
                //}
                else if (Global.strMasterName == Global.fVisaStatus)
                {
                    this.Text = "Visa Status";
                    lblFrmName.Text = Global.fVisaStatus;
                    lblName.Text = "Visa Status";
                    strMasterTable = "tbl_VisaStatus";
                    //txtCode.Tag = "*VisaStatusCode";
                    txtName.Tag = "VisaStatus";
                }
                else if (Global.strMasterName == Global.fWorkingAs)
                {
                    this.Text = "Working As";
                    lblFrmName.Text = Global.fWorkingAs;
                    lblName.Text = "Working As";
                    strMasterTable = "tbl_WorkingAs";
                    txtCode.Tag = "%WorkingAsCode";
                    txtName.Tag = "WorkingAs";
                }
                else if (Global.strMasterName == Global.fWorkingWith)
                {
                    this.Text = "Working With";
                    lblFrmName.Text = Global.fWorkingWith;
                    lblName.Text = "Working With";
                    strMasterTable = "tbl_WorkingWith";
                    txtCode.Tag = "%WorkingWithCode";
                    txtName.Tag = "WorkingWith";
                }
                else if (Global.strMasterName == Global.fEmployeeMaster)
                {
                    this.Text = "Employee Master";
                    lblFrmName.Text = Global.fEmployeeMaster;
                    lblName.Text = "Employee Name";
                    strMasterTable = "tbl_EmployeeMaster";
                    txtCode.Tag = "%EmployeeCode";
                    txtName.Tag = "EmployeeName";
                }
                else if (Global.strMasterName == Global.fWorkType)
                {
                    this.Text = "Work Type Master";
                    lblFrmName.Text = Global.fWorkType;
                    lblName.Text = "Work Type";
                    strMasterTable = "tbl_WorkType";
                    txtCode.Tag = "%WorkTypeCode";
                    txtName.Tag = "WorkType";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonMaster.SetInitialize() " + ex.ToString());
            }
        }

        public DataSet GetSaveList()
        {
            DataSet ds = new DataSet();
            try
            {
                if (lblFrmName.Text == Global.fAnnualIncome)
                {
                    tbl_AnnualIncomeBAL objbal = new tbl_AnnualIncomeBAL();
                    tbl_AnnualIncomeProp objtbl_tbl_AnnualIncome = new tbl_AnnualIncomeProp();
                    int PageCount = 0;
                    ds = objbal.Select_Data(objtbl_tbl_AnnualIncome, ref PageCount, 0);
                }
                else if (lblFrmName.Text == Global.fAnnualIncomeCurrency)
                {
                    tbl_AnnualIncomeCurrencyBAL objbal = new tbl_AnnualIncomeCurrencyBAL();
                    tbl_AnnualIncomeCurrencyProp objtbl_tbl_AnnualIncome = new tbl_AnnualIncomeCurrencyProp();
                    int PageCount = 0;
                    ds = objbal.Select_Data(objtbl_tbl_AnnualIncome, ref PageCount, 0);
                }
                else if (lblFrmName.Text == Global.fBloodGroup)
                {
                    tbl_BloodGroupBAL objbal = new tbl_BloodGroupBAL();
                    tbl_BloodGroupProp objtbl_prop = new tbl_BloodGroupProp();
                    int PageCount = 0;
                    ds = objbal.Select_Data(objtbl_prop, ref PageCount, 0);
                }
                else if (lblFrmName.Text == Global.fCaste)
                {
                    tbl_CasteBAL objbal = new tbl_CasteBAL();
                    tbl_CasteProp objtbl_prop = new tbl_CasteProp();
                    int PageCount = 0;
                    ds = objbal.Select_Data(objtbl_prop, 0, ref PageCount);
                }
                else if (lblFrmName.Text == Global.fCountry)
                {
                    tbl_CountryBAL objbal = new tbl_CountryBAL();
                    tbl_CountryProp objtbl_prop = new tbl_CountryProp();
                    int PageCount = 0;
                    ds = objbal.Select_Data(objtbl_prop, ref PageCount, 0);
                }
                else if (lblFrmName.Text == Global.fEducation)
                {
                    tbl_EducationBAL objbal = new tbl_EducationBAL();
                    tbl_EducationProp objtbl_prop = new tbl_EducationProp();
                    int PageCount = 0;
                    ds = objbal.Select_Data(objtbl_prop, ref PageCount, 0);
                }
                else if (lblFrmName.Text == Global.fMembershipType)
                {
                    tbl_MembershipTypeBAL objbal = new tbl_MembershipTypeBAL();
                    tbl_MembershipTypeProp objtbl_prop = new tbl_MembershipTypeProp();
                    int PageCount = 0;
                    ds = objbal.Select_Data(objtbl_prop, ref PageCount, 0);
                }
                else if (lblFrmName.Text == Global.fOccupation)
                {
                    tbl_OccupationBAL objbal = new tbl_OccupationBAL();
                    tbl_OccupationProp objtbl_prop = new tbl_OccupationProp();
                    int PageCount = 0;
                    ds = objbal.Select_Data(objtbl_prop, ref PageCount, 0);
                }
                else if (lblFrmName.Text == Global.fProfileCreatedBy)
                {
                    tbl_ProfileCreatedByBAL objbal = new tbl_ProfileCreatedByBAL();
                    tbl_ProfileCreatedByProp objtbl_prop = new tbl_ProfileCreatedByProp();
                    int PageCount = 0;
                    ds = objbal.Select_Data(objtbl_prop, ref PageCount, 0);
                }
                else if (lblFrmName.Text == Global.fVisaStatus)
                {
                    tbl_VisaStatusBAL objbal = new tbl_VisaStatusBAL();
                    tbl_VisaStatusProp objtbl_prop = new tbl_VisaStatusProp();
                    int PageCount = 0;
                    ds = objbal.Select_Data(objtbl_prop, ref PageCount, 0);
                }
                else if (lblFrmName.Text == Global.fWorkingAs)
                {
                    tbl_WorkingAsBAL objbal = new tbl_WorkingAsBAL();
                    tbl_WorkingAsProp objtbl_prop = new tbl_WorkingAsProp();
                    int PageCount = 0;
                    ds = objbal.Select_Data(objtbl_prop, ref PageCount, 0);
                }
                else if (lblFrmName.Text == Global.fWorkingWith)
                {
                    tbl_WorkingWithBAL objbal = new tbl_WorkingWithBAL();
                    tbl_WorkingWithProp objtbl_prop = new tbl_WorkingWithProp();
                    int PageCount = 0;
                    ds = objbal.Select_Data(objtbl_prop, ref PageCount, 0);
                }
                else if (lblFrmName.Text == Global.fMaritalStatus)
                {
                    //tbl_WorkingWithBAL objbal = new tbl_WorkingWithBAL();
                    //tbl_WorkingWithProp objtbl_prop = new tbl_WorkingWithProp();
                    //int PageCount = 0;
                    //ds = objbal.Select_Data(objtbl_prop, ref PageCount, 0);
                }
                else if (lblFrmName.Text == Global.fWorkType)
                {
                    //tbl_WorkingWithBAL objbal = new tbl_WorkingWithBAL();
                    //tbl_WorkingWithProp objtbl_prop = new tbl_WorkingWithProp();
                    //int PageCount = 0;
                    //ds = objbal.Select_Data(objtbl_prop, ref PageCount, 0);
                    strSQL = "Select * from tbl_WorkType";
                    ds = objDb.ExecuteDataset(strSQL);
                }
                else if (lblFrmName.Text == Global.fEmployeeMaster)
                {
                    strSQL = "Select * from tbl_EmployeeMaster";
                    ds = objDb.ExecuteDataset(strSQL);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonMaster.GetSaveList() " + ex.ToString());
            }
            return ds;
        }



    }
}
