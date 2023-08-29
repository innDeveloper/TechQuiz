using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnesTechSecureAccessGuard.Entities
{
    public class EmailConfig
    {
        public string SmtpServer  { get; set; } =  "defaultSmtpServer";
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; } = "defaultSmtpUsername";
        public string SmtpPassword { get; set; } = "defaultSmtpPassword";
    }
}
