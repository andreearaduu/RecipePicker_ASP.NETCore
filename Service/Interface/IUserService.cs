using recipePickerApp.Models;
using System;
using System.Collections.Generic;

namespace recipePickerApp.Service
{
    public  interface IUserService
    {
        ICollection<User> getAll();
        User getUserById(String id);
        IEnumerable<Recipe> getRecipesForUser(String id, String recipeType);
        public Recipe addRecipe(Recipe recipe);
        public User Update(User user);
    }
}
