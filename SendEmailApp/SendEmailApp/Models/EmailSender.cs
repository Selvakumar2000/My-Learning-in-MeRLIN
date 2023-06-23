using MailKit.Net.Smtp; //important import
using MimeKit;
using SendEmailApp.Interfaces;
using SendEmailApp.Models;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public class EmailSender : IEmailSender
{
    private readonly EmailConfiguration _emailConfig;
    public EmailSender(EmailConfiguration emailConfig)
    {
        _emailConfig = emailConfig;
    }
    //public void SendEmail(Message message)
    //{
    //    var emailMessage = CreateEmailMessage(message);
    //    Send(emailMessage);
    //}

    public async Task SendEmailAsync(Message message, string username)
    {
        var mailMessage = CreateEmailMessage(message, username);

        await SendEmailAsync(mailMessage);
    }

    private MimeMessage CreateEmailMessage(Message message, string username)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
        emailMessage.To.AddRange(message.To);
        emailMessage.Subject = message.Subject;

        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = string.Format("<h3 style='color:green'>{0} </h3>" +
                                  "<h4 style='color:black'>Hi {1}, " +
                                  "<p style='color:black'> Welcome To India's Largest Online Shopping Portal</p>" +
                                  "</h4><br>"+ "contact <strong>shopmeportal@gmail.com</strong> for your queries related to ShopMe",
                                   message.Content, username)
         };

        return emailMessage;
        //emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

        //emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        //{ 
        //    Text = string.Format("<h2 style='color:red'>{0}</h2>", message.Content)
        //};

        //var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h4 style='color:black'>{0}</h4>", message.Content) };

        //if(message.Attachements != null && message.Attachements.Any())
        //{
        //    byte[] fileBytes;
        //    foreach(var attachements in message.Attachements)
        //    {
        //        using var ms = new MemoryStream();
        //        attachements.CopyTo(ms);
        //        fileBytes = ms.ToArray();

        //        bodyBuilder.Attachments.Add(attachements.FileName, fileBytes, ContentType.Parse(attachements.ContentType));

        //    }
        //}

        //emailMessage.Body = bodyBuilder.ToMessageBody();

    }

    //private void Send(MimeMessage mailMessage)
    //{
    //    using var client = new SmtpClient();
    //    try
    //    {
    //        client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
    //        client.AuthenticationMechanisms.Remove("XOAUTH2");
    //        client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
    //        client.Send(mailMessage);
    //    }
    //    catch
    //    {
    //        throw;
    //    }
    //    finally
    //    {
    //        client.Disconnect(true);
    //        client.Dispose();
    //    }
    //}

    private async Task SendEmailAsync(MimeMessage mailMessage)
    {
        using var client = new SmtpClient();
        try
        {
            await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);
            await client.SendAsync(mailMessage);
        }
        catch
        {
            throw;
        }
        finally
        {
            await client.DisconnectAsync(true);
            client.Dispose();
        }
    }
}