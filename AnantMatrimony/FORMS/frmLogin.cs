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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        dbInteraction objdb = new dbInteraction();
        EventLogging objEventLoging = new EventLogging();
        Global objGlobal = new Global();

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text == "")
                {
                    MessageBox.Show("Please enter user name", "User Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserName.Focus();
                    return;
                }
                if (txtPassword.Text == "")
                {
                    MessageBox.Show("Please enter password", "Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Focus();
                    return;
                }
                string strUserName = Convert.ToString(objGlobal.CheckLogin(txtUserName.Text, txtPassword.Text));
                if (strUserName != "")
                {
                    Global.isLogin = true;
                    Global.strUserName = strUserName;
                }
                else
                {
                    Global.isLogin = false;
                    MessageBox.Show("Invalid User Name/Password", "Login Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In frmLogin.btnLogin_Click()" + ex.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (this.GetNextControl(this.ActiveControl, true) != null)
                        {
                            e.Handled = true;
                            this.GetNextControl(this.ActiveControl, true).Focus();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                objEventLoging.AppErrlog("Error In frmLogin.frmLogin_KeyDown() " + ex.ToString());
            }
        }
    }
}
