using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minbumm.Advs.Win.Common
{
    public static class SqlBuilderHelper
    {
        public static string GenerateInsert(DataRow dr, string[] removeFileds) 
        {
            if (dr == null)
            {
                throw new ArgumentNullException("dataRow");
            }

            DataTable tabel = dr.Table;

            return output.ToString();
        }

    }
}
