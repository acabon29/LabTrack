namespace LabTrack.Api.Dtos.Sample;

public class SampleResponseDto
{
    public int Id { get; set; }
    public string Reference { get; set; } = string.Empty;
    public string ClientName { get; set; } = string.Empty;
    public DateTime ReceivedAt { get; set; }
    public string Status { get; set; } = string.Empty;
}