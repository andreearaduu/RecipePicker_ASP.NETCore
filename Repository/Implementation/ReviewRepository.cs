using recipePickerApp.Models;
using recipePickerApp.Repository.Implementation;
using System.Collections.Generic;
using System.Linq;

namespace recipePickerApp.Repository
{
    public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
    {
        public ReviewRepository(DataContext.UserContext repositoryContext)
           : base(repositoryContext)
        {
            
        }
        public ICollection<Review> GetReviewsForRecipe(long recipeId)
        {
            return userContext.Reviews
                .Where(r => r.Recipe.RecipeId.Equals(recipeId))
                .ToList();
        }
    }
}
