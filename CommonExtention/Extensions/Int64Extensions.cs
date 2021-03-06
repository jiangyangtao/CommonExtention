﻿using System;
using System.Web;

namespace CommonExtention.Extensions
{
    /// <summary>
    /// <see cref="long"/> 扩展
    /// </summary>
    public static class Int64Extensions
    {
        #region 将此实例的Unix时间格式的数值转换为DateTime对象
        /// <summary>
        /// 将此实例的Unix时间格式的数值转换为要转换的 <see cref="DateTime"/> 对象
        /// </summary>
        /// <param name="timeStamp">Unix时间</param>
        /// <returns>返回 <see cref="DateTime"/> 对象</returns>
        public static DateTime ToDateTime(this long timeStamp)
        {
            var dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            var unix = long.Parse($"{timeStamp}0000000");
            var toNow = new TimeSpan(unix);
            return dtStart.Add(toNow);
        }
        #endregion

        #region 返回 length 对应的 Size
        /// <summary>
        /// 返回 <see cref="HttpPostedFileBase.ContentLength"/> 对应的Size
        /// </summary>
        /// <param name="length"><see cref="HttpPostedFileBase.ContentLength"/> 长度</param>
        /// <returns>
        /// B/KB/MB/GB/TB/PB
        /// </returns>
        public static string FileSize(this long length)
        {
            var size = Convert.ToDouble(length);
            var units = new String[] { "B", "KB", "MB", "GB", "TB", "PB" };
            var mod = 1024.0;
            var i = 0;
            while (size >= mod)
            {
                size /= mod;
                i++;
            }
            return Math.Round(size) + units[i];
        }
        #endregion

        #region 将此实例的数值转换为其千分位的字符串表示形式
        /// <summary>
        /// 将此实例的数值转换为其千分位的字符串表示形式
        /// </summary>
        /// <param name="value">要转换的<see cref="long"/></param>
        /// <returns>此实例的值的千分位字符串表示形式</returns>
        public static string ToThousand(this long value) => string.Format("{0:N}", value);
        #endregion
    }
}
