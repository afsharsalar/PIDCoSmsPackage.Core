using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PIDCoSmsPackage.Model;

namespace PIDCoSmsPackage.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISmsService _smsService;

        public HomeController(ISmsService smsService)
        {
            _smsService = smsService;
        }

        public async Task<IActionResult> Index()
        {
            await _smsService.Send(new SendViewModel
            {
                Password = "admin!23",
                Username = "superadmin",
                Folder = "web",
                Number = "500010033384311",
                ReceiverPhoneNumbers = new List<string>{"09144484180"},
                SmsText = "تست وب"
            });
            return Content("Sent");
        }
    }
}
