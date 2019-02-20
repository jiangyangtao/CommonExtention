﻿using CommonExtention.HttpResponseFormat;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Web.Http;

namespace CommonExtention.Common
{
    /// <summary>
    /// API基础控制器，提供通用返回格式。此类不可被实例化
    /// </summary>
    public abstract class BasicsApiController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        protected BasicsApiController() { }

        #region Json通用返回格式
        /// <summary>
        /// Json通用返回格式：返回成功
        /// </summary>
        /// <returns>
        /// Json格式 : {code:0,data:"",count:0,message:Success}
        /// </returns>
        protected virtual HttpResponseMessage ResponseSuccess() => HttpResponseMessageResponseFormat.ResponseSuccess();


        /// <summary>
        /// Json通用返回格式：返回成功
        /// </summary>
        /// <param name="data">要返回的数据</param>
        /// <param name="count">返回的数据行数(默认为1，数据为null则为0)</param>
        /// <returns>
        /// Json格式 : {code:0,data:data,count:1,message:Success}
        /// </returns>
        protected virtual HttpResponseMessage ResponseSuccess<T>(T data, int count = 1) => HttpResponseMessageResponseFormat.ResponseSuccess(data, count);

        /// <summary>
        /// Json通用返回格式：返回成功
        /// </summary>
        /// <param name="list"><see cref="List{T}"/></param>
        /// <param name="count">数据量(默认为 <see cref="List{T}.Count"/>)</param>
        /// <returns>
        /// Json格式 : {code:0,data:List,count:List.Count(),message:Success}
        /// </returns>
        protected virtual HttpResponseMessage ResponseSuccess<T>(List<T> list, int count = 0) => HttpResponseMessageResponseFormat.ResponseSuccess(list, count);

        /// <summary>
        /// Json通用返回格式：返回成功
        /// </summary>
        /// <param name="dataTable"><see cref="DataTable"/></param>
        /// <param name="count">数据量(默认为 <see cref="DataTable.Rows"/> 的Count)</param>
        /// <returns>
        /// Json格式 : {code:0,data:DataTable,count:DataTable.Rows.Count,message:Success}
        /// </returns>
        protected virtual HttpResponseMessage ResponseSuccess(DataTable dataTable, int count = 0) => HttpResponseMessageResponseFormat.ResponseSuccess(dataTable, count);

        /// <summary>
        /// Json通用返回格式：返回失败
        /// </summary>
        /// <param name="code">错误代码</param>
        /// <param name="message">错误信息(默认为"Unknown error")</param>
        /// <returns>
        /// Json格式 : {code:-1,data:"",count:-1,message:Unknown error}
        /// </returns>
        protected virtual HttpResponseMessage ResponseFail(int code = -1, string message = "Unknown error") => HttpResponseMessageResponseFormat.ResponseFail(code, message);
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
        protected virtual HttpResponseMessage ResponseGridResult<T>(T data, int count = 1) => HttpResponseMessageResponseFormat.ResponseGridResult(data, count);

        /// <summary>
        /// Json通用网格返回格式：返回成功
        /// </summary>
        /// <param name="list"><see cref="List{T}"/></param>
        /// <param name="count">数据量(默认为 <see cref="List{T}.Count"/>)</param>
        /// <returns>
        /// Json格式 : {code:0,rows:List,total:List.Count(),message:Success}
        /// </returns>
        protected virtual HttpResponseMessage ResponseGridResult<T>(List<T> list, int count = 0) => HttpResponseMessageResponseFormat.ResponseGridResult(list, count);

        /// <summary>
        /// Json通用网格返回格式：返回成功
        /// </summary>
        /// <param name="dataTable"><see cref="DataTable"/></param>
        /// <param name="count">数据量(默认为 <see cref="DataTable.Rows"/> 的Count)</param>
        /// <returns>
        /// Json格式 : {code:0,rows:DataTable,total:DataTable.Rows.Count,message:Success}
        /// </returns>
        protected virtual HttpResponseMessage ResponseGridResult(DataTable dataTable, int count = 0) => HttpResponseMessageResponseFormat.ResponseGridResult(dataTable, count);

        /// <summary>
        /// Json通用网格返回格式：返回失败
        /// </summary>
        /// <param name="code">失败代码</param>
        /// <param name="message">失败信息</param>
        /// <returns>
        /// Json格式 : {code:-1,rows:[],total:0,message:Unknown error}
        /// </returns>
        protected virtual HttpResponseMessage ResponseGridResult(int code = -1, string message = "Unknown error") => HttpResponseMessageResponseFormat.ResponseGridResult(code, message);
        #endregion
    }
}
