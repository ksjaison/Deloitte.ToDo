namespace Deloitte.Task.Web.Controllers
{
    using System.Configuration;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Deloitte.Task.Web.Models;

    public class LoginController : Controller
    {
        private readonly UserManager<LoginViewModel> _userManager;
        private readonly SignInManager<LoginViewModel> _signInManager;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginController"/> class.
        /// </summary>
        /// <param name="userManager">User identity parameter.</param>
        /// <param name="signInManager">User signIn parameter.</param>
        public LoginController(
                   UserManager<LoginViewModel> userManager,
                   SignInManager<LoginViewModel> signInManager, IConfiguration configuration)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._configuration = configuration;

            this.GetUserDetails(
                this._configuration.GetSection("AppSettings").GetSection("Id").Value,
                this._configuration.GetSection("AppSettings").GetSection("UserName").Value,
                this._configuration.GetSection("AppSettings").GetSection("Password").Value);
        }

        private void GetUserDetails(string userId, string userName,  string passWord)
        {
            var user = this._userManager.FindByNameAsync(userName);

            if (user != null)
            {
                var _user = new LoginViewModel
                {
                    Id = userId,
                    UserName = userName,
                    Name = userName,
                    Password = passWord,
                };
                var result = this._userManager.CreateAsync(_user, _user.Password);
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (this._signInManager.IsSignedIn(this.User))
            {
                return this.RedirectToAction("Index", "ToDoItem");
            }

            return this.View();
        }

        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel appUser)
        {
            var user = await this._userManager.FindByNameAsync(appUser.Name);

            if (user != null)
            {
                var signInResult = await this._signInManager.PasswordSignInAsync(user, appUser.Password, true, false);

                if (signInResult.Succeeded)
                {
                    return this.RedirectToAction("Index", "ToDoItem");
                }

                this.ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return this.RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> LogOut(string Name, string Password)
        {
            await this._signInManager.SignOutAsync();
            return this.RedirectToAction("Index");
        }
    }
}
