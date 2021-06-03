using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using AnantMatrimony.UD_CLASS;
using AnantMatrimony.MatrimonyDAL;


namespace AnantMatrimony.FROMS
{
    public partial class frmCommonHelp : Form
    {   
        EventLogging objEventLoging = new EventLogging();
        Global objGlobal = new Global();
        dbInteraction objDb = new dbInteraction();

        DataView datView;
        DataView HelpView;
        DataView dtMainView;

        public string[] strHelp;
        bool boolClose;
        int intColumnCount;
        int colIndex;


        //SqlConnection dbConn;
        //SqlDataAdapter dataAdpter;        
        //DataTable dTable = new DataTable();      


        public frmCommonHelp()
        {
            InitializeComponent();
        }

        private void frmCommonHelp_Load(object sender, EventArgs e)
        {
            try
            {

                this.Top = Global.Form_Top;
                this.Left = Global.From_Left;
                if (HelpView == null)
                    fillDataGridView(Global.strHelpSql, Global.strFilterText, Global.strFilterColumn);
                //  grdHelp.Columns[0].Visible = false;
                lblSearchType.Text = grdHelp.Columns[1].Name;
                int TotalCol = grdHelp.ColumnCount;
                strHelp = new string[TotalCol];
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonHelp.frmCommonHelp_Load()" + ex.ToString());
            }

        }

        private void grdHelp_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int KeyAscii = Convert.ToInt32(e.KeyChar);

                if (KeyAscii > 96 && KeyAscii < 123)
                {
                    e.KeyChar = Convert.ToChar(KeyAscii - 32);
                }

                if (KeyAscii == 8)
                {
                    if ((txtFilterText.Text.Length) > 0)
                    {
                        txtFilterText.Text = txtFilterText.Text.Substring(0, (txtFilterText.Text.Length - 1));
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (KeyAscii != 13 && KeyAscii != 9)
                    {
                        txtFilterText.Text = txtFilterText.Text + e.KeyChar;
                    }
                }

                if (txtFilterText.Text.ToString() != "")
                {
                    if (grdHelp.CurrentCell != null)
                    {
                        //datView.RowFilter = grdHelp.Columns[grdHelp.SelectedCells[0].ColumnIndex].Name + " LIKE '" + txtFilterText.Text.ToString() + "%'";
                        datView.RowFilter = lblSearchType.Text + " LIKE '" + txtFilterText.Text.ToString() + "%'";
                    }
                    else
                    {
                        datView.RowFilter = lblSearchType.Text + " LIKE '" + txtFilterText.Text.ToString() + "%'";
                    }

                }
                else
                {
                    datView.RowFilter = "";
                }

                if (grdHelp.CurrentCell != null && colIndex > 0)
                {
                    grdHelp.Focus();
                    grdHelp.Rows[grdHelp.CurrentRow.Index].Cells[colIndex].Selected = true;
                }
                if (datView.Count != dtMainView.Count)
                {
                    for (int cnt = 0; cnt < datView.Count; cnt++)
                    {
                        for (int icnt = 0; icnt < dtMainView.Count; icnt++)
                        {
                            if (Convert.ToString(datView.Table.Rows[cnt][lblSearchType.Text]) == Convert.ToString(dtMainView.Table.Rows[icnt][lblSearchType.Text]))
                            {
                                grdHelp.ClearSelection();
                                //DataGridViewRow row = new DataGridViewRow();
                                //row.DefaultCellStyle.BackColor = Color.Red; 
                                //grdHelp.Columns[lblSearchType.Text].DefaultCellStyle.ForeColor = Color.Red;
                                break;
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonHelp.grdHelp_KeyPress()" + ex.ToString());
            }
        }

        private void grdHelp_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (grdHelp.CurrentCell != null)
                {
                    colIndex = grdHelp.CurrentCell.ColumnIndex;
                    grdHelp.Focus();
                    grdHelp.Rows[grdHelp.CurrentRow.Index].Cells[colIndex].Selected = true;
                    lblSearchType.Text = grdHelp.Columns[grdHelp.SelectedCells[0].ColumnIndex].Name;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonHelp.grdHelp_KeyUp()" + ex.ToString());
            }
        }

        private void grdHelp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (grdHelp.Rows.Count >= 1)
                        {
                            for (
                                intColumnCount = strHelp.Length; intColumnCount > strHelp.Length; intColumnCount--)
                            {
                                strHelp[intColumnCount].Remove(intColumnCount);
                            }
                            for (intColumnCount = 0; intColumnCount < grdHelp.Columns.Count; intColumnCount++)
                            {
                                strHelp[intColumnCount] = grdHelp.Rows[grdHelp.CurrentRow.Index].Cells[intColumnCount].Value.ToString();
                            }
                            boolClose = true;
                            this.Close();
                        }
                        break;

                    case Keys.Escape:
                        for (intColumnCount = strHelp.Length; intColumnCount > strHelp.Length; intColumnCount--)
                        {
                            strHelp[intColumnCount].Remove(intColumnCount);
                        }
                        for (intColumnCount = 0; intColumnCount < grdHelp.Columns.Count; intColumnCount++)
                        {
                            strHelp[intColumnCount] = "";
                        }

                        boolClose = true;
                        this.Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonHelp.grdHelp_KeyDown()" + ex.ToString());
            }
        }

        private void grdHelp_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (grdHelp.CurrentCell != null)
                {
                    colIndex = grdHelp.CurrentCell.ColumnIndex;
                    grdHelp.Focus();
                    grdHelp.Rows[grdHelp.CurrentRow.Index].Cells[colIndex].Selected = true;
                    lblSearchType.Text = grdHelp.Columns[grdHelp.SelectedCells[0].ColumnIndex].Name;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonHelp.grdHelp_MouseClick()" + ex.ToString());
            }
        }

        private void grdHelp_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (grdHelp.Rows.Count >= 1)
                {
                    for (intColumnCount = strHelp.Length; intColumnCount > strHelp.Length; intColumnCount--)
                    {
                        strHelp[intColumnCount].Remove(intColumnCount);
                    }
                    for (intColumnCount = 0; intColumnCount < grdHelp.Columns.Count; intColumnCount++)
                    {
                        strHelp[intColumnCount] = grdHelp.Rows[grdHelp.CurrentRow.Index].Cells[intColumnCount].Value.ToString();
                    }
                    boolClose = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonHelp.grdHelp_MouseDoubleClick()" + ex.ToString());
            }
        }

        private void fillDataGridView(string strSql, string strFilterText, string strFilterColumn)
        {

            try
            {
                datView = objDb.GetDataView(strSql);
                dtMainView = objDb.GetDataView(strSql);
                if (strFilterText != "")
                {
                    txtFilterText.Text = strFilterText;
                    datView.RowFilter = strFilterColumn + " LIKE '" + txtFilterText.Text.ToString() + "%'";
                }
                grdHelp.DataSource = datView;
                //gridDesign(grdHelp, dTable);
                gridDesign(grdHelp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonHelp.fillDataGridView()" + ex.ToString());
            }
        }
        public void fillDataGridView(DataView View)
        {
            try
            {
                datView = View;
                HelpView = View;
                dtMainView = datView;
                if (Global.strFilterText != "")
                {
                    txtFilterText.Text = Global.strFilterText;
                    datView.RowFilter = Global.strFilterColumn + " LIKE '" + txtFilterText.Text.ToString() + "%'";
                }
                grdHelp.DataSource = dtMainView;
                gridDesign(grdHelp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonHelp.fillDataGridView()" + ex.ToString());
            }
        }

        private void frmCommonHelp_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (boolClose == false)
                {
                    for (intColumnCount = strHelp.Length; intColumnCount > strHelp.Length; intColumnCount--)
                    {
                        strHelp[intColumnCount].Remove(intColumnCount);
                    }
                    for (intColumnCount = 0; intColumnCount < grdHelp.Columns.Count; intColumnCount++)
                    {
                        strHelp[intColumnCount] = "";
                    }
                }
                boolClose = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonHelp.frmCommonHelp_FormClosed()" + ex.ToString());
            }
        }

        public void gridDesign(DataGridView dgv)
        {
            try
            {
                if (Global.strSearchSqlWidth != null)
                {
                    if (Convert.ToString(Global.strSearchSqlWidth) != "")
                    {

                        string[] Colwidth;
                        Colwidth = Global.strSearchSqlWidth.ToString().Split(':');
                        grdHelp.TopLeftHeaderCell.Value = "SrNo.";
                        grdHelp.RowHeadersWidth = 50;
                        if (Colwidth.Length > 0)
                        {
                            for (int cnt = 1; cnt < Colwidth.Length; cnt++)
                            {
                                if (Colwidth[cnt] != "" || Colwidth[cnt] != null)
                                {
                                    if (grdHelp.Columns.Count > cnt)
                                    {
                                        grdHelp.Columns[cnt].Width = Convert.ToInt16(Colwidth[cnt]);
                                        if (Convert.ToInt16(Colwidth[cnt]) == 0)
                                        {
                                            grdHelp.Columns[cnt].Visible = false;
                                        }
                                    }
                                }
                            }
                        }
                        grdHelp.Columns[0].Visible = false;
                        Global.strSearchSqlWidth = "";
                        grdHelp.DefaultCellStyle.BackColor = Color.LightYellow;
                        return;
                    }
                }
                DataColumn dataCol;
                int intColCount = 0;
                dgv.TopLeftHeaderCell.Value = "";
                for (int i = 0; i < datView.Table.Columns.Count; i++)
                {

                    dataCol = datView.Table.Columns[i];
                    if (dataCol.DataType.Name == "String")
                    {
                        if (dataCol.MaxLength <= 10)
                        {
                            dgv.Columns[i].Width = 70;
                        }
                        else if (dataCol.MaxLength <= 20)
                        {
                            dgv.Columns[i].Width = 100;
                        }
                        else if (dataCol.MaxLength == 92)
                        {
                            dgv.Columns[i].Width = 80;
                        }
                        else if ((dataCol.MaxLength * 4) >= 200)
                        {
                            dgv.Columns[i].Width = 150;
                        }
                        else
                        {
                            dgv.Columns[i].Width = dataCol.MaxLength * 2;
                        }
                    }
                    else if (dataCol.DataType.Name == "Decimal")
                    {
                        dgv.Columns[i].Width = 100;
                    }

                    intColCount = intColCount + 1;
                }
                dgv.Columns[0].Visible = false;
                dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonHelp.gridDesign()" + ex.ToString());
            }

        }



        private void frmCommonHelp_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                objGlobal.SingleQuoteBlock(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonHelp.frmCommonHelp_KeyPress()" + ex.ToString());
            }
        }

        private void lblSearchType_Click(object sender, EventArgs e)
        {

        }

        private void txtFilterText_TextChanged(object sender, EventArgs e)
        {

        }

        private void grdHelp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public void GridColWidth()
        {
            string[] Colwidth;
            Colwidth = Global.strSearchSqlWidth.ToString().Split(':');
            for (int cnt = 1; cnt < Colwidth.Length; cnt++)
            {
                grdHelp.Columns[cnt].Width = Convert.ToInt16(Colwidth[cnt]);
            }
            grdHelp.Columns[0].Visible = false;
        }

    }
}