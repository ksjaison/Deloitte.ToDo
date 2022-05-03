namespace Deloitte.Task.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// This is class for Login view model and setting and getting login related values.
    /// </summary>
    public class LoginViewModel : IdentityUser
    {
        /// <summary>
        /// Gets or Sets User Id.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or Sets Name.
        /// </summary>
        [Required(ErrorMessage = "UserName is required")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Password.
        /// </summary>
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Remember Me checked or not.
        /// </summary>
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
