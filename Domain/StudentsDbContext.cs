using Microsoft.EntityFrameworkCore;
using WebApp.Domain.Entities;

namespace WebApp.Domain;

public class StudentsDbContext : DbContext
{
    public StudentsDbContext(DbContextOptions<StudentsDbContext> options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
}