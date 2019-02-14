﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonExtention.Common
{
    /// <summary>
    /// 提供密码生成
    /// </summary>
    public static class Password
    {
        #region Private property
        /// <summary>
        /// 数字、大小写字母
        /// </summary>
        private const string _Key = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// 符号
        /// </summary>
        private const string _Symbol = "~!@#$%^&*()_+`-=";

        /// <summary>
        /// @ 符号
        /// </summary>
        private const char _AtSymbol = '@';
        #endregion

        #region 生成一个新的密码
        /// <summary>
        /// 生成一个新的密码
        /// </summary>
        /// <param name="length">密码长度</param>
        /// <param name="containsAtSymbol">是否包含 @ 符号</param>
        /// <param name="containsSymbol">是否包含符号</param>
        /// <returns>返回一个包含数字和大小写字母的密码</returns>
        public static string NewPassword(int length = 8, bool containsAtSymbol = false, bool containsSymbol = false)
        {
            var key = _Key;
            if (containsSymbol) key = string.Format("{0}{1}", key, _Symbol);

            var passwordStringBuild = new StringBuilder();
            var random = new Random();
            for (int i = 0; i < length; i++)
            {
                passwordStringBuild.Append(key[random.Next(0, key.Length)]);
            }

            var password = passwordStringBuild.ToString();
            if (containsAtSymbol && !password.Contains(_AtSymbol))
            {
                password = JoinAtSymbol(password.ToString());
            }
            return password;
        }
        #endregion

        #region 加入 @ 符号
        /// <summary>
        /// 加入 @ 符号
        /// </summary>
        /// <param name="password">密码</param>
        /// <returns>返回一个加入@符号的密码</returns>
        private static string JoinAtSymbol(string password)
        {
            var index = new Random().Next(0, password.Length);
            return password.Replace(password[index], _AtSymbol);
        }
        #endregion
    }
}