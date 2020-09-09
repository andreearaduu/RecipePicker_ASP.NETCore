using recipePickerApp.ManyToManyModel;
using System;
using System.Collections.Generic;

namespace recipePickerApp.Models
{
    public class Ingredient
    {
        public long IngredientId { get; set; }
        public String Name { get; set; }
        public  ICollection<RecipeIngredients> RecipeIngredients { get; set; }
    }
}
