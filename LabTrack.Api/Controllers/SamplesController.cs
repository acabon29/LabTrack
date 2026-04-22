using LabTrack.Api.Data;
using LabTrack.Api.Dtos.Sample;
using LabTrack.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabTrack.Api.Controllers;


// comment ca fonctionne exactement ?
[ApiController]
[Route("api/[controller]")]
public class SamplesController : ControllerBase
{
    private readonly AppDbContext _context;

    public SamplesController(AppDbContext context)
    {
        _context = context;
    }

// comment le programme sait que c'est api/samples ?
// Quand tu seras à l’aise, tu pourras :
// deplacer la logique dans un Service
// ajouter validation
// gérer les erreurs

    // POST: api/samples
    [HttpPost]
    public async Task<IActionResult> CreateSample(CreateSampleDto dto)
    {
        var sample = new Sample
        {
            Reference = dto.Reference,
            ClientName = dto.ClientName,
            ReceivedAt = DateTime.UtcNow,
            Status = SampleStatus.Received
        };

        _context.Samples.Add(sample);
        await _context.SaveChangesAsync();

        var response = new SampleResponseDto
        {
            Id = sample.Id,
            Reference = sample.Reference,
            ClientName = sample.ClientName,
            ReceivedAt = sample.ReceivedAt,
            Status = sample.Status.ToString()
        };

        return Ok(response);
    }
}
