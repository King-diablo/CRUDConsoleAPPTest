using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace CRUDConsoleAPPTest
{
    public class StudentDBContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Data Source=app.db;";

            optionsBuilder.UseSqlite(connectionString);//.LogTo(x => Console.WriteLine($"Db: '{x}'"));

            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Student>? Student { get; set; }
    }
}
