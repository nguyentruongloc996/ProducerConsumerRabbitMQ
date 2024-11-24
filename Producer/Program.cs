// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory() { HostName = "localhost"};
using (var connection = await factory.CreateConnectionAsync())
{
    using (var channel = await connection.CreateChannelAsync())
    {
        await channel.QueueDeclareAsync("BasicTest",false, false, false, null);
        string message = "Getting started with .NEt core RabbitMQ";
        var body = Encoding.UTF8.GetBytes(message);

        await channel.BasicPublishAsync("", "BasicTest", body);
        Console.WriteLine(message);
    }

    Console.WriteLine("Press [enter] to exit the Sender App...");
    Console.ReadLine();
}