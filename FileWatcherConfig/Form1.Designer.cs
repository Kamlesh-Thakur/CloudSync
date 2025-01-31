namespace FileWatcherConfig
{
    partial class Form1
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
            txtFolderPath = new TextBox();
            folderToWatchLabel = new Label();
            btnBrowse = new Button();
            label1 = new Label();
            txtConnectionString = new TextBox();
            label2 = new Label();
            txtContainerName = new TextBox();
            txtLogFilePath = new TextBox();
            label3 = new Label();
            btnLocationBrowse = new Button();
            label4 = new Label();
            txtServicePath = new TextBox();
            btnSaveConfig = new Button();
            InstallServeButton = new Button();
            StartServiceButton = new Button();
            StopServiceButton = new Button();
            UninstallServiceButton = new Button();
            SuspendLayout();
            // 
            // txtFolderPath
            // 
            txtFolderPath.Location = new Point(204, 66);
            txtFolderPath.Name = "txtFolderPath";
            txtFolderPath.Size = new Size(569, 26);
            txtFolderPath.TabIndex = 0;
            // 
            // folderToWatchLabel
            // 
            folderToWatchLabel.AutoSize = true;
            folderToWatchLabel.Font = new Font("Aptos", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            folderToWatchLabel.Location = new Point(78, 70);
            folderToWatchLabel.Name = "folderToWatchLabel";
            folderToWatchLabel.Size = new Size(120, 19);
            folderToWatchLabel.TabIndex = 1;
            folderToWatchLabel.Text = "Folder to Watch:";
            // 
            // btnBrowse
            // 
            btnBrowse.Font = new Font("Aptos", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBrowse.Location = new Point(781, 65);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(106, 28);
            btnBrowse.TabIndex = 2;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 108);
            label1.Name = "label1";
            label1.Size = new Size(183, 19);
            label1.TabIndex = 3;
            label1.Text = "Azure Connection String: ";
            // 
            // txtConnectionString
            // 
            txtConnectionString.Location = new Point(204, 105);
            txtConnectionString.Name = "txtConnectionString";
            txtConnectionString.PasswordChar = '*';
            txtConnectionString.Size = new Size(569, 26);
            txtConnectionString.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(73, 149);
            label2.Name = "label2";
            label2.Size = new Size(125, 19);
            label2.TabIndex = 7;
            label2.Text = "Container Name:";
            // 
            // txtContainerName
            // 
            txtContainerName.Location = new Point(204, 146);
            txtContainerName.Name = "txtContainerName";
            txtContainerName.Size = new Size(290, 26);
            txtContainerName.TabIndex = 8;
            // 
            // txtLogFilePath
            // 
            txtLogFilePath.Location = new Point(204, 187);
            txtLogFilePath.Name = "txtLogFilePath";
            txtLogFilePath.Size = new Size(569, 26);
            txtLogFilePath.TabIndex = 10;
            txtLogFilePath.Click += txtLogFilePath_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(99, 190);
            label3.Name = "label3";
            label3.Size = new Size(99, 19);
            label3.TabIndex = 9;
            label3.Text = "Log File Path:";
            // 
            // btnLocationBrowse
            // 
            btnLocationBrowse.Font = new Font("Aptos", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLocationBrowse.Location = new Point(781, 230);
            btnLocationBrowse.Name = "btnLocationBrowse";
            btnLocationBrowse.Size = new Size(106, 28);
            btnLocationBrowse.TabIndex = 15;
            btnLocationBrowse.Text = "Browse";
            btnLocationBrowse.UseVisualStyleBackColor = true;
            btnLocationBrowse.Click += btnLocationBrowse_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Aptos", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(34, 235);
            label4.Name = "label4";
            label4.Size = new Size(164, 19);
            label4.TabIndex = 14;
            label4.Text = "Location of the Service";
            // 
            // txtServicePath
            // 
            txtServicePath.Location = new Point(204, 231);
            txtServicePath.Name = "txtServicePath";
            txtServicePath.Size = new Size(569, 26);
            txtServicePath.TabIndex = 13;
            // 
            // btnSaveConfig
            // 
            btnSaveConfig.BackColor = Color.LightGreen;
            btnSaveConfig.ForeColor = Color.DarkGreen;
            btnSaveConfig.Location = new Point(643, 339);
            btnSaveConfig.Name = "btnSaveConfig";
            btnSaveConfig.Size = new Size(130, 39);
            btnSaveConfig.TabIndex = 16;
            btnSaveConfig.Text = "Save Config";
            btnSaveConfig.UseVisualStyleBackColor = false;
            btnSaveConfig.Click += btnSaveConfig_Click;
            // 
            // InstallServeButton
            // 
            InstallServeButton.BackColor = Color.LightGreen;
            InstallServeButton.ForeColor = Color.DarkGreen;
            InstallServeButton.Location = new Point(507, 339);
            InstallServeButton.Name = "InstallServeButton";
            InstallServeButton.Size = new Size(130, 39);
            InstallServeButton.TabIndex = 17;
            InstallServeButton.Text = "Install";
            InstallServeButton.UseVisualStyleBackColor = false;
            InstallServeButton.Click += InstallServeButton_Click;
            // 
            // StartServiceButton
            // 
            StartServiceButton.BackColor = Color.LightGreen;
            StartServiceButton.ForeColor = Color.DarkGreen;
            StartServiceButton.Location = new Point(371, 339);
            StartServiceButton.Name = "StartServiceButton";
            StartServiceButton.Size = new Size(130, 39);
            StartServiceButton.TabIndex = 18;
            StartServiceButton.Text = "Start";
            StartServiceButton.UseVisualStyleBackColor = false;
            StartServiceButton.Click += StartServiceButton_Click;
            // 
            // StopServiceButton
            // 
            StopServiceButton.BackColor = Color.LightCoral;
            StopServiceButton.ForeColor = Color.DarkRed;
            StopServiceButton.Location = new Point(235, 339);
            StopServiceButton.Name = "StopServiceButton";
            StopServiceButton.Size = new Size(130, 39);
            StopServiceButton.TabIndex = 19;
            StopServiceButton.Text = "Stop";
            StopServiceButton.UseVisualStyleBackColor = false;
            StopServiceButton.Click += StopServiceButton_Click;
            // 
            // UninstallServiceButton
            // 
            UninstallServiceButton.BackColor = Color.LightCoral;
            UninstallServiceButton.ForeColor = Color.DarkRed;
            UninstallServiceButton.Location = new Point(99, 339);
            UninstallServiceButton.Name = "UninstallServiceButton";
            UninstallServiceButton.Size = new Size(130, 39);
            UninstallServiceButton.TabIndex = 20;
            UninstallServiceButton.Text = "Uninstall";
            UninstallServiceButton.UseVisualStyleBackColor = false;
            UninstallServiceButton.Click += UninstallServiceButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 407);
            Controls.Add(UninstallServiceButton);
            Controls.Add(StopServiceButton);
            Controls.Add(StartServiceButton);
            Controls.Add(InstallServeButton);
            Controls.Add(btnSaveConfig);
            Controls.Add(btnLocationBrowse);
            Controls.Add(label4);
            Controls.Add(txtServicePath);
            Controls.Add(txtLogFilePath);
            Controls.Add(label3);
            Controls.Add(txtContainerName);
            Controls.Add(label2);
            Controls.Add(txtConnectionString);
            Controls.Add(label1);
            Controls.Add(btnBrowse);
            Controls.Add(folderToWatchLabel);
            Controls.Add(txtFolderPath);
            Font = new Font("Aptos", 9F, FontStyle.Bold);
            Name = "Form1";
            Text = "File Watcher Config App";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFolderPath;
        private Label folderToWatchLabel;
        private Button btnBrowse;
        private Label label1;
        private TextBox txtConnectionString;
        private Label label2;
        private TextBox txtContainerName;
        private TextBox txtLogFilePath;
        private Label label3;
        private Button btnLocationBrowse;
        private Label label4;
        private TextBox txtServicePath;
        private Button btnSaveConfig;
        private Button InstallServeButton;
        private Button StartServiceButton;
        private Button StopServiceButton;
        private Button UninstallServiceButton;
    }
}
