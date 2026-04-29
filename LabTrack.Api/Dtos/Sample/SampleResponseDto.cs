using System.ComponentModel.DataAnnotations;

namespace LabTrack.Api.Dtos.Sample;

public class SampleResponseDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Reference { get; set; } = "";
    [Required]
    public string ClientName { get; set; } = "";
    [Required]
    public DateTime ReceivedAt { get; set; }
    [Required]
    public string Status { get; set; } = "";
}