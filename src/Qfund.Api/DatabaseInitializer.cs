using DbUp;
using Qfund.Migrations;

namespace Qfund.Api;

public class DatabaseInitializer : IStartupFilter
{
    private readonly IConfiguration configuration;
    private readonly ILogger<DatabaseInitializer> logger;

    public DatabaseInitializer(IConfiguration configuration, ILogger<DatabaseInitializer> logger)
    {
        this.configuration = configuration;
        this.logger = logger;
    }

    public Action<IApplicationBuilder> Configure(
        Action<IApplicationBuilder> next)
    {
        var connectionString = this.configuration.GetConnectionString("DefaultConnectionString");
        Console.WriteLine($"DbUp ConnectionString {connectionString}");
        EnsureDatabase.For.PostgresqlDatabase(connectionString);

        var upgradeBuilder = DeployChanges.To
            .PostgresqlDatabase(connectionString, "qf")
            .WithScriptsEmbeddedInAssembly(typeof(IMigrationMoniker).Assembly)
            .WithTransaction()
            .LogToConsole();

        var dbUpgradeEngine = upgradeBuilder.Build();
        if (dbUpgradeEngine.IsUpgradeRequired())
        {
            var operation = dbUpgradeEngine.PerformUpgrade();
            if (!operation.Successful)
            {
                this.logger.LogError($"DATABASE UPGRADE FAILED. {Environment.NewLine}{operation.Error}");
            }
        }

        return next;
    }
}
