using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CommonExtention.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommonExtention.Extensions
{
    /// <summary>
    /// <see cref="DataTable"/> 扩展
    /// </summary>
    public static class DataTableExtensions
    {
        #region 将当前 DataTable 对象转换为 Json 字符串
        /// <summary>
        /// 将当前 <see cref="DataTable"/> 对象转换为 Json 字符串
        /// </summary>
        /// <param name="dataTable">要转换的 <see cref="DataTable"/> </param>
        /// <returns>如果 <see cref="DataTable"/> 为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串，包含 TableName。</returns>
        public static string ToJsonString(this DataTable dataTable)
        {
            var jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{\"" + dataTable.TableName + "\":[");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dataTable.Columns[j].ColumnName);
                    jsonBuilder.Append("\":");
                    jsonBuilder.Append(GetValueByType(dataTable.Rows[i][j]));
                    if (j != dataTable.Columns.Count - 1) jsonBuilder.Append(",");
                }
                jsonBuilder.Append("},");
            }
            if (jsonBuilder.ToString().Substring(jsonBuilder.Length - 1, 1) == ",") jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]}");
            return jsonBuilder.ToString();
        }
        #endregion

        #region 将当前 DataTable 对象转换为 Json 数组字符串
        /// <summary>
        /// 将当前 <see cref="DataTable"/> 对象转换为 Json 数组字符串
        /// </summary>
        /// <param name="dataTable">要转换的 <see cref="DataTable"/> </param>
        /// <returns>如果 <see cref="DataTable"/> 为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string ToJsonArray(this DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows.Count <= 0) return string.Empty;

            var jsonBuilder = new StringBuilder("{");
            if (dataTable.TableName.NotNullAndEmpty()) jsonBuilder.Append("\"" + dataTable.TableName + "\":");

            jsonBuilder.Append("[");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dataTable.Columns[j].ColumnName);
                    jsonBuilder.Append("\":");
                    jsonBuilder.Append(GetValueByType(dataTable.Rows[i][j]));
                    if (j != dataTable.Columns.Count - 1) jsonBuilder.Append(",");
                }
                jsonBuilder.Append("}");
                if (i != dataTable.Rows.Count - 1) jsonBuilder.Append(",");
            }
            jsonBuilder.Append("]");
            var _json = jsonBuilder.ToString();
            if (_json.Substring(_json.Length - 1, 1) == ",") _json = _json.Substring(0, _json.Length - 1);
            return _json;
        }

        /// <summary>
        /// 根据类型返回相应的对象
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>object</returns>
        private static object GetValueByType(object value)
        {
            if (value == null) return string.Empty;
            var _type = value.GetType().Name;
            switch (_type)
            {
                case "String": return "\"" + value.ToString().TrimStart().TrimEnd() + "\"";
                case "DateTime": return "\"" + value.ToString().ToDateTime().ToFormatDateTime() + "\"";
                case "Int16": return value.ToString().ToInt16();
                case "Int32": return value.ToString().ToInt();
                case "Int64": return value.ToString().ToInt64();
                case "Decimal": return value.ToString().ToDecimal();
                case "Single": return value.ToString().ToSingle();
                case "Double": return value.ToString().ToDouble();
                case "Boolean": return "\"" + value.ToString() + "\"";
                case "DBNull": return string.Empty;
            }
            return value.ToString();
        }
        #endregion

        #region 将当前 DataTable 对象转换为 Json 数组字符串
        /// <summary>
        /// 将当前 <see cref="DataTable"/> 对象转换为 Json 数组字符串
        /// </summary>
        /// <param name="dataTable">要转换的 <see cref="DataTable"/> </param>
        /// <param name="formatting">序列化的格式</param>
        /// <returns>如果 <see cref="DataTable"/> 为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string ToJsonArray(this DataTable dataTable, Formatting formatting) => Serialization.SerializeDataTableToJsonArray(dataTable, formatting);
        #endregion

        #region 将当前 DataTable 对象转换为 Json 数组字符串
        /// <summary>
        /// 将当前 <see cref="DataTable"/> 对象转换为 Json 数组字符串
        /// </summary>
        /// <param name="dataTable">要转换的 <see cref="DataTable"/> </param>
        /// <param name="settings">序列化的设置</param>
        /// <returns>如果 <see cref="DataTable"/> 为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string ToJsonArray(this DataTable dataTable, JsonSerializerSettings settings) => Serialization.SerializeDataTableToJsonArray(dataTable, settings);
        #endregion

        #region 将当前 DataTable 对象转换为 Json 数组字符串
        /// <summary>
        /// 将当前 <see cref="DataTable"/> 对象转换为 Json 数组字符串
        /// </summary>
        /// <param name="dataTable">要转换的 <see cref="DataTable"/> </param>
        /// <param name="converters">序列化时使用的转换器的集合</param>
        /// <returns>如果 <see cref="DataTable"/> 为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string ToJsonArray(this DataTable dataTable, params JsonConverter[] converters) => Serialization.SerializeDataTableToJsonArray(dataTable, converters);
        #endregion

        #region 将当前 DataTable 对象转换为 Json 数组字符串
        /// <summary>
        /// 将当前 <see cref="DataTable"/> 对象转换为 Json 数组字符串
        /// </summary>
        /// <param name="dataTable">要转换的 <see cref="DataTable"/> </param>
        /// <param name="formatting">序列化的格式</param>
        /// <param name="settings">序列化的设置</param>
        /// <returns>如果 <see cref="DataTable"/> 为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string ToJsonArray(this DataTable dataTable, Formatting formatting, JsonSerializerSettings settings) => Serialization.SerializeDataTableToJsonArray(dataTable, settings);
        #endregion

        #region 将当前 DataTable 对象转换为 Json 数组字符串
        /// <summary>
        /// 将当前 <see cref="DataTable"/> 对象转换为 Json 数组字符串
        /// </summary>
        /// <param name="dataTable">要转换的 <see cref="DataTable"/> </param>
        /// <param name="formatting">序列化的格式</param>
        /// <param name="converters">序列化时使用的转换器的集合</param>
        /// <returns>如果 <see cref="DataTable"/> 为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string ToJsonArray(this DataTable dataTable, Formatting formatting, params JsonConverter[] converters) => Serialization.SerializeDataTableToJsonArray(dataTable, formatting, converters);
        #endregion

        #region 将当前 DataTable 对象转换为 Newtonsoft.Json.Linq.JObject 对象
        /// <summary>
        /// 将当前 <see cref="DataTable"/> 对象转换为 <see cref="JObject"/> 对象
        /// </summary>
        /// <param name="dt">要转换的 <see cref="DataTable"/> </param>
        /// <returns>返回 <see cref="JObject"/> 对象</returns>
        public static JObject ToJObject(this DataTable dt)
        {
            return JObject.Parse(dt.ToJsonString());
        }
        #endregion

        #region 将当前 DataTable 对象转换为 Newtonsoft.Json.Linq.JArray 对象
        /// <summary>
        /// 将当前 <see cref="DataTable"/> 对象转换为 <see cref="JArray"/> 对象
        /// </summary>
        /// <param name="dt">要转换的 <see cref="DataTable"/> </param>
        /// <returns>返回 <see cref="JArray"/> 对象</returns>
        public static JArray ToJArray(this DataTable dt)
        {
            return JArray.Parse(dt.ToJsonArray());
        }
        #endregion

        #region 将当前 DataTable 对象转换为 List 对象
        /// <summary>
        /// 将当前 <see cref="DataTable"/> 对象转换为 <see cref="List{T}"/> 对象
        /// </summary>
        /// <typeparam name="T">要转换的元素的类型</typeparam>
        /// <param name="dt">要转换的 <see cref="DataTable"/> </param>
        /// <returns>转换过后的 <see cref="List{T}"/> 对象</returns>
        public static List<T> ToList<T>(this DataTable dt) where T : class, new()
        {
            List<T> list = new List<T>();
            if (dt == null || dt.Rows.Count <= 0) return list;

            var type = typeof(T);
            var properties = type.GetProperties();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                T model = new T();
                foreach (var item in properties)
                {
                    string itemStr = item.Name;
                    var itemType = item.PropertyType;
                    object value = GetDataRowValue(itemStr, itemType, dt.Rows[i]);
                    item.SetValue(model, value, null);
                }
                list.Add(model);
            }
            return list;
        }

        /// <summary>
        ///  根据Type在DataRow中获取对应的column值
        /// </summary>
        /// <param name="columnName">列名称</param>
        /// <param name="columnType">列的类型</param>
        /// <param name="dataRow">DataRow 集合</param>
        /// <returns>列值</returns>
        private static object GetDataRowValue(string columnName, Type columnType, DataRow dataRow)
        {
            if (dataRow.Table.Columns.Contains(columnName))
            {
                if (typeof(string) == columnType) return dataRow[columnName].ToString();
                if (typeof(short) == columnType) return dataRow[columnName].ToString().ToInt16();
                if (typeof(short?) == columnType) return dataRow[columnName].ToString().ToNullableInt16();
                if (typeof(int) == columnType) return dataRow[columnName].ToString().ToInt();
                if (typeof(int?) == columnType) return dataRow[columnName].ToString().ToNullableInt();
                if (typeof(long) == columnType) return dataRow[columnName].ToString().ToInt64();
                if (typeof(long?) == columnType) return dataRow[columnName].ToString().ToNullableInt64();
                if (typeof(float) == columnType) return dataRow[columnName].ToString().ToSingle();
                if (typeof(float?) == columnType) return dataRow[columnName].ToString().ToNullableSingle();
                if (typeof(double) == columnType) return dataRow[columnName].ToString().ToDouble();
                if (typeof(double?) == columnType) return dataRow[columnName].ToString().ToNullableDouble();
                if (typeof(decimal) == columnType) return dataRow[columnName].ToString().ToDecimal();
                if (typeof(decimal?) == columnType) return dataRow[columnName].ToString().ToNullableDecimal();
                if (typeof(DateTime) == columnType) return dataRow[columnName].IsNullOrEmpty() ? DateTime.MinValue : DateTime.Parse(dataRow[columnName].ToString());
                if (typeof(DateTime?) == columnType) return dataRow[columnName].ToString().ToNullableDateTime();
                if (typeof(bool) == columnType) return dataRow[columnName].ToString().ToBoolean();
                if (typeof(bool?) == columnType) return dataRow[columnName].ToString().ToNullableBoolean();
                if (typeof(Guid) == columnType) return dataRow[columnName].ToString().ToGuid();
                if (typeof(Guid?) == columnType) return dataRow[columnName].ToString().ToNullableGuid();
                if (dataRow[columnName] != null) return dataRow[columnName].ToString();
            }
            return string.Empty;
        }
        #endregion

        #region 将当前 DataTable 对象转换为 ArrayList 对象
        /// <summary>
        /// 将当前DataTable对象转换为 ArrayList 对象
        /// </summary>
        /// <param name="dt">要转换的DataTable</param>
        /// <returns>返回Dictionary键值对的 ArrayList 对象</returns>
        public static ArrayList ToArrayList(this DataTable dt)
        {
            var arrayList = new ArrayList();
            foreach (DataRow dataRow in dt.Rows)
            {
                var dictionary = new Dictionary<string, object>();
                foreach (DataColumn dataColumn in dt.Columns)
                {
                    dictionary.Add(dataColumn.ColumnName, dataRow[dataColumn.ColumnName].ToString());
                }
                arrayList.Add(dictionary);
            }
            return arrayList;
        }
        #endregion

        #region 清除当前 DataTable 对象的空行
        /// <summary>
        /// 清除当前DataTable对象的空行
        /// </summary>
        /// <param name="dt">要清除空行的DataTable</param>
        /// <returns>返回清除空行后的DataTable。</returns>
        public static DataTable ClearEmptyRow(this DataTable dt)
        {
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                var emptyColumnCount = 0;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    var item = dt.Rows[i][j].ToString();
                    if (!string.IsNullOrEmpty(item)) break;
                    else emptyColumnCount++;
                }

                if (emptyColumnCount == dt.Columns.Count) dt.Rows.RemoveAt(i);
            }
            return dt;
        }
        #endregion
    }
}
