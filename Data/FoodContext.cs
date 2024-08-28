using FoodMenu.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodMenu.Data
{
    public class FoodContext : DbContext
    {
        public FoodContext(DbContextOptions<FoodContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PlateIngredient>().HasKey(pi => new
            {
                pi.PlateId,
                pi.IngredientId
            });
            modelBuilder.Entity<PlateIngredient>().HasOne(p => p.Plate).WithMany(pi => pi.PlateIngredients).HasForeignKey(p => p.PlateId);
            modelBuilder.Entity<PlateIngredient>().HasOne(i => i.Ingredient).WithMany(pi => pi.PlateIngredients).HasForeignKey(i => i.IngredientId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Plate> Plates { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<PlateIngredient> PlateIngredients { get; set; }
    }
}
