namespace Teist.Web.Controllers
{
    using System.Threading.Tasks;

    using Teist.Data.Models;
    using Teist.Web.Infrastructure.Extensions;
    using Teist.Common.ViewModels.Account;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]UserLoginBindingModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            var result = signInManager.PasswordSignInAsync(user, model.Password, true, false).Result;

            if (result.Succeeded)
            {
                return this.Ok();
            }

            return this.BadRequest(result.IsNotAllowed);

        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]UserRegisterBindingModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState.GetFirstError());
            }

            var user = new ApplicationUser { Email = model.Email, UserName = model.Email };
            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return this.Ok();
            }

            return this.BadRequest(result.GetFirstError());
        }
    }
}
