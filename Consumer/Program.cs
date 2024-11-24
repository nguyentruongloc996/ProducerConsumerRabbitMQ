// See https://aka.ms/new-console-template for more information

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory() { HostName = "localhost" };
using (var connection = await factory.CreateConnectionAsync())
{
    using (var channel = await connection.CreateChannelAsync())
    {
        await channel.QueueDeclareAsync("BasicTest", false, false, false, null);
        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.ReceivedAsync += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine(message);
            return Task.CompletedTask;
        };

        await channel.BasicConsumeAsync("BasicTest", true, consumer);
        Console.WriteLine("Press [enter] to exit the Sender App...");
        Console.ReadLine();
    }
}