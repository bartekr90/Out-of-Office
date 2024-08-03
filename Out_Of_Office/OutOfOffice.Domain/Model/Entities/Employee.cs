using OutOfOffice.Domain.Model.Abstract;

namespace OutOfOffice.Domain.Model.Entities;

public class Employee : BaseEntity
{   
    public required string FullName { get; set; }       
    public bool Status { get; set; }
    public int SubdivisionId { get; set; }
    public int PositionId { get; set; }
    public int PeoplePartnerId { get; set; }
    public int OutOfOfficeBalance { get; set; }
    public byte[]? Photo { get; set; }

    public required virtual Subdivision Subdivision { get; set; }
    public required virtual Position Position { get; set; }        
    public virtual Employee? PeoplePartner { get; set; }
    public virtual ICollection<LeaveRequest>? LeaveRequests { get; set; }
    public virtual ICollection<ApprovalRequest>? ApprovalRequests { get; set; } 
    public virtual ICollection<Project>? Projects { get; set; }
    public virtual ICollection<Employee>? Subordinates { get; set; } 
}
