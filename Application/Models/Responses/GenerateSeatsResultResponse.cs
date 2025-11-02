namespace Application.Models.Responses;

public class GenerateSeatsResultResponse
{
    public Guid SectorId { get; set; }
    public string SectorName { get; set; }
    public string ShapeType { get; set; }
    public int SeatsGenerated { get; set; }
    public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;
}