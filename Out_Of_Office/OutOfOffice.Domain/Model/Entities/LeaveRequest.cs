using OutOfOffice.Domain.Model.Abstract;

namespace OutOfOffice.Domain.Model.Entities;

public class LeaveRequest : BaseEntity
{
    public int EmployeeId { get; set; }
    public int AbsenceReasonId { get; set; }
    public int StatusId { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public string? Comment { get; set; }
    public required virtual Employee Employee { get; set; }
    public required virtual Status Status { get; set; }
    public required virtual AbsenceReason AbsenceReason { get; set; }
}
