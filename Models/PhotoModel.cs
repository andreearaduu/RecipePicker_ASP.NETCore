using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace recipePickerApp.Models
{
    public class PhotoModel
    {
        [Display(Name = "Picture")]
        public IFormFile ProfileImage { get; set; }
    }
}
