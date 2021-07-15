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

        public static string GenerateUpdate(DataRow dr, string[] removeFields)
        {
            if (dr == null)
            {
                throw new ArgumentNullException("dataRow");
            }

            DataTable table = dr.Table;

            if (string.IsNullOrEmpty(table.TableName) || table.TableName.Trim() == "")
            {
                throw new ArgumentException("tablename must be set on table");
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

            output.AppendFormat("UPDATE [Sales].[{0}]\n\t SET ", table.TableName);

            output.Append(GetUpdateColumnValues(table, dr, excludeNames));

            output.AppendFormat("\n\t Where {0}", dr["wh"].ToString());


            return output.ToString();
        }

    }
}
