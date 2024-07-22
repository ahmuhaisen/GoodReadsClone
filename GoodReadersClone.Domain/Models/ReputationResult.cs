namespace GoodReadsClone.Domain.Models;
public class ReputationResult
{
    public ReputationDetails Details { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Reputation { get; set; } = string.Empty;
    public bool Suspicious { get; set; }
}
