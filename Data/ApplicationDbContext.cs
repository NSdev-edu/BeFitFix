using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeFit.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{
    public DbSet<BeFit.Models.Exercise> Exercise { get; set; } = default!;
    public DbSet<BeFit.Models.Session> Session { get; set; } = default!;
    public DbSet<BeFit.Models.ExerciseType> ExerciseType { get; set; } = default!;
}
