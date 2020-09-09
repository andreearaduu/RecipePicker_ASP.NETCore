using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace recipePickerApp.Models
{
    public class RecipeCategoryView
    {
        public List<Recipe> Recipes { get; set; }
        public SelectList Categories { get; set; }
        public string RecipeCategory { get; set; }
        public string SearchString { get; set; }
    }
}
