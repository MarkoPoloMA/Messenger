using Messenger.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Database.Context.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> modelBuilder)
	{
		modelBuilder.Property(login => login.Login)
			.IsRequired()
			.HasMaxLength(100);

		modelBuilder.Property(name => name.Name)
			.IsRequired()
			.HasMaxLength(100);

        modelBuilder.HasIndex(login => login.Login)
			.IsUnique();

		modelBuilder.HasIndex(name => name.Name)
			.IsUnique();

        modelBuilder.Property(pass => pass.Password)
			.IsRequired()
			.HasMaxLength(50);

		modelBuilder.Property(data => data.RegistrationDate)
			.ValueGeneratedOnAddOrUpdate();
	}
}