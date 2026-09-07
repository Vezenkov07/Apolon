using Apolon.Data.Models;
using Apolon.Data.Models.Enums;

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
    public DbSet<SupplementPurchase> SupplementPurchases { get; set; } = null!;
    public DbSet<PaymentTransaction> PaymentTransactions { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Workout> Workouts { get; set; } = null!;
    public DbSet<Session> Sessions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<SupplementCategory>()
            .Property(c => c.Category)
            .HasConversion<string>();

        builder.Entity<Session>()
            .HasIndex(s => new { s.TrainerId, s.BookingDate, s.BookingTime })
            .IsUnique();

        SeedDB(builder);
        SeedSupplements(builder);
        SeedWorkouts(builder);
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
            },
            new Trainer()
            {
                TrainerId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                FirstName = "Georgi",
                LastName = "Petrov",
                Email = "georgi.petrov@apolon.com",
                PhoneNumber = "+359888111222",
                Description = "Expert in powerlifting and heavy compound movements with over 10 years of coaching experience.",
                ImageUrl = "/images/trainers/georgi.jpeg",
                Gender = 'M'
            },
            new Trainer()
            {
                TrainerId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                FirstName = "Elena",
                LastName = "Stoyanova",
                Email = "elena.stoyanova@apolon.com",
                PhoneNumber = "+359888333444",
                Description = "Specialized in functional fitness, HIIT training, and core transformation.",
                ImageUrl = "/images/trainers/elena.jpeg",
                Gender = 'F'
            },
            new Trainer()
            {
                TrainerId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                FirstName = "Nikola",
                LastName = "Dimitrov",
                Email = "nikola.dimitrov@apolon.com",
                PhoneNumber = "+359888555666",
                Description = "Bodybuilding coach focused on hyper-trophy optimization and strict diet structuring.",
                ImageUrl = "/images/trainers/nikola.jpeg",
                Gender = 'M'
            },
            new Trainer()
            {
                TrainerId = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                FirstName = "Maria",
                LastName = "Ivanova",
                Email = "maria.ivanova@apolon.com",
                PhoneNumber = "+359888777888",
                Description = "Yoga instructor and mobility expert helping athletes prevent injury and recover faster.",
                ImageUrl = "/images/trainers/maria.jpeg",
                Gender = 'F'
            }
        };
        builder.Entity<Trainer>().HasData(trainers);
    }
    private void SeedSupplements(ModelBuilder builder)
{
    // Defined deterministic GUIDs for relationship linking
    var brandOnId = Guid.Parse("33333333-3333-3333-3333-333333333333");
    var brandMyProteinId = Guid.Parse("44444444-4444-4444-4444-444444444444");
    var brandCellucorId = Guid.Parse("55555555-5555-5555-5555-555555555555");

    var catProteinId = Guid.Parse("66666666-6666-6666-6666-666666666666");
    var catCreatineId = Guid.Parse("77777777-7777-7777-7777-777777777777");
    var catPreWorkoutId = Guid.Parse("88888888-8888-8888-8888-888888888888");

    // 1. Seed Supplement Brands
    builder.Entity<SupplementBrand>().HasData(
        new SupplementBrand
        {
            BrandId = brandOnId,
            BrandName = "Optimum Nutrition",
            Email = "support@optimumnutrition.com",
            PhoneNumber = "+18007055226",
            Description = "World leader in premium sports nutrition supplements."
        },
        new SupplementBrand
        {
            BrandId = brandMyProteinId,
            BrandName = "MyProtein",
            Email = "info@myprotein.com",
            PhoneNumber = "+359888123456",
            Description = "Leading European sports nutrition brand offering high-quality products."
        },
        new SupplementBrand
        {
            BrandId = brandCellucorId,
            BrandName = "Cellucor",
            Email = "support@cellucor.com",
            PhoneNumber = "+18669279686",
            Description = "Industry leader in high-performance pre-workout and energy formulas."
        }
    );

    // 2. Seed Supplement Categories
    builder.Entity<SupplementCategory>().HasData(
        new SupplementCategory
        {
            CategoryId = catProteinId,
            Category = SupplementCategories.Protein, // Uses your SupplementCategories enum
            CategoryDescription = "Protein supplements for muscle repair, growth, and daily dietary support."
        },
        new SupplementCategory
        {
            CategoryId = catCreatineId,
            Category = SupplementCategories.Creatine,
            CategoryDescription = "Creatine formulas to increase strength, power output, and muscle cell volume."
        },
        new SupplementCategory
        {
            CategoryId = catPreWorkoutId,
            Category = SupplementCategories.PreWorkout,
            CategoryDescription = "High-energy pre-workout formulas designed to maximize focus, endurance, and performance."
        }
    );

    // 3. Seed Supplements
    builder.Entity<Supplement>().HasData(
        new Supplement
        {
            SupplementId = Guid.Parse("90000000-0000-0000-0000-000000000001"),
            Name = "Gold Standard Whey Vanilla 2.27kg",
            Price = 149.99m,
            BrandId = brandOnId,
            CategoryId = catProteinId,
            Description = "Smooth vanilla whey blend with 24g of protein per serving for everyday recovery."
        },
        new Supplement
        {
            SupplementId = Guid.Parse("90000000-0000-0000-0000-000000000002"),
            Name = "Gold Standard Whey Chocolate 2.27kg",
            Price = 149.99m,
            BrandId = brandOnId,
            CategoryId = catProteinId,
            Description = "Rich chocolate whey blend designed to support muscle growth and recovery."
        },
        new Supplement
        {
            SupplementId = Guid.Parse("90000000-0000-0000-0000-000000000003"),
            Name = "Impact Whey Protein Strawberry 1kg",
            Price = 69.99m,
            BrandId = brandMyProteinId,
            CategoryId = catProteinId,
            Description = "Light strawberry whey protein for convenient post-workout nutrition."
        },
        new Supplement
        {
            SupplementId = Guid.Parse("90000000-0000-0000-0000-000000000004"),
            Name = "Creatine Monohydrate Pure 500g",
            Price = 45.00m,
            BrandId = brandMyProteinId,
            CategoryId = catCreatineId,
            Description = "Unflavored micronized creatine monohydrate to support strength and power."
        },
        new Supplement
        {
            SupplementId = Guid.Parse("90000000-0000-0000-0000-000000000005"),
            Name = "Creatine Capsules 120 Count",
            Price = 39.99m,
            BrandId = brandOnId,
            CategoryId = catCreatineId,
            Description = "Convenient creatine capsules for consistent daily supplementation."
        },
        new Supplement
        {
            SupplementId = Guid.Parse("90000000-0000-0000-0000-000000000006"),
            Name = "C4 Original Pre-Workout 390g",
            Price = 59.90m,
            BrandId = brandCellucorId,
            CategoryId = catPreWorkoutId,
            Description = "Classic energy and endurance formula with caffeine and beta-alanine."
        },
        new Supplement
        {
            SupplementId = Guid.Parse("90000000-0000-0000-0000-000000000007"),
            Name = "Ultimate Energy Pre-Workout 300g",
            Price = 54.99m,
            BrandId = brandCellucorId,
            CategoryId = catPreWorkoutId,
            Description = "Focused pre-workout energy formula for demanding training sessions."
        },
        new Supplement
        {
            SupplementId = Guid.Parse("90000000-0000-0000-0000-000000000008"),
            Name = "Clear Whey Isolate Lemon 500g",
            Price = 64.99m,
            BrandId = brandMyProteinId,
            CategoryId = catProteinId,
            Description = "Refreshing clear whey isolate that mixes like a light fruit drink."
        },
        new Supplement
        {
            SupplementId = Guid.Parse("90000000-0000-0000-0000-000000000009"),
            Name = "Gold Standard Whey Coffee 907g",
            Price = 79.99m,
            BrandId = brandOnId,
            CategoryId = catProteinId,
            Description = "Coffee-flavored whey protein for recovery with a morning boost."
        },
        new Supplement
        {
            SupplementId = Guid.Parse("90000000-0000-0000-0000-000000000010"),
            Name = "C4 Ripped Sport Pre-Workout 270g",
            Price = 62.99m,
            BrandId = brandCellucorId,
            CategoryId = catPreWorkoutId,
            Description = "Pre-workout blend for energy, focus, and intense training performance."
        }
    );
}

    private void SeedWorkouts(ModelBuilder builder)
    {
        var strengthSplitId = Guid.Parse("10000000-0000-0000-0000-000000000001");
        var fullBodySplitId = Guid.Parse("10000000-0000-0000-0000-000000000002");

        builder.Entity<Split>().HasData(
            new Split
            {
                SplitId = strengthSplitId,
                SplitName = "Strength and Power",
                TargetedMuscles = new() { Muscles.Pecs, Muscles.Shoulders, Muscles.Triceps }
            },
            new Split
            {
                SplitId = fullBodySplitId,
                SplitName = "Full Body Conditioning",
                TargetedMuscles = new() { Muscles.Legs, Muscles.Abs, Muscles.Shoulders }
            });

        builder.Entity<Workout>().HasData(
            new Workout
            {
                WorkoutId = Guid.Parse("20000000-0000-0000-0000-000000000001"),
                SplitId = strengthSplitId,
                TrainerId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                StartTime = new DateTime(2026, 9, 10, 18, 0, 0, DateTimeKind.Utc),
                EndTime = new DateTime(2026, 9, 10, 19, 0, 0, DateTimeKind.Utc)
            },
            new Workout
            {
                WorkoutId = Guid.Parse("20000000-0000-0000-0000-000000000002"),
                SplitId = fullBodySplitId,
                TrainerId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                StartTime = new DateTime(2026, 9, 12, 10, 0, 0, DateTimeKind.Utc),
                EndTime = new DateTime(2026, 9, 12, 11, 0, 0, DateTimeKind.Utc)
            });
    }
}