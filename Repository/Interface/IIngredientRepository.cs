using recipePickerApp.Models;
using recipePickerApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipePickerApp.Repository
{
   public interface IIngredientRepository: IRepositoryBase<Ingredient>
    {
        public ICollection<Ingredient> GetIngredientsForRecipe(long recipeId);
        public ICollection<Ingredient> AddIngredientsToRecipe(ICollection<Ingredient> ingredients, long recipeId);
    }
}
