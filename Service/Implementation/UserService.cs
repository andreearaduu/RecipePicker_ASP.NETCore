using recipePickerApp.Models;
using recipePickerApp.Repository.Interface;
using System;
using System.Collections.Generic;

namespace recipePickerApp.Service.Implementation
{
    public class UserService : IUserService
    {

        public IRepositoryWrapper _repositoryWrapper;
       
        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            this._repositoryWrapper = repositoryWrapper;
           
        }
       
        public ICollection<User> getAll()
        {
            return _repositoryWrapper.User.FindAll();
        }
        public User getUserById(String id)
        {
            return _repositoryWrapper.User.findById(id);
        }
        public IEnumerable<Recipe> getRecipesForUser(String Id, string recipeType)
        {
            
            switch (recipeType)
            {
                case "favorite":
                    return _repositoryWrapper.Recipe.GetFavoriteRecipesForUser(Id);

                case "cooked":
                    return _repositoryWrapper.Recipe.GetCookedRecipesForUser(Id);
                default:
                    return _repositoryWrapper.Recipe.GetOwnRecipesForUser(Id);
            }
        }
        public Recipe addRecipe(Recipe recipe)
        {
            return _repositoryWrapper.Recipe.Add(recipe);
        }

        public User Update(User user)
        {
            return _repositoryWrapper.User.Update(user);
        }
    }
}
