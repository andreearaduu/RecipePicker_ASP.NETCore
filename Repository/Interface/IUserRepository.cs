using recipePickerApp.Models;
using recipePickerApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipePickerApp.Repository
{
   public  interface IUserRepository : IRepositoryBase<User>
    {
        User findById(String Id);
        //User GetByUserId(Guid userIdGuid);
    }
}
