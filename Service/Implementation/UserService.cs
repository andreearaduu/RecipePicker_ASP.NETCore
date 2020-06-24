using recipePickerApp.Exceptions;
using recipePickerApp.Models;
using recipePickerApp.Repository;
using recipePickerApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        //public Recipe addRecipeToUser(Recipe recipe, String userId)
        //{
        //    User user = _repositoryWrapper.User.findById(userId);
        //    if (recipe.RecipeType.ToString().Equals("favorite"))
        //    {
        //        _repositoryWrapper.Recipe.addFavoriteRecipeToUser(recipe, userId);
        //    }
        //    if (recipe.RecipeType.ToString().Equals("cooked"))
        //    {
        //        _repositoryWrapper.Recipe.addCookedRecipeToUser(recipe, userId);
        //    }
        //    if(recipe.RecipeType.ToString().Equals("own"))
        //    {
        //        user.OwnRecipes.Add(recipe);
        //    }
        //    return _repositoryWrapper.Recipe.Add(recipe);
        //}

        //public bool removeRecipeFromUser(long recipeId, String userId)
        //{
        //    Recipe recipe = _repositoryWrapper.Recipe.findById(recipeId);
        //    User user = _repositoryWrapper.User.findById(userId);

        //    string recipeType = recipe.RecipeType.ToString();

        //    if(recipe.RecipeType.ToString().Equals("favorite"))
        //    {
        //        _repositoryWrapper.Recipe.RemoveFavoriteRecipeFromUser(recipe,userId);
        //    }
        //    if (recipe.RecipeType.ToString().Equals("cooked"))
        //    {
        //        _repositoryWrapper.Recipe.RemoveCookedRecipeFromUser(recipe,userId);
        //    }
        //    if (recipe.RecipeType.ToString().Equals("own"))
        //    {
        //        user.OwnRecipes.Remove(recipe);
        //    }
        //   return _repositoryWrapper.Recipe.Delete(recipe);
        //}


        //public User GetByUserId(string Id)
        //{
        //    Guid userIdGuid = Guid.Empty;
        //    if (!Guid.TryParse(Id, out userIdGuid))
        //    {
        //        throw new Exception("Invalid Guid Format");
        //    }

        //    var student = _repositoryWrapper.User.GetByUserId(userIdGuid);

        //    if (student == null)
        //    {
        //        throw new Exception("Entity not found");
        //    }

        //    return student;
        //}
    }
}
