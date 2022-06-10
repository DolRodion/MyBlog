using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBlog.DataAccess.Entities;

namespace MyBlog.DataAccess
{ 
    /// <summary>
    /// Контекст данных для обращения к бд(нижний уровень)
    /// </summary>
    public class DbCheckContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=CheckSystem;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public DbCheckContext()
        {
        }

        public DbCheckContext(DbContextOptions options) : base(options) { }
         
        /// <summary>
        /// "Context" для работы с бд через сущность TestEntity
        /// </summary>
        public DbSet<Check> Check { get; set; }

        public DbSet<Tag> Tag { get; set; }

        public DbSet<Comment> Comment { get; set; }

        public DbSet<Employee> Employee { get; set; }
    }
}
