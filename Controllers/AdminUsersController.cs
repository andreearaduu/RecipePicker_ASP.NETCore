using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using recipePickerApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipePickerApp.Controllers
{
        [Authorize(Roles = "Administrator")]
        public class AdminUsersController : Controller
        {
            private readonly IUserService userService;

            public AdminUsersController(IUserService userService)
            {
                this.userService = userService;
            }

            [HttpGet]
            public async Task<IActionResult> Index()
            {
                return View(userService.getAll());
            }

        }
    
}
