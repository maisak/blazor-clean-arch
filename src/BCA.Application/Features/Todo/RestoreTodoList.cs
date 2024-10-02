using BCA.Application.Contracts;
using BCA.Application.Validation;
using FluentValidation;
using MediatR;

namespace BCA.Application.Features.Todo;

public record RestoreTodoList(int Id) : IRequest
{
	public class Validator : AbstractValidator<RestoreTodoList>
	{
		public Validator() => RuleFor(x => x.Id).Id();
	}

	public class RestoreTodoListHandler(ITodoListsRepository repository) 
		: IRequestHandler<RestoreTodoList>
	{
		public async Task Handle(RestoreTodoList request, CancellationToken cancellationToken)
		{
			await repository.Restore(request.Id, cancellationToken);
		}
	}
}