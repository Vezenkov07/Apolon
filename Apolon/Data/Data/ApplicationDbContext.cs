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
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        SeedDB(builder);
    }

    private void SeedDB(ModelBuilder builder)
    {
        List<Trainer> trainers = new List<Trainer>()
        {
            new Trainer()
            {
                TrainerId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                FirstName = "Luboslav",
                LastName = "Vezenkov",
                Email = "vezenkov07@gmail.com",
                PhoneNumber = "+359888747824",
                Description = "Most muscular man in history!",
                ImageUrl = "/images/trainers/me.jpg",
                Gender = 'M'
            },
            new Trainer()
            {
                TrainerId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                FirstName = "Ornela",
                LastName = "Muti",
                Email = "ornelamuti@gmail.com",
                PhoneNumber = "+3596969696969",
                Description = "The best dog in the world. Can teach you how to hunt cats.",
                ImageUrl = "/images/trainers/ornela.jpg",
                Gender = 'F'
            }
        };
        builder.Entity<Trainer>().HasData(trainers);
    }
}