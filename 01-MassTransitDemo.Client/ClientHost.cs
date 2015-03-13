using MassTransit;
using MassTransitDemo.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MassTransitDemo.Client
{
    class ClientHost
    {
        private IServiceBus bus;

        public void Start()
        {
            bus = MassTransit.ServiceBusFactory.New(sb =>
            {
                sb.UseRabbitMq();
                sb.ReceiveFrom("rabbitmq://localhost/mtdemo.client");
            });

            Console.Write("Write a message: ");
            string message;
            int i = 0;
            while ((message = Console.ReadLine()) != null)
            {
                var messageToSend = new Message { Id = Guid.NewGuid(), Text = message, Index = ++i };

                bus.Publish(messageToSend);

                Console.WriteLine("Mensaje {0} - {1} enviado.", messageToSend.Index, messageToSend.Id);
                Console.Write("Write a message: ");
                
            }
        }

        public void Stop()
        {
            if (bus != null) bus.Dispose();
        }
    }
}
