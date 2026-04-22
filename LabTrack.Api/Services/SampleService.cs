using LabTrack.Api.Data;
using LabTrack.Api.Dtos.Sample;
using LabTrack.Api.Models;
using LabTrack.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LabTrack.Api.Services;

public class SampleService : ISampleService
{
    private readonly AppDbContext _context;

    public SampleService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<SampleResponseDto>> GetAllAsync()
    {
        return await _context.Samples
            .Select(s => new SampleResponseDto
            {
                Id = s.Id,
                Reference = s.Reference,
                ClientName = s.ClientName,
                Status = s.Status.ToString(),
                ReceivedAt = s.ReceivedAt
            })
            .ToListAsync();
    }

    public async Task<SampleResponseDto> CreateAsync(CreateSampleDto dto)
    {
        var sample = new Sample
        {
            Reference = dto.Reference,
            ClientName = dto.ClientName,
            ReceivedAt = DateTime.UtcNow
        };

        _context.Samples.Add(sample);
        await _context.SaveChangesAsync();

        return new SampleResponseDto
        {
            Id = sample.Id,
            Reference = sample.Reference,
            ClientName = sample.ClientName,
            Status = sample.Status.ToString(),
            ReceivedAt = sample.ReceivedAt
        };
    }

    public async Task<SampleResponseDto> UpdateStatusAsync(int id, UpdateSampleStatusDto dto)
    {
        var sample = await _context.Samples.FindAsync(id);
        if (sample == null)
            throw new KeyNotFoundException("Échantillon introuvable.");

        if (!Enum.TryParse<SampleStatus>(dto.Status, true, out var status))
            throw new ArgumentException("Statut invalide.", nameof(dto));

        sample.Status = status;
        await _context.SaveChangesAsync();

        return new SampleResponseDto
        {
            Id = sample.Id,
            Reference = sample.Reference,
            ClientName = sample.ClientName,
            Status = sample.Status.ToString(),
            ReceivedAt = sample.ReceivedAt
        };
    }
}