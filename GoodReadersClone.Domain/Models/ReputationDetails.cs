namespace GoodReadersClone.Domain.Models;
public class ReputationDetails
{
    public bool BlackListed { get; set; }
    public bool MaliciousActivity { get; set; }
    public bool MaliciousActivityRecent { get; set; }
    public bool Spam { get; set; }
    public bool Suspicious { get; set; }
}
