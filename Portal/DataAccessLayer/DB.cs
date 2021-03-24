using Microsoft.Extensions.Configuration;
using NLog;
using System.Net.Http;

namespace DataAccessLayer
{
    public class DB
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static string _connectionString;
        private static System.Net.Http.HttpClientHandler httpClientHandler = new System.Net.Http.HttpClientHandler();
        private static HttpClient client = new HttpClient(httpClientHandler);

        public static string connectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    SetConnectionString();
                }
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

        private static void SetConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(System.IO.Directory.GetCurrentDirectory()) // Directory where the json files are located
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            _connectionString = configuration.GetConnectionString("ESSConnection");
        }
    }
}
