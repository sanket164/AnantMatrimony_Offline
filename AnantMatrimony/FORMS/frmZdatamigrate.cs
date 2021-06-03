using AnantMatrimony.MatrimonyDAL;
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
    public partial class frmZdatamigrate : Form
    {
        public frmZdatamigrate()
        {
            InitializeComponent();
        }

        dbInteraction objDb = new dbInteraction();

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                string strSql = " select * from tbl_ProfilevisitLog where isnull(flag,0)=0 ";
                DataTable dtDetails = objDb.GetDataTable(strSql);
                if (dtDetails.Rows.Count > 0)
                {
                    richTextBox1.Text = "Total Count :" + dtDetails.Rows.Count;
                    richTextBox1.Text += Environment.NewLine;
                    for (int cnt = 0; cnt < dtDetails.Rows.Count; cnt++)
                    {
                        int MemberCode = Convert.ToInt32(dtDetails.Rows[cnt]["MemberCode"]);
                        string VisitProfileId = Convert.ToString(dtDetails.Rows[cnt]["VisitProfileId"]);
                        string[] VisitProfileId_arr = VisitProfileId.Split(',');
                        richTextBox1.Text += "Member Code :" + MemberCode;
                        richTextBox1.Text += Environment.NewLine;
                        if (VisitProfileId_arr.Length > 0)
                        {
                            richTextBox1.Text += "Total Profile :" + VisitProfileId_arr.Length;
                            richTextBox1.Text += Environment.NewLine;
                            for (int icnt = 0; icnt < VisitProfileId_arr.Length; icnt++)
                            {
                                strSql = " INSERT INTO tbl_ProfilevisitLog_new (MemberCode,ProfileId) VALUES (";
                                strSql += MemberCode + ",'" + VisitProfileId_arr[icnt] + "')";
                                objDb.ExecuteNonQuery(strSql);
                            }
                            richTextBox1.Text += "Profile transferd :" + MemberCode;
                            richTextBox1.Text += Environment.NewLine;
                            strSql = " UPDATE tbl_ProfilevisitLog SET flag=1 WHERE MemberCode=" + MemberCode;
                            objDb.ExecuteNonQuery(strSql);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
