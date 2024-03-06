using System.Reflection;
using DbUp;

var connectionString = args.FirstOrDefault();

EnsureDatabase.For.PostgresqlDatabase(connectionString);

var upgrader = DeployChanges.To.PostgresqlDatabase(connectionString)
    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
    .LogToConsole()
    .Build();

var result = upgrader.PerformUpgrade();
