﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
