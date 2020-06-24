using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace recipePickerApp.Models
{
    public class RecipePhotoModel
    {
        public long RecipeId { get; set; }
        [Display(Name = "Picture")]
        public IFormFile ProfileImage { get; set; }
    }
}
