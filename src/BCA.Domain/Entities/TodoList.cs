using BCA.Domain.Common;

namespace BCA.Domain.Entities;

public class TodoList : BaseEntity
{
	public string Name { get; set; } = null!;
}