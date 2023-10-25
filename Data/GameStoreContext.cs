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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}