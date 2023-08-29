namespace OnesTechSecureAccessGuard
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            btnGetUser = new Button();
            gridUserCredential = new DataGridView();
            colLogID = new DataGridViewTextBoxColumn();
            colComputerHash = new DataGridViewTextBoxColumn();
            colIPAddress = new DataGridViewTextBoxColumn();
            colUserID = new DataGridViewTextBoxColumn();
            colUsername = new DataGridViewTextBoxColumn();
            colAccessLocation = new DataGridViewTextBoxColumn();
            colAccessDirection = new DataGridViewTextBoxColumn();
            colVerifyStatusCode = new DataGridViewTextBoxColumn();
            colAdditionalInfo = new DataGridViewTextBoxColumn();
            colLogTime = new DataGridViewTextBoxColumn();
            pBoxLog = new PictureBox();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)gridUserCredential).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pBoxLog).BeginInit();
            SuspendLayout();
            // 
            // btnGetUser
            // 
            btnGetUser.BackColor = Color.Chartreuse;
            btnGetUser.Cursor = Cursors.Hand;
            btnGetUser.Location = new Point(12, 21);
            btnGetUser.Margin = new Padding(3, 2, 3, 2);
            btnGetUser.Name = "btnGetUser";
            btnGetUser.Size = new Size(116, 27);
            btnGetUser.TabIndex = 0;
            btnGetUser.Text = "GetAccessLog";
            toolTip1.SetToolTip(btnGetUser, "Verileri Çekmek İçin Tıklayınız..");
            btnGetUser.UseVisualStyleBackColor = false;
            btnGetUser.Click += BtnGetUser_Click;
            // 
            // gridUserCredential
            // 
            gridUserCredential.AllowUserToAddRows = false;
            gridUserCredential.AllowUserToDeleteRows = false;
            gridUserCredential.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridUserCredential.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridUserCredential.BackgroundColor = SystemColors.GradientInactiveCaption;
            gridUserCredential.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridUserCredential.Columns.AddRange(new DataGridViewColumn[] { colLogID, colComputerHash, colIPAddress, colUserID, colUsername, colAccessLocation, colAccessDirection, colVerifyStatusCode, colAdditionalInfo, colLogTime });
            gridUserCredential.Location = new Point(-2, 147);
            gridUserCredential.Margin = new Padding(3, 2, 3, 2);
            gridUserCredential.Name = "gridUserCredential";
            gridUserCredential.ReadOnly = true;
            gridUserCredential.RowHeadersWidth = 51;
            gridUserCredential.RowTemplate.Height = 29;
            gridUserCredential.Size = new Size(1284, 398);
            gridUserCredential.TabIndex = 1;
            gridUserCredential.Paint += gridUserCredential_Paint;
            // 
            // colLogID
            // 
            colLogID.HeaderText = "LogID";
            colLogID.MinimumWidth = 6;
            colLogID.Name = "colLogID";
            colLogID.ReadOnly = true;
            // 
            // colComputerHash
            // 
            colComputerHash.HeaderText = "ComputerHash";
            colComputerHash.MinimumWidth = 6;
            colComputerHash.Name = "colComputerHash";
            colComputerHash.ReadOnly = true;
            // 
            // colIPAddress
            // 
            colIPAddress.HeaderText = "IPAddress";
            colIPAddress.MinimumWidth = 6;
            colIPAddress.Name = "colIPAddress";
            colIPAddress.ReadOnly = true;
            // 
            // colUserID
            // 
            colUserID.HeaderText = "UserID";
            colUserID.MinimumWidth = 6;
            colUserID.Name = "colUserID";
            colUserID.ReadOnly = true;
            // 
            // colUsername
            // 
            colUsername.HeaderText = "Username";
            colUsername.MinimumWidth = 6;
            colUsername.Name = "colUsername";
            colUsername.ReadOnly = true;
            // 
            // colAccessLocation
            // 
            colAccessLocation.HeaderText = "AccessLocation";
            colAccessLocation.MinimumWidth = 6;
            colAccessLocation.Name = "colAccessLocation";
            colAccessLocation.ReadOnly = true;
            // 
            // colAccessDirection
            // 
            colAccessDirection.HeaderText = "AccessDirection";
            colAccessDirection.MinimumWidth = 6;
            colAccessDirection.Name = "colAccessDirection";
            colAccessDirection.ReadOnly = true;
            // 
            // colVerifyStatusCode
            // 
            colVerifyStatusCode.HeaderText = "VerifyStatusCode";
            colVerifyStatusCode.MinimumWidth = 6;
            colVerifyStatusCode.Name = "colVerifyStatusCode";
            colVerifyStatusCode.ReadOnly = true;
            // 
            // colAdditionalInfo
            // 
            colAdditionalInfo.HeaderText = "AdditionalInfo";
            colAdditionalInfo.MinimumWidth = 6;
            colAdditionalInfo.Name = "colAdditionalInfo";
            colAdditionalInfo.ReadOnly = true;
            // 
            // colLogTime
            // 
            colLogTime.HeaderText = "LogTime";
            colLogTime.MinimumWidth = 6;
            colLogTime.Name = "colLogTime";
            colLogTime.ReadOnly = true;
            // 
            // pBoxLog
            // 
            pBoxLog.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pBoxLog.Cursor = Cursors.Hand;
            pBoxLog.Image = (Image)resources.GetObject("pBoxLog.Image");
            pBoxLog.Location = new Point(1228, 11);
            pBoxLog.Name = "pBoxLog";
            pBoxLog.Size = new Size(42, 37);
            pBoxLog.SizeMode = PictureBoxSizeMode.StretchImage;
            pBoxLog.TabIndex = 2;
            pBoxLog.TabStop = false;
            toolTip1.SetToolTip(pBoxLog, "Log Dosyalarını Açmak İçin Tıklayınız");
            pBoxLog.Click += pBoxLog_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1282, 541);
            Controls.Add(pBoxLog);
            Controls.Add(btnGetUser);
            Controls.Add(gridUserCredential);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ones Technology";
            Paint += Form1_Paint;
            ((System.ComponentModel.ISupportInitialize)gridUserCredential).EndInit();
            ((System.ComponentModel.ISupportInitialize)pBoxLog).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnGetUser;
        private DataGridView gridUserCredential;
        private DataGridViewTextBoxColumn colLogID;
        private DataGridViewTextBoxColumn colComputerHash;
        private DataGridViewTextBoxColumn colIPAddress;
        private DataGridViewTextBoxColumn colUserID;
        private DataGridViewTextBoxColumn colUsername;
        private DataGridViewTextBoxColumn colAccessLocation;
        private DataGridViewTextBoxColumn colAccessDirection;
        private DataGridViewTextBoxColumn colVerifyStatusCode;
        private DataGridViewTextBoxColumn colAdditionalInfo;
        private DataGridViewTextBoxColumn colLogTime;
        private PictureBox pBoxLog;
        private ToolTip toolTip1;
    }
}