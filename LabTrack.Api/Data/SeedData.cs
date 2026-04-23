using LabTrack.Api.Models;

namespace LabTrack.Api.Data;

public static class SeedData
{
    public static void Initialize(AppDbContext context)
    {
        if (context.Samples.Any())
            return;

        var samples = new List<Sample>
        {
            new Sample
            {
                Reference = "LAB-001",
                ClientName = "Mairie de Lorient",
                ReceivedAt = DateTime.UtcNow.AddDays(-2),
                Status = SampleStatus.Received
            },
            new Sample
            {
                Reference = "LAB-002",
                ClientName = "Entreprise X",
                ReceivedAt = DateTime.UtcNow.AddDays(-1),
                Status = SampleStatus.InProgress
            },
            new Sample
            {
                Reference = "LAB-003",
                ClientName = "Laboratoire Y",
                ReceivedAt = DateTime.UtcNow,
                Status = SampleStatus.Completed
            }
        };

        context.Samples.AddRange(samples);
        context.SaveChanges();
    }
}