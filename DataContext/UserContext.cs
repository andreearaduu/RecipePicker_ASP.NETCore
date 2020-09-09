using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using recipePickerApp.ManyToManyModel;
using recipePickerApp.Models;

namespace recipePickerApp.DataContext
{
    public class UserContext : IdentityDbContext<User>
    {

       public UserContext(DbContextOptions<UserContext> options)
            :base(options)
        {

        }
       

        public DbSet<Recipe> FavoriteRecipes { get; set; }

        public DbSet<Recipe> OwnRecipes { get; set; }

        public DbSet<Recipe> CookedRecipes { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> UserFavoriteRecepies { get; set; }

        public DbSet<User> UserCookedRecepies { get; set; }

        public DbSet<RecipeIngredients> RecipeIngredients { get; set; }
        public DbSet<UserCookedRecipes> UserCookedRecipes { get; set; }
        public DbSet<UserFavoriteRecipes> UserFavoriteRecipes{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCookedRecipes>().HasKey(sc => new { sc.UserId, sc.RecipeId });
            modelBuilder.Entity<UserFavoriteRecipes>().HasKey(sc => new { sc.UserId, sc.RecipeId });
            modelBuilder.Entity<RecipeIngredients>().HasKey(sc => new { sc.IngredientId, sc.RecipeId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
