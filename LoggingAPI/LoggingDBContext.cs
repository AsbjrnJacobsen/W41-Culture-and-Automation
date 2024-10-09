using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LoggingAPI;

public class LoggingDbContext : DbContext
{
    public LoggingDbContext(DbContextOptions<LoggingDbContext> options) : base(options)
    {
    }

    public DbSet<Log> Logs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Table Logs
        modelBuilder.Entity<Log>(e =>
        {
            e.ToTable("Log");
            
            // Primary key
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).ValueGeneratedOnAdd();
            
            // Columns
            e.Property(x => x.Severity);
            e.Property(x => x.Message);
            e.Property(x => x.SystemIdentifier);
            e.Property(x => x.SessionIdentifier);
        });
    }
}

public class Log
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public Guid SystemIdentifier { get; set; }
    [Required]
    public Guid SessionIdentifier { get; set; }
    [Required]
    public SeverityLevel Severity { get; set; } = SeverityLevel.Debug;
    [Required]
    [MaxLength(1024)]
    public string Message { get; set; } = string.Empty;
}

public enum SeverityLevel
{
    Trace,
    Debug,
    Information,
    Warn,
    Error,
    Fatal,
}