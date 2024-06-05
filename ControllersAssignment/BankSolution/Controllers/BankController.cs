using Microsoft.AspNetCore.Mvc;

namespace BankSolution.Controllers
{
    public class BankController : Controller
    {
        // Route to the index page "/"
        [Route("/")]
        public IActionResult Index()
        {
            return Content("Welcome to the Best Bank");
        }

        // Route to the account details page "/account-details"
        [Route("/account-details")]
        public IActionResult AccountDetails()
        {
            var bankAccount = new { accountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000 };
            return Json(bankAccount);
        }

        // Route to the account statement page "/account-statement"
        [Route("/account-statement")]
        public IActionResult AccountStatement()
        {
            // return statement.pdf file from the wwwroot folder
            return File("/statement.pdf", "application/pdf");
        }

        // Return balance of the account "/get-current-balance/{accountNumber}"
        [Route("/get-current-balance/{accountNumber:int?}")]
        public IActionResult GetCurrentBalance(int accountNumber)
        {
            // Get the account number from the URL
            //var accountNumber = Convert.ToInt32(HttpContext.Request.RouteValues["accountNumber"]);

            if (accountNumber == 1001)
            {
                return Content("5000");
            }
            else if (accountNumber != 1001)
            {
                return BadRequest("Account Number should be 1001");
            }
            else
            {
                return NotFound("Account Number should be supplied");
            }
        }
    }
}
