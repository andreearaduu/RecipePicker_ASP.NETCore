using recipePickerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipePickerApp.ManyToManyModel
{
    public class RecipeIngredients
    {
        public Ingredient ingredient { get; set; }
        public long IngredientId { get; set; }

        public Recipe recipe { get; set; }
        public long RecipeId { get; set; }
    }
}
