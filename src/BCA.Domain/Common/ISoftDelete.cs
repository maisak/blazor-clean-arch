namespace BCA.Domain.Common;

public interface ISoftDelete
{
	public DateTimeOffset? DeletedAt { get; set; }
}