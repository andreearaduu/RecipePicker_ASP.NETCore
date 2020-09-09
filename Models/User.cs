using Microsoft.AspNetCore.Identity;
using recipePickerApp.ManyToManyModel;
using System;
using System.Collections.Generic;

namespace recipePickerApp.Models
{
    public class User : IdentityUser
    {
        public String ImageUrl { get; set; }
        public ICollection<Review> Reviews { get; set; }

        public  ICollection<UserFavoriteRecipes> FavoriteRecipes { get; set; }

        public ICollection<Recipe> OwnRecipes { get; set; }

        public  ICollection<UserCookedRecipes> CookedRecipes { get; set; }
    }
}
