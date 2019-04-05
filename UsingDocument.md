# Common 常用组件

## 异步日志

> 命名空间：`using CommonExtention.Common;`

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

<br/>
<br/>

## Json 通用返回格式

> 命名空间：`using CommonExtention.Common;`

``` json
{
  code : 0,
  data : {},
  count : 0,
  message : 'Success'
}
```

- 规范 Json 返回数据的格式。格式中有四个属性，分别是Code、Data、Count、Message。
- Code 为 0 时，表示请求成功，其它数据表示失败。
- Data 表示返回的数据。
- Count 表示返回的数据量，可以用于分页的数据量。
- Message 表示返回的消息，在请求/业务逻辑失败时，返回错误的消息。
- 在控制器中使用时，Mvc 继承 `BasicsController`，WebApi 继承 `BasicsApiController`。
- 单独使用时，引入 `using CommonExtention.HttpResponseFormat;` 命名空间，使用静态类 `JsonResultFormat`。

``` csharp

// 返回成功，用于增、删、改等操作成功时的返回。
ResponseSuccess();


// 返回成功，用于返回单个对象/单条数据。
ResponseSuccess<T>(T data, int count = 1);



// 返回成功，用于返回 List 数据。
ResponseSuccess<T>(List<T> list, int count = 0);



// 返回成功，用于增、删、改等操作成功时的返回。
ResponseSuccess(DataTable dataTable, int count = 0);


// 返回失败，用于返回失败。
ResponseFail(int code = -1, string message = "Unknown error");

```

<br/>
<br/>


## Json 通用网格返回格式

> 命名空间：`using CommonExtention.Common;`  
> 与 `Json 通用返回格式`原理、使用一样，通用网格的定位用于后台、管理系统一类的项目。

``` json
{
  code : 0,
  rows : {},
  total : 0,
  message : 'Success'
}
```

- 规范 Json 返回数据的格式。格式中有四个属性，分别是Code、Rows、Total、Message。
- Code 为 0 时，表示请求成功，其它数据表示失败。
- Rows 表示返回的数据。
- Total 表示返回的数据量，可以用于分页的数据量。
- Message 表示返回的消息，在请求/业务逻辑失败时，返回错误的消息。
- 在控制器中使用时，Mvc 继承 `BasicsController`，WebApi 继承 `BasicsApiController`。
- 单独使用时，引入 `using CommonExtention.HttpResponseFormat;` 命名空间，使用静态类 `JsonResultFormat`。

``` csharp

// 返回成功，用于增、删、改等操作成功时的返回。
ResponseGridResult();


// 返回成功，用于返回单个对象/单条数据。
ResponseGridResult<T>(T data, int count = 1);


// 返回成功，用于返回 List 数据。
ResponseGridResult<T>(List<T> list, int count = 0);


// 返回成功，用于返回 DataTable 数据。
ResponseGridResult(DataTable dataTable, int count = 0);


// 返回失败，用于返回失败。
ResponseGridResult(int code = -1, string message = "Unknown error");

```


<br/>
<br/>

## 发送邮件

> 对 `SmtpClient` 和 `MailMessage` 两个类进行的封装。  
> 命名空间：`using CommonExtention.Common;`、`using CommonExtention.Models;`  
> 使用时需要配置 `EmailServiceConfig` 和 `EmailContent` 两个类。

- `EmailContent` 类说明：  

| 属性           | 类型                   |  说明        |  是否必须  |  默认值  |
| ----------    | -----                  | ------       | --------- | -------- |
| Title         | string                 |  标题、主题   | 是        |          |
| Body          | string                 |  邮件主体     | 是        |          |
| IsHtmlContent | bool                   |  html 内容    | 否        |  false  |
| ReplyAddress  | MailAddress            |  邮件回复地址 | 是        |          |
| Priority      | MailPriority           |  邮件优先级   | 是        | MailPriority.Normal |
| Attachment    | `Collection<Attachment>` |  附件         | 否        |          |

<br/>

- `EmailServiceConfig` 类说明：

| 属性                  | 类型                |  说明                          |  是否必须  |  默认值  |
| ----------            | -----              | ------                        | --------- | -------- |
| Host                  | string             |  Smtp 服务器地址               | 是        |          |
| Port                  | int                |  Smtp 服务器的端口             | 是        |   25     |
| EnableSsl             | bool               |  Smtp 服务器是否启用 SSL 加密   | 否        |  true    |
| EmailAddress          | string             |  邮箱账号                      | 是        |          |
| Password              | string             |  密码                          | 是        |         |
| UseDefaultCredentials | bool               |  系统凭据是否随请求发送         | 否        |  false   |
| DeliveryMethod        | SmtpDeliveryMethod |  Smtp 传输方式                 | 否        | SmtpDeliveryMethod.Network |

<br/>

- 初始化

``` csharp

var email = new Email();

var email = new Email(EmailContent emailContent);

var email = new Email(EmailServiceConfig serviceConfig);

var email = new Email(EmailServiceConfig serviceConfig, EmailContent emailContent);

// 也可以在初始化后配置
email.EmailContent = new EmailContent();
email.ServiceConfig = new EmailServiceConfig();


// 手动释放资源
email.Dispose();


// 使用 using 方法自动释放资源
using(var email = new Email())
{

}

```

<br/>

- 发送

``` csharp

// 接收、抄送、密送
email.Receivers.Add(new MailAddress()); // 接收
email.CarbonCopy.Add(new MailAddress()); // 抄送
email.BlindCarbonCopy.Add(new MailAddress()); // 密送
email.Send();


// 发送给单个地址
email.Send(MailAddress mailAddress);

// 发送给多个地址
email.Send(Collection<MailAddress> mails);

```

<br/>

- 异步发送

> 发送方式与同步相同。此方法不会阻止调用线程，并允许调用方将对象传递给操作完成时调用的方法。  
> .Net Framework 4.0 调用异步不需要 async/await。

 ``` csharp

// 接收、抄送、密送
email.Receivers.Add(new MailAddress()); // 接收
email.CarbonCopy.Add(new MailAddress()); // 抄送
email.BlindCarbonCopy.Add(new MailAddress()); // 密送
email.SendAsync();


// 发送给单个地址
email.SendAsync(MailAddress mailAddress);

// 发送给多个地址
email.SendAsync(Collection<MailAddress> mails);

 ```

<br/>
<br/>

## Excel 操作

