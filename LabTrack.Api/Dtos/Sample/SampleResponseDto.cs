namespace LabTrack.Api.Dtos.Sample;

public class SampleResponseDto
{
    public int Id { get; set; }
    public string Reference { get; set; } = "";
    public string ClientName { get; set; } = "";
    public DateTime ReceivedAt { get; set; }
    public string Status { get; set; } = "";
}