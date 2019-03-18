using CommonExtention.Common;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace CommonExtention.Extensions
{
    /// <summary>
    /// <see cref="HttpPostedFileBase"/> 扩展
    /// </summary>
    public static class HttpPostedFileBaseExtensions
    {
        #region 将当前 HttpPostedFileBase 对象读取到 DataTable
        /// <summary>
        /// 将当前 <see cref="HttpPostedFileBase"/> 对象读取到 <see cref="DataTable"/>
        /// </summary>
        /// <param name="httpPostedFile">要读取的 <see cref="HttpPostedFileBase"/> 对象</param>
        /// <param name="sheetName">指定读取 Excel 工作薄 sheet 的名称</param>
        /// <param name="firstRowIsColumnName">首行是否为 <see cref="DataColumn.ColumnName"/></param>
        /// <param name="addEmptyRow">是否添加空行，默认为 false，不添加</param>
        /// <returns>
        /// 如果 httpPostedFile 参数为 null，则返回 null；
        /// 如果 httpPostedFile 参数的 <see cref="HttpPostedFileBase.ContentLength"/> 属性为 小于或者等于 0，则返回 null；
        /// 否则返回从 <see cref="HttpPostedFileBase"/>读取后的 <see cref="DataTable"/> 对象。
        /// </returns>
        public static DataTable ReadToDataTable(this HttpPostedFileBase httpPostedFile,
            string sheetName = null,
            bool firstRowIsColumnName = true,
            bool addEmptyRow = false) => new Excel().ReadHttpPostedFileToDataTable(httpPostedFile, sheetName, firstRowIsColumnName, addEmptyRow);
        #endregion

        #region 将当前 HttpPostedFileBase 对象读取到 ICollection<DataTable>
        /// <summary>
        /// 将当前 <see cref="HttpPostedFileBase"/> 对象读取到 <see cref="ICollection{DataTable}"/>
        /// </summary>
        /// <param name="httpPostedFile">要读取的 <see cref="HttpPostedFileBase"/> 对象</param>
        /// <param name="firstRowIsColumnName">首行是否为 <see cref="DataColumn.ColumnName"/></param>
        /// <param name="addEmptyRow">是否添加空行，默认为 false，不添加</param>
        /// <returns>
        /// 如果 httpPostedFile 参数为 null，则返回 null；
        /// 如果 httpPostedFile 参数的 <see cref="HttpPostedFileBase.ContentLength"/> 属性小于或者等于 0，则返回 null；
        /// 否则返回从 <see cref="HttpPostedFileBase"/>读取后的 <see cref="ICollection{DataTable}"/> 对象，
        /// 其中一个 <see cref="DataTable"/> 对应一个 Sheet 工作簿。
        ///</returns>
        public static ICollection<DataTable> ReadToTables(this HttpPostedFileBase httpPostedFile,
            bool firstRowIsColumnName = true,
            bool addEmptyRow = false) => new Excel().ReadHttpPostedFileToTables(httpPostedFile, firstRowIsColumnName, addEmptyRow);
        #endregion
    }
}
