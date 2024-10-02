using BCA.Domain.Entities;

namespace BCA.Application.Contracts;

public interface ITodoListsRepository
{
	Task<int> Add(TodoList entity, CancellationToken cancellationToken);
	Task<int> Update(TodoList entity, CancellationToken cancellationToken);
	Task<List<TodoList>> GetTodoLists(CancellationToken cancellationToken);
	Task<List<TodoList>> GetDeletedTodoLists(CancellationToken cancellationToken);
	Task<TodoList?> GetTodoList(int id, CancellationToken cancellationToken);
	Task Delete(int id, CancellationToken cancellationToken);
	Task Restore(int id, CancellationToken cancellationToken);
}