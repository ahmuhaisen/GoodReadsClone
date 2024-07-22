namespace GoodReadsClone.Application.Abstractions;


public interface IEmailService
{
    Task<bool> IsRisky(string email);

}
