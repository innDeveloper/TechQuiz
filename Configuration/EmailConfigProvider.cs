using OnesTechSecureAccessGuard.Entities;

namespace OnesTechSecureAccessGuard.Configuration
{
    public static class EmailConfigProvider
    {
        public static EmailConfig GetEmailConfig()
        {
            
            MyIniFile iniFile = new MyIniFile(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.ToString());

            string smtpServer = iniFile.ReadValue("SMTPSettings", "Server");
            int smtpPort = int.TryParse(iniFile.ReadValue("SMTPSettings", "Port"), out int parsedPort) ? parsedPort : 0;
            string smtpUsername = iniFile.ReadValue("SMTPSettings", "Username", "");
            string smtpPassword = iniFile.ReadValue("SMTPSettings", "Password", "");

            return new EmailConfig
            {
                SmtpServer = smtpServer,
                SmtpPort = smtpPort,
                SmtpUsername = smtpUsername,
                SmtpPassword = smtpPassword
            };
        }
    }

}
