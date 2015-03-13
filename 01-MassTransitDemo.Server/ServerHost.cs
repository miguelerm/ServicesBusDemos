using MassTransit;
using MassTransitDemo.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MassTransitDemo.Server
{
    class ServerHost
    {
        private IServiceBus bus;

        public void Start()
        {

            bus = MassTransit.ServiceBusFactory.New(sb => {

                sb.UseRabbitMq();
                sb.ReceiveFrom("rabbitmq://localhost/mtdemo.server");

                sb.Subscribe(x => x.Handler<Message>(message => {

                    Console.ForegroundColor = message.Index % 5 == 0 ? ConsoleColor.Red : ConsoleColor.Green;
                    Console.WriteLine("{0}: {1}", message.Index, message.Text);
                    Console.ResetColor();

                }));

            });

        }

        public void Stop()
        {
            if (bus != null) bus.Dispose();
        }
    }
}
