using LabTrack.Api.Dtos.Sample;

namespace LabTrack.Api.Services.Interfaces;

public interface ISampleService
{

    // c'est quoi tout ca ? C'est quoi task ?
    Task<List<SampleResponseDto>> GetAllAsync();
    Task<SampleResponseDto> CreateAsync(CreateSampleDto dto);
    Task<SampleResponseDto> UpdateStatusAsync(int id, UpdateSampleStatusDto dto);
}