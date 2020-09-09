using recipePickerApp.ManyToManyModel;
using System;
using System.Collections.Generic;

namespace recipePickerApp.Models
{
    public enum Category
    {
        APERITIV, PAINE, PRAJITURI, CIORBE, PORC, PUI,PESTE, SALATA, PASTE, TRADITIONAL, DIVERSE,PIZZA,POST
    }
    public enum RecipeType
    {
        favorite, cooked, own
    }
    public class Recipe
    {
        public long RecipeId { get; set; }
        public String Name { get; set; }

        public String Description { get; set; }

        public String ImageUrl { get; set; }
        public String CookingDecription { get; set; }
        public int CookingTime { get; set; }

        public Category Category { get; set; }
        public RecipeType RecipeType { get; set; }

        public User User { get; set; }

        public String UserId { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public  ICollection<RecipeIngredients> RecipeIngredients { get; set; }
        

        public  ICollection<UserFavoriteRecipes> UserFavoriteRecepies { get; set; }

        public  ICollection<UserCookedRecipes> UserCookedRecepies { get; set; }

    }
}
