using System.Collections.Generic;

namespace recipePickerApp.Models
{
    public class RecipeViewModel
    {
        public Recipe recipe { get; set; }
        public IEnumerable<Review> reviews { get; set; }
        public IEnumerable<Ingredient> ingredients { get; set; }
    }
}
