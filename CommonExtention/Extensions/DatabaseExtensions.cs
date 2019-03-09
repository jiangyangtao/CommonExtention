using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;

namespace CommonExtention.Extensions
{
    /// <summary>
    /// <see cref="Database"/> 扩展
    /// </summary>
    public static class DatabaseExtensions
    {
        #region 创建一个原始 Sql 查询，将该查询的结果返回给 DataTable
        /// <summary>
        /// 创建一个原始 Sql 查询，将该查询的结果返回给 <see cref="DataTable"/>
        /// </summary>
        /// <param name="database"><see cref="Database"/></param>
        /// <param name="sql">Sql 查询字符串</param>
        /// <param name="parameters">Sql 查询字符串的参数集</param>
        /// <returns><see cref="DataTable"/></returns>
        public static DataTable SqlQueryToDataTable(this Database database, string sql, params object[] parameters)
        {
            if (database == null) return null;
            if (sql.IsNullOrEmpty()) return null;

            using (var connection = (SqlConnection)database.Connection)
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = sql;

                    if (parameters != null && parameters.Length > 0)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            if (!parameter.ParameterName.Contains("@"))
                                parameter.ParameterName = $"@{parameter.ParameterName}";
                            cmd.Parameters.Add(parameter);
                        }
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(reader);
                        reader.Close();
                        return dt;
                    }
                }
            }
        }
        #endregion

        #region 创建一个原始 Sql 查询，将该查询的结果返回给 DataSet
        /// <summary>
        /// 创建一个原始 Sql 查询，将该查询的结果返回给 <see cref="DataSet"/>
        /// </summary>
        /// <param name="database">当前 <see cref="Database"/> 对象</param>
        /// <param name="sql">要执行查询的 Sql 语句</param>
        /// <param name="parameters">参数集</param>
        /// <returns>
        /// 如果 database 参数为 null 或者 sql 参数为 null 和空字符串("")，则返回 null；
        /// 否则返回填充数据后的<see cref="DataSet"/>
        /// </returns>
        public static DataSet SqlQueryToDataSet(this Database database, string sql, params object[] parameters)
        {
            if (database == null|| sql.IsNullOrEmpty()) return null;

            using (var conn = (SqlConnection)database.Connection)
            {
                conn.Open();
                using (var sqlCommand = conn.CreateCommand())
                {
                    sqlCommand.CommandText = sql;
                    if (parameters != null && parameters.Length > 0)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            if (!parameter.ParameterName.Contains("@"))
                                parameter.ParameterName = $"@{parameter.ParameterName}";
                            sqlCommand.Parameters.Add(parameter);
                        }
                    }
                    using (var adapter = new SqlDataAdapter(sqlCommand))
                    {
                        var dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        return dataSet;
                    }
                }
            }
        }
        #endregion
    }
}
