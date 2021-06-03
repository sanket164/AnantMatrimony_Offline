using AnantMatrimony.FORMS;
using AnantMatrimony.FROMS;
using AnantMatrimony.MatrimonyDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnantMatrimony.UD_CLASS
{
    public enum ToolbarPositions
    {
        eTPNoAction = 0,
        eTPAdd,
        eTPEdit,
        eTPDataDisplayed,
        eTPOk,
        eTPDelete,
        eTPSearch
    }
    class Global
    {
        dbInteraction objDb = new dbInteraction();
        EventLogging objEventLoging = new EventLogging();

        public static bool isLoginCancel = false;
        public static bool isLogin = false;
        public static int intUserId = 0;
        public static string strUserName = "";
        public static bool ControlChange = false;

        public static string strSearchSql;
        public static string strSearchSqlWidth;
        public static bool bolCombo = true;
        public static bool IsDateErr = false;
        public static string GridDate = "";

        public static string strMasterName = "";

        public string strUpdate;
        public string strvalues;
        public string strfields;
        public string strmonth;
        public int month;
        public static int Form_Top, From_Left;
        public static string strHelpSql;
        public static string strFilterText;
        public static string strFilterColumn;

        //public static string strMemberCode = "";

        #region
        public static string fCaste = "fCaste";
        public static string fCountry = "fCountry";
        //public static string fVisaCountry = "fVisaCountry";
        public static string fProfileCreatedBy = "fProfileCreatedBy";
        public static string fAnnualIncomeCurrency = "fAnnualIncomeCurrency";
        public static string fAnnualIncome = "fAnnualIncome";
        public static string fEducation = "fEducation";
        public static string fOccupation = "fOccupation";
        public static string fVisaStatus = "fVisaStatus";
        public static string fWorkingAs = "fWorkingAs";
        public static string fWorkingWith = "fWorkingWith";
        public static string fBloodGroup = "fBloodGroup";
        public static string fMembershipType = "fMembershipType";
        public static string fFacilityDetail = "fFacilityDetail";
        public static string fMaritalStatus = "fMaritalStatus";
        public static string fQueryMessage = "fQueryMessage";
        public static string fEmployeeMaster = "fEmployeeMaster";
        public static string fWorkType = "fWorkType";
        #endregion

        public bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (client.OpenRead("http://www.google.com/"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public string CheckLogin(string UserName, string Password)
        {
            string strUserName = "";
            try
            {
                DataSet ds = objDb.ExecuteDataset("dbo.CheckAdminLogin", UserName, Password);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        strUserName = Convert.ToString(ds.Tables[0].Rows[0][0]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In Global.CheckLogin()" + ex.ToString());
            }
            return strUserName;
        }

        #region CHANGE TEXTBOX BACKGROUP COLOR ON FOCUS
        /// <summary>
        /// Change textbox background color on Focus
        /// </summary>
        /// <param name="frmCntl"></param>
        public void FocusColor(Control frmCntl)
        {
            foreach (Control ctrl in frmCntl.Controls)
            {
                if (ctrl.HasChildren)
                {
                    FocusColor(ctrl);
                }
                //if (ctrl is TextBox)
                //{
                ctrl.GotFocus += txt_GotFocus;
                ctrl.LostFocus += txt_LostFocus;
                //}
            }
        }
        void txt_LostFocus(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            if (ctrl is TextBox)
            {
                ctrl.BackColor = SystemColors.Window;
            }
        }
        void txt_GotFocus(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            if (ctrl is TextBox)
            {
                ctrl.BackColor = Color.LightGoldenrodYellow;
            }
        }
        #endregion

        public void showMessage(string strFormName, string strMsgType, bool isEdit, TextBox txtName)
        {
            try
            {
                if (strMsgType.ToUpper() == "SUCCESS")
                {
                    if (isEdit)
                    {
                        MessageBox.Show(strFormName + " ' " + txtName.Text + " ' has been updated successfully.", strFormName + " updatation successful");
                    }
                    else
                    {
                        MessageBox.Show(strFormName + " ' " + txtName.Text + " ' has been created successfully.", strFormName + " creation successful");
                    }
                }
                else if (isEdit)
                {
                    MessageBox.Show(strFormName + " ' " + txtName.Text + " ' update faild.", strFormName + " update faild");
                }
                else
                {
                    MessageBox.Show(strFormName + " ' " + txtName.Text + " ' create faild.", strMsgType + " create faild");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error in Global.showMessage() " + exception.ToString());
            }
        }

        public string openSearch(DataView dv)
        {
            try
            {
                frmSearch search = new frmSearch
                {
                    //objConn = objConn
                };
                search.BringToFront();
                search.StartPosition = FormStartPosition.CenterParent;
                search.datView = dv;
                search.ShowDialog();
                return search.strSearch[0];
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.Global.openSearch()" + exception.ToString());
                return "";
            }
        }

        public void SingleQuoteBlock(KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '\'')
                {
                    e.Handled = true;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.Global.TextboxFill" + exception.ToString());
            }
        }

        public static bool IsDate(string date)
        {
            string str = "dd/MM/yyyy";
            DateTime dDate;
            try
            {
                if (date.ToString() != "  /  /")
                {
                    DateTimeFormatInfo provider = new DateTimeFormatInfo
                    {
                        ShortDatePattern = str
                    };
                    if (DateTime.TryParse(date, out dDate))
                    {
                        String.Format("{0:d/MM/yyyy}", dDate);
                    }
                    else
                    {
                        return false;
                    }
                    //if (DateTime.ParseExact(date, "d", provider).Month.ToString() == null)
                    //{
                    //    return false;
                    //}
                    return true;
                }
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter Valid Date in dd/MM/yyyy Format", "Date Input Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
        }

        public void UpdateFields(Control frmCntl)
        {
            CheckBox box = null;
            ComboBox box2 = null;
            try
            {
                foreach (Control control in frmCntl.Controls)
                {
                    if (Convert.ToString(control.Tag) != "")
                    {
                        if (control.Tag.ToString().Contains("*"))
                        {
                            this.strUpdate = this.strUpdate + "," + control.Tag.ToString().Substring(1, control.Tag.ToString().Length - 1);
                        }
                        else if ((control.Tag.ToString() != "#") && !control.Tag.ToString().Contains("%"))
                        {
                            this.strUpdate = this.strUpdate + "," + control.Tag;
                        }
                        if (control.Tag.ToString().Contains("*"))
                        {
                            if (control is CheckBox)
                            {
                                box = (CheckBox)control;
                                this.strUpdate = this.strUpdate + " = " + Convert.ToInt16(box.Checked);
                            }
                            else if (control is ComboBox)
                            {
                                box2 = (ComboBox)control;
                                if (box2.SelectedValue == null)
                                {
                                    this.strUpdate = this.strUpdate + " = 0";
                                }
                                else
                                {
                                    this.strUpdate = this.strUpdate + " = " + box2.SelectedValue;
                                }
                            }
                            else if (control.Text.ToString().Trim() != "")
                            {
                                this.strUpdate = this.strUpdate + " = " + control.Text;
                            }
                            else
                            {
                                this.strUpdate = this.strUpdate + " = null";
                            }
                        }
                        else if ((control.Tag.ToString() != "#") && !control.Tag.ToString().Contains("%"))
                        {
                            if (control is MaskedTextBox)
                            {
                                if (IsDate(control.Text) && (control.Text.ToString() != "  /  /"))
                                {
                                    this.strUpdate = this.strUpdate + "='" + this.DateConvert(control.Text) + "'";
                                }
                                else
                                {
                                    this.strUpdate = this.strUpdate + " = null";
                                }
                            }
                            else if (control is ComboBox)
                            {
                                box2 = (ComboBox)control;
                                this.strUpdate = string.Concat(new object[] { this.strUpdate, " = '", box2.SelectedValue, "'" });
                            }
                            else
                            {
                                this.strUpdate = this.strUpdate + " = '" + control.Text + "'";
                            }
                        }
                    }
                    else if (control.HasChildren)
                    {
                        this.UpdateFields(control);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.Global.UpdateFields" + exception.ToString());
            }
        }

        #region SAVEDATA FROM SELECTED COUNTROL
        public void SaveFields(Control frmCntl)
        {
            CheckBox box = null;
            ComboBox box2 = null;
            try
            {
                foreach (Control control in frmCntl.Controls)
                {
                    if (Convert.ToString(control.Tag) != "")
                    {
                        if (control.Tag.ToString().Contains("*"))
                        {
                            if (control is CheckBox)
                            {
                                box = (CheckBox)control;
                                this.strvalues = this.strvalues + "," + Convert.ToInt16(box.Checked);
                            }
                            else if (control is ComboBox)
                            {
                                box2 = (ComboBox)control;
                                if ((box2.SelectedValue == null) || (box2.Text.ToString() == ""))
                                {
                                    this.strvalues = this.strvalues + ",0";
                                }
                                else
                                {
                                    this.strvalues = this.strvalues + "," + box2.SelectedValue;
                                }
                            }
                            else if (control.Text.ToString().Trim() != "")
                            {
                                this.strvalues = this.strvalues + "," + control.Text;
                            }
                            else
                            {
                                this.strvalues = this.strvalues + ",null";
                            }
                        }
                        else if ((control.Tag.ToString() != "#") && !control.Tag.ToString().Contains("%"))
                        {
                            if (control is ComboBox)
                            {
                                box2 = (ComboBox)control;
                                this.strvalues = string.Concat(new object[] { this.strvalues, ",'", box2.SelectedValue, "'" });
                            }
                            else if (control is MaskedTextBox)
                            {
                                if (IsDate(control.Text) && (control.Text.ToString() != "  /  /"))
                                {
                                    this.strvalues = this.strvalues + ",'" + this.DateConvert(control.Text) + "'";
                                }
                                else
                                {
                                    this.strvalues = this.strvalues + ",null";
                                }
                            }
                            else if (control is DateTimePicker)
                            {
                                this.strvalues = this.strvalues + ",'" + (control.Text) + "'";
                            }
                            else
                            {
                                this.strvalues = this.strvalues + ",'" + control.Text + "'";
                            }
                        }
                        if (control.Tag.ToString().Contains("*"))
                        {
                            this.strfields = this.strfields + "," + control.Tag.ToString().Substring(1, control.Tag.ToString().Length - 1);
                        }
                        else if ((control.Tag.ToString() != "#") && !control.Tag.ToString().Contains("%"))
                        {
                            this.strfields = this.strfields + "," + control.Tag;
                        }
                    }
                    else if (control.HasChildren)
                    {
                        this.SaveFields(control);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.Global.SaveFields" + exception.ToString());
            }
        }
        #endregion

        public int SaveMasterRecords(string strTableName, string strTableFieldName, string strCode, string Condition, bool isEdit)
        {
            try
            {
                string str;
                if (this.strUpdate == "")
                {
                    this.strfields = "(" + this.strfields.Substring(1, this.strfields.Length - 1) + ")";
                    this.strvalues = " Values (" + this.strvalues.Substring(1, this.strvalues.Length - 1) + ")";
                    str = "insert into " + strTableName + " ";
                    str = str + this.strfields + " Output Inserted.Package_Id " + this.strvalues;
                }
                else if (Condition == "")
                {
                    this.strUpdate = this.strUpdate.Substring(1, this.strUpdate.Length - 1);
                    str = ("Update " + strTableName + " set ") + this.strUpdate;
                    str = str + " where " + strTableFieldName + "=" + strCode;
                }
                else
                {
                    this.strUpdate = this.strUpdate.Substring(1, this.strUpdate.Length - 1);
                    str = ("Update " + strTableName + " set ") + this.strUpdate;
                    str = str + " where " + strTableFieldName + "=" + strCode + " and " + Condition;
                }
                if (isEdit)
                {
                    return this.objDb.ExecuteNonQuery(str);
                }
                else
                {
                    return Convert.ToInt32(this.objDb.ExecuteScalar(str));
                }
                
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.Global.SaveMasterRecords" + exception.ToString());
                return 0;
            }
        }

        public string DateConvert(object MyDate)
        {
            try
            {
                this.month = Convert.ToInt16(MyDate.ToString().Substring(3, 2));
                switch (this.month)
                {
                    case 1:
                        this.strmonth = "jan";
                        break;

                    case 2:
                        this.strmonth = "feb";
                        break;

                    case 3:
                        this.strmonth = "mar";
                        break;

                    case 4:
                        this.strmonth = "apr";
                        break;

                    case 5:
                        this.strmonth = "may";
                        break;

                    case 6:
                        this.strmonth = "jun";
                        break;

                    case 7:
                        this.strmonth = "jul";
                        break;

                    case 8:
                        this.strmonth = "aug";
                        break;

                    case 9:
                        this.strmonth = "sep";
                        break;

                    case 10:
                        this.strmonth = "oct";
                        break;

                    case 11:
                        this.strmonth = "nov";
                        break;

                    case 12:
                        this.strmonth = "dec";
                        break;
                }
                return (MyDate.ToString().Substring(0, 3) + this.strmonth + MyDate.ToString().Substring(5, 5));
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.Global.DateConvert()" + exception.ToString());
                return null;
            }
        }

        public void ScreenPosition(Control cnt, string SearchCol)
        {
            Point p = new Point(0, 0);
            Point point2 = cnt.PointToScreen(p);
            Form_Top = point2.Y;
            From_Left = point2.X + cnt.Width;
            strSearchSqlWidth = SearchCol;
        }

        public void OpenHelpTxtBox_Validating(DataView datView, string HelpSql, string FilterColumn, bool bolMandatory, TextBox txtName, TextBox txtId)
        {
            try
            {
                strHelpSql = HelpSql;
                if (txtName.Enabled)
                {
                    if ((txtName.Text.ToString() != "") && (FilterColumn != ""))
                    {
                        strFilterText = txtName.Text;
                        strFilterColumn = FilterColumn;
                        datView.RowFilter = strFilterColumn.ToUpper() + " = '" + txtName.Text.ToString().ToUpper() + "'";
                        if (datView.Count > 0)
                        {
                            DataRow row = datView[0].Row;
                            txtId.Text = row[0].ToString();
                            txtName.Text = row[1].ToString();
                        }
                        else
                        {
                            this.openHelp(txtId, txtName);
                        }
                    }
                    else
                    {
                        strFilterText = "";
                        strFilterColumn = "";
                        if (bolMandatory)
                        {
                            this.openHelp(txtId, txtName);
                        }
                        else
                        {
                            txtId.Text = "";
                            txtName.Text = "";
                        }
                    }
                }
                if (bolMandatory && (txtName.Text == ""))
                {
                    txtId.Text = "";
                    txtName.Focus();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.Global.OpenHelpTxtBox_Validating" + exception.ToString());
            }
        }

        public void openHelp(TextBox txtId, TextBox txtText)
        {
            try
            {
                frmCommonHelp help = new frmCommonHelp();
                help.BringToFront();
                help.ShowDialog();
                txtId.Text = help.strHelp[0];
                txtText.Text = help.strHelp[1];
                txtText.SelectionStart = txtText.Text.Length;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.Global.openHelp" + exception.ToString());
            }
        }
        public void openHelp(TextBox txtId, TextBox txtText, DataView Helpview)
        {
            try
            {
                frmCommonHelp help = new frmCommonHelp();
                help.BringToFront();
                help.fillDataGridView(Helpview);
                help.ShowDialog();
                txtId.Text = help.strHelp[0];
                txtText.Text = help.strHelp[1];
                txtText.SelectionStart = txtText.Text.Length;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.Global.openHelp" + exception.ToString());
            }
        }

        public DataTable GetYearList(int FromYear, int ToYear)
        {
            DataTable dtYearList = new DataTable();
            try
            {
                DataSet ds = objDb.ExecuteDataset("GetBirthYearList", FromYear, ToYear);
                dtYearList = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtYearList;
        }

        public void CalcSrNo(DataGridView dgv)
        {
            try
            {
                if (dgv.RowCount > 0)
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        dgv.Rows[i].HeaderCell.Value = Convert.ToString((int)(i + 1));
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.Global.CalcSrNo" + exception.ToString());
            }
        }

        public void onlyNumber(object sender, KeyPressEventArgs e, bool isDecimal)
        {
            TextBox box = (TextBox)sender;
            try
            {
                if (!box.ReadOnly)
                {
                    if (isDecimal)
                    {
                        if ((box.SelectionLength > 0) && (e.KeyChar == '.'))
                        {
                            e.Handled = true;
                        }
                        if ((box.Text == string.Empty) && (e.KeyChar == '.'))
                        {
                            e.Handled = true;
                        }
                        if (box.Text.Contains(".") && (e.KeyChar == '.'))
                        {
                            e.Handled = true;
                        }
                        if (box.Text.Contains(".") && (e.KeyChar != '\b'))
                        {
                            int index = box.Text.ToString().IndexOf(".");
                            if (box.Text.ToString().Substring(index, box.Text.ToString().Length - index).Length == 4)
                            {
                                e.Handled = true;
                            }
                        }
                        if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) && (e.KeyChar != '.'))
                        {
                            e.Handled = true;
                        }
                    }
                    else if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)))
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error in Global.onlyNumber() " + exception.ToString());
            }
        }

        public void DisplayFields(Control frmCntl, DataTable datTable)
        {
            CheckBox box = null;
            ComboBox box2 = null;
            try
            {
                foreach (Control control in frmCntl.Controls)
                {
                    if ((control.Tag != null) && (control.Tag.ToString().Trim() != ""))
                    {
                        if (control.Tag.ToString().Contains("*"))
                        {
                            if (control is CheckBox)
                            {
                                box = (CheckBox)control;
                                string str = control.Tag.ToString().Contains("*") ? control.Tag.ToString().Trim().Substring(1, control.Tag.ToString().Length - 1).ToString() : control.Tag.ToString();
                                box.Checked = (bool)datTable.Rows[0][str];
                            }
                            else if (control is ComboBox)
                            {
                                box2 = (ComboBox)control;
                                box2.SelectedValue = datTable.Rows[0][control.Tag.ToString().Trim().Substring(1, control.Tag.ToString().Trim().Length - 1)];
                            }
                            else
                            {
                                control.Text = datTable.Rows[0][control.Tag.ToString().Substring(1, control.Tag.ToString().Trim().Length - 1).ToString()].ToString();
                            }
                        }
                        else if (control.Tag.ToString().Trim() != "#")
                        {
                            if (control.Tag.ToString().Trim().Contains("%"))
                            {
                                if (datTable.Rows[0][control.Tag.ToString().Trim().Substring(1, control.Tag.ToString().Trim().Length - 1)] == DBNull.Value)
                                {
                                    control.Text = "";
                                }
                                else
                                {
                                    control.Text = datTable.Rows[0][control.Tag.ToString().Trim().Substring(1, control.Tag.ToString().Trim().Length - 1)].ToString();
                                }
                            }
                            else if (control is MaskedTextBox)
                            {
                                if (datTable.Rows[0][control.Tag.ToString()] == DBNull.Value)
                                {
                                    control.Text = "";
                                }
                                else
                                {
                                    DateTime _datetime = Convert.ToDateTime(datTable.Rows[0][control.Tag.ToString().Trim()].ToString());
                                    control.Text = _datetime.ToString("dd/MM/yyyy");
                                }
                            }
                            else if (control is DateTimePicker)
                            {
                                control.Text = datTable.Rows[0][control.Tag.ToString().Trim()].ToString();
                            }
                            else if (control is ComboBox)
                            {
                                box2 = (ComboBox)control;
                                box2.Text = datTable.Rows[0][control.Tag.ToString().Trim()].ToString();
                                control.Text = datTable.Rows[0][control.Tag.ToString().Trim()].ToString();
                            }
                            else if (datTable.Rows[0][control.Tag.ToString().Trim()] == DBNull.Value)
                            {
                                control.Text = "";
                            }
                            else
                            {
                                control.Text = datTable.Rows[0][control.Tag.ToString().Trim()].ToString();
                            }
                        }
                    }
                    else if (control.HasChildren)
                    {
                        this.DisplayFields(control, datTable);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.Global.DisplayFields()" + exception.ToString());
            }
        }

        public void Insert_Rows_Abvoe(DataGridView dgv)
        {
            try
            {
                if (dgv.CurrentRow.Index > 0)
                {
                    dgv.Rows.Insert(dgv.CurrentRow.Index - 1, new object[0]);
                    dgv.EndEdit();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.Global.Insert_Rows_Abvoe" + exception.ToString());
            }
        }
        public void Insert_Rows_Below(DataGridView dgv)
        {
            try
            {
                if (dgv.CurrentRow.Index >= 0)
                {
                    dgv.Rows.Insert(dgv.CurrentRow.Index + 1, new object[0]);
                    dgv.EndEdit();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.Global.Insert_Rows_Below" + exception.ToString());
            }
        }
        public void Delete_Selected_Rows(DataGridView dgv)
        {
            try
            {
                if (((dgv.SelectedRows.Count > 0) && (dgv.CurrentRow.Index >= 0)) && (MessageBox.Show("Do you want to Delete Selected Rows?", "Delete Selected Rows Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    foreach (DataGridViewRow row in dgv.SelectedRows)
                    {
                        dgv.Rows.Remove(row);
                        dgv.EndEdit();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.Global.Delete_Selected_Rows" + exception.ToString());
            }
        }

        public bool SendMail(string ToEmailAddres, string MailSubject, string MailBody, bool HTML, string FromMialAdd, string Password)
        {

            try
            {
                FromMialAdd = "hits@anantmatrimony.com";
                Password = "bu97Ul#0";
                ToEmailAddres = "sanket164@gmail.com";

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("103.138.96.8");
                //SmtpClient SmtpServer = new SmtpClient("smtp.mail.yahoo.com");

                mail.From = new MailAddress(FromMialAdd);
                mail.To.Add(ToEmailAddres);
                mail.Subject = MailSubject;
                mail.Body = MailBody;
                //Attachment attachment = new Attachment(filename);
                //mail.Attachments.Add(attachment);
                if (HTML)
                {
                    mail.IsBodyHtml = true;
                }

                SmtpServer.Port = 587;
                //SmtpServer.UseDefaultCredentials = false;
                //SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.Credentials = new System.Net.NetworkCredential(FromMialAdd, Password);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

                // MessageBox.Show("Your Mail is sended");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        #region FILLLISTVIEW
        /// <summary>
        /// FILLLISTVIEW 
        /// </summary>
        /// <param name="LVW"></param>
        /// <param name="STRS"></param>
        public void FillListView(ListView LVW, string STRS, int[] FieldLenght)
        {
            try
            {
                LVW.Clear();
                DataTable Dtable;
                Dtable = objDb.GetDataTable(STRS);
                if (Dtable.Rows.Count > 0)
                {
                    ListViewItem LvwItem = new ListViewItem();
                    LVW.CheckBoxes = true;
                    for (int Cnt = 0; Cnt < Dtable.Columns.Count; Cnt++)
                    {
                        LVW.Columns.Add(Convert.ToString(Dtable.Columns[Cnt].ColumnName), FieldLenght[Cnt]);
                    }
                    for (int Cnt = 0; Cnt < Dtable.Rows.Count; Cnt++)
                    {
                        for (int Col = 0; Col < Dtable.Columns.Count; Col++)
                        {
                            if (Col == 0)
                            {
                                LvwItem = LVW.Items.Add(Convert.ToString(Dtable.Rows[Cnt][Col]));
                            }
                            else if (Col == 1)
                            {
                                LvwItem.SubItems.Add(Convert.ToString(Dtable.Rows[Cnt][Col]));
                            }
                            else
                            {
                                LvwItem.SubItems.Add(Convert.ToString(Dtable.Rows[Cnt][Col]));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.Global.FillListView()" + ex.ToString());

            }
        }

        public void FillListView(ListView LVW, DataTable dtDetails, int[] FieldLenght)
        {
            try
            {
                LVW.Clear();
                if (dtDetails.Rows.Count > 0)
                {
                    ListViewItem LvwItem = new ListViewItem();
                    LVW.CheckBoxes = true;
                    for (int Cnt = 0; Cnt < dtDetails.Columns.Count; Cnt++)
                    {
                        LVW.Columns.Add(Convert.ToString(dtDetails.Columns[Cnt].ColumnName), FieldLenght[Cnt]);
                    }
                    for (int Cnt = 0; Cnt < dtDetails.Rows.Count; Cnt++)
                    {
                        for (int Col = 0; Col < dtDetails.Columns.Count; Col++)
                        {
                            if (Col == 0)
                            {
                                LvwItem = LVW.Items.Add(Convert.ToString(dtDetails.Rows[Cnt][Col]));
                            }
                            else if (Col == 1)
                            {
                                LvwItem.SubItems.Add(Convert.ToString(dtDetails.Rows[Cnt][Col]));
                            }
                            else
                            {
                                LvwItem.SubItems.Add(Convert.ToString(dtDetails.Rows[Cnt][Col]));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.Global.FillListView()" + ex.ToString());

            }
        }

        #endregion

        #region LISTVIEWSELECTION
        /// <summary>
        /// PASS LISTVIEW NAME AND PARAMETER VALUE TRUE FOR SELECTION(ACCORDING)
        /// </summary>
        /// <param name="SELALL"></param>
        /// <param name="LVW"></param>
        public void LISTVIEWSELECTION(ListView LVW, bool SELALL, bool CLR, bool INVERT)
        {
            try
            {
                if (SELALL)
                {
                    for (int Cnt = 0; Cnt < LVW.Items.Count; Cnt++)
                    {
                        LVW.Items[Cnt].Checked = true;
                    }
                }
                else if (CLR)
                {
                    for (int Cnt = 0; Cnt < LVW.Items.Count; Cnt++)
                    {
                        LVW.Items[Cnt].Checked = false;
                    }
                }
                else if (INVERT)
                {

                    if (LVW.Items.Count > 0)
                    {
                        for (int Cnt = 0; Cnt < LVW.Items.Count; Cnt++)
                        {

                            if (LVW.Items[Cnt].Checked)
                            {
                                LVW.Items[Cnt].Checked = false;
                            }
                            else
                            {
                                LVW.Items[Cnt].Checked = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.Global.LISTVIEWSELECTION()" + ex.ToString());
            }

        }
        #endregion

        public bool SendSMS(string MobileNo, string strMsg, bool tTread)
        {
            string authKey = System.Configuration.ConfigurationManager.AppSettings["authKey"];
            string strResult = "";
            string senderId = System.Configuration.ConfigurationManager.AppSettings["senderId"];
            string sendSMSUri = System.Configuration.ConfigurationManager.AppSettings["sendSMSUri"];

            try
            {
                //Prepare you post parameters
                MobileNo = "91" + MobileNo;
                StringBuilder sbPostData = new StringBuilder();
                sbPostData.AppendFormat("authkey={0}", authKey);
                sbPostData.AppendFormat("&mobiles={0}", MobileNo);
                sbPostData.AppendFormat("&message={0}", strMsg);
                sbPostData.AppendFormat("&sender={0}", senderId);
                sbPostData.AppendFormat("&route={0}", "4");

                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
                //Prepare and Add URL Encoded data
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] data = encoding.GetBytes(sbPostData.ToString());
                //Specify post method
                httpWReq.Method = "POST";
                httpWReq.ContentType = "application/x-www-form-urlencoded";
                httpWReq.ContentLength = data.Length;
                using (Stream stream = httpWReq.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                //Get the response
                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string responseString = reader.ReadToEnd();
                strResult = response.ToString();
                //Close the response
                reader.Close();
                response.Close();
                CreateSMSLog(strMsg, MobileNo);
                if (tTread)
                {
                    Thread.Sleep(30000);
                }
                return true;
            }
            catch (Exception ex)
            {
                strResult = ex.Message.ToString();
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }

        public void CreateSMSLog(string strMessage, string MobileNumber)
        {
            try
            {
                StreamWriter writer = null;
                string str = Convert.ToString(DateTime.Now.ToString("ddMMyyyy"));
                bool flag = File.Exists("C:/ApplicationLog/AanantSMSLog/SMSLog_" + str + ".txt");
                if (Directory.Exists("C:/ApplicationLog/AanantSMSLog"))
                {
                    if (flag)
                    {
                        writer = new StreamWriter("C:/ApplicationLog/AanantSMSLog/SMSLog_" + str + ".txt", true);
                        writer.WriteLine(this.WriteInFile(strMessage, MobileNumber));
                        writer.Close();
                        return;
                    }
                    File.Create("C:/ApplicationLog/AanantSMSLog/AppLog_" + str + ".txt").Close();
                    writer = new StreamWriter("C:/ApplicationLog/AanantSMSLog/SMSLog_" + str + ".txt", true);
                    writer.WriteLine(this.WriteInFile(strMessage, MobileNumber));
                    writer.Close();
                    return;
                }
                Directory.CreateDirectory("C:/ApplicationLog/AanantSMSLog");
                File.Create("C:/ApplicationLog/AanantSMSLog/AppLog_" + str + ".txt").Close();
                writer = new StreamWriter("C:/ApplicationLog/AanantSMSLog/SMSLog_" + str + ".txt", true);
                writer.WriteLine(WriteInFile(strMessage, MobileNumber));
                writer.Close();
                return;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public string WriteInFile(string strMessage, string MobileNumber)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("============================================\r\n");
            builder.Append(" \r\n");
            builder.Append("Message Sent " + DateTime.Now.TimeOfDay.ToString() + "\r\n");
            builder.Append("-----------------------------------------------------\r\n");
            builder.Append("Message : " + strMessage + "\r\n Phone Number : " + MobileNumber);
            builder.Append(" \r\n");
            return Convert.ToString(builder);
        }





    }
}
