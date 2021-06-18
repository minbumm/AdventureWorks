using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minbumm.Advs.DataModel.DBCommandConfigSection
{
    public class DbCommandConfigCollection : ConfigurationElementCollection
    {
        public DbCommandConfigCollection() 
        {
            
        }
        public DbCommandConfig this[int index] 
        {
            get { return (DbCommandConfig)BaseGet(index); }
            set 
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public DbCommandConfig GetElement(string key) 
        {
            return (DbCommandConfig)BaseGet(key);
        }
        public void Clear() 
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new DbCommandConfig();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DbCommandConfig)element).CommandID;
        }

        public void Remove(DbCommandConfig dbCommandConfig)
        {
            BaseRemove(dbCommandConfig.CommandID);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }
    }
}
