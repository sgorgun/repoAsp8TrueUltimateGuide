using Microsoft.AspNetCore.Mvc;
using ControllersExample.Model;

namespace ControllersExample.Controllers
{
    public class HomeController: Controller
    {
        [Route("home")]
        [Route("/")]
        public ContentResult Index()
        {
            //return new ContentResult { Content = "Hello from Index", ContentType = "text/plain" };

            //return Content("Hello from Index", "text/plain");

            return Content("<h1>Welcome</h1> <h2>Hello from Index</h2>", "text/html");
        }

        [Route("person")]
        public JsonResult Person()
        {
            Person person = new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Age = 30
            };
            //return new JsonResult(person);
            return Json(person);
            //return "{ \"key\": \"value\" }";
        }

        [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")]
        public string Contact()
        {
            return "Hello from Contact";
        }
    }
}
