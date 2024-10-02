using BCA.Application.Contracts;
using BCA.Application.Validation;
using FluentValidation;
using MediatR;

namespace BCA.Application.Features.Todo;

public record DeleteTodoList(int Id) : IRequest
{
	public class Validator : AbstractValidator<DeleteTodoList>
	{
		public Validator() => RuleFor(x => x.Id).Id();
	}
	
	public class DeleteTodoListHandler(ITodoListsRepository repository) : IRequestHandler<DeleteTodoList>
	{
		public async Task Handle(DeleteTodoList request, CancellationToken cancellationToken)
		{
			await repository.Delete(request.Id, cancellationToken);
		}
	}
}