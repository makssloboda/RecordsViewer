using Microsoft.EntityFrameworkCore;

namespace RecordsViewerAPI_v2.Models;

public partial class RecordsViewerContext : DbContext
{
    public RecordsViewerContext()
    {
    }

    public RecordsViewerContext(DbContextOptions<RecordsViewerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Node> Nodes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("RecordsViewerDB"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Node>(entity =>
        {
            entity.Property(e => e.NodeId).HasColumnName("NodeID");
            entity.Property(e => e.Country).HasMaxLength(250);
            entity.Property(e => e.DateOfBirth).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.ParentNodeId).HasColumnName("ParentNodeID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
