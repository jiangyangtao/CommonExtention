using CommonExtention.Common;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Web;

namespace CommonExtention.Extensions
{
    /// <summary>
    /// <see cref="HttpFileCollectionBase"/> 扩展
    /// </summary>
    public static class HttpFileCollectionBaseExtensions
    {
        #region 将当前 HttpFileCollectionBase 对象读取到 ICollection<Collection<DataTable>>
        /// <summary>
        /// 将当前 <see cref="HttpFileCollectionBase"/> 对象读取到 <see cref="ICollection{Collection}"/> 集合
        /// </summary>
        /// <param name="httpFileCollection">要读取的 <see cref="HttpFileCollectionBase"/></param>
        /// <param name="firstRowIsColumnName">首行是否为 <see cref="DataColumn.ColumnName"/></param>
        /// <param name="addEmptyRow">是否添加空行，默认为 false，不添加</param>
        /// <returns>
        /// 如果 httpFileCollection 参数为 null，则返回 null；
        /// 如果 httpFileCollection 参数的 <see cref="HttpFileCollectionBase.Count"/> 属性小于或者等于 0，则返回 null；
        /// 否则返回从 <see cref="HttpFileCollectionBase"/> 读取后的 <see cref="ICollection{Collection}"/> 集合。
        /// 结构说明：
        /// <see cref="HttpPostedFileBase"/> 对应 <see cref="Collection{DataTable}"/>;
        /// <see cref="DataTable"/> 对应 Sheet 工作簿。
        /// </returns>
        public static ICollection<Collection<DataTable>> ReadToTableCollection(this HttpFileCollectionBase httpFileCollection,
            bool firstRowIsColumnName = true,
            bool addEmptyRow = false) => new Excel().ReadHttpFileCollectionToTableCollection(httpFileCollection, firstRowIsColumnName, addEmptyRow);
        #endregion
    }
}
