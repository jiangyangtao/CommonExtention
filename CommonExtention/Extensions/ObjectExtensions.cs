﻿using System;

namespace CommonExtention.Extensions
{
    /// <summary>
    /// <see cref="object"/> 扩展
    /// </summary>
    public static class ObjectExtensions
    {
        #region 指示指定的 object 对象是否不为 null
        /// <summary>
        /// 指示指定的 <see cref="object"/> 对象是否不为 null
        /// </summary>
        /// <param name="value">指定的 <see cref="object"/> 对象</param>
        /// <returns>如果当前 object 不为 null ，则为 true；否则为 false。</returns>
        public static bool NotNull(this object value) => value != null;
        #endregion

        #region 指示指定的 object 对象不是 null 和 System.String.Empty 字符串
        /// <summary>
        /// 指示指定的 <see cref="object"/> 对象不为 null 和 <see cref="string.Empty"/> 字符串
        /// </summary>
        /// <param name="value">指定的 <see cref="object"/> 对象</param>
        /// <returns>如果当前 object 不为 null 和空字符串 ("")，则为 true；否则为 false。</returns>
        public static bool NotNullAndEmpty(this object value) => value != null && value.ToString() != string.Empty;
        #endregion

        #region 指示指定的 object 对象是否为 null
        /// <summary>
        /// 指示指定的 <see cref="object"/> 对象是否为 null
        /// </summary>
        /// <param name="value">指定的 <see cref="object"/> 对象</param>
        /// <returns>如果当前 object 为 null，则返回true；否则为 false。</returns>
        public static bool IsNull(this object value) => value == null;
        #endregion

        #region 指示指定的 object 对象是 null 还是 System.String.Empty 字符串
        /// <summary>
        /// 指示指定的 object 对象是 null 还是 <see cref="string.Empty"/> 字符串
        /// </summary>
        /// <param name="value">要检测的Object对象</param>
        /// <returns>如果当前 object 为 null 或空字符串 ("")，则为 true；否则为 false。</returns>
        public static bool IsNullOrEmpty(this object value) => value == null || value.ToNotSpaceString() == string.Empty;
        #endregion

        #region 将指定的 object 对象转换不为 null 的 System.String 表示形式
        /// <summary>
        /// 将指定的 <see cref="object"/> 对象转换不为 null 的 <see cref="string"/> 表示形式
        /// </summary>
        /// <param name="value">要转换的 <see cref="object"/> 对象</param>
        /// <returns>
        /// 如果当前 object 不为 null，则返回 value 参数的 <see cref="string"/> 表示形式；
        /// 否则返回 <see cref="string.Empty"/>。
        /// </returns>
        public static string ToNotNullString(this object value)
        {
            if (value.IsNull()) return string.Empty;
            return value.ToString();
        }
        #endregion

        #region 将指定的 object 对象转换为去除空格后的 System.String 表示形式
        /// <summary>
        /// 将指定的 <see cref="object"/> 对象转换为去除空格后的 <see cref="string"/> 表示形式
        /// </summary>
        /// <param name="value">要转换的 <see cref="object"/> 对象</param>
        /// <returns>
        /// 如果当前 object 不为 null，则返回 value 参数去除空格后的 <see cref="string"/> 表示形式；
        /// 否则返回 <see cref="string.Empty"/>。
        /// </returns>
        public static string ToNotSpaceString(this object value)
        {
            if (value == null) return string.Empty;
            return value.ToString().Trim();
        }
        #endregion

        #region 指示指定的 object 是否为等效的 String 类型
        /// <summary>
        /// 指示指定的 <see cref="object"/> 是否为等效的 <see cref="string"/> 类型
        /// </summary>
        /// <param name="value">要检测的 <see cref="object"/> </param>
        /// <returns>
        /// 如果 value 值为 null，则返回 false；
        /// 如果 value 值为等效的 <see cref="string"/> 类型，则返回true；否则返回false。
        /// </returns>
        public static bool IsString(this object value)
        {
            if (value == null) return false;
            return value.GetType().Name == "String";
        }
        #endregion

        #region 指示指定的 object 是否为等效的 Int16 类型
        /// <summary>
        /// 指示指定的 <see cref="object"/> 是否为等效的 <see cref="short"/> 类型
        /// </summary>
        /// <param name="value">要检测的 <see cref="object"/> </param>
        /// <returns>
        /// 如果 value 值为 null，则返回 false；
        /// 如果 value 值为等效的 <see cref="short"/> 类型，则返回true；否则返回false。
        /// </returns>
        public static bool IsInt16(this object value)
        {
            if (value == null) return false;
            return value.GetType().Name == "Int16";
        }
        #endregion

        #region 指示指定的 object 是否为等效的 Int32 类型
        /// <summary>
        /// 指示指定的 <see cref="object"/> 是否为等效的 <see cref="int"/> 类型
        /// </summary>
        /// <param name="value">要检测的 <see cref="object"/> </param>
        /// <returns>
        /// 如果 value 值为 null，则返回 false；
        /// 如果 value 值为等效的 <see cref="int"/> 类型，则返回true；否则返回false。
        /// </returns>
        public static bool IsInt(this object value)
        {
            if (value == null) return false;
            return value.GetType().Name == "Int32";
        }
        #endregion

        #region 指示指定的 object 是否为等效的 Int64 类型
        /// <summary>
        /// 指示指定的 <see cref="object"/> 是否为等效的 <see cref="long"/> 类型
        /// </summary>
        /// <param name="value">要检测的 <see cref="object"/> </param>
        /// <returns>
        /// 如果 value 值为 null，则返回 false；
        /// 如果 value 值为等效的 <see cref="long"/> 类型，则返回true；否则返回false。
        /// </returns>
        public static bool IsInt64(this object value)
        {
            if (value == null) return false;
            return value.GetType().Name == "Int64";
        }
        #endregion

        #region 指示指定的 object 是否为等效的 Decimal 类型
        /// <summary>
        /// 指示指定的 <see cref="object"/> 是否为等效的 <see cref="decimal"/> 类型
        /// </summary>
        /// <param name="value">要检测的 <see cref="object"/> </param>
        /// <returns>
        /// 如果 value 值为 null，则返回 false；
        /// 如果 value 值为等效的 <see cref="decimal"/> 类型，则返回true；否则返回false。
        /// </returns>
        public static bool IsDecimal(this object value)
        {
            if (value == null) return false;
            return value.GetType().Name == "Decimal";
        }
        #endregion

        #region 指示指定的 object 是否为等效的 Single 类型
        /// <summary>
        /// 指示指定的 <see cref="object"/> 是否为等效的 <see cref="float"/> 类型
        /// </summary>
        /// <param name="value">要检测的 <see cref="object"/> </param>
        /// <returns>
        /// 如果 value 值为 null，则返回 false；
        /// 如果 value 值为等效的 <see cref="float"/> 类型，则返回true；否则返回false。
        /// </returns>
        public static bool IsSingle(this object value)
        {
            if (value == null) return false;
            return value.GetType().Name == "Single";
        }
        #endregion

        #region 指示指定的 object 是否为等效的 Double 类型
        /// <summary>
        /// 指示指定的 <see cref="object"/> 是否为等效的 <see cref="double"/> 类型
        /// </summary>
        /// <param name="value">要检测的 <see cref="object"/> </param>
        /// <returns>
        /// 如果 value 值为 null，则返回 false；
        /// 如果 value 值为等效的 <see cref="double"/> 类型，则返回true；否则返回false。
        /// </returns>
        public static bool IsDouble(this object value)
        {
            if (value == null) return false;
            return value.GetType().Name == "Double";
        }
        #endregion

        #region 指示指定的 object 是否为等效的 DadeTime 对象
        /// <summary>
        /// 指示指定的 <see cref="object"/> 是否为等效的 <see cref="DateTime"/> 对象
        /// </summary>
        /// <param name="value">要检测的 <see cref="object"/> </param>
        /// <returns>
        /// 如果 value 值为 null，则返回 false；
        /// 如果 value 值为等效的 <see cref="DateTime"/> 对象，则返回true；否则返回false。
        /// </returns>
        public static bool IsDateTime(this object value)
        {
            if (value == null) return false;
            return value.GetType().Name == "DateTime";
        }
        #endregion

        #region 指示指定的 object 是否为等效的 Boolean 类型
        /// <summary>
        /// 指示指定的 <see cref="object"/> 是否为等效的 <see cref="bool"/> 类型
        /// </summary>
        /// <param name="value">要检测的 <see cref="object"/> </param>
        /// <returns>
        /// 如果 value 值为 null，则返回 false；
        /// 如果 value 为等效的 <see cref="bool"/> 类型，则返回true；否则返回false。
        /// </returns>
        public static bool IsBoolean(this object value)
        {
            if (value == null) return false;
            return value.GetType().Name == "Boolean";
        }
        #endregion

        #region 将数字形式的 object 对象转换为其等效的 Int16 的值
        /// <summary>
        /// 将数字的 <see cref="object"/> 对象转换为其等效的 <see cref="short"/> 的值
        /// </summary>
        /// <param name="value">指定的 <see cref="object"/> 对象</param>
        /// <returns>
        /// 如果 <see cref="object"/> 对象为 null 或空字符串 ("")，则返回0；
        /// 如果转换失败，则返回0；
        /// 如果转换成功，则返回其等效的 <see cref="short"/> 值。
        /// </returns>
        public static short ToInt16(this object value)
        {
            if (value.IsNullOrEmpty()) return 0;

            var isParsed = short.TryParse(value.ToString(), out short i);
            if (!isParsed) return 0;
            return i;
        }
        #endregion

        #region 将数字形式的 object 对象转换为其等效的 Int32 的值
        /// <summary>
        /// 将数字的 <see cref="object"/> 对象转换为其等效的 <see cref="int"/> 的值
        /// </summary>
        /// <param name="value">指定的 <see cref="object"/> 对象/param>
        /// <returns> 
        /// 如果 <see cref="object"/> 对象为 null 或空字符串 ("")，则返回0；
        /// 如果转换失败，则返回0；
        /// 如果转换成功，则返回等效的 <see cref="int"/> 的值。
        /// </returns>
        public static int ToInt(this object value)
        {
            if (value.IsNullOrEmpty()) return 0;

            var isParsed = int.TryParse(value.ToString(), out int i);
            if (!isParsed) return 0;
            return i;
        }
        #endregion

        #region 将数字形式的 object 对象转换为其等效的 Int64 的值
        /// <summary>
        /// 将数字的 <see cref="object"/> 对象转换为其等效的 <see cref="long"/> 的值
        /// </summary>
        /// <param name="value">指定的 <see cref="object"/> 对象</param>
        /// <returns>
        /// 如果 <see cref="object"/> 对象为 null 或空字符串 ("")，则返回0；
        /// 如果转换失败，则返回0；
        /// 如果转换成功，则返回等效的 <see cref="long"/> 的值。
        /// </returns>
        public static long ToInt64(this object value)
        {
            if (value.IsNullOrEmpty()) return 0;

            var isParsed = long.TryParse(value.ToString(), out long i);
            if (!isParsed) return 0;
            return i;
        }
        #endregion

        #region 将数字形式的 object 对象转换为其等效的 Single 的值
        /// <summary>
        /// 将数字的 <see cref="object"/> 对象转换为其等效的 <see cref="float"/> 的值
        /// </summary>
        /// <param name="value">指定的 <see cref="object"/> 对象</param>
        /// <returns>
        /// 如果 <see cref="object"/> 对象为 null 或空字符串 ("")，则返回0；
        /// 如果转换失败，则返回0；
        /// 如果转换成功，则返回等效的 <see cref="float"/> 的值。
        /// </returns>
        public static float ToSingle(this object value)
        {
            if (value.IsNullOrEmpty()) return 0;

            var isParsed = float.TryParse(value.ToString(), out float i);
            if (!isParsed) return 0;
            return i;
        }
        #endregion

        #region 将数字形式的 object 对象转换为其等效的 Double 的值
        /// <summary>
        /// 将数字的 <see cref="object"/> 对象转换为其等效的 <see cref="double"/> 的值
        /// </summary>
        /// <param name="value">指定的 <see cref="object"/> 对象</param>
        /// <returns>
        /// 如果 <see cref="object"/> 对象为 null 或空字符串 ("")，则返回0；
        /// 如果转换失败，则返回0；
        /// 如果转换成功，则返回等效的 <see cref="double"/> 的值。
        /// </returns>
        public static double ToDouble(this object value)
        {
            if (value.IsNullOrEmpty()) return 0;

            var isParsed = double.TryParse(value.ToString(), out double i);
            if (!isParsed) return 0;
            return i;
        }
        #endregion

        #region 将数字形式的 object 对象转换为其等效的 Decimal 的值
        /// <summary>
        /// 将数字的 <see cref="object"/> 对象转换为其等效的 <see cref="decimal"/> 的值
        /// </summary>
        /// <param name="value">指定的 <see cref="object"/> 对象</param>
        /// <returns>
        /// 如果 <see cref="object"/> 对象为 null 或空字符串 ("")，则返回0；
        /// 如果转换失败，则返回0；
        /// 如果转换成功，则返回等效的 <see cref="decimal"/> 的值。
        /// </returns>
        public static decimal ToDecimal(this object value)
        {
            if (value.IsNullOrEmpty()) return 0;

            var isParsed = decimal.TryParse(value.ToString(), out decimal i);
            if (!isParsed) return 0;
            return i;
        }
        #endregion

        #region 将时间形式的 object 对象转换为其等效的 DateTime 对象
        /// <summary>
        /// 将时间的 <see cref="object"/> 对象转换为其等效的 <see cref="DateTime"/> 对象
        /// </summary>
        /// <param name="value">指定的 <see cref="object"/> 对象</param>
        /// <returns>
        /// 如果 <see cref="object"/> 对象为 null 或空字符串 ("")，则抛出异常("该字符串未被识别为有效的DateTime。")；
        /// 如果转换失败，则抛出异常("该字符串未被识别为有效的DateTime。")；
        /// 如果转换成功，则返回等效的 <see cref="DateTime"/> 的对象。
        /// </returns>
        /// <exception cref="ArgumentNullException"> value 参数为 null 或空字符串 ("")</exception>
        /// <exception cref="InvalidCastException"> value 参数转换失败。</exception>
        public static DateTime ToDateTime(this object value)
        {
            if (value.IsNullOrEmpty()) throw new InvalidCastException("该字符串未被识别为有效的DateTime。");

            var isParsed = DateTime.TryParse(value.ToString(), out DateTime dateTime);
            if (!isParsed) throw new InvalidCastException("该字符串未被识别为有效的DateTime。");
            return dateTime;
        }
        #endregion

        #region 将布尔形式的 object 对象转换为其等效的 Boolean 的值
        /// <summary>
        /// 将布尔的 <see cref="object"/> 对象转换为其等效的 <see cref="bool"/> 的值
        /// </summary>
        /// <param name="value">指定的 <see cref="object"/> 对象</param>
        /// <returns>
        /// 如果 <see cref="object"/> 对象为 null 或空字符串 ("")，则返回 false；
        /// 如果转换失败，则返回 false；
        /// 如果转换成功，则返回等效的 <see cref="bool"/> 的值。
        /// </returns>
        /// <exception cref="InvalidCastException"> value 参数转换失败。</exception>
        public static bool ToBoolean(this object value)
        {
            if (value.IsNullOrEmpty()) throw new InvalidCastException("该字符串未被识别为有效的布尔值。");

            var isParsed = bool.TryParse(value.ToString(), out bool _b);
            if (!isParsed) throw new InvalidCastException("该字符串未被识别为有效的布尔值。");
            return _b;
        }
        #endregion

        #region 将数字形式的 object 对象转换为其等效的 NullableInt16 的值
        /// <summary>
        /// 将数字的 <see cref="object"/> 对象转换为其等效的 <see cref="Nullable{Int16}"/> 的值
        /// </summary>
        /// <param name="value">指定的 <see cref="object"/> 对象</param>
        /// <returns>
        /// 如果 <see cref="object"/> 对象为 null 或空字符串 ("")，则返回 null；
        /// 如果转换失败，则返回 null；
        /// 如果转换成功，则返回其等效的 <see cref="short"/> 值。
        /// </returns>
        public static short? ToNullableInt16(this object value)
        {
            if (value.IsNullOrEmpty()) return null;

            var isParsed = short.TryParse(value.ToString(), out short i);
            if (!isParsed) return null;
            return i;
        }
        #endregion

        #region 将数字形式的 object 对象转换为其等效的 NullableInt32 的值
        /// <summary>
        /// 将数字的 <see cref="object"/> 对象转换为其等效的 <see cref="Nullable{Int32}"/> 的值
        /// </summary>
        /// <param name="value">指定的 <see cref="object"/> 对象</param>
        /// <returns> 
        /// 如果 <see cref="object"/> 对象为 null 或空字符串 ("")，则返回 null；
        /// 如果转换失败，则返回 null；
        /// 如果转换成功，则返回等效的 <see cref="int"/> 的值。
        /// </returns>
        public static int? ToNullableInt(this object value)
        {
            if (value.IsNullOrEmpty()) return null;

            var isParsed = int.TryParse(value.ToString(), out int i);
            if (!isParsed) return null;
            return i;
        }
        #endregion

        #region 将数字形式的 object 对象转换为其等效的 NullableInt64 的值
        /// <summary>
        /// 将数字的 <see cref="object"/> 对象转换为其等效的 <see cref="Nullable{Int64}"/> 的值
        /// </summary>
        /// <param name="value">指定的 <see cref="object"/> 对象</param>
        /// <returns>
        /// 如果 <see cref="object"/> 对象为 null 或空字符串 ("")，则返回 null；
        /// 如果转换失败，则返回 null；
        /// 如果转换成功，则返回等效的 <see cref="long"/> 的值。
        /// </returns>
        public static long? ToNullableInt64(this object value)
        {
            if (value.IsNullOrEmpty()) return null;

            var isParsed = long.TryParse(value.ToString(), out long i);
            if (!isParsed) return null;
            return i;
        }
        #endregion

        #region 将数字形式的 object 对象转换为其等效的 NullableSingle 的值
        /// <summary>
        /// 将数字的 <see cref="object"/> 对象转换为其等效的 <see cref="Nullable{Single}"/> 的值
        /// </summary>
        /// <param name="value">指定的 <see cref="object"/> 对象</param>
        /// <returns>
        /// 如果 <see cref="object"/> 对象为 null 或空字符串 ("")，则返回 null；
        /// 如果转换失败，则返回 null；
        /// 如果转换成功，则返回等效的 <see cref="float"/> 的值。
        /// </returns>
        public static float? ToNullableSingle(this object value)
        {
            if (value.IsNullOrEmpty()) return null;

            var isParsed = float.TryParse(value.ToString(), out float i);
            if (!isParsed) return null;
            return i;
        }
        #endregion

        #region 将数字形式的 object 对象转换为其等效的 NullableDouble 的值
        /// <summary>
        /// 将数字的 <see cref="object"/> 对象转换为其等效的 <see cref="Nullable{Double}"/> 的值
        /// </summary>
        /// <param name="value">指定的 <see cref="object"/> 对象</param>
        /// <returns>
        /// 如果 <see cref="object"/> 对象为 null 或空字符串 ("")，则返回 null；
        /// 如果转换失败，则返回 null；
        /// 如果转换成功，则返回等效的 <see cref="double"/> 的值。
        /// </returns>
        public static double? ToNullableDouble(this object value)
        {
            if (value.IsNullOrEmpty()) return null;

            var isParsed = double.TryParse(value.ToString(), out double i);
            if (!isParsed) return null;
            return i;
        }
        #endregion

        #region 将数字形式的 object 对象转换为其等效的 NullableDecimal 的值
        /// <summary>
        /// 将数字的 <see cref="object"/> 对象转换为其等效的 <see cref="Nullable{Decimal}"/> 的值
        /// </summary>
        /// <param name="value">指定的 <see cref="object"/> 对象</param>
        /// <returns>
        /// 如果 <see cref="object"/> 对象为 null 或空字符串 ("")，则返回 null；
        /// 如果转换失败，则返回 null；
        /// 如果转换成功，则返回等效的 <see cref="decimal"/> 的值。
        /// </returns>
        public static decimal? ToNullableDecimal(this object value)
        {
            if (value.IsNullOrEmpty()) return null;

            var isParsed = decimal.TryParse(value.ToString(), out decimal i);
            if (!isParsed) return null;
            return i;
        }
        #endregion

        #region 将时间形式的 object 对象转换为其等效的 NullableDateTime 对象
        /// <summary>
        /// 将时间的 <see cref="object"/> 对象转换为其等效的 <see cref="Nullable{DateTime}"/> 对象
        /// </summary>
        /// <param name="value">指定的 <see cref="object"/> 对象</param>
        /// <returns>
        /// 如果 <see cref="object"/> 对象为 null 或空字符串 ("")，，则返回 null；
        /// 如果转换失败，则返回 null；
        /// 如果转换成功，则返回等效的 <see cref="DateTime"/> 的对象。
        /// </returns>
        public static DateTime? ToNullableDateTime(this object value)
        {
            if (value.IsNullOrEmpty()) return null;

            var isParsed = DateTime.TryParse(value.ToString(), out DateTime _d);
            if (!isParsed) return null;
            return _d;
        }
        #endregion

        #region 将布尔形式的 object 对象转换为其等效的 NullableBoolean 的值
        /// <summary>
        /// 将布尔的 <see cref="object"/> 对象转换为其等效的 <see cref="Nullable{Boolean}"/> 的值
        /// </summary>
        /// <param name="value">指定的 <see cref="object"/> 对象</param>
        /// <returns>
        /// 如果 <see cref="object"/> 对象为 null 或空字符串 ("")，则返回 null；
        /// 如果转换失败，则返回 null；
        /// 如果转换成功，则返回等效的 <see cref="bool"/> 的值。
        /// </returns>
        public static bool? ToNullableBoolean(this object value)
        {
            if (value.IsNullOrEmpty()) return null;

            var isParsed = bool.TryParse(value.ToString(), out bool _b);
            if (!isParsed) return null;
            return _b;
        }
        #endregion
    }
}
