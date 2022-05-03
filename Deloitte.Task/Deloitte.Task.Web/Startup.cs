namespace Deloitte.Task.Web
{
    using System;
    using AutoMapper;
    using Deloite.Task.DataAccessLayer.Repository;
    using Deloitte.Task.BusinessService;
    using Deloitte.Task.BusinessService.Abstractions;
    using Deloitte.Task.DataAccessLayer.Abstractions.Repository;
    using Deloitte.Task.DataAccessLayer.Context;
    using Deloitte.Task.Web.Data;
    using Deloitte.Task.Web.Mapper;
    using Deloitte.Task.Web.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// Starp class intialise all services and configurations.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">Configuration interfcae.</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets Configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContext>(Opt => Opt.UseInMemoryDatabase("LoginWeb"));
            services.AddDbContext<MasterContext>(Opt => Opt.UseInMemoryDatabase("ToDoListWeb"));
            services.AddTransient<ITaskDetailsProvider, TaskDetailsProvider>();
            services.AddTransient<ITaskDetailsRepository, TaskDetailsRepository>();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CommonMapper());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            // Cookie settings
            services.ConfigureApplicationCookie(Opt =>
            {
                Opt.Cookie.Name = "ToDoListWebAppCookie";
                Opt.LoginPath = "/Home/Login"; // User defined login path
                Opt.ExpireTimeSpan = TimeSpan.FromMinutes(10);
            });

            services.AddIdentity<LoginViewModel, IdentityRole>(Opt =>
            {
                //// User defined password policy settings.
                /////config.Password.RequiredLength = 4;
                Opt.Password.RequireDigit = false;
                Opt.Password.RequireNonAlphanumeric = false;
                Opt.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<AppDBContext>()
                .AddEntityFrameworkStores<MasterContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<AppDBContext>();
            services.AddScoped<MasterContext>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=index}/{id?}");
            });
        }
    }
}
