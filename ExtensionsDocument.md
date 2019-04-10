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