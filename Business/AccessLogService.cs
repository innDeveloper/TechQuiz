using Newtonsoft.Json;
using OnesTechSecureAccessGuard.Core.CustomNLog;
using OnesTechSecureAccessGuard.Entities;
using OnesTechSecureAccessGuard.Helper.Constants;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;

namespace OnesTechSecureAccessGuard.Business
{
    public class AccessLogService
    {
        private readonly ISocketService _socketService;
        private  readonly INLogLogger _nLogLogger;

        public AccessLogService(ISocketService socketService)
        {
            _nLogLogger = new NLogLogger("ServiceLogger");
            _socketService = socketService;
        }
        public AccessLog GetAccess(Uri? uri = null, int port = 443, CancellationToken cancellationToken = default)
        {
            uri ??= Constant.Uri;
            AccessLog accessLog;
            using (TcpClient client = new(uri.Host, port))
            using (SslStream sslStream = new(client.GetStream(), false))
            {
                sslStream.AuthenticateAsClient(uri.Host);

                string request = "GET /API/AccessLog HTTP/1.1\r\n" +
                                 "Host: " + uri.Host + "\r\n" +
                                 "Connection: close\r\n\r\n";

                byte[] requestBytes = Encoding.ASCII.GetBytes(request);
                sslStream.Write(requestBytes, 0, requestBytes.Length);
                sslStream.Flush();

                #region Since the Tcpclient class returns chunked data, I needed to split the code.
                StreamReader reader = new(sslStream);
                string response = reader.ReadToEnd();
                int startIdx = response.IndexOf('{');
                int endIdx = response.IndexOf('}');
                if (startIdx >= 0)
                {
                    response = response.Substring(startIdx, endIdx - startIdx + 1);
                }
                #endregion
                accessLog = JsonConvert.DeserializeObject<AccessLog>(response) ?? new AccessLog();
                _nLogLogger.Info(Constant.GetAccessLog);
                _socketService.AddCredentials(accessLog);

            }
            return accessLog;
        }

        public static async Task<bool> PostAccess(AccessLog accessLog, Uri? uri = null, int port = 443, CancellationToken cancellationToken = default)
        {
            uri ??= Constant.Uri;
            using TcpClient client = new(uri.Host, port);
            using SslStream sslStream = new(client.GetStream(), false);
            sslStream.AuthenticateAsClient(uri.Host);


            PostResponse postResponse1 = new(accessLog.LogID, "Geçiş Onaylandı.");
            PostResponse postResponse = postResponse1;
            PostResponse logData = postResponse;
            string jsonData = JsonConvert.SerializeObject(logData);
            byte[] requestBytes = Encoding.ASCII.GetBytes(jsonData);

            string request = "POST /API/AccessLog HTTP/1.1\r\n" +
                             "Host: " + uri.Host + "\r\n" +
                             "Content-Type: application/json\r\n" +
                             "Content-Length: " + requestBytes.Length + "\r\n" +
                             "Connection: close\r\n\r\n";

            byte[] headerBytes = Encoding.ASCII.GetBytes(request);
            await sslStream.WriteAsync(headerBytes, 0, headerBytes.Length, cancellationToken);
            await sslStream.WriteAsync(requestBytes, 0, requestBytes.Length, cancellationToken);
            await sslStream.FlushAsync(cancellationToken);

            MemoryStream responseStream = new();
            byte[] buffer = new byte[4096];
            int bytesRead;

            while ((bytesRead = await sslStream.ReadAsync(buffer, 0, buffer.Length, cancellationToken)) > 0)
            {
                responseStream.Write(buffer, 0, bytesRead);
            }

            responseStream.Seek(0, SeekOrigin.Begin);
            StreamReader reader = new(responseStream);
            string response = await reader.ReadToEndAsync();
            #region Since the Tcpclient class returns chunked data, I needed to split the code.
            string[] lines = response.Split(new[] { "\r\n" }, StringSplitOptions.None);
            return lines.Length > 0 && lines[0].StartsWith("HTTP/1.1 200");
            #endregion
        }

        public List<AccessLog> GetAccessLogs()
        {
            return _socketService.GetCredentialsList();
        }

    }
}


