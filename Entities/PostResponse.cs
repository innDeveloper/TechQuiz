using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnesTechSecureAccessGuard.Entities
{
    public class PostResponse
    {
        private string? logID;
        private string? description;

        public string? LogID
        {
            get { return logID; }
            set { logID = value; }
        }
        public string? Description
        {
            get { return description; }
            set { description = value; }
        }
        public PostResponse(string logID, string description)
        {
            LogID = logID;
            Description = description;
        }
    }
}
