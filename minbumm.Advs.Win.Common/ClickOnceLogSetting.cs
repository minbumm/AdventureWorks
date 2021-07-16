using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minbumm.Advs.Win.Common
{
    public class ClickOnceLogSetting
    {
        //This is where the values go for the ClickOnce logging, in HKEY_Current_User.
        const string CLICKONCE_LOGGING_SUBKEYNAME =
        @"Software\Classes\Software\Microsoft\Windows\CurrentVersion\Deployment";

        /// <summary>
        ///This is the registry value name for the log file path. 
        ///The value should be the fully-qualified path and file name of the log file.
        /// </summary>
        const string LOGFILEPATH_KEYNAME = "LogFilePath";

        /// <summary>
        /// This is the registry value name for the logging level. 
        /// The value should be = 1 if you want verbose logging. 
        /// To turn off verbose logging, you can delete the entry or set it to 0.
        /// </summary>
        const string LOGVERBOSITYLEVEL_KEYNAME = "LogVerbosityLevel";

        /// <summary>
        /// Fully-qualified path and name of the log file.
        /// </summary>
        public string LogFileLocation { get; set; }

        /// <summary>
        /// Set this to 1 for verbose logging.
        /// </summary>
        public int LogVerbosityLevel { get; set; }

        /// <summary>
        /// Set to true if doing verbose logging.
        /// </summary>
        public bool VerboseLogging { get; set; }

        /// <summary>
        /// Create a new instance of this class and get the value for the registry entries (if found).
        /// </summary>
        /// <returns>An instance of this class.</returns>
        public static ClickOnceLogSetting Create()
        {
            ClickOnceLogSetting clickOnceLogSetting = new ClickOnceLogSetting();

            //open the Deployment sub-key.
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(CLICKONCE_LOGGING_SUBKEYNAME);

            //get the values currently saved (if they exist) and set the fields on the screen accordingly
            string logLevel = rk.GetValue(LOGVERBOSITYLEVEL_KEYNAME, string.Empty).ToString();
            if (logLevel == "1")
            {
                clickOnceLogSetting.VerboseLogging = true;
                clickOnceLogSetting.LogVerbosityLevel = 1;
            }
            else
            {
                clickOnceLogSetting.VerboseLogging = false;
                clickOnceLogSetting.LogVerbosityLevel = 0;
            }

            clickOnceLogSetting.LogFileLocation = rk.GetValue(LOGFILEPATH_KEYNAME, string.Empty).ToString();
            return clickOnceLogSetting;
        }

        /// <summary>
        /// Save the values to the registry.
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            bool success = false;
            try
            {
                //Open the Deployment sub-key.
                RegistryKey rk = Registry.CurrentUser.OpenSubKey(CLICKONCE_LOGGING_SUBKEYNAME, true);
                //Set the values associated with that sub-key.
                if (this.VerboseLogging)
                    rk.SetValue(LOGVERBOSITYLEVEL_KEYNAME, "1");
                else
                {
                    //check to make sure the [value] exists before trying to delete it 
                    object chkVal = rk.GetValue(LOGVERBOSITYLEVEL_KEYNAME);
                    if (chkVal != null)
                    {
                        rk.DeleteValue(LOGVERBOSITYLEVEL_KEYNAME);
                    }
                }

                if (this.LogFileLocation == null || this.LogFileLocation.Length == 0)
                {
                    //check to make sure the [value] exists before trying to delete it 
                    //Note: If you set the values to string.Empty instead of deleting it,
                    //  it will crash the dfsvc.exe service.
                    object chkPath = rk.GetValue(LOGFILEPATH_KEYNAME);
                    if (chkPath != null)
                        rk.DeleteValue(LOGFILEPATH_KEYNAME);
                }
                else
                {
                    rk.SetValue(LOGFILEPATH_KEYNAME, this.LogFileLocation);
                    string logFolder = Path.GetDirectoryName(this.LogFileLocation);
                    if (!Directory.Exists(logFolder))
                        Directory.CreateDirectory(logFolder);
                }
                success = true;
            }
            catch
            {
                throw;
            }
            return success;
        }
    }
}
}
