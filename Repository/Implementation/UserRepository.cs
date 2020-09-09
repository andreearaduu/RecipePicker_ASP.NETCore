using recipePickerApp.DataContext;
using recipePickerApp.Models;
using recipePickerApp.Repository.Implementation;
using System;
using System.Linq;

namespace recipePickerApp.Repository
{

    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private UserContext UserContext;
        public UserRepository(UserContext repositoryContext)
           : base(repositoryContext)
        {
            this.UserContext = repositoryContext;
        }

        public User findById(String Id)
        {
            
            return UserContext.UserFavoriteRecepies
                .Where(user => user.Id== Id)
                .SingleOrDefault();
        }
    }
}
