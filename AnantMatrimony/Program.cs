using AnantMatrimony.FORMS;
using AnantMatrimony.UD_CLASS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AnantMatrimony
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin objLogin = new frmLogin();
            objLogin.ShowDialog();
            if (Global.isLogin)
            {
                Application.Run(new frmMain());
            }
        }
    }
}
