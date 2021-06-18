using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minbumm.Advs.DataModel.DBCommandConfigSection
{
    public class DbCommandConfig : ConfigurationElement
    {
        public DbCommandConfig() { }
        [ConfigurationProperty("CommandID", IsRequired = true)]
        public string CommandID 
        {
            get 
            {
                return (string)this["CommandID"];
            }
            set 
            {
                this["CommandID"] = value;
            }
        }
        
        [ConfigurationProperty("Text", IsRequired = true)]
        public string Text 
        {
            get 
            {
                return (string)this["Text"];
            }
            set 
            {
                this["Text"] = value;
            }
        }

        [ConfigurationProperty("CommandType", DefaultValue = "SQL", IsRequired = true)]
        public string CommandType
        {
            get
            {
                return (string)this["CommandType"];
            }
            set
            {
                this["CommandType"] = value;
            }
        }
    }
