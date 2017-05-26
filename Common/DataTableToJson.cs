using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Common
{
    public static class DataTableToJsonHelper
    {
        /// <summary>
        /// 把DataTable里的数据转换成Json数据格式
        /// </summary>
        /// <param name="table">DataTable</param>
        /// <returns>string</returns>
        public static string DataTableToJson(DataTable table)
        {
            var JsonString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                JsonString.Append("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    JsonString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        JsonString.Append("}");
                    }
                    else
                    {
                        JsonString.Append("},");
                    }
                }
                JsonString.Append("]");
            }
            return JsonString.ToString();
        }

        /// <summary>
        /// 把DataTable里的数据转换成Json数据格式
        /// </summary>
        /// <param name="table">DataTable</param>
        /// <returns>string</returns>
        public static string DataTableToJsonAll(DataTable table, int total, int columnnum)
        {
            var JsonString = new StringBuilder();
            //if (total != 0)
            //{
            JsonString.Append("{");
            JsonString.Append("\"total\":" + total + ",");
            if (columnnum != 0)
            {
                JsonString.Append("\"columnnum\":" + columnnum + ",");
                JsonString.Append("\"columns\":[");
                for (int c = 0; c < table.Columns.Count; c++)
                {
                    if (c < table.Columns.Count - 1)
                    {
                        JsonString.Append("{");
                        JsonString.Append("\"field\":\"" + table.Columns[c].ColumnName.ToString() + "\",\"title\":\"" + table.Columns[c].ColumnName.ToString() + "\"");
                        JsonString.Append("},");
                    }
                    else if (c == table.Columns.Count - 1)
                    {
                        JsonString.Append("{");
                        JsonString.Append("\"field\":\"" + table.Columns[c].ColumnName.ToString() + "\",\"title\":\"" + table.Columns[c].ColumnName.ToString() + "\"");
                        JsonString.Append("}");
                    }
                }
                JsonString.Append("],");
            }
            //}
            //if (table.Rows.Count > 0)
            //{
            JsonString.Append("\"rows\":[");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                JsonString.Append("{");
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    if (j < table.Columns.Count - 1)
                    {
                        JsonString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                    }
                    else if (j == table.Columns.Count - 1)
                    {
                        JsonString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                    }
                }
                if (i == table.Rows.Count - 1)
                {
                    JsonString.Append("}");
                }
                else
                {
                    JsonString.Append("},");
                }
            }
            JsonString.Append("]");
            //if (total != 0)
            //{
            JsonString.Append("}");
            //}
            //}
            return JsonString.ToString();
        }
    }
}
