using recipePickerApp.DataContext;
using recipePickerApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace recipePickerApp.Repository.Implementation
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected  UserContext userContext { get; set; }

        public RepositoryBase(UserContext userContext)
        {
            this.userContext = userContext;
        }

        public T Add(T itemToAdd)
        {
            var entity = userContext.Add<T>(itemToAdd);
            userContext.SaveChanges();
            return entity.Entity;
        }

        public bool Delete(T itemToDelete)
        {
            userContext.Remove<T>(itemToDelete);
            userContext.SaveChanges();
            return true;
        }
        public T Update(T itemToUpdate)
        {
            var entity = userContext.Update<T>(itemToUpdate);
            userContext.SaveChanges();
            return entity.Entity;
        }
      
        public ICollection<T> FindAll()
        {
            return this.userContext.Set<T>().ToList();
        }

        public ICollection<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.userContext.Set<T>().Where(expression).ToList();
        }
        public T findById(long Id)
        {
            return this.userContext.Set<T>().Find(Id);
        }
    }
}
