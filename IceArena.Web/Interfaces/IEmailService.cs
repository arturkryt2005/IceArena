using IceArena.Entities;

namespace IceArena.Web.Interfaces
{
    public interface IEmailService
    {
        Task<CustomErrorMessage> SendMessage(string recipientEmail);
    }
}