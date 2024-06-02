using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("bookStore")]
        public IActionResult Index()
        
        {
            // BookID should be supplied in the query string
            if (!Request.Query.ContainsKey("bookId"))
            {
                return BadRequest("BookID is not supplied");
            }

            // BookID should not be empty
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookId"])))
            {
                return BadRequest("BookID should not be empty");
            }

            // BookID should be between 1 and 1000
            int bookId = Convert.ToInt32(ControllerContext.HttpContext.Request.Query["bookId"]);
            if (bookId < 1 || bookId > 1000)
            {
                return NotFound("BookID should be between 1 and 1000");
            }

            //is logged in should be true
            if (!Convert.ToBoolean(Request.Query["isLoggedIn"]))
            {
                return Unauthorized("User is not logged in");
            }

            //return new RedirectToActionResult("Books", "Store", new { });  // 302 Found
            return new RedirectToActionResult("Books", "Store", new { }, true); // 301 Moved Permanently
        }
    }
}

// http://localhost:5211/bookstore?bookid=5&isLoggedIn=true