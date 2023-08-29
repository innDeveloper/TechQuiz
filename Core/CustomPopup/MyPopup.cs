using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace OnesTechSecureAccessGuard.Core.CustomPopup
{
    public static class MyPopup
    {
        private static Form? customMessageBox;

        public static DialogResult Show(string message, string caption, MessageBoxIcon icon, string button1Text, string button2Text = "Ok")
        {
            bool isOKIcon = icon == MessageBoxIcon.Error;

            customMessageBox = new Form
            {
                Width = isOKIcon ? 300 : 600,
                Height = isOKIcon ? 200 : 500,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false,
                TopMost = true
            };

            PictureBox iconPictureBox = new()
            {
                Image = GetIconImage(icon),
                Size = new Size(40, 40),
                Location = new Point(20, 20)
            };

            Label label = new()
            {
                Text = message,
                Location = new Point(80, 20),
                AutoSize = true,
                MaximumSize = new Size(isOKIcon ? 240 : 500, 0), // Adjust maximum width based on the icon
                Font = new Font(FontFamily.GenericSansSerif, isOKIcon ? 10 : 12), // Adjust font size based on the icon
            };
            if(isOKIcon)
            label.Location = new Point(60, 20); // Move the label a bit more to the left

            customMessageBox.Controls.Add(iconPictureBox);
            customMessageBox.Controls.Add(label);

            if (icon == MessageBoxIcon.Error)
            {
                Button button3 = new()
                {
                    Text = button2Text,
                    DialogResult = DialogResult.No,
                    Size = new Size(100, 40),
                    Location = new Point((customMessageBox.Width - 100) / 2, isOKIcon ? 100 : 150) // Adjusted location based on the icon
                };
                customMessageBox.Controls.Add(button3);
                customMessageBox.AcceptButton = button3;

                button3.Click += (sender, args) =>
                {
                    customMessageBox.DialogResult = DialogResult.No;                 
                };

     
            }
            else
            {
                Button button1 = new()
                {
                    Text = button1Text,
                    DialogResult = DialogResult.Yes,
                    Size = new Size(100, 40),
                    Location = new Point((customMessageBox.Width - 240) / 2, 400)
                };
                button1.Click += (sender, args) =>
                {
                    customMessageBox.DialogResult = DialogResult.Yes;
                };

                Button button2 = new()
                {
                    Text = button2Text,
                    DialogResult = DialogResult.No,
                    Size = new Size(100, 40),
                    Location = new Point((customMessageBox.Width + 40) / 2, 400)
                };
                button2.Click += (sender, args) =>
                {
                    customMessageBox.DialogResult = DialogResult.No;
                };

                customMessageBox.Controls.Add(button1);
                customMessageBox.Controls.Add(button2);
                customMessageBox.AcceptButton = button1;
                customMessageBox.CancelButton = button2;
            }

            return customMessageBox.ShowDialog();
        }

        public static void Close()
        {
            if (customMessageBox != null)
            {
                customMessageBox.Close();
                customMessageBox.Dispose();
                customMessageBox = null;
            }
        }

        private static Bitmap GetIconImage(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Information:
                    return SystemIcons.Information.ToBitmap();
                case MessageBoxIcon.Warning:
                    return SystemIcons.Warning.ToBitmap();
                case MessageBoxIcon.Error:
                    return SystemIcons.Error.ToBitmap();
                default:
                    return SystemIcons.Asterisk.ToBitmap();
            }
        }
    }
}
