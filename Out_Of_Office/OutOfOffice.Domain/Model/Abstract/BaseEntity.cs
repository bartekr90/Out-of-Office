namespace OutOfOffice.Domain.Model.Abstract;

public abstract class BaseEntity : AuditableModel
{
    public int Id { get; set; }
    public bool Deleted { get; set; }
    public string? DeletedBy { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
}