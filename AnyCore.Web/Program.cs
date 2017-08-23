using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace AnyCore.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                System.Diagnostics.Debug.WriteLine(arg);

            }
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
