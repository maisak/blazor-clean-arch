using BCA.Application.Models.Todo;
using FluentValidation;
using MediatR;

namespace BCA.Application.Features.Todo;

public record CreateTodoList(CreateTodoListDto Dto) : IRequest
{
	public class Validator : AbstractValidator<CreateTodoList>
	{
		public Validator()
			=> RuleFor(x => x.Dto)
				.NotNull()
				.SetValidator(new CreateTodoListDto.Validator());
	}

	public class CreateTodoListHandler : IRequestHandler<CreateTodoList>
	{
		public async Task Handle(CreateTodoList request, CancellationToken cancellationToken)
		{
			// create the list
		}
	}
}