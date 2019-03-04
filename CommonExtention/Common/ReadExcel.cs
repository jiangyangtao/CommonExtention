using CommonExtention.Extensions;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace CommonExtention.Common
{
    /// <summary>
    /// 提供Excel读取功能。此类不可被继承
    /// </summary>
    public sealed class ReadExcel
    {
        #region 构造函数
        /// <summary>
        /// 初始化 <see cref="ReadExcel"/> 类的新实例
        /// </summary>
        /// <param name="path">Excel路径</param>
        /// <exception cref="ArgumentNullException">path 参数为 null 或空字符串 ("")</exception>
        /// <exception cref="DirectoryNotFoundException">未找到文件，或者没有文件夹、文件权限时，抛出 "未找到 path 中指定的文件"。</exception>
        public ReadExcel(string path)
        {
            if (path.IsNullOrEmpty()) throw new ArgumentNullException("未将对象引用设置到对象的实例。");
            if (!File.Exists(path)) throw new DirectoryNotFoundException("未找到指定的文件。");

            ByteLength = new FileInfo(path).Length;
            FileSize = ByteLength.FileSize();
            _Path = path;
        }
        #endregion

        #region 成员变量

        /// <summary>
        /// 路径
        /// </summary>
        private string _Path { set; get; }

        /// <summary>
        /// 文件大小
        /// </summary>
        public string FileSize { get; private set; }

        /// <summary>
        /// 字节长度
        /// </summary>
        public long ByteLength { get; private set; }

        /// <summary>
        /// 数据行数
        /// </summary>
        public int RowsCount { get; private set; }

        /// <summary>
        /// 字段列数
        /// </summary>
        public int ColumnCount { get; private set; }

        /// <summary>
        /// 数据
        /// </summary>
        public DataTable Data { get; private set; }

        /// <summary>
        /// 空行行数
        /// </summary>
        public int EmpytCount { get; private set; }

        /// <summary>
        /// 不为空的数据行数
        /// </summary>
        public int NotEmptyCount { get; private set; }

        /// <summary>
        /// 不为空的数据
        /// </summary>
        public DataTable NotEmptyData { get; private set; }

        #endregion

        #region 读取Excel
        /// <summary>
        /// 读取Excel
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns><see cref="DataTable"/></returns>
        private DataTable Read(string path)
        {
            if (path.IsNullOrEmpty()) throw new Exception("未将对象引用设置到对象的实例。");
            if (!File.Exists(path)) throw new Exception("未找到 path 中指定的文件。");

            var strConn = $"PRovider=Microsoft.ACE.OLEDB.12.0;Data Source={path};Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
            var Oleconn = new OleDbConnection(strConn);
            OleDbDataAdapter excelCommand = null;
            var excel_ds = new DataSet();
            try
            {
                Oleconn.Open();
                var dataTable = Oleconn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                var tableName = dataTable.Rows[1][2].ToString().Trim();
                var strSql = $"select * from [{tableName}]";
                excelCommand = new OleDbDataAdapter(strSql, Oleconn);
                excelCommand.Fill(excel_ds, "excelData");
                var dt = excel_ds.Tables[0];
                Data = dt;
                RowsCount = dt.Rows.Count;
                ColumnCount = dt.Columns.Count;

                var emptyCount = 0;
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    var emptyColumn = 0;
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        var item = dt.Rows[i][j].ToString();
                        if (!string.IsNullOrEmpty(item)) break;
                        else emptyColumn++;
                    }

                    if (emptyColumn == dt.Columns.Count)
                    {
                        emptyCount++;
                        dt.Rows.RemoveAt(i);
                    }
                }
                EmpytCount = emptyCount;
                NotEmptyData = dt;
                NotEmptyCount = NotEmptyData.Rows.Count;

                return dt;
            }
            finally
            {
                if (Oleconn.State != ConnectionState.Closed) Oleconn.Close();
                Oleconn.Dispose();
            }
        }
        #endregion

        #region 读取数据
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <returns>去除空行后的 <see cref="DataTable"/> 对象。</returns>
        public DataTable ReadData()
        {
            if (_Path.IsNullOrEmpty()) throw new DirectoryNotFoundException("未找到 Excel 文件。");
            return Read(_Path);
        }
        #endregion

        #region 删除Excel文件
        /// <summary>
        /// 删除Excel文件
        /// </summary>
        public void DeleteFile()
        {
            if (File.Exists(_Path)) File.Delete(_Path);
        }
        #endregion
    }
}
