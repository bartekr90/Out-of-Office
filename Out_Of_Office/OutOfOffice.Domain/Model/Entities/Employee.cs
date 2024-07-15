using OutOfOffice.Domain.Model.Abstract;

namespace OutOfOffice.Domain.Model.Entities;

public class Employee : BaseEntity
{
    //[Required]
    //[MaxLength(100)] // Assuming a reasonable length for full name
    public required string FullName { get; set; }

    //[Required]
    //[MaxLength(50)] // Assuming a reasonable length for subdivision
    //public string Subdivision { get; set; }

    ////[Required]
    ////[MaxLength(50)] // Assuming a reasonable length for position
    //public string Position { get; set; }

    //[Required]   
    public bool Status { get; set; }

    //[Required]
    public int SubdivisionId { get; set; }

    //[Required]
    public int PositionId { get; set; }

    //[Required]
    public int PeoplePartnerId { get; set; }

    //[Required]
    //[Range(0, int.MaxValue, ErrorMessage = "Out-of-Office Balance must be a non-negative number.")]
    public int OutOfOfficeBalance { get; set; }

    public byte[]? Photo { get; set; }

    //[ForeignKey("SubdivisionId")]
    public required virtual Subdivision Subdivision { get; set; }

    //[ForeignKey("PositionId")]
    public required virtual Position Position { get; set; }
        
    //[ForeignKey("PeoplePartnerId")]
    public virtual Employee? PeoplePartner { get; set; }

    public virtual ICollection<LeaveRequest>? LeaveRequests { get; set; }
    public virtual ICollection<ApprovalRequest>? ApprovalRequests { get; set; } 
    public virtual ICollection<Project>? Projects { get; set; }
    public virtual ICollection<Employee>? Subordinates { get; set; } 
}

//TODO