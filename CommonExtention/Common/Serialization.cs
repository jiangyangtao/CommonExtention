using CommonExtention.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CommonExtention.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class Serialization
    {
        #region MyRegion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static string DataTableToJsonString(DataTable dataTable)
        {
            return dataTable.ToJsonString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static string DataTableToJsonArrayString(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows.Count <= 0) return string.Empty;

            return JsonConvert.SerializeObject(dataTable);
        }
        #endregion

        #region DataSet
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        public static string DataSetToJsonArrayString(DataSet dataSet)
        {
            if (dataSet == null || dataSet.Tables.Count <= 0) return string.Empty;

            return JsonConvert.SerializeObject(dataSet);
        }
        #endregion

        #region List<T>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        public static string DataSetToString(DataSet dataSet)
        {
            if (dataSet == null || dataSet.Tables.Count <= 0) return string.Empty;

            return JsonConvert.SerializeObject(dataSet);
        }
        #endregion

        #region XML

        #endregion
    }
}
