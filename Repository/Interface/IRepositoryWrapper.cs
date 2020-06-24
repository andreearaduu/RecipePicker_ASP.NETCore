﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipePickerApp.Repository.Interface
{
   public interface IRepositoryWrapper
    {
        IRecipeRepository Recipe { get; }
        IIngredientRepository Ingredient { get; }
        IReviewRepository Review { get; }
        IUserRepository User { get; }
        void Save();
    }
}