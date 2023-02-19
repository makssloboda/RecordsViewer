using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace TestProject.Models
{
    public class Context : DbContext
    {
        public DbSet<Node> Nodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        }
    }
}
