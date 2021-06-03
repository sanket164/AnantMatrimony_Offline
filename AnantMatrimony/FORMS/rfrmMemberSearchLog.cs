using AnantMatrimony.FORMS;
using AnantMatrimony.MatrimonyDAL;
using AnantMatrimony.UD_CLASS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnantMatrimony
{
    public partial class rfrmMemberSearchLog : Form
    {
        public rfrmMemberSearchLog()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ShowIcon = false;
        }
        EventLogging objEventLoging = new EventLogging();
        Global objGlobal = new Global();
        dbInteraction objDb = new dbInteraction();
        string strSql = "";
        int[] FieldLength;

        private void rfrmMemberSearchLog_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                tbl_MemberMasterBAL objMemberMaster = new tbl_MemberMasterBAL();
                DataTable dtDetails = objMemberMaster.GetMemberListSearchLog(dtpFromDate.Value, dtpToDate.Value);
                if (dtDetails.Rows.Count > 0)
                {                    
                    FieldLength = new int[] { 0, 150, 150, 200, 0};
                    objGlobal.FillListView(LvwDetails, dtDetails, FieldLength);
                    LvwDetails.CheckBoxes = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rfrmMemberSearchLog_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
            ((frmMain)base.MdiParent).mnuMemberSearchLog.Enabled = true;
        }
    }
}
