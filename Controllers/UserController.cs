
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using recipePickerApp.Models;
using recipePickerApp.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace recipePickerApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IRecipeService recipeService;
        private readonly UserManager<User> userManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        public UserController(UserManager<User> userManager, 
            IUserService userService,IRecipeService recipeService,
            IWebHostEnvironment webHostEnvironment)
        {
            this.userManager = userManager;
            this.userService = userService;
            this.recipeService = recipeService;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult UserFavoriteRecipes()
        {
            var id = userManager.GetUserId(User);
            var model = userService.getRecipesForUser(id, "favorite");
            return View(model);
        }


        [HttpGet]
        public IActionResult UserOwnRecipes()
        {
            var id = userManager.GetUserId(User);
            IEnumerable<Recipe> model = userService.getRecipesForUser(id, "own");
            if (model == null)
            {
                return View();
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult UserCookedRecipes()
        {
            var id = userManager.GetUserId(User);
            IEnumerable<Recipe> model = userService.getRecipesForUser(id, "cooked");
            return View(model);
        }
        public IActionResult AddOwnRecipes()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOwnRecipes([FromForm]Recipe model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    model.UserId=userManager.GetUserId(User);
                    model.RecipeType = RecipeType.own;
                    userService.addRecipe(model);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
            return RedirectToAction("UserOwnRecipes", "User");
        }

        
       
        public async Task<IActionResult> AddFavoriteRecipes(long recipeId)
        {
            var recipe = recipeService.GetRecipeById(recipeId);
            try
            {
                if (ModelState.IsValid)
                {
                    var newRecipe = new Recipe
                    {
                        Name = recipe.Name,
                        Category = recipe.Category,
                        CookingDecription = recipe.CookingDecription,
                        CookingTime = recipe.CookingTime,
                        Description = recipe.Description,
                        ImageUrl = recipe.ImageUrl,
                        RecipeIngredients = recipe.RecipeIngredients,
                        Reviews = recipe.Reviews,

                    };
                    newRecipe.UserId = userManager.GetUserId(User);
                    newRecipe.RecipeType = RecipeType.favorite;
                    userService.addRecipe(newRecipe);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("UserFavoriteRecipes", "User");
        }

        public async Task<IActionResult> AddCookedRecipes(long recipeId)
        {
            var recipe = recipeService.GetRecipeById(recipeId);
            try
            {
                if (ModelState.IsValid)
                {
                    var newRecipe = new Recipe
                    {
                        Name = recipe.Name,
                        Category = recipe.Category,
                        CookingDecription = recipe.CookingDecription,
                        CookingTime = recipe.CookingTime,
                        Description = recipe.Description,
                        ImageUrl = recipe.ImageUrl,
                        RecipeIngredients = recipe.RecipeIngredients,
                        Reviews = recipe.Reviews,

                    };
                    newRecipe.UserId = userManager.GetUserId(User);
                    newRecipe.RecipeType = RecipeType.cooked;
                    userService.addRecipe(newRecipe);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("UserCookedRecipes", "User");
        }
        [HttpGet]
        public IActionResult AddReview()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddReview([FromForm]Review review, long recipeId)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    review.RecipeId = recipeId;
                    review.UserId = userManager.GetUserId(User);
                    recipeService.addReviewToRecipe(review);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Details", "Recipe");
        }

        public IActionResult user_home()
        {
            var id = userManager.GetUserId(User);
            return View(userService.getUserById(id));
        }


        public IActionResult AddPhoto()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPhoto(PhotoModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                if(uniqueFileName==null)
                {
                    throw new Exception();
                }

                var userId = userManager.GetUserId(User);
                var user = userService.getUserById(userId);
                
                user.ImageUrl= uniqueFileName;

                userService.Update(user);
            }
            return RedirectToAction("user_home", "User");
        }

        public IActionResult AddPhotoToRecipe(long RecipeId)
        {
            RecipePhotoModel model = new RecipePhotoModel();
            model.RecipeId = RecipeId;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPhotoToRecipe(long RecipeId,RecipePhotoModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = RecipeUploadedFile(model);
                if (uniqueFileName == null)
                {
                    throw new Exception();
                }


                var recipe = recipeService.GetRecipeById(RecipeId);

                recipe.ImageUrl = uniqueFileName;

                recipeService.Update(recipe);
            }
            return RedirectToAction("AddOwnRecipe", "User");
        }

        private string UploadedFile(PhotoModel model)
        {
           

            if (model.ProfileImage == null)
            {
                throw new Exception();
            }
           
            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
            //string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
            string uniqueFileName = model.ProfileImage.FileName;
            string filePath = Path.Combine(Path.Combine(webHostEnvironment.WebRootPath, "images"), model.ProfileImage.FileName);
                using (var fileStream = new FileStream(Path.Combine(Path.Combine(webHostEnvironment.WebRootPath, "images"), model.ProfileImage.FileName), FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            
            return uniqueFileName;
        }

        private string RecipeUploadedFile(RecipePhotoModel model)
        {


            if (model.ProfileImage == null)
            {
                throw new Exception();
            }

            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
            //string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
            string uniqueFileName = model.ProfileImage.FileName;
            string filePath = Path.Combine(Path.Combine(webHostEnvironment.WebRootPath, "images"), model.ProfileImage.FileName);
            using (var fileStream = new FileStream(Path.Combine(Path.Combine(webHostEnvironment.WebRootPath, "images"), model.ProfileImage.FileName), FileMode.Create))
            {
                model.ProfileImage.CopyTo(fileStream);
            }

            return uniqueFileName;
        }
    }




}

