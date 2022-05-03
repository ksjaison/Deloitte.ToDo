namespace Deloitte.Task.Web.Data
{
    using Deloitte.Task.Web.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// DB context class for identity DB context.
    /// </summary>
    public class AppDBContext : IdentityDbContext<LoginViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppDBContext"/> class.
        /// </summary>
        /// <param name="options">Base parameter for DB Context.</param>
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets Login model values.
        /// </summary>
        public DbSet<LoginViewModel> Login { get; set; } = null!;
    }
}
