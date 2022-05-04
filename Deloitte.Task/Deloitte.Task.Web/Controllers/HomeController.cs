namespace TodoListWebApp.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Deloitte.Task.Web.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using TodoListWebApp.Models;

    /// <summary>
    /// HomeController class by default.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<LoginViewModel> _userManager;
        private readonly SignInManager<LoginViewModel> _signInManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="logger">logger parameter.</param>
        public HomeController(ILogger<HomeController> logger, UserManager<LoginViewModel> userManager,
                   SignInManager<LoginViewModel> signInManager)
        {
            this._logger = logger;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        /// <summary>
        /// Task for calling Logout.
        /// </summary>
        /// <returns>Return to index view.</returns>
        public async Task<IActionResult> Logout()
        {
            await this._signInManager.SignOutAsync();
            this.HttpContext.Session.Remove("userName");
            return this.RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
