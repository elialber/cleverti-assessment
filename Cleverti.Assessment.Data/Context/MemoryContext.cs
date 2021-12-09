using Cleverti.Assessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Cleverti.Assessment.Data.Context
{
    public class MemoryContext : DbContext
    {
        public MemoryContext() { }

        public MemoryContext(DbContextOptions<MemoryContext> options)
            : base(options)
        { }
        public virtual DbSet<Todo> Todos { get; set; }
        public virtual DbSet<User> Users{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
               e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
               .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MemoryContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TodoDb");
        }

        [DbFunction("RemoveDiacritics", "dbo")]
        public static string RemoveDiacritics(string input)
        {
            return input;
        }

    }
}
