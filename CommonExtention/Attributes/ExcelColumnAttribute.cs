using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonExtention.Attributes
{
    /// <summary>
    /// Excel 自动导出时，指定属性的配置
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ExcelColumnAttribute : Attribute
    {
        #region 构造函数
        /// <summary>
        /// 初始化 <see cref="ExcelColumnAttribute"/> 类的新实例
        /// </summary>
        public ExcelColumnAttribute() { }
        #endregion

        #region 公开属性
        /// <summary>
        /// 列名
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 索引
        /// </summary>
        public int Index { set; get; }
        #endregion
    }
}
