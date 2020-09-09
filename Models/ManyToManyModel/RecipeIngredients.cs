using recipePickerApp.Models;

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
