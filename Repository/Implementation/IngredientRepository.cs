using recipePickerApp.DataContext;
using recipePickerApp.Models;
using recipePickerApp.Repository.Implementation;
using System.Collections.Generic;
using System.Linq;

namespace recipePickerApp.Repository
{
    public class IngredientRepository : RepositoryBase<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(UserContext repositoryContext)
           : base(repositoryContext)
        {
           
        }

        public ICollection<Ingredient> GetIngredientsForRecipe(long recipeId)
        {
            return userContext.RecipeIngredients
                .Where(r => r.RecipeId.Equals(recipeId))
                .Select(p => p.ingredient)
                .ToList();
        }

        public ICollection<Ingredient> AddIngredientsToRecipe(ICollection<Ingredient> ingredients,long recipeId)
        {
            ICollection<Ingredient> ingredientsRecipe= userContext.RecipeIngredients
                .Where(r => r.RecipeId.Equals(recipeId))
                .Select(p => p.ingredient)
                .ToList();
            foreach(Ingredient i in ingredients){
                ingredientsRecipe.Add(i);
            }
            userContext.SaveChanges();

            return ingredientsRecipe;
            
        }
    }
}
