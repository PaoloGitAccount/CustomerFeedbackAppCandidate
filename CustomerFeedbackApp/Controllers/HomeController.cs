using CustomerFeedback.Domain;
using CustomerFeedback.App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace CustomerFeedback.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerFeedbackService _customerFeedbackService;

        public HomeController(ICustomerFeedbackService customerFeedbackService)
        {
            _customerFeedbackService = customerFeedbackService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SaveFeedback(Feedback feedback)
        {
            _customerFeedbackService.SaveFeedback(feedback.FirstName, feedback.Lastname, feedback.Comment);
            return RedirectToAction("Thanks");
        }

        public IActionResult Thanks()
        {
            return View();
        }
    }
}
