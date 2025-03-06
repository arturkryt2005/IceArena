using Blazored.LocalStorage;
using IceArena.Entities;
using IceArena.Web.Interfaces;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Logging;

public class EmailService : IEmailService
{
    private readonly ILocalStorageService _localStorage;
    private readonly ILogger<EmailService> _logger;

    public EmailService(ILocalStorageService localStorage, ILogger<EmailService> logger)
    {
        _localStorage = localStorage;
        _logger = logger;
    }

    public async Task<CustomErrorMessage> SendMessage()
    {
        _logger.LogInformation("Начало отправки сообщения.");
        string recipientEmail = await _localStorage.GetItemAsync<string>("email");

        if (string.IsNullOrWhiteSpace(recipientEmail))
        {
            return new CustomErrorMessage
            {
                ErrorMessage = "Email пользователя не найден в локальном хранилище.",
                Success = false
            };
        }

        try
        {
            _logger.LogInformation("Попытка отправки письма на {RecipientEmail}", recipientEmail);

            var smtp = new SmtpClient("smtp.mail.ru", 587)
            {
                Credentials = new NetworkCredential("s1mplenote@mail.ru", "YYwD1yKQv5bySPgJ51W2"),
                EnableSsl = true
            };

            var mail = new MailMessage
            {
                From = new MailAddress("s1mplenote@mail.ru")
            };

            mail.To.Add(recipientEmail);
            mail.Subject = "Подтверждение бронирования";
            mail.Body = "Ваше бронирование подтверждено!";
            mail.IsBodyHtml = true;

            await smtp.SendMailAsync(mail);
            _logger.LogInformation("Письмо успешно отправлено на {RecipientEmail}", recipientEmail);
            return new CustomErrorMessage
            {
                ErrorMessage = $"Письмо успешно отправлено на {recipientEmail}.",
                Success = true
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при отправке письма на {RecipientEmail}", recipientEmail);
            return new CustomErrorMessage
            {
                ErrorMessage = ex.Message,
                Success = false
            };
        }
    }
}
