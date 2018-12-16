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
        #region 创建一个原始SQL查询，将该查询的结果将返回给 DataTable
        /// <summary>
        /// 创建一个原始 Sql 查询，将该查询的结果将返回给 <see cref="DataTable"/>
        /// </summary>
        /// <param name="database"><see cref="Database"/></param>
        /// <param name="sql">Sql 查询字符串</param>
        /// <param name="parameters">Sql 查询字符串的参数集</param>
        /// <returns><see cref="DataTable"/></returns>
        public static DataTable SqlQuery(this Database database, string sql, params object[] parameters)
        {
            if (database == null) return null;
            if (sql.IsNullOrEmpty()) return null;

            var connection = new SqlConnection();
            connection = (SqlConnection)database.Connection;
            var cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = sql;

            if (parameters != null && parameters.Length > 0)
            {
                foreach (var item in parameters)
                {
                    cmd.Parameters.Add(item);
                }
            }

            try
            {
                var adapter = new SqlDataAdapter(cmd);
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        #endregion
    }
}
