namespace GoodReadersClone.Application.Abstractions;


public interface IEmailService
{
    Task<bool> IsRisky(string email);

}
