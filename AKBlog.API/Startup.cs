using AKBlog.Core;
using AKBlog.Core.Services;
using AKBlog.Data;
using AKBlog.Data.Contexts;
using AKBlog.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;
using AutoMapper;
namespace AKBlog.API
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
            services.AddControllersWithViews();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICommentsService, CommentsService>();
            services.AddTransient<ITagsService, TagsService>();
            services.AddTransient<IPostService, PostsService>();
            services.AddTransient<IUserService, UserService>();
            services.AddDbContext<AKBlogMSSQLDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection"), x => x.MigrationsAssembly("AKBlog.Data")));
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "AK Blog", Version = "v1" });
            });
            services.AddAutoMapper(typeof(Startup)); 

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
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllers();
            });
            app.UseSwagger(); app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AK Blog V1");
            });
        }
    }
}
