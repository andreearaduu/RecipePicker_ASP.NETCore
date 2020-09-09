using System;

namespace recipePickerApp.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public long EntityId { get; private set; }
        public EntityNotFoundException(long id) : base($"Entity with id {id} was not found")
        {
        }
    }
}
