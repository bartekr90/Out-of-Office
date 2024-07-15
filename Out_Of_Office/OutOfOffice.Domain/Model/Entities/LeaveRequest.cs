using OutOfOffice.Domain.Model.Abstract;

namespace OutOfOffice.Domain.Model.Entities;

public class LeaveRequest : BaseEntity
{
    //[Required]
    public int EmployeeId { get; set; }

    //[Required]
    public int AbsenceReasonId { get; set; }

    //[Required]
    public int StatusId { get; set; }

    //[Required]
    public DateTimeOffset StartDate { get; set; }

    //[Required]
    public DateTimeOffset EndDate { get; set; }

    public string? Comment { get; set; }

    //[Required]
    //[MaxLength(10)]
    //public string Status { get; set; } = "New";

    //[ForeignKey("EmployeeId")]
    public required virtual Employee Employee { get; set; }

    //[ForeignKey("StatusId")]
    public required virtual Status Status { get; set; }

    //[ForeignKey("AbsenceReasonId")]
    public required virtual AbsenceReason AbsenceReason { get; set; }
}

//TODO