using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace recipePickerApp.Models
{
    public class PhotoModel
    {
        [Display(Name = "Picture")]
        public IFormFile ProfileImage { get; set; }
    }
}
