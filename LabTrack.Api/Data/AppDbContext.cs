

using LabTrack.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace LabTrack.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Sample> Samples => Set<Sample>();
    // public DbSet<Analysis> Analyses => Set<Analysis>();
    // public DbSet<Schedule> Schedules => Set<Schedule>();
}

