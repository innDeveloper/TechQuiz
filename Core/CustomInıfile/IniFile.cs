using System.Runtime.InteropServices;
using System.Text;

public class MyIniFile
{
    private readonly string filePath;

    public MyIniFile(string path)
    {
        filePath = path;
    }

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
    private static extern int GetPrivateProfileString(string section, string key, string defaultValue, StringBuilder value, int size, string filePath);

    public string ReadValue(string section, string key, string defaultValue = "")
    {
        const int bufferSize = 255; // Puffer 
        StringBuilder smtpServerBuffer = new StringBuilder(bufferSize);
        GetPrivateProfileString("SMTPSettings", "Server", "", smtpServerBuffer, bufferSize, filePath);
        string smtpServer = smtpServerBuffer.ToString();
        return smtpServer;
    }
}
