using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace recipePickerApp.Models
{
    public class RecipePhotoModel
    {
        public long RecipeId { get; set; }
        [Display(Name = "Picture")]
        public IFormFile ProfileImage { get; set; }
    }
}
