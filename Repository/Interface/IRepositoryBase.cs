using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace recipePickerApp.Repository.Interface
{
    public interface IRepositoryBase<T>
    {
        ICollection<T> FindAll();
        ICollection<T> FindByCondition(Expression<Func<T, bool>> expression);
        T findById(long Id);
        public T Add(T itemToAdd);
        public T Update(T itemToUpdate);
        public bool Delete(T itemToDelete);
    }
}
