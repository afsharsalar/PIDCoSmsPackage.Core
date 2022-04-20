using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIDCoSmsPackage.Model;

namespace PIDCoSmsPackage.Test
{
    [TestClass]
    public class SmsServiceTest
    {
        private readonly IServiceProvider _serviceProvider;
        public SmsServiceTest()
        {
            var services = new ServiceCollection();
            services.AddHttpClient();
            services.AddScoped<ISmsService, SmsService>();

            _serviceProvider = services.BuildServiceProvider();
        }
        [TestMethod]
        public async Task Test_Login()
        {
            //arrange
            var model = new SendViewModel
            {
                Username = "", 
                Password = "", 
                Folder = "web", 
                Number = "500010033384311",
                SmsText = "تست",
                ReceiverPhoneNumbers = new List<string>{ "09144484180" }
            };


            //act
            var service = _serviceProvider.GetService<ISmsService>();
            var result=await service.Send(model);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1,result.Count);

        }
    }
}
