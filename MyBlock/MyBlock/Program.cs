using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MyBlog.DataAccess;
using MyBlog.DataAccess.Extensions;
using MyBlog.WebApi;
using System.Threading.Tasks;

namespace WebAPIApp
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            await CreateHostBuilder(args).Build()
                .MigrateDbContext<DbCheckContext>()      //Статический класс для синхронизации созданных миграций
                .RunAsync();
            return 0;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}