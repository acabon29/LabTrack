
using System.ComponentModel.DataAnnotations;

namespace LabTrack.Api.Dtos.Sample;

public class CreateSampleDto
{
    [Required]
    public string Reference { get; set; } = "";

    [Required]
    public string ClientName { get; set; } = "";
}