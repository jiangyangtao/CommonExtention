﻿using CommonExtention.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="containsTableName">是否包含 <see cref="DataTable.TableName"/> </param>
        /// <returns>
        /// 如果 <see cref="DataTable"/> 为 null，则返回 <see cref="string.Empty"/>；
        /// 否则返回序列化后的 json 字符串。
        /// </returns>
        public static string ToJsonString(this DataTable dataTable, bool containsTableName = true)
        {
            if (dataTable == null || dataTable.Rows.Count <= 0) return string.Empty;

            var jsonBuilder = new StringBuilder("{");
            if (containsTableName) jsonBuilder.Append($"\"{dataTable.TableName}\":");

            jsonBuilder.Append("[");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"")
                        .Append(dataTable.Columns[j].ColumnName)
                        .Append("\":")
                        .Append(GetValueByType(dataTable.Rows[i][j]));
                    if (j != dataTable.Columns.Count - 1) jsonBuilder.Append(",");
                }
                jsonBuilder.Append("}");
                if (i != dataTable.Rows.Count - 1) jsonBuilder.Append(",");
            }
            if (jsonBuilder.ToString().Substring(jsonBuilder.Length - 1, 1) == ",") jsonBuilder.Remove(jsonBuilder.Length - 1, 1);

            jsonBuilder.Append("]}");
            return jsonBuilder.ToString();
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
                case "String": return $"\"{value.ToString().TrimStart().TrimEnd()}\"";
                case "DateTime": return $"\"{value.ToString().ToDateTime().ToFormatDateTime()}\"";
                case "Int16": return value.ToString().ToInt16();
                case "Int32": return value.ToString().ToInt();
                case "Int64": return value.ToString().ToInt64();
                case "Decimal": return value.ToString().ToDecimal();
                case "Single": return value.ToString().ToSingle();
                case "Double": return value.ToString().ToDouble();
                case "Boolean": return $"\"{value.ToString()}\"";
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
        /// <returns>如果 <see cref="DataTable"/> 为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string ToJsonArray(this DataTable dataTable) => new Serialization().SerializeDataTableToJsonArray(dataTable);
        #endregion

        #region 将当前 DataTable 对象转换为 Json 数组字符串
        /// <summary>
        /// 将当前 <see cref="DataTable"/> 对象转换为 Json 数组字符串
        /// </summary>
        /// <param name="dataTable">要转换的 <see cref="DataTable"/> </param>
        /// <param name="formatting">序列化的格式</param>
        /// <returns>如果 <see cref="DataTable"/> 为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string ToJsonArray(this DataTable dataTable, Formatting formatting) => new Serialization().SerializeDataTableToJsonArray(dataTable, formatting);
        #endregion

        #region 将当前 DataTable 对象转换为 Json 数组字符串
        /// <summary>
        /// 将当前 <see cref="DataTable"/> 对象转换为 Json 数组字符串
        /// </summary>
        /// <param name="dataTable">要转换的 <see cref="DataTable"/> </param>
        /// <param name="settings">序列化的设置</param>
        /// <returns>如果 <see cref="DataTable"/> 为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string ToJsonArray(this DataTable dataTable, JsonSerializerSettings settings) => new Serialization().SerializeDataTableToJsonArray(dataTable, settings);
        #endregion

        #region 将当前 DataTable 对象转换为 Json 数组字符串
        /// <summary>
        /// 将当前 <see cref="DataTable"/> 对象转换为 Json 数组字符串
        /// </summary>
        /// <param name="dataTable">要转换的 <see cref="DataTable"/> </param>
        /// <param name="converters">序列化时使用的转换器的集合</param>
        /// <returns>如果 <see cref="DataTable"/> 为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string ToJsonArray(this DataTable dataTable, params JsonConverter[] converters) => new Serialization().SerializeDataTableToJsonArray(dataTable, converters);
        #endregion

        #region 将当前 DataTable 对象转换为 Json 数组字符串
        /// <summary>
        /// 将当前 <see cref="DataTable"/> 对象转换为 Json 数组字符串
        /// </summary>
        /// <param name="dataTable">要转换的 <see cref="DataTable"/> </param>
        /// <param name="formatting">序列化的格式</param>
        /// <param name="settings">序列化的设置</param>
        /// <returns>如果 <see cref="DataTable"/> 为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string ToJsonArray(this DataTable dataTable, Formatting formatting, JsonSerializerSettings settings) => new Serialization().SerializeDataTableToJsonArray(dataTable, settings);
        #endregion

        #region 将当前 DataTable 对象转换为 Json 数组字符串
        /// <summary>
        /// 将当前 <see cref="DataTable"/> 对象转换为 Json 数组字符串
        /// </summary>
        /// <param name="dataTable">要转换的 <see cref="DataTable"/> </param>
        /// <param name="formatting">序列化的格式</param>
        /// <param name="converters">序列化时使用的转换器的集合</param>
        /// <returns>如果 <see cref="DataTable"/> 为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string ToJsonArray(this DataTable dataTable, Formatting formatting, params JsonConverter[] converters) => new Serialization().SerializeDataTableToJsonArray(dataTable, formatting, converters);
        #endregion

        #region 将当前 DataTable 对象转换为 Newtonsoft.Json.Linq.JObject 对象
        /// <summary>
        /// 将当前 <see cref="DataTable"/> 对象转换为 <see cref="JObject"/> 对象
        /// </summary>
        /// <param name="dt">要转换的 <see cref="DataTable"/> </param>
        /// <returns>返回 <see cref="JObject"/> 对象</returns>
        public static JObject ToJObject(this DataTable dt)
        {
            return JObject.Parse(dt.ToJsonString(false));
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

        #region 将当前 DataTable 对象转换为 List
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
                if (typeof(short) == columnType) return Convert.ToInt16(dataRow[columnName]);
                if (typeof(short?) == columnType) return dataRow[columnName].ToNullableInt16();
                if (typeof(int) == columnType) return Convert.ToInt32(dataRow[columnName]);
                if (typeof(int?) == columnType) return dataRow[columnName].ToNullableInt();
                if (typeof(long) == columnType) return Convert.ToInt64(dataRow[columnName]);
                if (typeof(long?) == columnType) return dataRow[columnName].ToNullableInt64();
                if (typeof(float) == columnType) return Convert.ToSingle(dataRow[columnName]);
                if (typeof(float?) == columnType) return dataRow[columnName].ToNullableSingle();
                if (typeof(double) == columnType) return Convert.ToInt16(dataRow[columnName]);
                if (typeof(double?) == columnType) return dataRow[columnName].ToNullableDouble();
                if (typeof(decimal) == columnType) return Convert.ToDecimal(dataRow[columnName]);
                if (typeof(decimal?) == columnType) return dataRow[columnName].ToString().ToNullableDecimal();
                if (typeof(DateTime) == columnType) return Convert.ToDateTime(dataRow[columnName]);
                if (typeof(DateTime?) == columnType) return dataRow[columnName].ToNullableDateTime();
                if (typeof(bool) == columnType) return Convert.ToBoolean(dataRow[columnName]);
                if (typeof(bool?) == columnType) return dataRow[columnName].ToNullableBoolean();
                if (typeof(Guid) == columnType) return dataRow[columnName].ToGuid();
                if (typeof(Guid?) == columnType) return dataRow[columnName].ToNullableGuid();
                if (dataRow[columnName] != null) return dataRow[columnName].ToString();
            }
            return string.Empty;
        }
        #endregion

        #region 将当前 DataTable 对象用异步方式转换为 List
        /// <summary>
        /// 将当前 <see cref="DataTable"/> 对象用异步方式转换为 <see cref="List{T}"/>
        /// </summary>
        /// <typeparam name="T">要转换的元素的类型</typeparam>
        /// <param name="dt">要转换的 <see cref="DataTable"/> </param>
        /// <returns>转换过后的 <see cref="List{T}"/> 对象</returns>
        public static async Task<List<T>> ToListAsync<T>(this DataTable dt) where T : class, new() => await Task.Run(() => dt.ToList<T>());
        #endregion

        #region 将当前 DataTable 对象转换为 ArrayList 对象
        /// <summary>
        /// 将当前 <see cref="DataTable"/> 对象转换为 <see cref="ArrayList"/> 对象
        /// </summary>
        /// <param name="dt">要转换的 <see cref="DataTable"/></param>
        /// <returns>返回 <see cref="Dictionary{String,Object}"/> 键值对的 ArrayList 对象</returns>
        public static ArrayList ToArrayList(this DataTable dt)
        {
            var arrayList = new ArrayList();
            dt.Rows.ForEach(row =>
            {
                var dictionary = new Dictionary<string, object>();
                dt.Columns.ForEach(column => dictionary.Add(column.ColumnName, row[column.ColumnName]));
                arrayList.Add(dictionary);
            });
            return arrayList;
        }
        #endregion

        #region 将当前 DataTable 对象写入 MemoryStream
        /// <summary>
        /// 将当前 <see cref="DataTable"/> 写入 <see cref="MemoryStream"/>
        /// </summary>
        /// <param name="dataTable">要写入的 <see cref="DataTable"/> 对象</param>
        /// <param name="action">用于执行写入 Excel 单元格的委托</param>
        /// <param name="sheetsName">Excel 的工作簿名称</param>
        /// <returns>Excel形式的 <see cref="MemoryStream"/> 对象</returns>
        public static MemoryStream WriteToMemoryStream(this DataTable dataTable, Action<ExcelWorksheet, DataColumnCollection, DataRowCollection> action,
            string sheetsName = "sheet1") => new Excel().WriteToMemoryStream(dataTable, action, sheetsName);
        #endregion

        #region 将当前 DataTable 对象用异步方式写入 MemoryStream
        /// <summary>
        /// 将当前 <see cref="DataTable"/> 对象用异步方式写入 <see cref="MemoryStream"/>
        /// </summary>
        /// <param name="dataTable">要写入的 <see cref="DataTable"/> 对象</param>
        /// <param name="action">用于执行写入 Excel 单元格的委托</param>
        /// <param name="sheetsName">Excel 的工作簿名称</param>
        /// <returns>Excel形式的 <see cref="MemoryStream"/> 对象</returns>
        public static async Task<MemoryStream> WriteToMemoryStreamAsync(this DataTable dataTable,
            Action<ExcelWorksheet, DataColumnCollection, DataRowCollection> action,
            string sheetsName = "sheet1") => await new Excel().WriteToMemoryStreamAsync(dataTable, action, sheetsName);
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
