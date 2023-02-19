using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TestProject;

namespace RecordsViewer.Data
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
