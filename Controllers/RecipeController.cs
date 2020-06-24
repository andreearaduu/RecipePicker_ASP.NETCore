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
using recipePickerApp.DataContext;
using recipePickerApp.Models;
using recipePickerApp.Repository;
using recipePickerApp.Service;
//sa fac service cu fiecare entitate, ingredient, review
//sa adaug un review, ingrediente,
//sa fac buton de edit la reteta
//sa adaug un user in db si sa lucrez pe el cu reteta fav si cooked, own
//daca am timp la pagina pricnipala sa adaug actions
//la reteta populare actions
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
        public async Task<IActionResult> AddRecipe([Bind("RecipeId,Name,Description,ImageUrl,CookingDecription,CookingTime,Category,RecipeType")]Recipe model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                //    Recipe recipe = new Recipe();
                //    recipe.CookingDecription = model.CookingDecription;
                //    recipe.Category = model.Category;
                //    recipe.CookingTime = model.CookingTime;
                //    recipe.Description = model.Description;
                //    recipe.Name = model.Name;
                //    recipe.RecipeType = RecipeType.own;
                //    recipe.ImageUrl = model.ImageUrl;
                  
                    service.AddRecipe(model);
                   
                   
        
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }


        //public IActionResult AddReview()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddReview([Bind("ReviewId,Description,Stars,DateTime,RecipeId,UserId")] Review model,long recipeId)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            Review review = new Review();
        //            review.Description = model.Description;
        //            review.DateTime = model.DateTime;
        //            review.Stars = model.Stars;
        //            review.Recipe = model.Recipe;
        //            review.User = model.User;
        //            service.addReviewToRecipe(review, recipeId);


        //            //if (isNew)
        //            //{
        //            //    studentRepository.SaveStudent(student);
        //            //}
        //            //else
        //            //{
        //            //    studentRepository.UpdateStudent(student);
        //            //}
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return RedirectToAction("Details");
        //}


        [HttpGet]
        public async Task<IActionResult> Details(long id)
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

        // GET: Recipe
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Recipes.ToListAsync());
        //}

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
        public async Task<IActionResult> AddPhoto(PhotoModel model,long id)
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
            //string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
            string uniqueFileName = model.ProfileImage.FileName;
            string filePath = Path.Combine(Path.Combine(webHostEnvironment.WebRootPath, "images"), model.ProfileImage.FileName);
            using (var fileStream = new FileStream(Path.Combine(Path.Combine(webHostEnvironment.WebRootPath, "images"), model.ProfileImage.FileName), FileMode.Create))
            {
                model.ProfileImage.CopyTo(fileStream);
            }

            return uniqueFileName;
        }
        //// GET: Recipe/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Recipe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("RecipeId,Name,Description,CookingDecription,CookingTime,Category,RecipeType")] Recipe recipe)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(recipe);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(recipe);
        //}

        // GET: Recipe/Edit/5
        //public async Task<IActionResult> Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var recipe = await _context.FavoriteRecipes.FindAsync(id);
        //    if (recipe == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(recipe);
        //}

        // POST: Recipe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(long id, [Bind("RecipeId,Name,Description,CookingDecription,CookingTime,Category,RecipeType")] Recipe recipe)
        //{
        //    if (id != recipe.RecipeId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(recipe);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!RecipeExists(recipe.RecipeId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(recipe);
        //}

        //    // GET: Recipe/Delete/5
        //    public async Task<IActionResult> Delete(long? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var recipe = await _context.FavoriteRecipes
        //            .FirstOrDefaultAsync(m => m.RecipeId == id);
        //        if (recipe == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(recipe);
        //    }

        //    // POST: Recipe/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(long id)
        //    {
        //        var recipe = await _context.FavoriteRecipes.FindAsync(id);
        //        _context.FavoriteRecipes.Remove(recipe);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    private bool RecipeExists(long id)
        //    {
        //        return _context.FavoriteRecipes.Any(e => e.RecipeId == id);
        //    }
    }
}
