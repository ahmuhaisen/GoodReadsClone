namespace GoodReadersClone.Api.Helpers;

public class JwtOptions
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int DurationInMinuets { get; set; }
    public string SigningKey { get; set; }
}

