using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FITClothing.API.Data;

public class ApplicationDbContextFactory
    : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder =
            new DbContextOptionsBuilder<ApplicationDbContext>();

        optionsBuilder.UseNpgsql(
            "Host=ep-delicate-bonus-b4cij8xt-pooler.c-6.us-east-2.aws.neon.tech;Port=5432;Database=neondb;Username=neondb_owner;Password=npg_6cYxvQGN8OIE;SSL Mode=Require;Trust Server Certificate=true");

        return new ApplicationDbContext(
            optionsBuilder.Options);
    }
}