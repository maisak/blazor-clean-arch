using AutoMapper;
using BCA.Application.Contracts;
using BCA.Application.Models.Todo;
using MediatR;

namespace BCA.Application.Features.Todo;

public record GetDeletedTodoLists : IRequest<List<TodoListDto>>
{
	public class GetDeletedTodoListsHandler(ITodoListsRepository repository, IMapper mapper) 
		: IRequestHandler<GetDeletedTodoLists, List<TodoListDto>>
	{
		public async Task<List<TodoListDto>> Handle(GetDeletedTodoLists request, CancellationToken cancellationToken)
		{
			var lists = await repository.GetDeletedTodoLists(cancellationToken);
			return mapper.Map<List<TodoListDto>>(lists);
		}
	}
}