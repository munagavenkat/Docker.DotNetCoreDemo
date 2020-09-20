using Microsoft.Extensions.Configuration;

namespace DNCD.Common.Base.AppSettings
{
    public class AppSettings : IAppSettings
    {
        public string DatabaseConnectionString { get; set; }
        public AzureStorage AzureStorage { get; set; }
        public AzureServiceBus AzureServiceBus { get; set; }
        public CustomerServiceAPI CustomerServiceAPI { get; set; }

        public AppSettings(IConfiguration configuration)
        {
            // Initiate object to bind appsetting.json values.
            AzureStorage = new AzureStorage();
            AzureServiceBus = new AzureServiceBus();
            CustomerServiceAPI = new CustomerServiceAPI();

            BuildConfiguration(configuration);
        }

        private void BuildConfiguration(IConfiguration configuration)
        {
            // Read app settings values from appsettings.json
            this.DatabaseConnectionString = configuration.GetValue<string>("DatabaseConnectionString");

            // bind appsetting.json values.
            configuration.Bind("AzureStorage", AzureStorage);
            configuration.Bind("AzureServiceBus", AzureServiceBus);
            configuration.Bind("CustomerServiceAPI", CustomerServiceAPI);
        }
    }
}
