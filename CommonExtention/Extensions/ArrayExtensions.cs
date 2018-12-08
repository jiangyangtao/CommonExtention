using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace CommonExtention.Extensions
{
    /// <summary>
    /// <see cref="Array"/> 扩展
    /// </summary>
    public static class ArrayExtensions
    {
        #region int[]转string[]
        /// <summary>
        /// int[] 转string[]
        /// </summary>
        /// <param name="intArr">int[]</param>
        /// <returns>string[]</returns>
        public static string[] ToStringArray(this int[] intArr)
        {
            return Array.ConvertAll(intArr, a => a.ToString());
        }
        #endregion

        #region string[]转int[]
        /// <summary>
        /// string[]转int[]
        /// </summary>
        /// <param name="strArr">string[]</param>
        /// <returns>int[]</returns>
        public static int[] ToIntArray(this string[] strArr)
        {
            return Array.ConvertAll(strArr, a => a.ToInt());
        }
        #endregion

        #region string[]转decimal[]
        /// <summary>
        /// string[]转decimal[]
        /// </summary>
        /// <param name="strArr">string[]</param>
        /// <returns>decimal[]</returns>
        public static decimal[] ToDecimalArray(this string[] strArr)
        {            
            return Array.ConvertAll(strArr, a => a.ToDecimal());
        }
        #endregion        

        #region decimal[]转string[]
        /// <summary>
        /// decimal[]转string[]
        /// </summary>
        /// <param name="decimalArr">decimal[]</param>
        /// <returns>string[]</returns>
        public static string[] ToStringArray(this decimal[] decimalArr)
        {
            return Array.ConvertAll(decimalArr, a => a.ToString());
        }
        #endregion

        #region 检测int[]序列中是否存在与条件相匹配的元素
        /// <summary>
        /// 检测int[]序列中是否存在与条件相匹配的元素
        /// </summary>
        /// <param name="intArray">int[]</param>
        /// <param name="value">value</param>
        /// <returns>序列中存在与条件相匹配的元素，则返回true；否则返回false;</returns>
        public static bool HasValue(this int[] intArray, int value)
        {
            return intArray.Contains(value);
        }
        #endregion

        #region 检测string[]序列中是否存在与条件相匹配的元素
        /// <summary>
        /// 检测string[]序列中是否存在与条件相匹配的元素
        /// </summary>
        /// <param name="stringArray">string[]</param>
        /// <param name="s">s</param>
        /// <returns>序列中存在与条件相匹配的元素，则返回true；否则返回false;</returns>
        public static bool HasValue(this string[] stringArray, string s)
        {
            return stringArray.Contains(s);
        }
        #endregion

        #region 将string转换为string[](默认为英文逗号分隔)
        /// <summary>
        /// 将string转换为string[](默认为英文逗号分割)
        /// </summary>
        /// <param name="s">string</param>
        /// <param name="symbol">分隔符，默认为英文逗号</param>
        /// <returns>string[]</returns>
        public static string[] ToSplitArray(this string s, char symbol = ',')
        {
            if (s.IsNullOrEmpty()) return new string[0];
            return s.Split(symbol);
        }
        #endregion

        #region 将string[]序列中的元素转化为字符串(默认英文逗号分隔)
        /// <summary>
        /// 将元素转化为字符串(默认英文逗号分隔)
        /// </summary>
        /// <param name="strArr">string[]</param>
        /// <param name="symbol">分隔符号</param>
        /// <returns>英文逗号分隔的字符串</returns>
        public static string ToStringValue(this string[] strArr, string symbol = ",")
        {
            var str = string.Empty;
            if (strArr.Length == 0) return str;
            for (int i = 0; i < strArr.Length; i++)
            {
                str += strArr[i];
                if (i != strArr.Length - 1) str += symbol;
            }
            return str;
        }
        #endregion

        #region 将int[]序列中的元素转化为字符串(默认英文逗号分隔)
        /// <summary>
        /// 将元素转化为字符串(默认英文逗号分隔)
        /// </summary>
        /// <param name="intArr">int[]</param>
        /// <param name="symbol">分隔符号</param>
        /// <returns>英文逗号分隔的字符串</returns>
        public static string ToStringValue(this int[] intArr, string symbol = ",")
        {
            var str = string.Empty;
            if (intArr.Length == 0) return str;
            for (int i = 0; i < intArr.Length; i++)
            {
                str += intArr[i];
                if (i != intArr.Length - 1) str += symbol;
            }
            return str;
        }
        #endregion

        #region 统计与条件相匹配的元素在int[]序列中出现过的次数
        /// <summary>
        /// 统计与条件相匹配的元素在序列中出现过的次数
        /// </summary>
        /// <param name="intArray">int[]</param>
        /// <param name="value">value</param>
        /// <returns>与条件相匹配的元素在int[]序列中出现过的次数</returns>
        public static int CountIndex(this int[] intArray, int value)
        {
            if (!intArray.Contains(value)) return 0;
            var count = 0;
            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i] == value) count++;
            }
            return count;
        }
        #endregion

        #region 统计与条件相匹配的元素在string[]序列中出现过的次数
        /// <summary>
        /// 统计与条件相匹配的元素在序列中出现过的次数
        /// </summary>
        /// <param name="stringArray">string[]</param>
        /// <param name="value">value</param>
        /// <returns>与条件相匹配的元素在string[]序列中出现过的次数</returns>
        public static int CountIndex(this string[] stringArray, string value)
        {
            if (!stringArray.Contains(value)) return 0;
            var count = 0;
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (stringArray[i] == value) count++;
            }
            return count;
        }
        #endregion

        #region 统计与条件相匹配和包含的元素在string[]序列中出现过的次数
        /// <summary>
        /// 统计与条件相匹配和包含的元素在序列中出现过的次数
        /// </summary>
        /// <param name="stringArray">string[]</param>
        /// <param name="value">value</param>
        /// <returns>与条件相匹配的元素在string[]序列中出现过的次数</returns>
        public static int CountContainIndex(this string[] stringArray, string value)
        {
            if (!stringArray.Contains(value)) return 0;
            var count = 0;
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (stringArray[i].Contains(value)) count++;
            }
            return count;
        }
        #endregion

        #region 寻找与条件相匹配的元素，并返回整个int[]序列中第一个匹配元素的从零开始的索引
        /// <summary>
        /// 寻找与条件相匹配的元素，并返回整个int[]序列中第一个匹配元素的从零开始的索引
        /// </summary>
        /// <param name="intArr">int[]</param>
        /// <param name="value">与条件相匹配的元素</param>
        /// <returns>int[]序列中第一个匹配元素的从零开始的索引</returns>
        public static int FindFirstIndex(this int[] intArr, int value)
        {
            if (intArr.Length == 0) return -1;
            if (!intArr.Contains(value)) return -1;

            for (int i = 0; i < intArr.Length; i++)
            {
                if (intArr[i] == value) return i;
            }
            return -1;
        }
        #endregion

        #region 寻找与条件相匹配的元素，并返回整个string[]序列中第一个匹配元素的从零开始的索引
        /// <summary>
        /// 寻找与条件相匹配的元素，并返回整个string[]序列中第一个匹配元素的从零开始的索引
        /// </summary>
        /// <param name="stringArr">string[]</param>
        /// <param name="value">与条件相匹配的元素</param>
        /// <returns>string[]序列中第一个匹配元素的从零开始的索引</returns>
        public static int FindFirstIndex(this string[] stringArr, string value)
        {
            if (stringArr.Length == 0) return -1;
            if (!stringArr.Contains(value)) return -1;
            for (int i = 0; i < stringArr.Length; i++)
            {
                if (stringArr[i] == value) return i;
            }
            return -1;
        }
        #endregion

        #region 寻找与条件相匹配的元素，并返回整个int[]序列中第一个匹配元素的从结尾开始的索引
        /// <summary>
        /// 寻找与条件相匹配的元素，并返回整个int[]序列中第一个匹配元素的从结尾开始的索引
        /// </summary>
        /// <param name="intArr">int[]</param>
        /// <param name="value">与条件相匹配的元素</param>
        /// <returns>int[]序列中第一个匹配元素的从结尾开始的索引</returns>
        public static int FindLastIndex(this int[] intArr, int value)
        {
            if (intArr.Length == 0) return -1;
            if (!intArr.Contains(value)) return -1;
            for (int i = intArr.Length - 1; i > 0; i--)
            {
                if (intArr[i] == value) return i;
            }
            return -1;
        }
        #endregion

        #region 寻找与条件相匹配的元素，并返回整个string[]序列中第一个匹配元素的从结尾开始的索引
        /// <summary>
        /// 寻找与条件相匹配的元素，并返回整个string[]序列中第一个匹配元素的从结尾开始的索引
        /// </summary>
        /// <param name="stringArr">string[]</param>
        /// <param name="value">与条件相匹配的元素</param>
        /// <returns>string[]序列中第一个匹配元素的从结尾开始的索引</returns>
        public static int FindLastIndex(this string[] stringArr, string value)
        {
            if (stringArr.Length == 0) return -1;
            if (!stringArr.Contains(value)) return -1;
            for (int i = stringArr.Length - 1; i > 0; i--)
            {
                if (stringArr[i] == value) return i;
            }
            return -1;
        }
        #endregion        

        #region 寻找与条件相匹配的元素，并返回整个int[]序列中的每一个匹配元素的索引
        /// <summary>
        /// 寻找与条件相匹配的元素，并返回整个int[]序列中的每一个匹配元素的索引
        /// </summary>
        /// <param name="intArray">int[]</param>
        /// <param name="value">value</param>
        /// <returns>int[]序列中的每一个匹配元素的索引</returns>
        public static int[] FindIndex(this int[] intArray, int value)
        {
            if (!intArray.Contains(value)) return new int[0];
            var str = string.Empty;
            if (intArray.Length == 0) return new int[0];
            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i] == value)
                {
                    str += i;
                    if (i != intArray.Length - 1) str += ",";
                }
            }
            return str.ToSplitArray().ToIntArray();
        }
        #endregion

        #region 寻找与条件相匹配的元素，并返回整个string[]序列中的每一个匹配元素的索引
        /// <summary>
        /// 寻找与条件相匹配的元素，并返回整个string[]序列中的每一个匹配元素的索引
        /// </summary>
        /// <param name="stringArray">string[]</param>
        /// <param name="value">value</param>
        /// <returns>string[]序列中的每一个匹配元素的索引</returns>
        public static int[] FindIndex(this string[] stringArray, string value)
        {
            if (!stringArray.Contains(value)) return new int[0];

            var str = string.Empty;
            if (stringArray.Length == 0) return new int[0];
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (stringArray[i] == value)
                {
                    str += i;
                    if (i != stringArray.Length - 1) str += ",";
                }
            }
            return str.ToSplitArray().ToIntArray();
        }
        #endregion

        #region 移除与条件相匹配的所有元素，并返回一个新的int[]
        /// <summary>
        /// 移除与条件相匹配的所有元素，并返回一个新的int[]
        /// </summary>
        /// <param name="intArray">int[]</param>
        /// <param name="value">value</param>
        /// <returns>int[]</returns>
        public static int[] Remove(this int[] intArray, int value)
        {
            if (!intArray.Contains(value)) return intArray;

            var indexArr = intArray.FindIndex(value);
            if (indexArr.Length == 0) return intArray;

            var index = 0;
            var newArr = new int[intArray.Length - indexArr.Length];
            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i] != value) newArr[index++] = intArray[i];
            }
            return newArr;
        }
        #endregion

        #region 移除与条件相匹配的所有元素，并返回一个新的string[]
        /// <summary>
        /// 移除与条件相匹配的所有元素，并返回一个新的string[]
        /// </summary>
        /// <param name="stringArray">string[]</param>
        /// <param name="value">value</param>
        /// <returns>一个新的string[]</returns>
        public static string[] Remove(this string[] stringArray, string value)
        {
            if (!stringArray.Contains(value)) return stringArray;

            var indexArr = stringArray.FindIndex(value);
            if (indexArr.Length == 0) return stringArray;

            var index = 0;
            var newArr = new string[stringArray.Length - indexArr.Length];
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (stringArray[i] != value) newArr[index++] = stringArray[i];
            }
            return newArr;
        }
        #endregion

        #region 移除序列中的指定索引的元素，并返回一个新的int[]
        /// <summary>
        /// 移除序列中的指定索引的元素，并返回一个新的序列
        /// </summary>
        /// <param name="intArray">int[]</param>
        /// <param name="index">index</param>
        /// <returns>一个新的int[]</returns>
        public static int[] RemoveAt(this int[] intArray, int index)
        {
            if (index < 0 || index > intArray.Length - 1) return intArray;
            var newArr = new int[intArray.Length - 1];
            var _index = 0;
            for (int i = 0; i < intArray.Length; i++)
            {
                if (i != index) newArr[_index++] = intArray[i];
            }
            return newArr;
        }
        #endregion      

        #region 移除序列中的指定索引的元素，并返回一个新的string[]
        /// <summary>
        /// 移除序列中的指定索引的元素，并返回一个新的序列
        /// </summary>
        /// <param name="stringArray">string[]</param>
        /// <param name="index">index</param>
        /// <returns>一个新的string[]</returns>
        public static string[] RemoveAt(this string[] stringArray, int index)
        {
            if (index < 0 || index > stringArray.Length - 1) return stringArray;
            var newArr = new string[stringArray.Length - 1];
            var _index = 0;
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (i != index) newArr[_index++] = stringArray[i];
            }
            return newArr;
        }
        #endregion

        #region 移除int[]序列的所有元素，并返回一个新的int[]
        /// <summary>
        /// 移除int[]序列的所有元素，并返回一个新的int[]
        /// </summary>
        /// <param name="intArray"></param>
        /// <returns>一个新的int[]</returns>
        public static int[] RemoveAll(this int[] intArray)
        {
            return new int[0];
        }
        #endregion

        #region 移除string[]序列的所有元素，并返回一个新的string[]
        /// <summary>
        /// 移除string[]序列的所有元素，并返回一个新的string[]
        /// </summary>
        /// <param name="strArray"></param>
        /// <returns>一个新的string[]</returns>
        public static string[] RemoveAll(this string[] strArray)
        {
            return new string[0];
        }
        #endregion

        #region 在int[]序列的起始处插入指定的元素，并返回一个新的int[]
        /// <summary>
        /// 在int[]序列的起始处插入指定的元素，并返回一个新的int[]
        /// </summary>
        /// <param name="intArray"></param>
        /// <param name="value"></param>
        /// <returns>一个新的int[]</returns>
        public static int[] Insert(this int[] intArray, int value)
        {
            var _arr = new int[intArray.Length + 1];
            _arr[0] = value;
            for (int i = 1; i < intArray.Length; i++)
            {
                _arr[i] = intArray[i - 1];
            }
            return _arr;
        }
        #endregion

        #region 在string[]序列的起始处插入指定的元素，并返回一个新的string[]
        /// <summary>
        /// 在string[]序列的起始处插入指定的元素，并返回一个新的string[]
        /// </summary>
        /// <param name="strArray"></param>
        /// <param name="value"></param>
        /// <returns>一个新的string[]</returns>
        public static string[] Insert(this string[] strArray, string value)
        {
            var _arr = new string[strArray.Length + 1];
            _arr[0] = value;
            for (int i = 1; i < strArray.Length; i++)
            {
                _arr[i] = strArray[i - 1];
            }
            return _arr;
        }
        #endregion

        #region 在int[]序列的结尾处插入指定的元素，并返回一个新的int[]
        /// <summary>
        /// 在int[]序列的结尾处插入指定的元素，并返回一个新的int[]
        /// </summary>
        /// <param name="intArray"></param>
        /// <param name="value"></param>
        /// <returns>一个新的int[]</returns>
        public static int[] Add(this int[] intArray, int value)
        {
            var _arr = new int[intArray.Length + 1];
            for (int i = 0; i < intArray.Length; i++)
            {
                _arr[i] = intArray[i];
            }
            _arr[intArray.Length] = value;
            return _arr;
        }
        #endregion

        #region 在string[]序列的结尾处插入指定的元素，并返回一个新的string[]
        /// <summary>
        /// 在string[]序列的结尾处插入指定的元素，并返回一个新的string[]
        /// </summary>
        /// <param name="strArray"></param>
        /// <param name="value"></param>
        /// <returns>一个新的string[]</returns>
        public static string[] Add(this string[] strArray, string value)
        {
            var _arr = new string[strArray.Length + 1];
            for (int i = 0; i < strArray.Length; i++)
            {
                _arr[i] = strArray[i];
            }
            _arr[strArray.Length] = value;
            return _arr;
        }
        #endregion

        #region 从int[]序列中指定的索引处移除一定范围的元素，并返回一个新的int[]
        /// <summary>
        /// 从int[]序列中指定的索引处移除一定范围的元素，并返回一个新的int[]
        /// </summary>
        /// <param name="intArray"></param>
        /// <param name="index">要移除的元素的范围从零开始的起始索引</param>
        /// <param name="count">要移除的元素数</param>
        /// <returns></returns>
        public static int[] RemoveRange(this int[] intArray, int index, int count)
        {
            if (index < 0 || index >= intArray.Length) throw new Exception("指定的索引超出了数组界限。");
            if ((index + count) >= intArray.Length) throw new Exception("指定索引处的范围超出了数组界限。");
            var _arr = new int[intArray.Length - count];
            var j = 0;
            for (int i = 0; i < intArray.Length; i++)
            {
                if (i >= index && i < (index + count)) continue;
                _arr[j++] = intArray[i];
            }
            return _arr;
        }
        #endregion     

        #region 从string[]序列中指定的索引处移除一定范围的元素，并返回一个新的string[]
        /// <summary>
        /// 从string[]序列中指定的索引处移除一定范围的元素，并返回一个新的string[]
        /// </summary>
        /// <param name="strArray"></param>
        /// <param name="index">要移除的元素的范围从零开始的起始索引</param>
        /// <param name="count">要移除的元素数</param>
        /// <returns></returns>
        public static string[] RemoveRange(this string[] strArray, int index, int count)
        {
            if (index < 0 || index >= strArray.Length) throw new Exception("指定的索引超出了数组界限。");
            if ((index + count) >= strArray.Length) throw new Exception("指定索引处的范围超出了数组界限。");
            var _arr = new string[strArray.Length - count];
            var j = 0;
            for (int i = 0; i < strArray.Length; i++)
            {
                if (i >= index && i < (index + count)) continue;
                _arr[j++] = strArray[i];
            }
            return _arr;
        }
        #endregion

        #region 将指定的Byte[]序列转换为 System.Drawing.Image
        /// <summary>
        /// 将指定的Byte[]序列转换为 <see cref="Image"/> 对象
        /// </summary>
        /// <param name="value">要转换的Byte[]</param>
        /// <returns>转换后的  <see cref="Image"/></returns>
        public static Image ToImage(this byte[] value)
        {
            var ms = new MemoryStream(value);
            return Image.FromStream(ms);
        }
        #endregion

        #region 将指定的Byte[]序列转换为 Base64 编码的字符串
        /// <summary>
        /// 将指定的Byte[]序列转换为 Base64 编码的字符串
        /// </summary>
        /// <param name="value">要转换的Byte[]</param>
        /// <returns>转换后的字符串表示形式，以 Base64 表示</returns>
        public static string ToBase64String(this byte[] value)
        {
            return Convert.ToBase64String(value, 0, value.Length);
        }
        #endregion

        #region 将指定的Byte[]序列转换为图片的 Base64 编码的字符串
        /// <summary>
        /// 将指定的Byte[]序列转换为图片的 Base64 编码的字符串
        /// </summary>
        /// <param name="value">要转换的Byte[]</param>
        /// <returns>转换图片后的字符串表示形式，以 Base64 表示</returns>
        public static string ToImageBase64String(this byte[] value)
        {
            return "data:image/jpeg;base64," + Convert.ToBase64String(value, 0, value.Length);
        }
        #endregion
    }
}
