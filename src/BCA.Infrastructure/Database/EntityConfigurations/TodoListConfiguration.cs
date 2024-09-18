using BCA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCA.Infrastructure.Database.EntityConfigurations;

public class TodoListConfiguration : IEntityTypeConfiguration<TodoList>
{
	public void Configure(EntityTypeBuilder<TodoList> builder)
	{
		builder.Property(f => f.Name).IsRequired().HasMaxLength(100);
	}
}