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
            if (Convert.ToBoolean(Request.Query["isLoggedIn"]) == false)
            {
                //return Unauthorized("User is not logged in");
                return StatusCode(401);
            }

            // 302 Found - RedirectToActionResult
            //return new RedirectToActionResult("Books", "Store", new { });  // 302 Found
            //return RedirectToAction("Books", "Store", new { id = bookId });

            // 301 Moved Permanently - RedirectToActionResult
            // return new RedirectToActionResult("Books", "Store", new { }, true); // 301 Moved Permanently
            //return RedirectToActionPermanent("Books", "Store", new { id = bookId });

            // 302 Found - RedirectToRouteResult
            //return new LocalRedirectResult($"store/books/{bookId}");
            //return LocalRedirect($"store/books/{bookId}"); // 302 Found

            // 301 Moved Permanently - RedirectToRouteResult
            return new LocalRedirectResult($"store/books/{bookId}", true); // 301 Moved Permanently
            //return LocalRedirectPermanent($"store/books/{bookId}"); // 301 Moved Permanently

            //return Redirect($"store/books/{bookId}"); // 302 Found
            //return RedirectPermanent($"store/books/{bookId}"); // 301 Moved Permanently
        }
    }
}

// http://localhost:5211/bookstore?bookid=5&isLoggedIn=true