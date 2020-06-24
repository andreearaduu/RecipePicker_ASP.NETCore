using recipePickerApp.ManyToManyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipePickerApp.Models
{
    public class Ingredient
    {
        public long IngredientId { get; set; }
        public String Name { get; set; }

       // public bool isSelected { get; set; }
        public  ICollection<RecipeIngredients> RecipeIngredients { get; set; }
    }
}
