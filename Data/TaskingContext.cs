using Microsoft.EntityFrameworkCore;
using ApiTasking.Models;

namespace ApiTasking.Data
{
    public class TaskingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=123;Persist Security Info=True;User ID=Admin;Initial Catalog=Dados;Data Source=DESKTOP-ARQUODB");
        }

        public DbSet<Tasking>? Taskings { get; set; }
    }
}
