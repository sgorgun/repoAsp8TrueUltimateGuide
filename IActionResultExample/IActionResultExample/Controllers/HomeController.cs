using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("book")]
        public IActionResult Index()
        {
            // BookID should be supplied in the query string
            if (!Request.Query.ContainsKey("bookId"))
            {
                Response.StatusCode = 400;
                return Content("BookID is not supplied");
            }

            // BookID should not be empty
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookId"])))
            {
                Response.StatusCode = 400;
                return Content("BookID should not be empty");
            }

            // BookID should be between 1 and 1000
            int bookId = Convert.ToInt32(ControllerContext.HttpContext.Request.Query["bookId"]);
            if (bookId < 1 || bookId > 1000)
            {
                return Content("BookID should be between 1 and 1000");
            }

            //is logged in should be true
            if (!Convert.ToBoolean(Request.Query["isLoggedIn"]))
            {
                Response.StatusCode = 401;
                return Content("User is not logged in");
            }
            
            return File("/sample.pdf", "application/pdf");
        }
    }
}

// http://localhost:5211/book?bookid=1&isLoggedIn=true