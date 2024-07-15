using OutOfOffice.Domain.Model.Abstract;

namespace OutOfOffice.Domain.Model.Entities;

public class ApprovalRequest : BaseEntity
{
    public int ApproverId { get; set; }
    public int LeaveRequestId { get; set; }
    public int StatusId { get; set; }

    //[Required]
    //[MaxLength(50)] // Assuming a reasonable length for status
    //public required string Status { get; set; }
    public string? Comment { get; set; }

    //[Required]
    public virtual required Employee Approver { get; set; }
    public virtual required LeaveRequest LeaveRequest { get; set; }
    public virtual required Status Status { get; set; }
}

//TODO

//Ensure the soft deletion logic(e.g., filtering out Deleted records) is implemented consistently in the repository or service layer.
// In a repository or DbContext
//modelBuilder.Entity<ApprovalRequest>().HasQueryFilter(e => !e.Deleted);
