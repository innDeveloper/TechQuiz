namespace OnesTechSecureAccessGuard.Helper.Constants
{
    public static class Constant
    {
        public static Uri Uri { get; } = new Uri("https://interview.ones.com.tr/API/AccessLog");
        public static string locationLogPath = AppDomain.CurrentDomain.BaseDirectory + "logs";
        public static string Info = "Bilgi";
        public static string Error = "Bilgi";
        public static string GenericErrorMessage = "Hata oluştu: ";
        public static string JsonParseFailed = "JSON dönüşü boş veya geçersiz.";
        public static string TransactionConfirmed = "İşlem onaylandı.";
        public static string TransactionConfirmedButApiNotSend = "İşlem onaylandı ama api gönderilemedi.";
        public static string TransactionRejected = "İşlem onaylanmadı.";
        public static string NoActionWithin30Second = "30 saniye içinde işlem yapılmadı.";
        public static string Ok = "Ok";
        public static string Approval = "Onay";
        public static string Approve = "Onayla";
        public static string Cancel = "İptal et";
        public static string EmailError = "Email gönderilemedi.";
        public static string EmailSend = "Email başarıyla gönderildi.";
        public static string PostAccessLog = "Giriş bilgisi gönderildi.";
        public static string GetAccessLog = "Bilgiler başarıyla getirildi.";
        public static string UpdateDataGridview = "Datagridview güncellendi";
        public static string ApiQuotaExceeded = "Api sınırı aşıldı. İzin verileren sınır maximum 3 saniyede 1 api isteği.";
        public static string logPathError = "İzniniz olmayabilir. bin\\Debug\\net6.0-windows\\logs dosyasını manuel açabilirsiniz.";
    }
}
