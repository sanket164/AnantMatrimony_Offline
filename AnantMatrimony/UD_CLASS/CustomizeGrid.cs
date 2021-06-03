using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AnantMatrimony.UD_CLASS;

namespace AnantMatrimony
{
    class CustomizeGrid : System.Windows.Forms.DataGridView
    {
        EventLogging objEventLoging = new EventLogging();

        protected override bool ProcessDialogKey(Keys keyData)
        {
            try
            {

                if (this.RowCount > 0)
                {
                    CommitEdit(DataGridViewDataErrorContexts.Commit);
                    EndEdit();

                    if (this.CurrentCell.ColumnIndex == (this.Columns.Count - 2) && this.CurrentCell.RowIndex == (this.Rows.Count - 1))
                    {
                        if (this[0, this.CurrentCell.RowIndex].Value != null)
                        {
                            if (this[0, this.CurrentCell.RowIndex].Value.ToString() != "")
                            {
                                //if (keyData == Keys.Enter)
                                //{
                                //    this.Rows.Add();
                                //}
                                this.Rows.Add();
                            }
                        }
                    }

                    if (this.CurrentCell.ColumnIndex <= this.Columns.Count - 1)
                    {

                        if (keyData == Keys.Enter)
                        {
                            this.Focus();
                            if (!Global.IsDateErr)
                            {
                                return this.ProcessDialogKey(Keys.Tab);
                            }
                            else
                            {
                                return this.ProcessDialogKey(Keys.Up);
                            }

                        }
                        if (keyData == Keys.Escape)
                        {

                            if (!Global.IsDateErr)
                            {
                                this.GetNextControl(this.Parent, true).Focus();
                            }

                        }
                        if (keyData == Keys.Tab)
                        {
                            if (!Global.IsDateErr)
                            {
                                this.Focus();
                            }
                            else if (Global.IsDate(Global.GridDate) || Global.GridDate == "")
                            {
                                this.Focus();
                            }

                        }


                    }
                }

                if (Global.IsDateErr)
                {
                    if ((int)keyData >= 96 && (int)keyData <= 105)
                    {
                        return base.ProcessDialogKey(keyData);
                    }
                    else if (keyData == Keys.F7 || keyData == Keys.Escape || keyData == Keys.F5 || keyData == Keys.Back || keyData == Keys.Delete)
                    {
                        return base.ProcessDialogKey(keyData);
                    }
                    else
                    {

                        //return false;
                        return base.ProcessDialogKey(Keys.Up);
                    }

                }
                else
                {

                    return base.ProcessDialogKey(keyData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In DyeingProject.GridClass.ProcessDialogKey()" + ex.ToString());
            }
            return base.ProcessDialogKey(keyData);
        }







    }
}
