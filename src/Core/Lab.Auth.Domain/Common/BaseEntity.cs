namespace Lab.Auth.Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public virtual DateTime? UpdatedDate { get; set; }
}