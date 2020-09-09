using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using recipePickerApp.Models;
using recipePickerApp.Service;

namespace recipePickerApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IUserService userService;

        public AdminController(UserManager<User> userManager,IUserService userService)
        {
            this.userManager = userManager;
            this.userService = userService;
        }
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult Home()
        {
            var id = userManager.GetUserId(User);
            return View(userService.getUserById(id));
        }




    }
}