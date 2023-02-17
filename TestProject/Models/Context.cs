using Microsoft.EntityFrameworkCore;

namespace TestProject.Models
{
    public class Context : DbContext
    {
        public DbSet<Node> Nodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=RecordsViewer;Trusted_Connection=True;");
        }
    }
}
