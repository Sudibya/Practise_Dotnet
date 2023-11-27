using Microsoft.EntityFrameworkCore;
using GameStore.API.Entities;
using System.Reflection;

namespace GameStore.API.Data;

public class GameStoreContext :DbContext
    {
        public GameStoreContext(DbContextOptions<GameStoreContext> options) 
        : base(options)
        {
            
        }

        public DbSet<Game> Games => Set<Game>();
        public DbSet<UserMaster> Users => Set<UserMaster>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}