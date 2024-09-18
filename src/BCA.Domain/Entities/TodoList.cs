using BCA.Domain.Common;

namespace BCA.Domain.Entities;

public class TodoList : AuditableEntity
{
	public string Name { get; set; } = null!;
}