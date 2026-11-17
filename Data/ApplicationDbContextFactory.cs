using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FITClothing.API.Data;

public class ApplicationDbContextFactory
    : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var connectionString =
            Environment.GetEnvironmentVariable(
                "DATABASE_CONNECTION_STRING")
            ?? throw new InvalidOperationException(
                "DATABASE_CONNECTION_STRING must be configured for EF migrations.");

        var optionsBuilder =
            new DbContextOptionsBuilder<ApplicationDbContext>();

        optionsBuilder.UseNpgsql(
            connectionString);

        return new ApplicationDbContext(
            optionsBuilder.Options);
    }
}