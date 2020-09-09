using Microsoft.AspNetCore.Identity;
using recipePickerApp.Models;
using System;
using System.Threading.Tasks;

namespace recipePickerApp.Service.Interface
{
    public interface IAutentificationUser
    {
        IdentityResult Register(UserManager<User> _userManager, String email, String password);
        Task LogInAsync(SignInManager<User> _signInManager, String email, String password);
    }
}
