using OnesTechSecureAccessGuard.Core.MailSender;
using OnesTechSecureAccessGuard.Helper.Constants;
using System;
using System.Net;
using System.Net.Mail;

public class EmailSender : IEmailSender
{
    private readonly string smtpServer;
    private readonly int smtpPort;
    private readonly string smtpUsername;
    private readonly string smtpPassword;

    public EmailSender(string server, int port, string username, string password)
    {
        smtpServer = server;
        smtpPort = port;
        smtpUsername = username;
        smtpPassword = password;
    }

    public bool SendEmail(string to, string subject, string body)
    {
        try
        {
            using SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
            smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            smtpClient.EnableSsl = true;

            using (MailMessage mailMessage = new())
            {
                mailMessage.From = new MailAddress(smtpUsername);
                mailMessage.To.Add(to);
                mailMessage.Subject = subject;
                mailMessage.Body = body;

                smtpClient.Send(mailMessage);
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(Constant.EmailError +"\n"+ ex.Message.ToString());
            return false;
        }
    }
}
