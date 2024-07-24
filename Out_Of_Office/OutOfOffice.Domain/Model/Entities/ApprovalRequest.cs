using OutOfOffice.Domain.Model.Abstract;

namespace OutOfOffice.Domain.Model.Entities;

public class ApprovalRequest : BaseEntity
{
    public int ApproverId { get; set; }
    public int LeaveRequestId { get; set; }
    public int StatusId { get; set; }
    public string? Comment { get; set; }

    public virtual required Employee Approver { get; set; }
    public virtual required LeaveRequest LeaveRequest { get; set; }
    public virtual required Status Status { get; set; }
}
