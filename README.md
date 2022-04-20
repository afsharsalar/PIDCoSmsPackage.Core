#PIDCoSmsPackage.Core
=======
<div dir="rtl">



PIDCoSmsPackage کتابخانه ای است برای ارسال اس ام اس.


</div>

[![Nuget](https://img.shields.io/nuget/v/PIDCoSmsPackage.Core)](https://www.nuget.org/packages/PIDCoSmsPackage.Core/)
```
PM> Install-Package PIDCoSmsPackage.Core
```
<div dir="rtl">
  <h2>نحوه کار 
</h2>
  
</div>

برای استفاده از این برنامه در برنامه های ASP.Net Core بعد از نصب Nuget بایستی تنظیمات زیر در فایل 
startup.cs در بخش ConfigureServices اعمال گردد.
```csharp
    services.AddHttpClient();            
    services.Add(ServiceDescriptor.Scoped<ISmsService,SmsService>());

```


سپس پس از تزریق وابستگی می توانید به صورت زیر متد ارسال را فراخوانی نمایید
```csharp
await _smsService.Send(new SendViewModel
            {
                Password = "****",
                Username = "*****",
                Folder = "web",
                Number = "500010****",
                ReceiverPhoneNumbers = new List<string>{"091********"},
                SmsText = "تست وب"
            });
```


