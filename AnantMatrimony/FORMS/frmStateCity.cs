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
    public partial class frmStateCity : Form, ICommonFunctions
    {
        EventLogging objEventLoging = new EventLogging();
        Global objGlobal = new Global();
        ToolbarPositions TpLast;

        string strMaxId = "";
        string strMasterTable = "tbl_StateCity";
        string strSQL = "";
        int Intcout = 0;

        int Record_Exist = 0;
        bool isValid = false;
        bool IsEdit = false;
        string strCode = "";

        public frmStateCity()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ShowIcon = false;
        }

        private void frmStateCity_Load(object sender, EventArgs e)
        {
            try
            {
                this.TpLast = ToolbarPositions.eTPOk;
                ((frmMain)base.MdiParent).setControlState(false, true, this);
                GetCountry();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmStateCity.frmStateCity_Load() " + ex.ToString());
            }
        }

        private void frmStateCity_Activated(object sender, EventArgs e)
        {
            try
            {
                ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                this.AutoValidate = AutoValidate.EnableAllowFocusChange;
                objGlobal.FocusColor(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmStateCity.frmStateCity_Activated() " + ex.ToString());
            }
        }

        private void frmStateCity_Deactivate(object sender, EventArgs e)
        {
            try
            {
                this.AutoValidate = AutoValidate.Disable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmStateCity.frmStateCity_Deactivate() " + ex.ToString());
            }
        }

        private void frmStateCity_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
                ((frmMain)base.MdiParent).mnuStateCity.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmStateCity.frmStateCity_FormClosed() " + ex.ToString());
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
                this.cmbCounteryStateCity.Focus();
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmStateCity.funAdd() " + exception.ToString());
            }
        }

        public void funClear()
        {
            try
            {
                ((frmMain)base.MdiParent).setControlState(false, true, this);
                this.TpLast = ToolbarPositions.eTPOk;
                ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                this.cmbCounteryStateCity.Focus();
                this.IsEdit = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmStateCity.funClear() " + exception.ToString());
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
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmStateCity.funDelete() " + exception.ToString());
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
                cmbCounteryStateCity.Focus();
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmStateCity.funEdit() " + exception.ToString());
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
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmStateCity.funExit() " + exception.ToString());
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
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmStateCity.funReport() " + exception.ToString());
            }
        }

        public void funSave()
        {
            try
            {
                int Intcout = 0;
                if (checkValidation())
                {
                    tbl_StateCityProp objtbl_Pro = new tbl_StateCityProp();
                    tbl_StateCityBAL objBAL = new tbl_StateCityBAL();
                    if (IsEdit)
                    {
                        objtbl_Pro.StateCityCode = Convert.ToInt32(txtStateCityCode.Text);
                        objtbl_Pro.CountryCode = Convert.ToInt32(cmbCounteryStateCity.SelectedValue);
                        objtbl_Pro.StateCity = txtStateCity.Text;
                    }
                    else
                    {
                        objtbl_Pro.StateCityCode = 0;
                        objtbl_Pro.CountryCode = Convert.ToInt32(cmbCounteryStateCity.SelectedValue);
                        objtbl_Pro.StateCity = txtStateCity.Text;
                    }
                    Intcout = objBAL.InsertUpdate_Data(objtbl_Pro);
                    if (Intcout > 0)
                    {
                        this.objGlobal.showMessage("State/City", "success", this.IsEdit, this.txtStateCity);
                        ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPOk);
                        ((frmMain)base.MdiParent).setControlState(false, true, this);
                        this.TpLast = ToolbarPositions.eTPOk;
                        ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                        this.IsEdit = false;
                    }
                    else
                    {
                        objGlobal.showMessage("State/City", "", IsEdit, txtStateCity);
                        txtStateCity.Focus();
                    }
                }
                else
                {
                    objGlobal.showMessage("State/City", "", IsEdit, txtStateCity);
                    txtStateCity.Focus();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmStateCity.funSave() " + exception.ToString());
            }
        }

        private bool checkValidation()
        {
            this.isValid = true;
            try
            {
                if (this.cmbCounteryStateCity.Text == "")
                {
                    MessageBox.Show("Please select Country", "Country validation", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.isValid = false;
                    this.cmbCounteryStateCity.Focus();
                }
                if (this.txtStateCity.Text == "")
                {
                    MessageBox.Show("Please insert State/City", "State/City validation", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.isValid = false;
                    this.cmbCounteryStateCity.Focus();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmStateCity.funSave() " + exception.ToString());
            }
            return isValid;
        }

        public void funSearch()
        {
            try
            {
                tbl_StateCityBAL objbal = new tbl_StateCityBAL();
                tbl_StateCityProp objtblProp = new tbl_StateCityProp();
                int PageCount = 0;
                DataSet ds = objbal.Select_Data(objtblProp, ref PageCount, 00);
                DataView dvSearch = ds.Tables[0].DefaultView;
                Global.strSearchSqlWidth = " 0:200:200 ";
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
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmStateCity.funSearch() " + exception.ToString());
            }
        }

        public void DisplayRecord(string Code, DataView dvSearch)
        {
            try
            {
                funClear();
                dvSearch.RowFilter = "";
                dvSearch.RowFilter = "StateCityCode='" + Code + "'";
                if (dvSearch.Count > 0)
                {
                    DataRow row = dvSearch[0].Row;
                    txtStateCity.Text = Convert.ToString(row["StateCity"]);
                    txtStateCityCode.Text = Convert.ToString(row["StateCityCode"]);
                    cmbCounteryStateCity.Text = Convert.ToString(row["Country"]);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmStateCity.DisplayRecord() " + exception.ToString());
            }
        }

        private void GetCountry()
        {
            try
            {
                tbl_CountryProp objProp_C = new tbl_CountryProp();
                tbl_CountryBAL objBal_C = new tbl_CountryBAL();
                DataSet ds = objBal_C.SelectCombo_Data(objProp_C);
                cmbCounteryStateCity.DataSource = ds.Tables[0];
                cmbCounteryStateCity.ValueMember = "CountryCode";
                cmbCounteryStateCity.DisplayMember = "Country";
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmStateCity.GetCountry() " + ex.ToString());
            }
        }

    }
}
