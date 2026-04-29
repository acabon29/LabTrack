using LabTrack.Api.Data;
using LabTrack.Api.Dtos.Sample;
using LabTrack.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace LabTrack.Api.Services;

public class SampleService
{
    private readonly AppDbContext _context;

    public SampleService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<SampleResponseDto> CreateAsync(CreateSampleDto dto)
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

        return (response);   
    }

    public async Task<List<SampleResponseDto>> GetAllAsync()
    {
        var samples = await _context.Samples
            .Select(sample => new SampleResponseDto
            {
                Id = sample.Id,
                Reference = sample.Reference,
                ClientName = sample.ClientName,
                ReceivedAt = sample.ReceivedAt,
                Status = sample.Status.ToString()
            })
            .ToListAsync();

        return samples;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var sample = await _context.Samples.FindAsync(id);

        if (sample == null) // on peut faire aussi "is null"
            return false;

        _context.Samples.Remove(sample);
        await _context.SaveChangesAsync();

        return true;
    }

   
}