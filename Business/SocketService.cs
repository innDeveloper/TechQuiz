using OnesTechSecureAccessGuard.Core.LinkedList;
using OnesTechSecureAccessGuard.Entities;

namespace OnesTechSecureAccessGuard.Business
{
    public class SocketService : ISocketService
    {
        private readonly MyLinkedList<AccessLog> userCredentialsList;

        public SocketService()
        {
            userCredentialsList = new MyLinkedList<AccessLog>();
        }

        public void AddCredentials(AccessLog accessLog)
        {
            userCredentialsList.Add(accessLog);
        }

        public List<AccessLog> GetCredentialsList()
        {
            return userCredentialsList.ToList();
        }
    }
}
