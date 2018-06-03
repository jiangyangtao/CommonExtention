using CommonExtention.Extention;
using System.Configuration;

namespace CommonExtention.Common
{
    /// <summary>
    /// 提供Web.Config文件的操作。此类无法被继承
    /// </summary>
    public sealed class WebConfig
    {
        #region 根据指定的 key 获取 Web.Config 文件中 AppSettings 节点对应的 value 值
        /// <summary>
        /// 根据指定的 key 获取 Web.Config 文件中 <see cref="ConfigurationManager.AppSettings"/> 节点对应的 value 值
        /// </summary>
        /// <param name="key">指定的 key </param>
        /// <returns>
        /// 如果 key 参数为 null 或空字符串 ("")，则返回 <see cref="string.Empty"/>；
        /// 如果 key 参数对应 <see cref="ConfigurationManager.AppSettings"/> 节点存在，则返回该 <see cref="ConfigurationManager.AppSettings"/> 节点的 value；
        /// 如果 key 参数对应 <see cref="ConfigurationManager.AppSettings"/> 节点不存在，则返回 <see cref="string.Empty"/> 。
        /// </returns>
        public static string GetAppSetting(string key)
        {
            if (key.IsNullOrEmpty()) return string.Empty;

            var str = ConfigurationManager.AppSettings[key];
            if (str.NotNullAndEmpty()) return str;
            return string.Empty;
        }
        #endregion

        #region 根据指定的 name 获取 Web.Config 文件中 connectionStrings 节点对应的 connectionString
        /// <summary>
        /// 根据指定的 name 获取 Web.Config 文件中 <see cref="ConfigurationManager.ConnectionStrings"/> 节点对应的 <see cref="ConnectionStringSettings.ConnectionString"/>
        /// </summary>
        /// <param name="name">指定的 name </param>
        /// <returns>
        /// 如果 name 参数为 null 或空字符串 ("")，则返回 <see cref="string.Empty"/>；
        /// 如果 <see cref="ConfigurationManager.ConnectionStrings"/> 节点下对应 name 参数的标签存在，则返回该标签的 <see cref="ConnectionStringSettings.ConnectionString"/>；
        /// 如果 <see cref="ConfigurationManager.ConnectionStrings"/> 节点下对应 name 参数的不存在，则返回 <see cref="string.Empty"/> 。
        /// </returns>
        public static string GetConnectionStrings(string name)
        {
            if (name.IsNullOrEmpty()) return string.Empty;

            var connString = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            if (connString.NotNullAndEmpty()) return connString;
            return string.Empty;
        }
        #endregion
    }
}
