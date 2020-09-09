using System;

namespace recipePickerApp.Exceptions
{
    public class EntitiesNotFoundException : Exception
    {
       
        public EntitiesNotFoundException(string message) : base($"{message}")
        {
        }
    }
}
