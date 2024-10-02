using BCA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCA.Infrastructure.Database.EntityConfigurations;

public class TodoListConfiguration : IEntityTypeConfiguration<TodoList>
{
	public void Configure(EntityTypeBuilder<TodoList> builder)
	{
		builder.ToTable("TodoLists");
		builder.HasIndex(x => x.DeletedAt);
		builder.HasQueryFilter(x => x.DeletedAt == null);
		builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
	}
}