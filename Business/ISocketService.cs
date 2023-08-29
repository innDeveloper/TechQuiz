using OnesTechSecureAccessGuard.Entities;

namespace OnesTechSecureAccessGuard.Business
{
    public interface ISocketService
    {
        void AddCredentials(AccessLog accessLog);

        List<AccessLog> GetCredentialsList();
    }
}
