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
            serviceInstaller.ServiceName = "FileWatcherService";
            serviceInstaller.DisplayName = "Cloud Sync";
            serviceInstaller.Description = "Watches a folder and uploads files to Azure.";
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            // Add installers to the collection
            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
