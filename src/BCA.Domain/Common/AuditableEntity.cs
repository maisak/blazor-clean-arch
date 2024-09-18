namespace BCA.Domain.Common;

public abstract class AuditableEntity : IEntity
{
	public int Id { get; set; }  
	public string CreatedBy { get; set; } = string.Empty;
	public DateTimeOffset CreatedDate { get; set; }
	public string LastModifiedBy { get; set; } = string.Empty;
	public DateTimeOffset? LastModifiedDate { get; set; }
}