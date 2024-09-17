using FluentValidation;

namespace BCA.Application.Models.Todo;

public class CreateTodoListDto
{
	public string Name { get; set; } = string.Empty;
	
	public sealed class Validator : AbstractValidator<CreateTodoListDto>
	{
		public Validator()
		{
			RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
		}
	}
}