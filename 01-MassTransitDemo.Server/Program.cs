
using Topshelf;
namespace MassTransitDemo.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<ServerHost>(s =>
                {
                    s.ConstructUsing(name => new ServerHost());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("MassTransit Demo Server");
                x.SetDisplayName("MassTransitDemoServer");
                x.SetServiceName("MassTransitDemoServer");
            });
        }
    }
}
