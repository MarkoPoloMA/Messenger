using Messenger.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Messenger.Database.Context;

public class ApplicationContext : DbContext
{
	private readonly ILogger<ApplicationContext>? _logger;
	public DbSet<User> Users => Set<User>();
	public ApplicationContext(ILogger<ApplicationContext>? logger = null)
    {
        _logger = logger;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MessengerDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        optionsBuilder.LogTo(LogMessage, LogLevel.Information);
    }

    private void LogMessage(string message)
    {
        _logger?.LogInformation(message);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
}