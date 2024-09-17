using BCA.Application.Models.Todo;
using MediatR;

namespace BCA.Application.Features.Todo;

public record GetTodoLists : IRequest<IEnumerable<TodoListDto>>
{
	public class GetTodoListsHandler : IRequestHandler<GetTodoLists, IEnumerable<TodoListDto>>
	{
		public async Task<IEnumerable<TodoListDto>> Handle(GetTodoLists request, CancellationToken cancellationToken)
		{
			return null;
		}
	}
}