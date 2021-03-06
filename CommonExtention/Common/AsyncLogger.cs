﻿using CommonExtention.Eititys;
using CommonExtention.Extensions;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Web;

namespace CommonExtention.Common
{
    /// <summary>
    /// 异步日志记录，不占用当前主线程。此类无法被继承
    /// </summary>
    public sealed class AsyncLogger
    {
        #region 构造函数
        /// <summary>
        /// 初始化 <see cref="AsyncLogger"/> 类的新实例
        /// </summary>
        public AsyncLogger() { }
        #endregion

        #region 记录异常
        /// <summary>
        /// 记录异常
        /// </summary>
        /// <param name="exception"><see cref="Exception"/> 对象</param>
        public static void LogException(Exception exception)
            => new AsyncLogException(BeginLogException).BeginInvoke(exception, HttpContext.Current, null, null);
        #endregion

        #region 记录关键信息
        /// <summary>
        /// 记录关键信息
        /// </summary>
        /// <param name="information">关键信息</param>
        public static void LogInformation(string information) =>
            new AsyncLogInformation(BeginLogInformation).BeginInvoke(information, HttpContext.Current, null, null);
        #endregion

        #region 记录Mvc请求信息
        /// <summary>
        /// 记录Mvc请求信息
        /// </summary>
        /// <param name="model"><see cref="MvcRequest"/> 对象</param>
        public static void LogMvcRequest(MvcRequest model)
            => new AsyncLogMvcRequest(BeginLogMvcRequest).BeginInvoke(model, HttpContext.Current, null, null);

        #endregion

        #region 异步方法
        /// <summary>
        /// 委托方式的异步写入异常
        /// </summary>
        /// <param name="exception"><see cref="Exception"/> 对象</param>
        /// <param name="context"><see cref="HttpContext"/> 对象</param>
        private delegate void AsyncLogException(Exception exception, HttpContext context);

        /// <summary>
        /// 委托方式的异步写入关键信息
        /// </summary>
        /// <param name="information">关键信息</param>
        /// <param name="context"><see cref="HttpContext"/> 对象</param>
        private delegate void AsyncLogInformation(string information, HttpContext context);

        /// <summary>
        /// 委托方式的异步写入Mvc请求信息
        /// </summary>
        /// <param name="model"><see cref="MvcRequest"/> 对象</param>
        /// <param name="context"><see cref="HttpContext"/> 对象</param>
        private delegate void AsyncLogMvcRequest(MvcRequest model, HttpContext context);
        #endregion

        #region 异步记录        
        /// <summary>
        /// 当前应用的相对路径
        /// </summary>
        private static readonly string _Map = $"{HttpRuntime.AppDomainAppPath}log/{DateTime.Now.ToFormatDate()}";

        /// <summary>
        /// 异步写入异常
        /// </summary>
        /// <param name="exception"><see cref="Exception"/> 对象</param>
        /// <param name="context"><see cref="HttpContext"/> 对象</param>
        private static void BeginLogException(Exception exception, HttpContext context)
        {
            if (exception != null)
            {
                var _path = $"{_Map}error.txt";
                var _fileInfo = new FileInfo(_path);
                var _dir = _fileInfo.Directory;
                if (!_dir.Exists) _dir.Create();    //如果文件夹不存在，则创建

                //允许多个线程同时写入
                using (var fileStream = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
                {
                    var streamWrite = new StreamWriter(fileStream, Encoding.Default);

                    try
                    {
                        streamWrite.BaseStream.Seek(0, SeekOrigin.End);
                        streamWrite.WriteLine(DateTime.Now.ToFormatDateTime());
                        streamWrite.WriteLine("\r\n");
                        streamWrite.WriteLine("\r\n  异常信息：");
                        streamWrite.WriteLine($"\r\n\t请求地址：{context.Request.Url.ToString()}");
                        streamWrite.WriteLine($"\r\n\t错误信息：{exception.ExceptionMessage()}");
                        streamWrite.WriteLine($"\r\n\t错 误 源：{exception.Source}");
                        streamWrite.WriteLine($"\r\n\t异常方法：{exception.TargetSite}");
                        streamWrite.WriteLine($"\r\n\t堆栈信息：{exception.StackTrace}");
                        streamWrite.WriteLine($"\r\n\t线程  ID：{Thread.CurrentThread.ManagedThreadId}");
                        streamWrite.WriteLine($"\r\n\t浏览器标识：{context.Request.UserAgent}");
                        streamWrite.WriteLine("\r\n");

                        //日志分隔线
                        streamWrite.WriteLine("--------------------------------------------------------------------------------------------------------------\n");
                        streamWrite.WriteLine("\r\n");
                        streamWrite.WriteLine("\r\n");
                        streamWrite.WriteLine("\r\n");
                    }
                    finally
                    {
                        streamWrite.Flush();
                        streamWrite.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 异步写入关键信息
        /// </summary>
        /// <param name="information">关键信息</param>
        /// <param name="context"><see cref="HttpContext"/> 对象</param>
        private static void BeginLogInformation(string information, HttpContext context)
        {
            var _path = $"{_Map}information.txt";
            var _fileInfo = new FileInfo(_path);
            var _dir = _fileInfo.Directory;
            if (!_dir.Exists) _dir.Create();    //如果文件夹不存在，则创建

            //允许多个线程同时写入
            using (var fileStream = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            {
                var streamWrite = new StreamWriter(fileStream, Encoding.Default);
                try
                {
                    streamWrite.BaseStream.Seek(0, SeekOrigin.End);
                    streamWrite.WriteLine(DateTime.Now.ToFormatDateTime());
                    streamWrite.WriteLine("\r\n");
                    streamWrite.WriteLine("\r\n");
                    streamWrite.WriteLine($"\r\n\t请求地址：{context.Request.Url.ToString()}");
                    streamWrite.WriteLine($"\r\n\t记录信息：{information}");
                    streamWrite.WriteLine("\r\n");
                    streamWrite.WriteLine($"\r\n\t浏览器标识：{context.Request.UserAgent}");

                    //日志分隔线
                    streamWrite.WriteLine("--------------------------------------------------------------------------------------------------------------\n");
                    streamWrite.WriteLine("\r\n");
                    streamWrite.WriteLine("\r\n");
                    streamWrite.WriteLine("\r\n");
                }
                finally
                {
                    streamWrite.Flush();
                    streamWrite.Close();
                }
            }
        }

        /// <summary>
        /// 异步写入请求信息
        /// </summary>
        /// <param name="model"><see cref="MvcRequest"/> 对象</param>
        /// <param name="context"><see cref="HttpContext"/> 对象</param>
        private static void BeginLogMvcRequest(MvcRequest model, HttpContext context)
        {
            var _path = $"{_Map}request.txt";
            var _fileInfo = new FileInfo(_path);
            var _dir = _fileInfo.Directory;
            if (!_dir.Exists) _dir.Create();    //如果文件夹不存在，则创建

            //允许多个线程同时写入
            using (var fileStream = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            {
                var streamWrite = new StreamWriter(fileStream, Encoding.Default);
                try
                {
                    streamWrite.BaseStream.Seek(0, SeekOrigin.End);
                    streamWrite.WriteLine(DateTime.Now.ToFormatDateTime());
                    streamWrite.WriteLine("\r\n");
                    streamWrite.WriteLine("\r\n  请求信息：");
                    streamWrite.WriteLine($"\r\n\t浏览器标识：{model.UserAgent}");
                    streamWrite.WriteLine($"\r\n\t请求地址：{model.Url}");
                    streamWrite.WriteLine($"\r\n\t请求参数：{model.Params}");
                    streamWrite.WriteLine($"\r\n\t请求类型：{model.RequestType}");
                    streamWrite.WriteLine($"\r\n\t控制器名：{model.ControllerName}");
                    streamWrite.WriteLine($"\r\n\tAction名：{model.ActionName}");
                    streamWrite.WriteLine($"\r\n\tIp  地址：{model.IpAddress}");
                    streamWrite.WriteLine($"\r\n\t线程  ID：{model.ThreadId}");
                    streamWrite.WriteLine($"\r\n\t消耗时间：{model.ConsumingTime} s");

                    //日志分隔线
                    streamWrite.WriteLine("--------------------------------------------------------------------------------------------------------------\n");
                    streamWrite.WriteLine("\r\n");
                    streamWrite.WriteLine("\r\n");
                    streamWrite.WriteLine("\r\n");
                }
                finally
                {
                    streamWrite.Flush();
                    streamWrite.Close();
                }
            }
        }
        #endregion
    }
}
