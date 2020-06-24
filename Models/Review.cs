using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipePickerApp.Models
{
    public enum Stars
    {
        ONE,
        TWO,
        THREE,
        FOUR,
        FIVE
    }
    public class Review
    {
        public long ReviewId { get; set; }
        public String Description { get; set; }

        public Stars Stars { get; set; }
        public DateTime DateTime { get; set; }

        public Recipe Recipe { get; set; }
        public long RecipeId { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
