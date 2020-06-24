using recipePickerApp.Models;
using recipePickerApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipePickerApp.Repository
{
  public  interface IRecipeRepository : IRepositoryBase<Recipe>
    {
        IEnumerable<Recipe> GetFavoriteRecipesForUser(String userId);

        IEnumerable<Recipe> GetCookedRecipesForUser(String userId);

        void RemoveFavoriteRecipeFromUser(Recipe recipe, String userId);
        void RemoveCookedRecipeFromUser(Recipe recipe, String userId);
        IEnumerable<Recipe> GetAll();

       // Recipe addFavoriteRecipeToUser(Recipe recipe, String userId);
     //   Recipe addCookedRecipeToUser(Recipe recipe, String userId);
        ICollection<Recipe> FindByCategory(string category);
        ICollection<Recipe> FindByName(string name);
        ICollection<Recipe> FindByNameAndCategory(string category, string name);
        IQueryable<String> FindAllCategoriesAsString();
        IEnumerable<Recipe> GetOwnRecipesForUser(string id);
    }
}
