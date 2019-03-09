using System.IO;
using System.Web;

namespace CommonExtention.Extensions
{
    /// <summary>
    /// <see cref="HttpRequest"/> 扩展
    /// </summary>
    public static class HttpRequestExtensions
    {
        #region 获取当前请求的参数
        /// <summary>
        /// 获取当前请求的参数
        /// </summary>
        /// <param name="request">当前请求</param>
        /// <returns>字符串表示形式的请求参数</returns>
        public static string GetParamsString(this HttpRequest request)
        {
            try
            {
                var method = request.HttpMethod.ToLower();
                if (method == "get") return request.QueryString.ToString();
                if (method == "post")
                {
                    var contentType = request.ContentType;
                    if (contentType.Contains("multipart")) return request.Form.ToJson();
                    else
                    {
                        // request.Body.Position = 0;
                        var reader = new StreamReader(request.InputStream);
                        return reader.ReadToEnd();
                    }
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
        #endregion
    }
}
