using recipePickerApp.Models;
using recipePickerApp.Repository.Interface;
using System.Collections.Generic;

namespace recipePickerApp.Repository
{
    public interface IReviewRepository : IRepositoryBase<Review>
    {
        public ICollection<Review> GetReviewsForRecipe(long recipeId);
    }
}
