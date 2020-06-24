using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
