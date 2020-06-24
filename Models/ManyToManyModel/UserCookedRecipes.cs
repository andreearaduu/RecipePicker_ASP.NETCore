using recipePickerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipePickerApp.ManyToManyModel
{
    public class UserCookedRecipes
    {
        public String UserId { get; set; }
        public User user { get; set; }
       
        public long RecipeId { get; set; }

        public Recipe recipe { get; set; }
    }
}
