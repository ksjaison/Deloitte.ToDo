namespace Deloitte.Task.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    public class LoginViewModel : IdentityUser
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
