# Common 常用组件

## 异步日志

> 命名空间：using CommonExtention.Common;

- 记录异常

``` csharp
AsyncLogger.LogException(Exception exception)
```

- 记录关键信息

``` csharp
AsyncLogger.LogInformation(string information)
```

- 记录 Mvc 请求信息

``` csharp
AsyncLogger.LogMvcRequest(MvcRequest model)
```