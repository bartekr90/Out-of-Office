namespace OutOfOffice.Domain.Model.Abstract;

public abstract class SelectionType : BaseEntity
{
    public required string Name { get; set; }
}