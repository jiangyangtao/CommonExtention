using System;
using System.Text;
using System.Web;

namespace CommonExtention.Common
{
    /// <summary>
    /// 提供 <see cref="HttpCookie"/> 的操作。此类无法被继承
    /// </summary>
    public sealed class HttpCookieConfigure
    {
        #region 指示Cookie是否存在
        /// <summary>
        /// 指示Cookie是否存在
        /// </summary>
        /// <param name="name">Cookie名</param>
        /// <param name="value">返回的Cookie值</param>
        /// <returns>
        /// 如果Cookie存在，则返回 true，并且返回对应的Cookie值；
        /// 如果Cookie不存在，则返回 falise；
        /// </returns>
        public static bool IsExist(string name, out string value)
        {
            value = GetCookie(name);
            return !string.IsNullOrWhiteSpace(value);
        }
        #endregion

        #region 清除所有Cookie
        /// <summary>
        /// 清除所有Cookie
        /// </summary>
        public static void ClearAll()
        {
            HttpContext.Current.Response.Cookies.Clear();
            int count = HttpContext.Current.Request.Cookies.Count;
            for (int i = 0; i < count; i++)
            {
                string name = HttpContext.Current.Request.Cookies[i].Name;
                HttpCookie httpCookie = new HttpCookie(name);
                httpCookie.Expires = DateTime.Now.AddDays(-10.0);
                HttpContext.Current.Response.Cookies.Add(httpCookie);
            }
        }
        #endregion

        #region 清除单个的Cookie
        /// <summary>
        /// 清除单个的Cookie
        /// </summary>
        /// <param name="name">需要清除的Cookie名</param>
        public static void Clear(string name)
        {
            HttpContext.Current.Response.Cookies.Clear();
            HttpCookie httpCookie = new HttpCookie(name);
            httpCookie.Expires = DateTime.Now.AddDays(-10.0);
            HttpContext.Current.Response.Cookies.Add(httpCookie);
        }
        #endregion

        #region 使用的编码
        /// <summary>
        /// 使用的编码
        /// </summary>
        private static readonly Encoding _enc = Encoding.UTF8;
        #endregion

        #region 设置单个Cookie值
        /// <summary>
        /// 设置单个Cookie值
        /// </summary>
        /// <param name="name">Cookie名</param>
        /// <param name="value">Cookie值</param>
        /// <param name="HttpOnly">
        /// 获取或设置一个值，该值指定 Cookie 是否可通过客户端脚本访问。
        /// 如果 Cookie 具有 HttpOnly 属性且不能通过客户端脚本访问，则为 true；
        /// 否则为 false。默认值为 false。
        /// </param>
        public static void SetCookie(string name, string value, bool HttpOnly)
        {
            if (HttpContext.Current.Request.Cookies[name] == null)
            {
                HttpContext.Current.Request.Cookies.Add(new HttpCookie(name));
            }
            HttpContext.Current.Request.Cookies[name].Value = HttpUtility.UrlEncode(value, _enc);
            HttpContext.Current.Request.Cookies[name].HttpOnly = HttpOnly;
            if (HttpContext.Current.Response.Cookies[name] == null)
            {
                HttpContext.Current.Response.Cookies.Add(new HttpCookie(name));
            }
            HttpContext.Current.Response.Cookies[name].Value = HttpUtility.UrlEncode(value, _enc);
            HttpContext.Current.Response.Cookies[name].HttpOnly = HttpOnly;
        }
        #endregion

        #region 设置客户端允许访问的Cookie
        /// <summary>
        /// 设置客户端允许访问的Cookie
        /// </summary>
        /// <param name="name">Cookie名</param>
        /// <param name="value">Cookie值</param>
        public static void SetCookie(string name, string value)
        {
            SetCookie(name, value, false);
        }
        #endregion

        #region 设置客户端不允许访问的Cookie
        /// <summary>
        /// 设置客户端不允许访问的Cookie
        /// </summary>
        /// <param name="name">Cookie名</param>
        /// <param name="value">Cookie值</param>
        public static void SetCookieHttpOnly(string name, string value)
        {
            SetCookie(name, value, true);
        }
        #endregion

        #region 获取单个Cookie值
        /// <summary>
        /// 获取单个Cookie值
        /// </summary>
        /// <param name="name">Cookie名</param>
        /// <returns>
        /// 如果Cookie存在，则返回Cookie值；
        /// 如果Cookie不存在，则返回  <see cref="string.Empty"/>  ；
        /// </returns>
        public static string GetCookie(string name)
        {
            var temp = HttpContext.Current.Request.Cookies[name];
            return temp != null ? HttpUtility.UrlDecode(temp.Value, _enc) : string.Empty;
        }
        #endregion
    }
}
