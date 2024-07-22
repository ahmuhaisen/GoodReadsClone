using GoodReadsClone.Application.Abstractions;

namespace GoodReadsClone.Application.Services;

public class EmailService : IEmailService
{
    public async Task<bool> IsRisky(string email)
    {
        //var httpClient = new HttpClient();
        //httpClient.DefaultRequestHeaders.Add("key", "THE_KEY");
        //httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("GoodReadsClone");

        //var result = await httpClient.GetFromJsonAsync<ReputationResult>($"https://emailrep.io/{email}");

        //return result.Details.Suspicious ||
        //    result.Details.Spam ||
        //    result.Details.MaliciousActivity ||
        //    result.Details.MaliciousActivityRecent;
        return true;
    }
}
