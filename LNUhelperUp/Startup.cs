using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNUhelperUp.Models;
using LNUhelperUp.Repositories.ImplementedRepositories;
using LNUhelperUp.Repositories.IRepositories;
using LNUhelperUp.Services.ImplementedServices;
using LNUhelperUp.Services.IServices;
using LNUhelperUp.UnitOfWorkPattern;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using AutoMapper;
using LNUhelperUp.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace LNUhelperUp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration)
            .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options => //CookieAuthenticationOptions
            {
                options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Auth/Login");
            });
            services.AddDbContext<LNUhelperContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews();
            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
        // Repositories
            services.AddScoped<DbContext, LNUhelperContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IFacultyRepository, FacultyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
            // Services
            services.AddScoped<IAnnouncementService, AnnouncementService>();
            services.AddScoped<IFacultyService, FacultyService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEventService, EventService>();
            // Extensions
            services.AddAutoMapper(typeof(Startup));
            services.ConfigureAutoMapper();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();    
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Auth}/{action=Login}/{id?}");
            });
        }
    }
}
