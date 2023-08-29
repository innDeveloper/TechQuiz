using OnesTechSecureAccessGuard.Entities;

namespace OnesTechSecureAccessGuard.Helper.Constants
{
    public class LogMessageBuilder
    {
        public static string BuildLogMessage(AccessLog accessLog)
        {
            return $"Log ID: {accessLog.LogID}\n" +
                   $"Computer Hash: {accessLog.ComputerHash}\n" +
                   $"IP Address: {accessLog.IPAddress}\n" +
                   $"User ID: {accessLog.UserID}\n" +
                   $"Username: {accessLog.Username}\n" +
                   $"Access Location: {accessLog.AccessLocation}\n" +
                   $"Access Direction: {accessLog.AccessDirection}\n" +
                   $"Verify Status Code: {accessLog.VerifyStatusCode}\n" +
                   $"Additional Info: {accessLog.AdditionalInfo}\n" +
                   $"Log Time: {accessLog.LogTime}";
        }
    }
}
