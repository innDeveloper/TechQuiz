using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OnesTechSecureAccessGuard.Entities.Enums;

namespace OnesTechSecureAccessGuard.Entities
{
    public class AccessLog
    {
        private string? logID;
        private string? computerHash;
        private string? ipAddress;
        private string? userID;
        private string? username;
        private string? accessLocation;
        private AccessDirection? accessDirection;
        private VerifyStatusCode? verifyStatusCode;
        private string? additionalInfo;
        private DateTime? logTime;
        private string? description;

        public string? LogID
        {
            get { return logID; }
            set { logID = value; }
        }

        public string? ComputerHash
        {
            get { return computerHash; }
            set { computerHash = value; }
        }

        public string? IPAddress
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }

        public string? UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string? Username
        {
            get { return username; }
            set { username = value; }
        }

        public string? AccessLocation
        {
            get { return accessLocation; }
            set { accessLocation = value; }
        }

        public AccessDirection? AccessDirection
        {
            get { return accessDirection; }
            set { accessDirection = value; }
        }

        public VerifyStatusCode? VerifyStatusCode
        {
            get { return verifyStatusCode; }
            set { verifyStatusCode = value; }
        }

        public string? AdditionalInfo
        {
            get { return additionalInfo; }
            set { additionalInfo = value; }
        }

        public DateTime? LogTime
        {
            get { return logTime; }
            set { logTime = value; }
        }

        public string? Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
