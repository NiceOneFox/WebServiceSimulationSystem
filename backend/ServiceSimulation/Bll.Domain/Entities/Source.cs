namespace Bll.Domain.Entities;

public class Source
{
    public int SourceId { get; set; }
    public int Priority { get; set; }
    public int SerialNumber { get; set; }
    public double TimeOfNextRequest { get; set; }
    public double Lambda { get; set; } = 5;
}