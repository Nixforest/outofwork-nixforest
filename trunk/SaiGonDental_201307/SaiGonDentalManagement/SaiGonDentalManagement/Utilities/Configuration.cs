using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaiGonDentalManagement.Utilities;
using System.IO;
using System.Runtime.InteropServices;
using IniParser;
using System.Windows.Forms;
using System.Diagnostics;

namespace SaiGonDentalManagement.Utilities
{
    /// <summary>
    /// Class for configuration handle
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// Load setting values in configuration file
        /// </summary>
        public static void LoadSettingValues()
        {
            // Load configuration file
            FileIniDataParser paser = new FileIniDataParser();
            IniData iniFile = paser.LoadFile(GlobalVariable.CONFIG_FILE_PATH);
            // Load Log file path
            GlobalVariable.LOG_FILE_PATH = Path.Combine(
                System.Environment.CurrentDirectory,
                iniFile[GlobalVariable.SECTION_LOG][GlobalVariable.KEY_FILE_PATH]);
            // Load Customer Id View
            string view =
                iniFile[GlobalVariable.SECTION_APPLICATION]
                [GlobalVariable.KEY_CUSTOMER_ID_VIEW];
            try
            {
                GlobalVariable.CUSTOMER_ID_VIEW = UInt16.Parse(view);
            }
            catch (ArgumentNullException)
            {
                LogManagement.WriteMessage(String.Format(GlobalVariable.ERR_LOAD_CONFIG_FILE_ARGU_NULL_EXCEPTION,
                        GlobalVariable.SECTION_APPLICATION,
                        GlobalVariable.KEY_CUSTOMER_ID_VIEW),
                    new StackTrace(new StackFrame(true)));
                MessageBox.Show(String.Format(GlobalVariable.ERR_LOAD_CONFIG_FILE_ARGU_NULL_EXCEPTION,
                        GlobalVariable.SECTION_APPLICATION,
                        GlobalVariable.KEY_CUSTOMER_ID_VIEW),
                    GlobalVariable.ERR_ERROR,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                LogManagement.WriteMessage(String.Format(GlobalVariable.ERR_LOAD_CONFIG_FILE_FORMAT_EXCEPTION,
                        GlobalVariable.SECTION_APPLICATION,
                        GlobalVariable.KEY_CUSTOMER_ID_VIEW),
                    new StackTrace(new StackFrame(true)));
                MessageBox.Show(String.Format(GlobalVariable.ERR_LOAD_CONFIG_FILE_FORMAT_EXCEPTION,
                        GlobalVariable.SECTION_APPLICATION,
                        GlobalVariable.KEY_CUSTOMER_ID_VIEW),
                    GlobalVariable.ERR_ERROR,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (OverflowException)
            {
                LogManagement.WriteMessage(String.Format(GlobalVariable.ERR_LOAD_CONFIG_FILE_UINT_OVERFLOW_EXCEPTION,
                        GlobalVariable.SECTION_APPLICATION,
                        GlobalVariable.KEY_CUSTOMER_ID_VIEW),
                    new StackTrace(new StackFrame(true)));
                MessageBox.Show(String.Format(GlobalVariable.ERR_LOAD_CONFIG_FILE_UINT_OVERFLOW_EXCEPTION,
                        GlobalVariable.SECTION_APPLICATION,
                        GlobalVariable.KEY_CUSTOMER_ID_VIEW),
                    GlobalVariable.ERR_ERROR,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            // Load Customer Id header
            GlobalVariable.CUSTOMER_ID_HEADER =
                iniFile[GlobalVariable.SECTION_APPLICATION]
                [GlobalVariable.KEY_CUSTOMER_ID_HEADER];
        }
    }
}
