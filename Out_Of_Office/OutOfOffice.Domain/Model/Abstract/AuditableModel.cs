namespace OutOfOffice.Domain.Model.Abstract;

public abstract class AuditableModel
{
    //[Required]
    public required string CreatorId { get; set; }
    //[Required]
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public string? ModifierId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
}
//TODO