namespace LabTrack.Api.Models;

public enum SampleStatus
{
    Received,
    InProgress,
    Completed
}

public class Sample
{
    public int Id { get; set; }
    public string Reference { get; set; } = ""; // ou string.Empty => nessessaire a une epoque pour des optis
    public string ClientName { get; set; } = "";
    public DateTime ReceivedAt { get; set; }
    public SampleStatus Status { get; set; } = SampleStatus.Received; // Received, InProgress, Completed

    // public List<Analysis> Analyses { get; set; } = new();
}