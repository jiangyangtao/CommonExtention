using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Net;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Linq;
using CommonExtention.Extensions;

namespace CommonExtention.Common
{
    /// <summary>
    /// API基础控制器，提供通用返回格式。此类不可被实例化
    /// </summary>
    public abstract class BasicsApiController : ApiController
    {
        /// <summary>
        /// HttpResponseMessage实例
        /// </summary>
        private HttpResponseMessage _ResponseMessage = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.OK,
        };

        /// <summary>
        /// 
        /// </summary>
        protected BasicsApiController()
        {

        }

        #region Json通用返回格式
        /// <summary>
        /// Json通用返回格式：返回成功
        /// </summary>
        /// <returns>
        /// Json格式 : {code:0,data:"",count:0,message:Success}
        /// </returns>
        protected HttpResponseMessage ResponseSuccess()
        {
            var result = new Dictionary<string, object>()
            {
                {"code",0},
                {"data",null},
                {"count",0},
                {"message","Success" }
            };
            var json = JObject.FromObject(result);
            _ResponseMessage.Content = new StringContent(json.ToString(), Encoding.UTF8);
            return _ResponseMessage;
        }

        /// <summary>
        /// Json通用返回格式：返回成功
        /// </summary>
        /// <param name="data">要返回的数据</param>
        /// <param name="count">返回的数据行数(默认为1，数据为null则为0)</param>
        /// <returns>
        /// Json格式 : {code:0,data:data,count:1,message:Success}
        /// </returns>
        protected virtual HttpResponseMessage ResponseSuccess<T>(T data, int count = 1)
        {
            if (data == null) count = 0;
            var result = new Dictionary<string, object>()
            {
                {"code",0},
                {"data",data},
                {"count",count},
                {"message","Success"}
            };
            var json = JObject.FromObject(result);
            _ResponseMessage.Content = new StringContent(json.ToString(), Encoding.UTF8);
            return _ResponseMessage;
        }

        /// <summary>
        /// Json通用返回格式：返回成功
        /// </summary>
        /// <param name="list"><see cref="List{T}"/></param>
        /// <param name="count">数据量(默认为 <see cref="List{T}.Count"/>)</param>
        /// <returns>
        /// Json格式 : {code:0,data:List,count:List.Count(),message:Success}
        /// </returns>
        protected virtual HttpResponseMessage ResponseSuccess<T>(List<T> list, int count = 0)
        {
            if (count == 0) count = list.Count();
            var result = new Dictionary<string, object>()
            {
                {"code",0},
                {"data",list},
                {"count",count},
                {"message","Success"}
            };
            var json = JObject.FromObject(result);
            _ResponseMessage.Content = new StringContent(json.ToString(), Encoding.UTF8);
            return _ResponseMessage;
        }

        /// <summary>
        /// Json通用返回格式：返回成功
        /// </summary>
        /// <param name="dt"><see cref="DataTable"/></param>
        /// <param name="count">数据量(默认为 <see cref="DataTable.Rows"/> 的Count)</param>
        /// <returns>
        /// Json格式 : {code:0,data:DataTable,count:DataTable.Rows.Count,message:Success}
        /// </returns>
        protected virtual HttpResponseMessage ResponseSuccess(DataTable dt, int count = 0)
        {
            if (count == 0) count = dt.Rows.Count;
            var jsonBuilder = new StringBuilder("{\"code\":0,\"count\":" + count + ",\"message\":\"Success\",\"data\":");
            jsonBuilder.Append(dt.ToJsonArrayString());
            jsonBuilder.Append("}");
            _ResponseMessage.Content = new StringContent(jsonBuilder.ToString(), Encoding.UTF8);
            return _ResponseMessage;
        }

        /// <summary>
        /// Json通用返回格式：返回失败
        /// </summary>
        /// <param name="code">错误代码</param>
        /// <param name="message">错误信息(默认为"Unknown error")</param>
        /// <returns>
        /// Json格式 : {code:-1,data:"",count:-1,message:Unknown error}
        /// </returns>
        protected virtual HttpResponseMessage ResponseFail(int code = -1, string message = "Unknown error")
        {
            var result = new Dictionary<string, object>()
            {
                {"code",code},
                {"data",""},
                {"count",-1},
                {"message",message}
            };
            var json = JObject.FromObject(result);
            _ResponseMessage.Content = new StringContent(json.ToString(), Encoding.UTF8);
            return _ResponseMessage;
        }
        #endregion

        #region Json通用网格返回格式
        /// <summary>
        /// Json通用网格返回格式：返回成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="count">数据量(默认为1，数据为null则为0)</param>
        /// <returns>
        /// Json格式 : {code:0,rows:data,total:1,message:Success}
        /// </returns>
        protected virtual HttpResponseMessage ResponseGridResult<T>(T data, int count = 1)
        {
            if (data != null) count = 1;
            var result = new Dictionary<string, object>()
            {
                {"code",0 },
                {"total",count },
                {"rows",data },
                {"message","Success" },
            };
            var json = JObject.FromObject(result);
            _ResponseMessage.Content = new StringContent(json.ToString(), Encoding.UTF8);
            return _ResponseMessage;
        }

        /// <summary>
        /// Json通用网格返回格式：返回成功
        /// </summary>
        /// <param name="list"><see cref="List{T}"/></param>
        /// <param name="count">数据量(默认为 <see cref="List{T}.Count"/>)</param>
        /// <returns>
        /// Json格式 : {code:0,rows:List,total:List.Count(),message:Success}
        /// </returns>
        protected virtual HttpResponseMessage ResponseGridResult<T>(List<T> list, int count = 0)
        {
            if (count == 0) count = list.Count();
            var result = new Dictionary<string, object>()
            {
                {"code",0 },
                {"total",count },
                {"rows",list },
                {"message","Success" },
            };
            var json = JObject.FromObject(result);
            _ResponseMessage.Content = new StringContent(json.ToString(), Encoding.UTF8);
            return _ResponseMessage;
        }

        /// <summary>
        /// Json通用网格返回格式：返回成功
        /// </summary>
        /// <param name="dt"><see cref="DataTable"/></param>
        /// <param name="count">数据量(默认为 <see cref="DataTable.Rows"/> 的Count)</param>
        /// <returns>
        /// Json格式 : {code:0,rows:DataTable,total:DataTable.Rows.Count,message:Success}
        /// </returns>
        protected virtual HttpResponseMessage ResponseGridResult(DataTable dt, int count = 0)
        {
            if (count == 0) count = dt.Rows.Count;
            var jsonBuilder = new StringBuilder("{\"code\":0,\"total\":" + count + ",\"message\":\"Success\",\"rows\":");
            jsonBuilder.Append(dt.ToJsonArrayString());
            jsonBuilder.Append("}");
            _ResponseMessage.Content = new StringContent(jsonBuilder.ToString(), Encoding.UTF8);
            return _ResponseMessage;
        }

        /// <summary>
        /// Json通用网格返回格式：返回失败
        /// </summary>
        /// <param name="code">失败代码</param>
        /// <param name="message">失败信息</param>
        /// <returns>
        /// Json格式 : {code:-1,rows:[],total:0,message:Unknown error}
        /// </returns>
        protected virtual HttpResponseMessage ResponseGridResult(int code = -1, string message = "Unknown error")
        {
            var result = new Dictionary<string, object>()
            {
                {"code",code },
                {"total",0 },
                {"rows",new string[0] },
                {"message",message },
            };
            var json = JObject.FromObject(result);
            _ResponseMessage.Content = new StringContent(json.ToString(), Encoding.UTF8);
            return _ResponseMessage;
        }
        #endregion
    }
}
