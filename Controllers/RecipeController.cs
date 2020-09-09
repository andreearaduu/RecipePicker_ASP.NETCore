using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using recipePickerApp.Models;
using recipePickerApp.Service;
namespace recipePickerApp.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeService service;
        private readonly IWebHostEnvironment webHostEnvironment;

        public RecipeController(IRecipeService service,IWebHostEnvironment webHostEnvironment)
        {
           this.service=service;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Recipe> model = service.getAllRecipes();
            return View(model);
        }
        [Authorize]
        public IActionResult AddRecipe()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddRecipe([Bind("RecipeId,Name,Description,ImageUrl,CookingDecription,CookingTime,Category,RecipeType")]Recipe model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.AddRecipe(model);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }


        public IActionResult AddReview()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddReview([Bind("ReviewId,Description,Stars,DateTime,RecipeId,UserId")] Review model, long recipeId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Review review = new Review();
                    review.Description = model.Description;
                    review.DateTime = model.DateTime;
                    review.Stars = model.Stars;
                    review.Recipe = model.Recipe;
                    review.User = model.User;

                    //service.addReviewToRecipe(review, recipeId);


                    //if (isNew)
                    //{
                    //    studentRepository.SaveStudent(student);
                    //}
                    //else
                    //{
                    //    studentRepository.UpdateStudent(student);
                    //}
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Details");
        }


        [HttpGet]
        public IActionResult Details(long id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            RecipeViewModel _recipeViewModel = new RecipeViewModel();

            var recipe = service.GetRecipeById((long)id);
            ICollection<Ingredient> ingredients = service.getIngredientsForRecipe((long)id);
            ICollection<Review> reviews = service.getReviewsForRecipe((long)id);

            _recipeViewModel.recipe = recipe;
            _recipeViewModel.ingredients = ingredients;
            _recipeViewModel.reviews = reviews;
            if (recipe == null)
            {
                return NotFound();
            }

            return View(_recipeViewModel);
        }
        [HttpGet]
        public IActionResult CategoryRecipes(string category)
        {
            ICollection<Recipe> recipes = service.GetRecipesByCategory(category);
            return View(recipes);
        }

        // GET: Recipe/Details/5
        [HttpGet]
        public async Task<IActionResult> SearchRecipes(string recipeCategory, string searchString)
        {


          var recipes = service.GetRecipesByCategoryAndName(recipeCategory, searchString);

            var recipeCategoryView = new RecipeCategoryView
            {
                Categories = new SelectList(await service.getAllCategoriesAsString().Distinct().ToListAsync()),
                Recipes =  recipes.ToList()
            };
            return View(recipeCategoryView);
        }
        public IActionResult Category()
        {
            return View();
        }

        public IActionResult Popular_recipe()
        {
            return View();
        }

        public IActionResult AddPhoto()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPhoto(PhotoModel model,long id)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                if (uniqueFileName == null)
                {
                    throw new Exception();
                }

              
                var recipe = service.GetRecipeById(id);

                recipe.ImageUrl = uniqueFileName;

                service.Update(recipe);
            }
            return RedirectToAction("user_home", "User");
        }

        private string UploadedFile(PhotoModel model)
        {


            if (model.ProfileImage == null)
            {
                throw new Exception();
            }

            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
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
