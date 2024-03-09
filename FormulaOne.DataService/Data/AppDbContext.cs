using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;

namespace FormulaOne.DataService.Data;

public class AppDbContext : DbContext
{
    // Defining database entities
    public virtual DbSet<Driver> Drivers { get; set; }
    public virtual DbSet<Achievement> Achievements { get; set; }
    public virtual DbSet<Circuit> Circuits { get; set; }
    public virtual DbSet<Team> Teams { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Specifying relationship between the entities
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity
                .HasOne(a => a.Driver)
                .WithMany(d => d.Achievements)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Achivements_Driver");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity
                .HasMany(t => t.Drivers)
                .WithOne(d => d.Team)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Team_Driver");
        });
    }
}
