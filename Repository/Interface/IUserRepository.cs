using recipePickerApp.Models;
using recipePickerApp.Repository.Interface;
using System;

namespace recipePickerApp.Repository
{
    public  interface IUserRepository : IRepositoryBase<User>
    {
        User findById(String Id);
    }
}
