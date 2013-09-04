using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaiGonDentalManagement.Utilities
{
    /// <summary>
    /// Class Global Variable
    /// </summary>
    public class GlobalVariable
    {
        #region Config value
        /// <summary>
        /// Connection string for SaiGonDental database
        /// </summary>
        public static string CONNECTION_STRING =
            "Data Source=.\\SQLEXPRESS;Initial Catalog=SaiGonDental;Integrated Security=True";

        /// <summary>
        /// Data context for SaiGonDental database
        /// </summary>
        public static DataAccess.Database_ConnectionDataContext DATA_CONTEXT =
            new DataAccess.Database_ConnectionDataContext(CONNECTION_STRING);

        /// <summary>
        /// File path of Log file
        /// </summary>
        public static string LOG_FILE_PATH = "C:\\saigondental_log.txt";

        /// <summary>
        /// File path of Configuration file
        /// </summary>
        public static string CONFIG_FILE_PATH = "saigondental_config.ini";

        /// <summary>
        /// Log section name
        /// </summary>
        public static string SECTION_LOG = "Log";

        /// <summary>
        /// FilePath key
        /// </summary>
        public static string KEY_FILE_PATH = "FilePath";

        /// <summary>
        /// Application section name
        /// </summary>
        public static string SECTION_APPLICATION = "Application";

        /// <summary>
        /// Customer Id View key
        /// </summary>
        public static string KEY_CUSTOMER_ID_VIEW = "CustomerIDView";
        
        /// <summary>
        /// Customer Id Header
        /// </summary>
        public static string KEY_CUSTOMER_ID_HEADER = "CustomerIdHeader";

        /// <summary>
        /// Date time format to log file
        /// </summary>
        public static string DATE_TIME_FORMAT = "{0:yyyy/MM/dd HH:mm:ss}";

        /// <summary>
        /// Log content format
        /// </summary>
        public static string LOG_CONTENT_FORMAT = "[{0, -20}][{1, -50}][{2, -50}][{3, 6}] {4}";
        #endregion

        #region Global String
        /// <summary>
        /// Error string
        /// </summary>
        public static string ERR_ERROR = "Error";

        /// <summary>
        /// Invalid Id string
        /// </summary>
        public static string INVALID_ID = "Id is invalid";

        /// <summary>
        /// String: Id of City is invalid
        /// </summary>
        public static string INVALID_ID_CITY = "Id of City is invalid";

        /// <summary>
        /// String: Id of District is invalid
        /// </summary>
        public static string INVALID_ID_DISTRICT = "Id of District is invalid";

        /// <summary>
        /// String: Id of Ward is invalid
        /// </summary>
        public static string INVALID_ID_WARD = "Id of Ward is invalid";

        /// <summary>
        /// String: Id of Street is invalid
        /// </summary>
        public static string INVALID_ID_STREET = "Id of Street is invalid";

        /// <summary>
        /// String: Id of District Detail is invalid
        /// </summary>
        public static string INVALID_ID_DISTRICT_DETAIL = "Id of District Detail is invalid";

        /// <summary>
        /// String: Id of Job is invalid
        /// </summary>
        public static string INVALID_ID_JOB = "Id of Job is invalid";

        /// <summary>
        /// String: Id of Know Reason is invalid
        /// </summary>
        public static string INVALID_ID_KNOW_REASON = "Id of Know Reason is invalid";

        /// <summary>
        /// String: Id of Disease Before is invalid
        /// </summary>
        public static string INVALID_ID_DISEASE_BEFORE = "Id of Disease Before is invalid";

        /// <summary>
        /// String: Id of Treatment Plan is invalid
        /// </summary>
        public static string INVALID_ID_TREATMENT_PLAN = "Id of Treatment Plan is invalid";

        /// <summary>
        /// String: Id of Branch is invalid
        /// </summary>
        public static string INVALID_ID_BRANCH = "Id of Branch is invalid";

        /// <summary>
        /// String: Id of Street is invalid: Not in District
        /// </summary>
        public static string INVALID_ID_STREET_NOT_IN_DISTRICT = "Id of Street is invalid: Not in District";

        /// <summary>
        /// String: Id of Academic is invalid
        /// </summary>
        public static string INVALID_ID_ACADEMIC = "Id of Academic is invalid";

        /// <summary>
        /// String: Id of Department is invalid
        /// </summary>
        public static string INVALID_ID_DEPARTMENT = "Id of Department is invalid";

        /// <summary>
        /// String: Id of Group is invalid
        /// </summary>
        public static string INVALID_ID_GROUP = "Id of Group is invalid";

        /// <summary>
        /// String: Id of Rule is invalid
        /// </summary>
        public static string INVALID_ID_RULE = "Id of Rule is invalid";

        /// <summary>
        /// String: Id of Group Detail is invalid
        /// </summary>
        public static string INVALID_ID_GROUP_DETAIL = "Id of Group Detail is invalid";

        /// <summary>
        /// String: Id of Customer is invalid
        /// </summary>
        public static string INVALID_ID_CUSTOMER = "Id of Customer is invalid";

        /// <summary>
        /// Load config file error
        /// </summary>
        public static string ERR_LOAD_CONFIG_FILE = "Load configuration file error";
        
        /// <summary>
        /// Load log file error: Unanthorized
        /// </summary>
        public static string ERR_LOAD_LOG_FILE_UNAUTHORIZED = "Load configuration file error: Can not access";
        
        /// <summary>
        /// Load log file error: Directory not found
        /// </summary>
        public static string ERR_LOAD_LOG_FILE_DIRECTORY_NOT_FOUND = "Load configuration file error: Directory not found";

        /// <summary>
        /// Load log file error: Path too long
        /// </summary>
        public static string ERR_LOAD_LOG_FILE_PATH_TOO_LONG = "Load configuration file error: Path too long";

        /// <summary>
        /// Id of Customer Header
        /// BN + YYMMDD + View
        /// </summary>
        public static string CUSTOMER_ID_HEADER = "BN";

        /// <summary>
        /// Id of Customer View
        /// BN + YYMMDD + View
        /// </summary>
        public static string CUSTOMER_ID_VIEW = "0";
        #endregion
    }
}
