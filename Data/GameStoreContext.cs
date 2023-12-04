using Microsoft.EntityFrameworkCore;
using GameStore.API.Entities;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Proxies; // Add this line


namespace GameStore.API.Data;

public class GameStoreContext :DbContext
    {
        public GameStoreContext(DbContextOptions<GameStoreContext> options) 
        : base(options)
        {
            
        }

        public DbSet<Game> Games => Set<Game>();
        public DbSet<UserMaster> Users => Set<UserMaster>();

        public DbSet<ModuleMaster> Module { get; set; }
        public DbSet<ProgramMaster> Program { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        optionsBuilder.UseLazyLoadingProxies(false); // Disable lazy loading
        base.OnConfiguring(optionsBuilder);
        }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<UserMaster>(user =>
            {
            user.HasIndex(u => new {u.EmployeeId})
            .IsUnique()
            .HasDatabaseName("EmployeeId");
            });

    }
}