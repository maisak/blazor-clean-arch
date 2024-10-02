using BCA.Domain.Common;

namespace BCA.Domain.Entities;

public class TodoList : BaseEntity, ISoftDelete
{
	public string Name { get; set; } = null!;
	public DateTimeOffset? DeletedAt { get; set; }
}