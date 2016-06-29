using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Serilog;
using static System.Console;

namespace SerilogSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var storage = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

            var log = new LoggerConfiguration()
                .WriteTo.AzureTableStorage(storage)
                .MinimumLevel.Debug()
                .CreateLogger();

            log.Debug("hello world");
            log.Error("Oh no, an error");
            log.Information("another message, just for info");

            ReadKey();
        }
    }
}
