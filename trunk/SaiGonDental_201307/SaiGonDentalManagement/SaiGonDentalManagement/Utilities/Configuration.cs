using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaiGonDentalManagement.Utilities;
using System.IO;
using System.Runtime.InteropServices;
using IniParser;

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
        }
    }
}
