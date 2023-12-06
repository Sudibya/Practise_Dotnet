using System.Text.Json.Serialization;
using GameStore.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Data;

public static class DataExtensions
{

        // We can also run the migrations in async mode that will help the code to run faster that's why we use this.
    public static async Task InitializeDbAsync(this IServiceProvider serviceProvider)
    {

        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        await dbContext.Database.MigrateAsync();
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        var connString = configuration.GetConnectionString("GameStoreContext");
        services.AddSqlServer<GameStoreContext>(connString)
        .AddScoped<IIGameRepository, EntityFrameworkGamesRepository>();

        services.AddSqlServer<GameStoreContext>(connString)
            .AddScoped<IIUserMasterRepository, UserMasterRepositoryLogic>();
        
        services.AddSqlServer<GameStoreContext>(connString)
            .AddScoped<IIProgramMasterRepository, ProgramMasterRepositoryLogic>();

        services.AddSqlServer<GameStoreContext>(connString)
            .AddScoped<IIModuleMasterRepository, ModuleMasterRepositoryLogic>();

        services.AddSqlServer<GameStoreContext>(connString)
            .AddScoped<IIRoleMasterRepository, RoleMasterRepositoryLogic>();
        
        return services;
    }
}