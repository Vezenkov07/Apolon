using Apolon.Data.Models;

namespace Apolon.Data.Data;
using Microsoft.EntityFrameworkCore;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Trainer> Trainers { get; set; } = null!;
    public DbSet<Card> Cards { get; set; } = null!;
    public DbSet<Split> Splits { get; set; } = null!;
    public DbSet<SupplementBrand> SupplementsBrands { get; set; } = null!;
    public DbSet<SupplementCategory> SupplementsCategories { get; set; } = null!;
    public DbSet<Supplement> Supplements { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Workout> Workouts { get; set; } = null!;
}