using Microsoft.AspNetCore.Mvc;

namespace recipePickerApp.Controllers
{
    public class ReviewController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
