using recipePickerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipePickerApp.Models
{
    public class RecipeViewModel
    {
        public Recipe recipe { get; set; }
        public IEnumerable<Review> reviews { get; set; }
        public IEnumerable<Ingredient> ingredients { get; set; }
    }
}
