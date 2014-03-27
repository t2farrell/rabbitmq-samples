using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldSend
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq.localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello", false, false, false, null);

                    string message = "Hello World!";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish("", "hello", null, body);
                    Console.WriteLine(" [x] Sent {0}", message);
                }
            }
        }
    }
}
