var target = Argument("target", "Default");
var configuration = Argument("configuration", "Debug");
var migrationName = Argument("migrationName", "InitialCreate");

var solution = "./Goga.Backend.slnx";
var startupProject = "./Goga.Backend.WebApi/Goga.Backend.WebApi.csproj";
var persistenceProject = "./Goga.Backend.Persistence/Goga.Backend.Persistence.csproj";

string EfArguments(string command) =>
    $"ef {command} --project {persistenceProject} --startup-project {startupProject} --configuration {configuration}";

Task("Restore")
    .Does(() => DotNetRestore(solution));

Task("Build")
    .IsDependentOn("Restore")
    .Does(() => DotNetBuild(solution, new DotNetBuildSettings
    {
        Configuration = configuration,
        NoRestore = true
    }));

Task("AddMigration")
    .IsDependentOn("Build")
    .Does(() =>
    {
        StartProcess("dotnet", new ProcessSettings
        {
            Arguments = EfArguments($"migrations add {migrationName}")
        });
    });

Task("UpdateDatabase")
    .IsDependentOn("Build")
    .Does(() =>
    {
        StartProcess("dotnet", new ProcessSettings
        {
            Arguments = EfArguments("database update")
        });
    });

Task("RemoveMigration")
    .IsDependentOn("Build")
    .Does(() =>
    {
        StartProcess("dotnet", new ProcessSettings
        {
            Arguments = EfArguments("migrations remove")
        });
    });

Task("ListMigrations")
    .IsDependentOn("Build")
    .Does(() =>
    {
        StartProcess("dotnet", new ProcessSettings
        {
            Arguments = EfArguments("migrations list")
        });
    });

Task("Default")
    .IsDependentOn("Build");

RunTarget(target);
