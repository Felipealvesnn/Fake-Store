using Fake_Store_Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Fake_Store_Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<IdentityUser> _usermanager;
        private readonly SignInManager<IdentityUser> _SignInmanager;

        public AuthenticateService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _usermanager = userManager;
            _SignInmanager = signInManager;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _SignInmanager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task logout()
        {
            await _SignInmanager.SignOutAsync();
        }

        public async  Task<bool> RegisterUser(string email, string password)
        {
            var aplicacaodousuario = new IdentityUser
            {
                UserName = email,
                Email = email,
            };
            var result = await _usermanager.CreateAsync(aplicacaodousuario, password);
            if (result.Succeeded)
            {
                await _SignInmanager.SignInAsync(aplicacaodousuario, isPersistent: false);
            }
            return result.Succeeded;
        }
    }
}
