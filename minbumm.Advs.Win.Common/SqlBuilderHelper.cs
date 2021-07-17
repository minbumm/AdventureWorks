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
        #region Public Methods


        public static string GenerateInsert(DataRow dr, string[] removeFields)
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

        /// <summary>
        /// Gets the column values list for an Update statement
        /// </summary>
        /// <param name="table">The table</param>
        /// <param name="row">a data row</param>
        /// <param name="excludeNames">A list of fields to be excluded</param>
        /// <returns></returns>
        public static string GetUpdateColumnValues(DataTable table, DataRow row, SortedList<string, string> excludeNames)
        {
            var output = new StringBuilder();

            bool firstColumn = true;

            foreach (DataColumn col in table.Columns)
            {
                if (!excludeNames.ContainsKey(col.ColumnName.ToUpper()))
                {
                    if (firstColumn)
                    {
                        firstColumn = false;
                    }
                    else
                    {
                        output.Append(", ");
                    }

                    output.AppendFormat("{0}={1}", col.ColumnName, GetColumnValue(row, col));
                }
            }

            return output.ToString();
        }


        /// <summary>
        /// Gets the column values list for an insert statement
        /// </summary>
        /// <param name="table">The table</param>
        /// <param name="row">a data row</param>
        /// <param name="excludeNames">A list of fields to be excluded</param>
        /// <returns></returns>
        public static string GetInsertColumnValues(DataTable table, DataRow row, SortedList<string, string> excludeNames)
        {
            var output = new StringBuilder();

            bool firstColumn = true;

            foreach (DataColumn col in table.Columns)
            {
                if (!excludeNames.ContainsKey(col.ColumnName.ToUpper()))
                {
                    if (firstColumn)
                    {
                        firstColumn = false;
                    }
                    else
                    {
                        output.Append(", ");
                    }

                    output.Append(GetColumnValue(row, col));
                }
            }

            return output.ToString();
        }

        /// <summary>
        /// Gets the insert column value, adding quotes and handling special formats
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column</param>
        /// <returns></returns>
        public static string GetColumnValue(DataRow row, DataColumn column)
        {
            string output = "";

            if (row[column.ColumnName] == DBNull.Value)
            {
                output = "NULL";
            }
            else
            {
                if (column.DataType == typeof(bool))
                {
                    output = (bool)row[column.ColumnName] ? "1" : "0";
                }
                else
                {
                    //bool addQuotes = false;
                    //addQuotes = addQuotes || (column.DataType == typeof(string));
                    //addQuotes = addQuotes || (column.DataType == typeof(DateTime));

                    if (column.DataType == typeof(string))
                    {
                        output = "N'" + row[column.ColumnName].ToString() + "'";
                    }
                    else if (column.DataType == typeof(DateTime))
                    {
                        output = "CAST('" + ((DateTime)row[column.ColumnName]).ToString("yyyy-MM-dd hh:mm:ss") + "' AS DATETIME)";
                    }
                    else
                    {
                        output = row[column.ColumnName].ToString();
                    }
                }
            }

            return output;
        }

        #endregion Public Methods
    }

}
