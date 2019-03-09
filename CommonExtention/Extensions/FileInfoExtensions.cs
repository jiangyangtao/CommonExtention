using System.IO;

namespace CommonExtention.Extensions
{
    /// <summary>
    /// <see cref="FileInfo"/> 扩展
    /// </summary> 
    public static class FileInfoExtensions
    {
        #region 获取当前 FileInfo 的无符号字节数组
        /// <summary>
        /// 获取当前 <see cref="FileInfo"/> 的无符号字节数组
        /// </summary>
        /// <param name="fileInfo">要获取无符号字节数组的 <see cref="FileInfo"/></param>
        /// <param name="deleteFile">是否删除文件</param>
        /// <returns>当前 <see cref="FileInfo"/> 的无符号字节数组</returns>
        public static byte[] GetBuffer(this FileInfo fileInfo, bool deleteFile = true)
        {
            var buffer = new byte[1024 * 10];
            var memoryStream = new MemoryStream();
            var fileStream = fileInfo.OpenRead();
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);
            memoryStream.Write(bytes, 0, (int)fileStream.Length);
            buffer = memoryStream.GetBuffer();
            fileStream.Close();
            memoryStream.Close();
            if (deleteFile) fileInfo.Delete();
            return buffer;
        }
        #endregion
    }
}
