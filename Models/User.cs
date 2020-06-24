using Microsoft.AspNetCore.Identity;
using recipePickerApp.ManyToManyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipePickerApp.Models
{
    public class User : IdentityUser
    {
    //    public Guid UserId { get; set; }

    //    public Guid UserLogId { get; set; }
    //    public String Password { get; set; }
    //    public string Email { get; set; }
    //    public String Name { get; set; }

        public String ImageUrl { get; set; }
        public ICollection<Review> Reviews { get; set; }

        public  ICollection<UserFavoriteRecipes> FavoriteRecipes { get; set; }

        public ICollection<Recipe> OwnRecipes { get; set; }

        public  ICollection<UserCookedRecipes> CookedRecipes { get; set; }
    }
}
