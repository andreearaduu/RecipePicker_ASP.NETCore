using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipePickerApp.Exceptions
{
    public class EntitiesNotFoundException : Exception
    {
       
        public EntitiesNotFoundException(string message) : base($"{message}")
        {
        }
    }
}
