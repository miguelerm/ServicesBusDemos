
using Topshelf;
namespace MassTransitDemo.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<ClientHost>(s =>
                {
                    s.ConstructUsing(name => new ClientHost());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("MassTransit Demo Client");
                x.SetDisplayName("MassTransitDemoClient");
                x.SetServiceName("MassTransitDemoClient");
            });
        }
    }
}
