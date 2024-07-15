using OutOfOffice.Domain.Model.Abstract;

namespace OutOfOffice.Domain.Model.Entities;

public class Project : BaseEntity
{
    // [Required]
    public int ProjectTypeId { get; set; }

    // [Required]
    public DateTimeOffset StartDate { get; set; }

    public DateTimeOffset? EndDate { get; set; }

    //[Required]
    public int ProjectManagerId { get; set; }

    public string? Comment { get; set; }

    //[Required]
    //[MaxLength(10)]
    //public string Status { get; set; }
    public bool Status { get; set; }

    //[ForeignKey("ProjectTypeId")]
    public required virtual ProjectType ProjectType { get; set; }

    // [ForeignKey("ProjectManagerId")]
    public required virtual Employee ProjectManager { get; set; }
}

