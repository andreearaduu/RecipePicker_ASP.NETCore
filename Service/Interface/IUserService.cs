using recipePickerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipePickerApp.Service
{
   public  interface IUserService
    {
        ICollection<User> getAll();

        User getUserById(String id);

        IEnumerable<Recipe> getRecipesForUser(String id, String recipeType);

       // Recipe addRecipeToUser(Recipe recipe, String userId);

       // bool removeRecipeFromUser(long recipeId, String userId);
        public Recipe addRecipe(Recipe recipe);

        public User Update(User user);
        //User GetByUserId(string Id);
    }
}
