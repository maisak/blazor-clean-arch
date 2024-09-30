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
}