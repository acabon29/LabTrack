
using System.ComponentModel.DataAnnotations;

namespace LabTrack.Api.Dtos.Sample;

public class CreateSampleDto
{
    [Required] // a quoii sert le Required ? => comment ca fonctionne ?
    public string Reference { get; set; } = "";

    [Required]
    public string ClientName { get; set; } = "";
}