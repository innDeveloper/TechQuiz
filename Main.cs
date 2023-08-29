// Form1.cs
using OnesTechSecureAccessGuard.Business;
using OnesTechSecureAccessGuard.Core.CustomPopup;
using OnesTechSecureAccessGuard.Entities;
using OnesTechSecureAccessGuard.Helper.Constants;
using OnesTechSecureAccessGuard.Core.MailSender;
using OnesTechSecureAccessGuard.Configuration;
using OnesTechSecureAccessGuard.Core.CustomNLog;
using System.Diagnostics;

namespace OnesTechSecureAccessGuard
{
    //I didn't have a lot of time to refactor. These codes can be improved further. Happy code reviews :)

    public partial class Main : Form
    {
        private readonly AccessLogService _accessLogService;
        private readonly IEmailSender _emailSender;
        private readonly INLogLogger _nLogLogger;

        AccessLog accessLogs;
        readonly EmailConfig mail = EmailConfigProvider.GetEmailConfig();

        public Main()
        {
            InitializeComponent();
            _nLogLogger = new NLogLogger("MainLogger");
            _accessLogService = new AccessLogService(new SocketService());
            _emailSender = new EmailSender(mail.SmtpServer, mail.SmtpPort, mail.SmtpUsername, mail.SmtpPassword);
        }

        private void BtnGetUser_Click(object sender, EventArgs e)
        {
            try
            {
                accessLogs = _accessLogService.GetAccess();
                UpdateDataGridView();

                if (accessLogs.VerifyStatusCode > 0)
                {
                    _ = ProcessResult(accessLogs);
                }
            }

            catch (Exception)
            {
                _nLogLogger.Info(Constant.ApiQuotaExceeded);
                MessageBox.Show(Constant.ApiQuotaExceeded, Constant.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ProcessResult(AccessLog accessLog)
        {
            string message = LogMessageBuilder.BuildLogMessage(accessLog);

            DialogResult dialogResult = await ShowPopupWithTimeoutAsync(message,
                                Constant.Approval,
                                Constant.Approve,
                                Constant.Cancel,
                                MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                var isSuccess = await AccessLogService.PostAccess(accessLog);
                var result = isSuccess ? Constant.TransactionConfirmed : Constant.TransactionConfirmedButApiNotSend;
                MessageBox.Show(result, Constant.Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                _nLogLogger.Info(result);
            }

            else
            {
                if (PostAccessLogAndSendEmail())
                {
                    _nLogLogger.Info(Constant.EmailSend);

                    MessageBox.Show(Constant.EmailSend, Constant.Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    _nLogLogger.Error(Constant.EmailError);

                    MessageBox.Show(Constant.EmailError, Constant.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private async Task<DialogResult> ShowPopupWithTimeoutAsync(string message, string caption, string approveButton, string cancelButton, MessageBoxIcon icon)
        {
            Task<DialogResult> popupTask = Task.Run(() => MyPopup.Show(message, caption, icon, approveButton, cancelButton));
            Task timeoutTask = Task.Delay(5000);

            await Task.WhenAny(popupTask, timeoutTask);

            if (popupTask.IsCompleted)
            {

                return await popupTask;

            }
            else
            {
                return DialogResult.None;

            }
        }
        private void UpdateDataGridView()
        {
            gridUserCredential.Rows.Clear();
            var gridList = _accessLogService.GetAccessLogs();
            foreach (var accessLog in gridList)
            {
                gridUserCredential.Rows.Add(
                   accessLog.LogID,
                   accessLog.ComputerHash,
                   accessLog.IPAddress,
                   accessLog.UserID,
                   accessLog.Username,
                   accessLog.AccessLocation,
                   accessLog.AccessDirection,
                   accessLog.VerifyStatusCode,
                   accessLog.AdditionalInfo,
                   accessLog.LogTime
               );
            }
            _nLogLogger.Info(Constant.UpdateDataGridview);
        }

        private bool PostAccessLogAndSendEmail()
        {
            string emailBody = $"Smtp Server: {mail.SmtpServer}\n" +
                                       $"Smtp Port: {mail.SmtpPort}\n" +
                                       $"Smtp Username: {mail.SmtpUsername}\n" +
                                       $"Smtp Password: {mail.SmtpPassword}";
            string emailTo = "mailAdress@gmail.com";
            string emailSubject = "Access Log Confirmation";
            bool emailSentResult = _emailSender.SendEmail(emailTo, emailSubject, emailBody);

            return emailSentResult;
        }

        #region Border Color
        private void gridUserCredential_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.LawnGreen, ButtonBorderStyle.Solid);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.LawnGreen, ButtonBorderStyle.Solid);
        }

        #endregion
        private void pBoxLog_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Constant.locationLogPath);
                Process.GetCurrentProcess().Kill();
                _nLogLogger.Info(Constant.UpdateDataGridview);
            }

            catch (Exception)
            {
                _nLogLogger.Error(Constant.logPathError);
                MessageBox.Show(Constant.logPathError, Constant.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
