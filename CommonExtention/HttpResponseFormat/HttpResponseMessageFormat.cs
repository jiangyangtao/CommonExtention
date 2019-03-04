using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Text;

namespace CommonExtention.HttpResponseFormat
{
    /// <summary>
    /// <see cref="HttpResponseMessage"/> 格式化。此类不可被实例化
    /// </summary>
    public abstract class HttpResponseMessageFormat
    {
        #region 构造函数
        /// <summary>
        /// 初始化 <see cref="HttpResponseMessageFormat"/> 类的新实例
        /// </summary>
        public HttpResponseMessageFormat() { }
        #endregion

        #region 设置返回结果
        /// <summary>
        /// 设置返回结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        protected virtual HttpResponseMessage SetResponseResult<T>(T response) where T : class
        {
            var json = JObject.FromObject(response);
            return new HttpResponseMessage()
            {
                Content = new StringContent(json.ToString(), Encoding.UTF8),
                StatusCode = HttpStatusCode.OK,
            };
        }
        #endregion

        #region Json通用返回格式
        /// <summary>
        /// Json通用返回格式：返回成功
        /// </summary>
        /// <returns>
        /// Json格式 : {code:0,data:"",count:0,message:Success}
        /// </returns>
        public virtual HttpResponseMessage ResponseSuccess() => SetResponseResult(new ResponseEntity()
        {
            Code = 0,
            Data = null,
            Count = 0,
            Message = "Success",
        });

        /// <summary>
        /// Json通用返回格式：返回成功
        /// </summary>
        /// <param name="data">要返回的数据</param>
        /// <param name="count">返回的数据行数(默认为1，数据为null则为0)</param>
        /// <returns>
        /// Json格式 : {code:0,data:data,count:1,message:Success}
        /// </returns>
        public virtual HttpResponseMessage ResponseSuccess<T>(T data, int count = 1) => SetResponseResult(new ResponseEntity()
        {
            Code = 0,
            Data = data,
            Count = data == null ? 0 : count,
            Message = "Success",
        });

        /// <summary>
        /// Json通用返回格式：返回成功
        /// </summary>
        /// <param name="list"><see cref="List{T}"/></param>
        /// <param name="count">数据量(默认为 <see cref="List{T}.Count"/>)</param>
        /// <returns>
        /// Json格式 : {code:0,data:List,count:List.Count(),message:Success}
        /// </returns>
        public virtual HttpResponseMessage ResponseSuccess<T>(List<T> list, int count = 0) => SetResponseResult(new ResponseEntity()
        {
            Code = 0,
            Data = list,
            Count = count == 0 ? list.Count : count,
            Message = "Success",
        });

        /// <summary>
        /// Json通用返回格式：返回成功
        /// </summary>
        /// <param name="dataTable"><see cref="DataTable"/></param>
        /// <param name="count">数据量(默认为 <see cref="DataTable.Rows"/> 的Count)</param>
        /// <returns>
        /// Json格式 : {code:0,data:DataTable,count:DataTable.Rows.Count,message:Success}
        /// </returns>
        public virtual HttpResponseMessage ResponseSuccess(DataTable dataTable, int count = 0) => SetResponseResult(new ResponseEntity()
        {
            Code = 0,
            Data = dataTable,
            Count = count == 0 ? dataTable.Rows.Count : count,
            Message = "Success",
        });

        /// <summary>
        /// Json通用返回格式：返回失败
        /// </summary>
        /// <param name="code">错误代码</param>
        /// <param name="message">错误信息(默认为"Unknown error")</param>
        /// <returns>
        /// Json格式 : {code:-1,data:"",count:-1,message:Unknown error}
        /// </returns>
        public virtual HttpResponseMessage ResponseFail(int code = -1, string message = "Unknown error") => SetResponseResult(new ResponseEntity()
        {
            Code = code,
            Data = null,
            Count = 0,
            Message = message,
        });
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
        public virtual HttpResponseMessage ResponseGridResult<T>(T data, int count = 1) => SetResponseResult(new ResponseGridEntity()
        {
            Code = 0,
            Rows = data,
            Total = data == null ? 0 : count,
            Message = "Success",
        });

        /// <summary>
        /// Json通用网格返回格式：返回成功
        /// </summary>
        /// <param name="list"><see cref="List{T}"/></param>
        /// <param name="count">数据量(默认为 <see cref="List{T}.Count"/>)</param>
        /// <returns>
        /// Json格式 : {code:0,rows:List,total:List.Count(),message:Success}
        /// </returns>
        public virtual HttpResponseMessage ResponseGridResult<T>(List<T> list, int count = 0) => SetResponseResult(new ResponseGridEntity()
        {
            Code = 0,
            Rows = list,
            Total = count == 0 ? list.Count : count,
            Message = "Success",
        });

        /// <summary>
        /// Json通用网格返回格式：返回成功
        /// </summary>
        /// <param name="dataTable"><see cref="DataTable"/></param>
        /// <param name="count">数据量(默认为 <see cref="DataTable.Rows"/> 的Count)</param>
        /// <returns>
        /// Json格式 : {code:0,rows:DataTable,total:DataTable.Rows.Count,message:Success}
        /// </returns>
        public virtual HttpResponseMessage ResponseGridResult(DataTable dataTable, int count = 0) => SetResponseResult(new ResponseGridEntity()
        {
            Code = 0,
            Rows = dataTable,
            Total = count == 0 ? dataTable.Rows.Count : count,
            Message = "Success",
        });

        /// <summary>
        /// Json通用网格返回格式：返回失败
        /// </summary>
        /// <param name="code">失败代码</param>
        /// <param name="message">失败信息</param>
        /// <returns>
        /// Json格式 : {code:-1,rows:[],total:0,message:Unknown error}
        /// </returns>
        public virtual HttpResponseMessage ResponseGridResult(int code = -1, string message = "Unknown error") => SetResponseResult(new ResponseGridEntity()
        {
            Code = code,
            Rows = null,
            Total = 0,
            Message = message,
        });
        #endregion
    }
}
