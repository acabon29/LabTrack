namespace LabTrack.Api.Models;

public class Analysis
{
    public int Id { get; set; }

    public string Type { get; set; } = ""; 
    // ex : "pH", "Température", "Bactérie"

    public string Result { get; set; } = ""; 
    // ex : "7.2", "Conforme", etc.

    public bool IsValidated { get; set; }

    public DateTime CreatedAt { get; set; }

    // 🔗 relation avec Sample
    public int SampleId { get; set; }
    public Sample? Sample { get; set; }
}