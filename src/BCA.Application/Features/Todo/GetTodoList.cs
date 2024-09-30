using AutoMapper;
using BCA.Application.Contracts;
using BCA.Application.Models.Todo;
using MediatR;

namespace BCA.Application.Features.Todo;

public record GetTodoList(int Id) : IRequest<TodoListDto>
{
	public class GetTodoListHandler(ITodoListsRepository repository, IMapper mapper) 
		: IRequestHandler<GetTodoList, TodoListDto>
	{
		public async Task<TodoListDto> Handle(GetTodoList request, CancellationToken cancellationToken)
		{
			var lists = await repository.GetTodoList(request.Id, cancellationToken);
			return mapper.Map<TodoListDto>(lists);
		}
	}
}