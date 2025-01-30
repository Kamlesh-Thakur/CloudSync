using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace FileWatcherService
{
    [RunInstaller(true)]
    public partial class ServiceInstaller : Installer
    {
        private ServiceProcessInstaller processInstaller;
        private System.ServiceProcess.ServiceInstaller serviceInstaller;

        public ServiceInstaller()
        {
            // Instantiate installers
            processInstaller = new ServiceProcessInstaller();
            serviceInstaller = new System.ServiceProcess.ServiceInstaller();

            // Set the service process installer properties
            processInstaller.Account = ServiceAccount.LocalSystem;

            // Set the service installer properties
            serviceInstaller.ServiceName = "FileWatcherService2";
            serviceInstaller.DisplayName = "Cloud Sync v2";
            serviceInstaller.Description = "Watches a folder and uploads files to Azure.";

            // Add installers to the collection
            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
