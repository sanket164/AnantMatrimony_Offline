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
    public partial class frmSubCaste : Form, ICommonFunctions
    {
        EventLogging objEventLoging = new EventLogging();
        Global objGlobal = new Global();
        ToolbarPositions TpLast;

        string strMaxId = "";
        string strMasterTable = "tbl_SubCaste";
        string strSQL = "";
        int Intcout = 0;

        int Record_Exist = 0;
        bool isValid = false;
        bool IsEdit = false;
        string strCode = "";

        public frmSubCaste()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ShowIcon = false;
        }

        private void frmSubCaste_Load(object sender, EventArgs e)
        {
            try
            {
                this.TpLast = ToolbarPositions.eTPOk;
                ((frmMain)base.MdiParent).setControlState(false, true, this);
                GetCaste();
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmSubCaste.funDelete() " + exception.ToString());
            }
        }

        private void frmSubCaste_Activated(object sender, EventArgs e)
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
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmSubCaste.funDelete() " + exception.ToString());
            }
        }

        private void frmSubCaste_Deactivate(object sender, EventArgs e)
        {
            try
            {
                this.AutoValidate = AutoValidate.Disable;
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmSubCaste.funDelete() " + exception.ToString());
            }
        }

        private void frmSubCaste_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
                ((frmMain)base.MdiParent).mnuSubCaste.Enabled = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmSubCaste.funDelete() " + exception.ToString());
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
                this.cmbCaste.Focus();
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmSubCaste.funAdd() " + exception.ToString());
            }
        }

        public void funClear()
        {
            try
            {
                ((frmMain)base.MdiParent).setControlState(false, true, this);
                this.TpLast = ToolbarPositions.eTPOk;
                ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                this.cmbCaste.Focus();
                this.IsEdit = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmSubCaste.funClear() " + exception.ToString());
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
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmSubCaste.funDelete() " + exception.ToString());
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
                cmbCaste.Focus();
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmSubCaste.funEdit() " + exception.ToString());
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
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmSubCaste.funExit() " + exception.ToString());
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
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmSubCaste.funReport() " + exception.ToString());
            }
        }

        public void funSave()
        {
            try
            {
                int Intcout = 0;
                if (checkValidation())
                {
                    tbl_SubCasteProp objtbl_SubCaste = new tbl_SubCasteProp();
                    tbl_SubCasteBAL objcasteBAL = new tbl_SubCasteBAL();
                    if (IsEdit)
                    {
                        objtbl_SubCaste.SubCasteCode = Convert.ToInt32(txtSubCasteCode.Text);
                        objtbl_SubCaste.CasteCode = Convert.ToInt32(cmbCaste.SelectedValue);
                        objtbl_SubCaste.SubCaste = txtSubCaste.Text;
                    }
                    else
                    {
                        objtbl_SubCaste.SubCasteCode = 0;
                        objtbl_SubCaste.CasteCode = Convert.ToInt32(cmbCaste.SelectedValue);
                        objtbl_SubCaste.SubCaste = txtSubCaste.Text;
                    }
                    Intcout = objcasteBAL.InsertUpdate_Data(objtbl_SubCaste);
                    if (Intcout > 0)
                    {
                        this.objGlobal.showMessage("SUB CASTE", "success", this.IsEdit, this.txtSubCaste);
                        ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPOk);
                        ((frmMain)base.MdiParent).setControlState(false, true, this);
                        this.TpLast = ToolbarPositions.eTPOk;
                        ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                        this.IsEdit = false;
                    }
                    else
                    {
                        objGlobal.showMessage("SUB CASTE", "", IsEdit, txtSubCaste);
                        txtSubCaste.Focus();
                    }
                }
                else
                {
                    objGlobal.showMessage("SUB CASTE", "", IsEdit, txtSubCaste);
                    txtSubCaste.Focus();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmSubCaste.funSave() " + exception.ToString());
            }
        }

        public void funSearch()
        {
            try
            {
                tbl_SubCasteBAL objbal = new tbl_SubCasteBAL();
                tbl_SubCasteProp objtbl_Caste = new tbl_SubCasteProp();
                int PageCount = 0;
                DataSet ds = objbal.Select_Data(objtbl_Caste, ref PageCount, 0);
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
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmSubCaste.funSearch() " + exception.ToString());
            }
        }

        public void DisplayRecord(string Code, DataView dvSearch)
        {
            try
            {
                funClear();
                dvSearch.RowFilter = "";
                dvSearch.RowFilter = "SubCasteCode='" + Code + "'";
                if (dvSearch.Count > 0)
                {
                    DataRow row = dvSearch[0].Row;
                    cmbCaste.Text = Convert.ToString(row["Caste"]);
                    txtSubCaste.Text = Convert.ToString(row["SubCaste"]);
                    txtSubCasteCode.Text = Convert.ToString(row["SubCasteCode"]);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmSubCaste.DisplayRecord() " + exception.ToString());
            }
        }

        private bool checkValidation()
        {
            this.isValid = true;
            try
            {
                if (this.cmbCaste.Text == "")
                {
                    MessageBox.Show("Please select Caste", "Caste validation", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.isValid = false;
                    this.cmbCaste.Focus();
                }
                if (txtSubCaste.Text == "")
                {
                    MessageBox.Show("Please Insert SubCaste", "SubCaste validation", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.isValid = false;
                    this.txtSubCaste.Focus();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmSubCaste.funSave() " + exception.ToString());
            }
            return isValid;
        }

        private void GetCaste()
        {
            try
            {
                tbl_CasteProp objCaste = new tbl_CasteProp();
                tbl_CasteBAL objBal = new tbl_CasteBAL();
                DataSet ds = objBal.SelectCombo_Data(objCaste);
                cmbCaste.DataSource = ds.Tables[0];
                cmbCaste.DisplayMember = "Caste";
                cmbCaste.ValueMember = "CasteCode";
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.GetCaste.funSave() " + ex.ToString());
            }
        }


    }
}
