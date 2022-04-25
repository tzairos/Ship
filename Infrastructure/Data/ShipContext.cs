using ApplicationCore.Entities.ShipAggreate;
using ApplicationCore.Entities.UserAggreate;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Data;
public class ShipContext : DbContext
{
    public DbSet<Ship> Ships { get; set; }
    public DbSet<User> Users { get; set; }


public ShipContext(DbContextOptions<ShipContext> options) : base(options)
{ }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ship>().ToTable("ships").HasIndex(x=>x.Code);
        modelBuilder.Entity<Ship>(
        s =>
        {
            s.Property(b => b.Code)
            .HasColumnName("code")
            .HasColumnType("varchar(200)").HasMaxLength(200);
            s.Property(b => b.Id)
          .HasColumnName("id")
          .HasColumnType("INTEGER").IsRequired();
            s.Property(b => b.Length)
          .HasColumnName("length")
          .HasColumnType("INTEGER");
           s.Property(b => b.Width)
          .HasColumnName("width")
          .HasColumnType("INTEGER");
          s.HasKey(x=>x.Id);
        });
        modelBuilder.Entity<User>().ToTable("users").HasIndex(x=>x.Username);
        modelBuilder.Entity<User>(
        s =>
        {
            s.Property(b => b.Username)
            .HasColumnName("username")
            .HasColumnType("varchar(200)").HasMaxLength(200);
            s.Property(b => b.Id)
          .HasColumnName("id")
          .HasColumnType("INTEGER").IsRequired();
            s.Property(b => b.Password)
          .HasColumnName("password")
           .HasColumnType("varchar(200)");
          s.HasKey(x=>x.Id);
        });

    }
}