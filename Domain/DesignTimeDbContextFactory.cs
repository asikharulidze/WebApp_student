using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace WebApp.Domain;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<StudentsDbContext>
{
    public StudentsDbContext CreateDbContext(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json")
            .Build();

        string connectionString = configuration.GetConnectionString("NpgSql");

        var optionsBuilder = new DbContextOptionsBuilder<StudentsDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new StudentsDbContext(optionsBuilder.Options);
    }
}