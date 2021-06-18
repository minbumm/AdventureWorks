using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minbumm.Advs.DataModel.DBCommandConfigSection
{
    public class DbCommandConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("DbCommandConfigs")]
        [ConfigurationCollection(typeof(DbCommandConfigCollection),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public DbCommandConfigCollection DbCommandConfigs
        {
            get
            {
                return (DbCommandConfigCollection)base["DbCommandConfigs"];
            }
        }
    }
}
