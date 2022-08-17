using Microsoft.EntityFrameworkCore;

namespace HSLRushHour.Backend.Models;

public class HSLRushHourDbContext : DbContext
{
    public HSLRushHourDbContext(DbContextOptions<HSLRushHourDbContext> options) : base(options)
    {

    }

    public DbSet<DisruptionEntity> Disruptions { get; set; } = null!;
}
