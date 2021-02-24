using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Paybaymax.Data;
using Paybaymax.Domain.Queries;
using Paybaymax.Domain.Repositories;
using Paybaymax.Domain.Repositories.Interfaces;
using Paybaymax.Web.Services;
using Paybaymax.Web.Services.Interfaces;
using System;
using System.Reflection;

namespace Paybaymax.Web
{
    public class Startup
    {
        private readonly string CORS_POLICY_NAME = "SimpleCorsPolicy";
        private readonly string AUTHORIZATION_POLICY_NAME = "IsAdmin";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist/paybaymax";
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: this.CORS_POLICY_NAME, builder =>
                {
                    //builder.WithOrigins("*");
                    //builder.WithMethods("*");
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie = new CookieBuilder()
                    {
                        HttpOnly = true,
                        MaxAge = new TimeSpan(7, 0, 0, 0),
                        SameSite = SameSiteMode.Strict,
                        IsEssential = true,
                        SecurePolicy = CookieSecurePolicy.Always,
                    };
                });

            services.AddAuthorization(options =>
            {

                options.AddPolicy(AUTHORIZATION_POLICY_NAME, policy =>
                {
                    policy.RequireClaim("UserType", ((int)Paybaymax.Models.UserType.Admin).ToString());
                });
            });

            services.AddControllers(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddDbContext<PaybaymaxContext>(options =>
            {
#if DEBUG
                options.EnableSensitiveDataLogging(true);
                options.EnableDetailedErrors(true);
#endif
                options.UseSqlServer(this.Configuration.GetConnectionString("PaybaymaxSQL"));
            });

            services.AddMediatR(typeof(GetUserByCredentialsQuery).Assembly);

            services.AddHttpContextAccessor();
            this.ConfigureIoC(services);
        }

        public void ConfigureIoC(IServiceCollection services)
        {
            // Web App services
            services.AddSingleton<IAuthService, AuthService>();
            services.AddScoped<IPerformanceService, PerformanceService>();
            services.AddScoped<IUserService, UserService>();

            //Domain repositoties
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IPerformanceRepository, PerformanceRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(this.CORS_POLICY_NAME);
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
