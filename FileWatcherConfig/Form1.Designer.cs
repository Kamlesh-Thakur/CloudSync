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
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            txtFolderPath = new TextBox();
            folderToWatchLabel = new Label();
            btnBrowse = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 43);
            label1.Name = "label1";
            label1.Size = new Size(190, 19);
            label1.TabIndex = 3;
            label1.Text = "Storage Connection String";
            // 
            // txtConnectionString
            // 
            txtConnectionString.Location = new Point(207, 40);
            txtConnectionString.Name = "txtConnectionString";
            txtConnectionString.PasswordChar = '*';
            txtConnectionString.Size = new Size(542, 26);
            txtConnectionString.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(80, 75);
            label2.Name = "label2";
            label2.Size = new Size(121, 19);
            label2.TabIndex = 7;
            label2.Text = "Container Name";
            // 
            // txtContainerName
            // 
            txtContainerName.Location = new Point(207, 72);
            txtContainerName.Name = "txtContainerName";
            txtContainerName.Size = new Size(290, 26);
            txtContainerName.TabIndex = 8;
            // 
            // txtLogFilePath
            // 
            txtLogFilePath.Location = new Point(207, 72);
            txtLogFilePath.Name = "txtLogFilePath";
            txtLogFilePath.Size = new Size(424, 26);
            txtLogFilePath.TabIndex = 10;
            txtLogFilePath.Click += txtLogFilePath_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(106, 75);
            label3.Name = "label3";
            label3.Size = new Size(95, 19);
            label3.TabIndex = 9;
            label3.Text = "Log File Path";
            // 
            // btnLocationBrowse
            // 
            btnLocationBrowse.Font = new Font("Aptos", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLocationBrowse.Location = new Point(637, 104);
            btnLocationBrowse.Name = "btnLocationBrowse";
            btnLocationBrowse.Size = new Size(112, 28);
            btnLocationBrowse.TabIndex = 15;
            btnLocationBrowse.Text = "Browse";
            btnLocationBrowse.UseVisualStyleBackColor = true;
            btnLocationBrowse.Click += btnLocationBrowse_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Aptos", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(37, 108);
            label4.Name = "label4";
            label4.Size = new Size(164, 19);
            label4.TabIndex = 14;
            label4.Text = "Location of the Service";
            // 
            // txtServicePath
            // 
            txtServicePath.Location = new Point(207, 104);
            txtServicePath.Name = "txtServicePath";
            txtServicePath.Size = new Size(424, 26);
            txtServicePath.TabIndex = 13;
            // 
            // btnSaveConfig
            // 
            btnSaveConfig.BackColor = Color.LightGreen;
            btnSaveConfig.ForeColor = Color.DarkGreen;
            btnSaveConfig.Location = new Point(704, 358);
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
            InstallServeButton.Location = new Point(704, 403);
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
            StartServiceButton.Location = new Point(704, 448);
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
            StopServiceButton.Location = new Point(568, 448);
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
            UninstallServiceButton.Location = new Point(568, 403);
            UninstallServiceButton.Name = "UninstallServiceButton";
            UninstallServiceButton.Size = new Size(130, 39);
            UninstallServiceButton.TabIndex = 20;
            UninstallServiceButton.Text = "Uninstall";
            UninstallServiceButton.UseVisualStyleBackColor = false;
            UninstallServiceButton.Click += UninstallServiceButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtConnectionString);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtContainerName);
            groupBox1.Location = new Point(67, 32);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(772, 123);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "Azure Configuration";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtFolderPath);
            groupBox2.Controls.Add(folderToWatchLabel);
            groupBox2.Controls.Add(btnBrowse);
            groupBox2.Controls.Add(txtLogFilePath);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(txtServicePath);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(btnLocationBrowse);
            groupBox2.Location = new Point(67, 172);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(772, 158);
            groupBox2.TabIndex = 22;
            groupBox2.TabStop = false;
            groupBox2.Text = "File Watcher Service Configuration";
            // 
            // txtFolderPath
            // 
            txtFolderPath.Location = new Point(207, 40);
            txtFolderPath.Name = "txtFolderPath";
            txtFolderPath.Size = new Size(424, 26);
            txtFolderPath.TabIndex = 7;
            // 
            // folderToWatchLabel
            // 
            folderToWatchLabel.AutoSize = true;
            folderToWatchLabel.Font = new Font("Aptos", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            folderToWatchLabel.Location = new Point(85, 43);
            folderToWatchLabel.Name = "folderToWatchLabel";
            folderToWatchLabel.Size = new Size(116, 19);
            folderToWatchLabel.TabIndex = 8;
            folderToWatchLabel.Text = "Folder to Watch";
            // 
            // btnBrowse
            // 
            btnBrowse.Font = new Font("Aptos", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBrowse.Location = new Point(637, 38);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(112, 28);
            btnBrowse.TabIndex = 9;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 523);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(UninstallServiceButton);
            Controls.Add(StopServiceButton);
            Controls.Add(StartServiceButton);
            Controls.Add(InstallServeButton);
            Controls.Add(btnSaveConfig);
            Font = new Font("Aptos", 9F, FontStyle.Bold);
            Name = "Form1";
            Text = "File Watcher Config App";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
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
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox txtFolderPath;
        private Label folderToWatchLabel;
        private Button btnBrowse;
    }
}
