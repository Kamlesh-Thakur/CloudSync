namespace FileWatcherConfig;

using System.Configuration;
using System.Diagnostics;
using System.ServiceProcess;
using System.Windows.Forms;

public partial class Form1 : Form
{
    private string serviceDirectory;
    private string serviceExePath;

    public Form1()
    {
        InitializeComponent();

        // Automatically locate the service directory
        var appDirectory = AppDomain.CurrentDomain.BaseDirectory;
        serviceDirectory = Path.Combine(appDirectory, "ServiceBin");
        serviceExePath = Path.Combine(serviceDirectory, "FileWatcherService.exe");

        if (!Directory.Exists(serviceDirectory) || !File.Exists(serviceExePath))
        {
            MessageBox.Show($"Service files not found at: {serviceDirectory}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        txtLogFilePath.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FileWatcherLog.txt");

        var config = ConfigurationManager.OpenExeConfiguration(serviceExePath);

        txtFolderPath.Text = config.AppSettings.Settings["FolderPath"].Value;
        txtConnectionString.Text = config.AppSettings.Settings["ConnectionString"].Value;
        txtContainerName.Text = config.AppSettings.Settings["ContainerName"].Value;
        txtLogFilePath.Text = config.AppSettings.Settings["LogFilePath"].Value;
        txtServicePath.Text = serviceExePath;

        ServiceDisplayNameTextBox.Text =
            string.IsNullOrEmpty(config.AppSettings.Settings["ServiceDisplayName"].Value)
                ? "Cloud Sync"
                : config.AppSettings.Settings["ServiceDisplayName"].Value;

        ServiceDescriptionTextBox.Text =
            string.IsNullOrEmpty(config.AppSettings.Settings["ServiceDescription"].Value)
                ? "This service monitors a folder and uploads files to Azure Blob Storage."
                : config.AppSettings.Settings["ServiceDescription"].Value;
    }

    private void btnBrowse_Click(object sender, EventArgs e)
    {
        using var folderBrowserDialog = new FolderBrowserDialog();
        var result = folderBrowserDialog.ShowDialog();
        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
        {
            txtFolderPath.Text = folderBrowserDialog.SelectedPath;
        }
    }

    private void txtLogFilePath_Click(object sender, EventArgs e)
    {
        using var saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
        saveFileDialog.Title = "Choose Log File Location";
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            txtLogFilePath.Text = saveFileDialog.FileName;
        }
    }

    private void btnLocationBrowse_Click(object sender, EventArgs e)
    {
        var openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Executable Files (*.exe)|*.exe";
        openFileDialog.Title = "Select the Service Executable";

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            txtServicePath.Text = openFileDialog.FileName;
        }
    }

    private void btnSaveConfig_Click(object sender, EventArgs e)
    {
        var folderPath = txtFolderPath.Text;
        var connectionString = txtConnectionString.Text;
        var containerName = txtContainerName.Text;
        var logFilePath = txtLogFilePath.Text;

        if (string.IsNullOrWhiteSpace(folderPath) || string.IsNullOrWhiteSpace(connectionString))
        {
            MessageBox.Show(
                "Please select a folder and enter a connection string.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        if (string.IsNullOrEmpty(containerName))
        {
            MessageBox.Show(
                "Please enter the container name.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        // Default log file path if not specified
        if (string.IsNullOrEmpty(logFilePath))
        {
            logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FileWatcherLog.txt"); // Default to exe directory
        }

        // Save Configuration
        var config = ConfigurationManager.OpenExeConfiguration(txtServicePath.Text);

        config.AppSettings.Settings["FolderPath"].Value = folderPath;
        config.AppSettings.Settings["ConnectionString"].Value = connectionString;
        config.AppSettings.Settings["ContainerName"].Value = containerName;
        config.AppSettings.Settings["LogFilePath"].Value = logFilePath;
        config.AppSettings.Settings["ServicePath"].Value = serviceExePath;
        config.AppSettings.Settings["ServiceDisplayName"].Value = ServiceDisplayNameTextBox.Text;
        config.AppSettings.Settings["ServiceDescription"].Value = ServiceDescriptionTextBox.Text;

        config.Save(ConfigurationSaveMode.Modified);
        ConfigurationManager.RefreshSection("appSettings");

        MessageBox.Show(
            "Configuration saved successfully.",
            "Success",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void InstallServeButton_Click(object sender, EventArgs e)
    {
        try
        {
            var serviceExePath = txtServicePath.Text;
            var serviceName = "FileWatcherService";
            var serviceDisplayName = ServiceDisplayNameTextBox.Text;

            if (ServiceExists(serviceName))
            {
                MessageBox.Show("The service already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var process = new Process();
            process.StartInfo.FileName = "sc.exe";
            process.StartInfo.Arguments = $"create {serviceName} binPath= \"{serviceExePath}\" start= auto DisplayName= \"{serviceDisplayName}\"";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            MessageBox.Show(process.ExitCode == 0
                ? "Service installed successfully."
                : $"Service installation failed. Output: {output}", "Success", MessageBoxButtons.OK);

            var serviceDescription = ServiceDescriptionTextBox.Text;
            var descriptionProcess = new Process();
            descriptionProcess.StartInfo.FileName = "sc.exe";
            descriptionProcess.StartInfo.Arguments = $"description {serviceName} \"{serviceDescription}\"";
            descriptionProcess.StartInfo.UseShellExecute = false;
            descriptionProcess.StartInfo.RedirectStandardOutput = true;
            descriptionProcess.StartInfo.CreateNoWindow = true;
            descriptionProcess.Start();

            descriptionProcess.StandardOutput.ReadToEnd();
            descriptionProcess.WaitForExit();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error installing service: {ex.Message}");
        }
    }

    private void StartServiceButton_Click(object sender, EventArgs e)
    {
        try
        {
            var serviceName = "FileWatcherService";

            if (!ServiceExists(serviceName))
            {
                MessageBox.Show("The service does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using var sc = new ServiceController(serviceName);
            if (sc.Status == ServiceControllerStatus.Running)
            {
                MessageBox.Show("The service is already running.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            sc.Start();
            sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(30));
            MessageBox.Show("Service started successfully.");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error starting service: {ex.Message}");
        }
    }

    private void StopServiceButton_Click(object sender, EventArgs e)
    {
        try
        {
            var serviceName = "FileWatcherService";

            if (!ServiceExists(serviceName))
            {
                MessageBox.Show("The service does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using var sc = new ServiceController(serviceName);
            if (sc.Status == ServiceControllerStatus.Stopped)
            {
                MessageBox.Show("The service is already stopped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            sc.Stop();
            sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(30));
            MessageBox.Show("Service stopped successfully.");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error stopping service: {ex.Message}");
        }
    }

    private void UninstallServiceButton_Click(object sender, EventArgs e)
    {
        try
        {
            var serviceName = "FileWatcherService";

            if (!ServiceExists(serviceName))
            {
                MessageBox.Show("The service does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Stop the service if it is running
            using (var sc = new ServiceController(serviceName))
            {
                if (sc.Status == ServiceControllerStatus.Running)
                {
                    sc.Stop();
                    sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(30));
                }
            }

            var process = new Process();
            process.StartInfo.FileName = "sc.exe";
            process.StartInfo.Arguments = $"delete {serviceName}";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            MessageBox.Show(process.ExitCode == 0
                ? "Service uninstalled successfully."
                : $"Service uninstallation failed. Output: {output}");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error uninstalling service: {ex.Message}");
        }
    }

    private bool ServiceExists(string serviceName)
    {
        try
        {
            using var sc = new ServiceController(serviceName);
            var status = sc.Status;
            return true;
        }
        catch (InvalidOperationException)
        {
            return false;
        }
    }
}
