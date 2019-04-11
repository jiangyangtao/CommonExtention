# Extensions 扩展

> 统一命名空间：`using CommonExtention.Extensions;`  

## Array 扩展

> 部分代码尚未测试，所以没有写进文档，请谨慎使用。

- 将一种将当前数组转换为另一种类型的数组

``` csharp

var intArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
var stringArray = intArray.ConvertAll(a => a.ToString());

```

- 将当前数组转换为 string[]

``` csharp

var intArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
var stringArray = intArray.ToStringArray();

```

- 将当前字符串换为 string[]

``` csharp

var str = "1,2,3,4,5,6,7,8,9";
var stringArray = str.ToSplitArray();

```

- 将当前数组转化为字符串的表示形式

``` csharp

var stringArray = new string[]{"1","2","3","4","5","6","7","8","9"};
var str = stringArray.ToStringValue();

// output: "1,2,3,4,5,6,7,8,9"

```

- 对当前数组的每个元素执行指定操作

``` csharp

var intArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

// ForEach 扩展不可使用 continue
intArray.ForEach(item =>
{
    // TO DO
});

```

- 对当前数组的每个元素执行指定操作

``` csharp

var intArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

// ForEach 扩展不可使用 continue
intArray.ForEach((item, index) =>
{
    // TO DO
});

```

<br />
<br />

## Database 扩展

- 创建一个原始 Sql 查询，将该查询的结果返回给 DataTable

``` csharp

DbContext.Database.SqlQueryToDataTable(sql, parameters);

```

- 创建一个原始 Sql 查询，将该查询的结果返回给 DataSet

``` csharp

DbContext.Database.SqlQueryToDataSet(sql, parameters);

```

<br />
<br />

## DataColumnCollection 扩展

- 对 DataColumnCollection 的每个元素执行指定操作

``` csharp

DataTable.Columns.ForEach(item =>
{
    // TO DO
});

```

- 对 DataColumnCollection 的每个元素执行指定操作

``` csharp

DataTable.Columns.ForEach((item, index) =>
{
    // TO DO
});

```

<br />
<br />

## DataRowCollection 扩展

- 对 DataRowCollection 的每个元素执行指定操作

``` csharp

DataTable.Rows.ForEach(item =>
{
    // TO DO
});

```

- 对 DataRowCollection 的每个元素执行指定操作

``` csharp

DataTable.Rows.ForEach((item, index) =>
{
    // TO DO
});

```

<br />
<br />

## DataSet 扩展

- 将当前 DataSet 对象转换为 Json 数组字符串

``` csharp

DataSet.ToJson(formatting);

```

- 将当前 DataSet 对象转换为 Json 数组字符串

``` csharp

DataSet.ToJson(settings);

```

- 将当前 DataSet 对象转换为 Json 数组字符串

``` csharp

DataSet.ToJson(converters);

```

- 将当前 DataSet 对象转换为 Json 数组字符串

``` csharp

DataSet.ToJson(formatting, settings);

```

- 将当前 DataSet 对象转换为 Json 数组字符串

``` csharp

DataSet.ToJson(formatting, converters);

```

<br />
<br />

## DataTableCollection 扩展

- 对 DataTableCollection 的每个元素执行指定操作

``` csharp

DataSet.Tables.ForEach(item =>
{
    // TO DO
});

```

- 对 DataTableCollection 的每个元素执行指定操作

``` csharp

DataTable.Rows.ForEach((item, index) =>
{
    // TO DO
});

```

<br />
<br />

## DataTable 扩展

- 将当前 DataTable 对象转换为 Json 字符串

``` csharp

DataTable.ToJsonString(formatting);

```

- 将当前 DataTable 对象转换为 Json 数组字符串

``` csharp

DataTable.ToJsonArray(formatting);

```

- 将当前 DataTable 对象转换为 Json 数组字符串

``` csharp

DataTable.ToJsonArray(settings);

```

- 将当前 DataTable 对象转换为 Json 数组字符串

``` csharp

DataTable.ToJsonArray(converters);

```

- 将当前 DataTable 对象转换为 Json 数组字符串

``` csharp

DataTable.ToJsonArray(formatting, settings);

```

- 将当前 DataTable 对象转换为 Json 数组字符串

``` csharp

DataTable.ToJsonArray(formatting, converters);

```

- 将当前 DataTable 对象转换为 List

``` csharp

DataTable.ToList<T>();

```

- 将当前 DataTable 对象用异步方式转换为 List

``` csharp

async DataTable.ToListAsync<T>();

```

- 将当前 DataTable 对象转换为 ArrayList 对象

``` csharp

DataTable.ToArrayList();

```

- 将当前 DataTable 对象写入 MemoryStream

``` csharp

DataTable.WriteToMemoryStream(action, sheetsName);

```

- 将当前 DataTable 对象用异步方式写入 MemoryStream

``` csharp

async DataTable.WriteToMemoryStreamAsync(action, sheetsName);

```

- 清除当前 DataTable 对象的空行

``` csharp

DataTable.ClearEmptyRow();

```

<br />
<br />

## DateTime 扩展

- Sql Server 数据库 DateTime 初始值

``` csharp

// 公元 1900 年 1 月 1 号 00 点 00 分 00 秒 000 毫秒
DateTimeExtensions.MsSQLDateTimeInitial

```

- Sql Server 数据库 DateTime 最小值

``` csharp

// 公元 1900 年 1 月 1 号 00 点 00 分 00 秒 000 毫秒
DateTimeExtensions.MsSQLDateTimeMinValue

```

- Sql Server 数据库 DateTime 最大值

``` csharp

// 公元 9999 年 12 月 31 号 11 点 59 分 59 秒 999 毫秒
DateTimeExtensions.MsSQLDateTimeMaxValue

```

- MySql 数据库 DateTime 初始值

``` csharp

// 公元 1753 年 1 月 1 号 00 点 00 分 00 秒 000 毫秒
DateTimeExtensions.MySqlDateTimeInitial

```

- MySql 数据库 DateTime 最小值

``` csharp

// 公元 1753 年 1 月 1 号 00 点 00 分 00 秒 000 毫秒
DateTimeExtensions.MySqlDateTimeMinValue

```

- MySql 数据库 DateTime 最大值

``` csharp

// 公元 9999 年 12 月 31 号 11 点 59 分 59 秒 999 毫秒
DateTimeExtensions.MySqlDateTimeMaxValue

```

- 将当前 DateTime 实例转换为 Unix 时间

``` csharp

DateTime.Now.ToUnixTime();

```

- 将当前 DateTime 实例转换为格式化后的日期的字符串表示形式

``` csharp

// 默认格式：yyyy-MM-dd
DateTime.Now.ToFormatDate();

```

- 将当前 DateTime 实例转换为格式化后的日期时间的字符串表示形式

``` csharp

// 默认格式：yyyy-MM-dd HH:mm:ss
DateTime.Now.ToFormatDateTime();

```

- 从当前 DateTime 实例中计算出与当前时间的时间差

``` csharp

DateTime.TimeRange();

```

- 从当前 DateTime 实例中计算出与当前时间之前的时间差

``` csharp

DateTime.BeforeTimeRange();

```

- 从当前 DateTime 实例中计算出与当前时间之后的时间差

``` csharp

DateTime.AfterTimeRange();

```

- 从当前 DateTime 实例中取得当前月的第一天

``` csharp

DateTime.Now.FirstDayOfMonth();

```

- 从当前 DateTime 实例中取得当前月的最后一天

``` csharp

DateTime.Now.LastDayOfMonth();

```

- 从当前 DateTime 实例中取得当前周以星期天开始的第一天

``` csharp

DateTime.Now.FirstDayOfWeekFromSunday();

```

- 从当前 DateTime 实例中取得当前周以星期一开始的第一天

``` csharp

DateTime.Now.FirstDayOfWeekFromMonday();

```

- 从当前 DateTime 实例中取得当前周以星期天开始的最后一天

``` csharp

DateTime.Now.LastDayOfWeekFromSunday();

```

- 从当前 DateTime 实例中取得当前周以星期一开始的最后一天

``` csharp

DateTime.Now.LastDayOfWeekFromMonday();

```

<br />
<br />

## decimal 扩展

- 将此实例的数值转换为其千分位的字符串表示形式

``` csharp

decimal.ToThousand();

```

<br />
<br />

## double 扩展

- 返回 length 对应的 Size

``` csharp

double.FileSize();

```

- 将此实例的数值转换为其千分位的字符串表示形式

``` csharp

double.ToThousand();

```