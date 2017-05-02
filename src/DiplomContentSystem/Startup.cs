using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DiplomContentSystem.Services.Students;
using DiplomContentSystem.Services.Teachers;
using DiplomContentSystem.Services.Users;
using DiplomContentSystem.Services.DiplomWorks;
using DiplomContentSystem.Services.Groups;
using DiplomContentSystem.DataLayer;
using DiplomContentSystem.Core;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DiplomContentSystem.Controllers;
using DiplomContentSystem.Authentication;

namespace DiplomContentSystem
{
    public class Startup
    {
        private const string SecretKey = "someverystrongkey";
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc(config =>
                {
                    var policy = new AuthorizationPolicyBuilder()
                                    .RequireAuthenticatedUser()
                                    .Build();
                    config.Filters.Add(new AuthorizeFilter(policy));
                })
                    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddAutoMapper();
            services.AddScoped<TeacherService>();
            services.AddScoped<UserService>();
            services.AddScoped<StudentService>();
            services.AddScoped<DiplomWorksService>();
            services.AddScoped<GroupService>();
            services.AddScoped<IRepository<Teacher>, RepositoryBase<Teacher>>();
            services.AddScoped<IRepository<Student>, RepositoryBase<Student>>();
            services.AddScoped<IRepository<DiplomWork>, RepositoryBase<DiplomWork>>();
            services.AddScoped<IRepository<TeacherPosition>, RepositoryBase<TeacherPosition>>();
            services.AddScoped<IRepository<Speciality>, RepositoryBase<Speciality>>();
            services.AddScoped<IRepository<Department>, RepositoryBase<Department>>();
            services.AddScoped<IRepository<Group>, RepositoryBase<Group>>();
            services.AddScoped<IRepository<User>, RepositoryBase<User>>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<DiplomContext>();
            services.AddScoped<IAuthService, AuthService>();
            services
                .AddAuthPolicy()
                .ConfigureJwtIssuerOptions(Configuration, _signingKey);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.ConfigureJwtBearerAuthentication(Configuration, _signingKey);

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                });
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    serviceScope.ServiceProvider.GetService<DiplomContext>().EnsureSeedData();
                }
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
