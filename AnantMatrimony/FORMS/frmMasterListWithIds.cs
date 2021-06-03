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
    public partial class frmMasterListWithIds : Form
    {
        public frmMasterListWithIds()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ShowIcon = true;
        }

        DataView dvCaste, dvEducation, dvCountry, dvCity, dvMaritalStatus;
        dbInteraction objDb = new dbInteraction();
        Global objGlobal = new Global();
        string strCaste = "", strEducation = "", strCountry = "", strCity = "", strMaritalStatus = "", strIncome = "", strHeight = "";
        int[] FieldLength;

        private void frmMasterListWithIds_Load(object sender, EventArgs e)
        {
            FillList();
        }

        public void FillList()
        {
            try
            {
                //strCaste = " SELECT 'All' AS Caste,0 as ORD,0 AS CasteCode";
                //strCaste += " UNION ALL ";
                strCaste = " SELECT CasteCode,Caste FROM tbl_Caste ORDER BY Caste";
                DataTable dtCaste = objDb.GetDataTable(strCaste);
                FieldLength = new int[] { 50,150};
                objGlobal.FillListView(LvwCaste_A, dtCaste, FieldLength);

                strEducation += " SELECT EducationCode,Education FROM tbl_Education ORDER BY Education";
                DataTable dtEducation = objDb.GetDataTable(strEducation);
                FieldLength = new int[] { 50, 150 };
                objGlobal.FillListView(LvwEducation_A, dtEducation, FieldLength);

                strMaritalStatus += " SELECT MaritalStatusCode,MaritalStatus from tbl_MaritalStatus ";
                DataTable dtMaritalStatus = objDb.GetDataTable(strMaritalStatus);
                FieldLength = new int[] { 50, 150 };
                objGlobal.FillListView(LvwMaritalStatus_A, dtMaritalStatus, FieldLength);

                strCountry += " SELECT CountryCode,Country FROM tbl_Country ORDER BY Country";
                DataTable dtCountry = objDb.GetDataTable(strCountry);
                FieldLength = new int[] { 50, 150 };
                objGlobal.FillListView(LvwCountry_A, dtCountry, FieldLength);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmMasterListWithIds_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
            ((frmMain)base.MdiParent).mnuMasterList.Enabled = true;
            ((frmMain)base.MdiParent).pnlMain.Visible = true;
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
                            strCountry_Sel = LvwCountry_A.Items[cnt].SubItems[0].Text;
                        }
                        else
                        {
                            strCountry_Sel += "," + LvwCountry_A.Items[cnt].SubItems[0].Text;
                        }
                    }
                }
                if (strCountry_Sel != "")
                {
                    if (strCountry_Sel != "0")
                    {
                        strCity = " SELECT StateCityCode,StateCity FROM tbl_StateCity WHERE CountryCode in (" + strCountry_Sel + ") ORDER BY StateCity";
                    }
                    FieldLength = new int[] { 50,100};
                    objGlobal.FillListView(LvwState_A, strCity, FieldLength);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
