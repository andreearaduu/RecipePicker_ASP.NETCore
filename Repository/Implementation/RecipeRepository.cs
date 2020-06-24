using Microsoft.EntityFrameworkCore;
using recipePickerApp.DataContext;
using recipePickerApp.Models;
using recipePickerApp.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipePickerApp.Repository
{
    public class RecipeRepository : RepositoryBase<Recipe>, IRecipeRepository
    {
        
        public RecipeRepository(UserContext repositoryContext)
           : base(repositoryContext)
        {
          
        }

        public IEnumerable<Recipe> GetAll()
        {
            RecipeType recipeType = RecipeType.own;
            return userContext.Recipes
                    .Where(r => r.RecipeType.Equals(recipeType))
                    .AsEnumerable();
        }

        public IEnumerable<Recipe> GetFavoriteRecipesForUser(String Id)
        {
            RecipeType recipeType = RecipeType.favorite;
            return userContext.Recipes
                 .Where(recipe => recipe.UserId.Equals(Id) && (recipe.RecipeType.Equals(recipeType)))
                 .AsEnumerable();
        }

        public IEnumerable<Recipe> GetCookedRecipesForUser(String Id)
        {
            RecipeType recipeType = RecipeType.cooked;
            return userContext.Recipes
                 .Where(recipe => recipe.UserId.Equals(Id) && (recipe.RecipeType.Equals(recipeType)))
                 .AsEnumerable();
        }

        public void RemoveCookedRecipeFromUser(Recipe recipe, String userId)
        {
            ICollection<Recipe> cookedRecipes = userContext.UserCookedRecipes
                 .Where(u => u.UserId.Equals(userId))
                 .Select(p => p.recipe)
                 .ToList();

            cookedRecipes.Remove(recipe);
            userContext.SaveChanges();
        }

        public void RemoveFavoriteRecipeFromUser(Recipe recipe, String userId)
        {
            ICollection<Recipe> favRecipes = userContext.UserFavoriteRecipes
                 .Where(u => u.UserId.Equals(userId))
                 .Select(p => p.recipe)
                 .ToList();
            favRecipes.Remove(recipe);
            userContext.SaveChanges();

        }

        //public Recipe addFavoriteRecipeToUser(Recipe recipe, String userId)
        //{
        //    ICollection<Recipe> favRecipes = userContext.UserFavoriteRecipes
        //        .Where(u=>u.UserId.Equals(userId))
        //        .Select(p => p.recipe)
        //        .ToList();
        //    favRecipes.Add(recipe);
        //    userContext.SaveChanges();
        //    return recipe;
           
        //}

        //public Recipe addCookedRecipeToUser(Recipe recipe, String userId)
        //{
        //    ICollection<Recipe> cookedRecipes = userContext.UserCookedRecipes
        //         .Where(u => u.UserId.Equals(userId))
        //         .Select(p => p.recipe)
        //         .ToList();
        //    cookedRecipes.Add(recipe);
        //    userContext.SaveChanges();
        //    return recipe;
        //}

        public ICollection<Recipe> FindByCategory(string category)
        {
            Category category1 = (Category)System.Enum.Parse(typeof(Category), category);
            RecipeType recipeType = RecipeType.own;
            ICollection<Recipe> recipes= userContext.Recipes
                .Where(r => r.Category.Equals(category1) && r.RecipeType.Equals(recipeType))
                .ToList();
            return recipes;
        }

        public ICollection<Recipe> FindByName(string name)
        {
            RecipeType recipeType = RecipeType.own;
            ICollection<Recipe> recipes = userContext.Recipes
                .Where(r => r.Name.Contains(name) && (r.RecipeType.Equals(recipeType)))
                .ToList();
            return recipes;
        }

        public ICollection<Recipe> FindByNameAndCategory(string category,string name)
        {
            Category category1 = (Category)System.Enum.Parse(typeof(Category), category);
            RecipeType recipeType = RecipeType.own;
            ICollection<Recipe> recipes = userContext.Recipes
                .Where(r => r.Name.Contains(name)&&((r.Category.Equals(category1)) && (r.RecipeType.Equals(recipeType))))
                .ToList();
            return recipes;
        }

        public IQueryable<string> FindAllCategoriesAsString()
        {
            IQueryable<string> categoryQuery = from m in userContext.Recipes
                                               select m.Category.ToString();
            return categoryQuery;
        }

        public IEnumerable<Recipe> GetOwnRecipesForUser(string id)
        {
            RecipeType recipeType = RecipeType.own;
            return userContext.Recipes
                 .Where(recipe => recipe.UserId.Equals(id) && (recipe.RecipeType.Equals(recipeType)))
                 .AsEnumerable();
        }
    }
}
