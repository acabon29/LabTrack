using LabTrack.Api.Data;
using LabTrack.Api.Dtos.Sample;
using LabTrack.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using LabTrack.Api.Services;

namespace LabTrack.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class SamplesController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly SampleService _sampleService;

    public SamplesController(AppDbContext context, SampleService sampleService)
    {
        _context = context;
        _sampleService = sampleService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSample(CreateSampleDto dto)
    {
        SampleResponseDto response = await _sampleService.CreateAsync(dto);
        
        return Ok(response); // CreatedAtAction ?
        // return Created("", response);
        // renvoie la réponse avec un lien vers la ressource :
        // return CreatedAtAction(
        //     nameof(GetSampleById), // fonction utilisé permettant de récupérer l'objet en question
        //     new { id = response.Id },
        //     response
        // );
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSamples()
    {
        var samples = await _sampleService.GetAllAsync();
        return Ok(samples);
    }

    // [HttpPut("{id}")]
    // public async Task<IActionResult> UpdateSample(int id, CreateSampleDto dto) // ne pas utiliser ce dto
    // {

    //     var sample = await _context.Samples.FindAsync(id);

    //     if (sample == null)
    //         return NotFound();


    //     var samples = await _context.Samples
    //         .Select(sample => new SampleResponseDto
    //         {
    //             Id = sample.Id,
    //             Reference = sample.Reference,
    //             ClientName = sample.ClientName,
    //             ReceivedAt = sample.ReceivedAt,
    //             Status = sample.Status.ToString()
    //         })
    //         .ToListAsync();

        
    //     _context.Samples.Update(sample);
    //     await _context.SaveChangesAsync();


    //     return Ok(null);
    // }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSample(int id)
    {
        bool isDelete = await _sampleService.DeleteAsync(id);

        if (isDelete)
            return NoContent();

        return NotFound();
    }


    // faire ceci rajoute a la route déjà existante (api/samples), ce qui donne : /api/samples/api/test
    //     [Route("api/test")]
    // faire cei fait la meme chose :
    // [HttpPost("api/test")]
    // ici : chmain absolut
    // [HttpPost("/api/test")]
    // public IActionResult test()
    // {
    //     Console.WriteLine("gfsgfdsg test");
    //     return Ok("test");
    // }
}
