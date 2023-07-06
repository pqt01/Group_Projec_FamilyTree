using BusinessObjects.Models;
using DataAccessObjects;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repositorys;
using Repositorys.Interface;

namespace Group_Project_FamilyTree
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddDbContext<FUFamilyTreeContext>(options =>
            {
                string connectString = Configuration.GetConnectionString("DB");
                options.UseSqlServer(connectString);
            });
            // Dang ky Identity
            services.AddIdentity<Account, IdentityRole>()
                    .AddEntityFrameworkStores<FUFamilyTreeContext>()
                    .AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/login";
                options.AccessDeniedPath = "/authenIdentity-false";
                //options.SlidingExpiration = true;
            });
            services.AddScoped<EventDAO>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<MemberDAO>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<FamilyDAO>();
            services.AddScoped<IFamilyRepository, FamilyRepository>();
            services.AddScoped<ServiceDAO>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<LocationDAO>();
            services.AddScoped<ILocationRepository, LocationRepository>();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
