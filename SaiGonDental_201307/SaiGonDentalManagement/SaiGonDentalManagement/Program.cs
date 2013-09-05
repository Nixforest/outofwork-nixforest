using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SaiGonDentalManagement.Utilities;
using System.IO;
using System.Diagnostics;
using SaiGonDentalManagement.BusinessLogic;

namespace SaiGonDentalManagement
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
            // -----Initialize for application-----
            // Check configuration file
            GlobalVariable.CONFIG_FILE_PATH = Path.Combine(
                System.Environment.CurrentDirectory,
                GlobalVariable.CONFIG_FILE_PATH);
            if (!File.Exists(GlobalVariable.CONFIG_FILE_PATH))
            {
                MessageBox.Show(GlobalVariable.ERR_LOAD_CONFIG_FILE,
                    GlobalVariable.ERR_ERROR,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                // Load setting values
                Configuration.LoadSettingValues();
                Application.Run(new MainForm());
            }
        }
    }
}
