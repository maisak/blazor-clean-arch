using FluentValidation;

namespace BCA.Application.Models.Todo;

public class TodoListDto
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	
	public sealed class Validator : AbstractValidator<TodoListDto>
	{
		public Validator()
		{
			RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
		}
	}
}