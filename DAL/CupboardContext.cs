using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class CupboardContext : DbContext
{
    public CupboardContext(DbContextOptions<CupboardContext> options) : base(options)
    {
    }

    public DbSet<Clothes> ClothesEntities { get; set; }
    public DbSet<Cupboard> CupboardEntities { get; set; }
    public DbSet<CupboardModel> CupboardModelEntities { get; set; }
    public DbSet<CupboardClothes> CupboardClothesEntities { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Clothes

        modelBuilder.Entity<Clothes>().HasKey(e => e.Id);

        #endregion

        #region Cupboard

        modelBuilder.Entity<Cupboard>().HasKey(e => e.Id);
        modelBuilder.Entity<Cupboard>().HasOne(e => e.CupboardModel).WithMany(e => e.Cupboards)
            .HasForeignKey(e => e.ModelId).IsRequired().OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region CupboardModel

        modelBuilder.Entity<CupboardModel>().HasKey(e => e.Id);

        #endregion

        #region CupboardClothes

        modelBuilder.Entity<CupboardClothes>().HasKey(e => e.Id);
        modelBuilder.Entity<CupboardClothes>().HasOne(e => e.Cupboard).WithMany(e => e.CupboardClothes)
            .HasForeignKey(e => e.CupboardId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<CupboardClothes>().HasOne(e => e.Clothes).WithMany(e => e.CupboardClothes)
            .HasForeignKey(e => e.ClothesId).IsRequired().OnDelete(DeleteBehavior.Cascade);

        #endregion


        base.OnModelCreating(modelBuilder);
    }
}