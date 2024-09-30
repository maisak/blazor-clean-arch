using AutoMapper;
using BCA.Application.Contracts;
using BCA.Application.Models.Todo;
using BCA.Domain.Entities;
using FluentValidation;
using MediatR;

namespace BCA.Application.Features.Todo;

public record SaveTodoList(TodoListDto Dto) : IRequest
{
	public class Validator : AbstractValidator<SaveTodoList>
	{
		public Validator()
			=> RuleFor(x => x.Dto)
				.NotNull()
				.SetValidator(new TodoListDto.Validator());
	}

	public class SaveTodoListHandler(ITodoListsRepository repository, IMapper mapper) : IRequestHandler<SaveTodoList>
	{
		public async Task Handle(SaveTodoList request, CancellationToken cancellationToken)
		{
			var entity = mapper.Map<TodoList>(request.Dto);
			if (request.Dto.Id == 0)
			{
				await repository.Add(entity, cancellationToken);
			}
			else
			{
				await repository.Update(entity, cancellationToken);
			}
		}
	}
}