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

            DataTable table = dr.Table;

            if (string.IsNullOrEmpty(table.TableName) || table.TableName.Trim() =="")
            {
                throw new ArgumentNullException("tablename must be set on table");
            }
            var excludeNames = new SortedList<string, string>();
            if (removeFields != null)
            {
                foreach (string removeField in removeFields)
                {
                    excludeNames.Add(removeField.ToUpper(), removeField.ToUpper());
                }
            }

            var names = new List<string>();
            foreach (DataColumn col in table.Columns)
            {
                if (!excludeNames.ContainsKey(col.ColumnName.ToUpper()))
                {
                    names.Add("[" + col.ColumnName + "]");
                }
            }

            var output = new StringBuilder();

            output.AppendFormat("INSERT INTO [Sales].[{0}]\n\t({1})\nVALUES ", table.TableName, string.Join(", ", names.ToArray()));

            output.Append("\t(");

            output.Append(GetInsertColumnValues(table, dr, excludeNames));

            output.Append(")");



            return output.ToString();
        }

    }
}
