using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmitLog
{
    class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq.localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare("logs", "fanout");

                var message = GetMessage(args);
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish("logs", "", null, body);
                Console.WriteLine(" [x] Sent {0}", message);
            }
        }

        private static string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "info: Hello World!");
        }
    }
}
