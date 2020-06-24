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

    public class RecipeService : IRecipeService
    {
       public IRepositoryWrapper _repositoryWrapper;
      
       public RecipeService(IRepositoryWrapper repositoryWrapper)
        {
            this._repositoryWrapper = repositoryWrapper;
        }

        public IEnumerable<Recipe> getAllRecipes()
        {
           
            return _repositoryWrapper.Recipe.GetAll();
        }

        public ICollection<Ingredient> getIngredientsForRecipe(long Id)
        {
            if (Id == 0)
            {
                throw new Exception("Recipe id is null");
            }
            var ingredients= _repositoryWrapper.Ingredient.GetIngredientsForRecipe(Id);

            if (ingredients == null)
            {
                throw new EntitiesNotFoundException("No ingredients for recipe");
            }
            return ingredients;
        }

        public ICollection<Review> getReviewsForRecipe(long Id)
        {
            //Recipe recipe = _repositoryWrapper.Recipe.findById(Id);
            //return recipe.Reviews.ToList();
            if(Id==0)
            {
                throw new Exception("Recipe id is null");
            }
            var reviews= _repositoryWrapper.Review.GetReviewsForRecipe(Id);

            if(reviews==null)
            {
                throw new EntitiesNotFoundException("No reviews for recipe");
            }
            return reviews;
        }
        public ICollection<Ingredient> addIngredientsToRecipe(ICollection<Ingredient> ingredients, long recipeId)
        {

            return _repositoryWrapper.Ingredient.AddIngredientsToRecipe(ingredients, recipeId);
        }

        public Review addReviewToRecipe(Review review)
        {
            if(review.RecipeId==0)
            {
                throw new Exception("Recipe id is invalid");
            }
            var recipe = _repositoryWrapper.Recipe.findById(review.RecipeId);
            if (recipe == null)
            {
                throw new EntityNotFoundException(review.RecipeId);
            }
            recipe.Reviews.Add(review);
            return _repositoryWrapper.Review.Add(review);
        }

        public Recipe GetRecipeById(long id)
        {
            if (id == 0)
            {
                throw new Exception("Id parameter is null");
            }

            var recipe= _repositoryWrapper.Recipe.findById(id);

            if(recipe==null)
            {
                throw new EntityNotFoundException(id);
            }
            return recipe;
        }

        public Recipe AddRecipe(Recipe recipe)
        {
            return _repositoryWrapper.Recipe.Add(recipe);
        }

        public ICollection<Recipe> GetRecipesByCategory(string category)
        {
            if(category==null)
            {
                throw new Exception("Category parameter is null");
            }
            var recipes= _repositoryWrapper.Recipe.FindByCategory(category);
            if(recipes==null)
            {
                throw new EntitiesNotFoundException("No recipes for this category");
            }
            return recipes;
        }

        public IEnumerable<Recipe> GetRecipesByCategoryAndName(string category,string name)
        {
            if (category != null && name!=null)
            {
                return _repositoryWrapper.Recipe.FindByNameAndCategory(category, name);
            }
            if(category==null &&name==null)
            {
                return _repositoryWrapper.Recipe.GetAll();
            }
            if (category == null && name != null)
            {
                return _repositoryWrapper.Recipe.FindByName(name);
            }
            if(category!=null &&name==null)
            {
                return _repositoryWrapper.Recipe.FindByCategory(category);
            }
            return _repositoryWrapper.Recipe.FindAll();
        }

        public IQueryable<string> getAllCategoriesAsString()
        {
           return _repositoryWrapper.Recipe.FindAllCategoriesAsString();
        }

        public Recipe Update(Recipe recipe)
        {
            return _repositoryWrapper.Recipe.Update(recipe);
        }
    }
}
