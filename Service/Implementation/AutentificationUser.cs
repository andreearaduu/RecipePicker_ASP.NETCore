using Microsoft.AspNetCore.Identity;
using recipePickerApp.Models;
using recipePickerApp.Service.Interface;
using System;
using System.Threading.Tasks;

namespace recipePickerApp.Service.Implementation
{
    public class AutentificationUser : IAutentificationUser
    {
        public IdentityResult Register(UserManager<User> _userManager, String email, String password)
        {
            var user = new User { UserName = email, Email =email };
            var result = _userManager.CreateAsync(user, password);

            return result.Result;
        }
        public async Task LogInAsync(SignInManager<User> _signInManager, String email, String password)
        {
            var user = new User { UserName = email, Email = email };
            await _signInManager.SignInAsync(user, isPersistent: false);
           
        }

    }
}
