using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    public class HomeController
    {
        [Route("sayHello")]
        public string Method1()
        {
            return "Hello from Method1";
        }
    }
}
