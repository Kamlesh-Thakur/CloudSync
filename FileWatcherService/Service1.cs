using System.ServiceProcess;

namespace FileWatcherService
{
    using Azure.Storage.Blobs;
    using System;
    using System.Configuration;
    using System.IO;
    using System.Threading;

    public partial class Service1 : ServiceBase
    {
        private FileSystemWatcher _watcher;
        private string _folderPath;
        private string _connectionString;
        private string _containerName;
        private string _logFilePath;
        private BlobContainerClient _containerClient;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // Load configuration from app.config
            _folderPath = ConfigurationManager.AppSettings["FolderPath"];
            _connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            _containerName = ConfigurationManager.AppSettings["ContainerName"]; // Get container name
            _logFilePath = ConfigurationManager.AppSettings["LogFilePath"]; // Get log file path

            if (string.IsNullOrEmpty(_folderPath)
                || string.IsNullOrEmpty(_connectionString)
                || string.IsNullOrEmpty(_containerName)
                || string.IsNullOrEmpty(_logFilePath))
            {
                LogError("Configuration is missing. Folder Path, Connection String, Container Name or Log File Path is empty.");
                Stop();
                return;
            }

            try
            {
                // Initialize Azure Blob Storage client
                var blobServiceClient = new BlobServiceClient(_connectionString);
                _containerClient = blobServiceClient.GetBlobContainerClient(_containerName);
                _containerClient.CreateIfNotExists();

                // Initialize FileSystemWatcher
                _watcher = new FileSystemWatcher(_folderPath)
                {
                    EnableRaisingEvents = true,
                    IncludeSubdirectories = true
                };

                _watcher.Created += OnFileCreated;
                LogInformation("FileWatcherService started.");
            }
            catch (Exception ex)
            {
                LogError($"Error initializing service: {ex.Message}");
                Stop();
            }
        }

        protected override void OnStop()
        {
            _watcher?.Dispose();
            LogInformation("FileWatcherService stopped.");
        }

        private void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            var filePath = e.FullPath;
            UploadFileToAzure(filePath);
        }

        private void UploadFileToAzure(string filePath)
        {
            var retryCount = 0;
            const int maxRetries = 3;

            while (retryCount <= maxRetries)
            {
                try
                {
                    var fileName = Path.GetFileName(filePath);
                    var blobClient = _containerClient.GetBlobClient(fileName);

                    using (var stream = File.OpenRead(filePath))
                    {
                        blobClient.Upload(stream, true);
                    }

                    LogInformation($"File {filePath} uploaded to Azure Blob Storage successfully.");
                    return;
                }
                catch (Exception ex)
                {
                    LogError($"Error uploading {filePath} to Azure Blob Storage (attempt {retryCount}: {ex.Message}");
                    retryCount++;

                    if (retryCount <= maxRetries)
                    {
                        var backoff = TimeSpan.FromSeconds(Math.Pow(2, retryCount - 1));
                        Thread.Sleep(backoff);
                    }
                }
            }

            LogError($"File '{Path.GetFileName(filePath)}' upload failed after {maxRetries} retries.");
        }

        private void LogInformation(string message)
        {
            try
            {
                using (var writer = File.AppendText(_logFilePath))
                {
                    writer.WriteLine($"[INFO] {DateTime.Now} - {message}");
                }
            }
            catch (Exception) { /* Ignore logging errors */}
        }

        private void LogError(string message)
        {
            try
            {
                using (var writer = File.AppendText(_logFilePath))
                {
                    writer.WriteLine($"[ERROR] {DateTime.Now} - {message}");
                }
            }
            catch (Exception) { /* Ignore logging errors */}
        }
    }
}
