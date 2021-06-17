using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace minbumm.Advs.Win.Common
{
    public class ConfigManager
    {
        public static ConfigManager OpenConfiguration(string configPath)
        {
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap()
            {
                ExeConfigFilename = configPath
            };
            return ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
        }

        public static ConnectionStringSettingsCollection GetConnectionStringSettings(string configFilePath)
        {
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = configFilePath;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);

            if (config.ConnectionStrings != null)
            {
                return config.ConnectionStrings.ConnectionStrings;
            }

            return null;
        }

        public static DbCommandConfigCollection GetDbCommandCollection(string configFilePath)
        {
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = configFilePath;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);

            DbCommandConfigSection dbCommandConfigSection = config.GetSection("DbCommandConfigSection") as DbCommandConfigSection;
            if (dbCommandConfigSection != null)
            {
                return dbCommandConfigSection.DbCommandConfigs;
            }

            return null;

        }

    }    
}


