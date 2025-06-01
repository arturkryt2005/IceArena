using Blazored.LocalStorage;
using IceArena.Entities;
using IceArena.Web.Interfaces;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Logging;

public class EmailService : IEmailService
{
    private readonly ILogger<EmailService> _logger;

    public EmailService(ILogger<EmailService> logger)
    {
        _logger = logger;
    }

    public async Task<CustomErrorMessage> SendMessage(string recipientEmail)
    {
        _logger.LogInformation("Начало отправки сообщения на {RecipientEmail}", recipientEmail);

        if (string.IsNullOrWhiteSpace(recipientEmail))
        {
            return new CustomErrorMessage
            {
                ErrorMessage = "Email получателя не указан.",
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
            mail.Body = @"
                <h1>Ваше бронирование подтверждено!</h1>
                <p>Спасибо за использование нашего сервиса.</p>
                <p>Вы можете просмотреть детали вашего бронирования в личном кабинете.</p>
                <p>С уважением,<br>Команда IceArena</p>";
            mail.IsBodyHtml = true;

            await smtp.SendMailAsync(mail);
            _logger.LogInformation("Письмо успешно отправлено на {RecipientEmail}", recipientEmail);
            return new CustomErrorMessage
            {
                ErrorMessage = string.Empty,
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