namespace Deloitte.Task.Web.Data
{
    using Deloitte.Task.Web.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    

    public class AppDBContext : IdentityDbContext<LoginViewModel>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<LoginViewModel> Login { get; set; } = null!;
    }
}
