using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnesTechSecureAccessGuard.Entities
{
    public class Enums
    {
        public enum VerifyStatusCode
        {
            Success = 0,
            NotFound = 1,
            NotEnrolled = 2,
            NotAllowedBioType = 3,
            NotVerified = 4,
            CardNotSupported = 5
        }

        public enum AccessDirection
        {
            Out = 0,
            In = 1
        }
    }
}
