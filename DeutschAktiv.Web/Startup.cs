using AutoMapper;
using DeutschAktiv.Core.Models;
using DeutschAktiv.Web.Services;
using DeutschAktiv.Web.Services.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace DeutschAktiv.Web
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

//        public Startup()
//        {
//            var builder = new ConfigurationBuilder().AddJsonFile("config.json").AddEnvironmentVariables();
//            Configuration = builder.Build();
//        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAutoMapper();
            services.AddTransient<DataSeeder>();
            services.AddScoped<ClubService>();
            services.AddScoped<CourseService>();
            services.AddScoped<IClubService, ClubService>();
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddEntityFrameworkSqlite().AddDbContext<DataContext>();
//            services.AddDbContext<DataContext>(
//                options => options.UseNpgsql(Configuration["Data:DefaultConnection:ConnectionString"])
//            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, DataSeeder seeder)
        {
            loggerFactory.AddConsole(LogLevel.Information).AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseStatusCodePagesWithRedirects("/error/{0}");
            app.ApplicationServices.GetService<DataContext>().Database.Migrate();
            seeder.Seed();

        }
    }
}