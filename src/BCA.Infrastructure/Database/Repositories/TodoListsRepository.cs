using BCA.Application.Contracts;
using BCA.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BCA.Infrastructure.Database.Repositories;

internal sealed class TodoListsRepository(ApplicationDbContext dbContext) 
	: Repository<TodoList>(dbContext), ITodoListsRepository
{
	public async Task<List<TodoList>> GetTodoLists(CancellationToken cancellationToken)
	{
		return await dbContext.Set<TodoList>().ToListAsync(cancellationToken);
	}

	public async Task<TodoList?> GetTodoList(int id, CancellationToken cancellationToken)
	{
		return await dbContext.Set<TodoList>()
			.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
	}
}