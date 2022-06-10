using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Myblog.DataAccess.Interfaces;
using Myblog.DataAccess.Repository;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;
using MyBlog.Application.Services;
using MyBlog.DataAccess;
using MyBlog.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers(); // используем контроллеры без представлений

            //настройка соединения с бд
            services.AddDbContext<DbCheckContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))); //Строка соединения находится в .json


            services.AddControllers().AddJsonOptions(
            options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            services.AddCors();

            services.AddTransient<IGenericRepository<Check>, GenericRepository<Check>>();
            services.AddTransient<IGenericRepository<Tag>, GenericRepository<Tag>>();
            services.AddTransient<IGenericRepository<Comment>, GenericRepository<Comment>>();
            services.AddTransient<IGenericRepository<Employee>, GenericRepository<Employee>>();

            services.AddTransient<ICheckService, CheckService>();
            services.AddTransient<ITagService, TagService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAdminService, AdminService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseRouting();


            app.UseCors(builder => builder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed((host) => true)
            .AllowCredentials()
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // подключаем маршрутизацию на контроллеры
            });
        }
    }
}
