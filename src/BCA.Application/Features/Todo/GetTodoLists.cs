using AutoMapper;
using BCA.Application.Contracts;
using BCA.Application.Models.Todo;
using MediatR;

namespace BCA.Application.Features.Todo;

public record GetTodoLists : IRequest<List<TodoListDto>>
{
	public class GetTodoListsHandler(ITodoListsRepository repository, IMapper mapper) 
		: IRequestHandler<GetTodoLists, List<TodoListDto>>
	{
		public async Task<List<TodoListDto>> Handle(GetTodoLists request, CancellationToken cancellationToken)
		{
			var lists = await repository.GetTodoLists(cancellationToken);
			return mapper.Map<List<TodoListDto>>(lists);
		}
	}
}