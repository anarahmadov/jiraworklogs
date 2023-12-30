using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class Constants
    {
        public static Uri ZipkinEndpoint
        {
            get
            {
                //var zipkinHostName = Environment.GetEnvironmentVariable("ZIPKIN_HOSTNAME") ?? "localhost";
                var zipkinHostName = "zipkin";
                return new Uri($"http://{zipkinHostName}:9411/api/v2/spans");
            }
        }

        public static string RabbitMqHost { get => "rabbitmq"; }
        public static string RabbitMqUser { get => "guest"; }
        public static string RabbitMqPassword { get => "guest"; }

        public static string DatabaseConnectionString
        {
            get
            {
                return "Server=postgresql;UserId=postgres;Password=password;Database=jiraworklogs;";
            }
        }

        public static string RedisConnectionString
        {
            get
            {
                return "redis:6379,abortConnect=false";
            }
        }
    }
}
