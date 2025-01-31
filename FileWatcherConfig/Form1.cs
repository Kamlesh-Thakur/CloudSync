namespace FileWatcherConfig;

using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        txtLogFilePath.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FileWatcherLog.txt");

        // Save Configuration
        var configLocal = ConfigurationManager.OpenExeConfiguration(txtServicePath.Text);

        var servicePath = configLocal.AppSettings.Settings["ServicePath"].Value;

        if (string.IsNullOrEmpty(servicePath)) return;

        var config = ConfigurationManager.OpenExeConfiguration(servicePath);


        txtFolderPath.Text = config.AppSettings.Settings["FolderPath"].Value;
        txtConnectionString.Text = config.AppSettings.Settings["ConnectionString"].Value;
        txtContainerName.Text = config.AppSettings.Settings["ContainerName"].Value;
        txtLogFilePath.Text = config.AppSettings.Settings["LogFilePath"].Value;
        txtServicePath.Text = config.AppSettings.Settings["ServicePath"].Value;
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
        OpenFileDialog openFileDialog = new OpenFileDialog();
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
        config.AppSettings.Settings["ServicePath"].Value = txtServicePath.Text;

        config.Save(ConfigurationSaveMode.Modified);
        ConfigurationManager.RefreshSection("appSettings");

        var configLocal = ConfigurationManager.OpenExeConfiguration("");
        configLocal.AppSettings.Settings["ServicePath"].Value = txtServicePath.Text;

        configLocal.Save(ConfigurationSaveMode.Modified);
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
            string serviceExePath = txtServicePath.Text;
            string serviceName = "Cloud Sync";

            Process process = new Process();
            process.StartInfo.FileName = "sc.exe";
            process.StartInfo.Arguments = $"create {serviceName} binPath= \"{serviceExePath}\" start= auto";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            if (process.ExitCode == 0)
            {
                MessageBox.Show("Service installed successfully.");
            }
            else
            {
                MessageBox.Show($"Service installation failed. Output: {output}");
            }
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
            string serviceName = "Cloud Sync";

            Process process = new Process();
            process.StartInfo.FileName = "sc.exe";
            process.StartInfo.Arguments = $"start {serviceName}";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            if (process.ExitCode == 0)
            {
                MessageBox.Show("Service started successfully.");
            }
            else
            {
                MessageBox.Show($"Service start failed. Output: {output}");
            }
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
            string serviceName = "Cloud Sync";

            Process process = new Process();
            process.StartInfo.FileName = "sc.exe";
            process.StartInfo.Arguments = $"stop {serviceName}";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            if (process.ExitCode == 0)
            {
                MessageBox.Show("Service stopped successfully.");
            }
            else
            {
                MessageBox.Show($"Service stop failed. Output: {output}");
            }
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
            string serviceName = "Cloud Sync";

            Process process = new Process();
            process.StartInfo.FileName = "sc.exe";
            process.StartInfo.Arguments = $"delete {serviceName}";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            if (process.ExitCode == 0)
            {
                MessageBox.Show("Service uninstalled successfully.");
            }
            else
            {
                MessageBox.Show($"Service uninstallation failed. Output: {output}");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error uninstalling service: {ex.Message}");
        }
    }
}
