using OutOfOffice.Domain.Model.Abstract;

namespace OutOfOffice.Domain.Model.Entities;

public class Project : BaseEntity
{
    public int ProjectTypeId { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset? EndDate { get; set; }
    public int ProjectManagerId { get; set; }
    public string? Comment { get; set; }
    public bool Status { get; set; }

    public required virtual ProjectType ProjectType { get; set; }
    public required virtual Employee ProjectManager { get; set; }
}

