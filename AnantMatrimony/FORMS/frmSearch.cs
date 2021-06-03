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

namespace AnantMatrimony.FORMS
{
    public partial class frmSearch : Form
    {
        EventLogging objEventLoging = new EventLogging();
        Global objGlobal = new Global();

        public DataView datView;

        public string[] strSearch = new string[1];
        bool boolClose;
        int intColumnCount;
        int colIndex;

        public frmSearch()
        {
            InitializeComponent();
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            try
            {
                fillDataGridView(Global.strSearchSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                objEventLoging.AppErrlog("Error In AnantMatrimony.frmSearch_Load()" + ex.ToString());
            }

        }

        private void grdSearch_KeyPress(object sender, KeyPressEventArgs e)
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
                    //if (grdSearch.CurrentCell != null)
                    //{
                    //    datView.RowFilter = grdSearch.Columns[grdSearch.SelectedCells[0].ColumnIndex].Name + "' LIKE '" + Convert.ToString(txtFilterText.Text) + "%'";
                    //}
                    //string Filter = Convert.ToString(txtFilterText.Text);
                    //datView.RowFilter = lblSearchType.Text + "' LIKE '" + Filter + "%'";
                    datView.RowFilter = lblSearchType.Text + " LIKE '" + Convert.ToString(txtFilterText.Text) + "%'";
                }
                else
                {
                    datView.RowFilter = "";
                }

                if (grdSearch.CurrentCell != null && colIndex > 0)
                {
                    grdSearch.Focus();
                    grdSearch.Rows[grdSearch.CurrentRow.Index].Cells[colIndex].Selected = true;
                }
                lblTotal.Text = "Total : " + Convert.ToString(datView.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                objEventLoging.AppErrlog("Error In AnantMatrimony.frmSearch.grdSearch_KeyPress()" + ex.ToString());
            }
        }

        private void grdSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (grdSearch.CurrentCell != null)
                {
                    colIndex = grdSearch.CurrentCell.ColumnIndex;
                    grdSearch.Focus();
                    grdSearch.Rows[grdSearch.CurrentRow.Index].Cells[colIndex].Selected = true;
                    lblSearchType.Text = grdSearch.Columns[grdSearch.SelectedCells[0].ColumnIndex].Name;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                objEventLoging.AppErrlog("Error In AnantMatrimony.frmSearch.grdSearch_KeyUp()" + ex.ToString());
            }
        }

        private void grdSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (grdSearch.Rows.Count >= 1)
                        {
                            for (intColumnCount = strSearch.Length; intColumnCount > strSearch.Length; intColumnCount--)
                            {
                                strSearch[intColumnCount].Remove(intColumnCount);
                            }
                            for (intColumnCount = 0; intColumnCount < 1; intColumnCount++)
                            {
                                strSearch[intColumnCount] = grdSearch.Rows[grdSearch.CurrentRow.Index].Cells[intColumnCount].Value.ToString();
                            }
                            boolClose = true;
                            this.Close();
                        }
                        break;

                    case Keys.Escape:
                        for (intColumnCount = strSearch.Length; intColumnCount > strSearch.Length; intColumnCount--)
                        {
                            strSearch[intColumnCount].Remove(intColumnCount);
                        }
                        for (intColumnCount = 0; intColumnCount < 1; intColumnCount++)
                        {
                            strSearch[intColumnCount] = "";
                        }

                        boolClose = true;
                        this.Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                objEventLoging.AppErrlog("Error In AnantMatrimony.frmSearch.grdSearch_KeyDown()" + ex.ToString());
            }
        }

        private void grdSearch_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (grdSearch.Rows.Count >= 1)
                {
                    for (intColumnCount = strSearch.Length; intColumnCount > strSearch.Length; intColumnCount--)
                    {
                        strSearch[intColumnCount].Remove(intColumnCount);
                    }
                    for (intColumnCount = 0; intColumnCount < 1; intColumnCount++)
                    {
                        strSearch[intColumnCount] = grdSearch.Rows[grdSearch.CurrentRow.Index].Cells[intColumnCount].Value.ToString();
                    }
                    boolClose = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                objEventLoging.AppErrlog("Error In AnantMatrimony.frmSearch.grdSearch_MouseDoubleClick()" + ex.ToString());
            }
        }

        private void fillDataGridView(string strSql)
        {

            try
            {   
                grdSearch.DataSource = datView;
                lblTotal.Text = "Total : " + Convert.ToString(datView.Count);
                // gridDesign(grdSearch);
                if (Global.strSearchSqlWidth == "" || Global.strSearchSqlWidth == null)
                {
                    gridDesign(grdSearch);
                }
                else
                {
                    GridColWidth();
                    Global.strSearchSqlWidth = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                objEventLoging.AppErrlog("Error In AnantMatrimony.frmSearch.fillDataGridView()" + ex.ToString());
            }


        }
        public void GridColWidth()
        {
            string[] Colwidth;
            Colwidth = Global.strSearchSqlWidth.ToString().Split(':');
            grdSearch.TopLeftHeaderCell.Value = "SrNo.";
            grdSearch.RowHeadersWidth = 50;
            for (int cnt = 1; cnt < Colwidth.Length; cnt++)
            {
                grdSearch.Columns[cnt].Width = Convert.ToInt16(Colwidth[cnt]);
            }
            grdSearch.Columns[0].Visible = false;
            Global.strSearchSqlWidth = "";
        }

        private void frmSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (boolClose == false)
                {
                    for (intColumnCount = strSearch.Length; intColumnCount > strSearch.Length; intColumnCount--)
                    {
                        strSearch[intColumnCount].Remove(intColumnCount);
                    }
                    for (intColumnCount = 0; intColumnCount < 1; intColumnCount++)
                    {
                        strSearch[intColumnCount] = "";
                    }
                }
                boolClose = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                objEventLoging.AppErrlog("Error In AnantMatrimony.frmSearch.frmSearch_FormClosed()" + ex.ToString());
            }

        }

        public void gridDesign(DataGridView dgv)
        {
            try
            {
                DataColumn dataCol;
                int intColCount = 0;
                dgv.TopLeftHeaderCell.Value = "SrNo.";
                dgv.RowHeadersWidth = 70;


                for (int i = 0; i < datView.Table.Columns.Count; i++)
                {
                    dataCol = datView.Table.Columns[i];
                    if (dataCol.DataType.Name == "String")
                    {
                        if (dataCol.MaxLength <= 20)
                        {
                            dgv.Columns[i].Width = 100;
                        }
                        else if (dataCol.MaxLength == 92)
                        {
                            dgv.Columns[i].Width = 100;
                        }
                        else if ((dataCol.MaxLength * 4) >= 200)
                        {
                            dgv.Columns[i].Width = 250;
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
                MessageBox.Show(ex.Message.ToString());
                objEventLoging.AppErrlog("Error In AnantMatrimony.frmSearch.gridDesign()" + ex.ToString());
            }

        }
        public void CalcSrNo()
        {
            try
            {
                for (int Cnt = 0; Cnt < grdSearch.RowCount; Cnt++)
                {
                    grdSearch.Rows[Cnt].HeaderCell.Value = Convert.ToString(Cnt + 1);
                }
                grdSearch.RowHeadersVisible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                objEventLoging.AppErrlog("Error In AnantMatrimony.frmSearch.CalcSrNo()" + ex.ToString());
            }
        }

        private void frmSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (lblSearchType.Text == "Search Type")
                {
                    e.Handled = true;
                    return;
                }

                //if (grdSearch.RowCount == 0)
                //{
                //    //e.Handled = true;
                //    return;
                //}
                objGlobal.SingleQuoteBlock(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                objEventLoging.AppErrlog("Error In AnantMatrimony.frmSearch.frmSearch_KeyPress()" + ex.ToString());
            }
        }

        private void grdSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }




    }
}