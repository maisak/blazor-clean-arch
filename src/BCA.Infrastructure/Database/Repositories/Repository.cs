using BCA.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace BCA.Infrastructure.Database.Repositories;

internal abstract class Repository<TEntity>(ApplicationDbContext dbContext)
	where TEntity : BaseEntity
{
	public async Task<int> Add(TEntity entity, CancellationToken cancellationToken)
	{
		await dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
		return await dbContext.SaveChangesAsync(cancellationToken);
	}

	public async Task<int> Update(TEntity entity, CancellationToken cancellationToken)
	{
		dbContext.Set<TEntity>().Update(entity);
		var result = await dbContext.SaveChangesAsync(cancellationToken);
		dbContext.ChangeTracker.Clear();
		return result;
	}

	public async Task<TEntity?> GetById(int id, CancellationToken cancellationToken)
	{
		return await dbContext.Set<TEntity>().SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
	}

	public async Task Delete(int id, CancellationToken cancellationToken)
	{
		var query = dbContext.Set<TEntity>().Where(x => x.Id == id);

		if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
		{
			await query.ExecuteUpdateAsync(setters
				=> setters.SetProperty(x
					=> ((ISoftDelete)x).DeletedAt, DateTimeOffset.UtcNow), cancellationToken);

			return;
		}

		await query.ExecuteDeleteAsync(cancellationToken);
	}
	
	public async Task Restore(int id, CancellationToken cancellationToken)
	{
		var query = dbContext.Set<TEntity>().IgnoreQueryFilters().Where(x => x.Id == id);

		if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
		{
			await query.ExecuteUpdateAsync(setters
				=> setters.SetProperty(x
					=> ((ISoftDelete)x).DeletedAt, null as DateTimeOffset?), cancellationToken);

			return;
		}

		throw new NotSupportedException("Entity does not support soft delete.");
	}
}